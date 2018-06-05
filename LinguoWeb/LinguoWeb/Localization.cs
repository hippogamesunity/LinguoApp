using System.Collections.Generic;

namespace LinguoWeb
{
	public static class Localization
	{
		public const string DefaultLanguage = "PL";
		public static string Language;
		
		private static readonly Dictionary<string, Dictionary<string, string>> Dictionary = new Dictionary<string, Dictionary<string, string>>
		{
			{
				"PL", new Dictionary<string, string>
				{
					{ "Latin", "Łacina" },
					{ "Cyrillic", "Цырылица" },
					{ "Translate", "Przetłumacz" },
					{ "TranslateBack", "Претлумачь" }
				}
			},
			{
				"CZ", new Dictionary<string, string>
				{
					{ "Latin", "Latina" },
					{ "Cyrillic", "Цырилице" },
					{ "Translate", "Přeložit" },
					{ "TranslateBack", "Преложит" }
				}
			}
		};

		public static string Localize(string key)
		{
			if (string.IsNullOrEmpty(Language) || !Dictionary.ContainsKey(Language))
			{
				Language = DefaultLanguage;
			}

			return Dictionary[Language][key];
		}
	}
}