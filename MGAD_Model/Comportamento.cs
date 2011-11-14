using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGAD_Model
{
    public class Comportamento
    {
        public string Descricao { get; private set; }
        public GrupoDeComportamentos Grupo { get; set; }

        private Comportamento(string descricaoDoComportamento, GrupoDeComportamentos grupo)
        {            
            this.Descricao = descricaoDoComportamento;
            this.Grupo = grupo;
        }

        public static Comportamento CriarComportamento(string descricaoDoComportamento, GrupoDeComportamentos grupo)
        {
            Comportamento comportamento = new Comportamento(descricaoDoComportamento, grupo);
            new ComportamentoDAO().Salvar(comportamento);
            return comportamento;
        }
    }
}
