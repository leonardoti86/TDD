using LojaVirtual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaVirtualTest
{
    [TestClass]
    public class CarrinhoDeComprasTest
    {
        private CarrinhoDeCompras Inicializa()
        {
            return new CarrinhoDeCompras();
        }

        [TestMethod]
        public void DeveRetornarZeroSeCarrinhoVazio()
        {
            var carrinho = Inicializa();
            Assert.AreEqual(0.0, carrinho.MaiorValor(), 0.0001);
        }

        [TestMethod]
        public void DeveRetornarValorDoItemSeCarrinhoCom1Elemento()
        {
            var carrinho = Inicializa();
            carrinho.Adiciona(new Item("Geladeira", 1, 900.0));
            Assert.AreEqual(900.0, carrinho.MaiorValor(), 0.0001);
        }

        [TestMethod]
        public void DeveRetornarMaiorValorSeCarrinhoContemMuitosElementos()
        {
            var carrinho = Inicializa();
            carrinho.Adiciona(new Item("Geladeira", 1, 900.0));
            carrinho.Adiciona(new Item("Fogão", 1, 1500.0));
            carrinho.Adiciona(new Item("Maquina de lavar", 1, 750));
            Assert.AreEqual(1500.0, carrinho.MaiorValor(), 0.0001);
        }
    }
}
