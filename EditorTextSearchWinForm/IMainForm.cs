using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorTextSearchWinForm
{
    public interface IMainForm
    {
        #region Текстовый редактор

        // Свойство возвращает строку из textBox "Путь к файлу"
        string FilePath { get; }
        // Свойство возвращает и задает строку в содержимое TextBox который отображает содержисмое файла
        string Content { get; set; }
        // Данный метод получает в параметр колличество символов в содержимом текстового файла
        void SetSymbolCount(int count);

        // Событие на кнопку "Открыть файл" в текстовом редакторе 
        event EventHandler FileOpenClick;
        // Событие на кнопку "Сохранить файл" в текстовом редакторе 
        event EventHandler FileSaveClick;
        // Событие на кнпку "Выбрать файл" в текстовом редакторе 
        event EventHandler FileSelectClick;
        // Событие при изменении содержимого файла в текстовом редакторе 
        event EventHandler ContentChanged;

        #endregion

        #region Поиск ключевых слов 

        // Содержимое параметра content помещаеться в richTextBox
        void SetTextSearchWords(string content);
        // Свойство возвращает строку из textBox "Имя файла"
        string FilePathSearchWords { get; }

        // Событие на кнопку "Выбрать файл" из поиск ключевых слов
        event EventHandler SelectFileSearchWordsClick;

        #endregion

        #region Поиск текста

        // Свойство возвращает строку из textBox "Имя файла"
        string FilePathSearchText { get; }
        // Свойство возвращает текст поиска занесеный в TextBox текст поиска
        string TextSearch { get; }
        // Метод помещает содержимое content в RichTextBox
        void SetTextSearch(string content);
        // Свойство возвращает строку из RichTextBox
        string GetText { get; }
        // Метод получает в параметр колличество совпадений строк поиска в тексте
        void SetCoincidenceCount(int count);

        // Событие на кнопку "Найти текст" из поиск текста 
        event EventHandler FindTextClick;
        // Событие на кнопку "Выбрать файл" из поиск текста
        event EventHandler SelectFileSearcTextClick;
        // Событие на кнопку "Сохранить результат поиска" из поиск текста 
        event EventHandler SaveSearchResultClick;

        #endregion
    }
}

