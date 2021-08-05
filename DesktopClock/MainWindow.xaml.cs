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
using System.Windows.Threading;

namespace DesktopClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _Timer = new DispatcherTimer();
        string[] _ChineseHour = null;


        public MainWindow()
        {
            InitializeComponent();

            _ChineseHour = new string[]
            {
                "丑初", "丑正", "寅初", "寅正", "卯初", "卯正", "辰初", "辰正",
                "巳初", "巳正 大荒落", "午初 阳气炽盛", "午正 阴阳交相", "未初", "未正", "申初", "申正",
                "酉初", "酉正", "戌初", "戌正", "亥初", "亥正", "子初", "子正 阳气始萌",
            };
            _Timer.Interval = TimeSpan.FromSeconds(1);
            _Timer.Tick += new EventHandler(Update_Time);
            _Timer.Start();

        }

        private void Update_Time(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Label_ModernClock.Content = $"{DateTime.Now.Hour.ToString("00")} : {DateTime.Now.Minute.ToString("00")} : {DateTime.Now.Second.ToString("00")}";
            this.Chinese_Clock.Content = _ChineseHour[DateTime.Now.Hour == 24 ? 0 : DateTime.Now.Hour - 1];
            this.Label_Date.Content = $"{DateTime.Now.Month.ToString("00")}-{DateTime.Now.Day.ToString("00")}-{DateTime.Now.Year.ToString("00").Substring(2,2)}";   // Substring 从第二位开始取两位
        }

        private void AppExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin drag the window
            this.DragMove();
        }

    }
}
