using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessadorBoleto.Models
{
    public class ProcessadorDeBoletos
    {
        /// <summary>
        /// não manipula mais estado da Fatura se ja esta paga ou não. 
        /// </summary>
        /// <param name="boletos"></param>
        /// <param name="fatura"></param>
        public void Processa(IList<Boleto> boletos, Fatura fatura)
        {
            foreach (var boleto in boletos)
            {
                Pagamento pagamento = new Pagamento(boleto.Valor, MeioDePagamento.BOLETO);
                fatura.AdicionaPagamento(pagamento); //tell, don´t ask... Lei de Demeter
            }
        }
    }
}
