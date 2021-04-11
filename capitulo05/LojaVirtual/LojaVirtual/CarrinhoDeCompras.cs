using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual
{
    public class CarrinhoDeCompras
    {
        public IList<Item> Itens { get; private set; }

        public CarrinhoDeCompras()
        {
            Itens = new List<Item>();
        }

        public void Adiciona(Item item)
        {
            Itens.Add(item);
        }
    }
}
