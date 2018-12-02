namespace CodingTheory
{
    partial class SimpleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SubmitVectorButton = new System.Windows.Forms.Button();
            this.DecodedVectorValue = new System.Windows.Forms.TextBox();
            this.DecodedVectorLabel = new System.Windows.Forms.Label();
            this.SentVectorValue = new System.Windows.Forms.TextBox();
            this.SentVectorLabel = new System.Windows.Forms.Label();
            this.EncodedVectorValue = new System.Windows.Forms.TextBox();
            this.EncodedVectorLabel = new System.Windows.Forms.Label();
            this.VectorInputValue = new System.Windows.Forms.TextBox();
            this.VectorInputLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SubmitStringButton = new System.Windows.Forms.Button();
            this.DecodedStringLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EncodedStringLabel = new System.Windows.Forms.Label();
            this.DecodedStringValue = new System.Windows.Forms.TextBox();
            this.SentStringValue = new System.Windows.Forms.TextBox();
            this.EncodedStringValue = new System.Windows.Forms.TextBox();
            this.StringInputValue = new System.Windows.Forms.TextBox();
            this.StringInputLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.EncodedAndDecodedLabel = new System.Windows.Forms.Label();
            this.NotEncodedPictureLabel = new System.Windows.Forms.Label();
            this.OriginalPictureLabel = new System.Windows.Forms.Label();
            this.DecodedPicture = new System.Windows.Forms.PictureBox();
            this.OriginalPicture = new System.Windows.Forms.PictureBox();
            this.WithoutEncodingPicture = new System.Windows.Forms.PictureBox();
            this.ErrorChanceValue = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ResetEverythingButton = new System.Windows.Forms.Button();
            this.UploadImageButton = new System.Windows.Forms.Button();
            this.ErrorChanceLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecodedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WithoutEncodingPicture)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SubmitVectorButton);
            this.panel1.Controls.Add(this.DecodedVectorValue);
            this.panel1.Controls.Add(this.DecodedVectorLabel);
            this.panel1.Controls.Add(this.SentVectorValue);
            this.panel1.Controls.Add(this.SentVectorLabel);
            this.panel1.Controls.Add(this.EncodedVectorValue);
            this.panel1.Controls.Add(this.EncodedVectorLabel);
            this.panel1.Controls.Add(this.VectorInputValue);
            this.panel1.Controls.Add(this.VectorInputLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 568);
            this.panel1.TabIndex = 0;
            // 
            // SubmitVectorButton
            // 
            this.SubmitVectorButton.Location = new System.Drawing.Point(92, 507);
            this.SubmitVectorButton.Name = "SubmitVectorButton";
            this.SubmitVectorButton.Size = new System.Drawing.Size(159, 45);
            this.SubmitVectorButton.TabIndex = 7;
            this.SubmitVectorButton.Text = "Submit vector";
            this.SubmitVectorButton.UseVisualStyleBackColor = true;
            this.SubmitVectorButton.Click += new System.EventHandler(this.SubmitVectorButton_Click);
            // 
            // DecodedVectorValue
            // 
            this.DecodedVectorValue.Location = new System.Drawing.Point(13, 385);
            this.DecodedVectorValue.Multiline = true;
            this.DecodedVectorValue.Name = "DecodedVectorValue";
            this.DecodedVectorValue.Size = new System.Drawing.Size(360, 62);
            this.DecodedVectorValue.TabIndex = 12;
            // 
            // DecodedVectorLabel
            // 
            this.DecodedVectorLabel.AutoSize = true;
            this.DecodedVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecodedVectorLabel.Location = new System.Drawing.Point(126, 343);
            this.DecodedVectorLabel.Name = "DecodedVectorLabel";
            this.DecodedVectorLabel.Size = new System.Drawing.Size(125, 20);
            this.DecodedVectorLabel.TabIndex = 11;
            this.DecodedVectorLabel.Text = "DecodedVector";
            // 
            // SentVectorValue
            // 
            this.SentVectorValue.Location = new System.Drawing.Point(13, 260);
            this.SentVectorValue.Multiline = true;
            this.SentVectorValue.Name = "SentVectorValue";
            this.SentVectorValue.Size = new System.Drawing.Size(360, 62);
            this.SentVectorValue.TabIndex = 10;
            // 
            // SentVectorLabel
            // 
            this.SentVectorLabel.AutoSize = true;
            this.SentVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SentVectorLabel.Location = new System.Drawing.Point(51, 227);
            this.SentVectorLabel.Name = "SentVectorLabel";
            this.SentVectorLabel.Size = new System.Drawing.Size(286, 20);
            this.SentVectorLabel.TabIndex = 9;
            this.SentVectorLabel.Text = "Encoded vector sent through channel";
            // 
            // EncodedVectorValue
            // 
            this.EncodedVectorValue.Location = new System.Drawing.Point(13, 139);
            this.EncodedVectorValue.Multiline = true;
            this.EncodedVectorValue.Name = "EncodedVectorValue";
            this.EncodedVectorValue.Size = new System.Drawing.Size(360, 62);
            this.EncodedVectorValue.TabIndex = 8;
            // 
            // EncodedVectorLabel
            // 
            this.EncodedVectorLabel.AutoSize = true;
            this.EncodedVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedVectorLabel.Location = new System.Drawing.Point(126, 114);
            this.EncodedVectorLabel.Name = "EncodedVectorLabel";
            this.EncodedVectorLabel.Size = new System.Drawing.Size(125, 20);
            this.EncodedVectorLabel.TabIndex = 7;
            this.EncodedVectorLabel.Text = "Encoded vector";
            // 
            // VectorInputValue
            // 
            this.VectorInputValue.Location = new System.Drawing.Point(13, 38);
            this.VectorInputValue.Multiline = true;
            this.VectorInputValue.Name = "VectorInputValue";
            this.VectorInputValue.Size = new System.Drawing.Size(360, 62);
            this.VectorInputValue.TabIndex = 6;
            // 
            // VectorInputLabel
            // 
            this.VectorInputLabel.AutoSize = true;
            this.VectorInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VectorInputLabel.Location = new System.Drawing.Point(126, 15);
            this.VectorInputLabel.Name = "VectorInputLabel";
            this.VectorInputLabel.Size = new System.Drawing.Size(99, 20);
            this.VectorInputLabel.TabIndex = 5;
            this.VectorInputLabel.Text = "Vector input";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SubmitStringButton);
            this.panel2.Controls.Add(this.DecodedStringLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.EncodedStringLabel);
            this.panel2.Controls.Add(this.DecodedStringValue);
            this.panel2.Controls.Add(this.SentStringValue);
            this.panel2.Controls.Add(this.EncodedStringValue);
            this.panel2.Controls.Add(this.StringInputValue);
            this.panel2.Controls.Add(this.StringInputLabel);
            this.panel2.Location = new System.Drawing.Point(403, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 568);
            this.panel2.TabIndex = 1;
            // 
            // SubmitStringButton
            // 
            this.SubmitStringButton.Location = new System.Drawing.Point(115, 507);
            this.SubmitStringButton.Name = "SubmitStringButton";
            this.SubmitStringButton.Size = new System.Drawing.Size(159, 45);
            this.SubmitStringButton.TabIndex = 13;
            this.SubmitStringButton.Text = "Submit string";
            this.SubmitStringButton.UseVisualStyleBackColor = true;
            this.SubmitStringButton.Click += new System.EventHandler(this.SubmitStringButton_Click);
            // 
            // DecodedStringLabel
            // 
            this.DecodedStringLabel.AutoSize = true;
            this.DecodedStringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecodedStringLabel.Location = new System.Drawing.Point(131, 343);
            this.DecodedStringLabel.Name = "DecodedStringLabel";
            this.DecodedStringLabel.Size = new System.Drawing.Size(123, 20);
            this.DecodedStringLabel.TabIndex = 13;
            this.DecodedStringLabel.Text = "Decoded string";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Encoded string sent through channel";
            // 
            // EncodedStringLabel
            // 
            this.EncodedStringLabel.AutoSize = true;
            this.EncodedStringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedStringLabel.Location = new System.Drawing.Point(131, 114);
            this.EncodedStringLabel.Name = "EncodedStringLabel";
            this.EncodedStringLabel.Size = new System.Drawing.Size(121, 20);
            this.EncodedStringLabel.TabIndex = 11;
            this.EncodedStringLabel.Text = "Encoded string";
            // 
            // DecodedStringValue
            // 
            this.DecodedStringValue.Location = new System.Drawing.Point(12, 385);
            this.DecodedStringValue.Multiline = true;
            this.DecodedStringValue.Name = "DecodedStringValue";
            this.DecodedStringValue.Size = new System.Drawing.Size(360, 62);
            this.DecodedStringValue.TabIndex = 10;
            // 
            // SentStringValue
            // 
            this.SentStringValue.Location = new System.Drawing.Point(12, 260);
            this.SentStringValue.Multiline = true;
            this.SentStringValue.Name = "SentStringValue";
            this.SentStringValue.Size = new System.Drawing.Size(360, 62);
            this.SentStringValue.TabIndex = 9;
            // 
            // EncodedStringValue
            // 
            this.EncodedStringValue.Location = new System.Drawing.Point(12, 139);
            this.EncodedStringValue.Multiline = true;
            this.EncodedStringValue.Name = "EncodedStringValue";
            this.EncodedStringValue.Size = new System.Drawing.Size(360, 62);
            this.EncodedStringValue.TabIndex = 8;
            // 
            // StringInputValue
            // 
            this.StringInputValue.Location = new System.Drawing.Point(12, 38);
            this.StringInputValue.Multiline = true;
            this.StringInputValue.Name = "StringInputValue";
            this.StringInputValue.Size = new System.Drawing.Size(360, 62);
            this.StringInputValue.TabIndex = 7;
            // 
            // StringInputLabel
            // 
            this.StringInputLabel.AutoSize = true;
            this.StringInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StringInputLabel.Location = new System.Drawing.Point(143, 15);
            this.StringInputLabel.Name = "StringInputLabel";
            this.StringInputLabel.Size = new System.Drawing.Size(94, 20);
            this.StringInputLabel.TabIndex = 6;
            this.StringInputLabel.Text = "String input";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.EncodedAndDecodedLabel);
            this.panel3.Controls.Add(this.NotEncodedPictureLabel);
            this.panel3.Controls.Add(this.OriginalPictureLabel);
            this.panel3.Controls.Add(this.DecodedPicture);
            this.panel3.Controls.Add(this.OriginalPicture);
            this.panel3.Controls.Add(this.WithoutEncodingPicture);
            this.panel3.Location = new System.Drawing.Point(794, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1016, 665);
            this.panel3.TabIndex = 2;
            // 
            // EncodedAndDecodedLabel
            // 
            this.EncodedAndDecodedLabel.AutoSize = true;
            this.EncodedAndDecodedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodedAndDecodedLabel.Location = new System.Drawing.Point(129, 334);
            this.EncodedAndDecodedLabel.Name = "EncodedAndDecodedLabel";
            this.EncodedAndDecodedLabel.Size = new System.Drawing.Size(230, 20);
            this.EncodedAndDecodedLabel.TabIndex = 16;
            this.EncodedAndDecodedLabel.Text = "Encoded and decoded picture";
            // 
            // NotEncodedPictureLabel
            // 
            this.NotEncodedPictureLabel.AutoSize = true;
            this.NotEncodedPictureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotEncodedPictureLabel.Location = new System.Drawing.Point(130, 4);
            this.NotEncodedPictureLabel.Name = "NotEncodedPictureLabel";
            this.NotEncodedPictureLabel.Size = new System.Drawing.Size(229, 20);
            this.NotEncodedPictureLabel.TabIndex = 15;
            this.NotEncodedPictureLabel.Text = "Picture sent without encoding";
            // 
            // OriginalPictureLabel
            // 
            this.OriginalPictureLabel.AutoSize = true;
            this.OriginalPictureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalPictureLabel.Location = new System.Drawing.Point(676, 4);
            this.OriginalPictureLabel.Name = "OriginalPictureLabel";
            this.OriginalPictureLabel.Size = new System.Drawing.Size(123, 20);
            this.OriginalPictureLabel.TabIndex = 14;
            this.OriginalPictureLabel.Text = "Original picture";
            // 
            // DecodedPicture
            // 
            this.DecodedPicture.Location = new System.Drawing.Point(18, 358);
            this.DecodedPicture.Name = "DecodedPicture";
            this.DecodedPicture.Size = new System.Drawing.Size(473, 304);
            this.DecodedPicture.TabIndex = 10;
            this.DecodedPicture.TabStop = false;
            // 
            // OriginalPicture
            // 
            this.OriginalPicture.Location = new System.Drawing.Point(497, 27);
            this.OriginalPicture.Name = "OriginalPicture";
            this.OriginalPicture.Size = new System.Drawing.Size(473, 304);
            this.OriginalPicture.TabIndex = 9;
            this.OriginalPicture.TabStop = false;
            // 
            // WithoutEncodingPicture
            // 
            this.WithoutEncodingPicture.Location = new System.Drawing.Point(18, 27);
            this.WithoutEncodingPicture.Name = "WithoutEncodingPicture";
            this.WithoutEncodingPicture.Size = new System.Drawing.Size(473, 304);
            this.WithoutEncodingPicture.TabIndex = 8;
            this.WithoutEncodingPicture.TabStop = false;
            // 
            // ErrorChanceValue
            // 
            this.ErrorChanceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorChanceValue.Location = new System.Drawing.Point(300, 51);
            this.ErrorChanceValue.Multiline = true;
            this.ErrorChanceValue.Name = "ErrorChanceValue";
            this.ErrorChanceValue.Size = new System.Drawing.Size(167, 30);
            this.ErrorChanceValue.TabIndex = 3;
            this.ErrorChanceValue.Text = "0.1500";
            this.ErrorChanceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ResetEverythingButton);
            this.panel4.Controls.Add(this.UploadImageButton);
            this.panel4.Controls.Add(this.ErrorChanceLabel);
            this.panel4.Controls.Add(this.ErrorChanceValue);
            this.panel4.Location = new System.Drawing.Point(12, 586);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(776, 91);
            this.panel4.TabIndex = 3;
            // 
            // ResetEverythingButton
            // 
            this.ResetEverythingButton.Location = new System.Drawing.Point(38, 28);
            this.ResetEverythingButton.Name = "ResetEverythingButton";
            this.ResetEverythingButton.Size = new System.Drawing.Size(159, 45);
            this.ResetEverythingButton.TabIndex = 6;
            this.ResetEverythingButton.Text = "Reset everything";
            this.ResetEverythingButton.UseVisualStyleBackColor = true;
            this.ResetEverythingButton.Click += new System.EventHandler(this.ResetEverythingButton_Click);
            // 
            // UploadImageButton
            // 
            this.UploadImageButton.Location = new System.Drawing.Point(581, 28);
            this.UploadImageButton.Name = "UploadImageButton";
            this.UploadImageButton.Size = new System.Drawing.Size(159, 45);
            this.UploadImageButton.TabIndex = 5;
            this.UploadImageButton.Text = "Upload image";
            this.UploadImageButton.UseVisualStyleBackColor = true;
            this.UploadImageButton.Click += new System.EventHandler(this.UploadImageButton_Click);
            // 
            // ErrorChanceLabel
            // 
            this.ErrorChanceLabel.AutoSize = true;
            this.ErrorChanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorChanceLabel.Location = new System.Drawing.Point(329, 28);
            this.ErrorChanceLabel.Name = "ErrorChanceLabel";
            this.ErrorChanceLabel.Size = new System.Drawing.Size(109, 20);
            this.ErrorChanceLabel.TabIndex = 4;
            this.ErrorChanceLabel.Text = "Error Chance";
            // 
            // SimpleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1822, 679);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SimpleForm";
            this.Text = "SimpleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DecodedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WithoutEncodingPicture)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox ErrorChanceValue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label ErrorChanceLabel;
        private System.Windows.Forms.TextBox VectorInputValue;
        private System.Windows.Forms.Label VectorInputLabel;
        private System.Windows.Forms.Label StringInputLabel;
        private System.Windows.Forms.TextBox StringInputValue;
        private System.Windows.Forms.PictureBox DecodedPicture;
        private System.Windows.Forms.PictureBox OriginalPicture;
        private System.Windows.Forms.PictureBox WithoutEncodingPicture;
        private System.Windows.Forms.Button ResetEverythingButton;
        private System.Windows.Forms.Button UploadImageButton;
        private System.Windows.Forms.Label EncodedVectorLabel;
        private System.Windows.Forms.TextBox SentVectorValue;
        private System.Windows.Forms.Label SentVectorLabel;
        private System.Windows.Forms.TextBox EncodedVectorValue;
        private System.Windows.Forms.TextBox DecodedVectorValue;
        private System.Windows.Forms.Label DecodedVectorLabel;
        private System.Windows.Forms.Button SubmitVectorButton;
        private System.Windows.Forms.Label DecodedStringLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label EncodedStringLabel;
        private System.Windows.Forms.TextBox DecodedStringValue;
        private System.Windows.Forms.TextBox SentStringValue;
        private System.Windows.Forms.TextBox EncodedStringValue;
        private System.Windows.Forms.Label OriginalPictureLabel;
        private System.Windows.Forms.Label EncodedAndDecodedLabel;
        private System.Windows.Forms.Label NotEncodedPictureLabel;
        private System.Windows.Forms.Button SubmitStringButton;
    }
}