namespace ProcessadorBoleto.Models
{
    public class Boleto
    {
        public double Valor { get; private set; }

        public Boleto(double valor)
        {
            Valor = valor;
        }
    }
}