using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoApp
{
	public static class TranslatorCyrillicPolish
	{
		private const string CyrillichAlphabet = "АаБбВвГгҐґДдЕеЁёÉéЖжЗзИиЙйЇїКкЛлМмНнОоÓóПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЮюѪѫѬѭЭэѦѧѨѩЯя";
		private const string CyrillicConsonants = "АаЕеЁёÉéИиЇїОоÓóУуЫыЮюѪѫѬѭЭэѦѧѨѩЯя";
		private const string CyrillicVowels = "БбВвГгҐґДдЖжЗзКкЛлМмНнПпРрСсТтФфХхЦцЧчШшЩщ";

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
            { "Rza", "Rza" }, { "rza", "rza" },
            { "Rzą", "Rzą" }, { "rzą", "rzą" },
            { "Rze", "Rze" }, { "rze", "rze" },
            { "Rzę", "Rzę" }, { "rzę", "rzę" },
            { "Rzo", "Rzo" }, { "rzo", "rzo" },
            { "Rzó", "Rzó" }, { "rzó", "rzó" },
            { "Rzu", "Rzu" }, { "rzu", "rzu" },
            { "Rzy", "Rzy" }, { "rzy", "rzy" },
            { "Dzia", "Dzia" }, { "dzia", "dzia" },
            { "Dzią", "Dzią" }, { "dzią", "dzią" },
            { "Dzie", "Dzie" }, { "dzie", "dzie" },
            { "Dzię", "Dzię" }, { "dzię", "dzię" },
            { "Dzio", "Dzio" }, { "dzio", "dzio" },
            { "Dzió", "Dzió" }, { "dzió", "dzió" },
            { "Dziu", "Dziu" }, { "dziu", "dziu" },
            { "Dzi", "Dzi" }, { "dzi", "dzi" },
            { "Cia", "Cia" }, { "cia", "тя" },
            { "Cią", "Cią" }, { "cią", "тѭ" },
            { "Cie", "Cie" }, { "cie", "те" },
            { "Cię", "Cię" }, { "cię", "тѩ" },
            { "Cio", "Cio" }, { "cio", "тё" },
            { "Ció", "Ció" }, { "ció", "тé" },
            { "Ciu", "Ciu" }, { "ciu", "тю" },
            { "Ci", "Ci" }, { "ci", "ти" },
            { "La", "La" }, { "la", "ля" },
            { "Lą", "Lą" }, { "lą", "лѭ" },
            { "Le", "Lе" }, { "le", "ле" },
            { "Lę", "Lę" }, { "lę", "лѩ" },
            { "Lo", "Lo" }, { "lo", "лё" },
            { "Ló", "Ló" }, { "ló", "лé" },
            { "Lu", "Lu" }, { "lu", "лю" },
            { "Li", "Li" }, { "li", "ли" },
            { "Rz", "Rz" }, { "rz", "рь" },
            { "Dź", "Dź" }, { "dź", "дь" },
            { "L", "L" }, { "l", "ль" },
            { "ЪЯ", "JA" }, { "ъа", "ja" },
            { "ЪѬ", "JĄ" }, { "ъѭ", "ją" },
            { "ЪЕ", "JE" }, { "ъе", "je" },
            { "ЪѨ", "JĘ" }, { "ъѩ", "ję" },
            { "ЪЁ", "JO" }, { "ъё", "jo" },
            { "ЪÉ", "JÓ" }, { "ъé", "jó" },
            { "ЪЮ", "JU" }, { "ъю", "ju" },
            { "ЪЇ", "JI" }, { "ъї", "ji" },
            { "Я", "Ja" }, { "ja", "я" },
            { "Ѭ", "Ją" }, { "ją", "ѭ" },
            { "Е", "Je" }, { "je", "е" },
            { "Ѩ", "Ję" }, { "ję", "ѩ" },
            { "Ё", "Jo" }, { "jo", "ё" },
            { "É", "Jó" }, { "jó", "é" },
            { "Ю", "Ju" }, { "ju", "ю" },
            { "Ї", "Ji" }, { "ji", "ї" },
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
            { "A", "а" }, { "a", "а" },
            { "Ą", "Ѫ" }, { "ą", "ѫ" },
            { "B", "Б" }, { "b", "б" },
            { "C", "Ц" }, { "c", "ц" },
            { "Ć", "Ть" }, { "ć", "ть" },
            { "D", "Д" }, { "d", "д" },
            { "E", "Э" }, { "e", "э" },
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
            { "Ż", "Ж" }, { "ż", "ж" },
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