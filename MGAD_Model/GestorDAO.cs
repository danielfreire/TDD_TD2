using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGAD_Persistence;

namespace MGAD_Model
{
    internal class GestorDAO
    {
        internal void Salvar(Gestor novoGestor)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();

            var gestorExistente = (from g in db.GetTable<gestor>()
                                   where g.nome == novoGestor.Nome
                                   select g).SingleOrDefault();

            if (gestorExistente == null)
            {
                Inserir(novoGestor, db);
            }
            else
            {
                Atualizar(novoGestor, db, gestorExistente);
            }
        }

        internal bool ExisteGestor(string nome)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();

            var gestorExistente = (from g in db.GetTable<gestor>()
                                   where g.nome == nome
                                   select g).SingleOrDefault();

            return gestorExistente != null;
        }

        private static void Atualizar(Gestor novoGestor, MGAD_BDDataContext db, gestor gestorExistente)
        {
            gestorExistente.nome = novoGestor.Nome;
            db.SubmitChanges();
        }

        private static void Inserir(Gestor novoGestor, MGAD_BDDataContext db)
        {
            gestor gestorBD = new gestor();
            gestorBD.nome = novoGestor.Nome;
            db.gestors.InsertOnSubmit(gestorBD);
            db.SubmitChanges();
        }        
    }
}
