using NotaFiscalApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotaFiscalApp.Model
{
    public class GeradorDeNotaFiscal
    {
        private IList<IAcaoAposGerarNota> _acoes;
        private IRelogio _relogio;
        private ITabela _tabela;

        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes)
        {
            _acoes = acoes;
        }

        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes, IRelogio relogio)
        {
            _acoes = acoes;
            _relogio = relogio;
        }

        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes, IRelogio relogio, ITabela tabela)
        {
            _acoes = acoes;
            _relogio = relogio;
            _tabela = tabela;
        }

        public NotaFiscal Gera(Pedido pedido)
        {
            NotaFiscal nf = null;

            if (_relogio != null)
            {
                nf = new NotaFiscal(pedido.Cliente, pedido.ValorTotal * _tabela.ParaValor(pedido.ValorTotal), _relogio.Hoje());
            }
            else
            {
                nf = new NotaFiscal(pedido.Cliente, pedido.ValorTotal * _tabela.ParaValor(pedido.ValorTotal), DateTime.Now);
            }

            foreach (var acao in _acoes)
            {
                acao.Executa(nf);
            }

            return nf;
        }
    }
}
