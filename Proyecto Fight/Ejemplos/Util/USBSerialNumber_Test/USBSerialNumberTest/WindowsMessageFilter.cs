using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace USBDriveSerialNumber {
    public class WindowsMessageFilter : IMessageFilter {

        public TextBox tb;

        public bool PreFilterMessage(ref Message aMessage) {


            if (aMessage.Msg == 537) {
                //WM_AMESSAGE Dispatched
                //Let’s do something here
                //...
                tb.Text = "Device Inserted OR removed : " + DateTime.Now.ToString();
                
            } 
            // This can be either true of false
            // false enables the message to propagate to all other
            // listeners
            return false;
        }

        public void setTextBox(ref TextBox tb) {
            this.tb = tb;
        }


    }
}
