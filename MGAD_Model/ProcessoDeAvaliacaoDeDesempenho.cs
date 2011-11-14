using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGAD_Model
{
    public class ProcessoDeAvaliacaoDeDesempenho
    {        
        private ProcessoDeAvaliacaoDeDesempenho() { }

        private ProcessoDeAvaliacaoDeDesempenho(string nome)
        {
            Nome = nome;
            avaliacoes = new List<Avaliacao>();
        }

        private List<Avaliacao> avaliacoes; 

        public string Nome { get; private set; }               

        public int QuantidadeDeAvaliacoes
        {
            get { return avaliacoes.Count; }
            private set { }
        }

        public Gestor Gestor { get; private set; }       

        

        public static ProcessoDeAvaliacaoDeDesempenho CriarProcessoDeAvaliacaoDeDesempenho(string nome, Gestor gestor)
        {
            ProcessoDeAvaliacaoDeDesempenho processoDeAvaliacaoDeDesempenho = new ProcessoDeAvaliacaoDeDesempenho(nome);
            processoDeAvaliacaoDeDesempenho.Gestor = gestor;

            processoDeAvaliacaoDeDesempenho.avaliacoes.Add(Avaliacao.CriarAvaliacao("Auto avaliação", processoDeAvaliacaoDeDesempenho));
            processoDeAvaliacaoDeDesempenho.avaliacoes.Add(Avaliacao.CriarAvaliacao("Avaliação do gestor", processoDeAvaliacaoDeDesempenho));
            processoDeAvaliacaoDeDesempenho.avaliacoes.Add(Avaliacao.CriarAvaliacao("Avaliação de consenso", processoDeAvaliacaoDeDesempenho));
            
            return processoDeAvaliacaoDeDesempenho;
        }

        public Avaliacao SelecionarAvaliacaoPorTipo(string tipo)
        {
            return avaliacoes.Find(x => x.Tipo == tipo);
        }
        
    }
}
