using System.Collections.Generic;

namespace BusinessLayer.Common
{
    public interface ITranslateAlgorithm
    {
        List<string> TranslateList(string input);
        string HeReader(string word);
        bool ThinFineFlourControl(string str);
        string AttachmentsControl(string str);
        List<string> ForeginWordList();
        string FirstSyllabicControl(string str);
    }
}