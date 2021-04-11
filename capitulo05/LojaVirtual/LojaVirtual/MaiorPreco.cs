using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual
{
    public class MaiorPreco
    {
        // esse algoritmo migrou para a classe CarrinhoDeCompras pq depende 100% da classe CarrinhoDeCompras
        public double Encontra(CarrinhoDeCompras carrinho)
        {
            if(carrinho.Itens.Count.Equals(0))
                return 0.0;

            double maior = carrinho.Itens[0].ValorTotal;

            foreach (var item in carrinho.Itens)
            {
                if (maior < item.ValorTotal)
                    maior = item.ValorTotal;
            }

            return maior;
        }
    }
}
