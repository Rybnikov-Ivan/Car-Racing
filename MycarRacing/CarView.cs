using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace MycarRacing
{
    public partial class CarView : Form
    {
        #region Fields

        private int col;

        private int elementSize;
        private int[,] gameMatrix;
        private int row;
        //the start point of board
        private int startX;
        private int startY;
        //the position of car in time
        private int carX;
        private int carY;

        private Random random;
        private int myCarPosition;

        private int LeftWallX;
        private int LeftWallY;

        private int RightWallX;
        private int RightWallY;

        private int MyScore;
        private int HighScore;
        #endregion

        public CarView()
        {
            InitializeComponent();
            InitializeGame();
            game.Play();
        }

        private void InitializeGame()
        {           
            row = 20;
            col = 10;
            startX = 50;
            startY = 50;
            elementSize = 15;

            carX = carY = 2;
            gameMatrix = new int[row, col];
            ResetGameBoard();

            random = new Random();
            myCarPosition = 2;

            LeftWallX = 1;
            LeftWallY = 0;

            RightWallX = 1;
            RightWallY = 9;

            MyScore = 0;
            HighScore = 0;
        }

        private void CarView_Paint(object sender, PaintEventArgs e)
        {
            DrawGameBoard(e.Graphics);
        }

        SoundPlayer game = new SoundPlayer(@"C:\Users\пк\Desktop\Music\МузыкаИгры.wav");

        SoundPlayer crash = new SoundPlayer(@"C:\Users\пк\Desktop\Music\МузыкаСтолкновения.wav");

        private void DrawGameBoard(Graphics g)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    g.DrawRectangle(new Pen(Brushes.Black), startX + j * elementSize,
                                    startY + i * elementSize, elementSize, elementSize);
                    if (gameMatrix[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.Gray, startX + j * elementSize,
                                        startY + i * elementSize, elementSize, elementSize);
                    }
                    if (gameMatrix[i, j] == 2)
                    {
                        g.FillRectangle(Brushes.Gray, startX + j * elementSize,
                                        startY + i * elementSize, elementSize, elementSize);
                    }
                }
            }
        }

        #region Functions

        private void ResetGameBoard()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    gameMatrix[i, j] = 0;
                }
            }
        }

        private void DrawACar(int x, int y, int value)
        {
            DrawAPoint(x, y + 1, value);
            DrawAPoint(x + 1, y + 1, value);
            DrawAPoint(x + 2, y + 1, value);
            DrawAPoint(x + 1, y, value);
            DrawAPoint(x + 1, y + 2, value);
            DrawAPoint(x + 3, y, value);
            DrawAPoint(x + 3, y + 2, value);
        }

        private void DrawABarrier(int x, int y, int value)
        {
            DrawAPoint(x, y, value);
            DrawAPoint(x + 2, y, value);
            DrawAPoint(x + 1, y + 1, value);
            DrawAPoint(x + 2, y + 1, value);
            DrawAPoint(x + 3, y + 1, value);
            DrawAPoint(x, y + 2, value);
            DrawAPoint(x + 2, y + 2, value);
        }
        
        private void DrawLeftWall(int x, int y, int value)
        {
            for (int k = 0; k < row; k++)                
            {
                DrawAPoint(x, y, value);
                x++;
                if (x % 4 == 0)
                {
                    x++;
                }
            }
        }
        private void DrawRightWall(int x, int y, int value)
        {
            for (int t = 0; t < row; t++)
            {
                DrawAPoint(x, y, value);
                x++;
                if (x % 4 == 0)
                {
                    x++;
                }
            }
        }

        private void DrawAPoint(int x, int y, int value)
        {
            if (x < row && x >= 0 && y < col && y >= 0)
            {
                gameMatrix[x, y] = value;
            }
        }

        #endregion

        private void tmrRacing_Tick(object sender, EventArgs e)
        {
            ResetGameBoard();
            DrawACar(16, myCarPosition, 2);
            DrawABarrier(carX, carY, 2);
            DrawLeftWall(LeftWallX, LeftWallY, 2);
            DrawRightWall(RightWallX, RightWallY, 2);
            Invalidate();

            carX++;
            if (carX == row)
            {
                carX = 0;
                carY = random.Next() % 2 == 0 ? 2 : 5;
            }
            CheckGame();
            MyScore++;
            Score_txt.Text = "Score - " + MyScore;
        }

        private void CheckGame()
        {           
            if (carX + 3 > 16 && carY == myCarPosition)
            {
                crash.Play();
                tmrRacing.Enabled = false;
            }
        }

        private void CarView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && myCarPosition == 5)
            {
                myCarPosition = 2;
            }
            else if (e.KeyCode == Keys.Right && myCarPosition == 2)
            {
                myCarPosition = 5;
            }
        }

        private void CarView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carX = carY = 2;
            myCarPosition = 2;
            tmrRacing.Enabled = true;
            if (MyScore > HighScore)
            {
                HighScore = MyScore;
            }
            High_txt.Text = "HighScore - " + HighScore;
            MyScore = 0;
            game.Play();
        }

       

    }
}