using System;
using System.Data; //подключаем дополнительную библиотеку
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

namespace Lab1WpfApp1_Labovkin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //перебираем все элементы,которые находятся внутри сетки MainGrid
            foreach (UIElement el in MainGrid.Children)
            {
                //проверяем является ли этот объект объектом класса Button
                if (el is Button)
                {
                    //преобразуем el к классу Button
                    ((Button)el).Click += Button_Click;
                }
            }
        }
        //метод, вызывающийся нажатием кнопки, с 2-мя параметрами
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //переменная, которая содержит текст, введенный с кнопки
            //объект преобразуем к классу Button и к строке 
            string str = (string)((Button)e.OriginalSource).Content;
            //если нажимается кнопка AС, тогда очищается текстовое поле 
            if (str == "AC")
                textlabel1.Text = "";

            else if (str == "=")
            {
                //метод Compute позволяет выполнить математическую операцию, в качестве параметра передается строка
                string value = new DataTable().Compute(textlabel1.Text, null).ToString();
                textlabel1.Text = value;
            }
            else
                textlabel1.Text += str;
        }
    }
}
