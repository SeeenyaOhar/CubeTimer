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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimerCode.Code;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Runtime.CompilerServices;
using SpeedCubeTimer.Model;

namespace SpeedCubeTimer
{
    /// <summary>
    /// Interaction logic for MainWindowsPage.xaml
    /// </summary>
    public partial class MainWindowsPage : Page
    {
        MainWindow mw;
        //User user = null;
        //SolvedSyncronizer ssync;
        public MainWindowsPage(MainWindow mw) //, User user = null
        {
            InitializeComponent();
            scramble.Text = scramble1.ToString();


            //if (user == null)
            //{
            //    this.user = App.CurrentUser;
            //}
            //else this.user = user;
            
            mw.Closing += MainWindow_Closing;
            this.mw = mw;
            LocUtil.SwitchLanguage(this, App.Language.ToString());
            LocUtil.LanguageChanged += LocUtil_LanguageChanged;
            
            mw.KeyDown += Window_KeyDown;
            mw.KeyUp += Window_KeyUp;
            ScrambleShow(scramble1);
            stoped = false;
            //ssync = new SolvedSyncronizer(0);
            var path = App.SolvedTimesTextDocPath;
            if (File.Exists(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileInfo fi = new FileInfo(path);
                if (fi.Length > 0)
                {
                    using (Stream str = new FileStream(path, FileMode.Open))
                    {
                        Time.History = (List<Time>)bf.Deserialize(str);
                        //ssync = new SolvedSyncronizer(Time.History.Count);
                    }
                    if (Time.History.Count > 0)
                    {
                        textblock1.Text = Time.History[Time.History.Count - 1].ToString(); sec2.IsEnabled = true; dnf.IsEnabled = true;
                        // TODO: ASIGN SDNF AND SSEC BY CONDITION CONSTRUCTION, CHECKING WHETHER Time.History[Time.History.Count - 1].SOT has DNF or SEC
                        sdnf = Time.History[Time.History.Count - 1].SOT == StateOfTime.DNF;
                        ssec2 = Time.History[Time.History.Count - 1].SOT == StateOfTime.SEC2;
                    };

                }

            }
           

            Thread thr = new Thread(threadmethod);
            thr.IsBackground = true;
            thr.Priority = ThreadPriority.AboveNormal;
            thr.Start();
        }

        private void LocUtil_LanguageChanged(object sender, LocUtil.LanguageChangedEventArgs e)
        {
            LocUtil.SwitchLanguage(this, e.infivechars);
        }

        CubingTimer Timer = null;
        Boolean sdnf = false;
        Boolean ssec2 = false;
        Boolean SDNF
        {
            get
            {
                return sdnf;
            }
            set
            {
                sdnf = value;
                if (value == true)
                {
                    
                    Time.History[Time.History.Count - 1].SOT = StateOfTime.DNF;
                    textblock1.Text = Time.History[Time.History.Count - 1].ToString();
                    GetEveryAverage();
                }
                else
                {
                    
                    Time.History[Time.History.Count - 1].SOT = StateOfTime.Default;
                    textblock1.Text = Time.History[Time.History.Count - 1].ToString();
                    GetEveryAverage();
                }
            }
        }
        Boolean SSEC2
        {
            get
            {
                return ssec2;
            }
            set
            {
                ssec2 = value;
                if (value == true)
                {
                    Time.History[Time.History.Count - 1].SOT = StateOfTime.SEC2;
                    textblock1.Text = Time.History[Time.History.Count - 1].ToString();
                    
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    GetEveryAverage();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    
                }
                else
                {
                    Time.History[Time.History.Count - 1].SOT = StateOfTime.Default;
                    textblock1.Text = Time.History[Time.History.Count - 1].ToString();
                    
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    GetEveryAverage();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                }
            }
        }
       
        Task task1 = null;// this task change color of textblock1
        Boolean CanTimerStart = true;
        Scramble scramble1 = new Scramble();
        Boolean stoped;



        public void threadmethod(object state)
        {
            try
            {
                RuntimeHelpers.PrepareConstrainedRegions();
                while (true)
                {

                    Thread.Sleep(10000);
                    SerializeHistory();
                    

                }
            }
            catch (ThreadAbortException)
            {
                
                
            }
            finally
            {
                SerializeHistory();
            }
    }
        private async void SerializeHistory()
        {
            BinaryFormatter bf = new BinaryFormatter();
            var path = App.SolvedTimesTextDocPath;
            using (Stream str = new FileStream(path, FileMode.Create))
            {
                bf.Serialize(str, Time.History);
            }
            //ssync.Serialize(); // sends to db all the solved times, which are not already sent
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
                   
                    Border border = new Border() { BorderThickness = new Thickness(3000), BorderBrush = Brushes.Black };
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, column);

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
                    Border border = new Border() { BorderThickness = new Thickness(3), BorderBrush = Brushes.Black };
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, column);

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
                    Border border = new Border() { BorderThickness = new Thickness(3), BorderBrush = Brushes.Black };
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, column);

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
                    Border border = new Border() { BorderThickness = new Thickness(3), BorderBrush = Brushes.Black };
                    Grid.SetRow(border, row);

                    Grid.SetColumn(border, column);
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
                    Border border = new Border() { BorderThickness = new Thickness(3), BorderBrush = Brushes.Black };
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, column);

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
                    Border border = new Border() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black };
                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, column);

                    grid1.Children.Add(canvas);
                    Grid.SetRow(canvas, row);
                    Grid.SetColumn(canvas, column);
                    
                    column++;
                    index++;
                }
                row++;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SerializeHistory();
        }

        private async void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Timer != null)
            {
                if (Timer.IsTimerWorking && CanTimerStart == false)
                {
                    Timer.Stop();
                    sec2.IsEnabled = true;
                    dnf.IsEnabled = true;
                    SDNF = false;
                    SSEC2 = false;
                    await GetEveryAverage();
                    stoped = true;
                    textblock1.Text = Timer.LastTimeSolved.ToString();
                    Focus();
                }
                else if (Timer.IsTimerWorking == false && task1 == null)
                {
                    CanTimerStart = false;
                    sec2.IsEnabled = false;
                    dnf.IsEnabled = false;
                    InitializeCubingTimer();
                    Timer.LoadScramble(scramble1);
                    RedGreen(e);
                    return;
                }
            }
            else
            {
                CanTimerStart = false;
                sec2.IsEnabled = false;
                dnf.IsEnabled = false;
                InitializeCubingTimer();
                Timer.LoadScramble(scramble1);
                RedGreen(e);
                return;


            }

        }
        void InitializeCubingTimer()
        {
            Timer = new CubingTimer(); // TODO: fix this
            Timer.Started += Timer_Started;
            Handlers.TimeChanged += CurrentTime_TimeChanged;
            

        }
        async Task GetEveryAverage()
        {
            textblock1.Text = Time.History[Time.History.Count - 1].ToString();
            Time avg3 = await GetAverageAsync(3);
            Time avg5 = await GetAverageAsync(5);
            Time avg12 = await GetAverageAsync(12);
            Time avg50 = await GetAverageAsync(50);
            Time avg100 = await GetAverageAsync(100);
            
            //grid.Children.Remove(sp);
            Int32 index = 0;
            List<Int32> ii = new List<Int32>();
            
                foreach (UIElement v in grid.Children)
                {
                    if (v.GetType() == typeof(StackPanel))
                    {
                        ii.Add(index);
                    }
                    index++;
                }
            
            foreach (int i in ii)
            {
                grid.Children.RemoveAt(i);
            }
            var stp = new StackPanel();
            grid.Children.Add(stp);
            Grid.SetRow(stp, 1);
            Grid.SetRowSpan(stp, 2);
            Grid.SetColumn(stp, 1);
            
            Style simpletextstyle= (Style)App.Current.FindResource("SimpleText") ;
            stp.Children.Add(new TextBlock());
            stp.Children.Add(new TextBlock() { Text = $"avg3 = {avg3}" ,Style = simpletextstyle,
                TextAlignment = TextAlignment.Center});
            stp.Children.Add(new TextBlock() { Text = $"avg5 = {avg5}" , Style = simpletextstyle,
            TextAlignment = TextAlignment.Center });
            stp.Children.Add(new TextBlock() { Text = $"avg12 = {avg12}", Style = simpletextstyle,
                TextAlignment = TextAlignment.Center });
            stp.Children.Add(new TextBlock() { Text = $"avg50 = {avg50}", Style = simpletextstyle,
                TextAlignment = TextAlignment.Center });
            stp.Children.Add(new TextBlock() { Text = $"avg100 = {avg100}", Style = simpletextstyle,
                TextAlignment = TextAlignment.Center });
        }
        async static Task<Time> GetAverageAsync(int count)
        {
            try
            {
                var t = Time.History;
                Time[] v = new Time[count];
                t.CopyTo(t.Count - count, v, 0, count);
                var list = new List<Time>(v);
                bool isdnf = list[list.Count - 1].SOT == StateOfTime.DNF;
                isdnf = isdnf | list[0].SOT == StateOfTime.DNF;
                list.RemoveAt(list.Count - 1);
                list.RemoveAt(0);

                var g = await Time.AverageAsync(list, count - 2);
                g.SOT = isdnf ? StateOfTime.DNF : StateOfTime.Default;
                return g;
            }
            catch (ArgumentException ae)
            {
                return new Time(new Scramble()); // , new User()

            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (Timer != null)
            {
                if (Timer.IsTimerWorking == false && CanTimerStart)
                {
                    Timer.Start();

                    CanTimerStart = false;
                    scramble1 = new Scramble();
                    scramble.Text = scramble1.ToString();
                    ScrambleShow(scramble1);
                    return;
                }
            }
            if (stoped == true)
            {
                textblock1.Text = Time.History[Time.History.Count - 1].ToString();
                textblock1.Visibility = Visibility.Visible;
            }
        }
        private void CurrentTime_TimeChanged(object sender, TimeChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                textblock1.Text = Timer.CurrentTime.ToString();
            });
        }
        private void Timer_Started(object sender, TimerStartedEventArgs e)
        {
            var v = App.Current.Resources.MergedDictionaries.Single((res) => {
                return res.Source.OriginalString.Contains("themes");
            });
            if (v.Source.OriginalString.Contains("White.xaml"))
                textblock1.Foreground = Brushes.Black;

            if (v.Source.OriginalString.Contains("Black.xaml"))
                textblock1.Foreground = Brushes.White;
            
            task1 = null;
        }
        private void RedGreen(KeyEventArgs e)
        {
            CancellationToken ct = new CancellationToken();
            CancellationTokenSource cts = new CancellationTokenSource();
            ct = cts.Token;

            task1 = Task.Run(() =>
            {
                try
                {
                    this.Dispatcher.Invoke(() => { textblock1.Foreground = Brushes.Red; });
                    ct.ThrowIfCancellationRequested();
                }
                catch (OperationCanceledException)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        var v = App.Current.Resources.MergedDictionaries.Single((res) => {
                            return res.Source.OriginalString.Contains("themes");
                        });
                        if (v.Source.OriginalString.Contains("White.xaml"))
                            textblock1.Foreground = Brushes.Black;

                        if (v.Source.OriginalString.Contains("Black.xaml"))
                            textblock1.Foreground = Brushes.White;

                    });
                }

            }, ct);
            Task.Run(() =>
            {
                try
                {
                    ct.ThrowIfCancellationRequested();
                    task1.Wait();
                    ct.ThrowIfCancellationRequested();
                    Thread.Sleep(200);
                    ct.ThrowIfCancellationRequested();
                    this.Dispatcher.Invoke(() => { textblock1.Foreground = Brushes.LightGreen;
                        CanTimerStart = true; });
                }
                catch (OperationCanceledException)
                {
                    task1 = null;
                    this.Dispatcher.Invoke(() =>
                    {
                              var v = App.Current.Resources.MergedDictionaries.Single((res) => {
                            return res.Source.OriginalString.Contains("themes"); });
                        if (v.Source.OriginalString.Contains("White.xaml"))
                            textblock1.Foreground = Brushes.Black;

                        if (v.Source.OriginalString.Contains("Black.xaml"))
                            textblock1.Foreground = Brushes.White;
                    });
                }
            }, ct);
            Task.Run(() => { while (e.IsDown) { } cts.Cancel(); });
        }

        private void settings_b_Click(object sender, RoutedEventArgs e)
        {
            mw.KeyDown -= Window_KeyDown;
            mw.KeyUp -= Window_KeyUp;
            mw.Content = new SettingsP(mw);
           
        }

        private void history_b_Click(object sender, RoutedEventArgs e)
        {
            mw.Content = new History(mw, this);
        }

        private void dnf_Click(object sender, RoutedEventArgs e)
        {
            if (Time.History.Count > 0)
            {
                SDNF = Swap(sdnf);
            }
        }

        private void sec2_Click(object sender, RoutedEventArgs e)
        {
            if (Time.History.Count > 0)
            {
                SSEC2 = Swap(ssec2);
            }
        }
        private Boolean Swap(Boolean bl)
        {
            if (bl == true)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

