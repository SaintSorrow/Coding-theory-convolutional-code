using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CodingTheory
{
    public partial class SimpleForm : Form
    {
        public SimpleForm()
        {
            InitializeComponent();
            Text = "Convolutional Code";
            Shrink();
            ShowLabels(false);
            ImageSizing();
        }

        private void ShowLabels(bool _enabled)
        {
            NotEncodedPictureLabel.Visible = _enabled;
            EncodedAndDecodedLabel.Visible = _enabled;
            OriginalPictureLabel.Visible = _enabled;
        }

        private void ImageSizing()
        {
            OriginalPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            WithoutEncodingPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            DecodedPicture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Shrink()
        {
            this.Size = new Size(630, this.Height);
        }

        private void Expand()
        {
            this.Size = new Size(1350, this.Height);
        }

        private void Reset()
        {
            Shrink();
            ShowLabels(false);
            OriginalPicture.Image = null;
            WithoutEncodingPicture.Image = null;
            DecodedPicture.Image = null;
            ErrorChanceValue.Text = "0.1500";

            VectorInputValue.Text = "";
            EncodedVectorValue.Text = "";
            SentVectorValue.Text = "";
            DecodedVectorValue.Text = "";

            StringInputValue.Text = "";
            EncodedStringValue.Text = "";
            SentStringValue.Text = "";
            DecodedVectorValue.Text = "";
        }

        private void UploadImageButton_Click(object sender, EventArgs e)
        {
            ProcessImage();
        }

        private void ProcessImage()
        {
            if (!ValidateErrorChance())
            {
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            Conversion conversion = new Conversion(double.Parse(ErrorChanceValue.Text));

            openFileDialog.Title = "Choose and image";
            openFileDialog.Filter = "Image Files| *.bmp;";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);

                OriginalPicture.Image = bitmap;
                conversion.RunImage(OriginalPicture.Image);

                WithoutEncodingPicture.Image = conversion.ImageWithErrors;
                DecodedPicture.Image = conversion.DecodedImage;
            }

            Expand();
            ShowLabels(true);
        }

        private void ProcessVector()
        {
            if (!ValidateErrorChance())
            {
                return;
            }

            if (!ValidateVector())
            {
                return;
            }

            string errorPositions = "Errors are in these positions:";
            Conversion conversion = new Conversion(double.Parse(ErrorChanceValue.Text));
            conversion.RunVector(VectorInputValue.Text);
            EncodedVectorValue.Text = conversion.EncodedVector;
            DecodedVectorValue.Text = conversion.DecodedVector;

            if (conversion.ErrorPositions.Length > 0)
            {
                foreach (int position in conversion.ErrorPositions)
                {
                    errorPositions += " " + position.ToString() + " ";
                }

                SentVectorValue.Text = conversion.EncodedAndSentVector + '\n' + errorPositions;
            }
        }

        private bool ValidateVector()
        {
            bool isValid = true;

            if (!Validator.IsBinary(VectorInputValue.Text))
            {
                MessageBox.Show("Vector should contain only 1 and 0 in itself",
                    "Vector", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                isValid = false;
            }

            return isValid;
        }

        private void ResetEverythingButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void SubmitVectorButton_Click(object sender, EventArgs e)
        {
            ProcessVector();
        }

        private bool ValidateErrorChance()
        {
            bool isValid = true;

            if (!Validator.IsNoiseValid(ErrorChanceValue.Text))
            {
                MessageBox.Show("Error chance does not match required format. Error chance should be 0.0001 - 1 ",
                    "Error chance", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                isValid = false;
            }

            return isValid;
        }

        private void SubmitStringButton_Click(object sender, EventArgs e)
        {
            ProcessString();
        }

        private bool ValidateString()
        {
            bool isValid = true;

            if (!Validator.IsAscii(StringInputValue.Text))
            {
                MessageBox.Show("There is inapropriate symbols in string. Text should only caontain ASCII symbols!",
                    "Wrong string input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                isValid = false;
            }

            return isValid;
        }

        private void ProcessString()
        {
            if (!ValidateErrorChance())
            {
                return;
            }

            if (!ValidateString())
            {
                return;
            }


        }
    }
}
