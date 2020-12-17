using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data.Entities
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ci { get; set; }
        public DateTime? BornDate { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public List<string> Classes { get; set; }
    }
}
