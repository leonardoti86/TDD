using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NotaFiscalApp.Model;

namespace NotaFiscalTest
{
    [TestClass]
    public class GeradorDeNotaFiscalTest
    {
        [TestMethod]
        public void DeveGerarNFComValorDeImpostoDescontado()
        {
            //criando o mock
            var dao = new Mock<NFDao>(); //n�o deveria estar aqui pq queremos testar apenas o valor de imposto descontado
            var sap = new Mock<SAP>(); //n�o deveria estar aqui pq queremos testar apenas o valor de imposto descontado

            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(dao.Object, sap.Object);
            Pedido pedido = new Pedido("Leonardo", 1000, 1);
            NotaFiscal nf = gerador.Gera(pedido);
            Assert.AreEqual(1000 * 0.94, nf.Valor, 0.0001);
        }
      
        [TestMethod]
        public void DevePersistirNFGerada()
        {
            //criando o mock
            var dao = new Mock<NFDao>();
            var sap = new Mock<SAP>(); //n�o deveria estar aqui pq queremos testar s� a persistencia dos dados no banco de dados.

            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(dao.Object, sap.Object);
            Pedido pedido = new Pedido("Leonardo", 1000, 1);
            NotaFiscal nf = gerador.Gera(pedido);

            //verificando que o m�todo foi invocado
            dao.Verify(t => t.Persiste(nf));
        }

        [TestMethod]
        public void DeveEnviarNFGeradaParaSAP()
        {
            var dao = new Mock<NFDao>(); //n�o deveria estar aqui pq queremos testar s� o envio para SAP.
            var sap = new Mock<SAP>();

            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(dao.Object, sap.Object);
            Pedido pedido = new Pedido("Leonardo", 1000, 1);
            NotaFiscal nf = gerador.Gera(pedido);

            sap.Verify(t => t.Envia(nf));
        }

    }
}
