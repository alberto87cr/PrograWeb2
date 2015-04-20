using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarParkingCoRi.Model
{
    public class ServicioPorHora
    {
        public int idServicio { get; set; }
        public int idCliente { get; set; }//si no es cliente por mes, setear como -1
        public string cedula { get; set; }//si no es cliente por mes, setear como vacio
        public string placa {get;set;}
        public int esClientePorMes { get; set; }
        public int exento { get; set; }//logica en la bd,no hace falta setear desde la aplcacion
        public DateTime horaEntrada { get; set; }   
        public DateTime horaSalida { get; set; }

        public ServicioPorHora()
        {
        }
    }
}