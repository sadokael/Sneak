using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sneak
{
    public partial class SneakGame : Form
    {
       

        private List<Circle> Snake = new List<Circle>();//new array
        private Circle dot = new Circle();//single dot da class head 

        public SneakGame()
        {
            InitializeComponent();
            new Options();
            timer1.Interval = 1000 / Options.Speed;        
            timer1.Tick += updateGame;
            timer1.Start();
            StartGame();
        }

        private void updateGame(object sender, EventArgs e)
        {
         
                if (Options.Gameover == true)
                {
                    //se o gameover == true e o user carrega enter, corre o startgame again
                    if (Input.keyPress(Keys.Enter))
                    {
                        StartGame();
                    }
                }
                else
                {
                    if (Input.keyPress(Keys.Left) && Options.direction != Directions.Rigth)
                    { Options.direction = Directions.Left; }
                    if (Input.keyPress(Keys.Right) && Options.direction != Directions.Left)
                    { Options.direction = Directions.Rigth; }
                    if (Input.keyPress(Keys.Up) && Options.direction != Directions.Down)
                    { Options.direction = Directions.Up; }
                    if (Input.keyPress(Keys.Down) && Options.direction != Directions.Up)
                    { Options.direction = Directions.Down; }

                    MovePlayer(); //Mexe na direction set
                }

                PB_Canvas.Invalidate();
            
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            //Este evento dá trigger a false ao changeState da classe Input
            Input.changeState(e.KeyCode, false);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            //Este evento dá trigger a true ao changeState da classe Input
            Input.changeState(e.KeyCode, true);
        }

        private void UpdateGramphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics; //nova gramphics class

            if(Options.Gameover == false)
            {
                Brush snakeColour; 

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0) //head
                    { snakeColour = Brushes.DarkGreen; }
                    else
                    { snakeColour = Brushes.Green; }

                    //************parte de draw**************
                    //Snake:
                    canvas.FillEllipse(snakeColour,
                                       new Rectangle(
                                           Snake[i].X * Options.Width,      //tamanho
                                           Snake[i].Y * Options.Height,     //tamanho   
                                           Options.Width, Options.Height)   //start pos
                                       );
                    //dots:
                    canvas.FillEllipse(Brushes.Black,
                                       new Rectangle(
                                           dot.X * Options.Width,
                                           dot.Y * Options.Height,
                                           Options.Width, Options.Height)
                                       );

                }
            }
            else
            {
                //se gameover == true mostra a label de gameover
                string gameOver = "Game over! \n" + "Final score: " + Options.Score + "\n Press Enter to Restart \n";
                EndGame.Text = gameOver;
                EndGame.Visible = true;
            }
        }

        private void StartGame() 
        {
            EndGame.Visible = false; //esconde a label de Gameover
            new Options();
            Snake.Clear(); //limpa a array
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); //primeiro elem da array

            L_score.Text = Options.Score.ToString(); //passa string com score á label

            generateDots();
        }

        private void MovePlayer()
        {
            //main loop
            for (int i = Snake.Count -1; i>=0; i--)
            {
                if (i == 0)
                {
                    switch (Options.direction)
                    {
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Rigth:
                            Snake[i].X++;
                            break;
                    }
                    //limites:
                    int MaxX = PB_Canvas.Size.Width / Options.Width;
                    int MaxY = PB_Canvas.Size.Height / Options.Height;

                    if(Snake[i].X < 0 || Snake[i].Y <0 || Snake[i].X > MaxX || Snake[i].Y > MaxY)
                    { end(); } //gameover se snake tocar nas bordas

                    //colisão com outros elementos da array
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        { end(); } //gameover se houver colisão
                    }

                    //colisão com dots ________ cabeça == Snake[0] (primeiro elem)
                    if (Snake[0].X == dot.X && Snake[0].Y == dot.Y)
                    { eat(); } //adiciona elem á array
                }
                else //depois de validar movimento da head
                {
                    Snake[i].X = Snake[i - 1].X;//assume pos do anterior
                    Snake[i].Y = Snake[i - 1].Y;//idem
                }

            }
        }

        private void generateDots()
        {
            int maxX = PB_Canvas.Size.Width / Options.Width;
            int maxY = PB_Canvas.Size.Height / Options.Height;
            Random rnd = new Random();
            dot = new Circle { X = rnd.Next(0, maxX), Y = rnd.Next(0, maxY) }; //nova dot em x/y random
        }
        private void eat()
        {
            Circle body = new Circle { X = Snake[Snake.Count - 1].X, Y = Snake[Snake.Count - 1].Y };
            Snake.Add(body);
            Options.Score += Options.Points;
            L_score.Text = Options.Score.ToString();
            generateDots();
        }
        private void end()
        {
            Options.Gameover = true;
        }

        

    }
}
