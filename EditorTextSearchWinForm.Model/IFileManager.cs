using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorTextSearchWinForm.Model
{
    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string content, string filePath);
        void SaveContent(string content, string filePath, Encoding encoding);
        string GetSearchResultString(string content, string searchString, out int searchCoincidenceCount, string firstStr, string lastStr);
        int GetSimbolCount(string content);
        bool IsExist(string filePath);
    }
}
