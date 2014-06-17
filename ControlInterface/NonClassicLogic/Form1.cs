using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonClassicLogic
{
    public partial class Form1 : Form
    {
        //оступ от границы pictureBox'a при отрисовки, по длине
        const int widthIndent = 40;
        //пусть 1 метр = 3 пикселям, тогда максимальная высота волны = 24 пикселя
        const int testWave = 24;


        //битмап вида сбоку
        static Bitmap sideway;
        //графика вида сбоку
        static Graphics sidewayGraphics;

        public Form1()
        {
            InitializeComponent();
            //инициализация вида сбоку
            sideway = new Bitmap(sidewayViewPicture.Size.Width, sidewayViewPicture.Size.Height);
            sidewayGraphics = Graphics.FromImage(sideway);
            sidewayViewPicture.Image = sideway;
            drawWaveSideway(testWave);
            //отрисовка корабля
            drawShipSideway(testWave);
            //отрисовка люльки крана и груза
            drawCraneWithCargoSideWay(sideway.Size.Width/2 - 40);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sidewayViewPicture_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        //отрисовка корабля в виде сбоку, высота волны входной параметр
        private void drawShipSideway(int waveHeight = 0)
        {
            // Create points that define polygon.
            Point point1 = new Point(0 + widthIndent, sideway.Size.Height - 40 - waveHeight);
            Point point2 = new Point(0 + 40 + widthIndent, sideway.Size.Height - waveHeight);
            Point point3 = new Point(sideway.Size.Width - 40 - widthIndent, sideway.Size.Height - waveHeight);
            Point point4 = new Point(sideway.Size.Width - widthIndent, sideway.Size.Height - 40 - waveHeight);
            Point point5 = new Point(sideway.Size.Width - 40 - widthIndent, sideway.Size.Height - 40 - waveHeight);
            Point point6 = new Point(sideway.Size.Width - 40 - widthIndent, sideway.Size.Height - 80 - waveHeight);
            Point point7 = new Point(sideway.Size.Width - 80 - widthIndent, sideway.Size.Height - 80 - waveHeight);
            Point point8 = new Point(sideway.Size.Width - 80 - widthIndent, sideway.Size.Height - 40 - waveHeight);
            Point[] curvePoints =
            {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7,
                 point8
            };
            //заполнить область корабля белым цветом
            sidewayGraphics.FillPolygon(new SolidBrush(Color.White), curvePoints);
            //отрисовать корабль
            sidewayGraphics.DrawPolygon(new Pen(Color.Black, 3), curvePoints);
            //обновить изображение
            Invalidate();
        }

        //отрисовка волны
        private void drawWaveSideway(int waveHeight = 0)
        {
            Point[] curvePoints = new Point[10];
            int step = sideway.Size.Width / 4;
            int highPoints = 0;
            int lowPoints = 0;
            for (int i = 1; i < 10; i += 2) 
            { 
                curvePoints[i - 1] = new Point(lowPoints, sideway.Size.Height);
                curvePoints[i] = new Point(highPoints, sideway.Size.Height - waveHeight);
                highPoints += step;
                lowPoints += step;
            }
            sidewayGraphics.DrawCurve(new Pen(Color.Blue, 3), curvePoints);
            Invalidate();
        }

        //отрисовка люльки крана и груза (позиция люльки крана, смещение груза из-за ветра, расстояние от люльки до груза, по умолчанию 5 метров)
        private void drawCraneWithCargoSideWay(int cranePos = 0, int deltaWind = 0, int distance = 15)
        {
            //отрисовка люльки
            Point point1 = new Point(cranePos, 0);
            Point point2 = new Point(cranePos + 80, 0);
            Point point3 = new Point(cranePos + 80, 40);
            Point point4 = new Point(cranePos, 40);
            Point[] curvePoints = 
            {
                point1,
                point2,
                point3,
                point4
            };
            sidewayGraphics.FillPolygon(new SolidBrush(Color.White), curvePoints);
            sidewayGraphics.DrawPolygon(new Pen(Color.Black, 3), curvePoints);
            Invalidate();

            //отрисовка груза (длина = 36, высота = 9, точка соединения = 18)
            Point p1 = new Point(cranePos + deltaWind + 40 - 18, 40 + distance);
            Point p2 = new Point(cranePos + deltaWind + 40 - 18, 40 + 9 + distance);
            Point p3 = new Point(cranePos + deltaWind  + 40 + 18, 40 + 9 + distance);
            Point p4 = new Point(cranePos + deltaWind  + 40 + 18, 40 + distance);
            Point[] cargoPoints = 
            {
                p1,
                p2,
                p3,
                p4
            };
            sidewayGraphics.FillPolygon(new SolidBrush(Color.White), cargoPoints);
            sidewayGraphics.DrawPolygon(new Pen(Color.Black, 3), cargoPoints);
            Invalidate();

            //отрисовка каната от люльки до груза
            sidewayGraphics.DrawLine(new Pen(Color.Black, 3), new Point(cranePos + 40, 40), new Point(cranePos + 40 + deltaWind, 40 + distance));
        }
    }
}
