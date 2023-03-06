using System.Data;

namespace Calculator_V2
{
    public partial class Form1 : Form
    {
        private string currentCalc = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            currentCalc += (sender as Button).Text;
            textBoxOutput.Text = currentCalc;
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {
            string formattedCalc = currentCalc.ToString().Replace("x", "*").ToString().Replace("÷", "/");

            try
            {
                textBoxOutput.Text = new DataTable().Compute(formattedCalc, null).ToString();
                currentCalc = textBoxOutput.Text;
            }
            catch(Exception ex)
            {
                textBoxOutput.Text = "0";
                currentCalc= "";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text= "";
            currentCalc = "";
        }

        private void button_ClearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalc.Length > 0)
            {
                currentCalc = currentCalc.Remove(currentCalc.Length - 1, 1);
            }

            textBoxOutput.Text = currentCalc;
        }
    }
}