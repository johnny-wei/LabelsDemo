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
    /// updatedata.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateData : Window
    {
        public string ctlno { set; get; }
        public UpdateData()
        {
            InitializeComponent();
           
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            LabelPreview view = (LabelPreview)Owner;
            view.reloadImage("1117011207i");
            Close(); 
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LabelsInfo lsi = new MsgDeal().getLabelsInfo(ctlno);
            textBox.Text = lsi.cValue_ProduceDate;
        }
    }
}
