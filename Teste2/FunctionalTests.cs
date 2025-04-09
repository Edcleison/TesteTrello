using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Automacao
{
    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Setup()
        {
            // Instância dos objetos
            Global.capabilitiesMethods = new CapabilitiesMethods();
            Global.trello = new Trello();

            // Instância do driver
            Global.driver = Global.capabilitiesMethods.BrowserConfig();
            Global.trello.paginaInicial();
        }

        [TestMethod]
        public void LoginTrello()
        {
            #region tarefa 1
            //logar
            Global.trello.login();


            Global.trello.criarQuadro("teste");//criarQuadro

            //acessarQuadro
            //Global.trello.acessarQuadro("teste");
            Global.trello.criarLista("teste"); //criarLista
            Global.trello.criarCartao("teste", "teste"); //criarCartao        
            Global.trello.criarTag("teste", "teste", "//button[@data-testid='color-tile-green_light']"); //criarTag           
            Global.trello.removerTag("teste", "teste");//removerTag
            Global.trello.excluirCartao("teste", "teste");//excluirCartao
            Global.trello.excluirLista("teste");//excluirLista
            Global.trello.excluirQuadro();//excluirQuadro
            Global.trello.logout();//logout

            #endregion

            //Global.capabilitiesMethods.Wait(5000);            
        }

        [TestMethod]
        public void LoopTrello()
        {
            // exercicio de loop, criar 1 quadro e na sequencia, 3 listas com 3 cartões cada, sendo:


            // lista 1 => tag vermelha
            // lista 2 => tag azul
            // lista 3 => tag verde

            //logar
            Global.trello.login();

            //-----------------------------------------------------------

            //  loop criação

            Global.trello.loopCriacao();


            //--------------------------------------------------------------

            //loop de exclusão
            Global.trello.loopExclusao();

            //--------------------------------------------------------------

            Global.trello.logout();//logout


        }

        [TestMethod]
        public void LoopTrelloRandom()
        {

            //logar
            Global.trello.login();

            //-----------------------------------------------------------

            //  loop criação

            Global.trello.loopCriacaoRandom();


            //--------------------------------------------------------------

            //loop de exclusão
            Global.trello.loopExclusao();

            //--------------------------------------------------------------

            Global.trello.logout();//logout


        }

        [TestMethod]

        public void FecharQuadros()
        {

            //logar
            Global.trello.login();

            //-----------------------------------------------------------
            Global.trello.fecharQuadros("//div[contains(@class,'EAVRQ0SLBlQrwI')]");

            //--------------------------------------------------------------

            Global.trello.logout();//logout
        }



        [TestCleanup]
        public void TeardownTest()
        {
            // Finalização do browser
            try
            {
                Global.driver.Close();
                // Global.driver.Quit();
            }
            catch (Exception)
            {

            }
        }
    }
}