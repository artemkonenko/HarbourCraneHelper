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

        private int tick = 0;

        //масштаб
        private double meters;

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
            sideView = new Bitmap(sidewayViewPicture.Size.Width, sidewayViewPicture.Size.Height);
            sideViewGraphics = Graphics.FromImage(sideView);
            sidewayViewPicture.Image = sideView;
            //инициализация масштаба
            meters = (sideView.Size.Height - 80) / 30;
        }


        ////////////////////////////SIDEWAY////////////////////////////////


        //отрисовка корабля в виде сбоку, высота волны входной параметр
        private void drawShipSideway(double waveHeight = 0)
        {
            // Create points that define polygon.
            Point point1 = new Point(0 + INDENT, sideView.Size.Height - 60 - (int)(waveHeight * meters));
            Point point2 = new Point(0 + 40 + INDENT, sideView.Size.Height - (int)(waveHeight * meters) - 35);
            Point point3 = new Point(sideView.Size.Width - 40 - INDENT, sideView.Size.Height - (int)(waveHeight * meters) - 35);
            Point point4 = new Point(sideView.Size.Width - INDENT, sideView.Size.Height - 60 - (int)(waveHeight * meters));
            Point point5 = new Point(sideView.Size.Width - 40 - INDENT, sideView.Size.Height - 60 - (int)(waveHeight * meters));
            Point point6 = new Point(sideView.Size.Width - 40 - INDENT, sideView.Size.Height - 100 - (int)(waveHeight * meters));
            Point point7 = new Point(sideView.Size.Width - 80 - INDENT, sideView.Size.Height - 100 - (int)(waveHeight * meters));
            Point point8 = new Point(sideView.Size.Width - 80 - INDENT, sideView.Size.Height - 60 - (int)(waveHeight * meters));
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
        private void drawWaveSideway(double waveHeight = 0)
        {
            Point[] curvePoints = new Point[10];
            int step = sideView.Size.Width / 4;
            int highPoints = 0;
            int lowPoints = 0;
            for (int i = 1; i < 10; i += 2)
            {
                curvePoints[i - 1] = new Point(lowPoints + (int)((waveHeight * meters)/2), sideView.Size.Height);
                curvePoints[i] = new Point(highPoints, sideView.Size.Height - (int)(waveHeight * meters) - 30 - 20);
                highPoints += step;
                lowPoints += step;
            }
            sideViewGraphics.DrawCurve(new Pen(Color.Blue, 3), curvePoints);
        }

        //отрисовка люльки крана и груза (позиция люльки крана, смещение груза из-за ветра, расстояние от люльки до груза, по умолчанию 5 метров)
        private void drawCraneWithCargoSideWay(double distance = 15)
        {
            int cranePos = sideView.Size.Width / 2 - 10;

            //отрисовка люльки
            Point point1 = new Point(cranePos, 0);
            Point point2 = new Point(cranePos + 20, 0);
            Point point3 = new Point(cranePos + 20, 20);
            Point point4 = new Point(cranePos, 20);
            Point[] curvePoints = 
            {
                point1,
                point2,
                point3,
                point4
            };
            sideViewGraphics.FillPolygon(new SolidBrush(Color.Gray), curvePoints);
            sideViewGraphics.DrawPolygon(new Pen(Color.Black, 3), curvePoints);

            //отрисовка груза (длина = 36, высота = 9, точка соединения = 18)
            Point p1 = new Point(cranePos + 10 - 18, 22 + (int)(distance * meters));
            Point p2 = new Point(cranePos + 10 - 18, 22 + 9 + (int) (distance * meters));
            Point p3 = new Point(cranePos + 10 + 18, 22 + 9 + (int) (distance * meters));
            Point p4 = new Point(cranePos + 10 + 18, 22 + (int)(distance * meters));
            Point[] cargoPoints = 
            {
                p1,
                p2,
                p3,
                p4
            };
            sideViewGraphics.FillPolygon(new SolidBrush(Color.Coral), cargoPoints);
            sideViewGraphics.DrawPolygon(new Pen(Color.Black, 1), cargoPoints);

            //отрисовка каната от люльки до груза
            sideViewGraphics.DrawLine(new Pen(Color.Black, 2), new Point(cranePos + 20, 20), new Point(cranePos + 10 + 18, 22 + (int)(distance * meters)));
            sideViewGraphics.DrawLine(new Pen(Color.Black, 2), new Point(cranePos, 20), new Point(cranePos - 8, 22 + (int) (distance * meters)));
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
        private void drawCraneTopView(int cranePosHorizontal = 0, int deltaCargo = 0)
        {
            int cranePosVertical = topView.Size.Height / 2 - 10;
            cranePosHorizontal += topView.Size.Width / 2;

            //отрисовка груза
            topViewGraphics.FillRectangle(new SolidBrush(Color.Coral), cranePosHorizontal - 3 + deltaCargo, cranePosVertical - 6, 6, 36);
            topViewGraphics.DrawRectangle(new Pen(Color.Black, 1), cranePosHorizontal - 3 + deltaCargo, cranePosVertical - 6, 6, 36);

            //отрисовка троссов от люльки до груза
            topViewGraphics.DrawLine(new Pen(Color.Black, 2), new Point(cranePosHorizontal - 10, cranePosVertical), new Point(cranePosHorizontal - 3 + deltaCargo, cranePosVertical - 6));
            topViewGraphics.DrawLine(new Pen(Color.Black, 2), new Point(cranePosHorizontal + 10, cranePosVertical), new Point(cranePosHorizontal + 3 + deltaCargo, cranePosVertical - 6));
            topViewGraphics.DrawLine(new Pen(Color.Black, 2), new Point(cranePosHorizontal + 10, cranePosVertical + 20), new Point(cranePosHorizontal + 3 + deltaCargo, cranePosVertical + 30));
            topViewGraphics.DrawLine(new Pen(Color.Black, 2), new Point(cranePosHorizontal - 10, cranePosVertical + 20), new Point(cranePosHorizontal - 3 + deltaCargo, cranePosVertical + 30));

            //линии на которых крепится люлька
            topViewGraphics.DrawLine(new Pen(Color.Black, 3), new Point(INDENT, cranePosVertical), new Point(topView.Size.Width - INDENT, cranePosVertical));
            topViewGraphics.DrawLine(new Pen(Color.Black, 3), new Point(INDENT, cranePosVertical + 20), new Point(topView.Size.Width - INDENT, cranePosVertical + 20));

            //отрисовка люльки крана
            topViewGraphics.FillRectangle(new SolidBrush(Color.Gray), cranePosHorizontal - 10, cranePosVertical, 20, 20);
            topViewGraphics.DrawRectangle(new Pen(Color.Black, 3), cranePosHorizontal - 10, cranePosVertical, 20, 20);
        }

        //функция старта, для потока, который вызывается по кнопке Start
        //и начинает рисовать в отдельном потоке
        private void startGraphics()
        {
            getParametersDelegate getParams = new getParametersDelegate(getParameters);
            drawSideWayDelegate drawSideway = new drawSideWayDelegate(drawSideWay);
            drawTopViewDelegate drawTopview = new drawTopViewDelegate(drawTopView);

            try
            {
                world.setTick(tick);
                while (true)
                {
                    if (world.getDistance() < 0.001 )
                    {
                        try
                        {
                            //заполнение TextBox'ов с параметрами
                            Invoke(getParams, tick);

                            //вид сбоку, инициализация, отрисовка через делегат
                            sideView = new Bitmap(sidewayViewPicture.Size.Width, sidewayViewPicture.Size.Height);
                            sideViewGraphics = Graphics.FromImage(sideView);
                            sidewayViewPicture.Image = sideView;
                            Invoke(drawSideway, world.getDistance());

                            // ----

                            //инициализация вида сверху, отрисовка через делегат
                            topView = new Bitmap(topViewPicture.Size.Width, topViewPicture.Size.Height);
                            topViewGraphics = Graphics.FromImage(topView);
                            topViewPicture.Image = topView;
                            Invoke(drawTopview, world.getDistance());
                            world.release();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Груз...", MessageBoxButtons.OK);
                        }
                        break;
                    }

                    world.setTick(tick);
                    //заполнение TextBox'ов с параметрами
                    Invoke(getParams, tick);

                    //вид сбоку, инициализация, отрисовка через делегат
                    sideView = new Bitmap(sidewayViewPicture.Size.Width, sidewayViewPicture.Size.Height);
                    sideViewGraphics = Graphics.FromImage(sideView);
                    sidewayViewPicture.Image = sideView;
                    Invoke(drawSideway, world.getDistance());

                    // ----

                    //инициализация вида сверху, отрисовка через делегат
                    topView = new Bitmap(topViewPicture.Size.Width, topViewPicture.Size.Height);
                    topViewGraphics = Graphics.FromImage(topView);
                    topViewPicture.Image = topView;
                    Invoke(drawTopview, world.getDistance());

                    world.moveRobe(expert.getMaxCargoSpeed(world.cargoHorizontalMove(), world.getDistance()));
                    world.moveCraneHorizontal(expert.getCraneDeviationCompensation(world.cargoHorizontalMove(), world.getDistance()));

                    tick++;
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
            tick = new Random().Next() % 30;
            world = new OuterWorld();
            if ((graphicsThread != null) || (graphicsThread.ThreadState != System.Threading.ThreadState.Stopped))
                graphicsThread.Interrupt();
        }
        ///////////////////////делагаты для отрисовки и изменения элементов из других потоков////////////////

        //обновляет значения высоты волны, скорости и тд в TextBox'ах
        private delegate void getParametersDelegate(int i);
        private void getParameters(int i)
        {
            iteration.Text = i.ToString();
            windSpeed.Text = world.getWind().ToString();
            waveHeight.Text = world.getWave().ToString();
            distanceText.Text = world.getDistance().ToString();
            deviation.Text = world.cargoHorizontalMove().ToString();

            windSpeed.Refresh();
            waveHeight.Refresh();
            iteration.Refresh();
            distanceText.Refresh();
            deviation.Refresh();
        }

        //отрисовка вида сбоку через делегат
        private delegate void drawSideWayDelegate(double distance);
        private void drawSideWay(double distance)
        {
            //отрисовка корабля
            drawShipSideway(world.getWave());
            //отрисовка волны
            drawWaveSideway(world.getWave());
            //отрисовка люльки крана и груза
            drawCraneWithCargoSideWay(world.getRobeLenght() - world.cargoVerticalMove());
            //обновление изображения
            sidewayViewPicture.Refresh();
        }

        //отрисовка вида сверху через делегат
        private delegate void drawTopViewDelegate(double distance);
        private void drawTopView(double distance)
        {
            //отрисовка корабля
            drawShipTopView();
            //отрисовка люльки крана и груза
            drawCraneTopView((int)world.getCraneHorizontalPos(), (int)(world.cargoHorizontalMove()));
            //обновление изображения
            topViewPicture.Refresh();
        }

    }
}
