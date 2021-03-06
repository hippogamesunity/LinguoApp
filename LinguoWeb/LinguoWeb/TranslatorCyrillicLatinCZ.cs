﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoWeb
{
	public class TranslatorCyrillicLatinCZ : TranslatorBase
	{
		private const string CyrillicConsonants = "АаÁáЕеЁёÉéÈèИиЇїОоÓóУуУ́у́ЫыЮюЭэЯяЯ́я́";
		private const string CyrillicVowels = "БбВвГгҐґЖжЗзКкМмНнПпСсФфХхЦцШшЩщТтДдЛлЧч";

		private static readonly Dictionary<string, string> RegexReplace = new Dictionary<string, string>
		{
            { "[V]Е", "E" }, { "[V]е", "e" },
            { "[V]É", "É" }, { "[V]é", "é" },           
        };

		private static readonly Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{
            { "Кс" + InvisibleChars.A, "X" }, { "кс" + InvisibleChars.A, "x" },
            { "Кв" + InvisibleChars.A, "Q" }, { "кв" + InvisibleChars.A, "q" },
            { "В" + InvisibleChars.A, "W" }, { "w" + InvisibleChars.A, "w" },
            { "Рі", "Ri" }, { "рі", "ri" },
            { "Рí", "Rí" }, { "рí", "rí" },
            { "Ки", "Ky" }, { "ки", "ky" },
            { "Ки́", "Ký" }, { "ки́", "ký" },
            { "Ги", "Hy" }, { "ги", "hy" },
            { "Ги́", "Hи́" }, { "ги́", "hý" },
            { "Ря", "Řa" }, { "ря", "řa" },
            { "Ря́", "Řá" }, { "ря́", "řá" },
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
            { "Тé", "Ťé" }, { "тé", "ťé" },
            { "Тё", "Ťo" }, { "тё", "ťo" },
            { "Тè", "Ťó" }, { "тè", "ťó" },
            { "Тю", "Ťu" }, { "тю", "ťu" },
            { "Тю́", "Ťú" }, { "тю́", "ťú" },
            { "Ня", "Ňa" }, { "ня", "ňa" },
            { "Ня́", "Ňá" }, { "ня́", "ňá" },
            { "Не", "Ňе" }, { "не", "ňe" },
            { "Нé", "Ňé" }, { "нé", "ňé" },
            { "Нё", "Ňo" }, { "нё", "ňo" },
            { "Нè", "Ňó" }, { "нè", "ňó" },
            { "Ню", "Ňu" }, { "ню", "ňu" },
            { "Ню́", "Ňú" }, { "ню́", "ňú" },
            { "Рь", "Ř" }, { "рь", "ř" },
            { "Дь", "Ď" }, { "дь", "ď" },
            { "Ть", "Ť" }, { "ть", "ť" },
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

			//result = ReplaceRomanNumbers(result);

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

			//result = RestoreRomanNumbers(result);

			return result;
		}
	}
}