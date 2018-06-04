using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoApp
{
	public static class TranslatorLatinCyrillicCZ
	{
		private const string LatinConsonants = "AaÁáEeÉéĚěOoÓóUuÚúŮůYyÝýIiÍí";
		private const string LatinVowels = "BbCcČčChchDdĎďFfGgHhKkLlMmNnŇňPpQqRrŘřSsŠšTtŤťVvWwŽž";

		private static Dictionary<string, string> RegexReplace = new Dictionary<string, string>
		{
            { "[V]E", "Е" }, { "[V]e", "е" },                   
        };

		private static Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{
			{ "Št", "Щ" }, { "št", "щ" },
            { "Ky", "Ки" }, { "ky", "ки" },
            { "Ký", "Ки́" }, { "ký", "ки́" },
            { "Hy", "Ги" }, { "hy", "ги" },
            { "Hý", "Ги́" }, { "hý", "ги́" },
            { "Ja", "Я" }, { "ja", "я" },
            { "Já", "Я́" }, { "já", "я́" },
            { "Je", "Е" }, { "je", "е" },
            { "Jé", "É" }, { "jé", "é" },
            { "Jo", "Ё" }, { "jo", "ё" },
            { "Jó", "È" }, { "jó", "è" },
            { "Ju", "Ю" }, { "ju", "ю" },
            { "Jú", "Ю́" }, { "jú", "ю́" },
            { "Ji", "Ї" }, { "ji", "ї" },
            { "Jí", "Ì" }, { "jí", "ì" },
            { "A", "а" }, { "a", "а" },
            { "Á", "Á" }, { "á", "á" },
            { "B", "Б" }, { "b", "б" },
            { "C", "Ц" }, { "c", "ц" },
            { "Č", "Ч" }, { "č", "ч" },
            { "D", "Д" }, { "d", "д" },
            { "Ď", "Дь" }, { "ď", "дь" },
            { "E", "Э" }, { "e", "э" },
            { "É", "Э́" }, { "é", "э́" },
            { "Ě", "Ѣ" }, { "ě", "ѣ" },
            { "F", "Ф" }, { "f", "ф" },
            { "G", "Ґ" }, { "g", "ґ" },
            { "H", "Г" }, { "h", "г" },
            { "I", "И" }, { "i", "и" },
            { "Í", "И́" }, { "í", "и́" },
            { "J", "Й" }, { "j", "й" },
            { "K", "К" }, { "k", "к" },
            { "L", "Л" }, { "l", "л" },
            { "M", "М" }, { "m", "м" },
            { "N", "Н" }, { "n", "н" },
            { "Ň", "Нь" }, { "ň", "нь" },
            { "O", "О" }, { "o", "о" },
            { "Ó", "Ó" }, { "ó", "ó" },
            { "P", "П" }, { "p", "п" },
            { "Q", "Кв" }, { "q", "кв" },
            { "R", "Р" }, { "r", "р" },
            { "Ř", "Рь" }, { "ř", "рь" },
            { "S", "С" }, { "s", "с" },
            { "Š", "Ш" }, { "š", "ш" },
            { "T", "Т" }, { "t", "т" },
            { "Ť", "Ть" }, { "ť", "ть" },
            { "U", "У" }, { "u", "у" },
            { "Ú", "У́" }, { "ú", "у́" },
            { "Ů", "Ŏ" }, { "ů", "ŏ" },
            { "V", "В" }, { "v", "в" },
            { "W", "В" }, { "w", "в" },
            { "X", "Кс" }, { "x", "кс" },
            { "Z", "З" }, { "z", "з" },
            { "Ž", "Ж" }, { "ž", "ж" },
            { "Y", "Ы" }, { "y", "ы" },
            { "Ý", "Ы́" }, { "ý", "ы́" },                        
        };

		public static string Translate(string input)
		{
			var result = input;

			result = ReplaceRomanNumbers(result);

			foreach (var entry in RegexReplace)
			{
				var pattern = entry.Key;

				pattern = pattern.Replace("[C]", string.Format("([{0}])", LatinConsonants));
				pattern = pattern.Replace("[^C]", string.Format("([^{0}])", LatinConsonants));
				pattern = pattern.Replace("[V]", string.Format("([{0}])", LatinVowels));
				pattern = pattern.Replace("[^V]", string.Format("([^{0}])", LatinVowels));

				foreach (Match match in Regex.Matches(result, pattern))
				{
					result = result.Replace(match.Groups[0].Value, match.Groups[1] + entry.Value);
				}
			}

			foreach (var entry in SimpleReplace)
			{
				result = result.Replace(entry.Key, entry.Value);
			}

			result = RestoreRomanNumbers(result);

			return result;
		}

		private static readonly Dictionary<int, string> Romans = new Dictionary<int, string>();

		private static string ReplaceRomanNumbers(string result)
		{
			foreach (Match match in Regex.Matches(result, @"([IÎVX]+)(\W+|$)"))
			{
				var hash = match.Groups[1].GetHashCode();

				if (!Romans.ContainsKey(hash)) Romans.Add(hash, match.Groups[1].Value);

				result = result.Replace(match.Groups[1].Value, "[#" + hash + "]");
			}

			return result;
		}

		private static string RestoreRomanNumbers(string result)
		{
			foreach (Match match in Regex.Matches(result, @"\[#(\d+)\]"))
			{
				result = result.Replace(match.Groups[0].Value, Romans[int.Parse(match.Groups[1].Value)]);
			}

			return result;
		}
	}
}