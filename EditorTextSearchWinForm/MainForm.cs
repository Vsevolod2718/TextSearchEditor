using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EditorTextSearchWinForm
{
    public partial class MainForm : Form, IMainForm
    {
        // черекз модификатор static делаем поле _cancelled общим для всех объектов класса MainForm. 
        // Дданное поле созданно для того чтобы досрочно останавливать поиск текста. 
        private static bool _cancelled = false;

        public MainForm()
        {
            InitializeComponent();


            ///////////////////////////////////// События текстового редактора /////////////////////////////////////
            _buttonSelectFile1.Click += ButtonSelectFile1_Click;
            _buttonOpenFile.Click += ButtonOpenFile_Click;
            _buttonSaveFile.Click += ButtonSaveFile_Click;
            // Собитие при изменении текста в текстового редактора
            _textBoxContent1.TextChanged += TextBoxContent1_TextChanged;
            // Событие при изменинии значения в NumericUpDown(в форме это размер шрифта)
            _numericUpDownFontTextEditor.ValueChanged += TextEditorSizeFont_ValueChanged;

            ////////////////////////////////////  События поиска ключевых слов //////////////////////////////////////
            _buttonWordsFind.Click += ButtonWordsFind_Click;
            _buttonReset.Click += ButtonReset_Click;
            _buttonSelectFileSearchWords.Click += ButtonSelectFileSearchWords_Click;
            // Событие при изменинии значения в NumericUpDown(в форме это размер шрифта)
            _numericUpDownFontSearchWords.ValueChanged += SearchWordsSizeFont_ValueChanged;
            // Событие во время нажатия кнопки "Очистить все поля"
            _buttonClearFieldsSearchWords.Click += ButtonClearFieldsSearchWords_Click;

            //////////////////////////////////// События поиска текста //////////////////////////////////////////////
            _buttonTextFind.Click += ButtonTextFind_Click;
            _buttonSelectFileSearchText.Click += ButtonSelectFileSearchText_Click;
            _buttonSaveSearch.Click += ButtonSaveSearch_Click;
            _buttonStopSearchText.Click += ButtonStopSearchText_Click;
            // Событие при изменинии значения в NumericUpDown(в форме это размер шрифта)
            _numericUpDownFontSearchText.ValueChanged += SearchTextSizeFont_ValueChanged;
            // Событие во время нажатия кнопки "Очистить все поля"
            _buttonClearFieldsSearchText.Click += ButtonClearFieldsSearchText_Click;
        }

        #region Обработчики событий текстового редактора

        // Обработчик кнопки "Выбрать файл" из Текстового редактороа.     
        private void ButtonSelectFile1_Click(object sender, EventArgs e)
        {
            // Объект класса OpenFileDialog включает диалоговое окно виндовс для открытия файла.
            OpenFileDialog dlg = new OpenFileDialog();
            // По умолчанию в окне выбора файла будут отображаться файлы формата txt
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            // Метод ShowDialog() при нажатии кнопки OK запускает общее диалоговое окно, 
            // в котором мы должны выбрать полное имя файла который не обходимо открыть.  
            // После нажатия кнопки OK выражение "dlg.ShowDialog() == DialogResult.OK" возврвщает true
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Свойство FileName возвращает полное имя файла, выбранного в диалоговом окне. 
                _textBoxFilePath.Text = dlg.FileName;

                if (FileSelectClick != null)
                {
                    FileSelectClick.Invoke(this, EventArgs.Empty);
                }
            }
        }
        // Обработчик выбора размера шрифта
        private void TextEditorSizeFont_ValueChanged(object sender, EventArgs e)
        {
            _textBoxContent1.Font = new Font("Calibri", (float)_numericUpDownFontTextEditor.Value);
        }
        // Обработчик кнопки "Открыть файл" из Текстового редактороа 
        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null)
            {
                FileOpenClick.Invoke(this, EventArgs.Empty);
            }
        }
        // Обработчик кнопки "Сохранить файл" из Текстового редактороа
        private void ButtonSaveFile_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null)
            {
                FileSaveClick.Invoke(this, EventArgs.Empty);
            }
        }
        // Обработчик при изменении содержимого файла в TexBox из Текстового редактороа
        private void TextBoxContent1_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null)
            {
                ContentChanged.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Обработчики событий поиска ключевых слов

        // Обработчик кнопки "Поиск" из поиска ключевых слов 
        private void ButtonWordsFind_Click(object sender, EventArgs e)
        {
            // В массив words помещаються все слова разделенные запятой
            string[] words = _tbSearchWords.Text.Split(',');

            foreach (string word in words)
            {
                int startIndex = 0;

                while (startIndex < _richTextBoxSearchWords.TextLength)
                {
                    int wordsStarIndex = _richTextBoxSearchWords.Find(word, startIndex, RichTextBoxFinds.None);

                    if (wordsStarIndex != -1)
                    {
                        _richTextBoxSearchWords.SelectionStart = wordsStarIndex;
                        _richTextBoxSearchWords.SelectionLength = word.Length;
                        _richTextBoxSearchWords.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {
                        break;
                    }

                    startIndex += wordsStarIndex + word.Length;
                }
            }
        }
        // Обработчик кнопки "Сбросить" из поиска ключевых слов 
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            _richTextBoxSearchWords.SelectionStart = 0;
            _richTextBoxSearchWords.SelectAll();
            _richTextBoxSearchWords.SelectionBackColor = Color.White;
        }
        // Обработчик кнопки "Выбрать файл" из поиска ключевых слов 
        private void ButtonSelectFileSearchWords_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Свойство FileName возвращает полное имя файла, выбранного в диалоговом окне. 
                _tbNameFaileSearchWords.Text = dlg.FileName;

                if (SelectFileSearchWordsClick != null)
                {
                    SelectFileSearchWordsClick.Invoke(this, EventArgs.Empty);
                }
            }
        }
        // Обработчик выбора размера шрифта 
        private void SearchWordsSizeFont_ValueChanged(object sender, EventArgs e)
        {
            _richTextBoxSearchWords.Font = new Font("Calibri", (float)_numericUpDownFontSearchWords.Value);
        }
        // Обработчик кнопки "Очистить все поля"
        private void ButtonClearFieldsSearchWords_Click(object sender, EventArgs e)
        {
            _tbNameFaileSearchWords.Text = "";
            _tbSearchWords.Text = "";
            _richTextBoxSearchWords.Text = "";
        }
        // Обработчик кнопки "Остановить поиск слов" 
        private void ButtonStopSearchWords_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region  Обработчики событий поиска текста 

        // Обработчик кнопки "Найти текст" из поиска текста 
        private void ButtonTextFind_Click(object sender, EventArgs e)
        {
            // Блок if включаеться только тогда когда в RichTextBox из 'поиска текста' занесен текст
            if (GetCountSymbols() > 0)
            {
                //Задаем новый поток для поиска символов в _richTextBoxSearchTex из "Поиска текста"
                Thread thread = new Thread(SymbolsSearchTextThread);
                // Запускаем метод SymbolsSearchTextThread(Object value) в другом потоке 
                thread.Start();
            }
            else
            {
                MessageBox.Show("Файл не выбран!");
            }
        }
        // Обработчик кнопки "Выбрать файл" из поиска текста 
        private void ButtonSelectFileSearchText_Click(object sender, EventArgs e)
        {
            // Обнуляем значение шкалы визуализации _progressBarSearchText
            _progressBarSearchText.Value = 0;
            // Сбрасываема показатель процента
            _labelProgressViewPercent.Text = "";


            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _tbNameFileSearchText.Text = dlg.FileName;

                if (SelectFileSearcTextClick != null)
                {
                    SelectFileSearcTextClick.Invoke(this, EventArgs.Empty);
                }
            }
        }
        // Обработчик кнопки "Сохранить результат поиска" из поиска текста
        private void ButtonSaveSearch_Click(object sender, EventArgs e)
        {
            if (SaveSearchResultClick != null)
            {
                SaveSearchResultClick.Invoke(this, EventArgs.Empty);
            }
        }
        // Обработчик выбора размера шрифта 
        private void SearchTextSizeFont_ValueChanged(object sender, EventArgs e)
        {
            _richTextBoxSearchText.Font = new Font("Calibri", (float)_numericUpDownFontSearchText.Value);
        }
        // Обработчик кнопки "Очистить все поля" 
        private void ButtonClearFieldsSearchText_Click(object sender, EventArgs e)
        {
            // Обнуляем значение шкалы визуализации _progressBarSearchText
            _progressBarSearchText.Value = 0;
            // Сбрасываема показатель процента
            _labelProgressViewPercent.Text = "";

            // Очистка имени файла 
            _tbNameFileSearchText.Text = "";
            // Очистка тектса поиска 
            _textBoxTextSearch.Text = "";
            // Очитска содержимого текста 
            _richTextBoxSearchText.Text = "";
            // обнуление визуального счетчика
            _labelWiewNumCoincidence.Text = "0";
        }
        // Обработчик кнопки "Остановить поиск текста" из поиска текста
        private void ButtonStopSearchText_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        #endregion

        #region реализация интерфейса IMainForm 

        ///////////////////////////////// Текстовый редактор /////////////////////////////////////

        public string FilePath
        {
            get
            {
                return _textBoxFilePath.Text;
            }
        }
        public string Content
        {
            get
            {
                return _textBoxContent1.Text;
            }

            set
            {
                _textBoxContent1.Text = value;
            }
        }
        public void SetSymbolCount(int count)
        {
            _fieldNumberChars.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler FileSelectClick;
        public event EventHandler ContentChanged;

        //////////////////////////////// Поиск ключевых слов /////////////////////////////////////

        public void SetTextSearchWords(string content)
        {
            _richTextBoxSearchWords.Text = content;
        }
        public string FilePathSearchWords
        {
            get
            {
                return _tbNameFaileSearchWords.Text;
            }
        }

        public event EventHandler SelectFileSearchWordsClick;

        //////////////////////////////// Поиск текста ////////////////////////////////////////////

        public string FilePathSearchText
        {
            get
            {
                return _tbNameFileSearchText.Text;
            }
        }
        public string TextSearch
        {
            get
            {
                return _textBoxTextSearch.Text;
            }
        }
        public void SetTextSearch(string content)
        {

            Action action = () =>
            {
                _richTextBoxSearchText.Text = content;
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();




        }
        public void SetCoincidenceCount(int count)
        {
            _labelWiewNumCoincidence.Text = count.ToString();
        }
        public string GetText
        {
            get
            {
                Func<String> func = () =>
                {
                    String richText = _richTextBoxSearchText.Text;

                    return richText;
                };

                if (InvokeRequired)
                    return (String)Invoke(func);
                else
                    return func();
            }
        }

        public event EventHandler FindTextClick;
        public event EventHandler SelectFileSearcTextClick;
        public event EventHandler SaveSearchResultClick;

        #endregion

        // Вызов данного метода принудительно останавливает процесс 
        public void Cancel()
        {
            _cancelled = true;
        }

        // Метод включает и выключает кнопки - "Найти текст", "Очистить все поля", "Выбрать файл"
        public void SwitchButtons(bool boolEnabled)
        {
            SwitchButtons(boolEnabled, _buttonTextFind, _buttonClearFieldsSearchText, _buttonSelectFileSearchText);
        }
        // Метод включает и выключает кнопки. 
        public void SwitchButtons(bool boolEnabled, params Button[] buttons)
        {
            Action action = () =>
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Enabled = boolEnabled;
                }
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        // Метод окрашивает в желтый цвет символы находящиеся в RichTextBox из поиска текста,
        // начинающиеся с позиции startPosition длинна которой равна lengthPosition.
        public void SymbolsWithColor(int startPosition, int lengthPosition)
        {
            SymbolsWithColor(startPosition, lengthPosition, _richTextBoxSearchText, Color.Yellow);
        }
        // Метод окрашивает в color цвет символы находящиеся в richTextBox,
        // начинающиеся с позиции startPosition длинна которой равна lengthPosition     
        public void SymbolsWithColor(int startPosition, int lengthPosition, RichTextBox richTextBox, Color color)
        {
            Action action = () =>
            {
                richTextBox.SelectionStart = startPosition;
                richTextBox.SelectionLength = lengthPosition;
                richTextBox.SelectionBackColor = color;
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        // Метод устанавливает минимальное и максимальное значение в ProgressBar из поиска текста
        public void SetMinMaxValueProgressBar(int min, int max)
        {
            SetMinMaxValueProgressBar(min, max, _progressBarSearchText);
        }
        // Метод устанавливает минимальное и максимальное значение ProgressBar
        public void SetMinMaxValueProgressBar(int min, int max, ProgressBar progressBar)
        {
            Action action = () =>
            {
                progressBar.Minimum = min;

                progressBar.Maximum = max;
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        // Метод вовращает количество символов помещенных в RichTextBox из 'поиска текста'.
        public int GetCountSymbols()
        {
            int count = GetCountSymbols(_richTextBoxSearchText);

            return count;
        }
        // Метод вовращает количество символов помещенных в RichTextBox.
        public int GetCountSymbols(RichTextBox countSymbols)
        {
            Func<int> func = () =>
            {
                int count = countSymbols.TextLength;

                return count;
            };

            if (InvokeRequired)
                return (int)Invoke(func);
            else
                return func();
        }

        // Метод изменяет линейку ProgressBar из поиска текста
        public void ProgressChange(int valueProgress)
        {
            ProgressChange(valueProgress, _progressBarSearchText);
        }
        // Метод изменяет линейку progressBar
        public void ProgressChange(int valueProgress, ProgressBar progress)
        {
            Action action = () =>
            {
                progress.Value = valueProgress + 1;

                progress.Value = valueProgress;
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        // Изменение показателя процента выполненой работы в поиске текста. 
        public void PercentChange(int numberProcessedItems, int totalNumberItems)
        {
            PercentChange(numberProcessedItems, totalNumberItems, _labelProgressViewPercent);
        }
        // Метод изменяет показатель процента выполненой работы и выносит его в viewlabel.
        // Параметр numberProcessedItems равен числу обработанных элеиентов.
        // Параметр totalNumberItems равен общему числу элементов которые должен обработать процесс.  
        public void PercentChange(int numberProcessedItems, int totalNumberItems, Label viewlabel)
        {
            Action action = () =>
            {
                int valuePercent = (numberProcessedItems * 101) / totalNumberItems;

                string strPercent = Convert.ToString(valuePercent) + '%';

                viewlabel.Text = strPercent;
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        // Метод возвращает символ находящийся в RichTextBox в позиции position из поиска текста
        public Char GetSymbol(int position)
        {
            char symbol = GetSymbol(position, _richTextBoxSearchText);

            return symbol;
        }
        // Метод возвращает символ находящийся в RichTextBox в позиции position. 
        public Char GetSymbol(int position, RichTextBox richText)
        {
            Func<Char> func = () =>
            {
                return richText.Text[position];
            };

            if (InvokeRequired)
                return (Char)Invoke(func);
            else
                return func();
        }

        // Очистка компонента RichTextBox из поиска текста
        public void ClearRichTextBox()
        {
            ClearRichTextBox(_richTextBoxSearchText);
        }
        // Очистка компонента RichTextBox
        public void ClearRichTextBox(RichTextBox richText)
        {
            Action action = () =>
            {
                richText.Clear();
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        // Метод осуществляет обработку всех символов находящихся в RichTextBox из поиска текста. 
        // Параметр value равен общему колличеству символов находящихся в _richTextBoxSearchText
        private void SymbolsSearchTextThread()
        {

            // Выключаем кнопки 
            SwitchButtons(false);

            if (FindTextClick != null)
            {

                // Для того что-бы всегда при нажатии кнопки "Найти текст" включался процесс поиска текста необходимо чтобы
                if (_cancelled)
                    _cancelled = false;

                // Вызываеться метод в котором происходит поиск текста, и результат поиска заноситься в RichTextBox 'Поиска текста'. 
                FindTextClick.Invoke(this, EventArgs.Empty);

                // Общее колличество символов в тексте помещенного в _richTextBoxSearchText
                int countChars = GetCountSymbols();

                // Устанавливаем минимальное и максимальное значение для ProgressBar из 'Поиска текста'
                SetMinMaxValueProgressBar(0, countChars);

                // Перебор и проверка всех символов 
                for (int i = 0; i < countChars; i++)
                {

                    if (_cancelled)
                        break;

                    char viewChar = GetSymbol(i);

                    bool isLowerChar = char.IsLower(viewChar);

                    if (!isLowerChar)
                    {
                        if (viewChar == 'А' || viewChar == 'Б' || viewChar == 'В' || viewChar == 'Г' || viewChar == 'Д' || viewChar == 'Е' || viewChar == 'Ё' || viewChar == 'Ж' || viewChar == 'З' || viewChar == 'И' || viewChar == 'Й' || viewChar == 'К' || viewChar == 'Л' || viewChar == 'М' || viewChar == 'Н' || viewChar == 'О' || viewChar == 'П' || viewChar == 'Р' || viewChar == 'С' || viewChar == 'Т' || viewChar == 'У' || viewChar == 'Ф' || viewChar == 'Х' || viewChar == 'Ц' || viewChar == 'Ч' || viewChar == 'Ш' || viewChar == 'Щ' || viewChar == 'Ъ' || viewChar == 'Ь' || viewChar == 'Ы' || viewChar == 'Э' || viewChar == 'Ю' || viewChar == 'Я')
                        {
                            SymbolsWithColor(i, 1);
                        }
                        else if (viewChar == 'A' || viewChar == 'B' || viewChar == 'C' || viewChar == 'D' || viewChar == 'E' || viewChar == 'F' || viewChar == 'G' || viewChar == 'H' || viewChar == 'I' || viewChar == 'J' || viewChar == 'K' || viewChar == 'L' || viewChar == 'M' || viewChar == 'М' || viewChar == 'N' || viewChar == 'O' || viewChar == 'P' || viewChar == 'Q' || viewChar == 'R' || viewChar == 'S' || viewChar == 'T' || viewChar == 'U' || viewChar == 'V' || viewChar == 'W' || viewChar == 'X' || viewChar == 'Y' || viewChar == 'Z')
                        {
                            SymbolsWithColor(i, 1);
                        }
                    }

                    PercentChange(i, countChars);

                    ProgressChange(i);
                }

                if (_cancelled)
                {
                    MessageBox.Show("Поиск текста остановлен!");

                    ClearRichTextBox();
                }
                else
                {
                    MessageBox.Show("Поиск текста завершен.");
                }

                // Включаем кнопки
                SwitchButtons(true);

            }

        }
    }

}

