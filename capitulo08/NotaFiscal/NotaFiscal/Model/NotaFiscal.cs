using System;
using System.Collections.Generic;
using System.Text;

namespace NotaFiscalApp.Model
{
    public class NotaFiscal
    {
        public string Cliente { get; private set; }
        public double Valor { get; private set; }
        public DateTime Data { get; private set; }

        public NotaFiscal(string cliente, double valor, DateTime data)
        {
            Cliente = cliente;
            Valor = valor;
            Data = data;
        }
    }
}
