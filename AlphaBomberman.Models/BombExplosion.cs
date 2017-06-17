namespace AlphaBomberman.Models
{
    public class BombExplosion
    {
        //public static ElapsedEventHandler AfterTimer(int row, int col)
        //{
        //    var playerRow = row;
        //    var PlayerCol = col;
        //    Explosion(row, col);
        //    return Explosion(row, col);
        //}
        public static LevelModel Level = Player.Level;
 
        public static LevelModel Explosion(int row, int col)  // was void initially
        {
            var field = Level;
            var bombCoordinatesRow = row /*Player.PlayerOneY*/;
            var bombCoordinatesCol = col /*Player.PlayerOneX*/;
            var range = 3;

            //blow left
            for (int rowIndex = bombCoordinatesRow - range; rowIndex < bombCoordinatesRow; rowIndex++)
            {
                if (IsInMatrix(rowIndex, bombCoordinatesCol, field.Matrix))
                {
                    if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.DestructibleWall)
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerOneChar || field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerTwoChar)
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(rowIndex, bombCoordinatesCol);
                    }
                }
            }
            //blow right
            for (int rowIndex = bombCoordinatesRow + 1; rowIndex <= bombCoordinatesRow + range; rowIndex++)
            {
                if (IsInMatrix(rowIndex, bombCoordinatesCol, field.Matrix))
                {
                    if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.DestructibleWall)
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerOneChar || field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.PlayerTwoChar)
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = GameChars.EmptySpace;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(rowIndex, bombCoordinatesCol);
                    }
                }
            }
            //blow up
            for (int colIndex = bombCoordinatesCol - range; colIndex < bombCoordinatesCol; colIndex++)
            {
                if (IsInMatrix(bombCoordinatesRow, colIndex, field.Matrix))
                {
                    if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.DestructibleWall)
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerOneChar || field.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerTwoChar)
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(bombCoordinatesRow, colIndex);
                    }
                }
            }
            //blow down
            for (int colIndex = bombCoordinatesCol + 1; colIndex < bombCoordinatesCol + range; colIndex++)
            {
                if (IsInMatrix(bombCoordinatesRow, colIndex, field.Matrix))
                {
                    if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.DestructibleWall)
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.IndestructibleWall)
                    {
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerOneChar || field.Matrix[bombCoordinatesRow][colIndex] == GameChars.PlayerTwoChar)
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = GameChars.EmptySpace;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == GameChars.BombChar)
                    {
                        BombExplosion.Explosion(bombCoordinatesRow, colIndex);
                    }
                }
            }
            //field[bombCoordinatesRow][bombCoordinatesCol] = GameChars.EmptySpace; //-> NOT WORKING FOR SOME REASON

            //for (int i = 0; i < field.Matrix.Length; i++)
            //{
            //    Console.WriteLine(string.Join("", field.Matrix[i]));
            //}
            return field;
        }

        private static bool IsInMatrix(int currentRow, int currentCol, char[][] field)
        {
            if (currentRow >= 0 && currentRow < field.Length &&
                currentCol >= 0 && currentCol < field[currentRow].Length)
            {
                return true;
            }
            return false;
        }
    }
}