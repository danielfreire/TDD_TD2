using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGAD_Model
{
    public class Avaliacao
    {
        private List<GrupoDeComportamentos> gruposDeComportamentos;

        public string Tipo{ get; private set;  }

        public ProcessoDeAvaliacaoDeDesempenho processoDeAvaliacaoDeDesempenho { get; private set; }

        public string Status 
        {
            get
            {
                return "EmAberto";
            }
            private set { }
        }
         

        private Avaliacao(string tipo)
        {
            if (gruposDeComportamentos == null)
            {
                gruposDeComportamentos = new List<GrupoDeComportamentos>();
            }

            gruposDeComportamentos = GrupoDeComportamentosDAO.SelecionarTodosGruposDeComportamentos();
            Tipo = tipo;           
        }

        public static Avaliacao CriarAvaliacao(string tipo, ProcessoDeAvaliacaoDeDesempenho processoDeAvaliacaoDeDesempenho) 
        {
            Avaliacao avaliacao = new Avaliacao(tipo);
            avaliacao.processoDeAvaliacaoDeDesempenho = processoDeAvaliacaoDeDesempenho;
            new AvaliacaoDAO().Salvar(avaliacao);
            return avaliacao;
        }

        public  int QuantidadeDeGruposComportamentais 
        {
            get
            {
                if (gruposDeComportamentos == null)
                    return 0;
                return gruposDeComportamentos.Count;
            }
            private set { }
        }

        public GrupoDeComportamentos RecuperarGrupoDeComportamentos(string nomeGrupoDeComportamentos)
        {
            return gruposDeComportamentos.Find(g => g.Nome == nomeGrupoDeComportamentos);
        }
    }
}
