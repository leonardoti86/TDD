using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessadorBoleto.Models;
using System.Collections.Generic;

namespace ProcessadorBoletoTest
{
    [TestClass]
    public class ProcessadorDeBoletosTest
    {
        [TestMethod]
        public void DeveProcessarPagamentoViaBoletoUnico()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(150.0);
            IList<Boleto> boletos = new List<Boleto>() { b1 };

            processador.Processa(boletos, fatura);

            Assert.AreEqual(1, fatura.Pagamentos.Count);
            Assert.AreEqual(150.0, fatura.Pagamentos[0].Valor, 0.00001);
        }

        [TestMethod]
        public void DeveProcessarPagamentoViaMuitosBoletos()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 300.0);
            Boleto b1 = new Boleto(100.0);
            Boleto b2 = new Boleto(200.0);
            IList<Boleto> boletos = new List<Boleto>() { b1, b2 };

            processador.Processa(boletos, fatura);

            Assert.AreEqual(2, fatura.Pagamentos.Count);
            Assert.AreEqual(100.0, fatura.Pagamentos[0].Valor, 0.00001);
            Assert.AreEqual(200.0, fatura.Pagamentos[1].Valor, 0.00001);
        }

        [TestMethod]
        public void DeveMarcarFaturaComoNaoPagaCasoBoletoUnicoTenhaValorInferiorDaFatura()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(140.0);
            IList<Boleto> boletos = new List<Boleto>() { b1 };

            processador.Processa(boletos, fatura);

            Assert.IsFalse(fatura.Pago);
        }

        [TestMethod]
        public void DeveMarcarFaturaComoPagaCasoBoletoUnicoTenhaValorSuperiorDaFatura()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(160.0);
            IList<Boleto> boletos = new List<Boleto>() { b1 };

            processador.Processa(boletos, fatura);

            Assert.IsTrue(fatura.Pago);
        }

        [TestMethod]
        public void DeveMarcarFaturaComoPagaCasoBoletoUnicoPagueTudo()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(150.0);
            IList<Boleto> boletos = new List<Boleto>() { b1 };

            processador.Processa(boletos, fatura);

            Assert.IsTrue(fatura.Pago);
        }

        [TestMethod]
        public void DeveMarcarFaturaComoNaoPagaCasoBoletosTenhamValorInferiorDaFatura()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(100.0);
            Boleto b2 = new Boleto(40.0);
            IList<Boleto> boletos = new List<Boleto>() { b1, b2 };

            processador.Processa(boletos, fatura);

            Assert.IsFalse(fatura.Pago);
        }

        [TestMethod]
        public void DeveMarcarFaturaComoPagaCasoBoletosTenhamValorSuperiorDaFatura()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(100.0);
            Boleto b2 = new Boleto(60.0);
            IList<Boleto> boletos = new List<Boleto>() { b1, b2 };

            processador.Processa(boletos, fatura);

            Assert.IsTrue(fatura.Pago);
        }

        [TestMethod]
        public void DeveMarcarFaturaComoPagaCasoBoletosTenhamValorIgualDaFatura()
        {
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            Fatura fatura = new Fatura("Cliente", 150.0);
            Boleto b1 = new Boleto(75.0);
            Boleto b2 = new Boleto(75.0);
            IList<Boleto> boletos = new List<Boleto>() { b1, b2 };

            processador.Processa(boletos, fatura);

            Assert.IsTrue(fatura.Pago);
        }
    }
}
