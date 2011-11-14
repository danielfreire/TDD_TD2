using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGAD_Model
{
    public class GrupoDeComportamentos
    {
        public string Nome { get; private set; }
        private List<Comportamento> comportamentos;

        internal GrupoDeComportamentos(string nomeDoGrupoDeComportamentos)
        {            
            Nome = nomeDoGrupoDeComportamentos;
            comportamentos = new List<Comportamento>();
        }

        public static GrupoDeComportamentos CriarGrupoDeComportamenos(string nomeDoGrupoDeComportamentos)
        {
            GrupoDeComportamentos grupoDeComportamentos = new GrupoDeComportamentos(nomeDoGrupoDeComportamentos);
            new GrupoDeComportamentosDAO().Salvar(grupoDeComportamentos);
            return grupoDeComportamentos;
        }

        public int QuantidadeDeComportamentos
        {
            get
            {
                if (comportamentos == null)
                    return 0;
                return comportamentos.Count;
            }
            set { }           
        }

        public Comportamento RecuperarComportamento(string descricaoDoComportamento)
        {
            if (comportamentos == null)
                return null;
            return comportamentos.Find(c => c.Descricao == descricaoDoComportamento);
        }
    }
}
