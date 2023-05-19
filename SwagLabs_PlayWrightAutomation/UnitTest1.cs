using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;

namespace SwagLabs_PlayWrightAutomation
{
    [TestFixture]
    public class UnitTest1 : PageTest
    {

        [SetUp]
        public async Task Setup()
        {
            ContextOptions();

            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public async Task TearDown()
        {
            // Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = @"trace/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString() + ".zip"
            });

            await Context.CloseAsync();
            await Browser.CloseAsync();
        }

        [Test]
        public async Task TestMethod1()
        {

            await Page.GotoAsync("https://saucedemo.com/");

            //await Page.EvaluateAsync("document.body.style.zoom=0.9");

            await Page.FillAsync("#user-name", "standard_user");
            await Page.FillAsync("#password", "secret_sauce");
            Thread.Sleep(3000);
            await Page.ClickAsync("#login-button");

            await Page.ClickAsync("#add-to-cart-sauce-labs-backpack");
            await Page.ClickAsync("#add-to-cart-sauce-labs-bike-light");
            await Page.ClickAsync("#add-to-cart-sauce-labs-bolt-t-shirt");
            await Page.ClickAsync("#add-to-cart-sauce-labs-fleece-jacket");
            await Page.ClickAsync("#add-to-cart-sauce-labs-onesie");
            await Page.ClickAsync("#add-to-cart-test\\.allthethings\\(\\)-t-shirt-\\(red\\)");

            await Page.ClickAsync("#shopping_cart_container > a");

            await Page.ClickAsync("#checkout");

            await Page.FillAsync("#first-name", "Mujahid");
            await Page.FillAsync("#last-name", "Akber Ali");
            await Page.FillAsync("#postal-code", "78600");
            Thread.Sleep(2000);
            await Page.ClickAsync("#continue");
            await Page.ClickAsync("#finish");
            Thread.Sleep(2000);
            await Page.ClickAsync("#back-to-products");

        }
           public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                RecordVideoDir = @"videos/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString(),
                //StorageStatePath = @"state\pagetest_state.json",
                ViewportSize = new ViewportSize
                {
                    Height = 1080,
                    Width = 1280
                },
                RecordVideoSize = new RecordVideoSize
                {
                    Height = 1080,
                    Width = 1280
                }
            };
        }

    }
}