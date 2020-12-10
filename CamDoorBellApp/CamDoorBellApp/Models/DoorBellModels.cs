using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamDoorBellApp.Models
{
    public class Playlist
    {
        public Playlist() // аудіотека
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
        public int SampleId { get; set; }
        public ICollection<Sample> samples { get; set; }

    }

    public class Sample // аудіофайл
    {
        public int SampleId { get; set; }

        [Display(Name = "Назва аудіофйалу")]
        [Required(ErrorMessage = "Неправильна назва!")]
        [Remote("CheckName", "SamplesController", HttpMethod = "POST", ErrorMessage = "Файл уже є в аудіотеці!")]
        public string SampleName { get; set; }

        [Display(Name = "Розмір аудіофайлу")]
        public int SampleSize { get; set; }
        public string SampleLink { get; set; }
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }
    }

    public class WirelessConn // ssid та pass для Wi-Fi 
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
        public string CameraName { get; set; }
        public string CameraIp { get; set; }
    }
}