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
using Microsoft.Win32;

namespace ImageSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClickShowButton(object sender, RoutedEventArgs args)
        {
            Console.WriteLine("show");
            var dialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == true)
            {
                this.image.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void OnClickClearButton(object sender, RoutedEventArgs args)
        {
            Console.WriteLine("clear");
            this.image.Source = null;
        }

        private void OnClickCloseButton(object sender, RoutedEventArgs args)
        {
            Console.WriteLine("close");
            this.Close();
        }

        private void StretchCheckboxChanged(bool isChecked, object sender, RoutedEventArgs args)
        {
            Console.WriteLine("stretch");
            Console.WriteLine(isChecked ? "check" : "uncheck");

            this.image.Stretch = isChecked ? Stretch.Fill : Stretch.Uniform;
        }

        private void StretchChecked(object sender, RoutedEventArgs args)
        {
            this.StretchCheckboxChanged(true, sender, args);
        }

        private void StretchUnchecked(object sender, RoutedEventArgs args)
        {
            this.StretchCheckboxChanged(false, sender, args);
        }
    }
}
