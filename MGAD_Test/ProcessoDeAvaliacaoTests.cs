using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MGAD_Model;

namespace MGAD_Test
{
    [TestClass]
    public class ProcessoDeAvaliacaoTests
    {
        [TestMethod]
        public void Dado_Um_Processo_De_Avaliacao_De_Desempenho_Ao_Ser_Criado_Deve_Associar_Tres_Avaliacoes()
        {
            //Arrange
            var administrador = new Administrador();
            var gestorJose = Gestor.CriarGestor("José");
            //Act
            var processoDeAvaliacaoDeDesempenho = administrador.CriarProcessoDeAvaliacaoDeDesempenho("Processo de Avaliacao 1", gestorJose);
            //Assert
            Assert.AreEqual(3, processoDeAvaliacaoDeDesempenho.QuantidadeDeAvaliacoes);
        }

        [TestMethod]
        public void Dado_Um_Processo_De_Avaliacao_De_Desempenho_Ao_Ser_Criado_Deve_Possuir_Uma_Auto_Avaliacao()
        {
            //Arrange
            var administrador = new Administrador();
            var gestorJose = Gestor.CriarGestor("José");
            //Act
            var processoDeAvaliacaoDeDesempenho = administrador.CriarProcessoDeAvaliacaoDeDesempenho("Processo de Avaliacao 1", gestorJose);
            //Assert
            Assert.AreEqual("Auto avaliação", processoDeAvaliacaoDeDesempenho.SelecionarAvaliacaoPorTipo("Auto avaliação").Tipo);
        }

        [TestMethod]
        public void Dado_Um_Processo_De_Avaliacao_De_Desempenho_Ao_Ser_Criado_Deve_Possuir_Uma_Avaliacao_Do_Gestor()
        {
            //Arrange
            var administrador = new Administrador();
            var gestorJose = Gestor.CriarGestor("José");
            //Act
            var processoDeAvaliacaoDeDesempenho = administrador.CriarProcessoDeAvaliacaoDeDesempenho("Processo de Avaliacao 1", gestorJose);
            //Assert
            Assert.AreEqual("Avaliação do gestor", processoDeAvaliacaoDeDesempenho.SelecionarAvaliacaoPorTipo("Avaliação do gestor").Tipo);
        }

        [TestMethod]
        public void Dado_Um_Processo_De_Avaliacao_De_Desempenho_Ao_Ser_Criado_Deve_Estar_Associado_A_Um_Gestor()
        {
            //Arrange
            var administrador = new Administrador();
            var gestorJose = Gestor.CriarGestor("José");
            //Act
            var processoDeAvaliacaoDeDesempenho = administrador.CriarProcessoDeAvaliacaoDeDesempenho("Processo de Avaliacao 1", gestorJose);            
            //Assert
            Assert.AreEqual(gestorJose, processoDeAvaliacaoDeDesempenho.Gestor);
        }
    }
}
