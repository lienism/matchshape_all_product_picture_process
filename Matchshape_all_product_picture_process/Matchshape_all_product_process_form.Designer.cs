namespace Matchshape_all_product_picture_process
{
    partial class Matchshape_all_product_process_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.file_path_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.X1_textbox = new System.Windows.Forms.TextBox();
            this.Y1_textbox = new System.Windows.Forms.TextBox();
            this.Y2_textbox = new System.Windows.Forms.TextBox();
            this.X2_textbox = new System.Windows.Forms.TextBox();
            this.X1_label = new System.Windows.Forms.Label();
            this.Y1_label = new System.Windows.Forms.Label();
            this.Y2_label = new System.Windows.Forms.Label();
            this.X2_label = new System.Windows.Forms.Label();
            this.Crop_checkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // file_path_button
            // 
            this.file_path_button.Location = new System.Drawing.Point(129, 55);
            this.file_path_button.Name = "file_path_button";
            this.file_path_button.Size = new System.Drawing.Size(75, 23);
            this.file_path_button.TabIndex = 0;
            this.file_path_button.Text = "file_path";
            this.file_path_button.UseVisualStyleBackColor = true;
            this.file_path_button.Click += new System.EventHandler(this.file_path_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // X1_textbox
            // 
            this.X1_textbox.Location = new System.Drawing.Point(63, 107);
            this.X1_textbox.Name = "X1_textbox";
            this.X1_textbox.Size = new System.Drawing.Size(100, 19);
            this.X1_textbox.TabIndex = 1;
            // 
            // Y1_textbox
            // 
            this.Y1_textbox.Location = new System.Drawing.Point(217, 107);
            this.Y1_textbox.Name = "Y1_textbox";
            this.Y1_textbox.Size = new System.Drawing.Size(100, 19);
            this.Y1_textbox.TabIndex = 2;
            // 
            // Y2_textbox
            // 
            this.Y2_textbox.Location = new System.Drawing.Point(217, 140);
            this.Y2_textbox.Name = "Y2_textbox";
            this.Y2_textbox.Size = new System.Drawing.Size(100, 19);
            this.Y2_textbox.TabIndex = 4;
            // 
            // X2_textbox
            // 
            this.X2_textbox.Location = new System.Drawing.Point(63, 140);
            this.X2_textbox.Name = "X2_textbox";
            this.X2_textbox.Size = new System.Drawing.Size(100, 19);
            this.X2_textbox.TabIndex = 3;
            // 
            // X1_label
            // 
            this.X1_label.AutoSize = true;
            this.X1_label.Location = new System.Drawing.Point(12, 107);
            this.X1_label.Name = "X1_label";
            this.X1_label.Size = new System.Drawing.Size(24, 12);
            this.X1_label.TabIndex = 5;
            this.X1_label.Text = "X1 :";
            // 
            // Y1_label
            // 
            this.Y1_label.AutoSize = true;
            this.Y1_label.Location = new System.Drawing.Point(176, 107);
            this.Y1_label.Name = "Y1_label";
            this.Y1_label.Size = new System.Drawing.Size(24, 12);
            this.Y1_label.TabIndex = 6;
            this.Y1_label.Text = "Y1 :";
            // 
            // Y2_label
            // 
            this.Y2_label.AutoSize = true;
            this.Y2_label.Location = new System.Drawing.Point(176, 147);
            this.Y2_label.Name = "Y2_label";
            this.Y2_label.Size = new System.Drawing.Size(24, 12);
            this.Y2_label.TabIndex = 8;
            this.Y2_label.Text = "Y2 :";
            // 
            // X2_label
            // 
            this.X2_label.AutoSize = true;
            this.X2_label.Location = new System.Drawing.Point(12, 147);
            this.X2_label.Name = "X2_label";
            this.X2_label.Size = new System.Drawing.Size(24, 12);
            this.X2_label.TabIndex = 7;
            this.X2_label.Text = "X2 :";
            // 
            // Crop_checkbox
            // 
            this.Crop_checkbox.AutoSize = true;
            this.Crop_checkbox.Location = new System.Drawing.Point(14, 59);
            this.Crop_checkbox.Name = "Crop_checkbox";
            this.Crop_checkbox.Size = new System.Drawing.Size(48, 16);
            this.Crop_checkbox.TabIndex = 9;
            this.Crop_checkbox.Text = "Crop";
            this.Crop_checkbox.UseVisualStyleBackColor = true;
            // 
            // Matchshape_all_product_process_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 182);
            this.Controls.Add(this.Crop_checkbox);
            this.Controls.Add(this.Y2_label);
            this.Controls.Add(this.X2_label);
            this.Controls.Add(this.Y1_label);
            this.Controls.Add(this.X1_label);
            this.Controls.Add(this.Y2_textbox);
            this.Controls.Add(this.X2_textbox);
            this.Controls.Add(this.Y1_textbox);
            this.Controls.Add(this.X1_textbox);
            this.Controls.Add(this.file_path_button);
            this.Name = "Matchshape_all_product_process_form";
            this.Text = "Matchshape_all_product_process_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button file_path_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox X1_textbox;
        private System.Windows.Forms.TextBox Y1_textbox;
        private System.Windows.Forms.TextBox Y2_textbox;
        private System.Windows.Forms.TextBox X2_textbox;
        private System.Windows.Forms.Label X1_label;
        private System.Windows.Forms.Label Y1_label;
        private System.Windows.Forms.Label Y2_label;
        private System.Windows.Forms.Label X2_label;
        private System.Windows.Forms.CheckBox Crop_checkbox;
    }
}

