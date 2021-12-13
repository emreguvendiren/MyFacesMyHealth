
namespace MyFacesMyHealth
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetectFaces = new System.Windows.Forms.Button();
            this.btnAddHES = new System.Windows.Forms.Button();
            this.picDetected = new System.Windows.Forms.PictureBox();
            this.txtHES = new System.Windows.Forms.TextBox();
            this.txtNameSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(1, 2);
            this.picCapture.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(812, 481);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(828, 13);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(194, 39);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "1. Kamerayı Aç";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnDetectFaces
            // 
            this.btnDetectFaces.Location = new System.Drawing.Point(828, 65);
            this.btnDetectFaces.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnDetectFaces.Name = "btnDetectFaces";
            this.btnDetectFaces.Size = new System.Drawing.Size(194, 39);
            this.btnDetectFaces.TabIndex = 2;
            this.btnDetectFaces.Text = "2. Yüzleri Tanı";
            this.btnDetectFaces.UseVisualStyleBackColor = true;
            this.btnDetectFaces.Click += new System.EventHandler(this.btnDetectFaces_Click);
            // 
            // btnAddHES
            // 
            this.btnAddHES.Location = new System.Drawing.Point(828, 382);
            this.btnAddHES.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnAddHES.Name = "btnAddHES";
            this.btnAddHES.Size = new System.Drawing.Size(194, 39);
            this.btnAddHES.TabIndex = 3;
            this.btnAddHES.Text = "3. Kişiyi Kaydet";
            this.btnAddHES.UseVisualStyleBackColor = true;
            this.btnAddHES.Click += new System.EventHandler(this.btnAddHES_Click);
            // 
            // picDetected
            // 
            this.picDetected.Location = new System.Drawing.Point(828, 116);
            this.picDetected.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(194, 152);
            this.picDetected.TabIndex = 4;
            this.picDetected.TabStop = false;
            // 
            // txtHES
            // 
            this.txtHES.Location = new System.Drawing.Point(828, 299);
            this.txtHES.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtHES.Name = "txtHES";
            this.txtHES.Size = new System.Drawing.Size(196, 20);
            this.txtHES.TabIndex = 5;
            // 
            // txtNameSurname
            // 
            this.txtNameSurname.Location = new System.Drawing.Point(827, 352);
            this.txtNameSurname.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtNameSurname.Name = "txtNameSurname";
            this.txtNameSurname.Size = new System.Drawing.Size(196, 20);
            this.txtNameSurname.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(825, 277);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "HES Kodunu Giriniz (Gerekli)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(825, 327);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ad Soyad Giriniz (Giriniz)";
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(828, 443);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(194, 39);
            this.btnTrain.TabIndex = 9;
            this.btnTrain.Text = "4. Sorgula";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1044, 488);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameSurname);
            this.Controls.Add(this.txtHES);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.btnAddHES);
            this.Controls.Add(this.btnDetectFaces);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picCapture);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "My Face My Health";
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetectFaces;
        private System.Windows.Forms.Button btnAddHES;
        private System.Windows.Forms.PictureBox picDetected;
        private System.Windows.Forms.TextBox txtHES;
        private System.Windows.Forms.TextBox txtNameSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTrain;
    }
}

