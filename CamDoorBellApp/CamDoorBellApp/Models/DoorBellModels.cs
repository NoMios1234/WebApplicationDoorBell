using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamDoorBellApp.Models
{
    public class AudioLib
    {
        public AudioLib() // аудіотека
        {
            samples = new HashSet<Sample>();
        }
        public int Id { get; set; }
        [Display(Name = "Аудіотека")]
        public string Name { get; set; }
        [Display(Name = "Кількість аудіофайлів")]
        public decimal Count { get; set; }
        [Display(Name = "Розмір аудіотеки")]
        public double Size { get; set; }
        [Display(Name = "Режим відтворення")]
        public int PlayModeId { get; set; }
        public virtual PlayMode PlayMode { get; set; }
        public ICollection<Sample> samples { get; set; }

    }
    public class PlayMode // режим відтворення
    {
        public PlayMode()
        {
            audioLibs = new HashSet<AudioLib>();
        }
        public int Id { get; set; }
        [Display(Name = "Назва режиму відтворення")]
        public string Name { get; set; }
        [Display(Name = "Опис режиму відтворення")]
        public string Description { get; set; }
        public ICollection<AudioLib> audioLibs { get; set; }

    }

    public class Sample // аудіофайл
    {
        public int Id { get; set; }
        [Display(Name = "Назва аудіофйалу")]
        [Required(ErrorMessage = "Неправильна назва!")]
        [Remote("CheckName", "SamplesController", HttpMethod = "POST", ErrorMessage = "Файл уже є в аудіотеці!")]
        public string Name { get; set; }

        [Display(Name = "Розмір аудіофайлу")]
        public double Size { get; set; }
        [Display(Name = "Аудіотека")]
        public int AudioLibId { get; set; }
        public virtual AudioLib AudioLib { get; set; }
    }
    public class DoorBellMode // режим роботи дзвінка (STA or AP)
    {
        public DoorBellMode()
        {
            wi_Fis = new HashSet<Wi_Fi>();
        }
        public int Id { get; set; }
        [Display(Name = "Назва режиму відтворення")]
        public string NameMode { get; set; }
        [Display(Name = "Опис режиму відтвоерння")]
        public string Description { get; set; }
        public ICollection<Wi_Fi> wi_Fis { get; set; }

    }
    public class Wi_Fi // ssid та pass для Wi-Fi 
    {
        public int Id { get; set; }

        [Display(Name = "Назва точки доступу Wi-Fi")]
        public string SSID { get; set; }
        [Display(Name = "Пароль точки доступу Wi-Fi")]
        public string Password { get; set; }
        [Display(Name = "Опис точки доступу")]
        public string Description { get; set; }
        [Display(Name = "Назва режиму відтворення")]
        public int DoorBellModeId { get; set; }
        [Display(Name = "Назва режиму відтворення")]
        public virtual DoorBellMode DoorBellMode { get; set; }

    }
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Resolution { get; set; }
        public string Position { get; set; }

    }
}