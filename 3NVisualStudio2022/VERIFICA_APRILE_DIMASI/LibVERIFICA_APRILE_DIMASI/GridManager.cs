using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibVERIFICA_APRILE_DIMASI
{
    public class GridManager
    {
        private bool[,] _gameGrid;
        private int _nAttempts;

        private GameState _gameStatus = GameState.PLAYING;//stato della partita

        public bool[,] GameGrid
            { get { return _gameGrid; } }

        public int NAttempts
            { get { return _nAttempts; } }


        public GameState GameStatus
            { get { return _gameStatus; } }

        public GridManager(bool[,] gameGrid, int nAttempts) 
        {
            if (nAttempts < 1)
                throw new ArgumentOutOfRangeException("illegal nAttempts");

            _gameGrid = gameGrid;
            _nAttempts = nAttempts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void makeATry(int x, int y)//i parametri sono le coordinate della matrice da controllare
        {

            if(x < 0 || y < 0) throw new ArgumentOutOfRangeException("illegal given coords");

            if (_gameGrid[x, y] == true)//se quella posizione è corretta lo stato della partita diventa WON
                _gameStatus = GameState.WON;
            else if (NAttempts > 1)//se il numero di tentativi è maggiore di 1, quindi posso fare alemno un altro tentativo continuo la partita
                _nAttempts--;
            else
                _gameStatus = GameState.LOST;//se termino i tentativi ho perso

        }


    }
}
