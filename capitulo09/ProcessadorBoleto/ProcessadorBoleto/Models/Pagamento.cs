namespace ProcessadorBoleto.Models
{
    public class Pagamento
    {
        public double Valor { get; private set; }
        public MeioDePagamento TipoDePagamento { get; private set; }

        public Pagamento(double valor, MeioDePagamento meioDePagamento)
        {
            Valor = valor;
            TipoDePagamento = meioDePagamento;
        }
    }
}