using CamDoorBellApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CamDoorBellApp.Controllers
{
    public class SampleController : ApiController
    {
        [Route("api/Sample")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @"
                    select SampleId, SampleName, SampleSize, SampleLink, PlaylistName from
                    dbo.Samples
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
        [Route("api/Sample")]
        [HttpPost]
        public string Post(Sample sample)
        {
            try
            {
                string query = @"
                    insert into dbo.Samples (SampleName, SampleSize, SampleLink, PlaylistName ) values
                    ('" + sample.SampleName + @"',
                     '" + sample.SampleSize + @"',
                     '" + sample.SampleLink + @"',
                     '" + sample.PlaylistName + @"'
  
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
        [Route("api/Sample")]
        [HttpPut]
        public string Put(Sample sample)
        {
            try
            {
                string query = @"
                    update dbo.Samples set 
                    SampleName='" + sample.SampleName + @"'
                    ,SampleSize='" + sample.SampleSize + @"'
                    ,SampleLink='" + sample.SampleLink + @"'
                    ,PlaylistName='" + sample.PlaylistName + @"'
                    where SampleId=" + sample.SampleId + @"
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
                return "Updated Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Update!";
            }
        }
        [HttpDelete]
        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Samples 
                    where SampleId=" + id + @"
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
                return "Deleted Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }

        [Route("api/Sample/uploadFile")]
        public string uploadFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Files/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            }
            catch(Exception)
            {
                return "empty file!";
            }

        }

        [Route("api/Sample/getAllPlaylistNames")]
        [HttpGet]
        public HttpResponseMessage getAllPlaylistNames()
        {
            string query = @"select dbo.Playlists.PlaylistName from dbo.Playlists";
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
        [Route("api/Sample/RemoveSample")]
        [HttpPut]
        public void RemoveSample(Sample sample)
        {
            var target = HttpContext.Current.Server.MapPath("~/Files/" + sample.SampleName);
            File.Delete(target);
        }
    }
}
