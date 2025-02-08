using MarksAndStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarksAndStudentLib
{
    public class PascalClass
    {
        private PascalStudent[] _studentList;

        PascalClass(PascalStudent[] studentsList) 
        {
            int nOfMarks = studentsList[0].Marks.Length;

            for (int i = 0; i < studentsList.Length; i++)
            {
                if (nOfMarks != studentsList[i].Marks.Length)
                    throw new ArgumentOutOfRangeException("the number of marks must be the same");
            }


            _studentList = studentsList;
        }

        public int NumberOfNotAdmittedStudents()
        {
            int counter = 0;

            for (int i = 0; i < _studentList.Length; i++)
            {
                if (_studentList[i].Scrutiny() == Result.NOTADMITTED)
                    counter++;
            }
            return counter;
        }

        public PascalStudent[] WhichStudentsNotAdmitted()
        {
            PascalStudent[] list = new PascalStudent[NumberOfNotAdmittedStudents()];
            int counter = 0;

            for(int i = 0;i < list.Length;i++)
            {
                if (_studentList[i].Scrutiny() == Result.NOTADMITTED)
                {
                    list[counter] = _studentList[i];
                    counter++;
                }
            }
            return list;

        }

        public int NumberOfAdmittedStudents()
        {
            int counter = 0;

            for (int i = 0; i < _studentList.Length; i++)
            {
                if (_studentList[i].Scrutiny() == Result.ADMITTED)
                    counter++;
            }
            return counter;
        }

        public PascalStudent[] WhichStudentsAdmitted()
        {
            PascalStudent[] list = new PascalStudent[NumberOfNotAdmittedStudents()];
            int counter = 0;

            for (int i = 0; i < list.Length; i++)
            {
                if (_studentList[i].Scrutiny() == Result.ADMITTED)
                {
                    list[counter] = _studentList[i];
                    counter++;
                }
            }
            return list;

        }
        public int NumberOfSuspendedStudents()
        {
            int counter = 0;

            for (int i = 0; i < _studentList.Length; i++)
            {
                if (_studentList[i].Scrutiny() == Result.SUSPENDED)
                    counter++;
            }
            return counter;
        }

        public PascalStudent[] WhichStudentsSuspended()
        {
            PascalStudent[] list = new PascalStudent[NumberOfNotAdmittedStudents()];
            int counter = 0;

            for (int i = 0; i < list.Length; i++)
            {
                if (_studentList[i].Scrutiny() == Result.SUSPENDED)
                {
                    list[counter] = _studentList[i];
                    counter++;
                }
            }
            return list;

        }

        public int ClassAverage()
        {
            int average = 0;

            for(int i = 0; i< _studentList.Length;i++)
            {
                average += _studentList[i].CalculateAverage();
            }
            return average;
        }

        public PascalStudent StudentWithLowestAverage()
        {
            PascalStudent studentWithLowestAv = _studentList[0];
            int lowestAv = studentWithLowestAv.CalculateAverage();
            int currentAv = 0;

            for (int i = 1; i < _studentList.Length; i++)
            {
                currentAv = _studentList[i].CalculateAverage();

                if (lowestAv > currentAv)
                {
                    studentWithLowestAv = _studentList[i];
                    lowestAv = currentAv;

                }else if(lowestAv == currentAv)
                {

                    if(String.Compare(studentWithLowestAv.Surname, _studentList[i].Surname) == 1)
                    {
                        studentWithLowestAv = _studentList[i];
                        lowestAv = currentAv;

                    }else if(String.Compare(studentWithLowestAv.Surname, _studentList[i].Surname) == 0)
                    {

                        if(String.Compare(studentWithLowestAv.Name, _studentList[i].Name) == 1)
                        {
                            studentWithLowestAv = _studentList[i];
                            lowestAv = currentAv;
                        }

                    }

                }

            }

            return studentWithLowestAv;

        }

        public PascalStudent StudentWithHighestAverage()
        {
            PascalStudent studentWithHighestAv = _studentList[0];
            int highestAv = studentWithHighestAv.CalculateAverage();
            int currentAv = 0;

            for (int i = 1; i < _studentList.Length; i++)
            {
                currentAv = _studentList[i].CalculateAverage();

                if (highestAv < currentAv)
                {
                    studentWithHighestAv = _studentList[i];
                    highestAv = currentAv;

                }
                else if (highestAv == currentAv)
                {

                    if (String.Compare(studentWithHighestAv.Surname, _studentList[i].Surname) == 1)
                    {
                        studentWithHighestAv = _studentList[i];
                        highestAv = currentAv;

                    }
                    else if (String.Compare(studentWithHighestAv.Surname, _studentList[i].Surname) == 0)
                    {

                        if (String.Compare(studentWithHighestAv.Name, _studentList[i].Name) == 1)
                        {
                            studentWithHighestAv = _studentList[i];
                            highestAv = currentAv;
                        }

                    }

                }

            }

            return studentWithHighestAv;

        }

        public int StudentsWithADeterminatedAverage(int wantedAverage)
        {
            if (wantedAverage < 1 || wantedAverage > 10)
                throw new ArgumentOutOfRangeException("illegal requested average");

            int counter = 0;

            for (int i = 0; i < _studentList.Length; i++)
            {
                if (_studentList[i].CalculateAverage() == wantedAverage)
                    counter ++;
            }
            return counter;

        }


        public PascalStudent BestStudentOfASubject(int wantedMark)
        {
            int max = 0;

            for(int i = 0; i < _studentList.Length; i++)
            {
                if (max < _studentList[i].GetMark(wantedMark - 1))
                    max = i;

            }
            return _studentList[max];
        }

    }
}
