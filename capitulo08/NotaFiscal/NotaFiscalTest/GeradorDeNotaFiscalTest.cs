using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotaFiscalApp.Model;

namespace NotaFiscalTest
{
    [TestClass]
    public class GeradorDeNotaFiscalTest
    {
        [TestMethod]
        public void DeveGerarNFComValorDeImpostoDescontado()
        {
            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal();
            Pedido pedido = new Pedido("Leonardo", 1000, 1);
            NotaFiscal nf = gerador.Gera(pedido);
            Assert.AreEqual(1000 * 0.94, nf.Valor, 0.0001);
        }
    }
}
