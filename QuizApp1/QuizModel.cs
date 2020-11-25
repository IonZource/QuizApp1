using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuizApp1
{
    public abstract class checkAnswer : INotifyPropertyChanged
    {
        protected checkAnswer(string userAnswer)
        {
            UserAnswer = userAnswer;
            
        }

        public string UserAnswer { get; private set; }
        public string result = "test";
        
        //for implementing checkanswer
        //public abstract checkUserAnswer(bool);

        protected void NotifyChange(string answersubmitted)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(answersubmitted));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    //do comparison to check answer here. access database and compare the string to return true/false

    //pull questions and answer choices from database


    //increment question number and pass it on
    
}
