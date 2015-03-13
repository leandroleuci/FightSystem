using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

using SdlDotNet.Graphics;
using SdlDotNet.Input;
using SdlDotNet.Audio;
using SdlDotNet.Core;

// http://cs-sdl.sourceforge.net/index.php/Joystick

namespace VariosJoystick
{
    public partial class Form1 : Form
    {
     //   Joystick joystick = Joysticks.OpenJoystick(0);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Joystick button was pressed");

           Go();
        }

        public void Go()
        {
            //Events.JoystickButtonDown += new EventHandler<JoystickButtonEventArgs>(this.JoystickButtonDown);
            //joystick = Joysticks.OpenJoystick(0);

        }

        private void JoystickButtonDown(object sender, JoystickButtonEventArgs e)
        {
            Console.WriteLine("Joystick button was pressed");
        }


    }

}


