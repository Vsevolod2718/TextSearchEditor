namespace EditorTextSearchWinForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tabControlTextModes = new System.Windows.Forms.TabControl();
            this._tabPageTextEditor = new System.Windows.Forms.TabPage();
            this._statusStripCountChars = new System.Windows.Forms.StatusStrip();
            this._labelNumberChars = new System.Windows.Forms.ToolStripStatusLabel();
            this._fieldNumberChars = new System.Windows.Forms.ToolStripStatusLabel();
            this._buttonSaveFile = new System.Windows.Forms.Button();
            this._textBoxContent1 = new System.Windows.Forms.TextBox();
            this._labelFontSize1 = new System.Windows.Forms.Label();
            this._numericUpDownFontTextEditor = new System.Windows.Forms.NumericUpDown();
            this._buttonOpenFile = new System.Windows.Forms.Button();
            this._buttonSelectFile1 = new System.Windows.Forms.Button();
            this._textBoxFilePath = new System.Windows.Forms.TextBox();
            this._labelFilePath = new System.Windows.Forms.Label();
            this._tabPageWordsFind = new System.Windows.Forms.TabPage();
            this._buttonClearFieldsSearchWords = new System.Windows.Forms.Button();
            this._tbNameFaileSearchWords = new System.Windows.Forms.TextBox();
            this._labelNameFileSearchWords = new System.Windows.Forms.Label();
            this._buttonReset = new System.Windows.Forms.Button();
            this._numericUpDownFontSearchWords = new System.Windows.Forms.NumericUpDown();
            this._labelFontSize2 = new System.Windows.Forms.Label();
            this._buttonSelectFileSearchWords = new System.Windows.Forms.Button();
            this._buttonWordsFind = new System.Windows.Forms.Button();
            this._tbSearchWords = new System.Windows.Forms.TextBox();
            this._labelSearchWords = new System.Windows.Forms.Label();
            this._richTextBoxSearchWords = new System.Windows.Forms.RichTextBox();
            this._tabPageTextFind = new System.Windows.Forms.TabPage();
            this._buttonStopSearchText = new System.Windows.Forms.Button();
            this._labelProgressViewPercent = new System.Windows.Forms.Label();
            this._progressBarSearchText = new System.Windows.Forms.ProgressBar();
            this._buttonClearFieldsSearchText = new System.Windows.Forms.Button();
            this._tbNameFileSearchText = new System.Windows.Forms.TextBox();
            this._labelNameFileSearchText = new System.Windows.Forms.Label();
            this._statusStripCount = new System.Windows.Forms.StatusStrip();
            this._labelNubberCoincidence = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelWiewNumCoincidence = new System.Windows.Forms.ToolStripStatusLabel();
            this._buttonSelectFileSearchText = new System.Windows.Forms.Button();
            this._buttonSaveSearch = new System.Windows.Forms.Button();
            this._richTextBoxSearchText = new System.Windows.Forms.RichTextBox();
            this._numericUpDownFontSearchText = new System.Windows.Forms.NumericUpDown();
            this._labelFontSize3 = new System.Windows.Forms.Label();
            this._buttonTextFind = new System.Windows.Forms.Button();
            this._textBoxTextSearch = new System.Windows.Forms.TextBox();
            this._labelTextSearср = new System.Windows.Forms.Label();
            this._tabControlTextModes.SuspendLayout();
            this._tabPageTextEditor.SuspendLayout();
            this._statusStripCountChars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownFontTextEditor)).BeginInit();
            this._tabPageWordsFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownFontSearchWords)).BeginInit();
            this._tabPageTextFind.SuspendLayout();
            this._statusStripCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownFontSearchText)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabControlTextModes
            // 
            this._tabControlTextModes.Controls.Add(this._tabPageTextEditor);
            this._tabControlTextModes.Controls.Add(this._tabPageWordsFind);
            this._tabControlTextModes.Controls.Add(this._tabPageTextFind);
            this._tabControlTextModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControlTextModes.Location = new System.Drawing.Point(0, 0);
            this._tabControlTextModes.Name = "_tabControlTextModes";
            this._tabControlTextModes.SelectedIndex = 0;
            this._tabControlTextModes.Size = new System.Drawing.Size(773, 483);
            this._tabControlTextModes.TabIndex = 0;
            // 
            // _tabPageTextEditor
            // 
            this._tabPageTextEditor.BackColor = System.Drawing.Color.WhiteSmoke;
            this._tabPageTextEditor.Controls.Add(this._statusStripCountChars);
            this._tabPageTextEditor.Controls.Add(this._buttonSaveFile);
            this._tabPageTextEditor.Controls.Add(this._textBoxContent1);
            this._tabPageTextEditor.Controls.Add(this._labelFontSize1);
            this._tabPageTextEditor.Controls.Add(this._numericUpDownFontTextEditor);
            this._tabPageTextEditor.Controls.Add(this._buttonOpenFile);
            this._tabPageTextEditor.Controls.Add(this._buttonSelectFile1);
            this._tabPageTextEditor.Controls.Add(this._textBoxFilePath);
            this._tabPageTextEditor.Controls.Add(this._labelFilePath);
            this._tabPageTextEditor.Location = new System.Drawing.Point(4, 22);
            this._tabPageTextEditor.Name = "_tabPageTextEditor";
            this._tabPageTextEditor.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageTextEditor.Size = new System.Drawing.Size(765, 457);
            this._tabPageTextEditor.TabIndex = 1;
            this._tabPageTextEditor.Text = "Текстовый редактор";
            // 
            // _statusStripCountChars
            // 
            this._statusStripCountChars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._labelNumberChars,
            this._fieldNumberChars});
            this._statusStripCountChars.Location = new System.Drawing.Point(3, 432);
            this._statusStripCountChars.Name = "_statusStripCountChars";
            this._statusStripCountChars.Size = new System.Drawing.Size(759, 22);
            this._statusStripCountChars.TabIndex = 8;
            this._statusStripCountChars.Text = "statusStrip1";
            // 
            // _labelNumberChars
            // 
            this._labelNumberChars.ActiveLinkColor = System.Drawing.Color.Black;
            this._labelNumberChars.Name = "_labelNumberChars";
            this._labelNumberChars.Size = new System.Drawing.Size(137, 17);
            this._labelNumberChars.Text = "Колличество символов";
            // 
            // _fieldNumberChars
            // 
            this._fieldNumberChars.ActiveLinkColor = System.Drawing.Color.Black;
            this._fieldNumberChars.Name = "_fieldNumberChars";
            this._fieldNumberChars.Size = new System.Drawing.Size(0, 17);
            // 
            // _buttonSaveFile
            // 
            this._buttonSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSaveFile.Location = new System.Drawing.Point(651, 33);
            this._buttonSaveFile.Name = "_buttonSaveFile";
            this._buttonSaveFile.Size = new System.Drawing.Size(106, 23);
            this._buttonSaveFile.TabIndex = 7;
            this._buttonSaveFile.Text = "Сохранить файл";
            this._buttonSaveFile.UseVisualStyleBackColor = true;
            // 
            // _textBoxContent1
            // 
            this._textBoxContent1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxContent1.Location = new System.Drawing.Point(8, 62);
            this._textBoxContent1.MaxLength = 65535;
            this._textBoxContent1.Multiline = true;
            this._textBoxContent1.Name = "_textBoxContent1";
            this._textBoxContent1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._textBoxContent1.Size = new System.Drawing.Size(749, 364);
            this._textBoxContent1.TabIndex = 6;
            // 
            // _labelFontSize1
            // 
            this._labelFontSize1.AutoSize = true;
            this._labelFontSize1.Location = new System.Drawing.Point(42, 38);
            this._labelFontSize1.Name = "_labelFontSize1";
            this._labelFontSize1.Size = new System.Drawing.Size(41, 13);
            this._labelFontSize1.TabIndex = 5;
            this._labelFontSize1.Text = "Шрифт";
            // 
            // _numericUpDownFontTextEditor
            // 
            this._numericUpDownFontTextEditor.Location = new System.Drawing.Point(89, 36);
            this._numericUpDownFontTextEditor.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this._numericUpDownFontTextEditor.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this._numericUpDownFontTextEditor.Name = "_numericUpDownFontTextEditor";
            this._numericUpDownFontTextEditor.Size = new System.Drawing.Size(120, 20);
            this._numericUpDownFontTextEditor.TabIndex = 4;
            this._numericUpDownFontTextEditor.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // _buttonOpenFile
            // 
            this._buttonOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonOpenFile.Location = new System.Drawing.Point(549, 33);
            this._buttonOpenFile.Name = "_buttonOpenFile";
            this._buttonOpenFile.Size = new System.Drawing.Size(96, 23);
            this._buttonOpenFile.TabIndex = 3;
            this._buttonOpenFile.Text = "Открыть файл";
            this._buttonOpenFile.UseVisualStyleBackColor = true;
            // 
            // _buttonSelectFile1
            // 
            this._buttonSelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSelectFile1.Location = new System.Drawing.Point(444, 33);
            this._buttonSelectFile1.Name = "_buttonSelectFile1";
            this._buttonSelectFile1.Size = new System.Drawing.Size(99, 23);
            this._buttonSelectFile1.TabIndex = 2;
            this._buttonSelectFile1.Text = "Выбрать файл";
            this._buttonSelectFile1.UseVisualStyleBackColor = true;
            // 
            // _textBoxFilePath
            // 
            this._textBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxFilePath.Location = new System.Drawing.Point(89, 6);
            this._textBoxFilePath.Name = "_textBoxFilePath";
            this._textBoxFilePath.Size = new System.Drawing.Size(668, 20);
            this._textBoxFilePath.TabIndex = 1;
            // 
            // _labelFilePath
            // 
            this._labelFilePath.AutoSize = true;
            this._labelFilePath.Location = new System.Drawing.Point(9, 9);
            this._labelFilePath.Name = "_labelFilePath";
            this._labelFilePath.Size = new System.Drawing.Size(74, 13);
            this._labelFilePath.TabIndex = 0;
            this._labelFilePath.Text = "Путь к файлу";
            // 
            // _tabPageWordsFind
            // 
            this._tabPageWordsFind.BackColor = System.Drawing.Color.WhiteSmoke;
            this._tabPageWordsFind.Controls.Add(this._buttonClearFieldsSearchWords);
            this._tabPageWordsFind.Controls.Add(this._tbNameFaileSearchWords);
            this._tabPageWordsFind.Controls.Add(this._labelNameFileSearchWords);
            this._tabPageWordsFind.Controls.Add(this._buttonReset);
            this._tabPageWordsFind.Controls.Add(this._numericUpDownFontSearchWords);
            this._tabPageWordsFind.Controls.Add(this._labelFontSize2);
            this._tabPageWordsFind.Controls.Add(this._buttonSelectFileSearchWords);
            this._tabPageWordsFind.Controls.Add(this._buttonWordsFind);
            this._tabPageWordsFind.Controls.Add(this._tbSearchWords);
            this._tabPageWordsFind.Controls.Add(this._labelSearchWords);
            this._tabPageWordsFind.Controls.Add(this._richTextBoxSearchWords);
            this._tabPageWordsFind.Location = new System.Drawing.Point(4, 22);
            this._tabPageWordsFind.Name = "_tabPageWordsFind";
            this._tabPageWordsFind.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageWordsFind.Size = new System.Drawing.Size(765, 457);
            this._tabPageWordsFind.TabIndex = 2;
            this._tabPageWordsFind.Text = "Поиск ключевых слов";
            // 
            // _buttonClearFieldsSearchWords
            // 
            this._buttonClearFieldsSearchWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClearFieldsSearchWords.Location = new System.Drawing.Point(535, 63);
            this._buttonClearFieldsSearchWords.Name = "_buttonClearFieldsSearchWords";
            this._buttonClearFieldsSearchWords.Size = new System.Drawing.Size(115, 23);
            this._buttonClearFieldsSearchWords.TabIndex = 12;
            this._buttonClearFieldsSearchWords.Text = "Очистить все поля";
            this._buttonClearFieldsSearchWords.UseVisualStyleBackColor = true;
            // 
            // _tbNameFaileSearchWords
            // 
            this._tbNameFaileSearchWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbNameFaileSearchWords.Location = new System.Drawing.Point(93, 7);
            this._tbNameFaileSearchWords.Name = "_tbNameFaileSearchWords";
            this._tbNameFaileSearchWords.Size = new System.Drawing.Size(663, 20);
            this._tbNameFaileSearchWords.TabIndex = 11;
            // 
            // _labelNameFileSearchWords
            // 
            this._labelNameFileSearchWords.AutoSize = true;
            this._labelNameFileSearchWords.Location = new System.Drawing.Point(20, 10);
            this._labelNameFileSearchWords.Name = "_labelNameFileSearchWords";
            this._labelNameFileSearchWords.Size = new System.Drawing.Size(67, 13);
            this._labelNameFileSearchWords.TabIndex = 10;
            this._labelNameFileSearchWords.Text = "Имя Файла";
            // 
            // _buttonReset
            // 
            this._buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonReset.Location = new System.Drawing.Point(681, 34);
            this._buttonReset.Name = "_buttonReset";
            this._buttonReset.Size = new System.Drawing.Size(75, 23);
            this._buttonReset.TabIndex = 9;
            this._buttonReset.Text = "Сбросить";
            this._buttonReset.UseVisualStyleBackColor = true;
            // 
            // _numericUpDownFontSearchWords
            // 
            this._numericUpDownFontSearchWords.Location = new System.Drawing.Point(93, 63);
            this._numericUpDownFontSearchWords.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this._numericUpDownFontSearchWords.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this._numericUpDownFontSearchWords.Name = "_numericUpDownFontSearchWords";
            this._numericUpDownFontSearchWords.Size = new System.Drawing.Size(120, 20);
            this._numericUpDownFontSearchWords.TabIndex = 8;
            this._numericUpDownFontSearchWords.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // _labelFontSize2
            // 
            this._labelFontSize2.AutoSize = true;
            this._labelFontSize2.Location = new System.Drawing.Point(46, 68);
            this._labelFontSize2.Name = "_labelFontSize2";
            this._labelFontSize2.Size = new System.Drawing.Size(41, 13);
            this._labelFontSize2.TabIndex = 7;
            this._labelFontSize2.Text = "Шрифт";
            // 
            // _buttonSelectFileSearchWords
            // 
            this._buttonSelectFileSearchWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSelectFileSearchWords.Location = new System.Drawing.Point(656, 63);
            this._buttonSelectFileSearchWords.Name = "_buttonSelectFileSearchWords";
            this._buttonSelectFileSearchWords.Size = new System.Drawing.Size(100, 23);
            this._buttonSelectFileSearchWords.TabIndex = 5;
            this._buttonSelectFileSearchWords.Text = "Выбрать файл";
            this._buttonSelectFileSearchWords.UseVisualStyleBackColor = true;
            // 
            // _buttonWordsFind
            // 
            this._buttonWordsFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonWordsFind.Location = new System.Drawing.Point(606, 34);
            this._buttonWordsFind.Name = "_buttonWordsFind";
            this._buttonWordsFind.Size = new System.Drawing.Size(69, 23);
            this._buttonWordsFind.TabIndex = 3;
            this._buttonWordsFind.Text = "Поиск";
            this._buttonWordsFind.UseVisualStyleBackColor = true;
            // 
            // _tbSearchWords
            // 
            this._tbSearchWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbSearchWords.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbSearchWords.Location = new System.Drawing.Point(93, 34);
            this._tbSearchWords.Name = "_tbSearchWords";
            this._tbSearchWords.Size = new System.Drawing.Size(507, 23);
            this._tbSearchWords.TabIndex = 2;
            // 
            // _labelSearchWords
            // 
            this._labelSearchWords.AutoSize = true;
            this._labelSearchWords.Location = new System.Drawing.Point(10, 39);
            this._labelSearchWords.Name = "_labelSearchWords";
            this._labelSearchWords.Size = new System.Drawing.Size(77, 13);
            this._labelSearchWords.TabIndex = 1;
            this._labelSearchWords.Text = "Искать слова";
            // 
            // _richTextBoxSearchWords
            // 
            this._richTextBoxSearchWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._richTextBoxSearchWords.BackColor = System.Drawing.SystemColors.Window;
            this._richTextBoxSearchWords.ForeColor = System.Drawing.SystemColors.WindowText;
            this._richTextBoxSearchWords.Location = new System.Drawing.Point(8, 92);
            this._richTextBoxSearchWords.Name = "_richTextBoxSearchWords";
            this._richTextBoxSearchWords.ReadOnly = true;
            this._richTextBoxSearchWords.Size = new System.Drawing.Size(748, 357);
            this._richTextBoxSearchWords.TabIndex = 0;
            this._richTextBoxSearchWords.Text = "";
            // 
            // _tabPageTextFind
            // 
            this._tabPageTextFind.BackColor = System.Drawing.Color.WhiteSmoke;
            this._tabPageTextFind.Controls.Add(this._buttonStopSearchText);
            this._tabPageTextFind.Controls.Add(this._labelProgressViewPercent);
            this._tabPageTextFind.Controls.Add(this._progressBarSearchText);
            this._tabPageTextFind.Controls.Add(this._buttonClearFieldsSearchText);
            this._tabPageTextFind.Controls.Add(this._tbNameFileSearchText);
            this._tabPageTextFind.Controls.Add(this._labelNameFileSearchText);
            this._tabPageTextFind.Controls.Add(this._statusStripCount);
            this._tabPageTextFind.Controls.Add(this._buttonSelectFileSearchText);
            this._tabPageTextFind.Controls.Add(this._buttonSaveSearch);
            this._tabPageTextFind.Controls.Add(this._richTextBoxSearchText);
            this._tabPageTextFind.Controls.Add(this._numericUpDownFontSearchText);
            this._tabPageTextFind.Controls.Add(this._labelFontSize3);
            this._tabPageTextFind.Controls.Add(this._buttonTextFind);
            this._tabPageTextFind.Controls.Add(this._textBoxTextSearch);
            this._tabPageTextFind.Controls.Add(this._labelTextSearср);
            this._tabPageTextFind.Location = new System.Drawing.Point(4, 22);
            this._tabPageTextFind.Name = "_tabPageTextFind";
            this._tabPageTextFind.Padding = new System.Windows.Forms.Padding(3);
            this._tabPageTextFind.Size = new System.Drawing.Size(765, 457);
            this._tabPageTextFind.TabIndex = 3;
            this._tabPageTextFind.Text = "Поиск текста";
            // 
            // _buttonStopSearchText
            // 
            this._buttonStopSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonStopSearchText.Location = new System.Drawing.Point(218, 56);
            this._buttonStopSearchText.Name = "_buttonStopSearchText";
            this._buttonStopSearchText.Size = new System.Drawing.Size(153, 23);
            this._buttonStopSearchText.TabIndex = 14;
            this._buttonStopSearchText.Text = "Остановить поиск текста";
            this._buttonStopSearchText.UseVisualStyleBackColor = true;
            // 
            // _labelProgressViewPercent
            // 
            this._labelProgressViewPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._labelProgressViewPercent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelProgressViewPercent.Location = new System.Drawing.Point(696, 433);
            this._labelProgressViewPercent.Name = "_labelProgressViewPercent";
            this._labelProgressViewPercent.Size = new System.Drawing.Size(61, 18);
            this._labelProgressViewPercent.TabIndex = 13;
            // 
            // _progressBarSearchText
            // 
            this._progressBarSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBarSearchText.ForeColor = System.Drawing.Color.Lime;
            this._progressBarSearchText.Location = new System.Drawing.Point(249, 431);
            this._progressBarSearchText.Name = "_progressBarSearchText";
            this._progressBarSearchText.Size = new System.Drawing.Size(441, 23);
            this._progressBarSearchText.TabIndex = 12;
            // 
            // _buttonClearFieldsSearchText
            // 
            this._buttonClearFieldsSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClearFieldsSearchText.Location = new System.Drawing.Point(377, 56);
            this._buttonClearFieldsSearchText.Name = "_buttonClearFieldsSearchText";
            this._buttonClearFieldsSearchText.Size = new System.Drawing.Size(116, 23);
            this._buttonClearFieldsSearchText.TabIndex = 11;
            this._buttonClearFieldsSearchText.Text = "Очистить все поля";
            this._buttonClearFieldsSearchText.UseVisualStyleBackColor = true;
            // 
            // _tbNameFileSearchText
            // 
            this._tbNameFileSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbNameFileSearchText.Location = new System.Drawing.Point(92, 4);
            this._tbNameFileSearchText.Name = "_tbNameFileSearchText";
            this._tbNameFileSearchText.Size = new System.Drawing.Size(665, 20);
            this._tbNameFileSearchText.TabIndex = 10;
            // 
            // _labelNameFileSearchText
            // 
            this._labelNameFileSearchText.AutoSize = true;
            this._labelNameFileSearchText.Location = new System.Drawing.Point(22, 7);
            this._labelNameFileSearchText.Name = "_labelNameFileSearchText";
            this._labelNameFileSearchText.Size = new System.Drawing.Size(64, 13);
            this._labelNameFileSearchText.TabIndex = 9;
            this._labelNameFileSearchText.Text = "Имя файла";
            // 
            // _statusStripCount
            // 
            this._statusStripCount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._labelNubberCoincidence,
            this._labelWiewNumCoincidence});
            this._statusStripCount.Location = new System.Drawing.Point(3, 432);
            this._statusStripCount.Name = "_statusStripCount";
            this._statusStripCount.Size = new System.Drawing.Size(759, 22);
            this._statusStripCount.TabIndex = 8;
            this._statusStripCount.Text = "statusStrip1";
            // 
            // _labelNubberCoincidence
            // 
            this._labelNubberCoincidence.ActiveLinkColor = System.Drawing.Color.Black;
            this._labelNubberCoincidence.Name = "_labelNubberCoincidence";
            this._labelNubberCoincidence.Size = new System.Drawing.Size(147, 17);
            this._labelNubberCoincidence.Text = "Колличество совпадений";
            // 
            // _labelWiewNumCoincidence
            // 
            this._labelWiewNumCoincidence.Name = "_labelWiewNumCoincidence";
            this._labelWiewNumCoincidence.Size = new System.Drawing.Size(0, 17);
            // 
            // _buttonSelectFileSearchText
            // 
            this._buttonSelectFileSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSelectFileSearchText.Location = new System.Drawing.Point(499, 56);
            this._buttonSelectFileSearchText.Name = "_buttonSelectFileSearchText";
            this._buttonSelectFileSearchText.Size = new System.Drawing.Size(89, 23);
            this._buttonSelectFileSearchText.TabIndex = 7;
            this._buttonSelectFileSearchText.Text = "Выбрать файл";
            this._buttonSelectFileSearchText.UseVisualStyleBackColor = true;
            // 
            // _buttonSaveSearch
            // 
            this._buttonSaveSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSaveSearch.Location = new System.Drawing.Point(594, 56);
            this._buttonSaveSearch.Name = "_buttonSaveSearch";
            this._buttonSaveSearch.Size = new System.Drawing.Size(163, 23);
            this._buttonSaveSearch.TabIndex = 6;
            this._buttonSaveSearch.Text = "Сохранить результат поиска";
            this._buttonSaveSearch.UseVisualStyleBackColor = true;
            // 
            // _richTextBoxSearchText
            // 
            this._richTextBoxSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._richTextBoxSearchText.BackColor = System.Drawing.SystemColors.Window;
            this._richTextBoxSearchText.ForeColor = System.Drawing.Color.Black;
            this._richTextBoxSearchText.Location = new System.Drawing.Point(6, 85);
            this._richTextBoxSearchText.Name = "_richTextBoxSearchText";
            this._richTextBoxSearchText.ReadOnly = true;
            this._richTextBoxSearchText.Size = new System.Drawing.Size(751, 344);
            this._richTextBoxSearchText.TabIndex = 5;
            this._richTextBoxSearchText.Text = "";
            // 
            // _numericUpDownFontSearchText
            // 
            this._numericUpDownFontSearchText.Location = new System.Drawing.Point(92, 57);
            this._numericUpDownFontSearchText.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this._numericUpDownFontSearchText.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this._numericUpDownFontSearchText.Name = "_numericUpDownFontSearchText";
            this._numericUpDownFontSearchText.Size = new System.Drawing.Size(120, 20);
            this._numericUpDownFontSearchText.TabIndex = 4;
            this._numericUpDownFontSearchText.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // _labelFontSize3
            // 
            this._labelFontSize3.AutoSize = true;
            this._labelFontSize3.Location = new System.Drawing.Point(45, 61);
            this._labelFontSize3.Name = "_labelFontSize3";
            this._labelFontSize3.Size = new System.Drawing.Size(41, 13);
            this._labelFontSize3.TabIndex = 3;
            this._labelFontSize3.Text = "Шрифт";
            // 
            // _buttonTextFind
            // 
            this._buttonTextFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonTextFind.Location = new System.Drawing.Point(673, 28);
            this._buttonTextFind.Name = "_buttonTextFind";
            this._buttonTextFind.Size = new System.Drawing.Size(84, 23);
            this._buttonTextFind.TabIndex = 2;
            this._buttonTextFind.Text = "Найти текст";
            this._buttonTextFind.UseVisualStyleBackColor = true;
            // 
            // _textBoxTextSearch
            // 
            this._textBoxTextSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxTextSearch.Location = new System.Drawing.Point(92, 30);
            this._textBoxTextSearch.Name = "_textBoxTextSearch";
            this._textBoxTextSearch.Size = new System.Drawing.Size(575, 20);
            this._textBoxTextSearch.TabIndex = 1;
            // 
            // _labelTextSearср
            // 
            this._labelTextSearср.AutoSize = true;
            this._labelTextSearср.Location = new System.Drawing.Point(10, 33);
            this._labelTextSearср.Name = "_labelTextSearср";
            this._labelTextSearср.Size = new System.Drawing.Size(76, 13);
            this._labelTextSearср.TabIndex = 0;
            this._labelTextSearср.Text = "Текст поиска";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(773, 483);
            this.Controls.Add(this._tabControlTextModes);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор текста";
            this._tabControlTextModes.ResumeLayout(false);
            this._tabPageTextEditor.ResumeLayout(false);
            this._tabPageTextEditor.PerformLayout();
            this._statusStripCountChars.ResumeLayout(false);
            this._statusStripCountChars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownFontTextEditor)).EndInit();
            this._tabPageWordsFind.ResumeLayout(false);
            this._tabPageWordsFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownFontSearchWords)).EndInit();
            this._tabPageTextFind.ResumeLayout(false);
            this._tabPageTextFind.PerformLayout();
            this._statusStripCount.ResumeLayout(false);
            this._statusStripCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownFontSearchText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControlTextModes;
        private System.Windows.Forms.TabPage _tabPageTextEditor;
        private System.Windows.Forms.TabPage _tabPageWordsFind;
        private System.Windows.Forms.TabPage _tabPageTextFind;
        private System.Windows.Forms.TextBox _textBoxFilePath;
        private System.Windows.Forms.TextBox _textBoxContent1;
        private System.Windows.Forms.TextBox _tbSearchWords;
        private System.Windows.Forms.TextBox _textBoxTextSearch;
        private System.Windows.Forms.TextBox _tbNameFaileSearchWords;
        private System.Windows.Forms.TextBox _tbNameFileSearchText;
        private System.Windows.Forms.Label _labelFilePath;
        private System.Windows.Forms.Label _labelSearchWords;
        private System.Windows.Forms.Label _labelTextSearср;
        private System.Windows.Forms.Label _labelFontSize1;
        private System.Windows.Forms.Label _labelFontSize3;
        private System.Windows.Forms.Label _labelFontSize2;
        private System.Windows.Forms.Label _labelNameFileSearchWords;
        private System.Windows.Forms.Label _labelNameFileSearchText;
        private System.Windows.Forms.Label _labelProgressViewPercent;
        private System.Windows.Forms.Button _buttonSelectFile1;
        private System.Windows.Forms.Button _buttonOpenFile;
        private System.Windows.Forms.Button _buttonSaveFile;
        private System.Windows.Forms.Button _buttonWordsFind;
        private System.Windows.Forms.Button _buttonSelectFileSearchWords;
        private System.Windows.Forms.Button _buttonTextFind;
        private System.Windows.Forms.Button _buttonSaveSearch;
        private System.Windows.Forms.Button _buttonSelectFileSearchText;
        private System.Windows.Forms.Button _buttonReset;
        private System.Windows.Forms.Button _buttonClearFieldsSearchWords;
        private System.Windows.Forms.Button _buttonClearFieldsSearchText;
        private System.Windows.Forms.Button _buttonStopSearchText;
        private System.Windows.Forms.NumericUpDown _numericUpDownFontTextEditor;
        private System.Windows.Forms.NumericUpDown _numericUpDownFontSearchText;
        private System.Windows.Forms.NumericUpDown _numericUpDownFontSearchWords;
        private System.Windows.Forms.StatusStrip _statusStripCountChars;
        private System.Windows.Forms.StatusStrip _statusStripCount;
        private System.Windows.Forms.ToolStripStatusLabel _labelNumberChars;
        private System.Windows.Forms.ToolStripStatusLabel _fieldNumberChars;
        private System.Windows.Forms.ToolStripStatusLabel _labelNubberCoincidence;
        private System.Windows.Forms.ToolStripStatusLabel _labelWiewNumCoincidence;
        private System.Windows.Forms.RichTextBox _richTextBoxSearchWords;
        private System.Windows.Forms.RichTextBox _richTextBoxSearchText;
        private System.Windows.Forms.ProgressBar _progressBarSearchText;
    }
}

