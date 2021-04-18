using System;
using System.Collections.Generic;
using System.Text;

namespace NotaFiscalApp.Model
{
    public class Pedido
    {
        public string Cliente { get; private set; }
        public double ValorTotal { get; private set; }
        public int QuantidadeItens { get; private set; }

        public Pedido(string cliente, double valorTotal, int quantidadeItens)
        {
            Cliente = cliente;
            ValorTotal = valorTotal;
            QuantidadeItens = quantidadeItens;
        }
    }
}
