using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliceria.Data.Models


{
    public class Utilizator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }

        public ICollection<Recenzie> Recenzii { get; set; }
    }
}
