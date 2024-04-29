using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopa101
{
    //ConcreteObserver- concrete Observer implementations. 
    
    class ConcreteObserver : Observer
    {
        private readonly ConcreteSubject subject;
        private readonly CheckBox checkBox;
        private readonly Label label;
        private static int countInState;
        private readonly Label countLabel;



        public ConcreteObserver(ConcreteSubject subject, CheckBox checkBox, Label label, Label countLabel)
        {
            this.subject = subject;
            this.checkBox = checkBox;
            this.label = label;
            this.countLabel = countLabel;
            this.checkBox.CheckedChanged += CheckBox_CheckedChanged;
        }
        public int CountInState
        {
            get { return countInState; }
        }
        public void Update()
        {
            if (checkBox.Checked)
            {
                label.Text = $"State: {subject.State}";
                if (subject.State == 0)
                {
                    countInState++; 
                }

                countLabel.Text = "Количество State 0: " + countInState.ToString();
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox.Checked)
            {
                Update();
            }
            else
            {
                if (subject.State == 0)
                {
                    label.Text = "";
                    countInState--;
                    countLabel.Text = "Количество State 0: " + countInState.ToString();
                }
            }
        }
    }
 }
