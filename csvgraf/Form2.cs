using System;
using System.Windows.Forms;

namespace csvgraf
{
    public partial class Form2 : Form
    {
        string[] options;
        public Form2()
        {
            InitializeComponent();
            options = Variables.getOptions();
        }

        //internal Options options
        private void saveoptions(object sender, EventArgs e)
        {
            options[1] = textBox1.Text;
            Hide();
        }


        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Variables.setOptions(options);
            textBox1.Text=options[1];
            Hide();
        }
    }
}
