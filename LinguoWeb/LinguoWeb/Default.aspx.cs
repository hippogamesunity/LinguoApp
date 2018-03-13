using System;
using System.Web.UI;
using LinguoApp;

namespace LinguoWeb
{
	public partial class _Default : Page
	{
		protected void Button1_Click(object sender, EventArgs e)
		{
			TextBox2.Text = TranslatorLatinCyrillic.Translate(TextBox1.Text);
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			TextBox1.Text = TranslatorCyrillicLatin.Translate(TextBox2.Text);
		}
	}
}