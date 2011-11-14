using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGAD_Persistence;

namespace MGAD_Model
{
    internal class ProcessoDeAvaliacaoDeDesempenhoDAO
    {

        internal void Salvar(ProcessoDeAvaliacaoDeDesempenho processoDeAvaliacaoDeDesempenho)
        {
            var processoDeAvaliacaoDeDesempenhoExiste = RecuperarProcessoDeAvaliacaoDeDesempenho(processoDeAvaliacaoDeDesempenho.Nome);

            if (processoDeAvaliacaoDeDesempenhoExiste == null)
            {
                Inserir(processoDeAvaliacaoDeDesempenho);
            }
            else
            {
                Atualizar(processoDeAvaliacaoDeDesempenho, processoDeAvaliacaoDeDesempenhoExiste);

            }
        }

        private static void Atualizar(ProcessoDeAvaliacaoDeDesempenho processoDeAvaliacaoDeDesempenho, processo_de_avaliacao processoDeAvaliacaoDeDesempenhoExiste)
        {
            MGAD_BDDataContext bd = new MGAD_BDDataContext();
            processoDeAvaliacaoDeDesempenhoExiste.gestor = processoDeAvaliacaoDeDesempenho.Gestor.Nome;
            processoDeAvaliacaoDeDesempenhoExiste.nome = processoDeAvaliacaoDeDesempenho.Nome;
            bd.SubmitChanges();
        }

        private static void Inserir(ProcessoDeAvaliacaoDeDesempenho processoDeAvaliacaoDeDesempenho)
        {
            MGAD_BDDataContext bd = new MGAD_BDDataContext();
            processo_de_avaliacao processoDeAvaliacaoDeDesempenhoNoBD = new processo_de_avaliacao();
            processoDeAvaliacaoDeDesempenhoNoBD.nome = processoDeAvaliacaoDeDesempenho.Nome;
            processoDeAvaliacaoDeDesempenhoNoBD.gestor = processoDeAvaliacaoDeDesempenho.Gestor.Nome;
            bd.processo_de_avaliacaos.InsertOnSubmit(processoDeAvaliacaoDeDesempenhoNoBD);
            bd.SubmitChanges();
        }

        internal bool Existe(string nome)
        {
            var processoDeAvaliacaoDeDesempenhoExiste = RecuperarProcessoDeAvaliacaoDeDesempenho(nome);            
            return processoDeAvaliacaoDeDesempenhoExiste != null;
        }

        private static processo_de_avaliacao RecuperarProcessoDeAvaliacaoDeDesempenho(string nome)
        {
            MGAD_BDDataContext bd = new MGAD_BDDataContext();

            var processoDeAvaliacaoDeDesempenhoExiste = (from p in bd.GetTable<processo_de_avaliacao>()
                                                         where p.nome == nome
                                                         select p).SingleOrDefault();
            return processoDeAvaliacaoDeDesempenhoExiste;
        }
    }
}
