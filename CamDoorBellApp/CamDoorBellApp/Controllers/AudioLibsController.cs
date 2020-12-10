using CamDoorBellApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CamDoorBellApp.Controllers
{
    public class AudioLibsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select Id,Name, Count, Size, PlayModeId from
                    dbo.AudioLibs
                    ";
            DataTable table = new DataTable();
            using(var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["ddDoorBell"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(AudioLib audioLib)
        {
            try
            {
                string query = @"
                    insert into dbo.AudioLibs values
                    ('" + audioLib.Name + @"',
                     '" + audioLib.Count + @"',
                     '" + audioLib.Size + @"',
                     '" + audioLib.PlayModeId + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ddDoorBell"].ConnectionString))
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
        public string Put(AudioLib audioLib)
        {
            try
            {
                string query = @"
                    update dbo.AudioLibs set 
                    Name='" + audioLib.Name + @"'
                    ,Count='" + audioLib.Count + @"'
                    ,Size='" + audioLib.Size + @"'
                    ,PlayModeId='" + audioLib.PlayModeId + @"'
                    where Id=" + audioLib.Id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ddDoorBell"].ConnectionString))
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
                    delete from dbo.AudioLibs 
                    where Id=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ddDoorBell"].ConnectionString))
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

        [Route("api/AudioLibs/GetAllPlayModes")]
        [HttpGet]
        public HttpResponseMessage GetAllPlayModes()
        {
            string query = @"
                    select Name from dbo.PlayModes";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["ddDoorBell"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
