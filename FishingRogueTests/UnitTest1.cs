using Microsoft.VisualStudio.TestTools.UnitTesting;
using FishingRogue;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishingRogueTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPlayerIsDrawnToCenterOfScreen()
        {
            Player player = new Player();
            Sprite sprite = player.GetComponent<Sprite>();
            sprite.customWidth = 100;
            sprite.customHeight = 100;
            Rectangle actualRectangle = sprite.WorldSpaceToCameraSpace();
            Rectangle expectedRectangle = new Rectangle(
                x: 1920 / 2,
                y: 1080 / 2,
                width: 100,
                height: 100
                );
            Assert.AreEqual(expectedRectangle, actualRectangle);
        }

        [TestMethod]
        public void TestPlayerInitialPositionIsCorrect()
        {
            Player player = new Player();

        }
        [TestMethod]
        public void TestPlayerIsUsingWorldPosition()
        {
            Player player = new Player();

        }
        [TestMethod]
        public void TestFishingIsUsingCameraPosition()
        {

        }
        [TestMethod]
        public void TestFishingRodIsDrawnNextToPlayer()
        {

        }

    }
}