using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumeraisRomanos;

namespace NumeraisRomanosTest
{
    [TestClass]
    public class ConversorDeNumeroRomanoTest
    {
        [TestMethod]
        public void DeveEntenderOSimboloI()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("I");
            Assert.AreEqual(1, numero);
        }

        [TestMethod]
        public void DeveEntenderOSimboloV()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("V");
            Assert.AreEqual(5, numero);
        }

        [TestMethod]
        public void DeveEntenderDoisSimbolosComoII()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("II");
            Assert.AreEqual(2, numero);
        }

        [TestMethod]
        public void DeveEntenderQuatroSimbolosDoisADoisComoXXII()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("XXII");
            Assert.AreEqual(22, numero);
        }

        [TestMethod]
        public void DeveEntenderNumerosComoIX()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("IX");
            Assert.AreEqual(9, numero);
        }

        [TestMethod]
        public void DeveEntenderNumerosComplexosComoXXIV()
        {
            ConversorDeNumeroRomano romano = new ConversorDeNumeroRomano();
            int numero = romano.Converte("XXIV");
            Assert.AreEqual(24, numero);
        }
    }
}
