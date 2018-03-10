using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoApp
{
	public static class TranslatorCyrillicPolish
	{
		private const string CyrillichAlphabet = "";
		private const string CyrillicConsonants = "";
		private const string CyrillicVowels = "";

		private static Dictionary<string, string> RegexReplace = new Dictionary<string, string>
		{         
        };

		private static Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{           
        };

		public static string Translate(string input)
		{
			var result = input;

			foreach (var entry in RegexReplace)
			{
				var pattern = entry.Key;

				pattern = pattern.Replace("[C]", string.Format("([{0}])", CyrillicConsonants));
				pattern = pattern.Replace("[^C]", string.Format("([^{0}])", CyrillicConsonants));
				pattern = pattern.Replace("[V]", string.Format("([{0}])", CyrillicVowels));
				pattern = pattern.Replace("[^V]", string.Format("([^{0}])", CyrillicVowels));

				foreach (Match match in Regex.Matches(result, pattern))
				{
					result = result.Replace(match.Groups[0].Value, match.Groups[1] + entry.Value);
				}
			}

			foreach (var entry in SimpleReplace)
			{
				result = result.Replace(entry.Key, entry.Value);
			}

			return result;
		}
	}
}