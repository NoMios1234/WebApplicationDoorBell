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
    public class PlaylistController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select PlaylistId, PlaylistName, CountOfSamp, PlaylistSize from
                    dbo.Playlists
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

        public string Post(Playlist playlist)
        {
            try
            {
                string query = @"
                    insert into dbo.Playlists values
                    ('" + playlist.PlaylistName + @"',
                     '" + playlist.CountOfSamp + @"',
                     '" + playlist.PlaylistSize + @"'
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
        public string Put(Playlist playlist)
        {
            try
            {
                string query = @"
                    update dbo.Playlists set 
                    PlaylistName='" + playlist.PlaylistName + @"'
                    ,CountOfSamp='" + playlist.CountOfSamp + @"'
                    ,PlaylistSize='" + playlist.PlaylistSize + @"'
                    where PlaylistId=" + playlist.PlaylistId + @"
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
                    delete from dbo.Playlists 
                    where PlaylistId=" + id + @"
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

        [Route("api/Playlist/getAllSamples")]
        [HttpGet]
        public HttpResponseMessage getAllSamples()
        {
            string query = @"
                    select dbo.Samples.SampleName, dbo.Samples.SampleSize from dbo.Samples, dbo.Playlists
                    where dbo.Samples.PlaylistId = dbo.Playlists.PlaylistId";

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
        /// <summary>
        /// /////////////////////////////
        /// </summary>
        /// <returns></returns>
        [Route("api/Playlist/getId")]
        [HttpGet]
        public HttpResponseMessage getId()
        {
            string query = @"
                    select MIN(dbo.Playlists.PlaylistId) from dbo.Playlists";

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


    }
}
