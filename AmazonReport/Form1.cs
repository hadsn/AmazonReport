using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonReport
{
    public partial class Form1 : Form
    {
        public List<string> asinAnItemList = new List<string>();
        public List<string> asinItemsList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void makeButton_Click(object sender, EventArgs e)
        {
            //Listからstringに変換
            string asinAnItems = String.Join("\r\n", asinAnItemList);
            string asinItemses = String.Join("\r\n", asinItemsList);

            //ASINリストのフォームを表示・終了
            asinListForm f2 = new asinListForm();
            f2.asinAnItems = asinAnItems;
            f2.asinItemses = asinItemses;
            f2.ShowDialog();
            f2.Dispose();

            //リストをそれぞれクリア
            asinAnItemList.Clear();
            asinItemsList.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            asinAnItemList.Clear();
            asinItemsList.Clear();
        }

        //単品ボタンにD&Dなカーソルがきたときの処理
        private void anItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UniformResourceLocator") || e.Data.GetDataPresent("UniformResourceLocatorW"))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        //単品ボタンにD&Dされた時の処理
        private void anItem_DragDrop(object sender, DragEventArgs e)
        {
            //URLからASINを抜く
            try
            {
                asinAnItemList.Add(getAsinFromURL(e.Data.GetData(DataFormats.Text).ToString()));
            }
            catch (ArgumentException ae) { }

        }

        //複数個ボタンにD&Dなカーソルがきたときの処理
        private void items_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UniformResourceLocator") || e.Data.GetDataPresent("UniformResourceLocatorW"))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        //複数個ボタンにD&Dされた時の処理
        private void items_DragDrop(object sender, DragEventArgs e)
        {
            //URLからASINを抜く
            try
            {
                string asin = getAsinFromURL(e.Data.GetData(DataFormats.Text).ToString());
                asinAnItemList.Add(asin);
                asinItemsList.Add(asin);

            }
            catch(ArgumentException ae) { }
        }

        //URLからASINを抜くメソッド
        private string getAsinFromURL(string uri)
        {
            //char[] asin = new char[15];
            string asin = new string(uri.ToCharArray());
            if (!(asin.IndexOf("dp/") == -1 || asin.IndexOf("dp/") == 0))
            {
                asin = asin.Remove(asin.IndexOf("/", asin.IndexOf("dp/") + 3));
                asin = asin.Remove(0, asin.IndexOf("dp/") + 3);
                return (asin);
            }
            else
            {
                throw new System.ArgumentException("AmazonのURLじゃないっぽい", "uri");
            }
        }
    }
}
