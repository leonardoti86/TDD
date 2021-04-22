using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NotaFiscalApp.Interfaces;
using NotaFiscalApp.Model;
using System.Collections.Generic;

namespace NotaFiscalTest
{
    [TestClass]
    public class GeradorDeNotaFiscalTest
    {
        //[TestMethod]
        //public void DeveGerarNFComValorDeImpostoDescontado()
        //{
        //    //criando o mock
        //    var dao = new Mock<NFDao>(); //não deveria estar aqui pq queremos testar apenas o valor de imposto descontado
        //    var sap = new Mock<SAP>(); //não deveria estar aqui pq queremos testar apenas o valor de imposto descontado

        //    GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(dao.Object, sap.Object);
        //    Pedido pedido = new Pedido("Leonardo", 1000, 1);
        //    NotaFiscal nf = gerador.Gera(pedido);
        //    Assert.AreEqual(1000 * 0.94, nf.Valor, 0.0001);
        //}

        //[TestMethod]
        //public void DevePersistirNFGerada()
        //{
        //    //criando o mock
        //    var dao = new Mock<NFDao>();
        //    var sap = new Mock<SAP>(); //não deveria estar aqui pq queremos testar só a persistencia dos dados no banco de dados.

        //    GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(dao.Object, sap.Object);
        //    Pedido pedido = new Pedido("Leonardo", 1000, 1);
        //    NotaFiscal nf = gerador.Gera(pedido);

        //    //verificando que o método foi invocado
        //    dao.Verify(t => t.Persiste(nf));
        //} 

        //[TestMethod]
        //public void DeveEnviarNFGeradaParaSAP()
        //{
        //    var dao = new Mock<NFDao>(); //não deveria estar aqui pq queremos testar só o envio para SAP.
        //    var sap = new Mock<SAP>();

        //    GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(dao.Object, sap.Object);
        //    Pedido pedido = new Pedido("Leonardo", 1000, 1);
        //    NotaFiscal nf = gerador.Gera(pedido);

        //    sap.Verify(t => t.Envia(nf));
        //}

        [TestMethod]
        public void DeveInvocarAcoesPosteriores()
        {
            var acao1 = new Mock<IAcaoAposGerarNota>();
            var acao2 = new Mock<IAcaoAposGerarNota>();

            IList<IAcaoAposGerarNota> acoes = new List<IAcaoAposGerarNota>() { acao1.Object, acao2.Object };

            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(acoes);
            Pedido pedido = new Pedido("Leonardo", 1000, 1);
            NotaFiscal nf = gerador.Gera(pedido);

            acao1.Verify(a => a.Executa(nf));
            acao2.Verify(a => a.Executa(nf));
        }

        [TestMethod]
        public void DeveConsultarATabelaParaCalcularValor()
        {
            var tabela = new Mock<ITabela>();
            var relogio = new Mock<IRelogio>();

            //definindo o futuro comportamento "ParaValor", que deve retornar 0.2 caso o valor seja 1000
            tabela.Setup(t => t.ParaValor(1000)).Returns(0.2);

            IList<IAcaoAposGerarNota> nenhumaAcao = new List<IAcaoAposGerarNota>();

            GeradorDeNotaFiscal gerador = new GeradorDeNotaFiscal(nenhumaAcao, relogio.Object, tabela.Object);
            Pedido pedido = new Pedido("Leonardo", 1000, 1);
            NotaFiscal nf = gerador.Gera(pedido);

            tabela.Verify(t => t.ParaValor(1000.0));
            Assert.AreEqual(1000 * 0.2, nf.Valor, 0.00001);
        }
    }
}