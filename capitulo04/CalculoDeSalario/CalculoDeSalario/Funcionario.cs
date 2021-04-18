using System;
using System.Collections.Generic;
using System.Text;

namespace CalculoDeSalario
{
    //public enum Cargo
    //{
    //    DESENVOLVEDOR,
    //    DBA,
    //    TESTADOR
    //}

    public class Funcionario
    {
        public string Nome { get; set; }
        public double Salario { get; set; }
        public Cargo Cargo { get; set; }

        public Funcionario(string nome, double salario, Cargo cargo)
        {
            Nome = nome;
            Salario = salario;
            Cargo = cargo;
        }
    }
}
