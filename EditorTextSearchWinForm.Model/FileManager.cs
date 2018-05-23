using System;
using System.IO;
using System.Text;

namespace EditorTextSearchWinForm.Model
{
    public class FileManager : IFileManager
    {
        //Флаг о том что было вызванно исключение в методе GetSearchResultString()
        public bool IsException { get; private set; } = false;


        // поле содержит стандартную кодировку windows
        private readonly Encoding _windowsEncoding = Encoding.GetEncoding(1251);

        // Свойство инициализируеться и используеться внутри метода GetSearchResultString()
        public string[] ResultString { get; private set; }
        // Свойство инициализируеться и используеться внутри метода GetSearchResultString()
        public string JoinWords { get; private set; }
        // Свойство инициализируеться и используеться внутри метода GetSearchResultString()
        public int ConditionValue { get; private set; }
        // Счетчик совпадений в методе GetSearchResultString()
        public int CoincidenceCounter { get; private set; } = 0;

        // Прорверка существования файла по адресу filePath
        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);

            return isExist;
        }

        // Метод подсчитывает колличество символов в строке content
        public int GetSimbolCount(string content)
        {
            int count = content.Length;

            return count;
        }

        // Метод возвращает содержимое файла filePath в кодировке windows 1251
        public string GetContent(string filePath)
        {
            return GetContent(filePath, _windowsEncoding);
        }
        // Метод возвращает содержимое файла filePath в кодировке encoding
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);

            return content;
        }

        // Метод помещает строковое содержимое content в кодировке windows по адресу filePath
        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _windowsEncoding);
        }
        // Метод помещает строковое содержимое content в кодировке encoding по адресу filePath
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        #region методы для работы с текстом

        // Метод возвращает колличество слов в строке strLine разделенных пробеломи
        public int GetCountWords(string strLine)
        {
            // Метод Trim() удаляет все начальные и конечные пробелы в строке strLine
            string line = strLine.Trim();
            int numChar = line.Length;
            int incGap = 0;

            for (int i = 0; i <= numChar - 1; i++)
            {
                if (line[i] == ' ' && line[i + 1] != ' ')
                {
                    incGap++;
                }
            }

            return incGap + 1;
        }

        // Метод возвращает массив типа string, состоящий из всех слов строки divisionStr, которые разделены символоми пробела 
        public string[] GetSplitString(string divisionStr)
        {
            // помещаем все слова из divisionStr разделеные символоми пробела в переменную массива arrayWords
            string[] arrayWords = divisionStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // создаем массив с длинной равному массиву arrayWords
            string[] wordWithoutSpaces = new string[arrayWords.Length];

            // счетчик для массива wordWithoutSpaces для работы внутри цикла foreach
            int index = 0;

            //вытаскиваем по очереди каждое слово находящиеся в массиве arrayWords и поещаем его в переменную word
            foreach (string word in arrayWords)
            {
                // помещаем попорядку все слова из массива arrayWords в массив wordWithoutSpaces           
                wordWithoutSpaces[index] = word;

                index++;
            }

            return wordWithoutSpaces;
        }

        // Метод GetSearchResultString() возвроащает строку результата поиска строки searchString в строке content.
        //       
        // Строки content и searchString приводяться к нижнему регистру символов.  
        // В итоге в выходной строке основной текст будет в нижнем регистре символов, а  
        // искомая строка searchString будет в верхнем регистре символов.    
        //
        // Параметр firstStr задает строку символов перед строкой поиска searchString в возвращаемой методом строке. 
        // Параметр lastStr задает строку символов в конце строки поиска searchString в возвращаемой методом строке. 
        //
        // Выходной параметр searchCoincidenceCount возвращает колличество совпавших строк searchString в строке content      
        public string GetSearchResultString(string content, string searchString, out int searchCoincidenceCount, string firstStr = "", string lastStr = " ")
        {
            // Текст content приводим к нижнему регистру символов, и заносим в переменную lowerContent.
            string lowerContent = content.ToLower();
            // Помещаем все слова из строки lowerContent в переменную массив arrayWodsContent 
            string[] arrayWodsContent = GetSplitString(lowerContent);
            // В переменную contentLimit помещаем длинну массива arrayWodsContent
            // Проще говоря contentLimit равен колличеству слов в строке content.
            int contentLimit = arrayWodsContent.Length;


            // Текст searchString приводим к нижнему регистру символов, и заносим в переменную lowerSearchString. 
            string lowerSearchString = searchString.ToLower();
            // Помещаем все слова из строки lowerSearchString в переменную массив arrayWodsContent 
            string[] arrayWodsSearchString = GetSplitString(lowerSearchString);
            // В переменную searchStringWordsNumber помещаем длинну массива arrayWodsSearchString 
            int searchStringWordsNumber = arrayWodsSearchString.Length;


            // Свойство ResultString содержиит строковый результат поиска 
            // строки searchString в тексте content. 
            ResultString = new string[contentLimit];

            // Перед началом работы метода данный счетчик должен равняться -1
            ConditionValue = -1;


            // Если колличество слов в строке content меньше чем в строке searchText. 
            // То в таком случае метод SaveSearchResult() возвращает исключение.  
            if (contentLimit < searchStringWordsNumber)
            {
                throw new Exception("Строка поиска не может быть меньше текста поиска!");
            }
            else
            {
                // searchStringWordsNumber - колличество слов в строке searchString
                switch (searchStringWordsNumber)
                {
                    case 0:

                        // Вызываеться конструктор классса исключения
                        throw new Exception("Не задана строка поиска!");

                    case 1:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\nа") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\n\nа") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\nв") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\n\nв") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\nи") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\n\nи") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\nк") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\n\nк") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\nс") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\n\nс") | (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\nу") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\n\nу") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\nя") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "." + "\n\nя"))
                            {
                                ResultString[i] = (firstStr + arrayWodsSearchString[0] + lastStr).ToUpper();

                                // Подсчет колличества совпадений
                                CoincidenceCounter = CoincidenceCounter + 1;
                            }
                            else
                            {
                                ResultString[i] = arrayWodsContent[i] + " ";
                            }
                        }

                        // Метод Join преобразует массив ResultString в строку, и помещает эту строку в JoinWords
                        JoinWords = String.Join("", ResultString);

                        // Присваиваем колличество совпадений выходному параметру searchCoincidenceCount
                        searchCoincidenceCount = CoincidenceCounter;

                        // Обнуляем счетчик. 
                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 2:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                        ResultString[i + 1] = (arrayWodsSearchString[1] + lastStr).ToUpper();

                                        ConditionValue = i + 1;

                                        CoincidenceCounter = CoincidenceCounter + 2;
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 2;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 3:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                            ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                            ResultString[i + 2] = (arrayWodsSearchString[2] + lastStr).ToUpper();

                                            ConditionValue = i + 2;

                                            CoincidenceCounter = CoincidenceCounter + 3;
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 3;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 4:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            if (i + 3 < contentLimit && ((arrayWodsContent[i + 3] == arrayWodsSearchString[3]) || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ".") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "!") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ",") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ":") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ";") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "?")))
                                            {
                                                ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                                ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                                ResultString[i + 2] = (arrayWodsSearchString[2] + " ").ToUpper();
                                                ResultString[i + 3] = (arrayWodsSearchString[3] + lastStr).ToUpper();

                                                ConditionValue = i + 3;

                                                CoincidenceCounter = CoincidenceCounter + 4;
                                            }
                                            else
                                            {
                                                ResultString[i] = arrayWodsContent[i] + " ";
                                            }
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 4;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 5:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            if (i + 3 < contentLimit && ((arrayWodsContent[i + 3] == arrayWodsSearchString[3]) || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ".") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "!") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ",") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ":") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ";") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "?")))
                                            {
                                                if (i + 4 < contentLimit && ((arrayWodsContent[i + 4] == arrayWodsSearchString[4]) || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ".") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "!") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ",") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ":") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ";") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "?")))
                                                {
                                                    ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                                    ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                                    ResultString[i + 2] = (arrayWodsSearchString[2] + " ").ToUpper();
                                                    ResultString[i + 3] = (arrayWodsSearchString[3] + " ").ToUpper();
                                                    ResultString[i + 4] = (arrayWodsSearchString[4] + lastStr).ToUpper();

                                                    ConditionValue = i + 4;

                                                    CoincidenceCounter = CoincidenceCounter + 5;
                                                }
                                                else
                                                {
                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                }
                                            }
                                            else
                                            {
                                                ResultString[i] = arrayWodsContent[i] + " ";
                                            }
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 5;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 6:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            if (i + 3 < contentLimit && ((arrayWodsContent[i + 3] == arrayWodsSearchString[3]) || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ".") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "!") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ",") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ":") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ";") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "?")))
                                            {
                                                if (i + 4 < contentLimit && ((arrayWodsContent[i + 4] == arrayWodsSearchString[4]) || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ".") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "!") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ",") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ":") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ";") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "?")))
                                                {
                                                    if (i + 5 < contentLimit && ((arrayWodsContent[i + 5] == arrayWodsSearchString[5]) || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ".") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "!") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ",") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ":") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ";") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "?")))
                                                    {
                                                        ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                                        ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                                        ResultString[i + 2] = (arrayWodsSearchString[2] + " ").ToUpper();
                                                        ResultString[i + 3] = (arrayWodsSearchString[3] + " ").ToUpper();
                                                        ResultString[i + 4] = (arrayWodsSearchString[4] + " ").ToUpper();
                                                        ResultString[i + 5] = (arrayWodsSearchString[5] + lastStr).ToUpper();

                                                        ConditionValue = i + 5;

                                                        CoincidenceCounter = CoincidenceCounter + 6;
                                                    }
                                                    else
                                                    {
                                                        ResultString[i] = arrayWodsContent[i] + " ";
                                                    }
                                                }
                                                else
                                                {
                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                }
                                            }
                                            else
                                            {
                                                ResultString[i] = arrayWodsContent[i] + " ";
                                            }
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 6;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 7:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            if (i + 3 < contentLimit && ((arrayWodsContent[i + 3] == arrayWodsSearchString[3]) || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ".") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "!") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ",") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ":") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ";") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "?")))
                                            {
                                                if (i + 4 < contentLimit && ((arrayWodsContent[i + 4] == arrayWodsSearchString[4]) || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ".") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "!") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ",") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ":") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ";") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "?")))
                                                {
                                                    if (i + 5 < contentLimit && ((arrayWodsContent[i + 5] == arrayWodsSearchString[5]) || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ".") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "!") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ",") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ":") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ";") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "?")))
                                                    {
                                                        if (i + 6 < contentLimit && ((arrayWodsContent[i + 6] == arrayWodsSearchString[6]) || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ".") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "!") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ",") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ":") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ";") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "?")))
                                                        {
                                                            ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                                            ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                                            ResultString[i + 2] = (arrayWodsSearchString[2] + " ").ToUpper();
                                                            ResultString[i + 3] = (arrayWodsSearchString[3] + " ").ToUpper();
                                                            ResultString[i + 4] = (arrayWodsSearchString[4] + " ").ToUpper();
                                                            ResultString[i + 5] = (arrayWodsSearchString[5] + " ").ToUpper();
                                                            ResultString[i + 6] = (arrayWodsSearchString[6] + lastStr).ToUpper();

                                                            ConditionValue = i + 6;

                                                            CoincidenceCounter = CoincidenceCounter + 7;
                                                        }
                                                        else
                                                        {
                                                            ResultString[i] = arrayWodsContent[i] + " ";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ResultString[i] = arrayWodsContent[i] + " ";
                                                    }
                                                }
                                                else
                                                {
                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                }
                                            }
                                            else
                                            {
                                                ResultString[i] = arrayWodsContent[i] + " ";
                                            }
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 7;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 8:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            if (i + 3 < contentLimit && ((arrayWodsContent[i + 3] == arrayWodsSearchString[3]) || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ".") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "!") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ",") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ":") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ";") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "?")))
                                            {
                                                if (i + 4 < contentLimit && ((arrayWodsContent[i + 4] == arrayWodsSearchString[4]) || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ".") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "!") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ",") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ":") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ";") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "?")))
                                                {
                                                    if (i + 5 < contentLimit && ((arrayWodsContent[i + 5] == arrayWodsSearchString[5]) || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ".") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "!") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ",") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ":") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ";") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "?")))
                                                    {
                                                        if (i + 6 < contentLimit && ((arrayWodsContent[i + 6] == arrayWodsSearchString[6]) || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ".") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "!") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ",") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ":") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ";") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "?")))
                                                        {
                                                            if (i + 7 < contentLimit && ((arrayWodsContent[i + 7] == arrayWodsSearchString[7]) || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ".") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + "!") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ",") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ":") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ";") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + "?")))
                                                            {
                                                                ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                                                ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                                                ResultString[i + 2] = (arrayWodsSearchString[2] + " ").ToUpper();
                                                                ResultString[i + 3] = (arrayWodsSearchString[3] + " ").ToUpper();
                                                                ResultString[i + 4] = (arrayWodsSearchString[4] + " ").ToUpper();
                                                                ResultString[i + 5] = (arrayWodsSearchString[5] + " ").ToUpper();
                                                                ResultString[i + 6] = (arrayWodsSearchString[6] + " ").ToUpper();
                                                                ResultString[i + 7] = (arrayWodsSearchString[7] + lastStr).ToUpper();

                                                                ConditionValue = i + 7;

                                                                CoincidenceCounter = CoincidenceCounter + 8;
                                                            }
                                                            else
                                                            {
                                                                ResultString[i] = arrayWodsContent[i] + " ";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ResultString[i] = arrayWodsContent[i] + " ";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ResultString[i] = arrayWodsContent[i] + " ";
                                                    }
                                                }
                                                else
                                                {
                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                }
                                            }
                                            else
                                            {
                                                ResultString[i] = arrayWodsContent[i] + " ";
                                            }
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 8;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 9:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            if (i + 3 < contentLimit && ((arrayWodsContent[i + 3] == arrayWodsSearchString[3]) || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ".") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "!") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ",") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ":") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ";") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "?")))
                                            {
                                                if (i + 4 < contentLimit && ((arrayWodsContent[i + 4] == arrayWodsSearchString[4]) || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ".") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "!") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ",") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ":") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ";") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "?")))
                                                {
                                                    if (i + 5 < contentLimit && ((arrayWodsContent[i + 5] == arrayWodsSearchString[5]) || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ".") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "!") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ",") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ":") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ";") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "?")))
                                                    {
                                                        if (i + 6 < contentLimit && ((arrayWodsContent[i + 6] == arrayWodsSearchString[6]) || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ".") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "!") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ",") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ":") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ";") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "?")))
                                                        {
                                                            if (i + 7 < contentLimit && ((arrayWodsContent[i + 7] == arrayWodsSearchString[7]) || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ".") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + "!") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ",") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ":") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ";") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + "?")))
                                                            {
                                                                if (i + 8 < contentLimit && ((arrayWodsContent[i + 8] == arrayWodsSearchString[8]) || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ".") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + "!") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ",") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ":") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ";") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + "?")))
                                                                {
                                                                    ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                                                    ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                                                    ResultString[i + 2] = (arrayWodsSearchString[2] + " ").ToUpper();
                                                                    ResultString[i + 3] = (arrayWodsSearchString[3] + " ").ToUpper();
                                                                    ResultString[i + 4] = (arrayWodsSearchString[4] + " ").ToUpper();
                                                                    ResultString[i + 5] = (arrayWodsSearchString[5] + " ").ToUpper();
                                                                    ResultString[i + 6] = (arrayWodsSearchString[6] + " ").ToUpper();
                                                                    ResultString[i + 7] = (arrayWodsSearchString[7] + " ").ToUpper();
                                                                    ResultString[i + 8] = (arrayWodsSearchString[8] + lastStr).ToUpper();

                                                                    ConditionValue = i + 8;

                                                                    CoincidenceCounter = CoincidenceCounter + 9;
                                                                }
                                                                else
                                                                {
                                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                ResultString[i] = arrayWodsContent[i] + " ";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ResultString[i] = arrayWodsContent[i] + " ";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ResultString[i] = arrayWodsContent[i] + " ";
                                                    }
                                                }
                                                else
                                                {
                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                }
                                            }
                                            else
                                            {
                                                ResultString[i] = arrayWodsContent[i] + " ";
                                            }
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 9;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    case 10:

                        for (int i = 0; i < contentLimit; i++)
                        {
                            if (i > ConditionValue)
                            {
                                if ((arrayWodsContent[i] == arrayWodsSearchString[0]) || (arrayWodsContent[i] == arrayWodsSearchString[0] + ".") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "!") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ",") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ":") || (arrayWodsContent[i] == arrayWodsSearchString[0] + ";") || (arrayWodsContent[i] == arrayWodsSearchString[0] + "?"))
                                {
                                    if (i + 1 < contentLimit && ((arrayWodsContent[i + 1] == arrayWodsSearchString[1]) || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ".") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "!") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ",") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ":") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + ";") || (arrayWodsContent[i + 1] == arrayWodsSearchString[1] + "?")))
                                    {
                                        if (i + 2 < contentLimit && ((arrayWodsContent[i + 2] == arrayWodsSearchString[2]) || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ".") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "!") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ",") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ":") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + ";") || (arrayWodsContent[i + 2] == arrayWodsSearchString[2] + "?")))
                                        {
                                            if (i + 3 < contentLimit && ((arrayWodsContent[i + 3] == arrayWodsSearchString[3]) || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ".") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "!") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ",") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ":") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + ";") || (arrayWodsContent[i + 3] == arrayWodsSearchString[3] + "?")))
                                            {
                                                if (i + 4 < contentLimit && ((arrayWodsContent[i + 4] == arrayWodsSearchString[4]) || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ".") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "!") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ",") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ":") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + ";") || (arrayWodsContent[i + 4] == arrayWodsSearchString[4] + "?")))
                                                {
                                                    if (i + 5 < contentLimit && ((arrayWodsContent[i + 5] == arrayWodsSearchString[5]) || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ".") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "!") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ",") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ":") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + ";") || (arrayWodsContent[i + 5] == arrayWodsSearchString[5] + "?")))
                                                    {
                                                        if (i + 6 < contentLimit && ((arrayWodsContent[i + 6] == arrayWodsSearchString[6]) || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ".") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "!") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ",") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ":") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + ";") || (arrayWodsContent[i + 6] == arrayWodsSearchString[6] + "?")))
                                                        {
                                                            if (i + 7 < contentLimit && ((arrayWodsContent[i + 7] == arrayWodsSearchString[7]) || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ".") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + "!") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ",") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ":") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + ";") || (arrayWodsContent[i + 7] == arrayWodsSearchString[7] + "?")))
                                                            {
                                                                if (i + 8 < contentLimit && ((arrayWodsContent[i + 8] == arrayWodsSearchString[8]) || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ".") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + "!") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ",") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ":") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + ";") || (arrayWodsContent[i + 8] == arrayWodsSearchString[8] + "?")))
                                                                {
                                                                    if (i + 9 < contentLimit && ((arrayWodsContent[i + 9] == arrayWodsSearchString[9]) || (arrayWodsContent[i + 9] == arrayWodsSearchString[9] + ".") || (arrayWodsContent[i + 9] == arrayWodsSearchString[9] + "!") || (arrayWodsContent[i + 9] == arrayWodsSearchString[9] + ",") || (arrayWodsContent[i + 9] == arrayWodsSearchString[9] + ":") || (arrayWodsContent[i + 9] == arrayWodsSearchString[9] + ";") || (arrayWodsContent[i + 9] == arrayWodsSearchString[9] + "?")))
                                                                    {
                                                                        ResultString[i] = (firstStr + arrayWodsSearchString[0] + " ").ToUpper();
                                                                        ResultString[i + 1] = (arrayWodsSearchString[1] + " ").ToUpper();
                                                                        ResultString[i + 2] = (arrayWodsSearchString[2] + " ").ToUpper();
                                                                        ResultString[i + 3] = (arrayWodsSearchString[3] + " ").ToUpper();
                                                                        ResultString[i + 4] = (arrayWodsSearchString[4] + " ").ToUpper();
                                                                        ResultString[i + 5] = (arrayWodsSearchString[5] + " ").ToUpper();
                                                                        ResultString[i + 6] = (arrayWodsSearchString[6] + " ").ToUpper();
                                                                        ResultString[i + 7] = (arrayWodsSearchString[7] + " ").ToUpper();
                                                                        ResultString[i + 8] = (arrayWodsSearchString[8] + " ").ToUpper();
                                                                        ResultString[i + 9] = (arrayWodsSearchString[9] + lastStr).ToUpper();

                                                                        ConditionValue = i + 9;

                                                                        CoincidenceCounter = CoincidenceCounter + 10;
                                                                    }
                                                                    else
                                                                    {
                                                                        ResultString[i] = arrayWodsContent[i] + " ";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                ResultString[i] = arrayWodsContent[i] + " ";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            ResultString[i] = arrayWodsContent[i] + " ";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ResultString[i] = arrayWodsContent[i] + " ";
                                                    }
                                                }
                                                else
                                                {
                                                    ResultString[i] = arrayWodsContent[i] + " ";
                                                }
                                            }
                                            else
                                            {
                                                ResultString[i] = arrayWodsContent[i] + " ";
                                            }
                                        }
                                        else
                                        {
                                            ResultString[i] = arrayWodsContent[i] + " ";
                                        }
                                    }
                                    else
                                    {
                                        ResultString[i] = arrayWodsContent[i] + " ";
                                    }
                                }
                                else
                                {
                                    ResultString[i] = arrayWodsContent[i] + " ";
                                }
                            }
                        }

                        JoinWords = String.Join("", ResultString);

                        searchCoincidenceCount = CoincidenceCounter / 10;

                        CoincidenceCounter = 0;

                        return JoinWords;

                    default:

                        // Вызываеться конструктор классса исключения
                        throw new Exception("Строка поиска должна состоять не более чем из 10-ти слов разделенных пробелами!");
                }
            }

        }

        #endregion

    }
}
