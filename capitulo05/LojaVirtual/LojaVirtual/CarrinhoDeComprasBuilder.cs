using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual
{
    /// <summary>
    /// Test Data Builder. 
    /// Design Pattern Builder.
    /// A idéia é facilitar o processo de criação de objetos que serão usados em cenarios de teste.
    /// </summary>
    public class CarrinhoDeComprasBuilder
    {
        public CarrinhoDeCompras carrinho;

        public CarrinhoDeComprasBuilder()
        {
            carrinho = new CarrinhoDeCompras();
        }
        public CarrinhoDeCompras Cria()
        {
            return carrinho;
        }

        public CarrinhoDeComprasBuilder ComItens(params double[] valores) 
        {
            foreach (double valor in valores)
            {
                carrinho.Adiciona(new Item("item", 1, valor));
            }

            return this;
        }

    }
}
