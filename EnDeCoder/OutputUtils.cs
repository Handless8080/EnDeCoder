using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace EnDeCoder
{
    class OutputUtils
    {
        /// <summary>
        ///     Вывод данных на форму
        /// </summary>
        /// 
        /// <param name="message">
        ///     Полученное сообщение
        /// </param>
        /// 
        /// <param name="descriptions">
        ///     Описания ключей
        /// </param>
        /// 
        /// <param name="keys">
        ///     Ключи
        /// </param>
        /// 
        /// <param name="parent">
        ///     Ссылка на родительскую форму
        /// </param>
        public static void OutputOnForm(string message, string[] descriptions, object[] keys, MainForm parent)
        {
            MessageForm messageForm = new MessageForm(parent, descriptions, keys, message);

            messageForm.ShowDialog();
        }

        /// <summary>
        ///     Вывод данных на форму
        /// </summary>
        /// 
        /// <param name="message">
        ///     Полученное сообщение в байтах
        /// </param>
        /// 
        /// <param name="descriptions">
        ///     Описания ключей
        /// </param>
        /// 
        /// <param name="keys">
        ///     Ключи
        /// </param>
        /// 
        /// <param name="parent">
        ///     Ссылка на родительскую форму
        /// </param>
        public static void OutputOnForm(byte[] message, string[] descriptions, object[] keys, MainForm parent)
        {
            MessageForm messageForm = new MessageForm(parent, descriptions, keys, message);

            messageForm.ShowDialog();
        }

        /// <summary>
        ///     Вывод данных в текстовый файл
        /// </summary>
        /// 
        /// <param name="message">
        ///     Полученное сообщение
        /// </param>
        /// 
        /// <param name="descriptions">
        ///     Описания ключей
        /// </param>
        /// 
        /// <param name="keys">
        ///     Ключи
        /// </param>
        /// 
        /// <param name="fileName">
        ///     Путь к файлу
        /// </param>
        public static void OutputInTXT(string message, string[] descriptions, object[] keys, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);

            sw.WriteLine("Метод шифрования: " + descriptions[descriptions.Length - 1]);
            sw.WriteLine("");
            sw.WriteLine("Ключи:");
            sw.WriteLine("");
            for (int i = 0; i < keys.Length; i++)
            {
                sw.WriteLine(descriptions[i] + ": " + keys[i]);
            }
            sw.WriteLine("Полученные текстовые данные:");
            sw.WriteLine("");
            sw.Write(message);

            sw.Close();
        }

        /// <summary>
        ///     Вывод данных в текстовый файл
        /// </summary>
        /// 
        /// <param name="message">
        ///     Полученное сообщение в байтах
        /// </param>
        /// 
        /// <param name="descriptions">
        ///     Описания ключей
        /// </param>
        /// 
        /// <param name="keys">
        ///     Ключи
        /// </param>
        /// 
        /// <param name="fileName">
        ///     Путь к файлу
        /// </param>
        public static void OutputInTXT(byte[] message, string[] descriptions, object[] keys, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);

            sw.WriteLine("Метод шифрования: " + descriptions[descriptions.Length - 1]);
            sw.WriteLine();
            sw.WriteLine("Ключи:");
            sw.WriteLine();
            for (int i = 0; i < keys.Length; i++)
            {
                sw.WriteLine(descriptions[i] + ": " + keys[i]);
            }
            sw.WriteLine();
            sw.WriteLine("Полученные текстовые данные:");
            sw.WriteLine();
            sw.Write("\r\n" + message.Length);
            foreach (byte b in message)
            {
                sw.Write("\r\n" + b);
            }

            sw.Close();
        }

        /// <summary>
        ///     Вывод данных в документ Microsoft Word
        /// </summary>
        /// 
        /// <param name="message">
        ///     Полученное сообщение
        /// </param>
        /// 
        /// <param name="descriptions">
        ///     Описания ключей
        /// </param>
        /// 
        /// <param name="keys">
        ///     Ключи
        /// </param>
        /// 
        /// <param name="fileName">
        ///     Путь к файлу
        /// </param>
        public static void OutputInWord(string message, string[] descriptions, object[] keys, string fileName)
        {
            Word.Application word = new Word.Application();
            Word.Document doc = new Word.Document();

            doc = word.Documents.Add();

            var paragraph = doc.Paragraphs.Add();

            paragraph.Range.Text = "Метод шифрования: " + descriptions[descriptions.Length - 1];
            paragraph.Range.InsertParagraphAfter();

            paragraph.Range.Text = "Ключи:";
            paragraph.Range.InsertParagraphAfter();
            for (int i = 0; i < keys.Length; i++)
            {
                paragraph.Range.Text = descriptions[i] + ": " + keys[i];
                paragraph.Range.InsertParagraphAfter();
            }
            paragraph.Range.Text = "Полученные текстовые данные:";
            paragraph.Range.InsertParagraphAfter();


            paragraph.Range.Text = message;
            paragraph.Range.InsertParagraphAfter();

            doc.SaveAs2(fileName);

            doc.Close();
            word.Quit();
        }

        /// <summary>
        ///     Вывод данных в документ Microsoft Word
        /// </summary>
        /// 
        /// <param name="message">
        ///     Полученное сообщение в байтах
        /// </param>
        /// 
        /// <param name="descriptions">
        ///     Описания ключей
        /// </param>
        /// 
        /// <param name="keys">
        ///     Ключи
        /// </param>
        /// 
        /// <param name="fileName">
        ///     Путь к файлу
        /// </param>
        public static void OutputInWord(byte[] message, string[] descriptions, object[] keys, string fileName)
        {
            Word.Application word = new Word.Application();
            Word.Document doc = new Word.Document();

            doc = word.Documents.Add();

            var paragraph = doc.Paragraphs.Add();

            paragraph.Range.Text = "Метод шифрования: " + descriptions[descriptions.Length - 1];
            paragraph.Range.InsertParagraphAfter();

            paragraph.Range.Text = "Ключи:";
            paragraph.Range.InsertParagraphAfter();
            for (int i = 0; i < keys.Length; i++)
            {
                paragraph.Range.Text = descriptions[i] + ": " + keys[i];
                paragraph.Range.InsertParagraphAfter();
            }
            paragraph.Range.Text = "Полученные текстовые данные:";
            paragraph.Range.InsertParagraphAfter();

            paragraph.Range.Text = message.Length.ToString();
            paragraph.Range.InsertParagraphAfter();

            foreach (byte b in message)
            {
                paragraph.Range.Text = b.ToString();
                paragraph.Range.InsertParagraphAfter();
            }

            doc.SaveAs2(fileName);

            doc.Close();
            word.Quit();
        }
    }
}