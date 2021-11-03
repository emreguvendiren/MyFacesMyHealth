using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace MyFacesMyHealth
{
    public partial class Form1 : Form
    {
        #region degiskenler
        Capture videoCapture;
        Mat Frame = new Mat();
        Image<Bgr, Byte> currentImage;
        bool YuzleriTani = false;
        CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_default.xml");
        bool saveUser = false;
        static string path = Directory.GetCurrentDirectory() + @"\Faces";
        static List<Image<Gray, Byte>> trainedFaces = new List<Image<Gray, byte>>();
        static List<string> personNameSurname = new List<string>();
        static List<string> HesCode = new List<string>();
        static List<int> personNumbers = new List<int>();
        static EigenFaceRecognizer recognizer;
        static bool isTrained = false;

        #endregion
        public Form1()
        {
            InitializeComponent();
            btnDetectFaces.Enabled = false;
            btnAddHES.Enabled = false;
            btnTrain.Enabled = false;
            btnRecognize.Enabled = false;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            btnDetectFaces.Enabled = true;
            videoCapture = new Capture();
            videoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;
            videoCapture.Start();
            

        }

        private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
        {
            videoCapture.Retrieve(Frame,0);
            currentImage = Frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);
            if (YuzleriTani)
            {
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentImage, grayImage, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(grayImage, grayImage);
                Rectangle[] faces = cascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                if (faces.Length>0)
                {
                    foreach (var face in faces)
                    {
                        CvInvoke.Rectangle(currentImage, face, new Bgr(Color.Red).MCvScalar, 2);
                        Image<Bgr, Byte> resultImage = currentImage.Convert<Bgr, Byte>();
                        resultImage.ROI = face;
                        picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                        picDetected.Image = resultImage.Bitmap;
                        if (saveUser)
                        {
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            Task.Factory.StartNew(() => {
                                for (int i = 0; i < 10; i++)
                                {
                                    resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtNameSurname.Text + "_" + txtHES.Text+"_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                    Thread.Sleep(1000);
                                }
                            });

                        }
                        saveUser = false;
                        if (btnAddHES.InvokeRequired)
                        {
                            btnAddHES.Invoke(new ThreadStart(delegate {
                                btnAddHES.Enabled = true;
                            }));
                        }
                        if (btnTrain.InvokeRequired)
                        {
                            btnTrain.Invoke(new ThreadStart(delegate {
                                btnTrain.Enabled = true;
                            }));
                        }
                        if (isTrained)
                        {
                            Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200,200,Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = recognizer.Predict(grayFaceResult);
                            if (result.Label != -1 && result.Distance<2000)
                            {
                                CvInvoke.PutText(currentImage,"Ismi : " +personNameSurname[result.Label]+" Hes Kodu : " + HesCode[result.Label], new Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 0.5, new Bgr(Color.Pink).MCvScalar);
                                CvInvoke.Rectangle(currentImage, face, new Bgr(Color.Green).MCvScalar, 2);

                            }
                            else
                            {
                                CvInvoke.PutText(currentImage, "Bilinmiyor", new Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 1.0, new Bgr(Color.Pink).MCvScalar);
                                CvInvoke.Rectangle(currentImage, face, new Bgr(Color.Red).MCvScalar,2);
                            }
                        }

                    }
                }
            }
            picCapture.Image = currentImage.Bitmap;
            /*if (currentImage != null) {
                currentImage.Dispose();
            }*/
        }

        private void btnDetectFaces_Click(object sender, EventArgs e)
        {
            YuzleriTani = true;
            btnAddHES.Enabled = true;
        }

        private void btnAddHES_Click(object sender, EventArgs e)
        {
            if (txtHES.Text != "" && txtNameSurname.Text != "")
            {
                saveUser = true;
                btnAddHES.Enabled = false;
            }
            else {
                MessageBox.Show("Lütfen Gerekli Alanları Boş Bırakmayınız.");
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            Sorgula();
        }
        private static bool Sorgula() {
            int imgNo = 0;
            double ThresHold = 2000;
            personNameSurname.Clear();
            personNumbers.Clear();
            trainedFaces.Clear();
            HesCode.Clear();
            try
            {
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Image<Gray, Byte> trainedImages = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImages, trainedImages);
                    trainedFaces.Add(trainedImages);
                    personNumbers.Add(imgNo);
                    string name = file.Split('\\').Last().Split('_')[0];
                    personNameSurname.Add(name);
                    string hesCode = file.Split('\\').Last().Split('_')[1];
                    HesCode.Add(hesCode);
                    //MessageBox.Show(imgNo + " Nolu, " + name + " isimli kişinin HES Kodu : " + hesCode);
                    imgNo++;
                    
                }
                if (trainedFaces.Count>0)
                {
                    recognizer = new EigenFaceRecognizer(imgNo, ThresHold);
                    recognizer.Train(trainedFaces.ToArray(), personNumbers.ToArray());
                    isTrained = true;
                    return true;

                }
                else
                {
                    isTrained = false;
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                isTrained = false;
                return false;
            }
            
            
        }
    }
}
