using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NotebookWebApp.Models
{
    public class Notebook
    {
        public int NotebookID { get; set; }

        [Required]
        [Display(Name = "Модель")]
        [StringLength(25)]
        public string Model { get; set; }
        
        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Оперативная память")]
        public int RAM { get; set; }

        [Required]
        [Display(Name = "Жесткий диск")]
        public int HDD { get; set; }

        [Required]
        [Display(Name = "Диагональ монитора")]
        public float Monitor { get; set; }

        [Required]
        [Display(Name = "Производитель")]
        [StringLength(30)]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Процессор")]
        [StringLength(30)]
        public string Processor { get; set; }

        [Required]
        [Display(Name = "ФИО")]
        [StringLength(30)]
        public string User { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(30)]
        public string Email { get; set; }
    }
}