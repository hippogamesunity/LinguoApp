using System.Collections.Generic;

namespace LinguoApp
{
	public static class Transtator
	{
		private static Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{
			{ "Szcz", "Щ" }, { "szcz", "щ" },
            { "Sz", "Ш" }, { "sz", "ш" },
            { "Cz", "Ч" }, { "cz", "ч" },
            { "Ch", "Х" }, { "ch", "х" },
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
            { "Y", "Ы" }, { "y", "ы" },
            { "Z", "З" }, { "z", "з" },
            { "Ź", "Зь" }, { "ź", "зь" },
            { "Ż", "Ж" }, { "ż", "ж" },
        };

		public static string Translate(string input)
		{
			var result = input;

			foreach (var entry in SimpleReplace)
			{
				result = result.Replace(entry.Key, entry.Value);
			}

			return result;
		}
	}
}