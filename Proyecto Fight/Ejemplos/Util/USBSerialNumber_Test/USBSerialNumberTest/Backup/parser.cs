using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace USBDriveSerialNumber {
    class valueParser {

        public string getValueInQuotes(string inValue) {
            string parsedValue = "";
            
            int posFoundStart = 0;
            int posFoundEnd = 0;

            posFoundStart = inValue.IndexOf("\"");
            posFoundEnd = inValue.IndexOf("\"",posFoundStart+1);

            

            parsedValue = inValue.Substring(posFoundStart+1, (posFoundEnd-posFoundStart)-1);

            return parsedValue;
        }


    }
}
