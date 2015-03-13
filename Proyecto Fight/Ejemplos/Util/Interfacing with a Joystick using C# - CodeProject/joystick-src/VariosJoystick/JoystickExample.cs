using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

using SdlDotNet.Graphics;
using SdlDotNet.Input;
using SdlDotNet.Audio;
using SdlDotNet.Core;

using System.Windows.Forms;

namespace VariosJoystick
{
    public partial class JoystickExample : Form
    {
        public JoystickExample()
        {
            InitializeComponent();
            Joystick joystick = Joysticks.OpenJoystick(0);
        }
    }
}