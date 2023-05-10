using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Notes
{
    /// <summary>
    /// Логика взаимодействия для TextNoteWindow.xaml
    /// </summary>
    public partial class TextNoteWindow : Window
    {
        public TextNoteWindow()
        {
            InitializeComponent();
        }
        TxtCareTaker cr = new TxtCareTaker();
        int activeMemento = -1;

        private void Save(object sender, RoutedEventArgs e)
        {
            FileStream fs = File.Open($"{NameTxt.Text}.txt", FileMode.OpenOrCreate);
            TextRange tr = new TextRange(RichTxt.Document.ContentStart,RichTxt.Document.ContentEnd);
            tr.Save(fs, DataFormats.Text);
            fs.Close();
        }

        private void SaveCare(object sender, RoutedEventArgs e)
        {
           cr.Memento.Add(new MementoTxt(new TextRange(RichTxt.Document.ContentStart,RichTxt.Document.ContentEnd),RichTxt.FontStyle,RichTxt.FontSize));
           activeMemento = cr.Memento.Count() - 1;
        }

        private void LoadCare(object sender, RoutedEventArgs e)
        {
            if (cr.Memento.Count != 0)
            {
                TextRange doc = new TextRange(RichTxt.Document.ContentStart, RichTxt.Document.ContentEnd);
                doc = cr.Memento[activeMemento].tr;
            }
            else
            {
                MessageBox.Show("Снимков не существует!");
            }

        }
    }
    class MementoTxt
    {
        public TextRange tr { get; set; }
        public FontStyle fs { get; set; }
        public double fontSize { get; set; }
        public MementoTxt(TextRange r,FontStyle s, double size)
        {
            tr = r;
            fs = s;
            fontSize = size;
        }
    }
    class TxtCareTaker
    {
        public List<MementoTxt> Memento { get; set; }
        public TxtCareTaker()
        {
            Memento = new List<MementoTxt>();
        }
    }
}
