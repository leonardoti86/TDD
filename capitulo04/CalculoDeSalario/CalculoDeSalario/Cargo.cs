using CalculoDeSalario.Abstract;
using CalculoDeSalario.Regras;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoDeSalario
{
    public class Cargo
    {
        public static Cargo DESENVOLVEDOR 
        { 
            get 
            {
                return new Cargo(new DezOuVintePorCento());
            } 
        }

        public static Cargo DBA
        {
            get
            {
                return new Cargo(new QuinzeOuVinteCincoPorCento());
            }
        }

        public static Cargo TESTADOR
        {
            get
            {
                return new Cargo(new QuinzeOuVinteCincoPorCento());
            }
        }

        public RegraDeCalculo Regra { get; private set; }

        private Cargo(RegraDeCalculo regra)
        {
            Regra = regra;
        }
    }
}
