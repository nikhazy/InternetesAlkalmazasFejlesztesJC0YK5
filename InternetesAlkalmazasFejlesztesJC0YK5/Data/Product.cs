using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetesAlkalmazasFejlesztesJC0YK5.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kérlek nevezd el a terméket!")]
        [StringLength(20, ErrorMessage = "A megnevezésnek 1 karakternél többnek de 20 karakternél kevesebbnek kell lennie!", MinimumLength = 1)]
        public string Megnevezes { get; set; }

        [Required]
        public int SulyGrammban { get; set; }

        [Required]
        public int Ar { get; set; }


    }
}
