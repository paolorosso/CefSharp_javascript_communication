using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace CefSharp_javascript_communication
{
    public partial class Frm_webrowser : Form
    {
        public Frm_webrowser()
        {
            InitializeComponent();

            // Start the browser after initialize global component
            InitializeChromium();
        }

        public ChromiumWebBrowser chromeBrowser;
        public string Url = System.IO.Path.GetFullPath("../../../") + @"\HTML\test.html";

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(Url);

            // Eventi browser
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;

            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            chromeBrowser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(this), false);

        }



        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

            // Wait for the Page to finish loading
            if (e.IsLoading == false)
            {
                // X DEBUG
                chromeBrowser.ShowDevTools();

            }
        }

        private void Frm_webrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }




        internal void testWinForm(string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(text);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            str = "jsFunction('from winForm')";

            chromeBrowser.ExecuteScriptAsync(str);
        }

    }

}
