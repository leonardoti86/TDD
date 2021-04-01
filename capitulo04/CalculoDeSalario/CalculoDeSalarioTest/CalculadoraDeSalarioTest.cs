using CalculoDeSalario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculoDeSalarioTest
{
    [TestClass]
    public class CalculadoraDeSalarioTest
    {
        [TestMethod]
        public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Mauricio", 1500, Cargo.DESENVOLVEDOR);
            double salario = calculadora.CalculaSalario(desenvolvedor);
            Assert.AreEqual(1500 * 0.9, salario, 0.00001);
        }

        [TestMethod]
        public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAcimaDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario desenvolvedor = new Funcionario("Mauricio", 4000, Cargo.DESENVOLVEDOR);
            double salario = calculadora.CalculaSalario(desenvolvedor);
            Assert.AreEqual(4000 * 0.8, salario, 0.00001);
        }

        [TestMethod]
        public void DeveCalcularSalarioParaDBAComSalarioAbaixoDoLimite()
        {
            CalculadoraDeSalario calculadora = new CalculadoraDeSalario();
            Funcionario dba = new Funcionario("Mauricio", 500, Cargo.DBA);
            double salario = calculadora.CalculaSalario(dba);
            Assert.AreEqual(500 * 0.85, salario, 0.00001);
        }
    }
}
