using System;
using System.Web.UI;
using LinguoApp;

namespace LinguoWeb
{
	public partial class _Default : Page
	{
		protected void Button1_Click(object sender, EventArgs e)
		{
			switch (DropDownList1.SelectedIndex)
			{
				case 0:
					TextBox2.Text = TranslatorLatinCyrillicPL.Translate(TextBox1.Text);
					break;
				case 1:
					TextBox2.Text = TranslatorLatinCyrillicCZ.Translate(TextBox1.Text);
					break;
				default:
					TextBox2.Text = "Language is not supported.";
					break;
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			switch (DropDownList1.SelectedIndex)
			{
				case 0:
					TextBox2.Text = TranslatorCyrillicLatinPL.Translate(TextBox1.Text);
					break;
				case 1:
					TextBox2.Text = TranslatorCyrillicLatinCZ.Translate(TextBox1.Text);
					break;
				default:
					TextBox2.Text = "Language is not supported.";
					break;
			}
		}
	}
}