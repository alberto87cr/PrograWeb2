using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarParkingCoRi.Model
{
    public class FacturaPorHora
    {
        public int idFactura { get; set; }
        public int idServicio { get; set; }
        public double monto { get; set; }
        public DateTime fecha { get; set; }

        public FacturaPorHora() { }
    }
}