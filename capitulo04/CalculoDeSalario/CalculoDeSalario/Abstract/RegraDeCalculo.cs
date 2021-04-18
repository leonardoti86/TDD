using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoDeSalario.Abstract
{
    public abstract class RegraDeCalculo
    {
        public double Calcula(Funcionario funcionario)
        {
            if (funcionario.Salario > Limite())
                return funcionario.Salario * PorcentagemAcimaDoLimite();

            return funcionario.Salario * PorcentagemBase();
        }

        protected abstract int Limite();

        protected abstract double PorcentagemAcimaDoLimite();

        protected abstract double PorcentagemBase();
    }
}
