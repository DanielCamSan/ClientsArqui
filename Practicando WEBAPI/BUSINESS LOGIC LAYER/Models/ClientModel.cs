using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Ci { get; set; }
        public DateTime? BornDate { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public List<string> Classes { get; set; }
    }
}
