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

namespace PZ6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            progress.Value = 0;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var task = Wow(300,progress); 
            await task;
        }

        public  async Task Wow(int a,ProgressBar p)
        {
            int b = 1;
            for (int  i = 0;  i <a;  i++)
            {
                b *= a; 
                p.Value += a/10; 
                await Task.Delay(TimeSpan.FromSeconds(1)); 
                
            }
        }

        private void progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        /*
         В синхроном режиме - прогресс бар заполняется моментально, рисовать во время расчетов не можем.
         В асинхронном режиме - прогресс бар заполняется постепенно, рисовать во время расчетов можно.
        */
    }
}
