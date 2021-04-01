using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoDeSalario
{
    public class CalculadoraDeSalario
    {
        public double CalculaSalario(Funcionario funcionario)
        {
            if (funcionario.Cargo.Equals(Cargo.DESENVOLVEDOR))
            {
                if (funcionario.Salario > 3000)
                    return funcionario.Salario * 0.8;

                return funcionario.Salario * 0.9;
            }

            return 425.0;

        }
    }
}
