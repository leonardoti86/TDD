using NotaFiscalApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotaFiscalApp.Model
{
    public class RelogioDoSistema : IRelogio
    {
        public DateTime Hoje()
        {
            return DateTime.Now;
        }
    }
}
