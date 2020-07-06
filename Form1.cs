using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace MultiMultiX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
            trackBar1.Value = mJpgQuality;
            lbQualityValue.Text = trackBar1.Value.ToString();
        }

        private string[] mJpgFiles;
        private int mJpgQuality = 95;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] InputPaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.GetAttributes(InputPaths[0]).HasFlag(FileAttributes.Directory))
            {
                lbDirPath.Text = InputPaths[0];
                mJpgFiles = Directory.GetFiles(InputPaths[0], "*.jpg");                
                lbNumFiles.Text = mJpgFiles.Length.ToString();
            }
        }

        private void BtnSelectDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            lbDirPath.Text = dialog.SelectedPath;

            try
            {
                mJpgFiles = Directory.GetFiles(dialog.SelectedPath, "*.jpg");
                lbNumFiles.Text = mJpgFiles.Length.ToString();
            } catch (Exception ex)
            {
                // TODO
            }
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (mJpgFiles is null)
            {
                return;
            } else if (mJpgFiles.Length == 0)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG image files (*.jpg)|*.jpg";
            dialog.DefaultExt = "jpg";
            dialog.AddExtension = true;
            
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync(dialog.FileName);
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            try
            {
                MultiExposure(worker, (string) e.Argument);
            } catch (Exception ex)
            {
                MessageBox.Show("같은 크기의 사진 파일만 모아서 사용해 주세요.");
            }
        }

        // This event handler updates the progress.
        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        // This event handler deals with the results of the background operation.
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("취소되었습니다.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("오류가 발생했습니다.");
            }
            else
            {
                MessageBox.Show("완료!");
            }
        }

        private void MultiExposure(BackgroundWorker worker, string FileName) {
            Bitmap oneImage = new Bitmap(mJpgFiles[0]);
            Bitmap resultBitmap = new Bitmap(oneImage.Width, oneImage.Height, oneImage.PixelFormat);
            Rectangle resultRect = new Rectangle(0, 0, oneImage.Width, oneImage.Height);
            BitmapData bmpData = oneImage.LockBits(resultRect, ImageLockMode.ReadWrite, oneImage.PixelFormat);
            int bytes = Math.Abs(bmpData.Stride) * oneImage.Height; // Declare an array to hold the bytes of the bitmap.
            byte[] resultRgbValues = new byte[bytes];
            oneImage.UnlockBits(bmpData);
            oneImage.Dispose();

            for (int counter = 0; counter < resultRgbValues.Length; ++counter)
            {
                resultRgbValues[counter] = (byte)0;
            }
            
            for (int i = 0; i < mJpgFiles.Length; ++i)
            {
                oneImage = new Bitmap(mJpgFiles[i]);
                bmpData = oneImage.LockBits(resultRect, ImageLockMode.ReadWrite, oneImage.PixelFormat);
                IntPtr ptr = bmpData.Scan0; // Get the address of the first line.

                //int bytes = Math.Abs(bmpData.Stride) * oneImage.Height; // Declare an array to hold the bytes of the bitmap.

                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes); // Copy the RGB values into the array.

                for (int counter = 0; counter < rgbValues.Length; ++counter)
                {
                    if (radioButton1.Checked)
                    {
                        resultRgbValues[counter] += (byte)(rgbValues[counter] / mJpgFiles.Length);
                    } else if (radioButton2.Checked)
                    {
                        if (((int)resultRgbValues[counter] + (int)rgbValues[counter]) > (int)Byte.MaxValue)
                        {
                            resultRgbValues[counter] = Byte.MaxValue;
                        } else
                        {
                            resultRgbValues[counter] += (byte)(rgbValues[counter]);
                        }
                                
                    }
                }

                // Unlock the bits.
                oneImage.UnlockBits(bmpData);
                oneImage.Dispose();
                
                worker.ReportProgress((i+1) * 100 / mJpgFiles.Length);
            }

            // Copy the RGB values back to the bitmap
            bmpData = resultBitmap.LockBits(resultRect, ImageLockMode.ReadWrite, resultBitmap.PixelFormat);
            IntPtr resultPtr = bmpData.Scan0; // Get the address of the first line.
            System.Runtime.InteropServices.Marshal.Copy(resultRgbValues, 0, resultPtr, bytes);
            resultBitmap.UnlockBits(bmpData);


            // JPEG quality setting (System default was 75)
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, mJpgQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;

            // Save
            resultBitmap.Save(FileName, jpgEncoder, myEncoderParameters);
            resultBitmap.Dispose();            
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lbQualityValue.Text = trackBar1.Value.ToString();
            mJpgQuality = trackBar1.Value;
        }
    }
}
