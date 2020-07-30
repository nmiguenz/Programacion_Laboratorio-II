namespace Formularios
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTimer1 = new System.Windows.Forms.Button();
            this.btnTimer2 = new System.Windows.Forms.Button();
            this.btnTimer3 = new System.Windows.Forms.Button();
            this.btnTimer4 = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTimer1
            // 
            this.btnTimer1.Location = new System.Drawing.Point(12, 105);
            this.btnTimer1.Name = "btnTimer1";
            this.btnTimer1.Size = new System.Drawing.Size(208, 70);
            this.btnTimer1.TabIndex = 0;
            this.btnTimer1.Text = "Timer 1";
            this.btnTimer1.UseVisualStyleBackColor = true;
            this.btnTimer1.Click += new System.EventHandler(this.btnTimer1_Click);
            // 
            // btnTimer2
            // 
            this.btnTimer2.Location = new System.Drawing.Point(226, 105);
            this.btnTimer2.Name = "btnTimer2";
            this.btnTimer2.Size = new System.Drawing.Size(208, 70);
            this.btnTimer2.TabIndex = 1;
            this.btnTimer2.Text = "Timer 2";
            this.btnTimer2.UseVisualStyleBackColor = true;
            this.btnTimer2.Click += new System.EventHandler(this.btnTimer2_Click);
            // 
            // btnTimer3
            // 
            this.btnTimer3.Location = new System.Drawing.Point(440, 105);
            this.btnTimer3.Name = "btnTimer3";
            this.btnTimer3.Size = new System.Drawing.Size(208, 70);
            this.btnTimer3.TabIndex = 2;
            this.btnTimer3.Text = "Timer 3";
            this.btnTimer3.UseVisualStyleBackColor = true;
            this.btnTimer3.Click += new System.EventHandler(this.btnTimer3_Click);
            // 
            // btnTimer4
            // 
            this.btnTimer4.Location = new System.Drawing.Point(654, 105);
            this.btnTimer4.Name = "btnTimer4";
            this.btnTimer4.Size = new System.Drawing.Size(208, 70);
            this.btnTimer4.TabIndex = 3;
            this.btnTimer4.Text = "Timer 4";
            this.btnTimer4.UseVisualStyleBackColor = true;
            this.btnTimer4.Click += new System.EventHandler(this.btnTimer4_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(81, 56);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(71, 20);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "00.00.00";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(294, 56);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(71, 20);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "00.00.00";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(504, 56);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(71, 20);
            this.lbl3.TabIndex = 6;
            this.lbl3.Text = "00.00.00";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(719, 56);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(71, 20);
            this.lbl4.TabIndex = 7;
            this.lbl4.Text = "00.00.00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 187);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnTimer4);
            this.Controls.Add(this.btnTimer3);
            this.Controls.Add(this.btnTimer2);
            this.Controls.Add(this.btnTimer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimer1;
        private System.Windows.Forms.Button btnTimer2;
        private System.Windows.Forms.Button btnTimer3;
        private System.Windows.Forms.Button btnTimer4;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
    }
}

