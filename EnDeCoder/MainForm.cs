using System.Windows.Forms;
using System.Drawing;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Security.Cryptography;
using System;

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
        public byte[] messageInBytes;
        private string outputPath = "";

        private bool isEncodingType = true;

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
        private void Title_MouseLeave(object sender, EventArgs e)
        {
            Title_MouseUp(null, null);
        }

        /// <summary>
        ///     Закрытие программы.
        /// </summary>
        private void ExitBtn_Click(object sender, EventArgs e)
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

            GenKeysBtn.Enabled = true;
            GenKeysBtn.ForeColor = Color.White;

            isEncodingType = true;
            OperateBtn.Text = "Выполнить шифрование";
        }

        /// <summary>
        ///     Установка программы в режим дешифрования.
        /// </summary>
        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            EncodeBtn.FlatAppearance.BorderColor = Color.Gray;
            DecodeBtn.FlatAppearance.BorderColor = Color.Black;

            GenKeysBtn.Enabled = false;
            GenKeysBtn.ForeColor = Color.FromArgb(64, 64, 64);

            isEncodingType = false;
            OperateBtn.Text = "Выполнить дешифрование";
        }

        /// <summary>
        ///     Сворачивание программы.
        /// </summary>
        private void HideBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        ///     Выполнение шифрования/дешифрования
        /// </summary>
        private void OperateBtn_Click(object sender, EventArgs e)
        {
            if (((message == null || message == "") && messageInBytes == null) || outputPath == null || outputPath == "")
            {
                if (message == null || message == "")
                {
                    InputDataLbl.ForeColor = Color.Red;
                }
                if (outputPath == null || outputPath == "")
                {
                    OutputDataLbl.ForeColor = Color.Red;
                }

                StatusLbl.ForeColor = Color.Red;
                StatusLbl.Text = inputError;

                return;
            }

            string[] descriptions = null;
            object[] keys = null;
            int cols = 0, rows = 0;
            string keyWord1 = null, keyWord2 = null;

            switch (EncodingTypeBox.SelectedIndex)
            {
                case 0:
                case 3:
                case 4:
                    if (!CheckKeys(2))
                    {
                        return;
                    }

                    break;
                case 1:
                    if (!CheckKeys(3))
                    {
                        return;
                    }

                    break;
                case 2:
                    if (!CheckKeys(4))
                    {
                        return;
                    }

                    break;
            }

            switch (EncodingTypeBox.SelectedIndex)
            {
                case 0:
                    cols = int.Parse(Key1TBox.Text);
                    rows = int.Parse(Key2TBox.Text);

                    if (cols * rows < message.Length)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длина сообщения должна быть меньше произведения числа строк и столбцов!";

                        return;
                    }

                    descriptions = new string[] { "Количество столбцов", "Количество строк", EncodingTypeBox.SelectedItem.ToString() };
                    keys = new object[] { cols, rows };

                    break;
                case 1:
                    cols = int.Parse(Key1TBox.Text);
                    rows = int.Parse(Key2TBox.Text);
                    keyWord1 = Key3TBox.Text;

                    if (cols * rows < message.Length)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длина сообщения должна быть меньше произведения числа строк и столбцов!";

                        return;
                    }

                    if (keyWord1.Length != cols)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длина ключевого слова должна быть равна числу столбцов!";

                        return;
                    }

                    descriptions = new string[]{ "Количество столбцов", "Количество строк", "Ключевое слово",
                                                  EncodingTypeBox.SelectedItem.ToString() };
                    keys = new object[]{ cols, rows, keyWord1 };

                    break;
                case 2:
                    cols = int.Parse(Key1TBox.Text);
                    rows = int.Parse(Key2TBox.Text);
                    keyWord1 = Key3TBox.Text;
                    keyWord2 = Key4TBox.Text;

                    if (cols * rows < message.Length)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длина сообщения должна быть меньше произведения числа строк и столбцов!";

                        return;
                    }

                    if (rows != keyWord1.Length || cols != keyWord2.Length)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длины 1-го и 2-го ключей должны совпадать с числом строк и столбцов соотв.!";

                        return;
                    }        

                    descriptions = new string[] { "Количество столбцов", "Количество строк",
                                                  "1-ое ключевое слово", "2-ое ключевое слово",
                                                  EncodingTypeBox.SelectedItem.ToString() };
                    keys = new object[] { cols, rows, keyWord1, keyWord2 };

                    break;
                case 3:
                    keyWord1 = Key1TBox.Text;
                    keyWord2 = Key2TBox.Text;

                    if (keyWord1.Length > 32 || keyWord2.Length > 16)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длины 1-го и 2-го ключей должны быть менее 32 и 16 символов соотв.!";

                        return;
                    }

                    descriptions = new string[] { "1-ое ключевое слово", "2-ое ключевое слово",
                                                  EncodingTypeBox.SelectedItem.ToString() };
                    keys = new object[] { keyWord1, keyWord2 };

                    break;
                case 4:
                    keyWord1 = Key1TBox.Text;
                    keyWord2 = Key2TBox.Text;

                    if (keyWord1.Length > 8 || keyWord2.Length > 8)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длины 1-го и 2-го ключей должны быть менее 8 символов!";

                        return;
                    }

                    descriptions = new string[] { "1-ое ключевое слово", "2-ое ключевое слово",
                                                  EncodingTypeBox.SelectedItem.ToString() };
                    keys = new object[] { keyWord1, keyWord2 };

                    break;
                case 5:
                    keyWord1 = Key1TBox.Text;
                    keyWord2 = Key2TBox.Text;

                    if (keyWord1.Length > 24 || keyWord2.Length > 8)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длины 1-го и 2-го ключей должны быть менее 24 и 8 символов соотв.!";

                        return;
                    }

                    descriptions = new string[] { "1-ое ключевое слово", "2-ое ключевое слово",
                                                  EncodingTypeBox.SelectedItem.ToString() };
                    keys = new object[] { keyWord1, keyWord2 };

                    break;
                case 6:
                    keyWord1 = Key1TBox.Text;
                    keyWord2 = Key2TBox.Text;

                    if (keyWord1.Length > 16 || keyWord2.Length > 8)
                    {
                        KeysLbl.ForeColor = StatusLbl.ForeColor = Color.Red;
                        StatusLbl.Text = "Длины 1-го и 2-го ключей должны быть менее 16 и 8 символов соотв.!";

                        return;
                    }

                    descriptions = new string[] { "1-ое ключевое слово", "2-ое ключевое слово",
                                                  EncodingTypeBox.SelectedItem.ToString() };
                    keys = new object[] { keyWord1, keyWord2 };

                    break;
            }

            try
            {
                if (isEncodingType)
                {
                    switch (EncodingTypeBox.SelectedIndex)
                    {
                        case 0:
                            message = SymmetricCryptAlgoritms.SimplePermutation(message, cols, rows);
                            break;
                        case 1:
                            message = SymmetricCryptAlgoritms.SinglePermutationWithKey(message, cols, rows, keyWord1);
                            break;
                        case 2:
                            message = SymmetricCryptAlgoritms.DoublePermutation(message, cols, rows, keyWord1, keyWord2);
                            break;
                        case 3:
                            messageInBytes = SymmetricCryptAlgoritms.AESEncrypt(message, keyWord1, keyWord2);
                            break;
                        case 4:
                            messageInBytes = SymmetricCryptAlgoritms.DESEncrypt(message, keyWord1, keyWord2);
                            break;
                        case 5:
                            messageInBytes = SymmetricCryptAlgoritms.TripleDESEncrypt(message, keyWord1, keyWord2);
                            break;
                        case 6:
                            messageInBytes = SymmetricCryptAlgoritms.RC2Encrypt(message, keyWord1, keyWord2);
                            break;
                    }
                }
                else
                {
                    switch (EncodingTypeBox.SelectedIndex)
                    {
                        case 0:
                            message = SymmetricCryptAlgoritms.SimplePermutation_Decrypt(message, cols, rows);
                            break;
                        case 1:
                            message = SymmetricCryptAlgoritms.SinglePermutationWithKey_Decrypt(message, cols, rows, keyWord1);
                            break;
                        case 2:
                            message = SymmetricCryptAlgoritms.DoublePermutation_Decrypt(message, cols, rows, keyWord1, keyWord2);
                            break;
                        case 3:
                            message = SymmetricCryptAlgoritms.AESDecrypt(messageInBytes, keyWord1, keyWord2);
                            messageInBytes = null;
                            break;
                        case 4:
                            message = SymmetricCryptAlgoritms.DESDecrypt(messageInBytes, keyWord1, keyWord2);
                            messageInBytes = null;
                            break;
                        case 5:
                            message = SymmetricCryptAlgoritms.TripleDESDecrypt(messageInBytes, keyWord1, keyWord2);
                            messageInBytes = null;
                            break;
                        case 6:
                            message = SymmetricCryptAlgoritms.RC2Decrypt(messageInBytes, keyWord1, keyWord2);
                            messageInBytes = null;
                            break;
                    }
                }
            }
            catch (CryptographicException)
            {
                StatusLbl.ForeColor = Color.Red;
                StatusLbl.Text = "Не удалось выполнить операцию. Проверьте ключи и введенные данные";

                return;
            }

            if (messageInBytes != null)
            {
                switch (outputMode)
                {
                    case OutputMode.OnForm:
                        OutputUtils.OutputOnForm(messageInBytes, descriptions, keys, this);
                        break;
                    case OutputMode.InTXT:
                        OutputUtils.OutputInTXT(messageInBytes, descriptions, keys, outputPath);
                        break;
                    case OutputMode.InWord:
                        OutputUtils.OutputInWord(messageInBytes, descriptions, keys, outputPath);
                        break;
                }
            }
            else
            {
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
            }
            
            message = outputPath = "";
            messageInBytes = null;
            SelectedIFileLbl.Text = SelectedOFileLbl.Text = "";

            StatusLbl.ForeColor = Color.FromArgb(64, 64, 64);
            StatusLbl.Text = "Операция выполнена успешно!";

            ClearKeys();
        }

        /// <summary>
        ///     Ввод информации с клавиатуры
        /// </summary>
        private void KeyboardInputBtn_Click(object sender, EventArgs e)
        {
            MessageForm messageInputForm = new MessageForm(this);
            messageInputForm.ShowDialog();

            if ((message != null && message != "") || messageInBytes != null)
            {
                SelectedIFileLbl.Text = "Введены данные с клавиатуры";

                InputDataLbl.ForeColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                SelectedIFileLbl.Text = "";
            }
        }

        /// <summary>
        ///     Установка режима вывода информации на экран
        /// </summary>
        private void ScreenOutputBtn_Click(object sender, EventArgs e)
        {
            outputMode = OutputMode.OnForm;
            outputPath = "screen";

            SelectedOFileLbl.Text = "Данные будут выведены на экран";
        }

        /// <summary>
        ///     Чтение информации из текстового файла
        /// </summary>
        private void TXTInputBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = txtFilter;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);

                    int size = Convert.ToInt32(sr.ReadLine());
                    messageInBytes = new byte[size];

                    for (int i = 0; i < size; i++)
                    {
                        messageInBytes[i] = Convert.ToByte(sr.ReadLine());
                    }
                    message = null;

                    sr.Close();
                }
                catch
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);

                    message = sr.ReadToEnd();
                    messageInBytes = null;

                    sr.Close();
                }


                InputDataLbl.ForeColor = Color.FromArgb(64, 64, 64);

                var splited = openFileDialog1.FileName.Split('\\');
                SelectedIFileLbl.Text = splited[splited.Length - 1];
            }
        }

        /// <summary>
        ///     Установка текстового файла для вывода информации
        /// </summary>
        private void TXTOutputBtn_Click(object sender, EventArgs e)
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
        private void WordInputBtn_Click(object sender, EventArgs e)
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

                try
                {
                    int size = Convert.ToInt32(doc.Paragraphs[1].Range.Text);
                    messageInBytes = new byte[size];

                    for (int i = 0; i < size; i++)
                    {
                        messageInBytes[i] = Convert.ToByte(doc.Paragraphs[i + 2].Range.Text);
                    }
                    message = null;
                }
                catch
                {
                    message = "";
                    for (int i = 0; i < doc.Paragraphs.Count; i++)
                    {
                        message += doc.Paragraphs[i + 1].Range.Text;
                    }
                    messageInBytes = null;
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
        private void WordOutputBtn_Click(object sender, EventArgs e)
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
        private void EncodingTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (EncodingTypeBox.SelectedIndex)
            {
                case 0:
                    ShowKeyInputs(2);

                    Key1Lbl.Text = "Кол-во столбцов:";
                    Key2Lbl.Text = "Кол-во строк:";

                    break;
                case 1:
                    ShowKeyInputs(3);

                    Key1Lbl.Text = "Кол-во столбцов:";
                    Key2Lbl.Text = "Кол-во строк:";
                    Key3Lbl.Text = "Кодовое слово:";

                    break;
                case 2:
                    ShowKeyInputs(4);

                    Key1Lbl.Text = "Кол-во столбцов:";
                    Key2Lbl.Text = "Кол-во строк:";
                    Key3Lbl.Text = "1-ое кодовое слово:";
                    Key4Lbl.Text = "2-ое кодовое слово:";

                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                    ShowKeyInputs(2);

                    Key1Lbl.Text =  "1-ое кодовое слово:";
                    Key2Lbl.Text = "2-ое кодовое слово:";

                    break;
            }

            ClearKeys();
        }

        /// <summary>
        ///     Генерация ключей шифрования
        /// </summary>
        private void GenKeysBtn_Click(object sender, EventArgs e)
        {
            if (message == null || message == "")
            {
                InputDataLbl.ForeColor = Color.Red;

                StatusLbl.ForeColor = Color.Red;
                StatusLbl.Text = "Введите шифруемые данные";

                return;
            }

            switch (EncodingTypeBox.SelectedIndex)
            {
                case 0:
                    int cols, rows;
                    KeyGen.ForSimplePermutation(message.Length, out cols, out rows);

                    Key1TBox.Text = cols.ToString();
                    Key2TBox.Text = rows.ToString();

                    break;
                case 1:
                    string keyWord;
                    KeyGen.ForSinglePermutationWithKey(message.Length, out cols, out rows, out keyWord);

                    Key1TBox.Text = cols.ToString();
                    Key2TBox.Text = rows.ToString();
                    Key3TBox.Text = keyWord;

                    break;
                case 2:
                    string keyWord1;
                    string keyWord2;
                    KeyGen.ForDoublePermutation(message.Length, out cols, out rows, out keyWord1, out keyWord2);

                    Key1TBox.Text = cols.ToString();
                    Key2TBox.Text = rows.ToString();
                    Key3TBox.Text = keyWord1;
                    Key4TBox.Text = keyWord2;

                    break;
                case 3:
                    KeyGen.GenKeyAndIV(out keyWord1, out keyWord2, Aes.Create());

                    Key1TBox.Text = keyWord1;
                    Key2TBox.Text = keyWord2;

                    break;
                case 4:
                    KeyGen.GenKeyAndIV(out keyWord1, out keyWord2, DES.Create());

                    Key1TBox.Text = keyWord1;
                    Key2TBox.Text = keyWord2;

                    break;
                case 5:
                    KeyGen.GenKeyAndIV(out keyWord1, out keyWord2, TripleDES.Create());

                    Key1TBox.Text = keyWord1;
                    Key2TBox.Text = keyWord2;

                    break;
                case 6:
                    KeyGen.GenKeyAndIV(out keyWord1, out keyWord2, RC2.Create());

                    Key1TBox.Text = keyWord1;
                    Key2TBox.Text = keyWord2;

                    break;
            }
        }

        /// <summary>
        ///     Очистка ключей
        /// </summary>
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearKeys();
        }

        /// <summary>
        ///     Обработчик нажатия клавиш при вводе символов в поля для ввода ключей
        /// </summary>
        private void Key1TBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var KeyBox = sender as TextBox;

            switch (EncodingTypeBox.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    if (KeyBox == Key1TBox || KeyBox == Key2TBox)
                    {
                        if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                        {
                            e.Handled = true;
                        }
                    }

                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                    if (KeyBox == Key1TBox || KeyBox == Key2TBox)
                    {
                        if (e.KeyChar != '\b' && (e.KeyChar < 0 || e.KeyChar > 255))
                        {
                            e.Handled = true;
                        }
                    }

                    break;
            }
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

        /// <summary>
        ///     Выводит указанное количество полей для ввода ключей и скрывает остальные
        /// </summary>
        /// 
        /// <param name="count">
        ///     Количество отображаемых полей для ввода ключей
        /// </param>
        private void ShowKeyInputs(int count)
        {
            for (int i = 1; i < 9; i++)
            {
                var keyLbl = KeysPanel.Controls["Key" + i.ToString() + "Lbl"];
                var keyBox = KeysPanel.Controls["Key" + i.ToString() + "TBox"];

                if (i < count + 1)
                {
                    keyLbl.Visible = keyBox.Visible = true;
                }
                else
                {
                    keyLbl.Visible = keyBox.Visible = false;
                }
            }
        }
    }
}