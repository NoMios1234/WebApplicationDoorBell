using CamDoorBellApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CamDoorBellApp.Controllers
{
    public class SamplesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select Id,Name, Size, AudioLibId from
                    dbo.Samples
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
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Sample sample)
        {
            try
            {
                string query = @"
                    insert into dbo.Samples values
                    ('" + sample.Name + @"',
                     '" + sample.Size + @"',
                     '" + sample.AudioLibId + @"'
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
        public string Put(Sample sample)
        {
            try
            {
                string query = @"
                    update dbo.Samples set 
                    Name='" + sample.Name + @"'
                    ,Size='" + sample.Size + @"'
                    ,AudioLibId='" + sample.AudioLibId + @"'
                    where Id=" + sample.Id + @"
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
                    delete from dbo.Samples 
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
        [Route("api/Samples/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var pytsicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(pytsicalPath);

                return filename;
            }
            catch(Exception)
            {
                return "anonymuos.png";
            }
        }
    }
}
