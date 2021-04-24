using System.Collections.Generic;

namespace ProcessadorBoleto.Models
{
    public class Fatura
    {
        public string Cliente { get; private set; }
        public double Valor { get; private set; }
        public IList<Pagamento> Pagamentos { get; private set; }
        public bool Pago { get; set; }

        public Fatura(string cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            Pagamentos = new List<Pagamento>();
            Pago = false;
        }
    }

    public enum MeioDePagamento
    {
        BOLETO,
        CARTAO
    }
}