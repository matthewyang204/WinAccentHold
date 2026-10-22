using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinAccentHold
{
    class AccentDB
    {
        public Dictionary<String, Dictionary<int, String>> mainDB;

        public AccentDB()
        {
            mainDB = new Dictionary<String, Dictionary<int, String>>();

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
        }
    }
}
