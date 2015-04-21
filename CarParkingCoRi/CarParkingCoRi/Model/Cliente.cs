using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarParkingCoRi.Model
{
    public class Cliente
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string telefono { get; set; } 
        public string placa { get; set; }
        public string  tipoServicio { get; set; }
        public bool estado { get; set; }

        public Cliente() { }

        public Cliente(string ced, string nom, string ape1, string ape2, string tel, string placa, string tipoServ, bool est)
        {
            this.id = id;
            cedula = ced;
            nombre = nom;
            apellido1 = ape1;
            apellido2 = ape2;
            telefono = tel;
            this.placa = placa;
            tipoServicio = tipoServ;
            estado = est;
                
        }
    
    }
}