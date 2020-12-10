using CamDoorBellApp.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CamDoorBellApp.Controllers
{
    public class WirelessConnController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select WirelessConnId, WirelessConnSSID, WirelessConnPassword, WirelessConnMode, WirelessConnDesc from
                    dbo.WirelessConns
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(WirelessConn wirelessConn)
        {
            try
            {
                string query = @"
                    insert into dbo.WirelessConns values
                    ('" + wirelessConn.WirelessConnSSID + @"',
                     '" + wirelessConn.WirelessConnPassword + @"',
                     '" + wirelessConn.WirelessConnMode + @"',
                     '" + wirelessConn.WirelessConnDesc + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }
        public string Put(WirelessConn wirelessConn)
        {
            try
            {
                string query = @"
                    update dbo.WirelessConns set 
                    WirelessConnSSID='" + wirelessConn.WirelessConnSSID + @"'
                    ,WirelessConnPassword='" + wirelessConn.WirelessConnPassword + @"'
                    ,WirelessConnMode='" + wirelessConn.WirelessConnMode + @"'
                    ,WirelessConnDesc='" + wirelessConn.WirelessConnDesc + @"'
                    where WirelessConnId=" + wirelessConn.WirelessConnId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.WirelessConns 
                    where WirelessConnId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DoorBellAlarmSystemDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }
    }
}
