using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge;
using AForge.Imaging;
using AForge.Video.FFMPEG;



namespace HandGesture
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection ListOfCams;
        private VideoCaptureDevice SelectedCam; //From where we will take image
        private VideoFileSource videoSource; 

        private HSLFiltering filter = new HSLFiltering();
        private Opening openingFilter = new Opening();
        private Threshold thresholdFilter = new Threshold(20);
        private Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
        private Erosion erosionFilter = new Erosion();

        BlobCounter bc = new BlobCounter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            
            ListOfCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            
            if (ListOfCams.Count == 0)
                return;

            comboBox1.Items.Clear();
            foreach (FilterInfo Cam in ListOfCams)
            {
                comboBox1.Items.Add(Cam.Name);
            }

            

        }

        private void StopCamera()
        {
            if (SelectedCam != null)
            {
                SelectedCam.SignalToStop();
                SelectedCam.Stop();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == string.Empty)
                return;
            
            
            SelectedCam = new VideoCaptureDevice(ListOfCams[comboBox1.SelectedIndex].MonikerString);

            SelectedCam.NewFrame += new NewFrameEventHandler(SelectedCam_NewFrame);
            histogram.Show();
            histogram1.Show();           
            SelectedCam.VideoResolution = SelectedCam.VideoCapabilities[0];
            SelectedCam.Start();
        }

        void SelectedCam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
           
            Bitmap bmp = new Bitmap(100,100);
            Graphics placeholder = Graphics.FromImage(bmp);
            placeholder.FillRectangle(Brushes.White,0,0,bmp.Width,bmp.Height);
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap originalImage = (Bitmap)eventArgs.Frame.Clone();
           
            
            // set color ranges to keep red-orange
            filter.Hue = new IntRange(0, 35);
            filter.Saturation = new Range(0.19f, 1);
            //filter.Luminance = new Range(0.31f, 255);
            // apply the filter
            filter.ApplyInPlace(image);           
            openingFilter.ApplyInPlace(image);
            Bitmap greyimage = grayscaleFilter.Apply(image);
            thresholdFilter.ApplyInPlace(greyimage);
            erosionFilter.Apply(greyimage);
            
            
            
            // process binary image
            bc.ProcessImage(image);
            bc.MinWidth = 50;
            bc.MinHeight = 50;
            bc.FilterBlobs = true;
            bc.ObjectsOrder = ObjectsOrder.Size;
            Rectangle[] rects = bc.GetObjectsRectangles();
            if (rects.Length > 0)
            {
                bmp = new Bitmap(rects[0].Width, rects[0].Height);

                
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(greyimage, 0, 0, rects[0], GraphicsUnit.Pixel);
                
                g.Dispose();




                // process blobs
                foreach (Rectangle rect in rects)
                {
                    Graphics g1 = Graphics.FromImage(originalImage);


                    using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5))
                    {
                        g1.DrawRectangle(pen, rect);
                    }

                    g1.Dispose();
                }
            }

            Crop cropFilter = new Crop(new Rectangle(0, (int)(0.15 * bmp.Height), bmp.Width, (int)(0.25 * bmp.Height)));
            
            
                Bitmap handImage = cropFilter.Apply(bmp);
                Bitmap overlay = new Bitmap(handImage.Width, handImage.Height);
                using (Graphics g = Graphics.FromImage(overlay))
                {
                    g.FillRectangle(Brushes.White, 0, 0, overlay.Width, overlay.Height);
                }
                Subtract subfilter = new Subtract(handImage);
                Bitmap resultImage = subfilter.Apply(overlay);
                HorizontalIntensityStatistics his = new HorizontalIntensityStatistics(handImage);
                

                double palmlimit = 0.4 * handImage.Height;
                int[] hisValues = (int[])his.Red.Values.Clone();
                for (int i = 0; i < handImage.Width; i++)
                {
                    hisValues[i] = ((double)hisValues[i] / 255 > palmlimit) ? 1 : 0;
                }


                histogram.Values = his.Red.Values;
                histogram1.Values = hisValues;
                //display number of fingers

                Graphics num = Graphics.FromImage(image);
                string text = "0";
                if (bmp.Height > 1.5*bmp.Width)                {
                    text = string.Format(countfingers(hisValues));
                }
                else { text = "0"; }
                Font drawFont = new Font("Courier", 18, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.White);

                num.DrawString(text, drawFont, drawBrush, new PointF(0, 5));

                drawFont.Dispose();
                drawBrush.Dispose();

                num.Dispose();
            
			// display in picture box
            pictureBox1.Image = originalImage;
            original.Image = image;
            crop.Image = handImage;
           
           
        }

        private void video_NewFrame( object sender, NewFrameEventArgs eventArgs )
{
    // get new frame
    Bitmap bmp = new Bitmap(100, 100);
    Graphics placeholder = Graphics.FromImage(bmp);
    placeholder.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
    Bitmap image = (Bitmap)eventArgs.Frame.Clone();

    // process the frame

    Bitmap originalImage = (Bitmap)eventArgs.Frame.Clone();


    // set color ranges to keep red-orange
    filter.Hue = new IntRange(0, 40);
    filter.Saturation = new Range(0.19f, 1);
    //filter.Luminance = new Range(0.31f, 255);
    // apply the filter
    filter.ApplyInPlace(image);
    openingFilter.ApplyInPlace(image);
    Bitmap greyimage = grayscaleFilter.Apply(image);
    thresholdFilter.ApplyInPlace(greyimage);
    erosionFilter.Apply(greyimage);



    // process binary image
    bc.ProcessImage(image);
    bc.MinWidth = 50;
    bc.MinHeight = 50;
    bc.FilterBlobs = true;
    bc.ObjectsOrder = ObjectsOrder.Size;
    Rectangle[] rects = bc.GetObjectsRectangles();
    if (rects.Length > 0)
    {
        bmp = new Bitmap(rects[0].Width, rects[0].Height);


        Graphics g = Graphics.FromImage(bmp);
        g.DrawImage(greyimage, 0, 0, rects[0], GraphicsUnit.Pixel);

        g.Dispose();




        // process blobs
        foreach (Rectangle rect in rects)
        {
            Graphics g1 = Graphics.FromImage(originalImage);


            using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5))
            {
                g1.DrawRectangle(pen, rect);
            }

            g1.Dispose();
        }
    }

    Crop cropFilter = new Crop(new Rectangle(0, (int)(0.15 * bmp.Height), bmp.Width, (int)(0.25 * bmp.Height)));


    Bitmap handImage = cropFilter.Apply(bmp);
    Bitmap overlay = new Bitmap(handImage.Width, handImage.Height);
    using (Graphics g = Graphics.FromImage(overlay))
    {
        g.FillRectangle(Brushes.White, 0, 0, overlay.Width, overlay.Height);
    }
    Subtract subfilter = new Subtract(handImage);
    Bitmap resultImage = subfilter.Apply(overlay);
    HorizontalIntensityStatistics his = new HorizontalIntensityStatistics(handImage);


    double palmlimit = 0.35 * handImage.Height;
    int[] hisValues = (int[])his.Red.Values.Clone();
    for (int i = 0; i < handImage.Width; i++)
    {
        hisValues[i] = ((double)hisValues[i] / 255 > palmlimit) ? 1 : 0;
    }


    histogram.Values = his.Red.Values;
    histogram1.Values = hisValues;
    //display number of fingers

    Graphics num = Graphics.FromImage(image);
    string text = "0";
    if (bmp.Height > 1.6 * bmp.Width)
    {
        text = string.Format(countfingers(hisValues));
    }
    else { text = "0"; }
    Font drawFont = new Font("Courier", 18, FontStyle.Bold);
    SolidBrush drawBrush = new SolidBrush(Color.White);

    num.DrawString(text, drawFont, drawBrush, new PointF(0, 5));

    drawFont.Dispose();
    drawBrush.Dispose();

    num.Dispose();

    // display in picture box
    pictureBox1.Image = originalImage;
    original.Image = image;
    crop.Image = handImage;
           
           
           
}

        private string countfingers(int[] his)
        {
            int num = 0;
            int stride = 0;
            int blank = 0;
            string position = "";
            for (int i = 0; i < his.Length-1; i++)
            {
                if (his[i] == 1 ) stride += 1;
                if (his[i] == 0) blank += 1;
                
                if (his[i] - his[i + 1] != 0)
                {
                     num += 1; ;
                     if (stride / his.Length > 0.25) position = "closed";
                     stride = 0;

                }
                
            }
            num = num / 2;
            return num.ToString() + position;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            StopCamera();
        }

               
        private void openvideo_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                videoSource = new VideoFileSource(Dialog.FileName);
                // set NewFrame event handler
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                // start the video source
                videoSource.Start();
                
            }
        }

        private void stopvideo_Click(object sender, EventArgs e)
        {
            if (videoSource != null) videoSource.Stop();
        }

        

    }
}
