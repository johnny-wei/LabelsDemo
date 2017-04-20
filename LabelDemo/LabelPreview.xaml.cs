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
using System.Windows.Shapes;

namespace LabelDemo
{
    /// <summary>
    /// labelpriview.xaml 的交互逻辑
    /// </summary>
    public partial class LabelPreview : Window
    {
        public string ctlno { set; get; }
        private
            BartenderHelp bh = null;
       
        public LabelPreview()
        {
      
            InitializeComponent();
      
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            UpdateData ud = new UpdateData();
            ud.Owner = this;
            ud.ctlno = ctlno;

            ud.Show();

            
        }

        public void button2_Click(object sender, RoutedEventArgs e)
        {
            bh.print();
        }

        public void reloadImage(string ctlno)
        {
            //根据分类获取对应模板，默认打印机，打印数量，超时，预览图片保存地址，生产批号
            bh = new BartenderHelp("D:\\TestLabels\\A.btw", "HP LaserJet Pro MFP M128fn", 1, 1000, "D:\\TestImg", ctlno);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(bh.getLabelImg());
            bi.EndInit();
            image.Source = bi;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            reloadImage(ctlno);
        }
      
    }
}
