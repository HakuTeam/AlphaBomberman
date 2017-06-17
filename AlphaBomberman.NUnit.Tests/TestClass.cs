using NUnit.Framework;

namespace AlphaBomberman.NUnit.Tests
{
    using Models;

    [TestFixture]
    [Author("Zlatyo Uzunov")]
    public class TestClass
    {
        [Test]
        [Author("Zlatyo Uzunov")]
        [Property("Player Tests", 1)]
        public void PlayerRespectsUpperWall()
        {
            //Arrange player on first valid row;
            int initialRow = 1;
            var player = new PlayerNew(initialRow, 1);

            //Act
            player.MoveUp();
            player.Move();
            
            //Assert
            Assert.AreEqual(initialRow,player.Row);
        }

        [Test]
        [Author("Zlatyo Uzunov")]
        [Property("Player Tests", 2)]
        public void PlayerRespectsLeftWall()
        {
            //Arrange player on first valid row;
            int initialColumn = 1;
            var player = new PlayerNew(1, initialColumn);

            //Act
            player.MoveLeft();
            player.Move();

            //Assert
            Assert.AreEqual(initialColumn, player.Column);
        }

        [Test]
        [Author("Zlatyo Uzunov")]
        [Property("Player Tests", 3)]
        public void PlayerRespectsConsoleBufferWidth()
        {
            //Arrange player on first valid row;
            int limitColumn = 17;
            var player = new PlayerNew(1, limitColumn,44,limitColumn);

            //Act
            player.MoveLeft();
            player.Move();

            //Assert
            Assert.AreEqual(limitColumn, player.Column);
        }

        [Test]
        [Author("Zlatyo Uzunov")]
        [Property("Player Tests", 3)]
        public void PlayerRespectsConsoleBufferHeight()
        {
            //Arrange player on last valid row;
            int endRow = 10;
            var player = new PlayerNew(endRow, 1,endRow);

            //Act
            player.MoveDown();
            player.Move();

            //Assert
            Assert.AreEqual(endRow, player.Row);
        }
    }
}
