namespace StartMenu
{
    partial class MenuForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnGoToRabin = new System.Windows.Forms.Button();
            this.btnGenKeys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(27, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 302);
            this.button1.TabIndex = 0;
            this.button1.Text = "Проверить подпись";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGoToRabin
            // 
            this.btnGoToRabin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToRabin.Location = new System.Drawing.Point(632, 12);
            this.btnGoToRabin.Name = "btnGoToRabin";
            this.btnGoToRabin.Size = new System.Drawing.Size(340, 302);
            this.btnGoToRabin.TabIndex = 1;
            this.btnGoToRabin.Text = "Вычислить или проверить подпись";
            this.btnGoToRabin.UseVisualStyleBackColor = true;
            this.btnGoToRabin.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGenKeys
            // 
            this.btnGenKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenKeys.Location = new System.Drawing.Point(27, 344);
            this.btnGenKeys.Name = "btnGenKeys";
            this.btnGenKeys.Size = new System.Drawing.Size(945, 205);
            this.btnGenKeys.TabIndex = 2;
            this.btnGenKeys.Text = "Сгенерировать закрытый и открытый ключ";
            this.btnGenKeys.UseVisualStyleBackColor = true;
            this.btnGenKeys.Click += new System.EventHandler(this.btnGenKeys_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnGenKeys);
            this.Controls.Add(this.btnGoToRabin);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(660, 360);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGoToRabin;
        private System.Windows.Forms.Button btnGenKeys;
    }
}

