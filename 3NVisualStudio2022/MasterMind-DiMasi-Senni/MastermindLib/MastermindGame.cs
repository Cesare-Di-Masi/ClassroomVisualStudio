namespace MastermindLib
{
    public class GameManager
    {
        private int _codeComplexity;
        private int _codeLength;
        private int _codeSolution;
        private int _nAttempts;
        private int _nColours;
        private int _isBotOn;

        public GameManager()
        {
            throw new System.NotImplementedException();
        }

        public int NAttempts
        {
            get => default;
        }

        public int CodeLength
        {
            get => default;
        }

        public int NColours
        {
            get => default;
        }

        public int CodeComplexity
        {
            get => default;
        }

        public Colours[] CodeSolution
        {
            get => default;
        }

        public bool IsColorBlindness
        {
            get => default;
        }

        public Colours Colours
        {
            get => default;
        }

        public int RightPosition
        {
            get => default;
            set
            {
            }
        }

        public int WrongPosition
        {
            get => default;
            set
            {
            }
        }

        public int IsAllWrong
        {
            get => default;
            set
            {
            }
        }

        public CodeGenerator CodeGenerator
        {
            get => default;
            set
            {
            }
        }

        public void ChangeColour()
        {
            throw new System.NotImplementedException();
        }

        public void TryToSolve()
        {
            throw new System.NotImplementedException();
        }

        public void GiveColourCode()
        {
            throw new System.NotImplementedException();
        }

        public void GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}