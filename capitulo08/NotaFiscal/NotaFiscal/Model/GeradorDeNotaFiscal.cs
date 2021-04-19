using System;
using System.Collections.Generic;
using System.Text;

namespace NotaFiscalApp.Model
{
    public class GeradorDeNotaFiscal
    {
        private NFDao Dao;
        private SAP Sap;

        public GeradorDeNotaFiscal(NFDao dao, SAP sap)
        {
            Dao = dao;
            Sap = sap;
        }

        public NotaFiscal Gera(Pedido pedido)
        {
            NotaFiscal nf = new NotaFiscal(pedido.Cliente, pedido.ValorTotal * 0.94, DateTime.Now);

            Dao.Persiste(nf);
            Sap.Envia(nf);

            return nf;
        }
    }
}
