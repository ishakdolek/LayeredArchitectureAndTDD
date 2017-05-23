using System.Collections.Generic;

namespace BusinessLayer.Common
{
    public class TranslateAlgorithm : ITranslateAlgorithm
    {
        readonly List<string> _translateOsmanlica = new List<string>();
        readonly List<string> _kelimeler = new List<string>();
        public List<string> ForeignWord = new List<string>();
        public string Kelime;
        public static int Counter;
        char[] _hece;
        public bool _dogru;
        public TranslateAlgorithm(char[] hece)
        {
            this._hece = hece;
        }
        public List<string> TranslateList(string input)
        {
            input = input.ToLower();
            var word = input.Split(' ');
            foreach (var item in word)
            {
                _kelimeler.Add(item.Trim());
            }

            foreach (var item in _kelimeler)
            {
                if (item != "")
                {

                    var kontrol = ThinFineFlourControl(item);
                    Kelime = item;
                    Kelime = AttachmentsControl(Kelime);

                    Kelime = HeReader(Kelime);

                    if (kontrol == true)
                    {
                        _translateOsmanlica.Add(Kelime
                       .Replace('t', 'ط')
                       .Replace('d', 'ط')
                       .Replace('ğ', 'غ')
                       .Replace('s', 'ص')
                       .Replace('k', 'ق')
                       .Replace('a', 'ا')
                       .Replace('b', 'ب')
                       .Replace('m', 'م')
                       .Replace('y', 'ي')
                       .Replace('ş', 'ش')
                       .Replace('c', 'ج')
                       .Replace('p', 'پ')
                       .Replace('ç', 'چ')
                       .Replace('z', 'ز')
                       .Replace('j', 'ژ')
                       .Replace('l', 'ل')
                       .Replace('n', 'ن')
                       .Replace('v', 'و')
                       .Replace('r', 'ر')
                       .Replace('f', 'ف')
                       .Replace('ı', 'ي')
                       .Replace('g', 'غ')
                       .Replace('h', 'ح')
                       .Replace('o', 'و')
                       .Replace('e', 'ه')
                       .Replace('i', 'ي')
                       .Replace('u', 'و'));
                    }
                    else
                    {
                        _translateOsmanlica.Add(Kelime
                        .Replace('a', 'ا')
                        .Replace('ğ', 'گ')
                        .Replace('s', 'س')
                        .Replace('h', 'ه')
                        .Replace('v', 'و')
                        .Replace('k', 'ك')
                        .Replace('t', 'ت')
                        .Replace('d', 'د')
                        .Replace('b', 'ب')
                        .Replace('m', 'م')
                        .Replace('y', 'ي')
                        .Replace('ş', 'ش')
                        .Replace('c', 'ج')
                        .Replace('p', 'پ')
                        .Replace('ç', 'چ')
                        .Replace('z', 'ز')
                        .Replace('j', 'ژ')
                        .Replace('l', 'ل')
                        .Replace('n', 'ن')
                        .Replace('v', 'و')
                        .Replace('r', 'ر')
                        .Replace('f', 'ف')
                        .Replace('e', 'ه')
                        .Replace('i', 'ي')
                        .Replace('g', 'گ')
                        .Replace('ü', 'و')
                        .Replace('ö', 'و'));
                    }


                }
            }
            return _translateOsmanlica;

        }
        public string HeReader(string word)
        {
            char[] heOkutucusu = word.ToCharArray();

            if (heOkutucusu[heOkutucusu.Length - 1] == 'e')
            {

                word = word.Replace("e", "") + "e";

            }
            else
            {
                word = word.Replace("e", "");
            }

            return word;
        }
        public bool ThinFineFlourControl(string item)
        {

            var ara = item.ToCharArray();
            _dogru = false;
            foreach (var t in ara)
            {
                if (t != 'a' && t != 'ı' && t != 'o' && t != 'u') continue;
                _dogru = true;
                break;
            }
            return _dogru;
        }
        public string AttachmentsControl(string str)
        {
            str =FirstSyllabicControl(str);

            var kelimeUzunluk = str.Length;
            if (kelimeUzunluk > 8)
            {
                var gelenEk = str.Substring(kelimeUzunluk - 6);
                var gelenKelime = str.Substring(0, str.Length - 6);
                var ekUzunluk = gelenEk.Length;

                if (ekUzunluk == 6)
                {
                    if (gelenEk == "muştur" || gelenEk == "müştür" || gelenEk == "mıştır" || gelenEk == "miştir")
                    {
                        gelenEk = gelenEk.Replace("muştur", "مشدر").Replace("müştür", "مشدر").Replace("miştir", "مشدر").Replace("mıştır", "مشدر").Replace("temmuz", "تموز");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }

                }
            }
            if (kelimeUzunluk > 7)
            {
                var gelenEk = str.Substring(kelimeUzunluk - 5);
                var gelenKelime = str.Substring(0, str.Length - 5);
                var ekUzunluk = gelenEk.Length;

                if (ekUzunluk == 5)
                {

                    if (gelenEk == "liğin" || gelenEk == "lığın")
                    {
                        gelenEk = gelenEk.Replace("liğin", "لگك").Replace("lığın", "لغك");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }

                }
            }


            if (kelimeUzunluk > 6)
            {
                var gelenEk = str.Substring(kelimeUzunluk - 4);
                var gelenKelime = str.Substring(0, str.Length - 4);
                var ekUzunluk = gelenEk.Length;

                if (ekUzunluk == 4)
                {

                    if (gelenEk == "sine" || gelenEk == "sına")
                    {
                        gelenEk = gelenEk.Replace("sine", "سنه").Replace("sına", "سنه");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                    else if (gelenEk == "meyi" || gelenEk == "mayı")
                    {
                        gelenEk = gelenEk.Replace("meyi", "میی").Replace("mayı", "میی");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                    else if (gelenEk == "ları")
                    {
                        gelenEk = gelenEk.Replace("ları", "لری");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }

                }
            }

            if (kelimeUzunluk > 5)
            {
                var gelenEk = str.Substring(kelimeUzunluk - 3);
                var gelenKelime = str.Substring(0, str.Length - 3);
                var ekUzunluk = gelenEk.Length;
                if (ekUzunluk == 3)
                {

                    if (gelenEk == "miş" || gelenEk == "mış" || gelenEk == "muş" || gelenEk == "müş")
                    {
                        gelenEk = gelenEk.Replace("miş", "مش").Replace("mış", "مش").Replace("muş", "مش").Replace("müş", "مش");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                    else if (gelenEk == "tir" || gelenEk == "tır" || gelenEk == "tur" || gelenEk == "tür" || gelenEk == "dir" || gelenEk == "dır" || gelenEk == "dur" || gelenEk == "dür")
                    {
                        gelenEk = gelenEk.Replace("tir", "در").Replace("tır", "در").Replace("tur", "در").Replace("tür", "در")
                                         .Replace("dir", "در").Replace("dır", "در").Replace("dur", "در").Replace("dür", "در");
                        str = gelenKelime + gelenEk;
                    }
                    else if (gelenEk == "lik" || gelenEk == "lık")
                    {
                        gelenEk = gelenEk.Replace("lik", "لك").Replace("lık", "لق");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                    else if (gelenEk == "nın" || gelenEk == "nin" || gelenEk == "nun" || gelenEk == "nün")
                    {
                        gelenEk = gelenEk.Replace("nin", "نك").Replace("nin", "نك").Replace("nın", "نك").Replace("nun", "نك").Replace("nün", "نك");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }

                }
            }

            if (kelimeUzunluk > 4)
            {

                string gelenEk = str.Substring(kelimeUzunluk - 2);
                string gelenKelime = str.Substring(0, str.Length - 2);
                int ekUzunluk = gelenEk.Length;

                if (ekUzunluk == 2)
                {
                    if (gelenEk == "da" || gelenEk == "de" || gelenEk == "ta" || gelenEk == "te")
                    {
                        gelenEk = gelenEk.Replace("da", "ده").Replace("de", "ده").Replace("ta", "ده").Replace("te", "ده");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                    else if (gelenEk == "le" || gelenEk == "la")
                    {
                        gelenEk = gelenEk.Replace("le", "له").Replace("la", "له");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                    else if (gelenEk == "ya" || gelenEk == "ye")
                    {
                        gelenEk = gelenEk.Replace("ye", "یه").Replace("ya", "یه");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                    else if (gelenEk == "ce" || gelenEk == "ça" || gelenEk == "ca" || gelenEk == "çe")
                    {
                        gelenEk = gelenEk.Replace("ce", "جه").Replace("ca", "جه").Replace("çe", "چه").Replace("ça", "چه");
                        str = gelenKelime + gelenEk;
                        ForeignWord.Add(gelenKelime);
                    }
                }
            }
            return str;
        }
        public List<string> ForeginWordList()
        {
            throw new System.NotImplementedException();
        }
        public string FirstSyllabicControl(string str)
        {
            char[] heceleme = str.ToCharArray();
            if (heceleme[0] == 'e')
            {
                str = "a" + str.Substring(1);
            }
            else if (heceleme[0] == 'i' || heceleme[0] == 'ı')
            {
                str = "ay" + str.Substring(1);

            }
            else if (heceleme[0] == 'o' || heceleme[0] == 'u' || heceleme[0] == 'ü' || heceleme[0] == 'ö')
            {
                str = "av" + str.Substring(1);
            }

            return str;
        }
    }
}

