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
using System.IO;

namespace haromszogekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Oldalak> listam = new List<Oldalak>();
        public MainWindow()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("haromszogek.csv", Encoding.UTF8);
            

            while(!sr.EndOfStream)
            {
                string sor =sr.ReadLine();
                string[] darabok = sor.Split(' ');
                Oldalak old = new Oldalak();
                old.a = Convert.ToInt32(darabok[0]);
                old.b = Convert.ToInt32(darabok[1]);
                old.c = Convert.ToInt32(darabok[2]);
                listam.Add(old);

            }
            sr.Close();

            datagrid.ItemsSource = listam;
           

            
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            int newa = Convert.ToInt32(tb1.Text);
            int newb = Convert.ToInt32(tb2.Text);
            int newc = Convert.ToInt32(tb3.Text);

            Oldalak old = new Oldalak();
            old.a = Convert.ToInt32(newa);
            old.b = Convert.ToInt32(newb);
            old.c = Convert.ToInt32(newc);


            if (newa<newb && newb<newc)
            {
                listam.Add(old);
                datagrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek!");
            }

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("haromszogek2.csv", false, Encoding.UTF8);
              
                foreach (var item in listam)
                {
                    sw.WriteLine(item.a + " " + item.b + " " + item.c);

                }
                
                MessageBox.Show("A mentés sikeresen megtörtént!");
                sw.Close();
            }
            catch (Exception ea)
            {
                MessageBox.Show(ea.Message);
               
            }


            
        }
    }
}
