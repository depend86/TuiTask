using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TuiTask.Common.Entities
{
    /// <summary>
    /// Страна
    /// </summary>
    [DataContract]
    public class Country
    {
        /// <summary>
        /// айди
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }
        
        /// <summary>
        /// название
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        protected bool Equals(Country other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Country) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        #region Countries

        public static List<Country> Countries = new List<Country>
        {
            new Country{ Id = "AU", Name = "Австралия" },
            new Country{ Id = "AT", Name = "Австрия" },
            new Country{ Id = "AZ", Name = "Азербайджан" },
            new Country{ Id = "AX", Name = "Аландские о-ва" },
            new Country{ Id = "AL", Name = "Албания" },
            new Country{ Id = "DZ", Name = "Алжир" },
            new Country{ Id = "AS", Name = "Американское Самоа" },
            new Country{ Id = "AI", Name = "Ангилья" },
            new Country{ Id = "AO", Name = "Ангола" },
            new Country{ Id = "AD", Name = "Андорра" },
            new Country{ Id = "AQ", Name = "Антарктида" },
            new Country{ Id = "AG", Name = "Антигуа и Барбуда" },
            new Country{ Id = "AR", Name = "Аргентина" },
            new Country{ Id = "AM", Name = "Армения" },
            new Country{ Id = "AW", Name = "Аруба" },
            new Country{ Id = "AF", Name = "Афганистан" },
            new Country{ Id = "BS", Name = "Багамы" },
            new Country{ Id = "BD", Name = "Бангладеш" },
            new Country{ Id = "BB", Name = "Барбадос" },
            new Country{ Id = "BH", Name = "Бахрейн" },
            new Country{ Id = "BY", Name = "Беларусь" },
            new Country{ Id = "BZ", Name = "Белиз" },
            new Country{ Id = "BE", Name = "Бельгия" },
            new Country{ Id = "BJ", Name = "Бенин" },
            new Country{ Id = "BM", Name = "Бермудские о-ва" },
            new Country{ Id = "BG", Name = "Болгария" },
            new Country{ Id = "BO", Name = "Боливия" },
            new Country{ Id = "BQ", Name = "Бонэйр, Синт-Эстатиус и Саба" },
            new Country{ Id = "BA", Name = "Босния и Герцеговина" },
            new Country{ Id = "BW", Name = "Ботсвана" },
            new Country{ Id = "BR", Name = "Бразилия" },
            new Country{ Id = "IO", Name = "Британская территория в Индийском океане" },
            new Country{ Id = "BN", Name = "Бруней-Даруссалам" },
            new Country{ Id = "BF", Name = "Буркина-Фасо" },
            new Country{ Id = "BI", Name = "Бурунди" },
            new Country{ Id = "BT", Name = "Бутан" },
            new Country{ Id = "VU", Name = "Вануату" },
            new Country{ Id = "VA", Name = "Ватикан" },
            new Country{ Id = "GB", Name = "Великобритания" },
            new Country{ Id = "HU", Name = "Венгрия" },
            new Country{ Id = "VE", Name = "Венесуэла" },
            new Country{ Id = "VG", Name = "Виргинские о-ва (Великобритания)" },
            new Country{ Id = "VI", Name = "Виргинские о-ва (США)" },
            new Country{ Id = "UM", Name = "Внешние малые о-ва (США)" },
            new Country{ Id = "TL", Name = "Восточный Тимор" },
            new Country{ Id = "VN", Name = "Вьетнам" },
            new Country{ Id = "GA", Name = "Габон" },
            new Country{ Id = "HT", Name = "Гаити" },
            new Country{ Id = "GY", Name = "Гайана" },
            new Country{ Id = "GM", Name = "Гамбия" },
            new Country{ Id = "GH", Name = "Гана" },
            new Country{ Id = "GP", Name = "Гваделупа" },
            new Country{ Id = "GT", Name = "Гватемала" },
            new Country{ Id = "GN", Name = "Гвинея" },
            new Country{ Id = "GW", Name = "Гвинея-Бисау" },
            new Country{ Id = "DE", Name = "Германия" },
            new Country{ Id = "GG", Name = "Гернси" },
            new Country{ Id = "GI", Name = "Гибралтар" },
            new Country{ Id = "HN", Name = "Гондурас" },
            new Country{ Id = "HK", Name = "Гонконг (САР)" },
            new Country{ Id = "GD", Name = "Гренада" },
            new Country{ Id = "GL", Name = "Гренландия" },
            new Country{ Id = "GR", Name = "Греция" },
            new Country{ Id = "GE", Name = "Грузия" },
            new Country{ Id = "GU", Name = "Гуам" },
            new Country{ Id = "DK", Name = "Дания" },
            new Country{ Id = "JE", Name = "Джерси" },
            new Country{ Id = "DJ", Name = "Джибути" },
            new Country{ Id = "DM", Name = "Доминика" },
            new Country{ Id = "DO", Name = "Доминиканская Республика" },
            new Country{ Id = "EG", Name = "Египет" },
            new Country{ Id = "ZM", Name = "Замбия" },
            new Country{ Id = "EH", Name = "Западная Сахара" },
            new Country{ Id = "ZW", Name = "Зимбабве" },
            new Country{ Id = "IL", Name = "Израиль" },
            new Country{ Id = "IN", Name = "Индия" },
            new Country{ Id = "ID", Name = "Индонезия" },
            new Country{ Id = "JO", Name = "Иордания" },
            new Country{ Id = "IQ", Name = "Ирак" },
            new Country{ Id = "IR", Name = "Иран" },
            new Country{ Id = "IE", Name = "Ирландия" },
            new Country{ Id = "IS", Name = "Исландия" },
            new Country{ Id = "ES", Name = "Испания" },
            new Country{ Id = "IT", Name = "Италия" },
            new Country{ Id = "YE", Name = "Йемен" },
            new Country{ Id = "CV", Name = "Кабо-Верде" },
            new Country{ Id = "KZ", Name = "Казахстан" },
            new Country{ Id = "KH", Name = "Камбоджа" },
            new Country{ Id = "CM", Name = "Камерун" },
            new Country{ Id = "CA", Name = "Канада" },
            new Country{ Id = "QA", Name = "Катар" },
            new Country{ Id = "KE", Name = "Кения" },
            new Country{ Id = "CY", Name = "Кипр" },
            new Country{ Id = "KG", Name = "Киргизия" },
            new Country{ Id = "KI", Name = "Кирибати" },
            new Country{ Id = "CN", Name = "Китай" },
            new Country{ Id = "KP", Name = "КНДР" },
            new Country{ Id = "CC", Name = "Кокосовые о-ва" },
            new Country{ Id = "CO", Name = "Колумбия" },
            new Country{ Id = "KM", Name = "Коморы" },
            new Country{ Id = "CG", Name = "Конго - Браззавиль" },
            new Country{ Id = "CD", Name = "Конго - Киншаса" },
            new Country{ Id = "CR", Name = "Коста-Рика" },
            new Country{ Id = "CI", Name = "Кот-д’Ивуар" },
            new Country{ Id = "CU", Name = "Куба" },
            new Country{ Id = "KW", Name = "Кувейт" },
            new Country{ Id = "CW", Name = "Кюрасао" },
            new Country{ Id = "LA", Name = "Лаос" },
            new Country{ Id = "LV", Name = "Латвия" },
            new Country{ Id = "LS", Name = "Лесото" },
            new Country{ Id = "LR", Name = "Либерия" },
            new Country{ Id = "LB", Name = "Ливан" },
            new Country{ Id = "LY", Name = "Ливия" },
            new Country{ Id = "LT", Name = "Литва" },
            new Country{ Id = "LI", Name = "Лихтенштейн" },
            new Country{ Id = "LU", Name = "Люксембург" },
            new Country{ Id = "MU", Name = "Маврикий" },
            new Country{ Id = "MR", Name = "Мавритания" },
            new Country{ Id = "MG", Name = "Мадагаскар" },
            new Country{ Id = "YT", Name = "Майотта" },
            new Country{ Id = "MO", Name = "Макао (САР)" },
            new Country{ Id = "MW", Name = "Малави" },
            new Country{ Id = "MY", Name = "Малайзия" },
            new Country{ Id = "ML", Name = "Мали" },
            new Country{ Id = "MV", Name = "Мальдивы" },
            new Country{ Id = "MT", Name = "Мальта" },
            new Country{ Id = "MA", Name = "Марокко" },
            new Country{ Id = "MQ", Name = "Мартиника" },
            new Country{ Id = "MH", Name = "Маршалловы Острова" },
            new Country{ Id = "MX", Name = "Мексика" },
            new Country{ Id = "MZ", Name = "Мозамбик" },
            new Country{ Id = "MD", Name = "Молдова" },
            new Country{ Id = "MC", Name = "Монако" },
            new Country{ Id = "MN", Name = "Монголия" },
            new Country{ Id = "MS", Name = "Монтсеррат" },
            new Country{ Id = "MM", Name = "Мьянма (Бирма)" },
            new Country{ Id = "NA", Name = "Намибия" },
            new Country{ Id = "NR", Name = "Науру" },
            new Country{ Id = "NP", Name = "Непал" },
            new Country{ Id = "NE", Name = "Нигер" },
            new Country{ Id = "NG", Name = "Нигерия" },
            new Country{ Id = "NL", Name = "Нидерланды" },
            new Country{ Id = "NI", Name = "Никарагуа" },
            new Country{ Id = "NU", Name = "Ниуэ" },
            new Country{ Id = "NZ", Name = "Новая Зеландия" },
            new Country{ Id = "NC", Name = "Новая Каледония" },
            new Country{ Id = "NO", Name = "Норвегия" },
            new Country{ Id = "BV", Name = "о-в Буве" },
            new Country{ Id = "IM", Name = "о-в Мэн" },
            new Country{ Id = "NF", Name = "о-в Норфолк" },
            new Country{ Id = "CX", Name = "о-в Рождества" },
            new Country{ Id = "SH", Name = "о-в Св. Елены" },
            new Country{ Id = "PN", Name = "о-ва Питкэрн" },
            new Country{ Id = "TC", Name = "о-ва Тёркс и Кайкос" },
            new Country{ Id = "HM", Name = "о-ва Херд и Макдональд" },
            new Country{ Id = "AE", Name = "ОАЭ" },
            new Country{ Id = "OM", Name = "Оман" },
            new Country{ Id = "KY", Name = "Острова Кайман" },
            new Country{ Id = "CK", Name = "Острова Кука" },
            new Country{ Id = "PK", Name = "Пакистан" },
            new Country{ Id = "PW", Name = "Палау" },
            new Country{ Id = "PS", Name = "Палестинские территории" },
            new Country{ Id = "PA", Name = "Панама" },
            new Country{ Id = "PG", Name = "Папуа — Новая Гвинея" },
            new Country{ Id = "PY", Name = "Парагвай" },
            new Country{ Id = "PE", Name = "Перу" },
            new Country{ Id = "PL", Name = "Польша" },
            new Country{ Id = "PT", Name = "Португалия" },
            new Country{ Id = "PR", Name = "Пуэрто-Рико" },
            new Country{ Id = "KR", Name = "Республика Корея" },
            new Country{ Id = "RE", Name = "Реюньон" },
            new Country{ Id = "RU", Name = "Россия" },
            new Country{ Id = "RW", Name = "Руанда" },
            new Country{ Id = "RO", Name = "Румыния" },
            new Country{ Id = "SV", Name = "Сальвадор" },
            new Country{ Id = "WS", Name = "Самоа" },
            new Country{ Id = "SM", Name = "Сан-Марино" },
            new Country{ Id = "ST", Name = "Сан-Томе и Принсипи" },
            new Country{ Id = "SA", Name = "Саудовская Аравия" },
            new Country{ Id = "MK", Name = "Северная Македония" },
            new Country{ Id = "MP", Name = "Северные Марианские о-ва" },
            new Country{ Id = "SC", Name = "Сейшельские Острова" },
            new Country{ Id = "BL", Name = "Сен-Бартелеми" },
            new Country{ Id = "MF", Name = "Сен-Мартен" },
            new Country{ Id = "PM", Name = "Сен-Пьер и Микелон" },
            new Country{ Id = "SN", Name = "Сенегал" },
            new Country{ Id = "VC", Name = "Сент-Винсент и Гренадины" },
            new Country{ Id = "KN", Name = "Сент-Китс и Невис" },
            new Country{ Id = "LC", Name = "Сент-Люсия" },
            new Country{ Id = "RS", Name = "Сербия" },
            new Country{ Id = "SG", Name = "Сингапур" },
            new Country{ Id = "SX", Name = "Синт-Мартен" },
            new Country{ Id = "SY", Name = "Сирия" },
            new Country{ Id = "SK", Name = "Словакия" },
            new Country{ Id = "SI", Name = "Словения" },
            new Country{ Id = "US", Name = "Соединенные Штаты" },
            new Country{ Id = "SB", Name = "Соломоновы Острова" },
            new Country{ Id = "SO", Name = "Сомали" },
            new Country{ Id = "SD", Name = "Судан" },
            new Country{ Id = "SR", Name = "Суринам" },
            new Country{ Id = "SL", Name = "Сьерра-Леоне" },
            new Country{ Id = "TJ", Name = "Таджикистан" },
            new Country{ Id = "TH", Name = "Таиланд" },
            new Country{ Id = "TW", Name = "Тайвань" },
            new Country{ Id = "TZ", Name = "Танзания" },
            new Country{ Id = "TG", Name = "Того" },
            new Country{ Id = "TK", Name = "Токелау" },
            new Country{ Id = "TO", Name = "Тонга" },
            new Country{ Id = "TT", Name = "Тринидад и Тобаго" },
            new Country{ Id = "TV", Name = "Тувалу" },
            new Country{ Id = "TN", Name = "Тунис" },
            new Country{ Id = "TM", Name = "Туркменистан" },
            new Country{ Id = "TR", Name = "Турция" },
            new Country{ Id = "UG", Name = "Уганда" },
            new Country{ Id = "UZ", Name = "Узбекистан" },
            new Country{ Id = "UA", Name = "Украина" },
            new Country{ Id = "WF", Name = "Уоллис и Футуна" },
            new Country{ Id = "UY", Name = "Уругвай" },
            new Country{ Id = "FO", Name = "Фарерские о-ва" },
            new Country{ Id = "FM", Name = "Федеративные Штаты Микронезии" },
            new Country{ Id = "FJ", Name = "Фиджи" },
            new Country{ Id = "PH", Name = "Филиппины" },
            new Country{ Id = "FI", Name = "Финляндия" },
            new Country{ Id = "FK", Name = "Фолклендские о-ва" },
            new Country{ Id = "FR", Name = "Франция" },
            new Country{ Id = "GF", Name = "Французская Гвиана" },
            new Country{ Id = "PF", Name = "Французская Полинезия" },
            new Country{ Id = "TF", Name = "Французские Южные территории" },
            new Country{ Id = "HR", Name = "Хорватия" },
            new Country{ Id = "CF", Name = "Центрально-Африканская Республика" },
            new Country{ Id = "TD", Name = "Чад" },
            new Country{ Id = "ME", Name = "Черногория" },
            new Country{ Id = "CZ", Name = "Чехия" },
            new Country{ Id = "CL", Name = "Чили" },
            new Country{ Id = "CH", Name = "Швейцария" },
            new Country{ Id = "SE", Name = "Швеция" },
            new Country{ Id = "SJ", Name = "Шпицберген и Ян-Майен" },
            new Country{ Id = "LK", Name = "Шри-Ланка" },
            new Country{ Id = "EC", Name = "Эквадор" },
            new Country{ Id = "GQ", Name = "Экваториальная Гвинея" },
            new Country{ Id = "ER", Name = "Эритрея" },
            new Country{ Id = "SZ", Name = "Эсватини" },
            new Country{ Id = "EE", Name = "Эстония" },
            new Country{ Id = "ET", Name = "Эфиопия" },
            new Country{ Id = "GS", Name = "Южная Георгия и Южные Сандвичевы о-ва" },
            new Country{ Id = "ZA", Name = "Южно-Африканская Республика" },
            new Country{ Id = "SS", Name = "Южный Судан" },
            new Country{ Id = "JM", Name = "Ямайка" },
            new Country{ Id = "JP", Name = "Япония" }
        };

        #endregion
    }
}