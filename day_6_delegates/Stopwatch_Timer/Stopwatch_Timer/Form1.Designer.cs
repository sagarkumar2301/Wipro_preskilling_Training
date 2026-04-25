namespace Stopwatch_Timer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.MenuHighlight;
            button1.Location = new Point(173, 219);
            button1.Name = "button1";
            button1.Size = new Size(139, 52);
            button1.TabIndex = 0;
            button1.Text = "start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.WindowFrame;
            button2.Location = new Point(298, 315);
            button2.Name = "button2";
            button2.Size = new Size(139, 52);
            button2.TabIndex = 0;
            button2.Text = "save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSave_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Red;
            button3.Location = new Point(435, 219);
            button3.Name = "button3";
            button3.Size = new Size(139, 52);
            button3.TabIndex = 0;
            button3.Text = "stop";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = SystemColors.MenuHighlight;
            richTextBox1.Location = new Point(321, 65);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(125, 120);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "Hours";
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox2.ForeColor = Color.Red;
            richTextBox2.Location = new Point(173, 65);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(125, 120);
            richTextBox2.TabIndex = 1;
            richTextBox2.Text = "Minutes";
            // 
            // richTextBox3
            // 
            richTextBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox3.ForeColor = SystemColors.HotTrack;
            richTextBox3.Location = new Point(469, 65);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(125, 120);
            richTextBox3.TabIndex = 1;
            richTextBox3.Text = "Second";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
    }
}
