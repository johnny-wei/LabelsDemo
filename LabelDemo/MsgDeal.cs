using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabelDemo.localhost;
using LabelDemo.Properties;
using System.Web.Script.Serialization;
namespace LabelDemo
{
    class MsgDeal
    {
        JavaScriptSerializer serializer = null;
        public MsgDeal() {
            serializer = new JavaScriptSerializer();    
        }
        public LabelsInfo getLabelsInfo(string ctlno)
        {
            LabelsInfoService lis = new LabelsInfoService();
            string lableinfo = lis.getLabelInfo(ctlno);
            if (lableinfo.Equals("未找到生产订单标签！"))
            {
                System.Windows.MessageBox.Show("未找到生产订单标签！");
            }
            LabelsInfo li = serializer.Deserialize<LabelsInfo>(lableinfo);
            return li;
        }
        public string CommitUpadte(LabelsInfo lsi) {
            string jsonstr=serializer.Serialize(lsi);
            LabelsInfoService lis = new LabelsInfoService();
            string result=lis.updateLabelInfo(jsonstr);
            return result;
        }
    }
}
