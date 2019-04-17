using System.Windows.Forms;
using System.Drawing;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace EnDeCoder
{
    public partial class MainForm : Form
    {
        private const string txtFilter = "Текстовый файл|*.txt";
        private const string wordFilter = "Документ Microsoft Word|*.docx;*.doc";
        private const string inputError = "Не все поля заполнены!";

        private bool move = false;
        private int formLocationX;
        private int formLocationY;

        public string message = "";
        private string outputPath = "";

        private enum OutputMode { OnForm, InTXT, InWord};
        private OutputMode outputMode;

        public MainForm()
        {
            InitializeComponent();

            EncodingTypeBox.SelectedIndex = 0;
        }

        /// <summary>
        ///     Определяет расстояние между курсором и верхним левым углом.
        /// </summary>
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                move = true;
                formLocationX = MousePosition.X - Location.X;
                formLocationY = MousePosition.Y - Location.Y;
            }
        }

        /// <summary>
        ///     Перемещает форму в соответствии движения курсора при нажатой левой кнопке мыши.
        /// </summary>
        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                Location = new Point(MousePosition.X - formLocationX, MousePosition.Y - formLocationY);
            }
        }

        /// <summary>
        ///     Блокирует перемещение формы при отпускании левой кнопки мыши.
        /// </summary>
        private void Title_MouseUp(object sender, MouseEventArgs e)
        {
            if (e == null || e.Button == MouseButtons.Left)
            {
                move = false;
            }
        }

        /// <summary>
        ///     Блокирует перемещение формы при покидании области компонента.
        /// </summary>
        private void Title_MouseLeave(object sender, System.EventArgs e)
        {
            Title_MouseUp(null, null);
        }

        /// <summary>
        ///     Закрытие программы.
        /// </summary>
        private void ExitBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Установка программы в режим шифрования.
        /// </summary>
        private void EncodeBtn_MouseClick(object sender, MouseEventArgs e)
        {
            EncodeBtn.FlatAppearance.BorderColor = Color.Black;
            DecodeBtn.FlatAppearance.BorderColor = Color.Gray;

            OperateBtn.Text = "Выполнить шифрование";
        }

        /// <summary>
        ///     Установка программы в режим дешифрования.
        /// </summary>
        private void DecodeBtn_Click(object sender, System.EventArgs e)
        {
            EncodeBtn.FlatAppearance.BorderColor = Color.Gray;
            DecodeBtn.FlatAppearance.BorderColor = Color.Black;

            OperateBtn.Text = "Выполнить дешифрование";
        }

        /// <summary>
        ///     Сворачивание программы.
        /// </summary>
        private void HideBtn_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        ///     Выполнение шифрования/дешифрования
        /// </summary>
        private void OperateBtn_Click(object sender, System.EventArgs e)
        {
            if (message == null || message == "")
            {
                InputDataLbl.ForeColor = Color.Red;

                StatusLbl.ForeColor = Color.Red;
                StatusLbl.Text = inputError;

                return;
            }
            if (outputPath == null || outputPath == "")
            {
                OutputDataLbl.ForeColor = Color.Red;

                StatusLbl.ForeColor = Color.Red;
                StatusLbl.Text = inputError;

                return;
            }

            string[] descriptions = null;
            object[] keys = null;

            switch (EncodingTypeBox.SelectedIndex)
            {
                case 0:
                    if (!CheckKeys(2))
                    {
                        return;
                    }

                    int cols = int.Parse(Key1TBox.Text);
                    int rows = int.Parse(Key2TBox.Text);

                    message = SymmetricKeyAlgoritms.SimplePermutation(message, cols, rows);

                    descriptions = new string[] { "Количество столбцов:", "Количество строк:"};
                    keys = new object[] { cols, rows };

                    break;
                case 1:
                    if (!CheckKeys(3))
                    {
                        return;
                    }

                    cols = int.Parse(Key1TBox.Text);
                    rows = int.Parse(Key2TBox.Text);
                    string keyWord = Key3TBox.Text;

                    message = SymmetricKeyAlgoritms.SinglePermutationWithKey(message, cols, rows, keyWord);

                    descriptions = new string[]{ "Количество столбцов:", "Количество строк:", "Ключевое слово:"};
                    keys = new object[]{ cols, rows, keyWord };

                    break;
                case 2:
                    if (!CheckKeys(4))
                    {
                        return;
                    }

                    cols = int.Parse(Key1TBox.Text);
                    rows = int.Parse(Key2TBox.Text);
                    string keyWord1 = Key3TBox.Text;
                    string keyWord2 = Key4TBox.Text;

                    if (rows != keyWord1.Length || cols != keyWord2.Length)
                    {
                        StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длины 1-го и 2-го ключей должны совпадать с числом строк и столбцов соотв.!";

                        return;
                    }

                    message = SymmetricKeyAlgoritms.DoublePermutation(message, cols, rows, keyWord1, keyWord2);

                    descriptions = new string[] { "Количество столбцов:", "Количество строк:",
                                                  "1-ое ключевое слово:", "2-ое ключевое слово:" };
                    keys = new object[] { cols, rows, keyWord1, keyWord2 };

                    break;
            }

            switch (outputMode)
            {
                case OutputMode.OnForm:
                    OutputUtils.OutputOnForm(message, descriptions, keys, this);
                    break;
                case OutputMode.InTXT:
                    OutputUtils.OutputInTXT(message, descriptions, keys, outputPath);
                    break;
                case OutputMode.InWord:
                    OutputUtils.OutputInWord(message, descriptions, keys, outputPath);
                    break;
            }

            message = outputPath = "";
            SelectedIFileLbl.Text = SelectedOFileLbl.Text = "";

            StatusLbl.ForeColor = Color.FromArgb(64, 64, 64);
            StatusLbl.Text = "Операция выполнена успешно!";

            ClearKeys();
        }

        /// <summary>
        ///     Ввод информации с клавиатуры
        /// </summary>
        private void KeyboardInputBtn_Click(object sender, System.EventArgs e)
        {
            MessageForm messageInputForm = new MessageForm(this);
            messageInputForm.ShowDialog();

            if (message != null && message != "")
            {
                SelectedIFileLbl.Text = "Введены данные с клавиатуры";

                InputDataLbl.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }

        /// <summary>
        ///     Установка режима вывода информации на экран
        /// </summary>
        private void ScreenOutputBtn_Click(object sender, System.EventArgs e)
        {
            outputMode = OutputMode.OnForm;
            outputPath = "screen";

            SelectedOFileLbl.Text = "Данные будут выведены на экран";
        }

        /// <summary>
        ///     Чтение информации из текстового файла
        /// </summary>
        private void TXTInputBtn_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Filter = txtFilter;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);

                message = sr.ReadToEnd();

                sr.Close();

                InputDataLbl.ForeColor = Color.FromArgb(64, 64, 64);

                var splited = openFileDialog1.FileName.Split('\\');
                SelectedIFileLbl.Text = splited[splited.Length - 1];
            }
        }

        /// <summary>
        ///     Установка текстового файла для вывода информации
        /// </summary>
        private void TXTOutputBtn_Click(object sender, System.EventArgs e)
        {
            saveFileDialog1.Filter = txtFilter;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputMode = OutputMode.InTXT;
                outputPath = saveFileDialog1.FileName;

                OutputDataLbl.ForeColor = Color.FromArgb(64, 64, 64);

                var splited = saveFileDialog1.FileName.Split('\\');
                SelectedOFileLbl.Text = splited[splited.Length - 1];
            }
        }

        /// <summary>
        ///     Чтение текстовых данных из документа Microsoft Word
        /// </summary>
        private void WordInputBtn_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Filter = wordFilter;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();

                object file = openFileDialog1.FileName;
                object miss = System.Reflection.Missing.Value;
                object readOnly = true;

                doc = word.Documents.Open(ref file, ref miss, ref readOnly, ref miss, ref miss,
                                            ref miss, ref miss, ref miss, ref miss, ref miss,
                                            ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

                message = "";
                for (int i = 0; i < doc.Paragraphs.Count; i++)
                {
                    message += doc.Paragraphs[i + 1].Range.Text.ToString();
                }

                doc.Close();
                word.Quit();

                InputDataLbl.ForeColor = Color.FromArgb(64, 64, 64);

                var splited = openFileDialog1.FileName.Split('\\');
                SelectedIFileLbl.Text = splited[splited.Length - 1];
            }
        }

        /// <summary>
        ///     Установка документа Microsoft Word для вывода информации
        /// </summary>
        private void WordOutputBtn_Click(object sender, System.EventArgs e)
        {
            saveFileDialog1.Filter = wordFilter;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputMode = OutputMode.InWord;
                outputPath = saveFileDialog1.FileName;

                OutputDataLbl.ForeColor = Color.FromArgb(64, 64, 64);

                var splited = saveFileDialog1.FileName.Split('\\');
                SelectedOFileLbl.Text = splited[splited.Length - 1];
            }
        }

        /// <summary>
        ///     Слушатель изменения метода шифрования
        /// </summary>
        private void EncodingTypeBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (EncodingTypeBox.SelectedIndex)
            {
                case 0:
                    Key1Lbl.Visible = true;
                    Key2Lbl.Visible = true;
                    Key3Lbl.Visible = false;
                    Key4Lbl.Visible = false;

                    Key1Lbl.Text = "Кол-во столбцов:";
                    Key2Lbl.Text = "Кол-во строк:";

                    Key1TBox.Visible = true;
                    Key2TBox.Visible = true;
                    Key3TBox.Visible = false;
                    Key4TBox.Visible = false;

                    break;
                case 1:
                    Key1Lbl.Visible = true;
                    Key2Lbl.Visible = true;
                    Key3Lbl.Visible = true;
                    Key4Lbl.Visible = false;

                    Key1Lbl.Text = "Кол-во столбцов:";
                    Key2Lbl.Text = "Кол-во строк:";
                    Key3Lbl.Text = "Кодовое слово:";

                    Key1TBox.Visible = true;
                    Key2TBox.Visible = true;
                    Key3TBox.Visible = true;
                    Key4TBox.Visible = false;

                    break;
                case 2:
                    Key1Lbl.Visible = true;
                    Key2Lbl.Visible = true;
                    Key3Lbl.Visible = true;
                    Key4Lbl.Visible = true;

                    Key1Lbl.Text = "Кол-во столбцов:";
                    Key2Lbl.Text = "Кол-во строк:";
                    Key3Lbl.Text = "1-ое кодовое слово:";
                    Key4Lbl.Text = "2-ое кодовое слово:";

                    Key1TBox.Visible = true;
                    Key2TBox.Visible = true;
                    Key3TBox.Visible = true;
                    Key4TBox.Visible = true;

                    break;
            }
        }

        /// <summary>
        ///     Очистка ключей
        /// </summary>
        private void ClearBtn_Click(object sender, System.EventArgs e)
        {
            ClearKeys();
        }

        /// <summary>
        ///     Метод, очищающий поля для ввода ключей
        /// </summary>
        private void ClearKeys()
        {
            for (int i = 1; i < 9; i++)
            {
                var keyBox = KeysPanel.Controls["Key" + i.ToString() + "TBox"];

                keyBox.Text = "";
            }
        }

        /// <summary>
        ///     Проверка полей для ввода ключей на пустые строки
        /// </summary>
        /// 
        /// <param name="keysCount">
        ///     Количество ключей
        /// </param>
        /// 
        /// <returns>
        ///     Возвращает true, если все ключи введены
        /// </returns>
        private bool CheckKeys(int keysCount)
        {
            for (int i = 1; i < keysCount + 1; i++)
            {
                var keyBox = KeysPanel.Controls["Key" + i.ToString() + "TBox"];

                if (keyBox.Text == "" || keyBox.Text == null)
                {
                    KeysLbl.ForeColor = Color.Red;

                    StatusLbl.ForeColor = Color.Red;
                    StatusLbl.Text = "Введите все значения ключей!";

                    return false;
                }
            }
            KeysLbl.ForeColor = Color.FromArgb(64, 64, 64);

            return true;
        }
    }
}