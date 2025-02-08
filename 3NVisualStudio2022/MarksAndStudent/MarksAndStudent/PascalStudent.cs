namespace MarksAndStudent
{
    public enum Result
    {
        ADMITTED,
        NOTADMITTED,
        SUSPENDED
    }
    public class PascalStudent
    {
        private string _name, _surname;

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if(String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("illegal name");
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("illegal surname");
                _surname = value;
            }
        }

        public int[] Marks
        {
            get; private set;
        }

        public bool isBiennium
        {
            get
            {
                return Marks.Length == 13;
            }
        }


        PascalStudent(string name, string surname, int[] marks) 
        {
            if(marks.Length != 10 || marks.Length != 13)
                throw new ArgumentOutOfRangeException("illegal number of marks");

            for(int i = 0; i < marks.Length; i++) 
            {
                if (marks[i] < 1 || marks[i] > 10)
                    throw new ArgumentOutOfRangeException($"illegal mark at position{i + 1}");
            }

            Name = name;
            Surname = surname;
            Marks = marks;

        }


        public void ModifyMark(int wantedMark, int markPosition)
        {
            if (wantedMark < 1 || wantedMark > 10)
                throw new ArgumentOutOfRangeException("illegal wantedMark");
            if((markPosition < 1 || (markPosition > 10 && isBiennium == true) || markPosition > 13))
                throw new ArgumentOutOfRangeException("illegal markPosition");

            Marks[markPosition-1] = wantedMark;

        }

        public int GetMark(int markPosition)
        {
            if ((markPosition < 1 || (markPosition > 10 && isBiennium == true) || markPosition > 13))
                throw new ArgumentOutOfRangeException("illegal markPosition");
            return Marks[markPosition-1];
        }

        public int CalculateAverage()
        {
            int average = 0;

            for(int i=0; i< Marks.Length; i++)
            {
                average += Marks[i];
            }

            return average/Marks.Length;

        }

        public int NumberOfInsufficiency()
        {
            int insufficiency = 0;

            for (int i = 0; i < Marks.Length; i++)
            {
                if (Marks[i] < 6)
                    insufficiency++;
            }
            return insufficiency;

        }

        public int PointToSufficiency()
        {
            int points = 0;

            for (int i = 0; i < Marks.Length; i++)
            {
                if (Marks[i] < 6)
                    points += 6 - Marks[i];
            }
            return points;

        }

        public Result Scrutiny()
        {
            int nInsufficiency = NumberOfInsufficiency();
            int nPoints = PointToSufficiency();

            if(nInsufficiency > 3 || (nPoints > 3 && !isBiennium) || nPoints > 4 )
            {
                return Result.NOTADMITTED;
            }else if(nPoints > 0)
            {
                return Result.SUSPENDED;
            }else
            {
                return Result.ADMITTED;
            }

        }


    }
}
