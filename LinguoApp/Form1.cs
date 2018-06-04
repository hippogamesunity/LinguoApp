using System;
using System.Windows.Forms;

namespace LinguoApp
{
	public partial class Form1 : Form
	{
		private int _direction;

		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Translate();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as RadioButton).Checked)
			{
				_direction = 0;
			}

			Translate();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as RadioButton).Checked)
			{
				_direction = 1;
			}

			Translate();
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as RadioButton).Checked)
			{
				_direction = 2;
			}

			Translate();
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as RadioButton).Checked)
			{
				_direction = 3;
			}

			Translate();
		}

		private void Translate()
		{
			switch (_direction)
			{
				case 0:
					textBox2.Text = TranslatorLatinCyrillicPL.Translate(textBox1.Text);
					break;
				case 1:
					textBox2.Text = TranslatorCyrillicLatinPL.Translate(textBox1.Text);
					break;
				case 2:
					textBox2.Text = TranslatorLatinCyrillicCZ.Translate(textBox1.Text);
					break;
				case 3:
					textBox2.Text = TranslatorCyrillicLatinCZ.Translate(textBox1.Text);
					break;
				default:
					throw new NotImplementedException();
			}
		}
	}
}