namespace OpenkeyWindow
{
    partial class OpenKeyForm
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
            this.tbtOpenKey = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.tbtContent = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSymbolCountConst = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSymbolCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblByteCountConst = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblByte = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConstKeyByte = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKeyByteCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOpenkey = new System.Windows.Forms.Label();
            this.btnGoToMenu = new System.Windows.Forms.Button();
            this.btnLoadOpneKeyFromFile = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbtOpenKey
            // 
            this.tbtOpenKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbtOpenKey.Location = new System.Drawing.Point(327, 11);
            this.tbtOpenKey.Name = "tbtOpenKey";
            this.tbtOpenKey.Size = new System.Drawing.Size(423, 20);
            this.tbtOpenKey.TabIndex = 0;
            this.tbtOpenKey.Text = "996178943546370874434617223229136763398160471277070982109844996503871352809714589" +
    "187947039619199549";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(105, 9);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(133, 23);
            this.butSave.TabIndex = 1;
            this.butSave.Text = "Проверить подпись";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // tbtContent
            // 
            this.tbtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbtContent.Location = new System.Drawing.Point(0, 46);
            this.tbtContent.Multiline = true;
            this.tbtContent.Name = "tbtContent";
            this.tbtContent.Size = new System.Drawing.Size(984, 490);
            this.tbtContent.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSymbolCountConst,
            this.lblSymbolCount,
            this.lblByteCountConst,
            this.lblByte,
            this.ConstKeyByte,
            this.lblKeyByteCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblSymbolCountConst
            // 
            this.lblSymbolCountConst.Name = "lblSymbolCountConst";
            this.lblSymbolCountConst.Size = new System.Drawing.Size(140, 17);
            this.lblSymbolCountConst.Text = "Количество симоволов:";
            // 
            // lblSymbolCount
            // 
            this.lblSymbolCount.Name = "lblSymbolCount";
            this.lblSymbolCount.Size = new System.Drawing.Size(13, 17);
            this.lblSymbolCount.Text = "0";
            // 
            // lblByteCountConst
            // 
            this.lblByteCountConst.Name = "lblByteCountConst";
            this.lblByteCountConst.Size = new System.Drawing.Size(103, 17);
            this.lblByteCountConst.Text = "Количество байт:";
            // 
            // lblByte
            // 
            this.lblByte.Name = "lblByte";
            this.lblByte.Size = new System.Drawing.Size(13, 17);
            this.lblByte.Text = "0";
            // 
            // ConstKeyByte
            // 
            this.ConstKeyByte.Name = "ConstKeyByte";
            this.ConstKeyByte.Size = new System.Drawing.Size(188, 17);
            this.ConstKeyByte.Text = "Размер блока байтов для ключа:";
            // 
            // lblKeyByteCount
            // 
            this.lblKeyByteCount.Name = "lblKeyByteCount";
            this.lblKeyByteCount.Size = new System.Drawing.Size(13, 17);
            this.lblKeyByteCount.Text = "0";
            // 
            // lblOpenkey
            // 
            this.lblOpenkey.AutoSize = true;
            this.lblOpenkey.Location = new System.Drawing.Point(244, 14);
            this.lblOpenkey.Name = "lblOpenkey";
            this.lblOpenkey.Size = new System.Drawing.Size(77, 13);
            this.lblOpenkey.TabIndex = 4;
            this.lblOpenkey.Text = "Открый ключ:";
            this.lblOpenkey.Click += new System.EventHandler(this.lblOpenkey_Click);
            // 
            // btnGoToMenu
            // 
            this.btnGoToMenu.Location = new System.Drawing.Point(12, 9);
            this.btnGoToMenu.Name = "btnGoToMenu";
            this.btnGoToMenu.Size = new System.Drawing.Size(87, 23);
            this.btnGoToMenu.TabIndex = 5;
            this.btnGoToMenu.Text = "В меню";
            this.btnGoToMenu.UseVisualStyleBackColor = true;
            this.btnGoToMenu.Click += new System.EventHandler(this.btnGoToMenu_Click);
            // 
            // btnLoadOpneKeyFromFile
            // 
            this.btnLoadOpneKeyFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadOpneKeyFromFile.Location = new System.Drawing.Point(756, 9);
            this.btnLoadOpneKeyFromFile.Name = "btnLoadOpneKeyFromFile";
            this.btnLoadOpneKeyFromFile.Size = new System.Drawing.Size(216, 23);
            this.btnLoadOpneKeyFromFile.TabIndex = 6;
            this.btnLoadOpneKeyFromFile.Text = "Загрузить открытый ключ из файла";
            this.btnLoadOpneKeyFromFile.UseVisualStyleBackColor = true;
            this.btnLoadOpneKeyFromFile.Click += new System.EventHandler(this.btnLoadOpneKeyFromFile_Click);
            // 
            // OpenKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnLoadOpneKeyFromFile);
            this.Controls.Add(this.btnGoToMenu);
            this.Controls.Add(this.lblOpenkey);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tbtContent);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.tbtOpenKey);
            this.MinimumSize = new System.Drawing.Size(660, 360);
            this.Name = "OpenKeyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Окно шифровки информации";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbtOpenKey;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.TextBox tbtContent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSymbolCountConst;
        private System.Windows.Forms.ToolStripStatusLabel lblSymbolCount;
        private System.Windows.Forms.ToolStripStatusLabel lblByteCountConst;
        private System.Windows.Forms.ToolStripStatusLabel lblByte;
        private System.Windows.Forms.Label lblOpenkey;
        private System.Windows.Forms.Button btnGoToMenu;
        private System.Windows.Forms.Button btnLoadOpneKeyFromFile;
        private System.Windows.Forms.ToolStripStatusLabel ConstKeyByte;
        private System.Windows.Forms.ToolStripStatusLabel lblKeyByteCount;
    }
}

