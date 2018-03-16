using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoApp
{
	public static class TranslatorCyrillicLatin
	{
		private const string CyrillichAlphabet = "АаБбВвГгҐґДдЕеЁёÉéЖжЗзИиЙйЇїКкЛлМмНнОоÓóПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЮюѪѫѬѭЭэѦѧѨѩЯя";
		private const string CyrillicConsonants = "АаЕеЁёÉéИиЇїОоÓóУуЫыЮюѪѫѬѭЭэѦѧѨѩЯя";
		private const string CyrillicVowels = "БбВвГгҐґЖжЗзКкМмНнПпСсФфХхЦц";

		private static Dictionary<string, string> RegexReplace = new Dictionary<string, string>
		{
            { "[V]Я", "IA" }, { "[V]я", "ia" },
            { "[V]Ѭ", "IĄ" }, { "[V]ѭ", "ią" },
            { "[V]Е", "IE" }, { "[V]е", "ie" },
            { "[V]Ѩ", "IĘ" }, { "[V]ѩ", "ię" },
            { "[V]Ё", "IO" }, { "[V]ё", "io" },
            { "[V]É", "IÓ" }, { "[V]é", "ió" },
            { "[V]Ю", "IU" }, { "[V]ю", "iu" },
            { "[V]Ї", "I" }, { "[V]ї", "i" },
        };

		private static Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{
			{ "[Roman:IV]", "[Roman:5]" },
            { "Клявиатур", "Klawiatur" }, { "клявиатур", "klawiatur" },
            { "Риа", "Ria" }, { "риа", "ria" },
            { "Диа", "Dia" }, { "диа", "dia" },
            { "Рио", "Rio" }, { "рио", "rio" },
            { "Дио", "Dio" }, { "дио", "dio" },
            { "Ря", "Rza" }, { "ря", "rza" },
            { "Рѭ", "Rzą" }, { "рѭ", "rzą" },
            { "Ре", "Rze" }, { "ре", "rze" },
            { "Рѩ", "Rzę" }, { "рѩ", "rzę" },
            { "Рё", "Rzo" }, { "рё", "rzo" },
            { "Рé", "Rzó" }, { "рé", "rzó" },
            { "Рю", "Rzu" }, { "рю", "rzu" },
            { "Ри", "Rzy" }, { "ри", "rzy" },
            { "Дя", "Dzia" }, { "дя", "dzia" },
            { "Дѭ", "Dzią" }, { "дѭ", "dzią" },
            { "Де", "Dzie" }, { "де", "dzie" },
            { "Дѩ", "Dzię" }, { "дѩ", "dzię" },
            { "Дё", "Dzio" }, { "дё", "dzio" },
            { "Дé", "Dzió" }, { "дé", "dzió" },
            { "Дю", "Dziu" }, { "дю", "dziu" },
            { "Ди", "Dzi" }, { "ди", "dzi" },
            { "Тя", "Cia" }, { "тя", "cia" },
            { "Тѭ", "Cią" }, { "тѭ", "cią" },
            { "Те", "Cie" }, { "те", "cie" },
            { "Тѩ", "Cię" }, { "тѩ", "cię" },
            { "Тё", "Cio" }, { "тё", "cio" },
            { "Тé", "Ció" }, { "тé", "ció" },
            { "Тю", "Ciu" }, { "тю", "ciu" },
            { "Ти", "Ci" }, { "ти", "ci" },
            { "Ля", "La" }, { "ля", "la" },
            { "Лѭ", "Lą" }, { "лѭ", "lą" },
            { "Ле", "Lе" }, { "ле", "le" },
            { "Лѩ", "Lę" }, { "лѩ", "lę" },
            { "Лё", "Lo" }, { "лё", "lo" },
            { "Лé", "Ló" }, { "лé", "ló" },
            { "Лю", "Lu" }, { "лю", "lu" },
            { "Ли", "Li" }, { "ли", "li" },
            { "Рь", "Rz" }, { "рь", "rz" },
            { "Дь", "Dź" }, { "дь", "dź" },
            { "Ль", "L" }, { "ль", "l" },
            { "Я", "Ja" }, { "я", "ja" },
            { "Ѭ", "Ją" }, { "ѭ", "ją" },
            { "Ѩ", "Ję" }, { "ѩ", "ję" },
            { "Ё", "Jo" }, { "ё", "jo" },
            { "É", "Jó" }, { "é", "jó" },
            { "Ю", "Ju" }, { "ю", "ju" },
            { "Ї", "Ji" }, { "ї", "ji" },
            { "Щи", "Szczy" }, { "щи", "szczy" },
            { "Ще", "Szcze" }, { "ще", "szcze" },
            { "Щ", "Szcz" }, { "щ", "szcz" },
            { "Ши", "Szy" }, { "ши", "szy" },
            { "Ше", "Sze" }, { "ше", "sze" },
            { "Ш", "Sz" }, { "ш", "sz" },
            { "Чи", "Czy" }, { "чи", "czy" },
            { "Че", "Cze" }, { "че", "cze" },
            { "Ч", "Cz" }, { "ч", "cz" },
            { "Х", "Ch" }, { "х", "ch" },
            { "А", "A" }, { "а", "a" },
            { "Ѫ", "Ą" }, { "ѫ", "ą" },
            { "Б", "B" }, { "б", "b" },
            { "Ц", "C" }, { "ц", "c" },
            { "Ть", "Ć" }, { "ть", "ć" },
            { "Д", "D" }, { "д", "d" },
            { "Э", "E" }, { "э", "e" },
            { "Ѧ", "Ę" }, { "ѧ", "ę" },
            { "Ф", "F" }, { "ф", "f" },
            { "Г", "G" }, { "г", "g" },
            { "Ґ", "H" }, { "ґ", "h" },
            { "Й", "J" }, { "й", "j" },
            { "К", "K" }, { "к", "k" },
            { "Л", "Ł" }, { "л", "ł" },
            { "М", "M" }, { "м", "m" },
            { "Нь", "Ń" }, { "нь", "ń" },
            { "Н", "N" }, { "н", "n" },
            { "О", "O" }, { "о", "o" },
            { "Ó", "Ó" }, { "ó", "ó" },
            { "П", "P" }, { "п", "p" },
            { "Р", "R" }, { "р", "r" },
            { "Сь", "Ś" }, { "сь", "ś" },
            { "С", "S" }, { "с", "s" },
            { "Т", "T" }, { "т", "t" },
            { "У", "U" }, { "у", "u" },
            { "В", "W" }, { "в", "w" },
            { "Ы", "Y" }, { "ы", "y" },
            { "Зь", "Ź" }, { "зь", "ź" },
            { "З", "Z" }, { "з", "z" },
            { "Жи", "Ży" }, { "жи", "ży" },
            { "Же", "Żе" }, { "же", "że" },
            { "И", "I" }, { "и", "i" },
            { "Ж", "Ż" }, { "ж", "ż" },
            { "Е", "Je" }, { "е", "je" },
            { "Ь", "" }, { "ь", "" },
			{ "Ъ", "" }, { "ъ", "" },
			{ "[Roman:5]", "IV" },
		};

		public static string Translate(string input)
		{
			var result = input;

			foreach (Match match in Regex.Matches(result, @"([IÎVX]+)(\W+|$)"))
			{
				result = result.Replace(match.Groups[1].Value, "[Roman:" + match.Groups[1] + "]");
			}

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