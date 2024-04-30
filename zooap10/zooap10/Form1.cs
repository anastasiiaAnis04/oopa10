using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zooap10;
using Label = System.Windows.Forms.Label;

namespace zooap10
{
    public partial class Form1 : Form
    {
        public class ConcreteObserver : Observer
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

            public void CheckBox_CheckedChanged(object sender, EventArgs e)
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
        public Form1()
        {
            InitializeComponent();

            var subject = new ConcreteSubject();

            var observer1 = new ConcreteObserver(subject, checkBox1, label1, label3);
            var observer2 = new ConcreteObserver(subject, checkBox2, label2, label3);

            subject.State = 0;
            checkBox1.Checked = true;
        }

    }
        
 
public class ConcreteSubject : Subject
{
    private int state;

    public int State
    {
        get { return state; }
        set
        {
            state = value;
            Notify();
        }
    }
}

    public interface Observer
    {
        void Update();
    }
    public abstract class Subject
{
    List<Observer> observers;

    public Subject()
    {
        observers = new List<Observer>();
    }

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }
    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }
    public void Notify()
    {
        foreach (Observer o in observers)
        {
            o.Update();
        }
    }
}
}

