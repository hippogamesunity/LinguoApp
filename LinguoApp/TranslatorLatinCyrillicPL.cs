﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoApp
{
	public static class TranslatorLatinCyrillicPL
	{
		private const string LatinConsonants = "AaĄąEeĘęOoÓóUuYyIi";
		private const string LatinVowels = "BbCcChchCzczĆćDdDźdźFfGgHhKkLlŁłMmNnŃńPpRrRzrzSsSzszŚśTtWwZzŹźŻż";

		private static Dictionary<string, string> RegexReplace = new Dictionary<string, string>
		{
            { "[V]JA", "ЪЯ" }, { "[V]ja", "ъя" },
            { "[V]JĄ", "ЪѬ" }, { "[V]ją", "ъѭ" },
            { "[V]JE", "ЪЕ" }, { "[V]je", "ъе" },
            { "[V]JĘ", "ЪѨ" }, { "[V]ję", "ъѩ" },
            { "[V]JO", "ЪЁ" }, { "[V]jo", "ъё" },
            { "[V]JÓ", "ЪÉ" }, { "[V]jó", "ъé" },
            { "[V]JU", "ЪЮ" }, { "[V]ju", "ъю" },
            { "[V]JI", "ЪЇ" }, { "[V]ji", "ъї" },         
        };

		private static Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{
			{ "Klawiatur", "Клявиатур" }, { "klawiatur", "клявиатур" },
            { "Ri", "Ри" }, { "ri", "ри" },
            { "Di", "Ди" }, { "di", "ди" },
            { "Rza", "Ря" }, { "rza", "ря" },
            { "Rzą", "Рѭ" }, { "rzą", "рѭ" },
            { "Rze", "Ре" }, { "rze", "ре" },
            { "Rzę", "Рѩ" }, { "rzę", "рѩ" },
            { "Rzo", "Рё" }, { "rzo", "рё" },
            { "Rzó", "Рé" }, { "rzó", "рé" },
            { "Rzu", "Рю" }, { "rzu", "рю" },
            { "Rzy", "Ри" }, { "rzy", "ри" },
            { "Dzia", "Дя" }, { "dzia", "дя" },
            { "Dzią", "Дѭ" }, { "dzią", "дѭ" },
            { "Dzie", "Де" }, { "dzie", "де" },
            { "Dzię", "Дѩ" }, { "dzię", "дѩ" },
            { "Dzio", "Дё" }, { "dzio", "дё" },
            { "Dzió", "Дé" }, { "dzió", "дé" },
            { "Dziu", "Дю" }, { "dziu", "дю" },
            { "Dzi", "Ди" }, { "dzi", "ди" },
            { "Cia", "Тя" }, { "cia", "тя" },
            { "Cią", "Тѭ" }, { "cią", "тѭ" },
            { "Cie", "Те" }, { "cie", "те" },
            { "Cię", "Тѩ" }, { "cię", "тѩ" },
            { "Cio", "Тё" }, { "cio", "тё" },
            { "Ció", "Тé" }, { "ció", "тé" },
            { "Ciu", "Тю" }, { "ciu", "тю" },
            { "Ci", "Ти" }, { "ci", "ти" },
            { "La", "Ля" }, { "la", "ля" },
            { "Lą", "Лѭ" }, { "lą", "лѭ" },
            { "Le", "Ле" }, { "le", "ле" },
            { "Lę", "Лѩ" }, { "lę", "лѩ" },
            { "Lo", "Лё" }, { "lo", "лё" },
            { "Ló", "Лé" }, { "ló", "лé" },
            { "Lu", "Лю" }, { "lu", "лю" },
            { "Li", "Ли" }, { "li", "ли" },
            { "Rz", "Рь" }, { "rz", "рь" },
            { "Dź", "Дь" }, { "dź", "дь" },
            { "L", "Ль" }, { "l", "ль" },
            { "Ia", "я" }, { "ia", "я" },
            { "Ią", "ѭ" }, { "ią", "ѭ" },
            { "Ie", "е" }, { "ie", "е" },
            { "Ię", "ѩ" }, { "ię", "ѩ" },
            { "Io", "ё" }, { "io", "ё" },
            { "Ió", "é" }, { "ió", "é" },
            { "Iu", "ю" }, { "iu", "ю" },
            { "Ja", "Я" }, { "ja", "я" }, 
            { "Ją", "Ѭ" }, { "ją", "ѭ" }, 
            { "Je", "Е" }, { "je", "е" }, 
            { "Ję", "Ѩ" }, { "ję", "ѩ" }, 
            { "Jo", "Ё" }, { "jo", "ё" }, 
            { "Jó", "É" }, { "jó", "é" }, 
            { "Ju", "Ю" }, { "ju", "ю" }, 
            { "Ji", "Ї" }, { "ji", "ї" }, 
            { "Szczy", "Щи" }, { "szczy", "щи" },
            { "Szcze", "Ще" }, { "szcze", "ще" },
            { "Szcz", "Щ" }, { "szcz", "щ" },
            { "Szy", "Ши" }, { "szy", "ши" },
            { "Sze", "Ше" }, { "sze", "ше" },
            { "Sz", "Ш" }, { "sz", "ш" },
            { "Czy", "Чи" }, { "czy", "чи" },
            { "Cze", "Че" }, { "cze", "че" },
            { "Cz", "Ч" }, { "cz", "ч" },
            { "Ch", "Х" }, { "ch", "х" },
            { "A", "а" }, { "a", "а" },
            { "Ą", "Ѫ" }, { "ą", "ѫ" },
            { "B", "Б" }, { "b", "б" },
            { "C", "Ц" }, { "c", "ц" },
            { "Ć", "Ть" }, { "ć", "ть" },
            { "D", "Д" }, { "d", "д" },
            { "Ę", "Ѧ" }, { "ę", "ѧ" },
            { "F", "Ф" }, { "f", "ф" },
            { "G", "Г" }, { "g", "г" },
            { "H", "Ґ" }, { "h", "ґ" },
            { "I", "И" }, { "i", "и" },
            { "J", "Й" }, { "j", "й" },
            { "K", "К" }, { "k", "к" },
            { "Ł", "Л" }, { "ł", "л" },
            { "M", "М" }, { "m", "м" },
            { "N", "Н" }, { "n", "н" },
            { "Ń", "Нь" }, { "ń", "нь" },
            { "O", "О" }, { "o", "о" },
            { "Ó", "Ó" }, { "ó", "ó" },
            { "P", "П" }, { "p", "п" },
            { "R", "Р" }, { "r", "р" },
            { "S", "С" }, { "s", "с" },
            { "Ś", "Сь" }, { "ś", "сь" },
            { "T", "Т" }, { "t", "т" },
            { "U", "У" }, { "u", "у" },
            { "W", "В" }, { "w", "в" },
            { "Z", "З" }, { "z", "з" },
            { "Ź", "Зь" }, { "ź", "зь" },
            { "Ży", "Жи" }, { "ży", "жи" },
            { "Że", "Же" }, { "że", "же" },
            { "Y", "Ы" }, { "y", "ы" },
            { "E", "Э" }, { "e", "э" },
            { "Ż", "Ж" }, { "ż", "ж" }
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