using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp1
{
    public partial class form1 : Form,IQuizInput
    {
        QuizViewModel q_viewModel;
        public form1()
        {
            InitializeComponent();
        }

        //load form here
        private void Form1_Load(object sender, EventArgs e)
        {
            q_viewModel = new QuizViewModel(this);
            q_viewModel.PropertyChanged += new PropertyChangedEventHandler(q_viewModel_PropertyChanged);
        }
        void q_viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AnswerSubmitted":
                    if (!(string.IsNullOrEmpty(q_viewModel.result)))
                    {
                        label1.Text = q_viewModel.result;
                    }
                    else
                    {
                        label1.Text = string.Empty;
                        MessageBox.Show(q_viewModel.ErrorMessage);
                    }
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //has autosize property
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("AnswerSubmitted"));
                //label1.Text = 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
