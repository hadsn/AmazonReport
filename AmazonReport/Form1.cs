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
        List<string> asinAnItemList = new List<string>();
        List<string> asinItemsList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void makeButton_Click(object sender, EventArgs e)
        {
            string asinAnItems = String.Join("\n", asinAnItemList);
            string asinItemses = String.Join("\n", asinItemsList);
            MessageBox.Show(asinAnItems);

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            asinAnItemList.Clear();
            asinItemsList.Clear();
        }

        private void anItem_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UniformResourceLocator") || e.Data.GetDataPresent("UniformResourceLocatorW"))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void anItem_DragDrop(object sender, DragEventArgs e)
        {
            //URLからASINを抜く
            asinAnItemList.Add(getAsinFromURL(e.Data.GetData(DataFormats.Text).ToString()));
        }

        private void items_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("UniformResourceLocator") || e.Data.GetDataPresent("UniformResourceLocatorW"))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void items_DragDrop(object sender, DragEventArgs e)
        {
            //URLからASINを抜く
            asinAnItemList.Add(getAsinFromURL(e.Data.GetData(DataFormats.Text).ToString()));
            asinItemsList.Add(getAsinFromURL(e.Data.GetData(DataFormats.Text).ToString()));
        }

        //URLからASINを抜くメソッド
        private string getAsinFromURL(string uri)
        {
            //char[] asin = new char[15];
            string asin = new string(uri.ToCharArray());
            if (!(asin.IndexOf("dp/") == -1 || asin.IndexOf("dp/") == 0))
            {
                /*
                //書籍 (ISBN) 対応でとりあえず13桁で抜く
                uri.CopyTo(uri.IndexOf("dp/") + 3, asin, 0, 13);
                //10桁ASINの場合は10桁で撮り直す
                if (!(new string(asin).IndexOf("/") == -1 || new string(asin).IndexOf("/") == 0))
                {
                    
                    uri.CopyTo(uri.IndexOf("dp/") + 3, asin, 0, 10);
                    asin[10] = '\0';
                }*/
                asin = asin.Remove(asin.IndexOf("/", asin.IndexOf("dp/") + 3));
                asin = asin.Remove(0, asin.IndexOf("dp/") + 3);
                MessageBox.Show(asin);
                return (asin);
            }
            else
            {
                throw new System.ArgumentException("AmazonのURLじゃないっぽい", "uri");
            }
        }
    }
}
