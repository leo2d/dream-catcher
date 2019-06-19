using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCatcher.Models.ViewModels
{
    public class DreamTaskViewModel
    {
        public Guid Id { get; set; }
        public Guid IdDream { get; set; }

        [Required(ErrorMessage = "É obrigatório o Titulo")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Display(Name = "Tarefa foi Feita")]
        public bool IsDone { get; set; }
    }
}
