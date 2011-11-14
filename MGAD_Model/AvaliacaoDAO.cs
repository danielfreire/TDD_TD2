using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGAD_Persistence;

namespace MGAD_Model
{
    internal class AvaliacaoDAO
    {
        internal void Salvar(Avaliacao avaliacao)
        {
            if (!new ProcessoDeAvaliacaoDeDesempenhoDAO().Existe(avaliacao.processoDeAvaliacaoDeDesempenho.Nome))
            {
                new ProcessoDeAvaliacaoDeDesempenhoDAO().Salvar(avaliacao.processoDeAvaliacaoDeDesempenho);
            }

            var avaliacaoExistente = RecuperarAvaliacao(avaliacao);

            if (avaliacaoExistente == null)
            {
                MGAD_BDDataContext bd = new MGAD_BDDataContext();
                avaliacao avaliacaoNoBD = new avaliacao();
                avaliacaoNoBD.tipo = avaliacao.Tipo;
                avaliacaoNoBD.processo_de_avaliacao = avaliacao.processoDeAvaliacaoDeDesempenho.Nome;
                bd.avaliacaos.InsertOnSubmit(avaliacaoNoBD);
                bd.SubmitChanges();
            }
            else
            {
                MGAD_BDDataContext bd = new MGAD_BDDataContext();
                avaliacaoExistente.tipo = avaliacao.Tipo;
                avaliacaoExistente.processo_de_avaliacao = avaliacao.processoDeAvaliacaoDeDesempenho.Nome;
                bd.SubmitChanges();
            }
        }

        private static avaliacao RecuperarAvaliacao(Avaliacao avaliacao)
        {
            MGAD_BDDataContext bd = new MGAD_BDDataContext();

            var avaliacaoExistente = (from a in bd.GetTable<avaliacao>()
                                      where a.tipo == avaliacao.Tipo && a.processo_de_avaliacao == avaliacao.processoDeAvaliacaoDeDesempenho.Nome
                                      select a).SingleOrDefault();
            return avaliacaoExistente;
        }
    }
}
