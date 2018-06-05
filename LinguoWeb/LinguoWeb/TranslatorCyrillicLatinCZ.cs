using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoApp
{
	public static class TranslatorCyrillicLatinCZ
	{
		private const string CyrillicConsonants = "АаÁáЕеЁёÉéÈèИиЇїОоÓóУуУ́у́ЫыЮюЭэЯяЯ́я́";
		private const string CyrillicVowels = "БбВвГгҐґЖжЗзКкМмНнПпСсФфХхЦцШшЩщТтДдЛлЧч";

		private static Dictionary<string, string> RegexReplace = new Dictionary<string, string>
		{
            { "[V]Е", "E" }, { "[V]е", "e" },
            { "[V]É", "É" }, { "[V]é", "é" },           
        };

		private static Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{
            { "Ки", "Ky" }, { "ky", "ки" },
            { "Ки́", "Ký" }, { "ký", "ки́" },
            { "Ги", "Hy" }, { "ги", "hy" },
            { "Ги", "Hи́" }, { "ги́", "hý" },
            { "Ря", "Řa" }, { "ря", "řa" },
            { "Ря́", "Řá" }, { "рѭ", "řá" },
            { "Ре", "Ře" }, { "ре", "ře" },
            { "Рé", "Řé" }, { "рé", "řé" },
            { "Рё", "Řo" }, { "рё", "řo" },
            { "Рè", "Řó" }, { "рè", "řó" },
            { "Рю", "Řu" }, { "рю", "řu" },
            { "Рю́", "Řú" }, { "рю́", "řú" },
            { "Ри", "Ři" }, { "ри", "ři" },
            { "Ри́", "Ří" }, { "ри́", "ří" },
            { "Дя", "Ďa" }, { "дя", "ďa" },
            { "Дя́", "Ďá" }, { "дя́", "ďá" },
            { "Де", "Ďe" }, { "де", "ďe" },
            { "Дé", "Ďé" }, { "дé", "ďé" },
            { "Дё", "Ďo" }, { "дё", "ďo" },
            { "Дè", "Ďó" }, { "дè", "ďó" },
            { "Дю", "Ďu" }, { "дю", "ďu" },
            { "Дю́", "Ďú" }, { "дю́", "ďú" },
            { "Тя", "Ťa" }, { "тя", "ťa" },
            { "Тя́", "Ťá" }, { "тя́", "ťá" },
            { "Те", "Ťe" }, { "те", "ťe" },
            { "Тé", "Ťé" }, { "тѩ", "ťé" },
            { "Тё", "Ťo" }, { "тё", "ťo" },
            { "Тé", "Ťó" }, { "тé", "ťó" },
            { "Тю", "Ťu" }, { "тю", "ťu" },
            { "Тю́", "Ťú" }, { "тю́", "ťú" },
            { "Ня", "Ňa" }, { "ňя", "na" },
            { "Ня́", "Ňá" }, { "ňя́", "ná" },
            { "Не", "Ňе" }, { "ňе", "ne" },
            { "Нé", "Ňé" }, { "ňé", "né" },
            { "Нё", "Ňo" }, { "ňё", "no" },
            { "Нé", "Ňó" }, { "ňé", "nó" },
            { "Ню", "Ňu" }, { "ňю", "nu" },
            { "Ню́", "Ňú" }, { "ňю́", "nú" },
            { "Рь", "Ř" }, { "рь", "ř" },
            { "Дь", "Ď" }, { "дь", "ď" },
            { "Ть", "Ť" }, { "ть", "м" },
            { "Нь", "Ň" }, { "нь", "ň" },
            { "Я", "Ja" }, { "я", "ja" },
            { "Я́", "Já" }, { "я́", "já" },
            { "Е", "Je" }, { "е", "je" },
            { "É", "Jé" }, { "é", "jé" },
            { "Ё", "Jo" }, { "ё", "jo" },
            { "È", "Jó" }, { "è", "jó" },
            { "Ю", "Ju" }, { "ю", "ju" },
            { "Ю́", "Jú" }, { "ю́", "jú" },
            { "Ї", "Ji" }, { "ї", "ji" },
            { "Ì", "Jí" }, { "ì", "jí" },
            { "Щ", "Št" }, { "щ", "št" },
            { "Ш", "Š" }, { "ш", "š" },
            { "Ч", "Č" }, { "ч", "č" },
            { "Х", "Ch" }, { "х", "ch" },
            { "А", "A" }, { "а", "a" },
            { "Á", "Á" }, { "á", "á" },
            { "Б", "B" }, { "б", "b" },
            { "Ц", "C" }, { "ц", "c" },
            { "Д", "D" }, { "д", "d" },
            { "Э", "E" }, { "э", "e" },
            { "É", "É" }, { "é", "é" },
            { "Ѣ", "Ě" }, { "ѣ", "ě" },
            { "Ф", "F" }, { "ф", "f" },
            { "Г", "H" }, { "г", "h" },
            { "Ґ", "G" }, { "ґ", "g" },
            { "Й", "J" }, { "й", "j" },
            { "К", "K" }, { "к", "k" },
            { "Л", "L" }, { "л", "l" },
            { "М", "M" }, { "м", "m" },
            { "Н", "N" }, { "н", "n" },
            { "О", "O" }, { "о", "o" },
            { "Ó", "Ó" }, { "ó", "ó" },
            { "П", "P" }, { "п", "p" },
            { "Р", "R" }, { "р", "r" },
            { "С", "S" }, { "с", "s" },
            { "Т", "T" }, { "т", "t" },
            { "У", "U" }, { "у", "u" },
            { "У́", "Ú" }, { "у́", "ú" },
            { "Ŏ", "Ů" }, { "ŏ", "ů" },
            { "В", "V" }, { "в", "v" },
            { "Ы", "Y" }, { "ы", "y" },
            { "Ы́", "Ý" }, { "ы́", "ý" },
            { "З", "Z" }, { "з", "z" },
            { "И", "I" }, { "и", "i" },
            { "И́", "Í" }, { "и́", "í" },
            { "Ж", "Ž" }, { "ж", "ž" },
            { "Ь", "" }, { "ь", "" },
			{ "Ъ", "" }, { "ъ", "" }
		};

		public static string Translate(string input)
		{
			var result = input;

			result = ReplaceRomanNumbers(result);

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