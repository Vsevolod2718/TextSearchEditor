using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EditorTextSearchWinForm.Model;


namespace EditorTextSearchWinForm
{
    public class MainPresenter
    {
        private readonly IMainForm _mainForm;
        private readonly IFileManager _fileManager;
        private readonly IMessageService _messageService;

        private String _currentFilePath;

        private MainForm isException;

        public MainPresenter(IMainForm form, IFileManager manager, IMessageService service)
        {
            _mainForm = form;
            _fileManager = manager;
            _messageService = service;

            ////////////////////////////////////// Текстовый редактор  ////////////////////////////////////////

            // При включении формы колличество символов изначально равно нулю 
            _mainForm.SetSymbolCount(0);
            // Событию ContentChanged(изменение контента) приписываем метод выполнения _mainForm_ContentChanged()
            _mainForm.ContentChanged += MainForm_ContentChanged;
            // Событию FileOpenClick приписываем метод выполнения MainForm_FileOpenClick
            _mainForm.FileOpenClick += MainForm_FileOpenClick;
            // Событию FileSaveClick приписываем метод выполнения MainForm_FileSaveClick
            _mainForm.FileSaveClick += MainForm_FileSaveClick;

            ////////////////////////////////////// Поиск ключевых слов ////////////////////////////////////////

            _mainForm.SelectFileSearchWordsClick += MainForm_SelectFileSearchWordsClick;

            ////////////////////////////////////// Поиск текста ////////////////////////////////////////

            _mainForm.SetCoincidenceCount(0);

            _mainForm.SelectFileSearcTextClick += MainForm_SelectFileSearcTextClick;
            _mainForm.FindTextClick += MainForm_FindTextClick;
            _mainForm.SaveSearchResultClick += MainForm_SaveSearchResultClick;

        }

        #region Реализация событий интерфейса IMainForm 

        ////////////////////////////////////// Текстовый редактор  ////////////////////////////////////////

        // Метод возвращает колличество символов в содержимом файла
        private void MainForm_ContentChanged(object sender, EventArgs e)
        {
            string content = _mainForm.Content;

            int count = _fileManager.GetSimbolCount(content);

            _mainForm.SetSymbolCount(count);
        }
        // Метод открывает файл по адресу FilePath
        private void MainForm_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _mainForm.FilePath;
                bool isExist = _fileManager.IsExist(filePath);

                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбраный файл не существует.");
                    return;
                }

                // _currentFilePath Будет содержать адрес куда надо по умолчанию запоминать файл. 
                // Проще говоря измененый файл сохранится по тому же адресу с которого он и был открыт. 
                _currentFilePath = filePath;

                string content = _fileManager.GetContent(filePath);
                int count = _fileManager.GetSimbolCount(content);

                _mainForm.Content = content;
                _mainForm.SetSymbolCount(count);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
        // Метод сохраняет файл 
        private void MainForm_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _mainForm.Content;

                _fileManager.SaveContent(content, _currentFilePath);

                _messageService.ShowMessage("Файл успешно сохранен.");
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        ////////////////////////////////////// Поиск ключевых слов ////////////////////////////////////////

        // Метод помещает выбраный файл в содержимое richTextBox
        private void MainForm_SelectFileSearchWordsClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _mainForm.FilePathSearchWords;
                bool isExist = _fileManager.IsExist(filePath);

                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбраный файл не существует.");
                    return;
                }

                string content = _fileManager.GetContent(filePath);
                _mainForm.SetTextSearchWords(content);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }

        ////////////////////////////////////// Поиск текста ///////////////////////////////////////////

        // Метод помещает выбраный файл в содержимое richTextBox
        private void MainForm_SelectFileSearcTextClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _mainForm.FilePathSearchText;
                bool isExist = _fileManager.IsExist(filePath);

                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбраный файл не существует.");
                    return;
                }

                string content = _fileManager.GetContent(filePath);
                _mainForm.SetTextSearch(content);
            }
            catch (Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
        // Метод осуществляет поиск текста в содержимом файла, и результат поиска помещает в RichTextBox
        private void MainForm_FindTextClick(object sender, EventArgs e)
        {

            isException = new MainForm();

            try
            {
                // Свойство TextSearch возвращает текст поиска занесеный в TextBox 
                string searchString = _mainForm.TextSearch;
                // Свойство GetText возвращает строку из RichTextBox
                string content = _mainForm.GetText;


                string firstStr = "";
                string lastStr = " ";

                // Переменая для колличества совпадений 
                int count = 0;

                // переменная resultSearch содержит результат поиска строки  searchString в тексте content. 
                string resultSearch = _fileManager.GetSearchResultString(content, searchString, out count, firstStr, lastStr);

                _mainForm.SetTextSearch(resultSearch);
                _mainForm.SetCoincidenceCount(count);

            }
            catch (Exception ex)
            {
                _messageService.ShowExclamation(ex.Message);

                // Метод останавливает поиск текста
                isException.Cancel();
            }

        }
        // Метод сохраняет результат поиска 
        private void MainForm_SaveSearchResultClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Сохранение результата поиска строки";

            saveFileDialog.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // В переменную filename заносим полное имя выбранного файла (являющиеся адресом)
                string filePath = saveFileDialog.FileName;
                // Текст находящийся в richTextBox заносим в переменную content
                string content = _mainForm.GetText;
                // По адресу filePath сохраняем содержимое content
                _fileManager.SaveContent(content, filePath);

                _messageService.ShowMessage("Результат поиска успешно сохранен.");
            }
        }

        #endregion

    }
}
