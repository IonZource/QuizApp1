using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace QuizApp1
{
    public class QuizViewModel:INotifyPropertyChanged
    {
        private IQuizInput q_inputs;
        public QuizViewModel(IQuizInput inputs)
        {
            q_inputs = inputs;
            q_inputs.PropertyChanged += new PropertyChangedEventHandler(q_inputs_PropertyChanged);
            

        }

        void q_inputs_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AnswerSubmitted":
                    DoSolve();
                    break;

            }
        }
        private void DoSolve()
        {
            ErrorMessage = string.Empty;
            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    //Filler for error message
                    ErrorMessage = string.Empty;
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message + " " + ex.InnerException;
                }
            }

            NotifyChange("OperationComplete");
        }

        public string ErrorMessage { get; private set; }
        private void NotifyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string result { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
