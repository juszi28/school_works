using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Awari.Model;
using Awari.Persistence;
using Moq;

namespace AwariTest
{
    [TestClass]
    public class AwariTestClass
    {
        private AwariGameModel model;
        private Mock<IAwariDataAccess> mock;
        private (int, int, bool, int, int[]) loadMock;

        [TestInitialize]
        public void Initialize()
        {
            loadMock.Item5 = new int[10];
            mock = new Mock<IAwariDataAccess>();
            mock.Setup(mock => mock.LoadAsync(It.IsAny<String>())).Returns(() => Task.FromResult(loadMock));
            // a mock a LoadAsync mûveletben bármilyen paraméterre az elõre beállított játéktáblát fogja visszaadni

            model = new AwariGameModel(8, mock.Object);
            model.NewGame();
            // példányosítjuk a modellt a mock objektummal

            model.GameStep += new EventHandler<EventArgs>(Model_GameStep);
            model.GameOver += new EventHandler<AwariEventArgs>(Model_GameOver);
        }

        [TestMethod]
        public void AwariNewEasyGameTest()
        {
            model.BinNumber = 4;
            model.NewGame();

            Assert.AreEqual(Player.RedPlayer, model.CurrentPlayer);
            Assert.AreEqual(4, model.BinNumber);
            Assert.AreEqual(false, model.SecondTurn);
            Assert.AreEqual(0, model.MoveCount);

            //tábla ellenõrzése
            for(int i = 0; i < model.Table.Length; ++i)
            {
                if (i == 2 || i == 5)
                    Assert.AreEqual(0, model.Table[i]);
                else
                    Assert.AreEqual(6, model.Table[i]);
            }
        }

        [TestMethod]
        public void AwariNewMediumGameTest()
        {
            model.BinNumber = 8;
            model.NewGame();

            Assert.AreEqual(Player.RedPlayer, model.CurrentPlayer);
            Assert.AreEqual(8, model.BinNumber);
            Assert.AreEqual(false, model.SecondTurn);
            Assert.AreEqual(0, model.MoveCount);

            //tábla ellenõrzése
            for (int i = 0; i < model.Table.Length; ++i)
            {
                if (i == 4 || i == 9)
                    Assert.AreEqual(0, model.Table[i]);
                else
                    Assert.AreEqual(6, model.Table[i]);
            }
        }

        [TestMethod]
        public void AwariNewHardGameTest()
        {
            model.BinNumber = 12;
            model.NewGame();

            Assert.AreEqual(Player.RedPlayer, model.CurrentPlayer);
            Assert.AreEqual(12, model.BinNumber);
            Assert.AreEqual(false, model.SecondTurn);
            Assert.AreEqual(0, model.MoveCount);

            //tábla ellenõrzése
            for (int i = 0; i < model.Table.Length; ++i)
            {
                if (i == 6 || i == 13)
                    Assert.AreEqual(0, model.Table[i]);
                else
                    Assert.AreEqual(6, model.Table[i]);
            }
        }

        [TestMethod]
        public void AwariGameStepTest()
        {
            Assert.AreEqual(Player.RedPlayer, model.CurrentPlayer);
            Assert.AreEqual(0, model.MoveCount);

            model.StepGame(1);
            Assert.AreEqual(1, model.MoveCount);
            Assert.AreEqual(Player.BluePlayer, model.CurrentPlayer);
            Assert.AreEqual(0, model.Table[0]);
        }

        [TestMethod]
        public async Task AwariGameModelLoadASyncTest()
        {
            // kezdünk egy új játékot
            model.NewGame();

            // majd betöltünk egy játékot
            await model.LoadGameAsync(String.Empty);

            Assert.AreEqual(0, loadMock.Item1);
            Assert.AreEqual(0, loadMock.Item2);
            Assert.AreEqual(false, loadMock.Item3);
            Assert.AreEqual(0, loadMock.Item4);
            for (int i = 0; i < loadMock.Item5.Length; i++)
            {
                Assert.AreEqual(0, loadMock.Item5[i]);
            }

            // ellenõrizzük, hogy meghívták-e a Load mûveletet a megadott paraméterrel
            mock.Verify(dataAccess => dataAccess.LoadAsync(String.Empty), Times.Once());
        }
        private void Model_GameStep(Object sender, EventArgs e)
        {
            Assert.AreEqual(false, model.Won);
            Assert.AreEqual(false, model.Draw);
        }

        private void Model_GameOver(Object sender, AwariEventArgs e)
        {
            Assert.AreEqual(0, e.RedPot);
            Assert.AreEqual(0, e.BluePot);
            Assert.AreEqual(false, model.Won);
            Assert.AreEqual(true, model.Draw);
        }
    }
}
