using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace pz10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Saver> frames = new List<Saver>();
        private bool boold = false;
        int countFrame = 0;
        int countsFrames = 5;
        public MainWindow()
        {
            InitializeComponent();
            SaveF(); // вызов асинхронного метода для сохранения снимков каждые 5 секунд
        }

        private void bold_Click(object sender, RoutedEventArgs e)
        {
            if (!boold)
            {
                text_area.FontWeight = FontWeights.Bold;
                boold = true;
            }
            else
            {
                text_area.FontWeight = FontWeights.Normal;
                boold = false;
            }
        }

        private void cursiv_Click(object sender, RoutedEventArgs e)
        {

            if (!boold)
            {
                text_area.FontStyle = FontStyles.Italic;
                boold = true;
            }
            else
            {
                text_area.FontStyle = FontStyles.Normal;
                boold = false;
            }
        }

        private void podcherk_Click(object sender, RoutedEventArgs e)
        {
        }

        private void size_plus_Click(object sender, RoutedEventArgs e)
        {
            text_area.FontSize += 1;
        }

        private void size_minus_Click(object sender, RoutedEventArgs e)
        {
            text_area.FontSize -= 1;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            TextRange txt = new TextRange(text_area.Document.ContentStart, text_area.Document.ContentEnd);
            File.WriteAllText("text.txt", txt.Text);
        }
        

        async void  text_area_Initialized(object sender, EventArgs e)
        {
            
        }
        async Task SaveF() // Каждые 5 секунд сохраняется "снимок"
        {
            TextRange text = new TextRange(text_area.Document.ContentStart, text_area.Document.ContentEnd);
            Saver s = new Saver(text_area.FontSize, text_area.FontStyle, text_area.FontWeight, text.Text);
            if (countsFrames > 0) 
            {
                frames.Add(s);
                countsFrames--;
                MessageBox.Show($"Количество снимков{frames.Count}");
            }
            else
            {
                frames = new List<Saver>();
                countsFrames = 4;
                frames.Add(s);
                MessageBox.Show($"Количество снимков{frames.Count}");
            }
            await Task.Delay(TimeSpan.FromSeconds(5));
            await SaveF();
        }

        private void cancel_Click(object sender, RoutedEventArgs e) //восстановления состояния из снимка
        {
            Saver sv = new Saver();
            if(countFrame<frames.Count)sv = frames[frames.Count - countFrame - 1];
            text_area.FontSize = sv.fontSize;
            text_area.FontStyle = sv.fontStyle;
            text_area.FontWeight = sv.fontWeight;
            FlowDocument doc = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Run(sv.text));
            doc.Blocks.Add(p);
            text_area.Document = doc;
            countFrame++;
        }
    }

    public class Saver // класс для "снимков"
    {
        public double fontSize { get; set; }
        public FontStyle fontStyle { get; set; }
        public FontWeight fontWeight { get; set; }
        public string text { get; set; }
        public Saver(double f,FontStyle s, FontWeight w,string t)
        {
            fontSize = f;
            fontStyle = s;
            fontWeight = w;
            text = t;
        }
        public Saver()
        {
            fontSize = 12;
            fontStyle = FontStyles.Normal;
            fontWeight = FontWeights.Normal;
        }
    }
}
