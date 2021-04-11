using LojaVirtual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtualTest
{
    [TestClass]
    public class MaiorPrecoTest
    {
        [TestMethod]
        public void DeveRetornarZeroSeCarrinhoVazio()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();            
            Assert.AreEqual(0.0, carrinho.MaiorValor(), 0.0001);
        }

        [TestMethod]
        public void DeveRetornarValorDoItemSeCarrinhoCom1Elemento()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.Adiciona(new Item("Geladeira", 1, 900.0));
            Assert.AreEqual(900.0, carrinho.MaiorValor(), 0.0001);
        }

        [TestMethod]
        public void DeveRetornarMaiorValorSeCarrinhoContemMuitosElementos()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.Adiciona(new Item("Geladeira", 1, 900.0));
            carrinho.Adiciona(new Item("Fog�o", 1, 1500.0));
            carrinho.Adiciona(new Item("Maquina de lavar", 1, 750));
            Assert.AreEqual(1500.0, carrinho.MaiorValor(), 0.0001);
        }
    }
}
