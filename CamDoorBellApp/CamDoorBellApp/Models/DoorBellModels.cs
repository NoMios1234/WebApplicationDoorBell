using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CamDoorBellApp.Models
{
    public class Playlist
    {
        public Playlist() 
        {
            samples = new HashSet<Sample>();
        }
        public int PlaylistId { get; set; }
        [Display(Name = "Плейлист")]
        public string PlaylistName { get; set; }
        [Display(Name = "Кількість аудіофайлів")]
        public int CountOfSamp { get; set; }
        [Display(Name = "Розмір плейлиста")]
        public int PlaylistSize { get; set; }
        public ICollection<Sample> samples { get; set; }

    }

    public class Sample
    {
        public int SampleId { get; set; }

        [Display(Name = "Назва аудіофйалу")]
        public string SampleName { get; set; }

        [Display(Name = "Розмір аудіофайлу")]
        public int SampleSize { get; set; }
        [Display(Name = "Посилання на аудіофйал")]
        public string SampleLink { get; set; }
        [Display(Name = "Плейлист")]
        public string PlaylistName { get; set; }
        public virtual Playlist Playlist { get; set; }
    }

    public class WirelessConn 
    {
        public int WirelessConnId { get; set; }

        [Display(Name = "SSID")]
        public string WirelessConnSSID { get; set; }
        [Display(Name = "Password")]
        public string WirelessConnPassword { get; set; }
        [Display(Name = "Режим відтворення")]
        public string WirelessConnMode { get; set; }
        [Display(Name = "Опис точки доступу")]
        public string WirelessConnDesc { get; set; }
    }
    public class Camera
    {
        public int CameraId { get; set; }
        [Display(Name = "Назва камери")]
        public string CameraName { get; set; }
        [Display(Name = "IP камери")]
        public string CameraIp { get; set; }
    }
}