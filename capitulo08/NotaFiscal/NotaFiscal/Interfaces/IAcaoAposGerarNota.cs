using NotaFiscalApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotaFiscalApp.Interfaces
{
    public interface IAcaoAposGerarNota
    {
        void Executa(NotaFiscal nf);
    }
}
