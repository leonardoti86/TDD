namespace LojaVirtual
{
    public class Item
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal 
        { get {
                return ValorUnitario * Quantidade;
            } 
        }

        public Item(string descricao, int quantidade, double valorUnitario)
        {
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }
    }
}