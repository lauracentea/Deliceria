using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliceria.Data.Models
{
    public class Recenzie
    {
        public int RecenzieId { get; set; }
        public int ProdusId { get; set; }
        public int ClientId { get; set; }
        public string TextRecenzie { get; set; }
        public int Rating { get; set; }

        public Utilizator Client { get; set; }
        public Produs Produs { get; set; }
    }
}
