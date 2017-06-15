namespace AlphaBomberman.Models
{
    using System;
    using System.Timers;

    public class BombExplosion
    {
        //public static ElapsedEventHandler AfterTimer(int row, int col)
        //{
        //    var playerRow = row;
        //    var PlayerCol = col;
        //    Explosion(row, col);
        //    return Explosion(row, col);
        //}

        public static LevelModel Explosion(int row, int col)  // was void initially
        {
            var field = new LevelModel(11, 17);
            var bombCoordinatesRow = row /*Player.PlayerOneY*/;
            var bombCoordinatesCol = col /*Player.PlayerOneX*/;
            var range = Bomb.Range();

            //blow left
            for (int rowIndex = bombCoordinatesRow - range; rowIndex < bombCoordinatesRow; rowIndex++)
            {
                if (IsInMatrix(rowIndex, bombCoordinatesCol, field.Matrix))
                {
                    if (field.Matrix[rowIndex][bombCoordinatesCol] == '*')
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == '#')
                    {
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == 'P' || field.Matrix[rowIndex][bombCoordinatesCol] == 'K')
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == 'B')
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
                    if (field.Matrix[rowIndex][bombCoordinatesCol] == '*')
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == '#')
                    {
                        break;
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == 'P' || field.Matrix[rowIndex][bombCoordinatesCol] == 'K')
                    {
                        field.Matrix[rowIndex][bombCoordinatesCol] = ' ';
                    }
                    else if (field.Matrix[rowIndex][bombCoordinatesCol] == 'B')
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
                    if (field.Matrix[bombCoordinatesRow][colIndex] == '*')
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = ' ';
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == '#')
                    {
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == 'P' || field.Matrix[bombCoordinatesRow][colIndex] == 'K')
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = ' ';
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == 'B')
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
                    if (field.Matrix[bombCoordinatesRow][colIndex] == '*')
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = ' ';
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == '#')
                    {
                        break;
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == 'P' || field.Matrix[bombCoordinatesRow][colIndex] == 'K')
                    {
                        field.Matrix[bombCoordinatesRow][colIndex] = ' ';
                    }
                    else if (field.Matrix[bombCoordinatesRow][colIndex] == 'B')
                    {
                        BombExplosion.Explosion(bombCoordinatesRow, colIndex);
                    }
                }
            }
            //field[bombCoordinatesRow][bombCoordinatesCol] = ' '; //-> NOT WORKING FOR SOME REASON
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
