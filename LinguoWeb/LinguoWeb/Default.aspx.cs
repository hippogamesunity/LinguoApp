using System;
using System.Web.UI;
using LinguoApp;

namespace LinguoWeb
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var lang = Request["lang"];

			if (lang != null) Localization.Language = Request["lang"];

			TranslateButton.Text = Localization.Localize("Translate");
			TranslateBackButton.Text = Localization.Localize("TranslateBack");
		}
		
		protected void Translate(object sender, EventArgs e)
		{
			switch (DropDownList1.SelectedIndex)
			{
				case 0:
					TextBoxResult.Text = TranslatorLatinCyrillicPL.Translate(TextBoxInput.Text);
					break;
				case 1:
					TextBoxResult.Text = TranslatorLatinCyrillicCZ.Translate(TextBoxInput.Text);
					break;
				default:
					TextBoxResult.Text = "Language is not supported.";
					break;
			}
		}

		protected void TranslateBack(object sender, EventArgs e)
		{
			switch (DropDownList1.SelectedIndex)
			{
				case 0:
					TextBoxInput.Text = TranslatorCyrillicLatinPL.Translate(TextBoxResult.Text);
					break;
				case 1:
					TextBoxInput.Text = TranslatorCyrillicLatinCZ.Translate(TextBoxResult.Text);
					break;
				default:
					TextBoxInput.Text = "Language is not supported.";
					break;
			}
		}
    }
}