using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MGAD_Persistence;

namespace MGAD_Model
{
    internal class GrupoDeComportamentosDAO
    {
        public void Salvar(GrupoDeComportamentos grupoDeComportamentos)
        {
            var grupoExistente = RecuperarGrupoDeComportamento(grupoDeComportamentos.Nome);

            if (grupoExistente == null)
            {
                InserirGruposDeComportamentos(grupoDeComportamentos);
            }
            else
            {
                AtualizarGruposDeComportamentos(grupoDeComportamentos, grupoExistente);
            }
        }

        public bool Existe(string nome)
        {
            var grupoExiste = RecuperarGrupoDeComportamento(nome);
            
            return grupoExiste != null;
        }

        private static grupo_de_comportamento RecuperarGrupoDeComportamento(string nome)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();
            var grupoExiste = (from g in db.GetTable<grupo_de_comportamento>()
                               where g.nome == nome
                               select g).SingleOrDefault();

            return grupoExiste;
        }

        private void AtualizarGruposDeComportamentos(GrupoDeComportamentos grupoDeComportamentos, grupo_de_comportamento grupoExistente)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();
            grupoExistente.nome = grupoDeComportamentos.Nome;
            db.SubmitChanges();
        }

        private void InserirGruposDeComportamentos(GrupoDeComportamentos grupoDeComportamentos)
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();
            grupo_de_comportamento grupoDeComportamentoBD = new grupo_de_comportamento();
            grupoDeComportamentoBD.nome = grupoDeComportamentos.Nome;
            db.grupo_de_comportamentos.InsertOnSubmit(grupoDeComportamentoBD);
            db.SubmitChanges();
        }

        internal static List<GrupoDeComportamentos> SelecionarTodosGruposDeComportamentos()
        {
            MGAD_BDDataContext db = new MGAD_BDDataContext();
            List<GrupoDeComportamentos> gruposDeComportamentos = new List<GrupoDeComportamentos>();

            foreach (grupo_de_comportamento grupoComportamentos in db.GetTable<grupo_de_comportamento>())
            {
                gruposDeComportamentos.Add(new GrupoDeComportamentos(grupoComportamentos.nome));
            }

            return gruposDeComportamentos;
        }
    }
}
