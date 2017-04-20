using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seagull.BarTender.Print;
using Seagull.BarTender.PrintServer;
using Seagull.BarTender.SystemDatabase;
using System.Drawing;
using LabelDemo.localhost;
using LabelDemo.Properties;
using System.Web.Script.Serialization;
namespace LabelDemo
{
    class BartenderHelp
    {
        public string printerName { set; get; }
        public int number { set; get; }
        public Dictionary<string, string> data { set; get; }
        public int waitout { set; get; }
        public string demopath { set; get; }
        public string imgpath { set; get; }
        public string ctlno { set; get; }
        public MsgDeal md { set; get; }

        public BartenderHelp(string demopath,string printerName, int number, int waitout,string imgpath,string ctlno)
        {
            this.printerName = printerName;//打印机名字
            this.number = number;//打印数量
            this.waitout = waitout;//超时
            this.imgpath = imgpath;//图片保存位置
            this.demopath = demopath;
            this.ctlno = ctlno;
            md = new MsgDeal();
        }
        public BartenderHelp(string demopath,string imgpath) {
            this.imgpath = imgpath;
            this.demopath = demopath;
            md = new MsgDeal();
        }
        public void initializationData(LabelFormatDocument btFormat,LabelsInfo lsi) {
            
           
            try
            {

             
                btFormat.SubStrings["生产许可证号值"].Value = lsi.cValue_ProductionLicense;
                btFormat.SubStrings["产品标准编号值"].Value = lsi.cValue_ProductStandardNo;
                btFormat.SubStrings["客户名称值"].Value = lsi.cValue_CustomerName;
                btFormat.SubStrings["客户生产许可证号值"].Value = lsi.cValue_CustomerProductionLicense;
                btFormat.SubStrings["客户地址值"].Value = lsi.cValue_CustomerAddress;
                btFormat.SubStrings["产品编号值"].Value = lsi.cValue_ProductNo;
                btFormat.SubStrings["生产批号值"].Value = lsi.cValue_ProductLotNo;
                btFormat.SubStrings["产品字母编号"].Value = lsi.cInvCode_Eng;
                btFormat.SubStrings["生产日期值"].Value = lsi.cValue_ProduceDate;
                btFormat.SubStrings["保质期值"].Value = lsi.cValue_Warranty;
                btFormat.SubStrings["净含量值"].Value = lsi.cValue_NetContent;
                btFormat.SubStrings["产品成分值"].Value = lsi.cValue_Components;
                btFormat.SubStrings["使用说明"].Value = lsi.cValue_Instructions;
                btFormat.SubStrings["作用与用途值"].Value = lsi.cValue_Functions;
                btFormat.SubStrings["注意事项值"].Value = lsi.cValue_Warming;
                btFormat.SubStrings["推荐用量值"].Value = lsi.cValue_Dosage;
                btFormat.SubStrings["贮存条件及方法值"].Value = lsi.cValue_Storage;
                btFormat.SubStrings["原料组成值"].Value = lsi.cValue_MaterialCom;


            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }


        }
       
        public string getLabelImg() {
            Engine btEngine = new Engine();
            btEngine.Start();
            Messages messages;
            LabelFormatDocument btFormat = btEngine.Documents.Open((demopath));
            initializationData(btFormat, md.getLabelsInfo(ctlno));
            Result result = btFormat.ExportPrintPreviewToFile(imgpath, ctlno + ".jpg", ImageType.JPEG, ColorDepth.ColorDepth24bit, new Resolution(96), System.Drawing.Color.Gray, OverwriteOptions.Overwrite, false, false, out messages);
            btEngine.Stop();
            return imgpath + "\\" + ctlno + "1.jpg";
        }
        public void print()
        {
            Engine btEngine = new Engine();
            bool isAlive = btEngine.IsAlive;
            btEngine.Start();
            LabelFormatDocument btFormat = btEngine.Documents.Open((demopath));//这里是Bartender软件生成的模板文件，你需要先把模板文件做好。
            btFormat.PrintSetup.PrinterName = printerName;
            btFormat.PrintSetup.IdenticalCopiesOfLabel = number; //打印份数                                                 // btFormat.PrintSetup.IdenticalCopiesOfLabel = 1;  //设置同序列打印的份数
            btFormat.PrintSetup.NumberOfSerializedLabels = 1;
            initializationData(btFormat, md.getLabelsInfo(ctlno));
            Messages messages;
            Result nResult1 = btFormat.Print("标签打印1", waitout, out messages);
            btFormat.PrintSetup.Cache.FlushInterval = CacheFlushInterval.PerSession;
            btFormat.Close(SaveOptions.DoNotSaveChanges);//不保存对打开模板的修改
            btEngine.Stop();

        }

    }
}
