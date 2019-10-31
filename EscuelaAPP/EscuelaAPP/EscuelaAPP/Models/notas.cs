using System;
using System.Collections.Generic;
using System.Text;

namespace EscuelaAPP.Models
{
    public class notas
    {
        public int idnota { get; set; }
        public Nullable<float> nota1 { get; set; }
        public Nullable<float> nota2 { get; set; }
        public Nullable<float> nota3 { get; set; }
        public Nullable<float> promedio { get; set; }
        public string estado { get; set; }
    }
}
