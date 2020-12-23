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
    public class ViewController : ApiController
    {
        [Route("api/View/updatePlaylistInfoOnAdd")]
        [HttpPut]
        public string updatePlaylistInfoOnAdd(Sample sample)
        {
            if(sample!=null)
            {
                string query = @"
                    UPDATE 
                        dbo.Playlists
                    SET 
                        dbo.Playlists.CountOfSamp = dbo.Playlists.CountOfSamp + 1,
                        dbo.Playlists.PlaylistSize = dbo.Playlists.PlaylistSize + '" + sample.SampleSize + @"'
                    Where dbo.Playlists.PlaylistName = '" + sample.PlaylistName + @"'
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
                return "Playlist was updated!";
            }
            return "Playlist was not updated!";
        }
        [Route("api/View/updatePlaylistInfoOnDelete")]
        [HttpPut]
        public string updatePlaylistInfoOnDelete(Sample sample)
        {
            if (sample != null)
            {
                string query = @"
                    UPDATE 
                        dbo.Playlists
                    SET 
                        dbo.Playlists.CountOfSamp = dbo.Playlists.CountOfSamp - 1,
                        dbo.Playlists.PlaylistSize = dbo.Playlists.PlaylistSize - '" + sample.SampleSize + @"' 
                    Where dbo.Playlists.PlaylistName = '" + sample.PlaylistName + @"'
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
                return "Playlist was updated!";
            }
            return "Playlist was not updated!";
        }

        [Route("api/View/GetWirelessConnInfo")]
        [HttpGet]
        public HttpResponseMessage GetWirelessConnInfo()
        {
            string query = @"
                    select dbo.WirelessConns.WirelessConnSSID, dbo.WirelessConns.WirelessConnPassword, dbo.WirelessConns.WirelessConnMode 
                    from   dbo.WirelessConns
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

        [Route("api/View/GetSampleInfo")]
        [HttpGet]
        public HttpResponseMessage GetSampleInfo()
        {
            string query = @"
                    select dbo.Samples.SampleId, dbo.Samples.SampleName, dbo.Samples.SampleSize
                    from   dbo.Samples
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
    }
}
