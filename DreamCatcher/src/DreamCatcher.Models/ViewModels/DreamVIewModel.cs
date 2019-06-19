using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamCatcher.Models.ViewModels
{
    public class DreamVIewModel
    {
        public DreamVIewModel()
        {
            Tasks = new List<DreamTaskViewModel>();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "É obrigatório o Titulo")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Display(Name = "Completo")]
        public bool IsDone { get; set; }

        [DisplayFormat( ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data cadastro")]
        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }


        public Guid IDUser { get; set; }

        [Display(Name = "Sonhador")]
        public string User { get; set; }
        public List<DreamTaskViewModel> Tasks { get; set; }
    }
}
