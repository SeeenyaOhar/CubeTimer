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
    public static class StringExtension
    {
        public static Scramble ToScramble(this String str)
        {
            var arg = Scramble.Empty;
            var split = str.Split(' ');
            Scramble finalobject = new Scramble();
            foreach (var v in split)
            {
                M1(v, ref arg);
            }
            Task.WaitAll();
            return arg;
        }
        static void M1(String str, ref Scramble scramble)
        {

            switch (str)
            {
                case "R":
                    scramble.AddElement(ScrambleElements.R);
                    break;
                case "L":
                    scramble.AddElement(ScrambleElements.L);
                    break;
                case "U":
                    scramble.AddElement(ScrambleElements.U);
                    break;
                case "D":
                    scramble.AddElement(ScrambleElements.D);
                    break;
                case "F":
                    scramble.AddElement(ScrambleElements.F);
                    break;
                case "B":
                    scramble.AddElement(ScrambleElements.B);
                    break;
                case "R'":
                    scramble.AddElement(ScrambleElements.R1);
                    break;
                case "L'":
                    scramble.AddElement(ScrambleElements.L1);
                    break;
                case "U'":
                    scramble.AddElement(ScrambleElements.U1);
                    break;
                case "D'":
                    scramble.AddElement(ScrambleElements.D1);
                    break;
                case "F'":
                    scramble.AddElement(ScrambleElements.F1);
                    break;
                case "B'":
                    scramble.AddElement(ScrambleElements.B1);
                    break;
                case "R2":
                    scramble.AddElement(ScrambleElements.R2);
                    break;
                case "L2":
                    scramble.AddElement(ScrambleElements.L2);
                    break;
                case "U2":
                    scramble.AddElement(ScrambleElements.U2);
                    break;
                case "D2":
                    scramble.AddElement(ScrambleElements.D2);
                    break;
                case "F2":
                    scramble.AddElement(ScrambleElements.F2);
                    break;
                case "B2":
                    scramble.AddElement(ScrambleElements.B2);
                    break;
            }


        }
    }
    /// <summary>
    /// Interaction logic for TimeInfoWindow.xaml
    /// </summary>
    public partial class TimeInfoWindow : Window
    {
        public TimeInfoWindow(Time tme)
        {
            InitializeComponent();
            title.Text = $"{this.Resources.MergedDictionaries[0]["info_text"]} - {tme.ToString()}";
            var scramble = tme.Scramble;
            ScrambleShow(scramble.ToScramble());
            scr_tb.Text = scramble;
            
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
                column = 6;
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
            column = 6;
            index = 0;
            for (int i = 0; i < 3; i++) // green color
            {
                column = 6;
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
            column = 2;
            index = 0;
            for (int i = 0; i < 3; i++) // orange color
            {
                column = 2;
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
            column = 10;
            index = 0;
            for (int i = 0; i < 3; i++) // Red color
            {
                column = 10;
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
            column = 14;
            index = 0;
            for (int i = 0; i < 3; i++) // blue color
            {
                column = 14;
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
            column = 6;
            index = 0;
            for (int i = 0; i < 3; i++) // green color
            {
                column = 6;
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
