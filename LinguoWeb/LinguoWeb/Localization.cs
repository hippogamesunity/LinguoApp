using System.Collections.Generic;

namespace LinguoWeb
{
	public static class Localization
	{
		public const string DefaultLanguage = "PL";
		public static string Language = DefaultLanguage;
		
		private static readonly Dictionary<string, Dictionary<string, string>> Dictionary = new Dictionary<string, Dictionary<string, string>>
		{
			{
				"PL", new Dictionary<string, string>
				{
					{ "Translator", "Транслятор" },
					{ "About", "Информацъя" },
					{ "Contact", "Контакт" },
					{ "Latin", "Łacina" },
					{ "Cyrillic", "Цырылица" },
					{ "Translate", "Przetłumacz" },
					{ "TranslateBack", "Претлумачь" },
					{ "About.Text", "Тэн тлумач зостал створёны през мѩдзысловяньскѫ групѧ \"Володари\" в цэлю усправненя комуникацъї мѩдзы Поляками а ужитковниками цырылицы (на базе ѩзыка староцэркевнословяньскего). Опера сѩ на клясычнэй ортографии старословяньскей (не вплыва то на читане). Скопюй тэкст, артыкул люб вядомосьть до тлумача, а настѧпне ужий го до власных потреб. Есьли зауважиш блѫд тэхничны люб маш пропозыцъѩ, напиш до нас (патрь дял информацыйны)." },
					{ "Contact.Text", "<p>Георгий Милованов - глóвны володар</p><strong>Вспарте:</strong> <a href=\"Svaznoyjedi@mail.ru\">Svaznoyjedi@mail.ru</a>" }
				}
			},
			{
				"CZ", new Dictionary<string, string>
				{
					{ "Translator", "Прекладател" },
					{ "About", "Информаце" },
					{ "Contact", "Контакт" },
					{ "Latin", "Latina" },
					{ "Cyrillic", "Цырилице" },
					{ "Translate", "Přeložit" },
					{ "TranslateBack", "Преложит" },
					{ "About.Text", "Тенто прекладател был вытворен скупиноу мезивойводŏ \"Володари\", абы се злепшила комуникаце мези Полáки а цырілски́ми уживатели (заложенá на старослованске́м слованске́м языце). Е заложен на класицке́ старослованске́ правописне́ ґрафице (неовливнюе чтени́). Зкопи́руйте текст, члáнек небо зпрáву прекладатели а поте́ ей поужийте подле свы́х потреб. Покуд се обеви́ техницкá хыба небо мáте нѣяки́ нáврг, напище нáм (виз чáст с информацеми)." },
					{ "Contact.Text", "<p>Георгий Милованов - главни́ володар</p><strong>Подпора:</strong> <a href=\"Svaznoyjedi@mail.ru\">Svaznoyjedi@mail.ru</a>" }
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