namespace Rabin_Window
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
            this.tbtSecretKey1 = new System.Windows.Forms.TextBox();
            this.tbtSecretKey2 = new System.Windows.Forms.TextBox();
            this.tbtContent = new System.Windows.Forms.TextBox();
            this.lblSecretKey1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoose = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblConstNumbCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNuberCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNumberByteConutConst = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblbyteCountNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConstlblKeyByte = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKeyByteCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.btnLoadKeyFromFile = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbtSecretKey1
            // 
            this.tbtSecretKey1.Location = new System.Drawing.Point(205, 44);
            this.tbtSecretKey1.Name = "tbtSecretKey1";
            this.tbtSecretKey1.Size = new System.Drawing.Size(363, 20);
            this.tbtSecretKey1.TabIndex = 0;
            this.tbtSecretKey1.Text = "\n42764507373891426737894787167122204810987143475912511814131712839262784842723802" +
    "2492911827679032622";
            // 
            // tbtSecretKey2
            // 
            this.tbtSecretKey2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbtSecretKey2.Location = new System.Drawing.Point(574, 44);
            this.tbtSecretKey2.Name = "tbtSecretKey2";
            this.tbtSecretKey2.Size = new System.Drawing.Size(398, 20);
            this.tbtSecretKey2.TabIndex = 2;
            this.tbtSecretKey2.Text = "342116058991131413903158297336977638487897147807312035781981305767497979062906827" +
    "2599455932103088821";
            // 
            // tbtContent
            // 
            this.tbtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbtContent.Location = new System.Drawing.Point(12, 67);
            this.tbtContent.Multiline = true;
            this.tbtContent.Name = "tbtContent";
            this.tbtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbtContent.Size = new System.Drawing.Size(960, 431);
            this.tbtContent.TabIndex = 3;
            this.tbtContent.TextChanged += new System.EventHandler(this.tbtContent_TextChanged);
            // 
            // lblSecretKey1
            // 
            this.lblSecretKey1.AutoSize = true;
            this.lblSecretKey1.Location = new System.Drawing.Point(320, 28);
            this.lblSecretKey1.Name = "lblSecretKey1";
            this.lblSecretKey1.Size = new System.Drawing.Size(91, 13);
            this.lblSecretKey1.TabIndex = 4;
            this.lblSecretKey1.Text = "Секретный ключ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(686, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Открытый ключ";
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.Location = new System.Drawing.Point(897, 504);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 6;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancle.Location = new System.Drawing.Point(12, 504);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 8;
            this.btnCancle.Text = "В меню";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(574, 7);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 9;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbtFilePath
            // 
            this.tbtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbtFilePath.Location = new System.Drawing.Point(98, 9);
            this.tbtFilePath.Name = "tbtFilePath";
            this.tbtFilePath.Size = new System.Drawing.Size(378, 20);
            this.tbtFilePath.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Выбрать файл:";
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.Location = new System.Drawing.Point(493, 7);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 23);
            this.btnChoose.TabIndex = 12;
            this.btnChoose.Text = "Выбрать";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConstNumbCount,
            this.lblNuberCount,
            this.lblNumberByteConutConst,
            this.lblbyteCountNumber,
            this.ConstlblKeyByte,
            this.lblKeyByteCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblConstNumbCount
            // 
            this.lblConstNumbCount.Name = "lblConstNumbCount";
            this.lblConstNumbCount.Size = new System.Drawing.Size(133, 17);
            this.lblConstNumbCount.Text = "Количество символов:";
            this.lblConstNumbCount.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // lblNuberCount
            // 
            this.lblNuberCount.Name = "lblNuberCount";
            this.lblNuberCount.Size = new System.Drawing.Size(0, 17);
            // 
            // lblNumberByteConutConst
            // 
            this.lblNumberByteConutConst.Name = "lblNumberByteConutConst";
            this.lblNumberByteConutConst.Size = new System.Drawing.Size(102, 17);
            this.lblNumberByteConutConst.Text = "Количества байт:";
            // 
            // lblbyteCountNumber
            // 
            this.lblbyteCountNumber.Name = "lblbyteCountNumber";
            this.lblbyteCountNumber.Size = new System.Drawing.Size(0, 17);
            // 
            // ConstlblKeyByte
            // 
            this.ConstlblKeyByte.Name = "ConstlblKeyByte";
            this.ConstlblKeyByte.Size = new System.Drawing.Size(175, 17);
            this.ConstlblKeyByte.Text = "Размер блока байт для ключа:";
            // 
            // lblKeyByteCount
            // 
            this.lblKeyByteCount.Name = "lblKeyByteCount";
            this.lblKeyByteCount.Size = new System.Drawing.Size(13, 17);
            this.lblKeyByteCount.Text = "0";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAs.Location = new System.Drawing.Point(802, 504);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(89, 23);
            this.btnSaveAs.TabIndex = 14;
            this.btnSaveAs.Text = "Соранить как";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnLoadKeyFromFile
            // 
            this.btnLoadKeyFromFile.Location = new System.Drawing.Point(12, 41);
            this.btnLoadKeyFromFile.Name = "btnLoadKeyFromFile";
            this.btnLoadKeyFromFile.Size = new System.Drawing.Size(187, 23);
            this.btnLoadKeyFromFile.TabIndex = 15;
            this.btnLoadKeyFromFile.Text = "Загрузить ключ из файла";
            this.btnLoadKeyFromFile.UseVisualStyleBackColor = true;
            this.btnLoadKeyFromFile.Click += new System.EventHandler(this.btnLoadKeyFromFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnLoadKeyFromFile);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbtFilePath);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSecretKey1);
            this.Controls.Add(this.tbtContent);
            this.Controls.Add(this.tbtSecretKey2);
            this.Controls.Add(this.tbtSecretKey1);
            this.MinimumSize = new System.Drawing.Size(810, 360);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно вычисления и проверки подписи";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbtSecretKey1;
        private System.Windows.Forms.TextBox tbtSecretKey2;
        private System.Windows.Forms.TextBox tbtContent;
        private System.Windows.Forms.Label lblSecretKey1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblConstNumbCount;
        private System.Windows.Forms.ToolStripStatusLabel lblNuberCount;
        private System.Windows.Forms.ToolStripStatusLabel lblNumberByteConutConst;
        private System.Windows.Forms.ToolStripStatusLabel lblbyteCountNumber;
        private System.Windows.Forms.Button btnSaveAs;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ProgressBar progresBar;
        private System.Windows.Forms.Button btnLoadKeyFromFile;
        private System.Windows.Forms.ToolStripStatusLabel ConstlblKeyByte;
        private System.Windows.Forms.ToolStripStatusLabel lblKeyByteCount;
    }
}

