namespace PetSystem
{
    partial class ExpertSystem
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
            this.Question = new System.Windows.Forms.Label();
            this.FirstQuestion = new System.Windows.Forms.Button();
            this.NegativeAnswer = new System.Windows.Forms.Button();
            this.DopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Question
            // 
            this.Question.Location = new System.Drawing.Point(71, 122);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(356, 44);
            this.Question.TabIndex = 0;
            this.Question.Text = "Вопрос";
            this.Question.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstQuestion
            // 
            this.FirstQuestion.Location = new System.Drawing.Point(94, 212);
            this.FirstQuestion.Name = "FirstQuestion";
            this.FirstQuestion.Size = new System.Drawing.Size(310, 39);
            this.FirstQuestion.TabIndex = 1;
            this.FirstQuestion.Text = "Да";
            this.FirstQuestion.UseVisualStyleBackColor = true;
            this.FirstQuestion.Click += new System.EventHandler(this.FirstQuestion_Click);
            // 
            // NegativeAnswer
            // 
            this.NegativeAnswer.Location = new System.Drawing.Point(97, 263);
            this.NegativeAnswer.Name = "NegativeAnswer";
            this.NegativeAnswer.Size = new System.Drawing.Size(306, 43);
            this.NegativeAnswer.TabIndex = 2;
            this.NegativeAnswer.Text = "Нет";
            this.NegativeAnswer.UseVisualStyleBackColor = true;
            this.NegativeAnswer.Click += new System.EventHandler(this.NegativeAnswer_Click);
            // 
            // DopButton
            // 
            this.DopButton.Location = new System.Drawing.Point(99, 324);
            this.DopButton.Name = "DopButton";
            this.DopButton.Size = new System.Drawing.Size(304, 40);
            this.DopButton.TabIndex = 3;
            this.DopButton.Text = "DopButton";
            this.DopButton.UseVisualStyleBackColor = true;
            this.DopButton.Click += new System.EventHandler(this.DopButton_Click);
            // 
            // ExpertSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.DopButton);
            this.Controls.Add(this.NegativeAnswer);
            this.Controls.Add(this.FirstQuestion);
            this.Controls.Add(this.Question);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "ExpertSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExpertSystem";
            this.Load += new System.EventHandler(this.ExpertSystem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Question;
        private System.Windows.Forms.Button FirstQuestion;
        private System.Windows.Forms.Button NegativeAnswer;
        private System.Windows.Forms.Button DopButton;
    }
}