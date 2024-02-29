using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGICA
{
    
    public class Logica_Presentacion
    {
        string DBContraseña = "pass";
        public bool evaluarContraseña(string contraseña) {

            if (DBContraseña.Equals(contraseña)) { 
            return true;
            } else return false;
        
        }


    }
}
