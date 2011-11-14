using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MGAD_Model;

namespace MGAD_Test
{
    [TestClass]
    public class ComportamentoTests
    {
        [TestMethod]
        public void Dado_Um_Comportamento_Ao_Ser_Criado_Deve_Associar_A_Algum_Grupo_De_Comportamentos()
        {
            //Arrange
            var administrador = new Administrador();
            var grupoComportamentalPessoal = administrador.CriarGrupoComportamentos("Comportamentos Pessoais");
            var grupoComportamentalProfissional = administrador.CriarGrupoComportamentos("Comportamentos Profissionais");
            //Act
            var comportamento = administrador.CriarComportamento("É pontual?", grupoComportamentalProfissional);
            //Assert
            Assert.AreEqual(grupoComportamentalProfissional, comportamento.Grupo);
        }
    }
}
