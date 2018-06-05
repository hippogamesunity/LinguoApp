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
			switch (Localization.Language)
			{
				case "PL":
					TextBoxResult.Text = TranslatorLatinCyrillicPL.Translate(TextBoxInput.Text);
					break;
				case "CZ":
					TextBoxResult.Text = TranslatorLatinCyrillicCZ.Translate(TextBoxInput.Text);
					break;
				default:
					TextBoxResult.Text = "Language is not supported: " + Localization.Language;
					break;
			}
		}

		protected void TranslateBack(object sender, EventArgs e)
		{
			switch (Localization.Language)
			{
				case "PL":
					TextBoxInput.Text = TranslatorCyrillicLatinPL.Translate(TextBoxResult.Text);
					break;
				case "CZ":
					TextBoxInput.Text = TranslatorCyrillicLatinCZ.Translate(TextBoxResult.Text);
					break;
				default:
					TextBoxInput.Text = "Language is not supported: " + Localization.Language;
					break;
			}
		}
    }
}