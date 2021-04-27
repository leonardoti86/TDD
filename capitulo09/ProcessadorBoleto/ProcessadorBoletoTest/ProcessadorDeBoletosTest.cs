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
    }
}
