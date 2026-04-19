using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Automacao
{
    class Trello
    {

        public void paginaInicial()
        {
            Global.capabilitiesMethods.Navigate(Global.driver, "https://trello.com/");
        }

        //elementos
        private static string acceptCookies = "onetrust-accept-btn-handler";
        private static string menuHamburguer = "//button[@data-testid='menubutton']";
        private static string lnkLogin = "//a[contains(@data-uuid,'login')]";
        private static string user = "//input[contains(@id,'username')]";
        private static string btnSubmit = "login-submit";
        private static string password = "password";
        private static string codeVerification = "//div[contains(@data-testid,'otp-input-index')]";
        private static string promptMfa = "mfa-promote-dismiss";
        private static string preferencesCookies = "//span[@data-testid='experiment-one-button-icon']";
        private static string creatFrame = "//button[@data-testid='create-board-tile']/div/span";
        private static string creatFrameList = "//li[@data-testid='create-board-tile']/div/p/span";
        private static string nameFrame = "//input[contains(@class,'nch-textfield__input')]";
        private static string btnCreatFrame = "//button[contains(@data-testid,'create-board-submit-button')]";
        private static string btnCollapseDesktop = "//button[@data-testid='workspace-navigation-collapse-button']";
        private static string portal = "//div[@class='atlaskit-portal']";
        private static string txtareaListName = "//textarea[@data-testid='list-name-textarea']";
        private static string btnListComposer = "//button[contains(@data-testid,'list-composer')]";
        private static string nameList = "//*[*[textarea[@data-testid='list-name-textarea']]//button[contains(@data-testid,'list-composer-add')]]//textarea";
        private static string btnSaveList = "//button[@data-testid='list-composer-add-list-button']";
        private static string closeIcon = "//button[span/span[contains(@data-testid,'CloseIcon')]]";
        private static string nameCard = "//textarea[contains(@data-testid,'list-card-composer-textarea')]";
        private static string saveCard = "//button[contains(@data-testid,'list-card-composer-add-card-button')]";
        private static string menuTag = "//button[contains(text(),'Etiquetas')]";
        private static string btnNewTag = "//button[text()='Criar uma nova etiqueta']";
        private static string btnCreatTag = "(//button[contains(text(),'Criar')])[2]";
        private static string btnCloseTag = "//button[contains(@aria-label,'pop-over')]";
        private static string btnCloseCard = "//button[contains(@aria-label,'Fechar caixa de diálogo')]//span[contains(@data-testid,'CloseIcon')]";
        private static string tagSelected = "//*[input[@aria-checked='true']]/span/span";
        private static string btnMenuArquive = "//button[@data-testid='card-back-archive-button']";
        private static string exclude = "//button[@data-testid='card-back-delete-card-button']";
        private static string confirmExclude = "//button[@data-testid='popover-confirm-button']";
        private static string showMenu = "//button[@aria-label='Mostrar Menu']";
        private static string btnItensArquiveted = "//button[div[contains(text(),'Itens arquivados')]]";
        private static string btnAlternList = "//button[normalize-space(text())='Listas']";
        private static string confirmExcludeList = "//button[contains(text(),'Excluir')]";
        private static string btnCloseExcludeList = "//button[contains(@aria-label,'Fechar pop-over')]";
        private static string btnShowMenu = "//*[button[@data-testid='board-share-button']]/button[@aria-label='Mostrar Menu']";
        private static string btnCloseFrame = "//button[div[normalize-space(text())='Fechar quadro']]";
        private static string removeIcon = "//*[*[span[@data-testid='RemoveIcon']]]";
        private static string closeBoardConfirmOne = "//button[@data-testid='popover-close-board-confirm']";
        private static string closeBoardDelete = "//button[contains(@data-testid,'close-board-delete')]";
        private static string closeBoardDeleteExclude = "//button[contains(@data-testid,'close-board-delete') and normalize-space(text())='Excluir']";
        private static string headMember = "//section[@data-testid='header-member-menu-popover']";
        private static string btnOpenHeaderMemberMenu = "//button[contains(@class,'open-header-member-menu')]";
        private static string btnLogout = "//button[contains(@data-testid,'logout')]";
        private static string btnSecondLogout = "//button[contains(@data-testid,'logout-button')]";
        private static string boardIcon = "(//span[@data-testid='BoardIcon'])[2]";
        private static string preferences = "//span[@data-testid='experiment-one-button-icon']";
        private static string bannerNews = "//h2[contains(text(),'Conheça as novidades')]";
        private static string btnIgnore = "//button[span[contains(text(),'Ignorar')]]";
        private static string btnIOk = "//button[span[contains(text(),'OK')]]";
        private static string addTag = "//button[contains(@aria-label,'etiqueta')]";
        private static string openActions = "//button[contains(@data-testid,'card-back')and contains(@aria-label,'Ações')]";
        private static string btnArquiveList = "//button[contains(@data-testid,'archive')]";
        private static string lnkSmallNav = "//a[contains(text(),'Log in') and contains(@class,'SmallNav')]";
        private static string h1FreeAssessment = "//h1[contains(text(),'avaliação gratuita')]";
        private static string freeVersion = "//button[contains(text(),'versão grátis')]";
        private static string planFree = "//button[contains(text(),'plano grátis')]";
        private static string closeBoardsPage = "settings-full-page-close-button";
        private static string minimize = "(//div[contains(@data-testid,'ad-container')]//button[contains(@title,Minimizar)])[1]";
        public void login()
        {

            //clica no botão de login
            Global.capabilitiesMethods.WaitVisible(Global.driver, By.Id(acceptCookies));
            Global.capabilitiesMethods.Click(Global.driver, By.Id(acceptCookies), 1000);
            Global.capabilitiesMethods.WaitHideElement(Global.driver, By.Id(acceptCookies));
            //verifica se existe o menu hamburguer
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(menuHamburguer)))
            {
                //clica no menu hamburguer
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(menuHamburguer), 1000);
                //clica no botão login
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(lnkLogin), 1000);
                if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(lnkSmallNav)))
                {
                    Global.capabilitiesMethods.Click(Global.driver, By.XPath(lnkSmallNav), 1000);
                }
            }
            // Verifica se existe outro botão de login
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(lnkLogin)))
            {
                //clica o botão login
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(lnkLogin), 1000);
            }
            //preenche o combo de login
            Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath(user), Global.user);
            //clica no login
            Global.capabilitiesMethods.Click(Global.driver, By.Id(btnSubmit), 2000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            //aguarda o combo de senha
            Global.capabilitiesMethods.WaitExists(Global.driver, By.Id(password));
            //preenche o combo de senha
            Global.capabilitiesMethods.SendKeys(Global.driver, By.Id(password), Global.pass);
            //clica em acessar         
            Global.capabilitiesMethods.Click(Global.driver, By.Id(btnSubmit), 2000);
            //espera ocultar o botão acessar
            Global.capabilitiesMethods.WaitHideElement(Global.driver, By.Id(btnSubmit));
            // Caso precise digitar código de verificação (OTP)
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(codeVerification)))
            {
                string codigo = Global.capabilitiesMethods.ObterCodigoVerificacaoGmail();
                int indiceDoisPontos = codigo.LastIndexOf("código:");

                codigo = codigo.Substring(indiceDoisPontos, 17);
                codigo = codigo.Replace("código:", "").TrimStart();
                int contador = 0;
                foreach (char key in codigo)
                {
                    Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath($@"//div[contains(@data-testid,'otp-input-index-{contador}-container')]/input"), key.ToString());
                    contador++;
                }
            }
            // Remove o prompt de MFA caso apareça
            if (Global.capabilitiesMethods.Exists(Global.driver, By.Id(promptMfa)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.Id(promptMfa), 50);
            }
            Global.capabilitiesMethods.Wait(3000);
            //verifica se o banner está visivel e fecha
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(bannerNews)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnIgnore), 2000);

            }
            //verifica se o banner com o botão ok está visivel e fecha
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnIOk)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnIOk), 1000);
            }
        }



        public void criarQuadro(string novoQuadro)
        {
            // espera a página carregar
            Global.capabilitiesMethods.Wait(3000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            //fecha as preferencias de cookies
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath(preferencesCookies)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(preferencesCookies), 1000);
            }
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
             //verifica se o banner de novidades está aberto e fecha
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(bannerNews)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnIgnore), 2000);
            }
            //verifica se o banner com o botão ok está visivel e fecha
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnIOk)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnIOk), 2000);
            }
            // clica no link para criar quadro
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath(creatFrame)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(creatFrame));
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(creatFrame), 1000);
            }
            //verifica se o banner com o botão ok está visivel e fecha
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnIOk)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnIOk), 2000);
            }
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath(creatFrameList)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(creatFrameList)
                );
                for (int i = 0; i < 3; i++)
                {
                    Global.capabilitiesMethods.Click(Global.driver, By.XPath(creatFrameList), 1000);
                    if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(nameFrame)))
                    {
                        i = 3;
                    }
                }
            }
            //nomeia o quadro
            Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath(nameFrame), novoQuadro);
            //cria o quadro
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCreatFrame), 3000);
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnIgnore)))
            {
                //fecha o planejador
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnIgnore), 1000);
            }
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(h1FreeAssessment)))
            {
                if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(freeVersion)))
                {
                    Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(freeVersion));
                }
                //fecha o planejador
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(freeVersion), 3000);
            }
            //plano grátis
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(planFree)))
            {
                //fecha o planejador
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(planFree), 3000);
            }

        }


        public void criarLista(string novaLista)
        {
            //recolhe a aba Area de trabalho
            if (Global.capabilitiesMethods.IsDisplayed(Global.driver, By.XPath(btnCollapseDesktop)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCollapseDesktop), 1000);
            }
            // Se existe portal aberto, pressiona ESC
            if (Global.capabilitiesMethods.IsDisplayed(Global.driver, By.XPath(portal)))
            {
                Global.capabilitiesMethods.PressionarEsc(Global.driver);
            }
           
            // Se o container-ad estiver visível fecha
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(minimize)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(minimize), 1000);
            }
            // Se o closeIcon estiver visivel fecha
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(closeIcon)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(closeIcon), 1000);
            }
            // Verifica se a área para digitar o nome da lista está aberta
            if (!Global.capabilitiesMethods.IsDisplayed(Global.driver, By.XPath(txtareaListName)))
            {
                //botão nova lista
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnListComposer), 1000);
            }
            //nomeia a lista              
            Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath(nameList), novaLista);
            // salva a lista
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnSaveList), 1000);
            //cancela a nova lista
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(closeIcon), 1000);
        }
        public void criarCartao(string nomeLista, string novoCartao)
        {

            //novo cartão
            Global.capabilitiesMethods.Click(Global.driver,
                By.XPath($@"//div[div[div/textarea[contains(text(),'{nomeLista}')]]]/div[@data-testid='list-footer']/button"),
                1000);
            // nomeia o cartão
            Global.capabilitiesMethods.SendKeys(Global.driver, By.XPath(nameCard), novoCartao);
            // salva
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(saveCard), 1000);
        }

        public void criarTag(string nomeLista, string nomeCartao, string xPathCor = "")
        {
            //abre o cartão
            Global.capabilitiesMethods.Click(Global.driver,
                By.XPath($@"//*[div[div/textarea[contains(text(),'{nomeLista}')]]]//a[@data-testid='card-name' and text()='{nomeCartao}']"),
                1000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            // seleciona o menu tag
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(menuTag), 1000);
            //botão nova etiqueta
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnNewTag), 3000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(xPathCor)))
            {
                //rola até a cor        
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(xPathCor));
            }
            //escolhe a cor        
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(xPathCor), 1000);
            //rola até o botão criar
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnCreatTag)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnCreatTag));
            }
            //botão criar            
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCreatTag), 1000);
            //rola até o botão fechar etiqueta
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnCloseTag)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnCloseTag));
            }
            //fecha  a edição da etiqueta
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCloseTag), 1000);
            //rola até o botão fechar cartão
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnCloseCard)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnCloseCard));
            }
            // fecha a edição do cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCloseCard), 1000);

        }
        public void removerTag(string nomeLista, string nomeCartao)
        {
            //abre o cartão
            Global.capabilitiesMethods.Click(Global.driver,
                By.XPath($@"//*[div[div/textarea[contains(text(),'{nomeLista}')]]]//a[@data-testid='card-name' and text()='{nomeCartao}']"),
                1000);
            // seleciona o menu tag
            Global.capabilitiesMethods.Click(Global.driver,
                By.XPath(addTag),
                1000);
            //rola até a tag selecionada
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(tagSelected)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(tagSelected));
            }
            //desmarca tag
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(tagSelected), 1000);
            //fecha  a edição da etiqueta
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCloseTag), 1000);
            // fecha a edição do cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCloseCard), 1000);
        }
        public void excluirCartao(string nomeLista, string nomeCartao)
        {
            //abre o cartão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"//*[div[div/textarea[contains(text(),'{nomeLista}')]]]//a[@data-testid='card-name' and text()='{nomeCartao}']"), 1000);
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(openActions), 1000);
            //rola até o menu arquivar
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnMenuArquive)))
            {
                Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnMenuArquive));
            }
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnMenuArquive), 1000);


            //excluir
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(exclude), 1000);
            //confirma exclusão 
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(confirmExclude), 1000);
        }
        public void excluirLista(string nomeLista)
        {
            //abre o cartão
            Global.capabilitiesMethods.Click(Global.driver,
                By.XPath(
                    $@"//div[div/textarea[contains(text(),'{nomeLista}')]]//button[@data-testid='list-edit-menu-button']"), 1000);
            //seleciona o menu arquivar
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnArquiveList)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnArquiveList));
            }
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnArquiveList), 1000);


            //abre o menu
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(showMenu), 1000);
            //abre os itens arquivados
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnItensArquiveted)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnItensArquiveted));
            }
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnItensArquiveted), 1000);

            //clica no botão alternar para listas
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnAlternList), 1000);
            // clica no botão para excluir lista
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(
                $@"//*[div[contains(text(), '{nomeLista}')]]//button//span[contains(@data-testid,'TrashIcon')]"), 1000);
            //confirma a exclusão
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(confirmExcludeList), 1000);
            //fechar
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCloseExcludeList), 1000);


        }

        public void excluirQuadro()
        {
            //Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnShowMenu)))
            {
                //abre o menu
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnShowMenu), 1000);
            }
            //seleciona fechar o quadro 
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath(btnCloseFrame)))
            {
                if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnCloseFrame)))
                {

                    Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnCloseFrame));
                }
                Global.capabilitiesMethods.Wait(2000);
                //fechar quadro
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnCloseFrame), 2000);
            }
            //seleciona fechar o quadro dentro do elemento li
            else if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath(removeIcon)))
            {
                if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(removeIcon)))
                {

                    Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(removeIcon));
                }
                Global.capabilitiesMethods.Wait(2000);
                //fechar quadro
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(removeIcon), 2000);
            }
            Global.capabilitiesMethods.Wait(2000);
            Global.capabilitiesMethods.WaitClickable(Global.driver, By.XPath(closeBoardConfirmOne));
            // Confirmação 1
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(closeBoardConfirmOne)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(closeBoardConfirmOne));
            }
            //1ª confirmação
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(closeBoardConfirmOne), 2000);
            //abre o menu

            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnShowMenu)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnShowMenu), 2000);
            }
            //2ª confirmação
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(closeBoardDelete), 2000);
            //excluir
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(closeBoardDeleteExclude), 2000);

        }

        public void logout()
        {
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(headMember)))
            {
                //abre o menu
                Global.capabilitiesMethods.WaitClickable(Global.driver, By.XPath(btnOpenHeaderMemberMenu));
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnOpenHeaderMemberMenu), 3000);
            }
            Global.capabilitiesMethods.Wait(2000);
            Global.capabilitiesMethods.WaitForPageLoad(Global.driver);
            //sair 1
            if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(btnOpenHeaderMemberMenu)))
            {
                Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath(btnLogout));
            }

            Global.capabilitiesMethods.Click(Global.driver,
                By.XPath(btnLogout),
                1000);
            //sair 2 
            Global.capabilitiesMethods.Click(Global.driver, By.XPath(btnSecondLogout), 2000);
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

            Global.capabilitiesMethods.Click(Global.driver, By.XPath(boardIcon), 2000);

            //fecha as preferencias de cookies
            if (Global.capabilitiesMethods.Exists(Global.driver, By.XPath(preferences)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.XPath(preferences), 2000);
            }

            int quantidade = Global.capabilitiesMethods.CountElements(Global.driver, By.XPath(xPath));

            if (quantidade > 0)
            {
                for (int i = quantidade; i >= 1; i--)
                {
                    Global.capabilitiesMethods.Wait(2000);
                    if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath(boardIcon)))
                    {
                        Global.capabilitiesMethods.Click(Global.driver, By.XPath(boardIcon), 2000);
                    }
                    if (!Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath($@"{xPath}[{i}]")))
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Global.capabilitiesMethods.ScrollToElement(Global.driver, By.XPath($@"{xPath}[{i}]"));

                            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.XPath($@"{xPath}[{i}]")))
                            {
                                Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"{xPath}[{i}]"), 2000);
                                j = 3;

                            }
                        }
                    }
                    else
                    {
                        Global.capabilitiesMethods.Click(Global.driver, By.XPath($@"{xPath}[{i}]"), 2000);
                    }

                    Global.trello.excluirQuadro();//excluirQuadro
                }
            }
            if (Global.capabilitiesMethods.IsVisible(Global.driver, By.Id(closeBoardsPage)))
            {
                Global.capabilitiesMethods.Click(Global.driver, By.Id(closeBoardsPage), 1000);
            }

        }
    }

}
