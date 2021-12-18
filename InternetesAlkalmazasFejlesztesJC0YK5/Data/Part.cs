using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InternetesAlkalmazasFejlesztesJC0YK5.Validation;

namespace InternetesAlkalmazasFejlesztesJC0YK5.Data
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kérlek nevezd el az alkatrészt!")]
        [StringLength(20, ErrorMessage = "A megnevezésnek 1 karakternél többnek de 20 karakternél kevesebbnek kell lennie!", MinimumLength = 1)]
        public string Megnevezes { get; set; }

        [Required]
        [Weight(ErrorMessage = "Kérlek adj meg egy valós súly értéket!")]
        public int SulyGrammban { get; set; }

        [Required]
        [Price(ErrorMessage = "Kérlek adj meg egy valós árat!")]
        public int Ar { get; set; }

        public Part()
        {

        }
    }
}
