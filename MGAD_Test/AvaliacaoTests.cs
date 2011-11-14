using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MGAD_Model;

namespace MGAD_Test
{
    [TestClass]
    public class AvaliacaoTests
    {
        [TestMethod]
        public void Dado_Uma_Avaliacao_Ao_Ser_Criada_Deve_Associar_A_Todos_Grupos_De_Comportamentos_Existentes()        
        {
            //Arrange       
            var administrador = new Administrador();
            var gestorJose = Gestor.CriarGestor("José");
            var grupoComportamentalPessoal = administrador.CriarGrupoComportamentos("Comportamentos Pessoais");
            var grupoComportamentalProfissional = administrador.CriarGrupoComportamentos("Comportamentos Profissionais");
            var grupoComportamentalSocial = administrador.CriarGrupoComportamentos("Comportamentos Sociais");
            var processoDeAvaliacaoDeDesempenho = administrador.CriarProcessoDeAvaliacaoDeDesempenho("Processo de Avaliacao 1", gestorJose);
            //Act
            var avaliacao = Avaliacao.CriarAvaliacao("Auto avaliação", processoDeAvaliacaoDeDesempenho);
            //Assert
            Assert.AreEqual(3, avaliacao.QuantidadeDeGruposComportamentais);
            Assert.AreEqual("Comportamentos Pessoais", avaliacao.RecuperarGrupoDeComportamentos("Comportamentos Pessoais").Nome);
            Assert.AreEqual("Comportamentos Profissionais", avaliacao.RecuperarGrupoDeComportamentos("Comportamentos Profissionais").Nome);
            Assert.AreEqual("Comportamentos Sociais", avaliacao.RecuperarGrupoDeComportamentos("Comportamentos Sociais").Nome);
        }

        
        [TestMethod]
        public void Dada_Uma_Avaliacao_Ao_Ser_Criada_Deve_Possuir_Status_Em_Aberto()
        {
            //Arrange
            var administrador = new Administrador();
            var gestorJose = Gestor.CriarGestor("José");
            var processoDeAvaliacaoDeDesempenho = administrador.CriarProcessoDeAvaliacaoDeDesempenho("Processo de Avaliacao 1", gestorJose);
            //Act
            var avaliacao = Avaliacao.CriarAvaliacao("Auto avaliação", processoDeAvaliacaoDeDesempenho);
            //Assert
            Assert.AreEqual("EmAberto", avaliacao.Status);
        }
         
    }
}
