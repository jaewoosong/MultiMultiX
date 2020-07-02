namespace MultiMultiX
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lbTitle1 = new System.Windows.Forms.Label();
            this.lbTitle2 = new System.Windows.Forms.Label();
            this.lbDirPath = new System.Windows.Forms.Label();
            this.lbNumFiles = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(12, 11);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(152, 23);
            this.btnSelectDir.TabIndex = 0;
            this.btnSelectDir.Text = "폴더 선택 (드래그 가능)";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.BtnSelectDir_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(233, 11);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(107, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "다중 노출 시작";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // lbTitle1
            // 
            this.lbTitle1.AutoSize = true;
            this.lbTitle1.Location = new System.Drawing.Point(12, 54);
            this.lbTitle1.Name = "lbTitle1";
            this.lbTitle1.Size = new System.Drawing.Size(61, 12);
            this.lbTitle1.TabIndex = 4;
            this.lbTitle1.Text = "폴더 경로:";
            // 
            // lbTitle2
            // 
            this.lbTitle2.AutoSize = true;
            this.lbTitle2.Location = new System.Drawing.Point(12, 72);
            this.lbTitle2.Name = "lbTitle2";
            this.lbTitle2.Size = new System.Drawing.Size(120, 12);
            this.lbTitle2.TabIndex = 5;
            this.lbTitle2.Text = "그림 파일 (jpg) 개수:";
            // 
            // lbDirPath
            // 
            this.lbDirPath.AutoSize = true;
            this.lbDirPath.Location = new System.Drawing.Point(79, 54);
            this.lbDirPath.Name = "lbDirPath";
            this.lbDirPath.Size = new System.Drawing.Size(121, 12);
            this.lbDirPath.TabIndex = 6;
            this.lbDirPath.Text = "폴더를 선택해주세요.";
            // 
            // lbNumFiles
            // 
            this.lbNumFiles.AutoSize = true;
            this.lbNumFiles.Location = new System.Drawing.Point(140, 72);
            this.lbNumFiles.Name = "lbNumFiles";
            this.lbNumFiles.Size = new System.Drawing.Size(11, 12);
            this.lbNumFiles.TabIndex = 7;
            this.lbNumFiles.Text = "0";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(353, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(125, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "밝기 정규화 (권장)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(353, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 16);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "밝기 누적";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 109);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(603, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "사용법: 같은 크기의 사진을 한 폴더에 모은 뒤 그 폴더를 선택해주세요.";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 147);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbNumFiles);
            this.Controls.Add(this.lbTitle2);
            this.Controls.Add(this.lbDirPath);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.lbTitle1);
            this.Controls.Add(this.btnSelectDir);
            this.Name = "Form1";
            this.Text = "다중 노출 제작 프로그램 v0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label lbTitle1;
        private System.Windows.Forms.Label lbDirPath;
        private System.Windows.Forms.Label lbTitle2;
        private System.Windows.Forms.Label lbNumFiles;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}

