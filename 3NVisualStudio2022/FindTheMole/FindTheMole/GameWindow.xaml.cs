using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FindTheMole_Lib;

namespace FindTheMole
{
    /// <summary>
    /// Logica di interazione per GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        private int _gameSize;
        private int _nAttempts;
        private Game currGame;
        bool[,] _gameMatrix;

        private int solX, solY;

        public GameWindow(int gameSize, int nAttempts)
        {
            InitializeComponent();
            _gameSize = gameSize;
            _nAttempts = nAttempts;

            currGame = new Game(_gameSize, _nAttempts);
            _gameMatrix = currGame.GameMatrix;

            for (int i = 0; i < _nAttempts; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50+50)});
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50+50)});
            }

            for(int i = 0; i < _gameSize; i++)
            {
                for (int j = 0; j < _gameSize; j++)
                {
                    Button button = new Button();
                    
                    var tuple = Tuple.Create(i, j);

                    button.Click += MakeATry;
                    button.Tag = tuple;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    GameGrid.Children.Add(button);

                    if(_gameMatrix[i, j])
                    {
                        solX = i;
                        solY = j;
                    }
                    

                }
            }

            
            

        }


        public void MakeATry(object sender, EventArgs eventArgs)
        {
            if(sender is Button)
            {
                Button button = sender as Button;

                var tuple = (Tuple<int,int>)button.Tag;
                
                if(tuple.Item1 == solX && tuple.Item2 == solY)
                {
                    button.Background = Brushes.Green;
                    MessageBox.Show("You won!");
                }
                else
                {
                    button.Background = Brushes.Red;
                    currGame.NAttempt--;
                    if (currGame.NAttempt == 1)
                    {
                        MessageBox.Show("You lost!");
                    }
                    else
                    {
                        MessageBox.Show($"You have {currGame.NAttempt} attempts left");
                    }
                }

                _nAttempts--;
            }
        }

        private void endGame()
        {
            var a = new MainWindow();
            a.Show();
            this.Close();
        }
        

    }
}
