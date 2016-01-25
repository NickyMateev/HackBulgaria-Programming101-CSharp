using System.ComponentModel;

namespace StudentClass
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; private set; }
        public int FacultyNumber { get; private set; }
        public int NumberOfExamsLeft { get; private set; }

        public Student(string name, int facultyNumber, int numberOfExamsLeft)
        {
            Name = name;
            FacultyNumber = facultyNumber;
            NumberOfExamsLeft = numberOfExamsLeft;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
        }

        public void ChangeFacultyNumber(int newFacultyNumber)
        {
            FacultyNumber = newFacultyNumber;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Faculty number"));
        }

        public void ChangeNumberOfExamsLeft(int newNumberOfExams)
        {
            NumberOfExamsLeft = newNumberOfExams;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Number of exams left"));
        }

    }
}