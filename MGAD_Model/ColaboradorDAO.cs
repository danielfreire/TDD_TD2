using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGAD_Persistence;

namespace MGAD_Model
{
    internal class ColaboradorDAO
    {
        internal void Salvar(Colaborador colaborador)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();

            if (!new GestorDAO().ExisteGestor(colaborador.GestorAssociado.Nome))
            {
                new GestorDAO().Salvar(colaborador.GestorAssociado);
            }

            var colaboradorExistente = (from c in db.GetTable<colaborador>()
                                        where c.nome == colaborador.Nome
                                        select c).SingleOrDefault();
            

            if (colaboradorExistente == null)
            {
                Salvar(colaborador, db);
            }
            else
            {
                Atualizar(colaborador, db, colaboradorExistente);
            }            
        }

        internal List<Colaborador> SelecionarTodosColaboradoresDeUmGestor(Gestor gestor)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();
            var listaColaboradoresQuery = (from c in db.GetTable<colaborador>()
                                           where c.gestor == gestor.Nome
                                           select c);

            List<Colaborador> colaboradoresComGestor = new List<Colaborador>();

            foreach(colaborador colaboradorBD in listaColaboradoresQuery)
            {
                colaboradoresComGestor.Add(new Colaborador(colaboradorBD.nome, new Gestor(colaboradorBD.gestor)));
            }

            return colaboradoresComGestor;            
        }


        private static void Atualizar(Colaborador colaborador, MGAD_BDDataContext db, MGAD_Persistence.colaborador colaboradorExistente)
        {
            colaboradorExistente.nome = colaborador.Nome;
            colaboradorExistente.gestor = colaborador.GestorAssociado.Nome;
            db.SubmitChanges();
        }

        private static void Salvar(Colaborador colaborador, MGAD_BDDataContext db)
        {
            colaborador colaboradorBD = new colaborador();
            colaboradorBD.nome = colaborador.Nome;
            colaboradorBD.gestor = colaborador.GestorAssociado.Nome;
            db.colaboradors.InsertOnSubmit(colaboradorBD);
            db.SubmitChanges();
        }
    }
}
