using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MGAD_Model;

namespace MGAD_Test
{
    [TestClass]
    public class GestorTests
    {
        [TestMethod]
        public void Dado_Um_Gestor_Ao_Ser_Solicitado_Deve_Exibir_Todos_Seus_Colaboradores_Subordinados()
        {
            //Arrange
            var gestor = Gestor.CriarGestor("José");
            var colaboradorIgnacio = Colaborador.CriarColaborador("Ignácio", gestor);
            var colaboradorJudas = Colaborador.CriarColaborador("Judas", gestor);
            //Act
            int quantidadeDeColaboradores = gestor.QuantidadeColaboradoresSubordinados;
            List<Colaborador> colaboradoresSubordinados = gestor.RecuperarColaboradoresSubordinados();
            //Assert
            Assert.AreEqual(2, quantidadeDeColaboradores);
            Assert.AreEqual("Ignácio", colaboradoresSubordinados.Find(c => c.Nome == "Ignácio").Nome);
            Assert.AreEqual("Judas", colaboradoresSubordinados.Find(c => c.Nome == "Judas").Nome);

        }
    }
}
