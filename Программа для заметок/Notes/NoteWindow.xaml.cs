using Microsoft.Win32;
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
    /// Логика взаимодействия для NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow : Window
    {
        public NoteWindow()
        {
            InitializeComponent();
        }
        CareTaker cr = new CareTaker();
        int activeMemento = -1;

        private void Save(object sender, RoutedEventArgs e)
        {
            FileStream fs = File.Open($"{NameTxt.Text}.txt", FileMode.OpenOrCreate);
            inkCanvas.Strokes.Save(fs);
            fs.Close();
        }

        private void SaveCare(object sender, RoutedEventArgs e)
        {
            cr.Memento.Add(new Memento(inkCanvas.EditingMode, new StrokeCollection(inkCanvas.Strokes)));
            activeMemento = cr.Memento.Count()-1;
        }

        private void LoadCare(object sender, RoutedEventArgs e)
        {
            if (cr.Memento.Count != 0)
            {
                activeMemento--;
                inkCanvas.Strokes = cr.Memento[activeMemento].strokes;  
            }
            else
            {
                MessageBox.Show("Снимков не существует!");
            }
            
        }
    }
    class Memento
    {
        public InkCanvasEditingMode editMode { get; set; }
        public StrokeCollection strokes { get; set; }
        public Memento(InkCanvasEditingMode e, StrokeCollection s)
        {
            editMode = e;
            strokes = s;
        }
    }
    class CareTaker
    {
        public List<Memento> Memento { get; set; }
        public CareTaker()
        {
            Memento = new List<Memento>();
        }
    }

}
