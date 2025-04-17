using System;
using System.IO;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using System.Drawing;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using OpenQA.Selenium.Interactions;

using OpenQA.Selenium.Support.UI;

using System.Text.RegularExpressions;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;


namespace Automacao
{
    class CapabilitiesMethods
    {
        public IWebDriver BrowserConfig()
        {
            // Configurações do Chrome            
            string projectPath = @System.Environment.CurrentDirectory.ToString();
            string chromeDriverPath;
            var options = new ChromeOptions();
            var os = Environment.OSVersion;
            Global.osLinux = os.Platform == PlatformID.Unix;
            ChromeDriverService service;
            if (Global.osLinux)
            {
                chromeDriverPath = "/usr/bin/";
                service = ChromeDriverService.CreateDefaultService(chromeDriverPath, "chromedriver");
            }
            else
            {
                chromeDriverPath = projectPath;
                service = ChromeDriverService.CreateDefaultService(chromeDriverPath, "chromedriver.exe");
            }
            options.AddArgument("--headless");
            options.AddArgument("--incognito");
            options.AddArgument("--start-maximized");// Inicia maximizado
            //options.AddArgument("--window-position=1,0"); // Metade direita (960px de largura)
            //options.AddArgument("--window-size=960,1080");  // Ajusta o tamanho para metade da tela
            //options.AddArgument("--no-sandbox");
            //options.AddArgument("--disable-dev-shm-usage");
            //options.AddArgument("--disable-gpu");
            //options.AddArgument("--ignore-certificate-errors-spki-list");
            //options.AddArgument("use-fake-ui-for-media-stream");
            //options.AddArgument("use-fake-device-for-media-stream");
            //options.AcceptInsecureCertificates = true;

            // Instância do driver
            //IWebDriver driver = new ChromeDriver(service, options);
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options, TimeSpan.FromMinutes(1));
            return driver;
        }

        public void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
        public void Navigate(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            WaitForPageLoad(driver);
        }
        public void WaitForPageLoad(IWebDriver driver)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait Wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception)
            {

            }
        }
        public void WaitVisible(IWebDriver driver, By element)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            Wait(400);
        }
        public void WaitClickable(IWebDriver driver, By element)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public void WaitSelectable(IWebDriver driver, By element)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeSelected(element));
        }
        public void WaitExists(IWebDriver driver, By element)
        {
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementExists(element));
        }
        public void Click(IWebDriver driver, By element, int milliseconds = 0)
        {
            WaitClickable(driver, element);
            driver.FindElement(element).Click();
            Wait(milliseconds);
        }
        public void DoubleClick(IWebDriver driver, By element, int milliseconds = 0)
        {
            WaitClickable(driver, element);

            OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);
            IWebElement webElement = driver.FindElement(element);
            actions.DoubleClick(webElement).Perform();
            Wait(milliseconds);
        }
        public void Clear(IWebDriver driver, By element)
        {
            WaitExists(driver, element);
            driver.FindElement(element).Clear();
        }
        public void SendKeys(IWebDriver driver, By element, string text, int milliseconds = 0)
        {
            WaitVisible(driver, element);
            driver.FindElement(element).SendKeys(text);
            Wait(milliseconds);
        }
        public void SwitchFrame(IWebDriver driver, string frame)
        {
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame(frame);
        }
        public void DefaultContentFrame(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }
        public bool GetElementSelected(IWebDriver driver, By element)
        {
            WaitExists(driver, element);
            return driver.FindElement(element).Selected;
        }
        public string GetElementValue(IWebDriver driver, By element)
        {
            WaitExists(driver, element);
            return driver.FindElement(element).GetAttribute("value");
        }
        public string GetElementAttribute(IWebDriver driver, By element, string name)
        {
            WaitExists(driver, element);
            string result = "";
            IWebElement webElement = driver.FindElement(element);
            Size elementSize = webElement.Size;
            switch (name)
            {
                case "width":
                    result = elementSize.Width.ToString();
                    break;
                case "height":
                    result = elementSize.Height.ToString();
                    break;
                default:
                    result = driver.FindElement(element).GetAttribute(name);
                    break;
            }
            return result;
        }
        public string GetElementCssProperty(IWebDriver driver, By element, string property)
        {
            WaitExists(driver, element);
            return driver.FindElement(element).GetCssValue(property);
        }
        public string GetElementText(IWebDriver driver, By element)
        {
            WaitExists(driver, element);
            return driver.FindElement(element).Text;
        }
        public int GetElementsCount(IWebDriver driver, By element)
        {
            return driver.FindElements(element).Count;
        }
        public void SetElementAttribute(IWebDriver driver, By element, string name, string value)
        {
            WaitExists(driver, element);
            IWebElement webElement = driver.FindElement(element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0]." + name + "='" + value + "';", webElement);
        }
        public void SetSelectByValue(IWebDriver driver, By element, string value, int milliseconds = 0)
        {
            WaitExists(driver, element);
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(element));
            selectElement.SelectByValue(value);
            Wait(milliseconds);
        }
        public void SetSelectByText(IWebDriver driver, By element, string text)
        {
            WaitExists(driver, element);
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(driver.FindElement(element));
            selectElement.SelectByText(text);
        }
        public bool Exists(IWebDriver driver, By element)
        {
            bool result;
            try
            {
                IWebElement webElement = driver.FindElement(element);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public bool IsDisplayed(IWebDriver driver, By element)
        {
            bool result;
            try
            {
                IWebElement webElement = driver.FindElement(element);
                result = webElement.Displayed;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public bool IsVisible(IWebDriver driver, By element)
        {
            bool result;
            try
            {
                IWebElement webElement = driver.FindElement(element);
                result = (bool)((IJavaScriptExecutor)driver).ExecuteScript("var elem = arguments[0], box = elem.getBoundingClientRect(), cx = box.left + box.width / 2, cy = box.top + box.height / 2, e = document.elementFromPoint(cx, cy); for (; e; e = e.parentElement) { if (e === elem) return true; } return false;", webElement);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public void SendKeys(IWebDriver driver, string text, int milliseconds = 0)
        {
            OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.SendKeys(text).Build().Perform();
            Wait(milliseconds);
        }
        public void MouseOver(IWebDriver driver, By element, int milliseconds = 0)
        {
            IWebElement webElement = driver.FindElement(element);
            OpenQA.Selenium.Interactions.Actions actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.MoveToElement(webElement).Perform();
            Wait(milliseconds);
        }


        public int CountElements(IWebDriver driver, By element)
        {
            return Global.driver.FindElements(element).Count;
        }

        public void WaitHideElement(IWebDriver driver, By element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); // define o timeout
            wait.Until(driver =>
            {
                try
                {
                    var elementos = driver.FindElements(element);
                    return elementos.Count == 0 || !elementos[0].Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            });
        }
        public void PressionarEsc(IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Escape).Perform();
        }
        public void TentarClicarElemento(IWebDriver driver, By by, int tempoEspera = 1000)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Global.capabilitiesMethods.IsVisible(driver, by))
                {
                    Global.capabilitiesMethods.Click(driver, by, tempoEspera);
                    //Global.capabilitiesMethods.ScreeanShot();
                    i = 3;
                }
            }
        }

        public void TentarPreencherCampo(IWebDriver driver, By by, string texto)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Global.capabilitiesMethods.IsVisible(driver, by))
                {
                    Global.capabilitiesMethods.SendKeys(driver, by, texto);
                    //Global.capabilitiesMethods.ScreeanShot();
                    i = 3;
                }
            }
        }

        public void ScrollToElement(IWebDriver driver, By by)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!Global.capabilitiesMethods.IsVisible(driver, by))
                {
                    IWebElement elemento = driver.FindElement(by);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", elemento);

                }
                if (Global.capabilitiesMethods.IsVisible(driver, by))
                {
                    i = 3;
                }
            }
        }

        public void ScreeanShot()
        {
            // Tira o print antes de fechar o browser
            Screenshot screenshot = ((ITakesScreenshot)Global.driver).GetScreenshot();
            // Define o caminho e o nome do arquivo do print
            string fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string filePath = Path.Combine($@"C:\Cursos\Teste Trello\Print", fileName);

            // Salva o print
            screenshot.SaveAsFile(filePath);
        }

        public string ObterCodigoVerificacaoGmail()
        {
            using (var client = new ImapClient())
            {
                // Ignora a verificação de certificado SSL
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                // Conecta ao servidor Gmail via IMAP
                client.Connect("imap.gmail.com", 993, true);

                // Autenticação com senha de app
                client.Authenticate("mail.qa@gmail.com", "");

                // Acessa a caixa de entrada
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                // Busca e-mails com "Trello" no assunto (sem filtro de não lido)
                var uids = inbox.Search(SearchQuery.SubjectContains("Verificação da sua identidade"));

                if (uids.Count == 0)
                    throw new Exception("Nenhum e-mail com o assunto 'Verificação da sua identidade' encontrado.");

                // Pega o último e-mail da lista
                var mensagem = inbox.GetMessage(uids[uids.Count - 1]);
                string corpo = mensagem.TextBody;


                // Aqui você pode aplicar um regex pra extrair um código, se quiser.
                return corpo;
            }
        }



    }
}

