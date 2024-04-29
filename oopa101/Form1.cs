namespace oopa101
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var subject = new ConcreteSubject();

            var observer1 = new ConcreteObserver(subject, checkBox1, label1, label3);
            var observer2 = new ConcreteObserver(subject, checkBox2, label2, label3);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}