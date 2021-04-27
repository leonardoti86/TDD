using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessadorBoleto.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessadorBoletoTest
{
    [TestClass]
    public class FaturaTest
    {
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
