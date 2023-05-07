using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateList();
        }
        private void UpdateList()
        {
            List<string> elements = new List<string>();
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (var s in files)
            {
                if (s.Contains(".txt")) elements.Add(Path.GetFileName(s));
            }
            lsView.ItemsSource = elements;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cmb_box.SelectedValue != null)
            {
                if (cmb_box.SelectedValue.ToString().Contains("InkCanvas"))
                {
                    NoteWindow nw = new NoteWindow();
                    nw.Show();
                    this.Close();
                }
                else if (cmb_box.SelectedValue.ToString().Contains("Text"))
                {
                    NoteWindow nw = new NoteWindow();
                    nw.Show();
                    nw.txt.Visibility = Visibility.Visible;
                    nw.inkCanvas.Visibility = Visibility.Collapsed;
                    this.Close();
                }
            }
        }

        private void Select(object sender, SelectionChangedEventArgs e)
        {
            if (btn_delete.IsEnabled)
            {
                NoteWindow nw = new NoteWindow();
                nw.Show();
                FileStream fs = File.Open($"{lsView.SelectedItem.ToString()}", FileMode.Open);
                StrokeCollection myStrk = new StrokeCollection(fs);
                nw.inkCanvas.Strokes = myStrk;
                fs.Close();
                this.Close();
            }
            else
            {
                try {
                    File.Delete($"{lsView.SelectedItem.ToString()}");
                    
                } catch { }
                UpdateList();
                btn_delete.IsEnabled = true;
            } 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            btn_delete.IsEnabled = false;
        }

        private void cmb_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
