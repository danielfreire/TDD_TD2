using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGAD_Model
{
    public class Colaborador
    {
        public string Nome { get; private set; }
        public Gestor GestorAssociado { get; private set; }

        public Colaborador(string nome, Gestor gestor)
        {

            this.Nome = nome;
            this.GestorAssociado = gestor;
        }

        public static Colaborador CriarColaborador(string nome, Gestor gestor)
        {
            Colaborador colaborador = new Colaborador(nome, gestor);
            new ColaboradorDAO().Salvar(colaborador);
            return colaborador;
        }
    }
}
