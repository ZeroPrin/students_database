namespace WindowsFormsApp1
{
    partial class Menu
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
            this.check_but = new System.Windows.Forms.Button();
            this.add_but = new System.Windows.Forms.Button();
            this.show_list_but = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // check_but
            // 
            this.check_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.check_but.Location = new System.Drawing.Point(118, 126);
            this.check_but.Name = "check_but";
            this.check_but.Size = new System.Drawing.Size(131, 52);
            this.check_but.TabIndex = 3;
            this.check_but.Text = "Проверка";
            this.check_but.UseVisualStyleBackColor = true;
            this.check_but.Click += new System.EventHandler(this.check_but_Click);
            // 
            // add_but
            // 
            this.add_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_but.Location = new System.Drawing.Point(118, 184);
            this.add_but.Name = "add_but";
            this.add_but.Size = new System.Drawing.Size(131, 52);
            this.add_but.TabIndex = 4;
            this.add_but.Text = "Добавление";
            this.add_but.UseVisualStyleBackColor = true;
            this.add_but.Click += new System.EventHandler(this.add_but_Click);
            // 
            // show_list_but
            // 
            this.show_list_but.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.show_list_but.Location = new System.Drawing.Point(118, 242);
            this.show_list_but.Name = "show_list_but";
            this.show_list_but.Size = new System.Drawing.Size(131, 52);
            this.show_list_but.TabIndex = 5;
            this.show_list_but.Text = "Таблица";
            this.show_list_but.UseVisualStyleBackColor = true;
            this.show_list_but.Click += new System.EventHandler(this.show_list_but_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(407, 426);
            this.Controls.Add(this.show_list_but);
            this.Controls.Add(this.add_but);
            this.Controls.Add(this.check_but);
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button check_but;
        private System.Windows.Forms.Button add_but;
        private System.Windows.Forms.Button show_list_but;
    }
}

