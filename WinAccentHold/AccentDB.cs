using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinAccentHold
{
    class AccentDB
    {
        public Dictionary<String, Dictionary<int, String>> mainDB;
        public Dictionary<String, Dictionary<int, String>> altDB;

        public AccentDB()
        {
            mainDB = new Dictionary<String, Dictionary<int, String>>();
            altDB = new Dictionary<String, Dictionary<int, String>>();

            mainDB["A"] = new Dictionary<int, String>
        {
            { 1, "\u00C0" }, // À
            { 2, "\u00C1" }, // Á
            { 3, "\u00C2" }, // Â
            { 4, "\u00C4" }, // Ä
            { 5, "\u01CD" }, // Ǎ
            { 6, "\u00C6" }, // Æ
            { 7, "\u00C3" }, // Ã
            { 8, "\u00C5" }, // Å
            { 9, "\u0100" }  // Ā
        };

            mainDB["a"] = new Dictionary<int, String>
        {
            { 1, "\u00E0" }, // à
            { 2, "\u00E1" }, // á
            { 3, "\u00E2" }, // â
            { 4, "\u00E4" }, // ä
            { 5, "\u01CE" }, // ǎ
            { 6, "\u00E6" }, // æ
            { 7, "\u00E3" }, // ã
            { 8, "\u00E5" }, // å
            { 9, "\u0101" }  // ā
        };

            mainDB["E"] = new Dictionary<int, String>
        {
            { 1, "\u00C8" }, // È
            { 2, "\u00C9" }, // É
            { 3, "\u00CA" }, // Ê
            { 4, "\u00CB" }, // Ë
            { 5, "\u0112" }, // Ē
            { 6, "\u011A" }  // Ě
        };

            mainDB["e"] = new Dictionary<int, String>
        {
            { 1, "\u00E8" }, // è
            { 2, "\u00E9" }, // é
            { 3, "\u00EA" }, // ê
            { 4, "\u00EB" }, // ë
            { 5, "\u0113" }, // ē
            { 6, "\u011B" }  // ě
        };

            mainDB["I"] = new Dictionary<int, String>
        {
            { 1, "\u00CC" }, // Ì
            { 2, "\u00CD" }, // Í
            { 3, "\u00CE" }, // Î
            { 4, "\u00CF" }, // Ï
            { 5, "\u012A" }  // Ī
        };

            mainDB["i"] = new Dictionary<int, String>
        {
            { 1, "\u00EC" }, // ì
            { 2, "\u00ED" }, // í
            { 3, "\u00EE" }, // î
            { 4, "\u00EF" }, // ï
            { 5, "\u012B" }  // ī
        };

            mainDB["O"] = new Dictionary<int, String>
        {
            { 1, "\u00D2" }, // Ò
            { 2, "\u00D3" }, // Ó
            { 3, "\u00D4" }, // Ô
            { 4, "\u00D6" }, // Ö
            { 5, "\u01D1" }, // Ǒ
            { 6, "\u00D8" }, // Ø
            { 7, "\u014C" }  // Ō
        };

            mainDB["o"] = new Dictionary<int, String>
        {
            { 1, "\u00F2" }, // ò
            { 2, "\u00F3" }, // ó
            { 3, "\u00F4" }, // ô
            { 4, "\u00F6" }, // ö
            { 5, "\u01D2" }, // ǒ
            { 6, "\u00F8" }, // ø
            { 7, "\u014D" }  // ō
        };

            mainDB["U"] = new Dictionary<int, String>
        {
            { 1, "\u00D9" }, // Ù
            { 2, "\u00DA" }, // Ú
            { 3, "\u00DB" }, // Û
            { 4, "\u00DC" }, // Ü
            { 5, "\u016A" }  // Ū
        };

            mainDB["u"] = new Dictionary<int, String>
        {
            { 1, "\u00F9" }, // ù
            { 2, "\u00FA" }, // ú
            { 3, "\u00FB" }, // û
            { 4, "\u00FC" }, // ü
            { 5, "\u016B" }  // ū
        };

            mainDB["N"] = new Dictionary<int, String>
        {
            { 1, "\u00D1" }, // Ñ
            { 2, "\u0143" }, // Ń
            { 3, "\u0147" }, // Ň
            { 4, "\u0145" }, // Ņ
            { 5, "\u1E4A" }, // Ṋ
            { 6, "\u1E44" }, // Ṅ
            { 7, "\u1E46" }, // Ṇ
            { 8, "\u1E48" }  // Ṉ
        };

            mainDB["n"] = new Dictionary<int, String>
        {
            { 1, "\u00F1" }, // ñ
            { 2, "\u0144" }, // ń
            { 3, "\u0148" }, // ň
            { 4, "\u0146" }, // ņ
            { 5, "\u1E4B" }, // ṋ
            { 6, "\u1E45" }, // ṅ
            { 7, "\u1E47" }, // ṇ
            { 8, "\u1E49" }  // ṉ
        };

            mainDB["B"] = new Dictionary<int, String>
        {
            { 1, "\u1E02" }  // Ḃ - dot above
        };

            mainDB["b"] = new Dictionary<int, String>
        {
            { 1, "\u1E03" }  // ḃ - dot above
        };

            mainDB["C"] = new Dictionary<int, String>
        {
            { 1, "\u00C7" }, // Ç - cedilla
            { 2, "\u0106" }, // Ć - acute
            { 3, "\u0108" }, // Ĉ - circumflex
            { 4, "\u010C" }, // Č - caron
            { 5, "\u010A" }  // Ċ - dot above
        };

            mainDB["c"] = new Dictionary<int, String>
        {
            { 1, "\u00E7" }, // ç - cedilla
            { 2, "\u0107" }, // ć - acute
            { 3, "\u0109" }, // ĉ - circumflex
            { 4, "\u010D" }, // č - caron
            { 5, "\u010B" }  // ċ - dot above
        };

            mainDB["D"] = new Dictionary<int, String>
        {
            { 1, "\u010E" }, // Ď - caron
            { 2, "\u0110" }, // Đ - stroke
            { 3, "\u00D0" }  // Ð - eth
        };

            mainDB["d"] = new Dictionary<int, String>
        {
            { 1, "\u010F" }, // ď - caron
            { 2, "\u0111" }, // đ - stroke
            { 3, "\u00F0" }  // ð - eth
        };

            mainDB["G"] = new Dictionary<int, String>
        {
            { 1, "\u011E" }, // Ğ - breve
            { 2, "\u0120" }, // Ġ - dot above
            { 3, "\u0122" }  // Ģ - cedilla
        };

            mainDB["g"] = new Dictionary<int, String>
        {
            { 1, "\u011F" }, // ğ - breve
            { 2, "\u0121" }, // ġ - dot above
            { 3, "\u0123" }  // ģ - cedilla
        };

            mainDB["H"] = new Dictionary<int, String>
        {
            { 1, "\u0124" }  // Ĥ - circumflex
        };

            mainDB["h"] = new Dictionary<int, String>
        {
            { 1, "\u0125" }  // ĥ - circumflex
        };

            mainDB["J"] = new Dictionary<int, String>
        {
            { 1, "\u0134" }  // Ĵ - circumflex
        };

            mainDB["j"] = new Dictionary<int, String>
        {
            { 1, "\u0135" }  // ĵ - circumflex
        };

            mainDB["K"] = new Dictionary<int, String>
        {
            { 1, "\u0136" }  // Ķ - cedilla
        };

            mainDB["k"] = new Dictionary<int, String>
        {
            { 1, "\u0137" }  // ķ - cedilla
        };

            mainDB["L"] = new Dictionary<int, String>
        {
            { 1, "\u0139" }, // Ĺ - acute
            { 2, "\u013B" }, // Ļ - cedilla
            { 3, "\u013D" }, // Ľ - caron
            { 4, "\u0141" }  // Ł - stroke
        };

            mainDB["l"] = new Dictionary<int, String>
        {
            { 1, "\u013A" }, // ĺ - acute
            { 2, "\u013C" }, // ļ - cedilla
            { 3, "\u013E" }, // ľ - caron
            { 4, "\u0142" }  // ł - stroke
        };

            mainDB["R"] = new Dictionary<int, String>
        {
            { 1, "\u0154" }, // Ŕ - acute
            { 2, "\u0158" }  // Ř - caron
        };

            mainDB["r"] = new Dictionary<int, String>
        {
            { 1, "\u0155" }, // ŕ - acute
            { 2, "\u0159" }  // ř - caron
        };

            mainDB["S"] = new Dictionary<int, String>
        {
            { 1, "\u015A" }, // Ś - acute
            { 2, "\u015C" }, // Ŝ - circumflex
            { 3, "\u015E" }, // Ş - cedilla
            { 4, "\u0160" }, // Š - caron
            { 5, "\u1E9E" }  // ẞ - sharp S
        };

            mainDB["s"] = new Dictionary<int, String>
        {
            { 1, "\u015B" }, // ś - acute
            { 2, "\u015D" }, // ŝ - circumflex
            { 3, "\u015F" }, // ş - cedilla
            { 4, "\u0161" }, // š - caron
            { 5, "\u00DF" }  // ß - sharp S
        };

            mainDB["T"] = new Dictionary<int, String>
        {
            { 1, "\u0162" }, // Ţ - cedilla
            { 2, "\u0164" }, // Ť - caron
            { 3, "\u0166" }, // Ŧ - stroke
            { 4, "\u00DE" }  // Þ - thorn
        };

            mainDB["t"] = new Dictionary<int, String>
        {
            { 1, "\u0163" }, // ţ - cedilla
            { 2, "\u0165" }, // ť - caron
            { 3, "\u0167" }, // ŧ - stroke
            { 4, "\u00FE" }  // þ - thorn
        };

            mainDB["Y"] = new Dictionary<int, String>
        {
            { 1, "\u00DD" }, // Ý - acute
            { 2, "\u0176" }, // Ŷ - circumflex
            { 3, "\u0178" }  // Ÿ - diaeresis
        };

            mainDB["y"] = new Dictionary<int, String>
        {
            { 1, "\u00FD" }, // ý - acute
            { 2, "\u0177" }, // ŷ - circumflex
            { 3, "\u00FF" }  // ÿ - diaeresis
        };

            mainDB["Z"] = new Dictionary<int, String>
        {
            { 1, "\u0179" }, // Ź - acute
            { 2, "\u017B" }, // Ż - dot above
            { 3, "\u017D" }  // Ž - caron
        };

            mainDB["z"] = new Dictionary<int, String>
        {
            { 1, "\u017A" }, // ź - acute
            { 2, "\u017C" }, // ż - dot above
            { 3, "\u017E" }  // ž - caron
        };

            mainDB["1"] = new Dictionary<int, String>
        {
            { 1, "\u00A1" }, // ¡ - inverted exclamation mark
            { 2, "\u2044" }  // ⁄ - fraction slash
        };
            mainDB["2"] = new Dictionary<int, String>
        {
            { 1, "\u2122" }, // ™ - trademark sign
            { 2, "\u20AC" }  // € - euro sign
        };
            mainDB["3"] = new Dictionary<int, String>
        {
            { 1, "\u00A3" }, // £ - pound sign
            { 2, "\u2039" }  // ‹ - single left angle quotation mark
        };
            mainDB["4"] = new Dictionary<int, String>
        {
            { 1, "\u00A2" }, // ¢ - cent sign
            { 2, "\u203A" }  // › - single right angle quotation mark
        };
            mainDB["5"] = new Dictionary<int, String>
        {
            { 1, "\u221E" }, // ∞ - infinity
            { 2, "\uFB01" }  // ﬁ - Latin ligature fi
        };
            mainDB["6"] = new Dictionary<int, String>
        {
            { 1, "\u00A7" }, // § - section sign
            { 2, "\uFB02" }  // ﬂ - Latin ligature fl
        };
            mainDB["7"] = new Dictionary<int, String>
        {
            { 1, "\u00B6" }, // ¶ - pilcrow sign
            { 2, "\u2021" }  // ‡ - double dagger
        };
            mainDB["8"] = new Dictionary<int, String>
        {
            { 1, "\u2022" }, // • - bullet
            { 2, "\u00B0" }  // ° - degree sign
        };
            mainDB["9"] = new Dictionary<int, String>
        {
            { 1, "\u00AA" }, // ª - feminine ordinal indicator
            { 2, "\u00B7" }  // · - middle dot
        };
            mainDB["0"] = new Dictionary<int, String>
        {
            { 1, "\u00BA" }, // º - masculine ordinal indicator
            { 2, "\u201A" }  // ‚ - single low-9 quotation mark
        };
            mainDB["-"] = new Dictionary<int, String>
        {
            { 1, "\u2013" }, // – - en dash
            { 2, "\u2014" }  // — - em dash
        };
            mainDB["="] = new Dictionary<int, String>
        {
            { 1, "\u2260" }, // ≠ - not equal to
            { 2, "\u00B1" }  // ± - plus-minus sign
        };

            altDB["A"] = new Dictionary<int, String> { { 1, "\u00E5" }, { 2, "\u00C5" } }; // å / Å
            altDB["B"] = new Dictionary<int, String> { { 1, "\u222B" }, { 2, "\u0131" } }; // ∫ / ı
            altDB["C"] = new Dictionary<int, String> { { 1, "\u00E7" }, { 2, "\u00C7" } }; // ç / Ç
            altDB["D"] = new Dictionary<int, String> { { 1, "\u2202" }, { 2, "\u00CE" } }; // ∂ / Î
            altDB["E"] = new Dictionary<int, String> { { 1, "\u00B4" }, { 2, "\u00B4" } }; // ´ / ´
            altDB["F"] = new Dictionary<int, String> { { 1, "\u0192" }, { 2, "\u00CF" } }; // ƒ / Ï
            altDB["G"] = new Dictionary<int, String> { { 1, "\u00A9" }, { 2, "\u02DD" } }; // © / ˝
            altDB["H"] = new Dictionary<int, String> { { 1, "\u02D9" }, { 2, "\u00D3" } }; // ˙ / Ó
            altDB["I"] = new Dictionary<int, String> { { 1, "\u02C6" }, { 2, "\u02C6" } }; // ˆ / ˆ
            altDB["J"] = new Dictionary<int, String> { { 1, "\u2206" }, { 2, "\u00D4" } }; // ∆ / Ô
            altDB["K"] = new Dictionary<int, String> { { 1, "\u02DA" }, { 2, "\uF8FF" } }; // ˚ / Apple logo
            altDB["L"] = new Dictionary<int, String> { { 1, "\u00AC" }, { 2, "\u00D2" } }; // ¬ / Ò
            altDB["M"] = new Dictionary<int, String> { { 1, "\u00B5" }, { 2, "\u00C2" } }; // µ / Â
            altDB["N"] = new Dictionary<int, String> { { 1, "\u02DC" }, { 2, "\u02DC" } }; // ˜ / ˜
            altDB["O"] = new Dictionary<int, String> { { 1, "\u00F8" }, { 2, "\u00D8" } }; // ø / Ø
            altDB["P"] = new Dictionary<int, String> { { 1, "\u03C0" }, { 2, "\u220F" } }; // π / ∏
            altDB["Q"] = new Dictionary<int, String> { { 1, "\u0153" }, { 2, "\u0152" } }; // œ / Œ
            altDB["R"] = new Dictionary<int, String> { { 1, "\u00AE" }, { 2, "\u2030" } }; // ® / ‰
            altDB["S"] = new Dictionary<int, String> { { 1, "\u00DF" }, { 2, "\u00CD" } }; // ß / Í
            altDB["T"] = new Dictionary<int, String> { { 1, "\u2020" }, { 2, "\u02C7" } }; // † / ˇ
            altDB["U"] = new Dictionary<int, String> { { 1, "\u00A8" }, { 2, "\u00A8" } }; // ¨ / ¨
            altDB["V"] = new Dictionary<int, String> { { 1, "\u221A" }, { 2, "\u25CA" } }; // √ / ◊
            altDB["W"] = new Dictionary<int, String> { { 1, "\u2211" }, { 2, "\u201E" } }; // ∑ / „
            altDB["X"] = new Dictionary<int, String> { { 1, "\u2248" }, { 2, "\u02DB" } }; // ≈ / ˛
            altDB["Y"] = new Dictionary<int, String> { { 1, "\u00A5" }, { 2, "\u00C1" } }; // ¥ / Á
            altDB["Z"] = new Dictionary<int, String> { { 1, "\u03A9" }, { 2, "\u00B8" } }; // Ω / ¸
            altDB["GRAVE"] = new Dictionary<int, String> { { 1, "\u0300" }, { 2, "~" } }; // combining grave / tilde
            altDB["["] = new Dictionary<int, String> { { 1, "\u201C" }, { 2, "\u201D" } }; // “ / ”
            altDB["]"] = new Dictionary<int, String> { { 1, "\u2018" }, { 2, "\u2019" } }; // ‘ / ’
            altDB["\\"] = new Dictionary<int, String> { { 1, "\u00AB" }, { 2, "\u00BB" } }; // « / »
            altDB[";"] = new Dictionary<int, String> { { 1, "\u2026" }, { 2, "\u00DA" } }; // … / Ú
            altDB["'"] = new Dictionary<int, String> { { 1, "\u00E6" }, { 2, "\u00C6" } }; // æ / Æ
            altDB[","] = new Dictionary<int, String> { { 1, "\u2264" }, { 2, "\u00AF" } }; // ≤ / macron
            altDB["."] = new Dictionary<int, String> { { 1, "\u2265" }, { 2, "\u02D8" } }; // ≥ / breve
            altDB["/"] = new Dictionary<int, String> { { 1, "\u00F7" }, { 2, "\u00BF" } }; // ÷ / inverted question mark
            altDB["SPACE"] = new Dictionary<int, String> { { 1, "\u00A0" } }; // non-breaking space

            altDB["A"][3] = "\u0104"; // Ą - ogonek
            altDB["A"][4] = "\u0102"; // Ă - breve
            altDB["A"][5] = "\u01FA"; // Ǻ - ring above and acute
            altDB["E"][3] = "\u0118"; // Ę - ogonek
            altDB["E"][4] = "\u0116"; // Ė - dot above
            altDB["E"][5] = "\u0114"; // Ĕ - breve
            altDB["I"][3] = "\u012E"; // Į - ogonek
            altDB["I"][4] = "\u0130"; // İ - dot above
            altDB["I"][5] = "\u0128"; // Ĩ - tilde
            altDB["O"][3] = "\u00D5"; // Õ - tilde
            altDB["O"][4] = "\u0150"; // Ő - double acute
            altDB["O"][5] = "\u014E"; // Ŏ - breve
            altDB["O"][6] = "\u01EA"; // Ǫ - ogonek
            altDB["U"][3] = "\u016E"; // Ů - ring above
            altDB["U"][4] = "\u0170"; // Ű - double acute
            altDB["U"][5] = "\u0172"; // Ų - ogonek
            altDB["U"][6] = "\u0168"; // Ũ - tilde
            altDB["U"][7] = "\u016C"; // Ŭ - breve
            altDB["N"][3] = "\u014A"; // Ŋ - eng
            altDB["N"][4] = "\u01F8"; // Ǹ - grave

            altDB["a"][3] = "\u0105"; // ą - ogonek
            altDB["a"][4] = "\u0103"; // ă - breve
            altDB["a"][5] = "\u01FB"; // ǻ - ring above and acute
            altDB["e"][3] = "\u0119"; // ę - ogonek
            altDB["e"][4] = "\u0117"; // ė - dot above
            altDB["e"][5] = "\u0115"; // ĕ - breve
            altDB["i"][3] = "\u012F"; // į - ogonek
            altDB["i"][4] = "\u0131"; // ı - dotless i
            altDB["i"][5] = "\u0129"; // ĩ - tilde
            altDB["o"][3] = "\u00F5"; // õ - tilde
            altDB["o"][4] = "\u0151"; // ő - double acute
            altDB["o"][5] = "\u014F"; // ŏ - breve
            altDB["o"][6] = "\u01EB"; // ǫ - ogonek
            altDB["u"][3] = "\u016F"; // ů - ring above
            altDB["u"][4] = "\u0171"; // ű - double acute
            altDB["u"][5] = "\u0173"; // ų - ogonek
            altDB["u"][6] = "\u0169"; // ũ - tilde
            altDB["u"][7] = "\u016D"; // ŭ - breve
            altDB["n"][3] = "\u014B"; // ŋ - eng
            altDB["n"][4] = "\u01F9"; // ǹ - grave
        }
    }
}
