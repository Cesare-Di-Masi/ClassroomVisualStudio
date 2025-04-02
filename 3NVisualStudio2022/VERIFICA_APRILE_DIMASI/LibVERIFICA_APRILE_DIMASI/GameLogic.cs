namespace LibVERIFICA_APRILE_DIMASI
{
    public class GameLogic
    {
        private int _gridSize;

        private bool[,] _gameGrid;

        public int GridSize 
        {
            get { return _gridSize; }
            private set
            { 
                if(value<1)
                {
                    throw new ArgumentOutOfRangeException("illegal gridSize");
                }
                _gridSize = value;
            }
        }

        public bool[,] GameGrid
            { get { return _gameGrid; } }

        public GameLogic(int gridSize,IGenerator generator = null)//Igenerator è necessario per eseguire i test del codice
        {
            GridSize = gridSize;

            _gameGrid = new bool[gridSize,gridSize];

            if (generator == null)
            {
                Generator generator1 = new Generator();
                generator1.hideTreasure(_gameGrid);//hideTrasure posiziona il tesoro nella matrice
            }else
            {
                generator.hideTreasure(_gameGrid);
            }

        }

    }
}
