using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TimerCode.Code;

namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for TimeInfoWindow.xaml
    /// </summary>
    public partial class TimeInfoWindow : Window
    {
        public TimeInfoWindow(Time tme)
        {
            InitializeComponent();
            title.Text = $"Info - {tme.ToString()}";
            // TODO: Continue developing
            
        }
        private void ScrambleShow(Scramble scramble) // show it in grid1
        {
            CubeState cs = CubeState.Scramble(scramble);
            cs.PrepareForUI();
            int row = 0 + 1;
            int column = 5;
            int index = 0;// of array of elements in Side.Elements property
            for (int i = 0; i < 3; i++) // white color
            {
                column = 5;
                for (int i2 = 0; i2 < 3; i2++)
                {

                    Canvas canvas = new Canvas();
                    canvas.Background = cs.S2.Elements[index].ConvertToBrush();
                    grid1.Children.Add(canvas);
                    Grid.SetRow(canvas, row);
                    Grid.SetColumn(canvas, column);
                    column++;
                    index++;
                }
                row++;
            }
            row = 4 + 1;
            column = 5;
            index = 0;
            for (int i = 0; i < 3; i++) // green color
            {
                column = 5;
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Canvas canvas = new Canvas();
                    canvas.Background = cs.S1.Elements[index].ConvertToBrush();
                    grid1.Children.Add(canvas);
                    Grid.SetRow(canvas, row);
                    Grid.SetColumn(canvas, column);
                    column++;
                    index++;
                }
                row++;
            }
            row = 4 + 1;
            column = 1;
            index = 0;
            for (int i = 0; i < 3; i++) // orange color
            {
                column = 1;
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Canvas canvas = new Canvas();
                    canvas.Background = cs.S6.Elements[index].ConvertToBrush();
                    grid1.Children.Add(canvas);
                    Grid.SetRow(canvas, row);
                    Grid.SetColumn(canvas, column);
                    column++;
                    index++;
                }
                row++;
            }
            row = 4 + 1;
            column = 9;
            index = 0;
            for (int i = 0; i < 3; i++) // Red color
            {
                column = 9;
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Canvas canvas = new Canvas();
                    canvas.Background = cs.S5.Elements[index].ConvertToBrush();
                    grid1.Children.Add(canvas);
                    Grid.SetRow(canvas, row);
                    Grid.SetColumn(canvas, column);
                    column++;
                    index++;
                }
                row++;
            }
            row = 4 + 1;
            column = 13;
            index = 0;
            for (int i = 0; i < 3; i++) // blue color
            {
                column = 13;
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Canvas canvas = new Canvas();
                    canvas.Background = cs.S3.Elements[index].ConvertToBrush();
                    grid1.Children.Add(canvas);
                    Grid.SetRow(canvas, row);
                    Grid.SetColumn(canvas, column);
                    column++;
                    index++;
                }
                row++;
            }
            row = 8 + 1;
            column = 5;
            index = 0;
            for (int i = 0; i < 3; i++) // green color
            {
                column = 5;
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Canvas canvas = new Canvas();
                    canvas.Background = cs.S4.Elements[index].ConvertToBrush();
                    grid1.Children.Add(canvas);
                    Grid.SetRow(canvas, row);
                    Grid.SetColumn(canvas, column);
                    column++;
                    index++;
                }
                row++;
            }
        }
    }
}
