using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetesAlkalmazasFejlesztesJC0YK5.Data
{
    public class ProductPart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TermekId { get; set; }

        [Required]
        public int AlkatreszId { get; set; }

        [Required]
        public int Mennyiseg { get; set; }
    }
}
