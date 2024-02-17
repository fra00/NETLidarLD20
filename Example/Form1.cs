using ClassLibrary1;
using LidarLD20Driver.Model;
using System.Diagnostics;

namespace TestLidar
{
    public partial class Form1 : Form
    {
        private LidarLD20 lidarDriver;
        public Form1()
        {
            InitializeComponent();
            lidarDriver = new LidarLD20();
        }

        private Point Move(Point p, double angleDegrees, double distance)
        {
            // Convert the angle to radians
            double angleRadians = angleDegrees * Math.PI / 180.0;

            // Calculate the new coordinates
            var newX = p.X + distance * Math.Cos(angleRadians);
            var newY = p.Y + distance * Math.Sin(angleRadians);

            // Update the point
            return new Point
            {
                X = Convert.ToInt32(newX),
                Y = Convert.ToInt32(newY)
            };
        }

        private void DrawPoint(LidarFrame frame)
        {
            var w = pictureBox1.Width;
            var h = pictureBox1.Height;

            Point center = new Point(w / 2, h / 2);

            // Crea un oggetto Graphics per il PictureBox
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                foreach (var p in frame.points)
                {
                    var nextP = Move(center, p.angle, p.distance / 10);
                    // Disegna un punto rosso nella posizione (10, 10)
                    g.DrawEllipse(Pens.Red, nextP.X, nextP.Y, 5, 5);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lidarDriver.callbackReadPackage = (LidarFrame frame) =>
            {
                //string pack = JsonConvert.SerializeObject(frame);
                //Debug.WriteLine(pack);
                DrawPoint(frame);
            };
            lidarDriver.Read();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
