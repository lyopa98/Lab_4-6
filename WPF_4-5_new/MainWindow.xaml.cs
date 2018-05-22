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
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace WPF_4_5_new
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> path = new List<string>();//все пути открытых ранее текствиков
        //int nullCounter = 0;
        static int CountWind = 1;
        public MainWindow()
        {

            InitializeComponent();
            sizeBut.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

        }



        private void NewButton(object sender, RoutedEventArgs e)//new
        {

            //MainWindow newWind = new MainWindow();
            
            //newWind.Title = "TextEditor" + Convert.ToString(CountWind);

            //path.Add(newWind.Title);

            //File.Items.Add(path[CountWind]);

            TabItem tabItem = new TabItem();
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "RichText";
            tabItem.Header = "TextEditor" + Convert.ToString(CountWind);
            tabItem.Content = richTextBox;
            Tab.Items.Add(tabItem);

            CountWind++;

            //if (path.Count>=10)
            //{
            //    path.RemoveAt(nullCounter);
            //    nullCounter++;
            //}


            //newWind.Show();


        }

        private void BottonClose(object sender, RoutedEventArgs e)//close
        {
            try
            {
                Tab.Items.RemoveAt(Tab.SelectedIndex);
            }
            catch
            {

                Close();
            }
        }



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)//size
        {

            if (sizeBut.SelectedItem != null)
                RichText.Selection.ApplyPropertyValue(Inline.FontSizeProperty, Convert.ToString(sizeBut.SelectedItem));


        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)//open
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (.txt)|*.txt";

            TabItem tabItem = new TabItem();
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Name = "RichText";
            
            tabItem.Content = richTextBox;
            Tab.Items.Add(tabItem);


            if (dlg.ShowDialog() == true)
            {
                using (FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open))
                {

                    TextRange range = new TextRange(RichText.Document.ContentStart, RichText.Document.ContentEnd);

                    tabItem.Header = dlg.FileName;
                    range.Load(fileStream, DataFormats.Text);
                }


            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)//save
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Files (.txt)|*.txt";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(RichText.Document.ContentStart, RichText.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)//FONT
        {

            string asd = Convert.ToString(FontSt.SelectedItem);


            if (FontSt.SelectedItem != null)
                RichText.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, FontSt.SelectedItem);

        }

        private void RichText_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string richText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
            string temp = new TextRange(RichText.Document.ContentStart, RichText.Document.ContentEnd).Text;
            CountLabel.Content = "Число символов:" + (temp.Count() - 2);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)//SCALE
        {
            //RichText.Height
            
            this.Tab.Width= SliderScale.Value;
            this.Tab.Height = 0.628571429 * SliderScale.Value;


            //RichText.Width = SliderScale.Value;
            //RichText.Height = 0.628571429 * SliderScale.Value;



        }


        private void LangButtonEng(object sender, RoutedEventArgs e)
        {



            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\WPF_4-5_new\\WPF_4-5_new\\Resourses\\langENG.xaml")

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }






        }

        private void LangButtonRus(object sender, RoutedEventArgs e)
        {

            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\WPF_4-5_new\\WPF_4-5_new\\Resourses\\langRU.xaml")

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }





        }

        private void GraySubj(object sender, RoutedEventArgs e)//GRAY
        {

            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\WPF_4-5_new\\WPF_4-5_new\\Resourses\\Gray.xaml")

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
        private void PinkSubj(object sender, RoutedEventArgs e)//Pink
        {

            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\WPF_4-5_new\\WPF_4-5_new\\Resourses\\Pink.xaml")

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void OptmismSubj(object sender, RoutedEventArgs e)//Optmism
        {

            try
            {
                this.Resources = new ResourceDictionary()
                {
                    Source = new Uri("E:\\Учёба\\C#\\II semestr\\WPF_4-5_new\\WPF_4-5_new\\Resourses\\Optimism.xaml")

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }







        private void txtTarget_Drop(object sender, DragEventArgs e)
        {


            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                string file = (string)e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.

                    RichText.AppendText(file);
                //((TextBlock)sender).Text = (string)e.Data.GetData(DataFormats.Text);
            }
        }




    }
}
