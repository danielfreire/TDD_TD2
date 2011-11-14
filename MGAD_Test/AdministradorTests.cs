using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MGAD_Model;

namespace MGAD_Test
{
    [TestClass]
    public class AdministradorTests
    {
        [TestMethod]
        public void Dado_Um_Administrador_Ao_Cadastrar_Um_Colaborador_Deve_Associar_A_Um_Gestor()        
        {
            //Arrange
            var administrador = new Administrador();
            var gestor = Gestor.CriarGestor("André");            
            //Act
            var colaborador = Colaborador.CriarColaborador("Antonio", gestor);
            //Assert
            Assert.AreEqual(gestor.Nome, colaborador.GestorAssociado.Nome);
        }
    }
}
