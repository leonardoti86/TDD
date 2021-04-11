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

        public double MaiorValor()
        {
            if (Itens.Count.Equals(0))
                return 0.0;

            double maior = Itens[0].ValorTotal;

            foreach (var item in Itens)
            {
                if (maior < item.ValorTotal)
                    maior = item.ValorTotal;
            }

            return maior;
        }
    }
}
