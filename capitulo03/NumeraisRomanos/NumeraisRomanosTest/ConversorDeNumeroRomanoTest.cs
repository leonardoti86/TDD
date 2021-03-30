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
    }
}
