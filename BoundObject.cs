using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharp_javascript_communication
{
    class BoundObject
    {
        Frm_webrowser frmMain = null;

        public BoundObject(Frm_webrowser frm)
        {
            frmMain = frm;
        }

        public void TestWinForm(string text)
        {
            frmMain.testWinForm(text);
        }


    }
}
