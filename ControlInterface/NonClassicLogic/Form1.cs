using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NonClassicLogic
{
    public partial class Form1 : Form
    {
        //оступ от границы pictureBox'a при отрисовки
        const int INDENT = 40;
        //пусть 1 метр = 3 пикселям, тогда максимальная высота волны = 24 пикселя
        const int testWave = 24;


        //битмап вида сбоку
        static Bitmap sideView;
        //графика вида сбоку
        static Graphics sideViewGraphics;
        //битмап вида сверху
        static Bitmap topView;
        //графика вида сверху
        static Graphics topViewGraphics;
        private Thread graphicsThread = null;
        OuterWorld world = new OuterWorld();
        Expert expert = new Expert();

        public Form1()
        {
            InitializeComponent();

            topView = new Bitmap(topViewPicture.Size.Width, topViewPicture.Size.Height);
            topViewGraphics = Graphics.FromImage(topView);
            topViewPicture.Image = topView;

            //drawCraneTopView((int)expert.getCranePos(world.getWind(), 40), (int)(world.getWind()));
        }


        ////////////////////////////SIDEWAY////////////////////////////////

        //отрисовка всего вида сбоку по входным параметрам
        private void drawSideView(int waveHeight = 0, int cranePos = 0, int deltaWind = 0, int distance = 15)
        {
            drawWaveSideway(waveHeight);
            drawShipSideway(waveHeight);
            drawCraneWithCargoSideWay(cranePos, deltaWind, distance);
        }


        //отрисовка корабля в виде сбоку, высота волны входной параметр
        private void drawShipSideway(int waveHeight = 0)
        {
            // Create points that define polygon.
            Point point1 = new Point(0 + INDENT, sideView.Size.Height - 40 - waveHeight);
            Point point2 = new Point(0 + 40 + INDENT, sideView.Size.Height - waveHeight);
            Point point3 = new Point(sideView.Size.Width - 40 - INDENT, sideView.Size.Height - waveHeight);
            Point point4 = new Point(sideView.Size.Width - INDENT, sideView.Size.Height - 40 - waveHeight);
            Point point5 = new Point(sideView.Size.Width - 40 - INDENT, sideView.Size.Height - 40 - waveHeight);
            Point point6 = new Point(sideView.Size.Width - 40 - INDENT, sideView.Size.Height - 80 - waveHeight);
            Point point7 = new Point(sideView.Size.Width - 80 - INDENT, sideView.Size.Height - 80 - waveHeight);
            Point point8 = new Point(sideView.Size.Width - 80 - INDENT, sideView.Size.Height - 40 - waveHeight);
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
            sideViewGraphics.FillPolygon(new SolidBrush(Color.White), curvePoints);
            //отрисовать корабль
            sideViewGraphics.DrawPolygon(new Pen(Color.Black, 3), curvePoints);
        }

        //отрисовка волны
        private void drawWaveSideway(int waveHeight = 0)
        {
            Point[] curvePoints = new Point[10];
            int step = sideView.Size.Width / 4;
            int highPoints = 0;
            int lowPoints = 0;
            for (int i = 1; i < 10; i += 2)
            {
                curvePoints[i - 1] = new Point(lowPoints, sideView.Size.Height);
                curvePoints[i] = new Point(highPoints, sideView.Size.Height - waveHeight);
                highPoints += step;
                lowPoints += step;
            }
            sideViewGraphics.DrawCurve(new Pen(Color.Blue, 3), curvePoints);
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
            sideViewGraphics.FillPolygon(new SolidBrush(Color.White), curvePoints);
            sideViewGraphics.DrawPolygon(new Pen(Color.Black, 3), curvePoints);
            Invalidate();

            //отрисовка груза (длина = 36, высота = 9, точка соединения = 18)
            Point p1 = new Point(cranePos + deltaWind + 40 - 18, 40 + distance);
            Point p2 = new Point(cranePos + deltaWind + 40 - 18, 40 + 9 + distance);
            Point p3 = new Point(cranePos + deltaWind + 40 + 18, 40 + 9 + distance);
            Point p4 = new Point(cranePos + deltaWind + 40 + 18, 40 + distance);
            Point[] cargoPoints = 
            {
                p1,
                p2,
                p3,
                p4
            };
            sideViewGraphics.FillPolygon(new SolidBrush(Color.White), cargoPoints);
            sideViewGraphics.DrawPolygon(new Pen(Color.Black, 3), cargoPoints);

            //отрисовка каната от люльки до груза
            sideViewGraphics.DrawLine(new Pen(Color.Black, 3), new Point(cranePos + 40, 40), new Point(cranePos + 40 + deltaWind, 40 + distance));
        }



        ////////////////////////////TopView////////////////////////////////

        //отрисовка корабля в виде сверху
        private void drawShipTopView()
        {
            //ширина корабля 16 контейнеров = 2*2*16 = 64 пикселей
            Point point1 = new Point(topView.Size.Width / 2, INDENT);
            Point point2 = new Point((topView.Size.Width / 2) - 32, 20 + INDENT);
            Point point3 = new Point((topView.Size.Width / 2) - 32, topView.Size.Height - INDENT - 20);
            Point point4 = new Point(topView.Size.Width / 2, topView.Size.Height - INDENT);
            Point point5 = new Point((topView.Size.Width / 2) + 32, topView.Size.Height - INDENT - 20);
            Point point6 = new Point((topView.Size.Width / 2) + 32, 20 + INDENT);
            Point[] curvePoints = 
            {
                point1,
                point2,
                point3,
                point4,
                point5,
                point6
            };
            topViewGraphics.FillPolygon(new SolidBrush(Color.White), curvePoints);
            topViewGraphics.DrawPolygon(new Pen(Color.Black, 3), curvePoints);
        }

        //отрисовка крана с люлькой для вида сверху(позиция люльки, смещение груза)
        private void drawCraneTopView(int cranePosHorizontal = 0, int deltaWind = 0)
        {
            int cranePosVertical = topView.Size.Height / 2 - 10;

            //линии на которых крепится люлька
            topViewGraphics.DrawLine(new Pen(Color.Black, 3), new Point(INDENT, cranePosVertical), new Point(topView.Size.Width - INDENT, cranePosVertical));
            topViewGraphics.DrawLine(new Pen(Color.Black, 3), new Point(INDENT, cranePosVertical + 20), new Point(topView.Size.Width - INDENT, cranePosVertical + 20));

            //отрисовка груза
            topViewGraphics.FillRectangle(new SolidBrush(Color.Coral), cranePosHorizontal / 3 + 15 + deltaWind, cranePosVertical - 6, 6, 36);
            topViewGraphics.DrawRectangle(new Pen(Color.Black, 1), cranePosHorizontal / 3 + 15 + deltaWind, cranePosVertical - 6, 6, 36);

            //отрисовка люльки крана
            topViewGraphics.FillRectangle(new SolidBrush(Color.Gray), cranePosHorizontal, cranePosVertical, 20, 20);
            topViewGraphics.DrawRectangle(new Pen(Color.Black, 3), cranePosHorizontal, cranePosVertical, 20, 20);
        }

        //функция старта, для потока, который вызывается по кнопке Start
        //и начинает рисовать в отдельном потоке
        private void startGraphics()
        {
            try
            {
                for (int i = 1; i < 200; ++i)
                {
                    world.setTick(i);
                    double distance = 40;
                    //заполнение TextBox'ов с параметрами
                    getParametersDelegate getParams = new getParametersDelegate(getParameters);
                    Invoke(getParams, i);

                    //вид сбоку, инициализация, отрисовка через делегат
                    sideView = new Bitmap(sidewayViewPicture.Size.Width, sidewayViewPicture.Size.Height);
                    sideViewGraphics = Graphics.FromImage(sideView);
                    sidewayViewPicture.Image = sideView;

                    drawSideWayDelegate drawSideway = new drawSideWayDelegate(drawSideWay);
                    //    !!!ACHTUNG!!!
                    Invoke(drawSideway, distance);

                    // ----

                    //инициализация вида сверху, отрисовка через делегат
                    topView = new Bitmap(topViewPicture.Size.Width, topViewPicture.Size.Height);
                    topViewGraphics = Graphics.FromImage(topView);
                    topViewPicture.Image = topView;

                    drawTopViewDelegate drawTopview = new drawTopViewDelegate(drawTopView);
                    //    !!!ACHTUNG!!!
                    Invoke(drawTopview, distance);

                    Thread.Sleep(100);
                }
            }
            catch (System.ObjectDisposedException e) { }
            catch (System.Threading.ThreadInterruptedException e) { }
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            if ((graphicsThread == null) || (graphicsThread.ThreadState == System.Threading.ThreadState.Stopped))
            {
                graphicsThread = new Thread(startGraphics);
                graphicsThread.IsBackground = true;
                graphicsThread.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if ((graphicsThread != null) || (graphicsThread.ThreadState != System.Threading.ThreadState.Stopped))
                graphicsThread.Interrupt();
        }
        ///////////////////////делагаты для отрисовки и изменения элементов из других потоков////////////////

        //обновляет значения высоты волны, скорости и тд в TextBox'ах
        private delegate void getParametersDelegate(int i);
        private void getParameters(int i)
        {
            cargoSpeed.Text = i.ToString();
            windSpeed.Text = world.getWind().ToString();
            waveHeight.Text = world.getWave().ToString();
            windSpeed.Refresh();
            waveHeight.Refresh();
            cargoSpeed.Refresh();
        }

        //отрисовка вида сбоку через делегат
        private delegate void drawSideWayDelegate(double distance);
        private void drawSideWay(double distance)
        {
            drawWaveSideway((int)(world.getWave()));
            //отрисовка корабля
            drawShipSideway((int)(world.getWave()));
            //отрисовка люльки крана и груза
            drawCraneWithCargoSideWay((int)expert.getCranePos(world.getWind(), distance), (int)(world.getWind()), (int)distance);
            //обновление изображения
            sidewayViewPicture.Refresh();
        }

        //отрисовка вида сверху через делегат
        private delegate void drawTopViewDelegate(double distance);
        private void drawTopView(double distance)
        {
            drawShipTopView();
            drawCraneTopView((int)expert.getCranePos(world.getWind(), distance), (int)(world.getWind()));
            topViewPicture.Refresh();
        }

    }
}
