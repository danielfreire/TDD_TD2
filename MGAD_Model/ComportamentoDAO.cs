using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGAD_Persistence;

namespace MGAD_Model
{
    public class ComportamentoDAO
    {       

        public void Salvar(Comportamento comportamento)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();

            if (!new GrupoDeComportamentosDAO().Existe(comportamento.Grupo.Nome))
            {
                new GrupoDeComportamentosDAO().Salvar(comportamento.Grupo);
            }

            var comportamentoExistente = (from c in db.GetTable<comportamento>()
                                          where c.descricao == comportamento.Descricao
                                          select c).SingleOrDefault();
            if (comportamentoExistente == null)
            {
                InsereComportamento(comportamento, db);
            }
            else
            {
                AtualizarComportamento(comportamento, db, comportamentoExistente);
            }
        }

        private static void AtualizarComportamento(Comportamento comportamento, MGAD_BDDataContext db, MGAD_Persistence.comportamento comportamentoExistente)
        {
            comportamentoExistente.descricao = comportamento.Descricao;
            comportamentoExistente.grupo_de_comportamento = comportamento.Grupo.Nome;
            db.SubmitChanges();
        }

        private static void InsereComportamento(Comportamento comportamento, MGAD_BDDataContext db)
        {
            comportamento comportamentoBD = new MGAD_Persistence.comportamento();
            comportamentoBD.descricao = comportamento.Descricao;
            comportamentoBD.grupo_de_comportamento = comportamento.Grupo.Nome;
            db.comportamentos.InsertOnSubmit(comportamentoBD);
            db.SubmitChanges();
        }       
    }

}
