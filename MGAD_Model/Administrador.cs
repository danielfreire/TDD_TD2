using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGAD_Model
{
    public class Administrador
    {   
        public GrupoDeComportamentos CriarGrupoComportamentos(string nomeDoGrupoDeComportamentos)
        {
            return GrupoDeComportamentos.CriarGrupoDeComportamenos(nomeDoGrupoDeComportamentos);
        }

        public Comportamento CriarComportamento(string descricaoDoComportamento, GrupoDeComportamentos grupoDeComportamentos)
        {
            return Comportamento.CriarComportamento(descricaoDoComportamento, grupoDeComportamentos);
        }

        public ProcessoDeAvaliacaoDeDesempenho CriarProcessoDeAvaliacaoDeDesempenho(string nome, Gestor gestor)
        {
            return ProcessoDeAvaliacaoDeDesempenho.CriarProcessoDeAvaliacaoDeDesempenho(nome, gestor);
        }
    }
}
