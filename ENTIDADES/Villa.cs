using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Villa
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Habitantes { get; set; }
        public decimal Area { get; set; }
        public decimal Precio { get; set; }

        public Villa()
        {
        }

        public Villa(int id, string nombre, int habitantes, decimal area, decimal precio)
        {
            ID = id;
            Nombre = nombre;
            Habitantes = habitantes;
            Area = area;
            Precio = precio;
        }
    }
}
