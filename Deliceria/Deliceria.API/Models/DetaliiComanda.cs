using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliceria.Data.Models
{
    public class DetaliiComanda
    {
        public int DetaliiComandaId { get; set; }
        public int ComandaId { get; set; }
        public int ProdusId { get; set; }
        public int Cantitate { get; set; }

        public Comanda Comanda { get; set; }
        public Produs Produs { get; set; }
    }
}
