﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V132.SystemInfo;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Automacao
{
    class Trello
    {
        public void paginaInicial()
        {
            Global.capabilitiesMethods.Navigate(Global.driver, "https://trello.com/");
        }
        public void login()
        {
            //Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            //aguarda o botão de aceitar todos os cookies
            //Global.capabilitiesMethods.WaitVisible(Global.driver, By.Id("onetrust-accept-btn-handler"));
            //clica no botão de login
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.Id("onetrust-accept-btn-handler"), 1000);
            //verifica se existe o menu hamburguer
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[@data-testid='menubutton']")))
            {
                //espera o menu haburguer
                //Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//button[@data-testid='menubutton']"));
                //clica no menu hamburguer
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='menubutton']"), 1000);

                //verifica se existe o botão login
                //Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//div[contains(@class,'SmallNavstyles__Buttons')]/a[contains(@href,'login')]"));
                //clica no botão login
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//div[contains(@class,'SmallNavstyles__Buttons')]/a[contains(@href,'login')]"), 1000);
            }

            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//div[contains(@class,'Buttonsstyles__ButtonGroup')]/a[contains(@data-uuid,'login')]")))
            {
                //espera o botão login
                //Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//div[contains(@class,'Buttonsstyles__ButtonGroup')]/a[contains(@data-uuid,'login')]"));
                //clica o botão login
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//div[contains(@class,'Buttonsstyles__ButtonGroup')]/a[contains(@data-uuid,'login')]"), 1000);
            }
            //aguarda o combo de login 
            //Global.capabilitiesMethods.WaitExists(Global.driver, By.Id("username"));//&& Global.capabilitiesMethods.Exists(Global.driver, By.Id("password"))
            //preenche o combo de login
            Global.capabilitiesMethods.SendKeys(Global.driver, By.Id("username"), "mail.qa@gmail.com");
            //clica no login
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.Id("login-submit"), 3000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            //aguarda o combo de senha
            Global.capabilitiesMethods.WaitExists(Global.driver, By.Id("password"));
            //preenche o combo de senha
            Global.capabilitiesMethods.TentarPreencherCampo(Global.driver, By.Id("password"), "@Trello123");
            //clica em acessar         
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.Id("login-submit"), 2000);


            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//div[contains(@data-testid,'otp-input-index')]")))
            {
                string codigo = Global.capabilitiesMethods.ObterCodigoVerificacaoGmail();
                int indiceDoisPontos = codigo.LastIndexOf("código:");

                codigo = codigo.Substring(indiceDoisPontos, 17);
                codigo = codigo.Replace("código:", "").TrimStart();
                int contador = 0;
                foreach (char key in codigo)
                {
                    Global.capabilitiesMethods.TentarPreencherCampo(Global.driver, By.XPath($@"//div[contains(@data-testid,'otp-input-index-{contador}-container')]/input"), key.ToString());
                    contador++;
                }
            }
            if (Global.capabilitiesMethods.Exists(Global.driver, By.Id("mfa-promote-dismiss")))
            {
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.Id("mfa-promote-dismiss"), 1000);
            }
        }





        public void criarQuadro(string novoQuadro)
        {
            //espera a barra de pesquisar aparecer
            //Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//button[@data-testid='header-create-menu-button']"));
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            //fecha as preferencias de cookies
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//span[@data-testid='experiment-one-button-icon']")))
            {
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//span[@data-testid='experiment-one-button-icon']"), 1000);
            }
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            // clica no link para criar quadro
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//button[@data-testid='create-board-tile']/div/span")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath($@"//button[@data-testid='create-board-tile']/div/span"));
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='create-board-tile']/div/span"), 1000);
            }
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//li[@data-testid='create-board-tile']/div/p/span")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath($@"//li[@data-testid='create-board-tile']/div/p/span"));
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//li[@data-testid='create-board-tile']/div/p/span"), 1000);
            }

            //Aguarda abrir o quadro
            //Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//input[contains(@class,'nch-textfield__input')]"));
            //nomeia o quadro
            Global.capabilitiesMethods.TentarPreencherCampo(Global.driver,
                By.XPath("//input[contains(@class,'nch-textfield__input')]"),
                novoQuadro);
            //cria o quadro
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[contains(@data-testid,'create-board-submit-button')]"),
                1000);
        }

        public void acessarQuadro(string nomeQuadro)
        {
            // clica no link para acessar o  quadro
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath($@"//div[contains(@title,'{nomeQuadro}')]"), 1000);
        }

        public void criarLista(string novaLista)
        {
            //Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//ol[@id='board']"));
            for (int i = 0; i < 3; i++)
            {
                if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//ol[@id='board']")))
                {
                    i = 3;
                }
            }
            //recolhe a aba Area de trabalho
            if (Global.capabilitiesMethods.IsDisplayed(Global.driver, By.XPath("//button[@data-testid='workspace-navigation-collapse-button']")))
            {
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='workspace-navigation-collapse-button']"), 1000);
            }

            //verifica se elemento para adicionar listas está presente
            //if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//button[contains(@data-testid,'list-composer')]")))
            //{
            //aguarda ocultar elemento
            if (Global.capabilitiesMethods.IsDisplayed(Global.driver, By.XPath("//div[@class='atlaskit-portal']")))
            {
                //Global.capabilitiesMethods.WaitHideElement(Global.driver, By.XPath("//div[@class='atlaskit-portal']"));
                //Global.capabilitiesMethods.Click(Global.driver, By.XPath("//span[@data-testid='StarIcon']"), 1000);
                Global.capabilitiesMethods.PressionarEsc(Global.driver);
            }
            //espera botão nova lista ser clicável
            //Global.capabilitiesMethods.WaitVisible(Global.driver, By.XPath("//div[@class='atlaskit-portal']"));

            if (!Global.capabilitiesMethods.IsDisplayed(Global.driver, By.XPath("//textarea[@data-testid='list-name-textarea']")))
            {
                //botão nova lista
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                    By.XPath("//button[contains(@data-testid,'list-composer')]"),
                    1000);
            }

            //nomeia a lista              
            Global.capabilitiesMethods.TentarPreencherCampo(Global.driver,
                By.XPath("//*[*[textarea[@data-testid='list-name-textarea']]//button[contains(@data-testid,'list-composer-add')]]//textarea"),
                novaLista);

            // salva a lista
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[@data-testid='list-composer-add-list-button']"),
                1000);

            //cancela a nova lista
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//span[@data-testid='CloseIcon']"),
                1000);
        }
        // }
        //if (!Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//button[contains(@data-testid,'list-composer')]")))
        //{
        //    //implementar um for para capturar o nome das listas default: A fazer, Em andamento e Concluído
        //    //renomear a primeira lista para teste e apagar as outras duas
        //}


        public void criarCartao(string nomeLista, string novoCartao)
        {

            //novo cartão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath($@"//div[div[div/h2[contains(text(),'{nomeLista}')]]]/div[@data-testid='list-footer']/button"),
                1000);
            // nomeia o cartão
            Global.capabilitiesMethods.TentarPreencherCampo(Global.driver,
                By.XPath("//textarea[contains(@data-testid,'list-card-composer-textarea')]"),
                novoCartao);


            // salva
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[contains(@data-testid,'list-card-composer-add-card-button')]"),
                1000);

        }

        public void criarTag(string nomeLista, string nomeCartao, string xPathCor = "")
        {

            //abre o cartão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath($@"//*[div[div/h2[contains(text(),'{nomeLista}')]]]//a[@data-testid='card-name' and text()='{nomeCartao}']"),
                1000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);

            // seleciona o menu tag
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[@data-testid='card-back-labels-button']"),
                1000);
            //botão nova etiqueta
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[text()='Criar uma nova etiqueta']"),
                3000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(xPathCor)))
            {
                //rola até a cor        
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(xPathCor));
            }
            //escolhe a cor        
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath(xPathCor),
                1000);
            //rola até o botão criar
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//section[contains(@data-testid,'labels-popover-create-label-screen')]/div/div[4]/button")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//section[contains(@data-testid,'labels-popover-create-label-screen')]/div/div[4]/button"));
            }
            //botão criar            
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//section[contains(@data-testid,'labels-popover-create-label-screen')]/div/div[4]/button"),
                1000);
            //rola até o botão fechar etiqueta
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[contains(@data-testid,'popover-close')]")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//button[contains(@data-testid,'popover-close')]"));
            }
            //fecha  a edição da etiqueta
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[contains(@data-testid,'popover-close')]"),
                1000);
            //rola até o botão fechar cartão
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[contains(@aria-label,'Fechar caixa de diálogo')]//span[contains(@data-testid,'CloseIcon')]")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//button[contains(@aria-label,'Fechar caixa de diálogo')]//span[contains(@data-testid,'CloseIcon')]"));
            }
            // fecha a edição do cartão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[contains(@aria-label,'Fechar caixa de diálogo')]//span[contains(@data-testid,'CloseIcon')]"),
                1000);

        }
        public void removerTag(string nomeLista, string nomeCartao)
        {
            //abre o cartão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath($@"//*[div[div/h2[contains(text(),'{nomeLista}')]]]//a[@data-testid='card-name' and text()='{nomeCartao}']"),
                1000);
            // seleciona o menu tag
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[@data-testid='card-back-labels-button']"),
                1000);
            //rola até a tag selecionada
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath($@"//*[input[@aria-checked='true']]/span/span")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath($@"//*[input[@aria-checked='true']]/span/span"));
            }
            //desmarca tag
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath($@"//*[input[@aria-checked='true']]/span/span"), 1000);
            //fecha  a edição da etiqueta
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[contains(@data-testid,'popover-close')]"),
                1000);
            // fecha a edição do cartão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[contains(@aria-label,'Fechar caixa de diálogo')]//span[contains(@data-testid,'CloseIcon')]"),
                1000);

        }


        public void excluirCartao(string nomeLista, string nomeCartao)
        {
            //abre o cartão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath($@"//*[div[div/h2[contains(text(),'{nomeLista}')]]]//a[@data-testid='card-name' and text()='{nomeCartao}']"), 1000);
            
            //rola até o menu arquivar
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[@data-testid='card-back-archive-button']")))
            {
                Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//button[@data-testid='card-back-archive-button']"));
            }
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='card-back-archive-button']"), 1000);


            //excluir
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='card-back-delete-card-button']"), 1000);
            //confirma exclusão 
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='popover-confirm-button']"), 1000);
        }
        public void excluirLista(string nomeLista)
        {
            //abre o cartão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath($@"//div[div/h2[contains(text(),'{nomeLista}')]]//button[@data-testid='list-edit-menu-button']"), 1000);
            //seleciona o menu arquivar
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[@data-testid='list-actions-archive-list-button']")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//button[@data-testid='list-actions-archive-list-button']"));
            }
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='list-actions-archive-list-button']"), 1000);


            //abre o menu
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@aria-label='Mostrar Menu']"), 1000);
            //abre os itens arquivados
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button/span[contains(@aria-label,'Itens arquivados')]")))
            {
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button/span[contains(@aria-label,'Itens arquivados')]"), 1000);
            }
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[span[span[@data-testid='ArchiveIcon']]]")))
            {
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[span[span[@data-testid='ArchiveIcon']]]"), 1000);
            }
            //clica no botão alternar para listas
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//div[@data-testid='board-menu-container']//button[normalize-space(text())='Alternar para listas']"), 1000);
            // clica no botão para excluir lista
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath($@"//*[span[contains(text(), '{nomeLista}')]]//button//span[contains(@data-testid,'TrashIcon')]"), 1000);
            //confirma a exclusão
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[contains(text(),'Excluir')]"), 1000);
            //fechar
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[span/span[@data-testid='CloseIcon']]"), 1000);


        }

        public void excluirQuadro()
        {
            //Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//*[button[@data-testid='board-share-button']]/button[@aria-label='Mostrar Menu']")))
            {
                //abre o menu
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//*[button[@data-testid='board-share-button']]/button[@aria-label='Mostrar Menu']"), 1000);
            }

            //seleciona fechar o quadro 
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//button[div[normalize-space(text())='Fechar quadro']]")))
            {
                if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[div[normalize-space(text())='Fechar quadro']]")))
                {

                    Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//button[div[normalize-space(text())='Fechar quadro']]"));
                }
                Global.capabilitiesMethods.Wait(2000);
                //fechar quadro
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[div[normalize-space(text())='Fechar quadro']]"), 2000);
            }
            //seleciona fechar o quadro dentro do elemento li
            else if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//*[*[span[@data-testid='RemoveIcon']]]")))
            {
                if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//*[*[span[@data-testid='RemoveIcon']]]")))
                {

                    Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//*[*[span[@data-testid='RemoveIcon']]]"));
                }
                Global.capabilitiesMethods.Wait(2000);
                //fechar quadro
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//*[*[span[@data-testid='RemoveIcon']]]"), 2000);
            }
            Global.capabilitiesMethods.Wait(2000);
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[@data-testid='popover-close-board-confirm']")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//button[@data-testid='popover-close-board-confirm']"));
            }
            //1ª confirmação
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[@data-testid='popover-close-board-confirm']"), 2000);
            //abre o menu

            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//*[button[@data-testid='board-share-button']]/button[@aria-label='Mostrar Menu']")))
            {
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//*[button[@data-testid='board-share-button']]/button[@aria-label='Mostrar Menu']"), 2000);
            }
            //2ª confirmação
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[contains(@data-testid,'close-board-delete')]"), 2000);
            //excluir
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[contains(@data-testid,'close-board-delete') and normalize-space(text())='Excluir']"), 2000);

        }

        public void logout()
        {
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//section[@data-testid='header-member-menu-popover']")))//button[*[span[text()='Fazer Logout']]]
            {
                //abre o menu
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                    By.XPath("//button[contains(@class,'open-header-member-menu')]"),
                    3000);
            }
            Global.capabilitiesMethods.Wait(2000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            //sair 1
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//button[*[span[text()='Fazer Logout']]]")))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath("//button[*[span[text()='Fazer Logout']]]"));
            }

            Global.capabilitiesMethods.TentarClicarElemento(Global.driver,
                By.XPath("//button[*[span[text()='Fazer Logout']]]"),
                1000);
            //sair 2 
            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//button[contains(@data-testid,'logout-button')]"), 2000);
        }

        public void loopCriacao()
        {

            Global.trello.criarQuadro("testeLoop");//criarQuadro

            List<string> cores = new List<string> { "color-tile-red", "color-tile-blue_light", "color-tile-green_light" };

            int contCartao = 1;

            for (int i = 1; i < 4; i++)
            {
                Global.trello.criarLista("Lista " + i.ToString()); //criarLista

                //cartões com cores iguais por lista
                /* while (contCartao < 4)
                 {
                     Global.trello.criarCartao("Lista " + i.ToString(), "Cartão " + contCartao.ToString()); //criarCartao                                                        
                    string cor;

                     switch (i)
                     {
                         case (1):
                             cor = "color-tile-red";
                             Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//button[@data-testid='{cor}']"); //criarTag 
                             break;
                         case (2):
                             cor = "color-tile-blue_light";
                             Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//button[@data-testid='{cor}']"); //criarTag 
                             break;
                         case (3):
                             cor = "color-tile-green_light";
                             Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//button[@data-testid='{cor}']"); //criarTag 
                             break;
                     }*/
                //cartões com cores diferentes por lista
                foreach (string cor in cores)
                {
                    Global.trello.criarCartao("Lista " + i.ToString(), "Cartão " + contCartao.ToString()); //criarCartao  
                    Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//button[@data-testid='{cor}']");
                    contCartao++;
                }
                contCartao = 1;
            }
            // contCartao = 1;

        }

        //}

        //public void loopExclusao()
        //{
        //    //Global.trello.acessarQuadro("testeLoop");


        //    for (int i = 1; i < 4; i++)
        //    {

        //        for (int j = 1; j < 4; j++)
        //        {
        //            string cor = "";
        //            switch (i)
        //            {
        //                case (1):
        //                    cor = "red";
        //                    break;
        //                case (2):
        //                    cor = "blue";
        //                    break;
        //                case (3):
        //                    cor = "green";
        //                    break;
        //            }
        //            Global.trello.removerTag("Lista " + i.ToString(), "Cartão " + j.ToString(), cor); //excluirTag 
        //        }
        //        for (int k = 1; k < 4; k++)
        //        {
        //            Global.trello.excluirCartao("Lista " + i.ToString(), "Cartão " + k.ToString()); //excluirCartao
        //        }
        //        Global.trello.excluirLista("Lista " + i.ToString()); //excluirLista
        //    }
        //    Global.trello.excluirQuadro();//excluirQuadro

        //}

        public void loopCriacaoRandom()
        {

            Global.trello.criarQuadro("testeTrelloRandom");//criarQuadro

            int contCartao = 1;

            for (int i = 1; i < 4; i++)
            {
                Global.trello.criarLista("Lista " + i.ToString()); //criarLista
                while (contCartao < 4)
                {
                    string cor;
                    Global.trello.criarCartao("Lista " + i.ToString(), "Cartão " + contCartao.ToString()); //criarCartao
                                                                                                           //gera cor rândomicamente e passa para a variável cor
                    cor = geraCorTagRandom();
                    Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//button[@data-testid='{cor}']"); //criarTag 
                    contCartao++;
                }
                contCartao = 1;
            }
            ///Assert.IsTrue(Global.capabilitiesMethods.Exists(), "Logo não encontrado");
        }

        public void loopExclusao()
        {
            //Global.trello.acessarQuadro("testeLoopRandom");


            for (int i = 3; i > 0; i--)
            {

                for (int j = 3; j > 0; j--)
                {
                    Global.trello.removerTag("Lista " + i.ToString(), "Cartão " + j.ToString()); //excluirTag 
                }
                for (int k = 3; k > 0; k--)
                {
                    Global.trello.excluirCartao("Lista " + i.ToString(), "Cartão " + k.ToString()); //excluirCartao
                }
                Global.trello.excluirLista("Lista " + i.ToString()); //excluirLista
            }
            Global.trello.excluirQuadro();//excluirQuadro

        }


        public string geraCorTagRandom()
        {
            List<string> listaCor = new List<string>() { "color-tile-green_light", "color-tile-yellow_dark", "color-tile-orange", "color-tile-red", "color-tile-purple", "color-tile-purple", "color-tile-lime_dark", "color-tile-pink_dark", "color-tile-black_light", "color-tile-sky" };
            Random rand = new Random(DateTime.Now.Millisecond);
            string cor = listaCor[rand.Next(listaCor.Count)];
            return cor;
        }

        public void fecharQuadros(string xPath)
        {
            //Global.capabilitiesMethods.WaitVisible(Global.driver, By.XPath("//span[@data-testid='BoardIcon']"));

            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//span[@data-testid='BoardIcon']"), 2000);

            //fecha as preferencias de cookies
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath("//span[@data-testid='experiment-one-button-icon']")))
            {
                Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath("//span[@data-testid='experiment-one-button-icon']"), 2000);
            }

            int quantidade = Global.capabilitiesMethods.CountElements(Global.driver, By.XPath(xPath));
            quantidade = quantidade - 1;
            for (int i = quantidade; i >= 1; i--)
            {
                Global.capabilitiesMethods.Wait(2000);
                if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath($@"{xPath}[{i}]")))
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath($@"{xPath}[{i}]"));

                        if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath($@"{xPath}[{i}]")))
                        {
                            Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath($@"{xPath}[{i}]"), 2000);
                            j = 3;

                        }
                    }
                }
                else
                {
                    Global.capabilitiesMethods.TentarClicarElemento(Global.driver, By.XPath($@"{xPath}[{i}]"), 2000);
                }

                Global.trello.excluirQuadro();//excluirQuadro
            }

        }
    }

}
