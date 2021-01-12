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
                    if (Input.keyPress(Keys.Left) && Options.direction != Directions.Right)
                    { Options.direction = Directions.Left; }
                    if (Input.keyPress(Keys.Right) && Options.direction != Directions.Left)
                    { Options.direction = Directions.Right; }
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
                canvas.FillEllipse(Brushes.Black,
                                       new Rectangle(
                                           dot.X * Options.Width,
                                           dot.Y * Options.Height,
                                           Options.Width, Options.Height)
                                       );
                
                canvas.FillEllipse(Brushes.DarkGreen,
                                               new Rectangle(
                                               Snake.head.body.X * Options.Width,      //tamanho
                                               Snake.head.body.Y * Options.Height,     //tamanho   
                                               Options.Width, Options.Height)   //start pos
                                                              );

                 
                
                
                Node temp = Snake.head.next;
                do
                {
                    if (temp == null)
                    {
                        break;
                    }
                    canvas.FillEllipse(Brushes.Green,
                                          new Rectangle(
                                          temp.body.X * Options.Width,      //tamanho
                                          temp.body.Y * Options.Height,     //tamanho   
                                          Options.Width, Options.Height)   //start pos
                                          );
                        
                    temp = temp.next;


                } while (1 == 1);
                
               


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
            Snake.head.next = null; //limpa a LList
            Snake.head.body.X = 10; //primeiro elem da lista
            Snake.head.body.Y = 5;
            AddNode(Snake.head.body.X, Snake.head.body.Y); //no idea, mas assim corre, so...


            L_score.Text = Options.Score.ToString(); //passa string com score á label

            generateDots();
        }

        private void MovePlayer()
        {                  
                switch (Options.direction)
                {
                    case Directions.Down:
                        Snake.head.body.Y++;
                        break;
                    case Directions.Up:
                        Snake.head.body.Y--; 
                        break;
                    case Directions.Left:
                        Snake.head.body.X--;
                        break;
                    case Directions.Right:
                        Snake.head.body.X++;
                        break;
                }
                //limites:
                int MaxX = PB_Canvas.Size.Width / Options.Width;
                int MaxY = PB_Canvas.Size.Height / Options.Height;

                if (Snake.head.body.X < 0 || Snake.head.body.Y < 0 || Snake.head.body.X > MaxX || Snake.head.body.Y > MaxY)
                { end(); } //gameover se snake tocar nas bordas



                //colisão com outros elementos da lista                           
                Node temp = Snake.head.next;
                while(temp == null); 
                {
                  
                    if (Snake.head.body.X == temp.body.X && Snake.head.body.Y == temp.body.Y)
                    { end(); } //gameover se houver colisão

                    temp = temp.next;

                } 
                


                //colisão com dots ________ cabeça == Snake[0] (primeiro elem)
                if (Snake.head.body.X == dot.X && Snake.head.body.Y == dot.Y)
                { eat(); } //adiciona elem á array





                temp = Snake.head.next;
                do
                {
                
                if (temp == null)
                {
                    
                    break;
                }
                else if (temp.next == null)
                {
                    //só deve correr 1x
                    temp.body.X = Snake.head.body.X;
                    temp.body.Y = Snake.head.body.Y;
                    break;
                }
                
                temp.body.X = temp.next.body.X;//assume pos do anterior
                temp.body.Y = temp.next.body.Y;//assume pos do anterior

                temp = temp.next;

                } while (1 == 1);
                                                         
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
           
            AddNode(Snake.head.body.X, Snake.head.body.Y);

            Options.Score += Options.Points;
            L_score.Text = Options.Score.ToString();
            generateDots();
        }
        private void end()
        {
            Options.Gameover = true;
        }

        public void AddNode(int x, int y)
        {
            Node newNode = new Node();
            newNode.body.X = x;
            newNode.body.Y = y;

            newNode.next = Snake.head;
            Snake.head = newNode;
        }


    }
}
