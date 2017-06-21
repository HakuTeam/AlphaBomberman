using NUnit.Framework;

namespace AlphaBomberman.NUnit.Tests
{
    using System;
    using Utilities.ScreenElementsComposite;

    [TestFixture]
    [Author("Zlatyo Uzunov")]
    public class AplhaBombermanTests
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

        [Test]
        [Author("Zlatyo Uzunov")]
        [Property("Interface Tests", 1)]
        public void InputNoNegativePositions()
        {
            //Arrange player on first valid row;
            int inputRow = -1;
            int inputColumn = -1;

            //Act
            void CreateInput()
            {
                var userInput = new Input(inputRow, inputColumn, "123", 2);
            }

            //Assert
            Assert.Throws<Exception>(CreateInput);
        }
    }

    public class PlayerNew
    {
        private int endRow;
        private int limitColumn;

        public PlayerNew(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public PlayerNew(int row, int column, int endRow) : this(row, column)
        {
            this.endRow = endRow;
        }

        public PlayerNew(int row, int column, int endRow, int limitColumn) : this(row, column, endRow)
        {
            this.limitColumn = limitColumn;
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }
    }
}
