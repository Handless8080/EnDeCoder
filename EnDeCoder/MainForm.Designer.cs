namespace EnDeCoder
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.EncodeBtn = new System.Windows.Forms.Button();
            this.DecodeBtn = new System.Windows.Forms.Button();
            this.ReferenceBtn = new System.Windows.Forms.Button();
            this.KeysPanel = new System.Windows.Forms.Panel();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.Key8TBox = new System.Windows.Forms.TextBox();
            this.Key8Lbl = new System.Windows.Forms.Label();
            this.Key7TBox = new System.Windows.Forms.TextBox();
            this.Key7Lbl = new System.Windows.Forms.Label();
            this.Key6TBox = new System.Windows.Forms.TextBox();
            this.Key6Lbl = new System.Windows.Forms.Label();
            this.Key5TBox = new System.Windows.Forms.TextBox();
            this.Key5Lbl = new System.Windows.Forms.Label();
            this.Key4TBox = new System.Windows.Forms.TextBox();
            this.Key4Lbl = new System.Windows.Forms.Label();
            this.Key3TBox = new System.Windows.Forms.TextBox();
            this.Key3Lbl = new System.Windows.Forms.Label();
            this.Key2TBox = new System.Windows.Forms.TextBox();
            this.Key2Lbl = new System.Windows.Forms.Label();
            this.Key1TBox = new System.Windows.Forms.TextBox();
            this.Key1Lbl = new System.Windows.Forms.Label();
            this.EncodingTypeLbl = new System.Windows.Forms.Label();
            this.EncodingTypeBox = new System.Windows.Forms.ComboBox();
            this.GenKeysBtn = new System.Windows.Forms.Button();
            this.KeysLbl = new System.Windows.Forms.Label();
            this.InputDataLbl = new System.Windows.Forms.Label();
            this.DataInputPanel = new System.Windows.Forms.Panel();
            this.SelectedIFileLbl = new System.Windows.Forms.Label();
            this.KeyboardInputBtn = new System.Windows.Forms.Button();
            this.TXTInputBtn = new System.Windows.Forms.Button();
            this.WordInputBtn = new System.Windows.Forms.Button();
            this.OperateBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.HideBtn = new System.Windows.Forms.Button();
            this.OutputDataLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SelectedOFileLbl = new System.Windows.Forms.Label();
            this.ScreenOutputBtn = new System.Windows.Forms.Button();
            this.TXTOutputBtn = new System.Windows.Forms.Button();
            this.WordOutputBtn = new System.Windows.Forms.Button();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.KeysPanel.SuspendLayout();
            this.DataInputPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(662, 24);
            this.Title.TabIndex = 1;
            this.Title.Text = "EnDeCoder";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            this.Title.MouseLeave += new System.EventHandler(this.Title_MouseLeave);
            this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Title_MouseMove);
            this.Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Title_MouseUp);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitBtn.BackColor = System.Drawing.Color.Red;
            this.ExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Location = new System.Drawing.Point(639, 0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(23, 23);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // EncodeBtn
            // 
            this.EncodeBtn.BackColor = System.Drawing.Color.Green;
            this.EncodeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EncodeBtn.FlatAppearance.BorderSize = 3;
            this.EncodeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.EncodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EncodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncodeBtn.ForeColor = System.Drawing.Color.White;
            this.EncodeBtn.Location = new System.Drawing.Point(12, 36);
            this.EncodeBtn.Name = "EncodeBtn";
            this.EncodeBtn.Size = new System.Drawing.Size(316, 35);
            this.EncodeBtn.TabIndex = 4;
            this.EncodeBtn.Text = "Шифрование";
            this.EncodeBtn.UseVisualStyleBackColor = false;
            this.EncodeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EncodeBtn_MouseClick);
            // 
            // DecodeBtn
            // 
            this.DecodeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DecodeBtn.BackColor = System.Drawing.Color.Green;
            this.DecodeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.DecodeBtn.FlatAppearance.BorderSize = 3;
            this.DecodeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.DecodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecodeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DecodeBtn.ForeColor = System.Drawing.Color.White;
            this.DecodeBtn.Location = new System.Drawing.Point(334, 36);
            this.DecodeBtn.Name = "DecodeBtn";
            this.DecodeBtn.Size = new System.Drawing.Size(316, 35);
            this.DecodeBtn.TabIndex = 5;
            this.DecodeBtn.Text = "Дешифрование";
            this.DecodeBtn.UseVisualStyleBackColor = false;
            this.DecodeBtn.Click += new System.EventHandler(this.DecodeBtn_Click);
            // 
            // ReferenceBtn
            // 
            this.ReferenceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReferenceBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.ReferenceBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ReferenceBtn.FlatAppearance.BorderSize = 0;
            this.ReferenceBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.ReferenceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReferenceBtn.Location = new System.Drawing.Point(614, 0);
            this.ReferenceBtn.Name = "ReferenceBtn";
            this.ReferenceBtn.Size = new System.Drawing.Size(23, 23);
            this.ReferenceBtn.TabIndex = 6;
            this.ReferenceBtn.UseVisualStyleBackColor = false;
            // 
            // KeysPanel
            // 
            this.KeysPanel.BackColor = System.Drawing.Color.White;
            this.KeysPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KeysPanel.Controls.Add(this.ClearBtn);
            this.KeysPanel.Controls.Add(this.Key8TBox);
            this.KeysPanel.Controls.Add(this.Key8Lbl);
            this.KeysPanel.Controls.Add(this.Key7TBox);
            this.KeysPanel.Controls.Add(this.Key7Lbl);
            this.KeysPanel.Controls.Add(this.Key6TBox);
            this.KeysPanel.Controls.Add(this.Key6Lbl);
            this.KeysPanel.Controls.Add(this.Key5TBox);
            this.KeysPanel.Controls.Add(this.Key5Lbl);
            this.KeysPanel.Controls.Add(this.Key4TBox);
            this.KeysPanel.Controls.Add(this.Key4Lbl);
            this.KeysPanel.Controls.Add(this.Key3TBox);
            this.KeysPanel.Controls.Add(this.Key3Lbl);
            this.KeysPanel.Controls.Add(this.Key2TBox);
            this.KeysPanel.Controls.Add(this.Key2Lbl);
            this.KeysPanel.Controls.Add(this.Key1TBox);
            this.KeysPanel.Controls.Add(this.Key1Lbl);
            this.KeysPanel.Controls.Add(this.EncodingTypeLbl);
            this.KeysPanel.Controls.Add(this.EncodingTypeBox);
            this.KeysPanel.Controls.Add(this.GenKeysBtn);
            this.KeysPanel.Location = new System.Drawing.Point(12, 99);
            this.KeysPanel.Name = "KeysPanel";
            this.KeysPanel.Size = new System.Drawing.Size(316, 254);
            this.KeysPanel.TabIndex = 7;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearBtn.BackColor = System.Drawing.Color.Gray;
            this.ClearBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.Location = new System.Drawing.Point(3, 226);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(152, 23);
            this.ClearBtn.TabIndex = 33;
            this.ClearBtn.Text = "Очистить поля";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // Key8TBox
            // 
            this.Key8TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key8TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key8TBox.Location = new System.Drawing.Point(159, 186);
            this.Key8TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key8TBox.Name = "Key8TBox";
            this.Key8TBox.Size = new System.Drawing.Size(152, 21);
            this.Key8TBox.TabIndex = 32;
            this.Key8TBox.Visible = false;
            // 
            // Key8Lbl
            // 
            this.Key8Lbl.AutoSize = true;
            this.Key8Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key8Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key8Lbl.Location = new System.Drawing.Point(158, 167);
            this.Key8Lbl.Name = "Key8Lbl";
            this.Key8Lbl.Size = new System.Drawing.Size(44, 15);
            this.Key8Lbl.TabIndex = 31;
            this.Key8Lbl.Text = "Ключ8";
            this.Key8Lbl.Visible = false;
            // 
            // Key7TBox
            // 
            this.Key7TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key7TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key7TBox.Location = new System.Drawing.Point(3, 186);
            this.Key7TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key7TBox.Name = "Key7TBox";
            this.Key7TBox.Size = new System.Drawing.Size(152, 21);
            this.Key7TBox.TabIndex = 30;
            this.Key7TBox.Visible = false;
            // 
            // Key7Lbl
            // 
            this.Key7Lbl.AutoSize = true;
            this.Key7Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key7Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key7Lbl.Location = new System.Drawing.Point(3, 167);
            this.Key7Lbl.Name = "Key7Lbl";
            this.Key7Lbl.Size = new System.Drawing.Size(44, 15);
            this.Key7Lbl.TabIndex = 29;
            this.Key7Lbl.Text = "Ключ7";
            this.Key7Lbl.Visible = false;
            // 
            // Key6TBox
            // 
            this.Key6TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key6TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key6TBox.Location = new System.Drawing.Point(159, 145);
            this.Key6TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key6TBox.Name = "Key6TBox";
            this.Key6TBox.Size = new System.Drawing.Size(152, 21);
            this.Key6TBox.TabIndex = 28;
            this.Key6TBox.Visible = false;
            // 
            // Key6Lbl
            // 
            this.Key6Lbl.AutoSize = true;
            this.Key6Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key6Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key6Lbl.Location = new System.Drawing.Point(158, 126);
            this.Key6Lbl.Name = "Key6Lbl";
            this.Key6Lbl.Size = new System.Drawing.Size(44, 15);
            this.Key6Lbl.TabIndex = 27;
            this.Key6Lbl.Text = "Ключ6";
            this.Key6Lbl.Visible = false;
            // 
            // Key5TBox
            // 
            this.Key5TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key5TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key5TBox.Location = new System.Drawing.Point(3, 145);
            this.Key5TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key5TBox.Name = "Key5TBox";
            this.Key5TBox.Size = new System.Drawing.Size(152, 21);
            this.Key5TBox.TabIndex = 26;
            this.Key5TBox.Visible = false;
            // 
            // Key5Lbl
            // 
            this.Key5Lbl.AutoSize = true;
            this.Key5Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key5Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key5Lbl.Location = new System.Drawing.Point(3, 126);
            this.Key5Lbl.Name = "Key5Lbl";
            this.Key5Lbl.Size = new System.Drawing.Size(44, 15);
            this.Key5Lbl.TabIndex = 25;
            this.Key5Lbl.Text = "Ключ5";
            this.Key5Lbl.Visible = false;
            // 
            // Key4TBox
            // 
            this.Key4TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key4TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key4TBox.Location = new System.Drawing.Point(159, 105);
            this.Key4TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key4TBox.Name = "Key4TBox";
            this.Key4TBox.Size = new System.Drawing.Size(152, 21);
            this.Key4TBox.TabIndex = 24;
            this.Key4TBox.Visible = false;
            // 
            // Key4Lbl
            // 
            this.Key4Lbl.AutoSize = true;
            this.Key4Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key4Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key4Lbl.Location = new System.Drawing.Point(158, 86);
            this.Key4Lbl.Name = "Key4Lbl";
            this.Key4Lbl.Size = new System.Drawing.Size(44, 15);
            this.Key4Lbl.TabIndex = 23;
            this.Key4Lbl.Text = "Ключ4";
            this.Key4Lbl.Visible = false;
            // 
            // Key3TBox
            // 
            this.Key3TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key3TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key3TBox.Location = new System.Drawing.Point(3, 105);
            this.Key3TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key3TBox.Name = "Key3TBox";
            this.Key3TBox.Size = new System.Drawing.Size(152, 21);
            this.Key3TBox.TabIndex = 22;
            this.Key3TBox.Visible = false;
            // 
            // Key3Lbl
            // 
            this.Key3Lbl.AutoSize = true;
            this.Key3Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key3Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key3Lbl.Location = new System.Drawing.Point(3, 86);
            this.Key3Lbl.Name = "Key3Lbl";
            this.Key3Lbl.Size = new System.Drawing.Size(44, 15);
            this.Key3Lbl.TabIndex = 21;
            this.Key3Lbl.Text = "Ключ3";
            this.Key3Lbl.Visible = false;
            // 
            // Key2TBox
            // 
            this.Key2TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key2TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key2TBox.Location = new System.Drawing.Point(159, 63);
            this.Key2TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key2TBox.Name = "Key2TBox";
            this.Key2TBox.Size = new System.Drawing.Size(152, 21);
            this.Key2TBox.TabIndex = 20;
            // 
            // Key2Lbl
            // 
            this.Key2Lbl.AutoSize = true;
            this.Key2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key2Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key2Lbl.Location = new System.Drawing.Point(158, 44);
            this.Key2Lbl.Name = "Key2Lbl";
            this.Key2Lbl.Size = new System.Drawing.Size(86, 15);
            this.Key2Lbl.TabIndex = 19;
            this.Key2Lbl.Text = "Кол-во строк:";
            // 
            // Key1TBox
            // 
            this.Key1TBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Key1TBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key1TBox.Location = new System.Drawing.Point(3, 63);
            this.Key1TBox.Margin = new System.Windows.Forms.Padding(2);
            this.Key1TBox.Name = "Key1TBox";
            this.Key1TBox.Size = new System.Drawing.Size(152, 21);
            this.Key1TBox.TabIndex = 18;
            // 
            // Key1Lbl
            // 
            this.Key1Lbl.AutoSize = true;
            this.Key1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Key1Lbl.ForeColor = System.Drawing.Color.Black;
            this.Key1Lbl.Location = new System.Drawing.Point(3, 44);
            this.Key1Lbl.Name = "Key1Lbl";
            this.Key1Lbl.Size = new System.Drawing.Size(108, 15);
            this.Key1Lbl.TabIndex = 17;
            this.Key1Lbl.Text = "Кол-во столбцов:";
            // 
            // EncodingTypeLbl
            // 
            this.EncodingTypeLbl.AutoSize = true;
            this.EncodingTypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncodingTypeLbl.ForeColor = System.Drawing.Color.Black;
            this.EncodingTypeLbl.Location = new System.Drawing.Point(3, 0);
            this.EncodingTypeLbl.Name = "EncodingTypeLbl";
            this.EncodingTypeLbl.Size = new System.Drawing.Size(145, 15);
            this.EncodingTypeLbl.TabIndex = 16;
            this.EncodingTypeLbl.Text = "Метод шифрования:";
            // 
            // EncodingTypeBox
            // 
            this.EncodingTypeBox.BackColor = System.Drawing.Color.White;
            this.EncodingTypeBox.DisplayMember = "(нет)";
            this.EncodingTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingTypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EncodingTypeBox.FormattingEnabled = true;
            this.EncodingTypeBox.Items.AddRange(new object[] {
            "Простая перестановка",
            "Простая перестановка по ключу",
            "Двойная перестановка"});
            this.EncodingTypeBox.Location = new System.Drawing.Point(3, 18);
            this.EncodingTypeBox.MaxDropDownItems = 5;
            this.EncodingTypeBox.Name = "EncodingTypeBox";
            this.EncodingTypeBox.Size = new System.Drawing.Size(308, 23);
            this.EncodingTypeBox.TabIndex = 1;
            this.EncodingTypeBox.SelectedIndexChanged += new System.EventHandler(this.EncodingTypeBox_SelectedIndexChanged);
            // 
            // GenKeysBtn
            // 
            this.GenKeysBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GenKeysBtn.BackColor = System.Drawing.Color.Gray;
            this.GenKeysBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GenKeysBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenKeysBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenKeysBtn.ForeColor = System.Drawing.Color.White;
            this.GenKeysBtn.Location = new System.Drawing.Point(159, 226);
            this.GenKeysBtn.Name = "GenKeysBtn";
            this.GenKeysBtn.Size = new System.Drawing.Size(152, 23);
            this.GenKeysBtn.TabIndex = 0;
            this.GenKeysBtn.Text = "Сгенерировать ключи";
            this.GenKeysBtn.UseVisualStyleBackColor = false;
            // 
            // KeysLbl
            // 
            this.KeysLbl.AutoSize = true;
            this.KeysLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeysLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.KeysLbl.Location = new System.Drawing.Point(12, 79);
            this.KeysLbl.Name = "KeysLbl";
            this.KeysLbl.Size = new System.Drawing.Size(61, 17);
            this.KeysLbl.TabIndex = 8;
            this.KeysLbl.Text = "Ключи:";
            // 
            // InputDataLbl
            // 
            this.InputDataLbl.AutoSize = true;
            this.InputDataLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputDataLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InputDataLbl.Location = new System.Drawing.Point(334, 79);
            this.InputDataLbl.Name = "InputDataLbl";
            this.InputDataLbl.Size = new System.Drawing.Size(108, 17);
            this.InputDataLbl.TabIndex = 10;
            this.InputDataLbl.Text = "Ввод данных:";
            // 
            // DataInputPanel
            // 
            this.DataInputPanel.BackColor = System.Drawing.Color.White;
            this.DataInputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataInputPanel.Controls.Add(this.SelectedIFileLbl);
            this.DataInputPanel.Controls.Add(this.KeyboardInputBtn);
            this.DataInputPanel.Controls.Add(this.TXTInputBtn);
            this.DataInputPanel.Controls.Add(this.WordInputBtn);
            this.DataInputPanel.Location = new System.Drawing.Point(334, 99);
            this.DataInputPanel.Name = "DataInputPanel";
            this.DataInputPanel.Size = new System.Drawing.Size(316, 114);
            this.DataInputPanel.TabIndex = 9;
            // 
            // SelectedIFileLbl
            // 
            this.SelectedIFileLbl.AutoSize = true;
            this.SelectedIFileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedIFileLbl.ForeColor = System.Drawing.Color.Black;
            this.SelectedIFileLbl.Location = new System.Drawing.Point(3, 87);
            this.SelectedIFileLbl.Name = "SelectedIFileLbl";
            this.SelectedIFileLbl.Size = new System.Drawing.Size(0, 17);
            this.SelectedIFileLbl.TabIndex = 12;
            // 
            // KeyboardInputBtn
            // 
            this.KeyboardInputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyboardInputBtn.BackColor = System.Drawing.Color.Gray;
            this.KeyboardInputBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.KeyboardInputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KeyboardInputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyboardInputBtn.ForeColor = System.Drawing.Color.White;
            this.KeyboardInputBtn.Location = new System.Drawing.Point(3, 61);
            this.KeyboardInputBtn.Name = "KeyboardInputBtn";
            this.KeyboardInputBtn.Size = new System.Drawing.Size(308, 23);
            this.KeyboardInputBtn.TabIndex = 3;
            this.KeyboardInputBtn.Text = "Ввести вручную с клавиатуры";
            this.KeyboardInputBtn.UseVisualStyleBackColor = false;
            this.KeyboardInputBtn.Click += new System.EventHandler(this.KeyboardInputBtn_Click);
            // 
            // TXTInputBtn
            // 
            this.TXTInputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTInputBtn.BackColor = System.Drawing.Color.Gray;
            this.TXTInputBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TXTInputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TXTInputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TXTInputBtn.ForeColor = System.Drawing.Color.White;
            this.TXTInputBtn.Location = new System.Drawing.Point(3, 32);
            this.TXTInputBtn.Name = "TXTInputBtn";
            this.TXTInputBtn.Size = new System.Drawing.Size(308, 23);
            this.TXTInputBtn.TabIndex = 2;
            this.TXTInputBtn.Text = "Ввести из текстового документа";
            this.TXTInputBtn.UseVisualStyleBackColor = false;
            this.TXTInputBtn.Click += new System.EventHandler(this.TXTInputBtn_Click);
            // 
            // WordInputBtn
            // 
            this.WordInputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WordInputBtn.BackColor = System.Drawing.Color.Gray;
            this.WordInputBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WordInputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WordInputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordInputBtn.ForeColor = System.Drawing.Color.White;
            this.WordInputBtn.Location = new System.Drawing.Point(3, 3);
            this.WordInputBtn.Name = "WordInputBtn";
            this.WordInputBtn.Size = new System.Drawing.Size(308, 23);
            this.WordInputBtn.TabIndex = 1;
            this.WordInputBtn.Text = "Ввести из документа MS Word";
            this.WordInputBtn.UseVisualStyleBackColor = false;
            this.WordInputBtn.Click += new System.EventHandler(this.WordInputBtn_Click);
            // 
            // OperateBtn
            // 
            this.OperateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperateBtn.BackColor = System.Drawing.Color.Green;
            this.OperateBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.OperateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.OperateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OperateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperateBtn.ForeColor = System.Drawing.Color.White;
            this.OperateBtn.Location = new System.Drawing.Point(12, 378);
            this.OperateBtn.Name = "OperateBtn";
            this.OperateBtn.Size = new System.Drawing.Size(638, 35);
            this.OperateBtn.TabIndex = 11;
            this.OperateBtn.Text = "Выполнить шифрование";
            this.OperateBtn.UseVisualStyleBackColor = false;
            this.OperateBtn.Click += new System.EventHandler(this.OperateBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // HideBtn
            // 
            this.HideBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HideBtn.BackColor = System.Drawing.Color.White;
            this.HideBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.HideBtn.FlatAppearance.BorderSize = 0;
            this.HideBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.HideBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideBtn.Location = new System.Drawing.Point(590, 0);
            this.HideBtn.Name = "HideBtn";
            this.HideBtn.Size = new System.Drawing.Size(23, 23);
            this.HideBtn.TabIndex = 12;
            this.HideBtn.UseVisualStyleBackColor = false;
            this.HideBtn.Click += new System.EventHandler(this.HideBtn_Click);
            // 
            // OutputDataLbl
            // 
            this.OutputDataLbl.AutoSize = true;
            this.OutputDataLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputDataLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OutputDataLbl.Location = new System.Drawing.Point(334, 219);
            this.OutputDataLbl.Name = "OutputDataLbl";
            this.OutputDataLbl.Size = new System.Drawing.Size(119, 17);
            this.OutputDataLbl.TabIndex = 14;
            this.OutputDataLbl.Text = "Вывод данных:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SelectedOFileLbl);
            this.panel1.Controls.Add(this.ScreenOutputBtn);
            this.panel1.Controls.Add(this.TXTOutputBtn);
            this.panel1.Controls.Add(this.WordOutputBtn);
            this.panel1.Location = new System.Drawing.Point(334, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 114);
            this.panel1.TabIndex = 13;
            // 
            // SelectedOFileLbl
            // 
            this.SelectedOFileLbl.AutoSize = true;
            this.SelectedOFileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedOFileLbl.ForeColor = System.Drawing.Color.Black;
            this.SelectedOFileLbl.Location = new System.Drawing.Point(3, 87);
            this.SelectedOFileLbl.Name = "SelectedOFileLbl";
            this.SelectedOFileLbl.Size = new System.Drawing.Size(0, 17);
            this.SelectedOFileLbl.TabIndex = 13;
            // 
            // ScreenOutputBtn
            // 
            this.ScreenOutputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenOutputBtn.BackColor = System.Drawing.Color.Gray;
            this.ScreenOutputBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ScreenOutputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenOutputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScreenOutputBtn.ForeColor = System.Drawing.Color.White;
            this.ScreenOutputBtn.Location = new System.Drawing.Point(3, 61);
            this.ScreenOutputBtn.Name = "ScreenOutputBtn";
            this.ScreenOutputBtn.Size = new System.Drawing.Size(308, 23);
            this.ScreenOutputBtn.TabIndex = 3;
            this.ScreenOutputBtn.Text = "Вывести на экран";
            this.ScreenOutputBtn.UseVisualStyleBackColor = false;
            this.ScreenOutputBtn.Click += new System.EventHandler(this.ScreenOutputBtn_Click);
            // 
            // TXTOutputBtn
            // 
            this.TXTOutputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TXTOutputBtn.BackColor = System.Drawing.Color.Gray;
            this.TXTOutputBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TXTOutputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TXTOutputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TXTOutputBtn.ForeColor = System.Drawing.Color.White;
            this.TXTOutputBtn.Location = new System.Drawing.Point(3, 32);
            this.TXTOutputBtn.Name = "TXTOutputBtn";
            this.TXTOutputBtn.Size = new System.Drawing.Size(308, 23);
            this.TXTOutputBtn.TabIndex = 2;
            this.TXTOutputBtn.Text = "Вывести в текстовый документ";
            this.TXTOutputBtn.UseVisualStyleBackColor = false;
            this.TXTOutputBtn.Click += new System.EventHandler(this.TXTOutputBtn_Click);
            // 
            // WordOutputBtn
            // 
            this.WordOutputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WordOutputBtn.BackColor = System.Drawing.Color.Gray;
            this.WordOutputBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WordOutputBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WordOutputBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordOutputBtn.ForeColor = System.Drawing.Color.White;
            this.WordOutputBtn.Location = new System.Drawing.Point(3, 3);
            this.WordOutputBtn.Name = "WordOutputBtn";
            this.WordOutputBtn.Size = new System.Drawing.Size(308, 23);
            this.WordOutputBtn.TabIndex = 1;
            this.WordOutputBtn.Text = "Вывести в документ MS Word";
            this.WordOutputBtn.UseVisualStyleBackColor = false;
            this.WordOutputBtn.Click += new System.EventHandler(this.WordOutputBtn_Click);
            // 
            // StatusLbl
            // 
            this.StatusLbl.AutoSize = true;
            this.StatusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StatusLbl.Location = new System.Drawing.Point(12, 356);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(0, 17);
            this.StatusLbl.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(662, 425);
            this.Controls.Add(this.StatusLbl);
            this.Controls.Add(this.OutputDataLbl);
            this.Controls.Add(this.OperateBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HideBtn);
            this.Controls.Add(this.InputDataLbl);
            this.Controls.Add(this.DataInputPanel);
            this.Controls.Add(this.KeysLbl);
            this.Controls.Add(this.KeysPanel);
            this.Controls.Add(this.ReferenceBtn);
            this.Controls.Add(this.DecodeBtn);
            this.Controls.Add(this.EncodeBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeysPanel.ResumeLayout(false);
            this.KeysPanel.PerformLayout();
            this.DataInputPanel.ResumeLayout(false);
            this.DataInputPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button EncodeBtn;
        private System.Windows.Forms.Button DecodeBtn;
        private System.Windows.Forms.Button ReferenceBtn;
        private System.Windows.Forms.Label KeysLbl;
        private System.Windows.Forms.Label InputDataLbl;
        private System.Windows.Forms.Panel DataInputPanel;
        private System.Windows.Forms.Button GenKeysBtn;
        private System.Windows.Forms.Button WordInputBtn;
        private System.Windows.Forms.Button TXTInputBtn;
        private System.Windows.Forms.Button KeyboardInputBtn;
        private System.Windows.Forms.Button OperateBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button HideBtn;
        private System.Windows.Forms.Label OutputDataLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ScreenOutputBtn;
        private System.Windows.Forms.Button TXTOutputBtn;
        private System.Windows.Forms.Button WordOutputBtn;
        private System.Windows.Forms.Label SelectedOFileLbl;
        private System.Windows.Forms.Label SelectedIFileLbl;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Label EncodingTypeLbl;
        private System.Windows.Forms.ComboBox EncodingTypeBox;
        private System.Windows.Forms.Label Key1Lbl;
        private System.Windows.Forms.TextBox Key1TBox;
        private System.Windows.Forms.TextBox Key2TBox;
        private System.Windows.Forms.Label Key2Lbl;
        private System.Windows.Forms.TextBox Key8TBox;
        private System.Windows.Forms.Label Key8Lbl;
        private System.Windows.Forms.TextBox Key7TBox;
        private System.Windows.Forms.Label Key7Lbl;
        private System.Windows.Forms.TextBox Key6TBox;
        private System.Windows.Forms.Label Key6Lbl;
        private System.Windows.Forms.TextBox Key5TBox;
        private System.Windows.Forms.Label Key5Lbl;
        private System.Windows.Forms.TextBox Key4TBox;
        private System.Windows.Forms.Label Key4Lbl;
        private System.Windows.Forms.TextBox Key3TBox;
        private System.Windows.Forms.Label Key3Lbl;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Panel KeysPanel;
    }
}

