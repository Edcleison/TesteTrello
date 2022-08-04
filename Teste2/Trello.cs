using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            //verifica se existe o botão de login
            Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//div[contains(@class,'Buttonsstyles')]/a[@href='/login']"));
            //clica no botão de login
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//div[contains(@class,'Buttonsstyles')]/a[@href='/login']"), 1000);
            //verifica se existe os combos de login e senha
            if (Global.capabilitiesMethods.Exists(Global.driver, By.Id("user")) && Global.capabilitiesMethods.Exists(Global.driver, By.Id("password")))
            {
                //preenche o combo de login
                Global.capabilitiesMethods.SendKeys(Global.driver, By.Id("user"), "mail@mail.com");
                //clica no login
                Global.capabilitiesMethods.Click(Global.driver, By.Id("login"), 1000);
                //preenche o combo de senha
                Global.capabilitiesMethods.SendKeys(Global.driver, By.Id("password"), "********");
                //clica em acessar
                Global.capabilitiesMethods.Click(Global.driver, By.Id("login-submit"), 1000);
            }

        }

        public void criarQuadro(string novoQuadro)
        {
            // clica no link para criar quadro
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//div[contains(@class,'board-tile mod-add')]/p/span"), 1000);
            //nomeia o quadro
            Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath("//input[contains(@class,'nch-textfield__input')]"), novoQuadro);
            //cria o quadro
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//button[contains(@data-test-id,'create-board-submit-button')]"), 1000);

        }

        public void acessarQuadro(string nomeQuadro)
        {
            // clica no link para acessar o  quadro
            Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//div[contains(@title,'{nomeQuadro}')]"), 1000);
        }

        public void criarLista(string novaLista)
        {
            Global.capabilitiesMethods.WaitExists(Global.driver, By.XPath("//div[@id='board']"));

            //verifica se o elemento para adicionar lista está presente
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//div[contains(@class,'js-add-list list-wrapper mod-add is-idle')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath("//div[contains(@class,'js-add-list list-wrapper mod-add is-idle')]/form/a"), 1000);
            }
            //nomeia a lista
            Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath("//input[contains(@class,'list-name-input')]"), novaLista);
            // salva a lista
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//div[contains(@class,'list-add-controls u-clearfix')]/input"), 1000);
            //cancela a nova lista
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'icon-lg icon-close dark-hover js-cancel-edit')]"), 1000);
        }

        public void criarCartao(string nomeLista, string novoCartao)
        {

            //novo cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//div[div/h2[contains(text(),'{nomeLista}')]]/div/a[contains(@class,'open-card-composer js-open-card-composer')]"), 1000);
            //nomeia o cartão
            Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath("//textarea[contains(@class,'list-card-composer-textarea js-card-title')]"), novoCartao);
            //salva
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//input[contains(@class,'nch-button nch-button--primary confirm mod-compact js-add-card')]"), 1000);
        }

        public void criarTag(string nomeLista, string nomeCartao, string xPathCor = "")
        {

            //abre o cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//div[div/h2[contains(text(),'{nomeLista}')]]/div[contains(@class,'list-cards u-fancy-scrollbar u-clearfix js-list-cards js-sortable ui-sortable')]/a/div/span[contains(text(),'{nomeCartao}')]"), 1000);
            // seleciona o menu etiquetas
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'button-link js-edit-labels') and @title='Etiquetas']"), 1000);
            //botão nova etiqueta
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//button[contains(@class,'button full js-add-label') and text()='Criar uma nova etiqueta']"), 1000);
            //escolhe a cor        
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(xPathCor), 1000);
            //botão criar            
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//input[contains(@class,'nch-button nch-button--primary wide js-submit')]"), 1000);
            //fecha  a edição da etiqueta
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'pop-over-header-close-btn icon-sm icon-close')]"), 1000);
            // fecha a edição do cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'icon-md icon-close dialog-close-button js-close-window')]"), 1000);

        }
        public void removerTag(string nomeLista, string nomeCartao)
        {
            //abre o cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//div[div/h2[contains(text(),'{nomeLista}')]]/div[contains(@class,'list-cards u-fancy-scrollbar u-clearfix js-list-cards js-sortable ui-sortable')]/a/div/span[contains(text(),'{nomeCartao}')]"), 1000);
            // seleciona o menu tag
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'button-link js-edit-labels') and @title='Etiquetas']"), 1000);
            //desmarca tag
            desmarcaTag(nomeLista, nomeCartao);
            //fecha  a edição da etiqueta
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'pop-over-header-close-btn icon-sm icon-close')]"), 1000);
            // fecha a edição do cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'icon-md icon-close dialog-close-button js-close-window')]"),1000);

        }

        public void excluirCartao(string nomeLista, string nomeCartao)
        {
            //abre o cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//div[div/h2[contains(text(),'{nomeLista}')]]/div[contains(@class,'list-cards u-fancy-scrollbar u-clearfix js-list-cards js-sortable ui-sortable')]/a/div/span[contains(text(),'{nomeCartao}')]"), 1000);
            //seleciona o menu arquivar
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'button-link js-archive-card') and @title='Arquivar']"), 1000);
            //botão excluir
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'button-link js-delete-card negate') and @title='Excluir']"), 1000);
            //confirma a exclusão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//input[contains(@class,'js-confirm full nch-button nch-button--danger') and @value='Excluir']"), 1000);
        }
        public void excluirLista(string nomeLista)
        {
            //abre a lista
            Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//div[div/h2[contains(text(),'{nomeLista}')]]/div/div/a"), 1000);
            //seleciona a opção 'arquivar esta lista'
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'js-close-list')and text()='Arquivar Esta Lista']"), 1000);
        }

        public void excluirQuadro()
        {
            //abre o menu
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'board-header-btn mod-show-menu js-show-sidebar')]"), 1000);
            //mostra mais opções do menu
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'board-menu-navigation-item-link js-open-more')]"), 1000);
            //fechar quadro
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//a[contains(@class,'board-menu-navigation-item-link js-close-board')]"), 1000);
            //1ª confirmação
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//input[contains(@class,'js-confirm full nch-button nch-button--danger')]"), 1000);
            //2ª confirmação
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//button[text()='Excluir o quadro permanentemente']"), 1000);
            //excluir
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//button[text()='Excluir']"), 1000);

        }

        public void logout()
        {
            //abre o menu
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//button[contains(@data-test-id,'header-member-menu-button')]"), 1000);
            //sair 1
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//button[contains(@data-test-id,'header-member-menu-logout')]"), 1000);
            //sair 2 
            Global.capabilitiesMethods.Click(Global.driver, By.XPath("//button[contains(@data-testid,'logout-button')]"), 1000);
        }

        public void loopCriacao()
        {

            Global.trello.criarQuadro("testeLoop");//criarQuadro

            int contCartao = 1;

            for (int i = 1; i < 4; i++)
            {
                Global.trello.criarLista("Lista " + i.ToString()); //criarLista
                while (contCartao < 4)
                {
                    Global.trello.criarCartao("Lista " + i.ToString(), "Cartão " + contCartao.ToString()); //criarCartao                                                        
                    string cor;

                    switch (i)
                    {
                        case (1):
                            cor = "red";
                            Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//span[contains(@class,'card-label mod-edit-label mod-clickable card-label-{cor} palette-color js-palette-color')]"); //criarTag 
                            break;
                        case (2):
                            cor = "blue";
                            Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//span[contains(@class,'card-label mod-edit-label mod-clickable card-label-{cor} palette-color js-palette-color')]"); //criarTag 
                            break;
                        case (3):
                            cor = "green";
                            Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//span[contains(@class,'card-label mod-edit-label mod-clickable card-label-{cor} palette-color js-palette-color')]"); //criarTag 
                            break;
                    }
                    contCartao++;
                }
                contCartao = 1;

            }

        }

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

            Global.trello.criarQuadro("testeLoopRandom");//criarQuadro

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
                    Global.trello.criarTag("Lista " + i.ToString(), "Cartão " + contCartao.ToString(), $@"//span[contains(@class,'card-label mod-edit-label mod-clickable card-label-{cor} palette-color js-palette-color')]"); //criarTag 
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
            List<string> listaCor = new List<string>() { "green", "yellow", "orange", "red", "purple", "blue","lime","pink","black","sky"};
            Random rand = new Random(DateTime.Now.Millisecond);
            string cor = listaCor[rand.Next(listaCor.Count)];
            return cor;
        }

        public void desmarcaTag(string nomeLista, string nomeCartao)
        {

            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'green')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'green')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'yellow')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'yellow')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'orange')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'orange')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'red')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'red')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'purple')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'purple')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'sky')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'sky')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'lime')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'lime')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'pink')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'pink')]"), 1000);
            }
            else if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath("//span[contains(@data-color,'black')]/span[contains(@class,'icon-sm icon-check card-label-selectable-icon light')]")))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'black')]"), 1000);
            }
            else
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//span[contains(@data-color,'blue')]"), 1000);
            }
        }
    }

}
