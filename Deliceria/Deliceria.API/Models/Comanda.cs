using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliceria.Data.Models

{
    public class Comanda
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }

        public ICollection<DetaliiComanda> DetaliiComanda { get; set; }
    }
}
