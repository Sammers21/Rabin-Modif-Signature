namespace GenerateKeyWindow
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTypeLegth = new System.Windows.Forms.Label();
            this.tbtKeyLength1 = new System.Windows.Forms.TextBox();
            this.lblType2 = new System.Windows.Forms.Label();
            this.tbtkeylength2 = new System.Windows.Forms.TextBox();
            this.btnGENERATEMK = new System.Windows.Forms.Button();
            this.btnGoToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTypeLegth
            // 
            this.lblTypeLegth.AutoSize = true;
            this.lblTypeLegth.Location = new System.Drawing.Point(28, 103);
            this.lblTypeLegth.Name = "lblTypeLegth";
            this.lblTypeLegth.Size = new System.Drawing.Size(99, 13);
            this.lblTypeLegth.TabIndex = 0;
            this.lblTypeLegth.Text = "Введите длинну  p";
            // 
            // tbtKeyLength1
            // 
            this.tbtKeyLength1.Location = new System.Drawing.Point(31, 151);
            this.tbtKeyLength1.Name = "tbtKeyLength1";
            this.tbtKeyLength1.Size = new System.Drawing.Size(61, 20);
            this.tbtKeyLength1.TabIndex = 1;
            this.tbtKeyLength1.Text = "10";
            this.tbtKeyLength1.TextChanged += new System.EventHandler(this.tbtKeyLength1_TextChanged);
            // 
            // lblType2
            // 
            this.lblType2.AutoSize = true;
            this.lblType2.Location = new System.Drawing.Point(218, 103);
            this.lblType2.Name = "lblType2";
            this.lblType2.Size = new System.Drawing.Size(96, 13);
            this.lblType2.TabIndex = 2;
            this.lblType2.Text = "Введите длинну q";
            // 
            // tbtkeylength2
            // 
            this.tbtkeylength2.Location = new System.Drawing.Point(253, 151);
            this.tbtkeylength2.Name = "tbtkeylength2";
            this.tbtkeylength2.Size = new System.Drawing.Size(61, 20);
            this.tbtkeylength2.TabIndex = 3;
            this.tbtkeylength2.Text = "10";
            this.tbtkeylength2.TextChanged += new System.EventHandler(this.tbtkeylength2_TextChanged);
            // 
            // btnGENERATEMK
            // 
            this.btnGENERATEMK.Location = new System.Drawing.Point(31, 193);
            this.btnGENERATEMK.Name = "btnGENERATEMK";
            this.btnGENERATEMK.Size = new System.Drawing.Size(283, 66);
            this.btnGENERATEMK.TabIndex = 4;
            this.btnGENERATEMK.Text = "Сгенерировать!";
            this.btnGENERATEMK.UseVisualStyleBackColor = true;
            this.btnGENERATEMK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGoToMenu
            // 
            this.btnGoToMenu.Location = new System.Drawing.Point(31, 25);
            this.btnGoToMenu.Name = "btnGoToMenu";
            this.btnGoToMenu.Size = new System.Drawing.Size(283, 63);
            this.btnGoToMenu.TabIndex = 5;
            this.btnGoToMenu.Text = "В меню";
            this.btnGoToMenu.UseVisualStyleBackColor = true;
            this.btnGoToMenu.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 291);
            this.Controls.Add(this.btnGoToMenu);
            this.Controls.Add(this.btnGENERATEMK);
            this.Controls.Add(this.tbtkeylength2);
            this.Controls.Add(this.lblType2);
            this.Controls.Add(this.tbtKeyLength1);
            this.Controls.Add(this.lblTypeLegth);
            this.MaximumSize = new System.Drawing.Size(350, 330);
            this.MinimumSize = new System.Drawing.Size(350, 330);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генерация ключа";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTypeLegth;
        private System.Windows.Forms.TextBox tbtKeyLength1;
        private System.Windows.Forms.Label lblType2;
        private System.Windows.Forms.TextBox tbtkeylength2;
        private System.Windows.Forms.Button btnGENERATEMK;
        private System.Windows.Forms.Button btnGoToMenu;
    }
}

