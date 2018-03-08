using System;
using System.Windows.Forms;

namespace LinguoApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			textBox2.Text = Transtator.Translate(textBox1.Text);
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}
}