using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGAD_Model
{
    public class Gestor
    {
        public string Nome { get; private set; }
        public int QuantidadeColaboradoresSubordinados 
        {
            get
            {
                return new ColaboradorDAO().SelecionarTodosColaboradoresDeUmGestor(this).Count;
            }
            set { }
        }

        internal Gestor(string nome)
        {
            this.Nome = nome;
        }

        public static Gestor CriarGestor(string nome)
        {
            Gestor gestor = new Gestor(nome);
            new GestorDAO().Salvar(gestor);
            return gestor;
        }

        public List<Colaborador> RecuperarColaboradoresSubordinados()
        {
            return new ColaboradorDAO().SelecionarTodosColaboradoresDeUmGestor(this);
        }
    }
}
