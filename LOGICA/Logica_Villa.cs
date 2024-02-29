using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ENTIDADES;

namespace LOGICA
{


    public class Logica_Villa
    {
        decimal numresultado;
        int numresultadoInt;
        List<Villa> villas = new List<Villa>();

        public void crearVilla(Villa villa)
        {
            villas.Add(villa);
        }
        public List<Villa> getVillas()
        {
            return villas;
        }

        public bool ParseDecimal(string numero)
        {
            if (!decimal.TryParse(numero, out numresultado))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool ParseInt(string numero)
        {
            if (!int.TryParse(numero, out numresultadoInt))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void ActualizarVilla(Villa villa)
        {
            foreach (Villa item in villas)
            {
                if (item.ID == villa.ID) {
                    item.Nombre = villa.Nombre;
                    item.Habitantes = villa.Habitantes;
                    item.Area = villa.Area;
                    item.Precio = villa.Precio;
                }
            }

        }

        public void EliminarVilla(int id) {

            foreach (Villa item in villas) {

                if (item.ID == id) {
                    villas.Remove(item);
                    return;
                }

            }
        }

        public int ObtenerNVillas() {
            int i = 0;
            foreach (Villa item in villas) {
                i++;
            }
            return i;
        }

        public Villa ObtenerVillaMasCostosa()
        {
            Villa villaCostosa = new Villa();

            villaCostosa.Precio = 0;

            foreach(Villa villaActual in villas) {

                if (villaActual.Precio > villaCostosa.Precio)
                {
                    villaCostosa = villaActual;
                }
            }

            return villaCostosa;
        }

        public string ObtenerPrecioVillaCostosa()
        {
            Villa villa = ObtenerVillaMasCostosa();

            return villa.Precio.ToString();
        }

        public string ObtenerNombreVillaCostosa()
        {
            Villa villa = ObtenerVillaMasCostosa();

            return villa.Nombre;
        }

        public Villa ObtenerVillaBarata()
        {
            Villa villaBarata = new Villa();

            villaBarata.Precio = ObtenerVillaMasCostosa().Precio;

            foreach (Villa villaActual in villas)
            {

                if (villaActual.Precio < villaBarata.Precio)
                {
                    villaBarata = villaActual;
                }
            }
            return villaBarata;
        }
        public string ObtenerPrecioVillaBarata()
        {
            Villa villa = ObtenerVillaBarata();

            return villa.Precio.ToString();
        }

        public string ObtenerNombreVillaBarata()
        {
            Villa villa = ObtenerVillaBarata();

            return villa.Nombre;
        }

        public string ObtenerValorTotalVillas() {

            decimal valorTotal = 0;
            foreach (Villa villaActual in villas)
            {
                valorTotal += villaActual.Precio;
            }

            return valorTotal.ToString();
        }

        public string ObtenerHabitantes()
        {

            int habitantes = 0;
            foreach (Villa villaActual in villas)
            {
                habitantes += villaActual.Habitantes;
            }

            return habitantes.ToString();
        }

        public string ObtenerPromedioPrecio() 
        {
            return Convert.ToString(Convert.ToDecimal(ObtenerValorTotalVillas()) / Convert.ToDecimal(ObtenerNVillas())); 
        }

        public bool VillaExistente(int Id)
        {
            bool existe = false;    
            foreach (Villa villa in villas)
            {
                if (Id == villa.ID)
                {
                    existe = true;
                    return existe;
                } else { existe = false; }

            }
            return existe;
        }




    }
}

