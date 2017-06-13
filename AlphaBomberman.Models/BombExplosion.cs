namespace AlphaBomberman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BombExplosion
    {
        public static char[][] Explosion()  // was void initially
        {
            var field = LevelModels.DrawMatrix();
            var bombCoordinatesRow = Player.PlayerOneY;
            var bombCoordinatesCol = Player.PlayerOneX;
            var range = Bomb.Range();
            var timer = Bomb.Timer();
            // timer functionality will be added in the near future :D :D :D 

            //blow left
            for (int rowIndex = bombCoordinatesRow - range; rowIndex < bombCoordinatesRow; rowIndex++)
            {
                if (IsInMatrix(rowIndex, bombCoordinatesCol, field))
                {
                    if (field[rowIndex][bombCoordinatesCol] == '*')
                    {
                        field[rowIndex][bombCoordinatesCol] = ' ';
                    }
                    else if (field[rowIndex][bombCoordinatesCol] == '#')
                    {
                        break;
                    }
                    else if (field[rowIndex][bombCoordinatesCol] == 'P' || field[rowIndex][bombCoordinatesCol] == 'K')
                    {
                        field[rowIndex][bombCoordinatesCol] = ' ';
                    }
                }
            }
            //blow right
            for (int rowIndex = bombCoordinatesRow + 1; rowIndex <= bombCoordinatesRow + range; rowIndex++)
            {
                if (IsInMatrix(rowIndex,bombCoordinatesCol,field))
                {
                    if (field[rowIndex][bombCoordinatesCol] == '*')
                    {
                        field[rowIndex][bombCoordinatesCol] = ' ';
                    }
                    else if (field[rowIndex][bombCoordinatesCol] == '#')
                    {
                        break;
                    }
                    else if (field[rowIndex][bombCoordinatesCol] == 'P' || field[rowIndex][bombCoordinatesCol] == 'K')
                    {
                        field[rowIndex][bombCoordinatesCol] = ' ';
                    }
                }
            }
            //blow up
            for (int colIndex = bombCoordinatesCol - range; colIndex < bombCoordinatesCol; colIndex++)
            {
                if (IsInMatrix(bombCoordinatesRow,colIndex,field))
                {
                    if (field[bombCoordinatesRow][colIndex] == '*')
                    {
                        field[bombCoordinatesRow][colIndex] = ' ';
                    }
                    else if (field[bombCoordinatesRow][colIndex] == '#')
                    {
                        break;
                    }
                    else if (field[bombCoordinatesRow][colIndex] == 'P' || field[bombCoordinatesRow][colIndex] == 'K')
                    {
                        field[bombCoordinatesRow][colIndex] = ' ';
                    }
                }
            }
            //blow down
            for (int colIndex = bombCoordinatesCol + 1; colIndex < bombCoordinatesCol + range; colIndex++)
            {
                if (IsInMatrix(bombCoordinatesRow, colIndex, field))
                {
                    if (field[bombCoordinatesRow][colIndex] == '*')
                    {
                        field[bombCoordinatesRow][colIndex] = ' ';
                    }
                    else if (field[bombCoordinatesRow][colIndex] == '#')
                    {
                        break;
                    }
                    else if (field[bombCoordinatesRow][colIndex] == 'P' || field[bombCoordinatesRow][colIndex] == 'K')
                    {
                        field[bombCoordinatesRow][colIndex] = ' ';
                    }
                }
            }
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
