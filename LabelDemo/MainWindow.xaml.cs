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
using LabelDemo.localhost;
using LabelDemo.Properties;
using System.Web.Script.Serialization;
using Seagull.BarTender.Print;
using Seagull.BarTender.PrintServer;
using Seagull.BarTender.SystemDatabase;

namespace LabelDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
     
    public partial class MainWindow : System.Windows.Window
    {
        public string ctlno { set; get; }
        public LabelPreview lp = null;
        public MainWindow()
        {
            InitializeComponent();
            lp = new LabelPreview();
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            ctlno=textBox.Text;
            if (ctlno.Trim().Equals(""))
            {
                MessageBox.Show("空的批号！");
            }
            else {
                lp.ctlno = ctlno;
                 lp.Show();
            }

        }

        public void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
