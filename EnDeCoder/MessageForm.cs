using System;
using System.Drawing;
using System.Windows.Forms;

namespace EnDeCoder
{
    public partial class MessageForm : Form
    {
        private MainForm parent;
        private bool isInputForm;

        private bool move = false;
        private int formLocationX;
        private int formLocationY;

        public MessageForm(MainForm parent)
        {
            InitializeComponent();

            this.parent = parent;
            isInputForm = true;

            MessageInput.Text = parent.message;
        }

        /// <summary>
        ///     Создает форму и заполняет ее переданными данными
        /// </summary>
        /// 
        /// <param name="parent">
        ///     Ссылка на родительскую форму
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
        /// <param name="message">
        ///     Полученная информация
        /// </param>
        public MessageForm(MainForm parent, string[] descriptions, object[] keys, string message)
        {
            InitializeComponent();

            this.parent = parent;
            isInputForm = false;

            MessageInput.Text = "Метод шифрования: " + descriptions[descriptions.Length - 1] + "\r\n\r\n";
            MessageInput.Text += "Ключи:\r\n\r\n";
            for (int i = 0; i < keys.Length; i++)
            {
                MessageInput.Text += descriptions[i] + ": " + keys[i] + "\r\n";
            }
            MessageInput.Text += "\r\nПолученные текстовые данные:\r\n\r\n" + message;

            EnterBtn.BackColor = Color.Green;
            EnterBtn.Enabled = true;
            EnterBtn.Text = "Скопировать";

            MessageInput.ReadOnly = true;
        }

        /// <summary>
        ///     Создает форму и заполняет ее переданными данными
        /// </summary>
        /// 
        /// <param name="parent">
        ///     Ссылка на родительскую форму
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
        /// <param name="message">
        ///     Полученная информация в виде последовательности байтов
        /// </param>
        public MessageForm(MainForm parent, string[] descriptions, object[] keys, byte[] message)
        {
            InitializeComponent();

            this.parent = parent;
            isInputForm = false;

            MessageInput.Text = "Метод шифрования: " + descriptions[descriptions.Length - 1] + "\r\n\r\n";
            MessageInput.Text += "Ключи:\r\n\r\n";
            for (int i = 0; i < keys.Length; i++)
            {
                MessageInput.Text += descriptions[i] + ": " + keys[i] + "\r\n";
            }
            MessageInput.Text += "\r\nПолученные текстовые данные:\r\n\r\n" + message.Length;
            foreach (byte b in message)
            {
                MessageInput.Text += "\r\n" + b;
            }

            EnterBtn.BackColor = Color.Green;
            EnterBtn.Enabled = true;
            EnterBtn.Text = "Скопировать";

            MessageInput.ReadOnly = true;
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
        ///     Блокирует перемещение формы при покидании области компонента.
        /// </summary>
        private void Title_MouseLeave(object sender, EventArgs e)
        {
            Title_MouseUp(null, null);
        }

        /// <summary>
        ///     Закрытие формы
        /// </summary>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Копирование в буффер обмена/ввод информации
        /// </summary>
        private void EnterBtn_Click(object sender, EventArgs e)
        {
            if (isInputForm)
            {
                try
                {
                    var strings = MessageInput.Text.Split('\r', '\n');
                    int size = Convert.ToInt32(strings[0]);
                    parent.messageInBytes = new byte[size];

                    for (int i = 0; i < size; i++)
                    {
                        parent.messageInBytes[i] = Convert.ToByte(strings[(i + 1) * 2]);
                    }

                    parent.message = null;
                }
                catch
                {
                    parent.messageInBytes = null;
                    parent.message = MessageInput.Text;
                }

                Close();
            }
            else
            {
                Clipboard.SetText(MessageInput.Text);
            }
        }

        /// <summary>
        ///     Обработчик изменения текста в TextBox
        /// </summary>
        private void MessageInput_TextChanged(object sender, EventArgs e)
        {
            if (MessageInput.Text == null || MessageInput.Text == "")
            {
                EnterBtn.Enabled = false;
                EnterBtn.BackColor = Color.Gray;
            }
            else
            {
                EnterBtn.Enabled = true;
                EnterBtn.BackColor = Color.Green;
            }
        }
    }
}