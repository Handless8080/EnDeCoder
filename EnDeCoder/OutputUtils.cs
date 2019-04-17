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

            sw.WriteLine("Ключи:");
            sw.WriteLine("");
            for (int i = 0; i < keys.Length; i++)
            {
                sw.WriteLine(descriptions[i] + " " + keys[i]);
            }
            sw.WriteLine("Полученные текстовые данные:");
            sw.WriteLine("");
            sw.WriteLine(message);

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

            paragraph.Range.Text = "Ключи:";
            paragraph.Range.InsertParagraphAfter();
            for (int i = 0; i < keys.Length; i++)
            {
                paragraph.Range.Text = descriptions[i] + " " + keys[i];
                paragraph.Range.InsertParagraphAfter();
            }
            paragraph.Range.Text = "Полученные текстовые данные:";
            paragraph.Range.InsertParagraphAfter();


            paragraph.Range.Text = message;
            paragraph.Range.InsertParagraphAfter();

            doc.SaveAs2(fileName);

            word.Quit();
        }
    }
}
