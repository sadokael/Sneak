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
        private LList Snake = new LList();                
        private Circle dot = new Circle();

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
                Snake.getHead();

                canvas.FillEllipse(Brushes.Black,
                                       new Rectangle(
                                           dot.X * Options.Width,
                                           dot.Y * Options.Height,
                                           Options.Width, Options.Height)
                                       );
                
                canvas.FillEllipse(Brushes.DarkGreen,
                                               new Rectangle(
                                               (Snake.getX()) * Options.Width,      //tamanho
                                               (Snake.getY()) * Options.Height,     //tamanho   
                                               Options.Width, Options.Height)   //start pos
                                                              );


                do
                {
                    Snake.getBefore();

                    canvas.FillEllipse(Brushes.Green,
                                      new Rectangle(
                                          (Snake.getX()) * Options.Width,      //tamanho
                                          (Snake.getY()) * Options.Height,     //tamanho   
                                          Options.Width, Options.Height)   //start pos
                                      );
                } while (Snake.getBefore() != null);


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
            Snake.ClearList(); //limpa a array
            Snake.setX(10); //primeiro elem da array
            Snake.setY(5);
            

            L_score.Text = Options.Score.ToString(); //passa string com score á label

            generateDots();
        }

        private void MovePlayer()
        {
            Snake.getHead();

                    
                switch (Options.direction)
                {
                    case Directions.Down:
                        Snake.incY();
                        break;
                    case Directions.Up:
                        Snake.decY();
                        break;
                    case Directions.Left:
                        Snake.decX();
                        break;
                    case Directions.Rigth:
                        Snake.incX();
                        break;
                }
                //limites:
                int MaxX = PB_Canvas.Size.Width / Options.Width;
                int MaxY = PB_Canvas.Size.Height / Options.Height;

                if (Snake.getCurr().X < 0 || Snake.getY() < 0 || Snake.getX() > MaxX || Snake.getY() > MaxY)
                { end(); } //gameover se snake tocar nas bordas

                //colisão com outros elementos da array
                while (Snake.getBefore() != null)
                {
                    if (Snake.getCurr().X == Snake.getBefore().X && Snake.getCurr().Y == Snake.getBefore().Y)
                    { end(); } //gameover se houver colisão

                    Snake.getBefore();

                }

            Snake.getHead();

            //colisão com dots ________ cabeça == Snake[0] (primeiro elem)
            if (Snake.getCurr().X == dot.X && Snake.getCurr().Y == dot.Y)
                { eat(); } //adiciona elem á array



            if(Snake.getBefore() != null)
            {
                do
                {
                    Snake.getBefore().X = Snake.getCurr().X;//assume pos do anterior
                    Snake.getBefore().Y = Snake.getCurr().Y;//idem
                } while (Snake.getBefore() != null) ;

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
            
            Snake.AddNode();
            Snake.getCurr();
            Snake.setX(Snake.getNext().X);
            Snake.setY(Snake.getNext().Y);
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
