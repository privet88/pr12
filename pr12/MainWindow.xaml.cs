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

namespace pr12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            task.Text = "Найти длины отрезков и их сумму";
            timer = new DispatcherTimer();
#pragma warning disable CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            timer.Tick += Timer_Tick;
#pragma warning restore CS8622 // Допустимость значений NULL для ссылочных типов в типе параметра не соответствует целевому объекту делегирования (возможно, из-за атрибутов допустимости значений NULL).
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm");
            date.Text = d.ToString("dd.MM.yyyy");
        }
        private void InputProtection(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int a) == false) e.Handled = true;
        }
        private void CompositionCounter(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(pointA.Text) > Convert.ToInt32(pointB.Text) || Convert.ToInt32(pointB.Text) > Convert.ToInt32(pointC.Text)) MessageBox.Show("Неверное расположение координат");
                else
                {
                    rez.Text = ((Convert.ToInt32(pointC.Text) - Convert.ToInt32(pointA.Text)) + (Convert.ToInt32(pointC.Text) - Convert.ToInt32(pointB.Text))).ToString();
                }
            }
            catch { MessageBox.Show("Неверные либо незаполненные данные."); }

            pointA.Focus();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Потапкин. Задание:Даны три точки A, B, C на числовой оси. Найти длины отрезков AC и BC и ихсумму. С начала суток прошло N секунд(N — целое).Найти количество полных минут,прошедших сначала последнего часа.");
        }

        private void Task2(object sender, RoutedEventArgs e)
        {
            int.TryParse(N.Text, out int sec);
            double hour = sec / 60;
            hour = hour % 60;
            minute.Text = ((Convert.ToString(hour)));

        }
    }
}
