using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


    public partial class Form1 : Form
    {
        private Joystick jst1;
        private Joystick jst2;
        private Joystick jst3;
        private Joystick jst4;

        int cantJoystick = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            jst1  = new JoystickInterface.Joystick(this.Handle);
            jst2 = new JoystickInterface.Joystick(this.Handle);
            jst3 = new JoystickInterface.Joystick(this.Handle);
            jst4 = new JoystickInterface.Joystick(this.Handle);

            string[] sticks = jst1.FindJoysticks();

            if (sticks.Length > 0)
            {
                jst1.AcquireJoystick(sticks[0]);
                cantJoystick = 1;
            }

            if (sticks.Length > 1)
            {
                jst2.AcquireJoystick(sticks[1]);
                cantJoystick = 2;
            }

            if (sticks.Length > 2)
            {
                jst3.AcquireJoystick(sticks[2]);
                cantJoystick = 3;
            }

            if (sticks.Length > 3)
            {
                jst4.AcquireJoystick(sticks[3]);
                cantJoystick = 4;
            }

            tmrUpdateStick.Enabled = true;
        }

        private void tmrUpdateStick_Tick_1(object sender, EventArgs e)
        {

            if (cantJoystick >= 1)
            {
                #region ' Joystick 1
                jst1.UpdateStatus();

                //  Ejes
                if (jst1.AxisC < 32511)
                    this.J1_button13.BackColor = Color.Red;
                else
                    this.J1_button13.BackColor = Color.Gray;

                if (jst1.AxisC > 32511)
                    this.J1_button14.BackColor = Color.Red;
                else
                    this.J1_button14.BackColor = Color.Gray;

                if (jst1.AxisD < 32511)
                    this.J1_button11.BackColor = Color.Red;
                else
                    this.J1_button11.BackColor = Color.Gray;

                if (jst1.AxisD > 32511)
                    this.J1_button12.BackColor = Color.Red;
                else
                    this.J1_button12.BackColor = Color.Gray;

                //   R
                if (jst1.Buttons[0])
                    this.J1_button1.BackColor = Color.Red;
                else
                    this.J1_button1.BackColor = Color.Gray;

                if (jst1.Buttons[1])
                    this.J1_button2.BackColor = Color.Red;
                else
                    this.J1_button2.BackColor = Color.Gray;

                if (jst1.Buttons[2])
                    this.J1_button3.BackColor = Color.Red;
                else
                    this.J1_button3.BackColor = Color.Gray;

                if (jst1.Buttons[3])
                    this.J1_button4.BackColor = Color.Red;
                else
                    this.J1_button4.BackColor = Color.Gray;

                // Superiores
                if (jst1.Buttons[4])
                    this.J1_button5.BackColor = Color.Red;
                else
                    this.J1_button5.BackColor = Color.Gray;

                if (jst1.Buttons[5])
                    this.J1_button6.BackColor = Color.Red;
                else
                    this.J1_button6.BackColor = Color.Gray;

                if (jst1.Buttons[6])
                    this.J1_button7.BackColor = Color.Red;
                else
                    this.J1_button7.BackColor = Color.Gray;

                if (jst1.Buttons[7])
                    this.J1_button8.BackColor = Color.Red;
                else
                    this.J1_button8.BackColor = Color.Gray;

                // Select  / Start
                if (jst1.Buttons[8])
                    this.J1_button9.BackColor = Color.Red;
                else
                    this.J1_button9.BackColor = Color.Gray;

                if (jst1.Buttons[9])
                    this.J1_button10.BackColor = Color.Red;
                else
                    this.J1_button10.BackColor = Color.Gray;


                #endregion
            }

            if (cantJoystick >= 2)
            {
                #region ' Joystick 2
                jst2.UpdateStatus();

                //  Ejes
                if (jst2.AxisC < 32511)
                    this.J2_button13.BackColor = Color.Red;
                else
                    this.J2_button13.BackColor = Color.Gray;

                if (jst2.AxisC > 32511)
                    this.J2_button14.BackColor = Color.Red;
                else
                    this.J2_button14.BackColor = Color.Gray;

                if (jst2.AxisD < 32511)
                    this.J2_button11.BackColor = Color.Red;
                else
                    this.J2_button11.BackColor = Color.Gray;

                if (jst2.AxisD > 32511)
                    this.J2_button12.BackColor = Color.Red;
                else
                    this.J2_button12.BackColor = Color.Gray;

                //   R
                if (jst2.Buttons[0])
                    this.J2_button1.BackColor = Color.Red;
                else
                    this.J2_button1.BackColor = Color.Gray;

                if (jst2.Buttons[1])
                    this.J2_button2.BackColor = Color.Red;
                else
                    this.J2_button2.BackColor = Color.Gray;

                if (jst2.Buttons[2])
                    this.J2_button3.BackColor = Color.Red;
                else
                    this.J2_button3.BackColor = Color.Gray;

                if (jst2.Buttons[3])
                    this.J2_button4.BackColor = Color.Red;
                else
                    this.J2_button4.BackColor = Color.Gray;

                // Superiores
                if (jst2.Buttons[4])
                    this.J2_button5.BackColor = Color.Red;
                else
                    this.J2_button5.BackColor = Color.Gray;

                if (jst2.Buttons[5])
                    this.J2_button6.BackColor = Color.Red;
                else
                    this.J2_button6.BackColor = Color.Gray;

                if (jst2.Buttons[6])
                    this.J2_button7.BackColor = Color.Red;
                else
                    this.J2_button7.BackColor = Color.Gray;

                if (jst2.Buttons[7])
                    this.J2_button8.BackColor = Color.Red;
                else
                    this.J2_button8.BackColor = Color.Gray;

                // Select  / Start
                if (jst2.Buttons[8])
                    this.J2_button9.BackColor = Color.Red;
                else
                    this.J2_button9.BackColor = Color.Gray;

                if (jst2.Buttons[9])
                    this.J2_button10.BackColor = Color.Red;
                else
                    this.J2_button10.BackColor = Color.Gray;


                #endregion
            }

            if (cantJoystick >= 3)
            {
                #region ' Joystick 3
                jst3.UpdateStatus();

                //  Ejes
                if (jst3.AxisC < 32511)
                    this.J3_button13.BackColor = Color.Red;
                else
                    this.J3_button13.BackColor = Color.Gray;

                if (jst3.AxisC > 32511)
                    this.J3_button14.BackColor = Color.Red;
                else
                    this.J3_button14.BackColor = Color.Gray;

                if (jst3.AxisD < 32511)
                    this.J3_button11.BackColor = Color.Red;
                else
                    this.J3_button11.BackColor = Color.Gray;

                if (jst3.AxisD > 32511)
                    this.J3_button12.BackColor = Color.Red;
                else
                    this.J3_button12.BackColor = Color.Gray;

                //   R
                if (jst3.Buttons[0])
                    this.J3_button1.BackColor = Color.Red;
                else
                    this.J3_button1.BackColor = Color.Gray;

                if (jst3.Buttons[1])
                    this.J3_button2.BackColor = Color.Red;
                else
                    this.J3_button2.BackColor = Color.Gray;

                if (jst3.Buttons[2])
                    this.J3_button3.BackColor = Color.Red;
                else
                    this.J3_button3.BackColor = Color.Gray;

                if (jst3.Buttons[3])
                    this.J3_button4.BackColor = Color.Red;
                else
                    this.J3_button4.BackColor = Color.Gray;

                // Superiores
                if (jst3.Buttons[4])
                    this.J3_button5.BackColor = Color.Red;
                else
                    this.J3_button5.BackColor = Color.Gray;

                if (jst3.Buttons[5])
                    this.J3_button6.BackColor = Color.Red;
                else
                    this.J3_button6.BackColor = Color.Gray;

                if (jst3.Buttons[6])
                    this.J3_button7.BackColor = Color.Red;
                else
                    this.J3_button7.BackColor = Color.Gray;

                if (jst3.Buttons[7])
                    this.J3_button8.BackColor = Color.Red;
                else
                    this.J3_button8.BackColor = Color.Gray;

                // Select  / Start
                if (jst3.Buttons[8])
                    this.J3_button9.BackColor = Color.Red;
                else
                    this.J3_button9.BackColor = Color.Gray;

                if (jst3.Buttons[9])
                    this.J3_button10.BackColor = Color.Red;
                else
                    this.J3_button10.BackColor = Color.Gray;


                #endregion
            }

            if (cantJoystick >= 4)
            {
                #region ' Joystick 4
                jst4.UpdateStatus();

                //  Ejes
                if (jst4.AxisC < 32511)
                    this.J4_button13.BackColor = Color.Red;
                else
                    this.J4_button13.BackColor = Color.Gray;

                if (jst4.AxisC > 32511)
                    this.J4_button14.BackColor = Color.Red;
                else
                    this.J4_button14.BackColor = Color.Gray;

                if (jst4.AxisD < 32511)
                    this.J4_button11.BackColor = Color.Red;
                else
                    this.J4_button11.BackColor = Color.Gray;

                if (jst4.AxisD > 32511)
                    this.J4_button12.BackColor = Color.Red;
                else
                    this.J4_button12.BackColor = Color.Gray;

                //   R
                if (jst4.Buttons[0])
                    this.J4_button1.BackColor = Color.Red;
                else
                    this.J4_button1.BackColor = Color.Gray;

                if (jst4.Buttons[1])
                    this.J4_button2.BackColor = Color.Red;
                else
                    this.J4_button2.BackColor = Color.Gray;

                if (jst4.Buttons[2])
                    this.J4_button3.BackColor = Color.Red;
                else
                    this.J4_button3.BackColor = Color.Gray;

                if (jst4.Buttons[3])
                    this.J4_button4.BackColor = Color.Red;
                else
                    this.J4_button4.BackColor = Color.Gray;

                // Superiores
                if (jst4.Buttons[4])
                    this.J4_button5.BackColor = Color.Red;
                else
                    this.J4_button5.BackColor = Color.Gray;

                if (jst4.Buttons[5])
                    this.J4_button6.BackColor = Color.Red;
                else
                    this.J4_button6.BackColor = Color.Gray;

                if (jst4.Buttons[6])
                    this.J4_button7.BackColor = Color.Red;
                else
                    this.J4_button7.BackColor = Color.Gray;

                if (jst4.Buttons[7])
                    this.J4_button8.BackColor = Color.Red;
                else
                    this.J4_button8.BackColor = Color.Gray;

                // Select  / Start
                if (jst4.Buttons[8])
                    this.J4_button9.BackColor = Color.Red;
                else
                    this.J4_button9.BackColor = Color.Gray;

                if (jst4.Buttons[9])
                    this.J4_button10.BackColor = Color.Red;
                else
                    this.J4_button10.BackColor = Color.Gray;


                #endregion
            }

        }

        //private void UpdateJoystick(JoystickInterface.Joystick jst1)
        //{
        //    //  Ejes
        //    if (jst1.AxisC < 32511)
        //        this.J1_button13.BackColor = Color.Red;
        //    else
        //        this.J1_button13.BackColor = Color.Gray;

        //    if (jst1.AxisC > 32511)
        //        this.J1_button14.BackColor = Color.Red;
        //    else
        //        this.J1_button14.BackColor = Color.Gray;

        //    if (jst1.AxisD < 32511)
        //        this.J1_button11.BackColor = Color.Red;
        //    else
        //        this.J1_button11.BackColor = Color.Gray;

        //    if (jst1.AxisD > 32511)
        //        this.J1_button12.BackColor = Color.Red;
        //    else
        //        this.J1_button12.BackColor = Color.Gray;

        //    //   R
        //    if (jst1.Buttons[0])
        //        this.J1_button1.BackColor = Color.Red;
        //    else
        //        this.J1_button1.BackColor = Color.Gray;

        //    if (jst1.Buttons[1])
        //        this.J1_button2.BackColor = Color.Red;
        //    else
        //        this.J1_button2.BackColor = Color.Gray;

        //    if (jst1.Buttons[2])
        //        this.J1_button3.BackColor = Color.Red;
        //    else
        //        this.J1_button3.BackColor = Color.Gray;

        //    if (jst1.Buttons[3])
        //        this.J1_button4.BackColor = Color.Red;
        //    else
        //        this.J1_button4.BackColor = Color.Gray;

        //    // Superiores
        //    if (jst1.Buttons[4])
        //        this.J1_button5.BackColor = Color.Red;
        //    else
        //        this.J1_button5.BackColor = Color.Gray;

        //    if (jst1.Buttons[5])
        //        this.J1_button6.BackColor = Color.Red;
        //    else
        //        this.J1_button6.BackColor = Color.Gray;

        //    if (jst1.Buttons[6])
        //        this.J1_button7.BackColor = Color.Red;
        //    else
        //        this.J1_button7.BackColor = Color.Gray;

        //    if (jst1.Buttons[7])
        //        this.J1_button8.BackColor = Color.Red;
        //    else
        //        this.J1_button8.BackColor = Color.Gray;


        //    // Select  / Start
        //    if (jst1.Buttons[8])
        //        this.J1_button9.BackColor = Color.Red;
        //    else
        //        this.J1_button9.BackColor = Color.Gray;

        //    if (jst1.Buttons[9])
        //        this.J1_button10.BackColor = Color.Red;
        //    else
        //        this.J1_button10.BackColor = Color.Gray;

        //}


    }


