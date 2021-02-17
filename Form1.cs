using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VroomMachine
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        [Flags]
        private enum KeyStates
        {
            None = 0,
            Down = 1,
            Toggled = 2
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        private static KeyStates GetKeyState(Keys key)
        {
            KeyStates state = KeyStates.None;

            short retVal = GetKeyState((int)key);

            //If the high-order bit is 1, the key is down
            //otherwise, it is up.
            if ((retVal & 0x8000) == 0x8000)
                state |= KeyStates.Down;

            //If the low-order bit is 1, the key is toggled.
            if ((retVal & 1) == 1)
                state |= KeyStates.Toggled;

            return state;
        }

        public static bool IsKeyDown(Keys key)
        {
            return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
        }

        public static bool IsKeyToggled(Keys key)
        {
            return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);


        int basea = 0;
        memory m = new memory();

        float X, Y, Z;
        float p2X, p2Y, p2Z;
        float p3X, p3Y, p3Z;
        float p4X, p4Y, p4Z;

        private float[] X_z = new float[address.vz.Length];
        private float[] Y_z = new float[address.vz.Length];
        private float[] Z_z = new float[address.vz.Length];

        private Task<long> ReadMemory<T>(long v)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BringToFront();
            label2.BringToFront();
        }

        //private async void Cache_Tick(object sender, EventArgs e)
        //{
        //    if (address.PlayerCompPtr != await ReadMemory<UInt64>(address.PlayerBase))
        //        address.PlayerCompPtr = await ReadMemory<UInt64>(address.PlayerBase);
        //
        //    if (address.PlayerPedPtr != await ReadMemory<UInt64>(address.PlayerBase + 0x8))
        //        address.PlayerPedPtr = await ReadMemory<UInt64>(address.PlayerBase + 0x8);
        //
        //    if (address.ZMGlobalBase != await ReadMemory<UInt64>(address.PlayerBase + 0x60))
        //        address.ZMGlobalBase = await ReadMemory<UInt64>(address.PlayerBase + 0x60);
        //
        //    if (address.ZMBotBase != await ReadMemory<UInt64>(address.PlayerBase + 0x68))
        //        address.ZMBotBase = await ReadMemory<UInt64>(address.PlayerBase + 0x68);
        //
        //    if (address.ZMBotBase != 0x0 && address.ZMBotBase != 0x68 && address.ZMBotListBase != await ReadMemory<UInt64>(address.ZMBotBase + (uint)address.ZM_Bot_List_Offset))
        //        address.ZMBotListBase = await ReadMemory<UInt64>(address.ZMBotBase + (uint)address.ZM_Bot_List_Offset);
        //}

        private void ConnectTimer_Tick(object sender, EventArgs e)
        {
            {
                if (m.IsOpen())
                {
                    label1.Text = "Connected";
                    label1.ForeColor = Color.Green;
                    DevUp.Interval = 500;
                    if (pos.Enabled == false)
                    {
                        pos.Start();
                    }
                    if (basea == 0)
                    {
                        address.setadd();
                        basea = 1;
                    }
                }
                else
                {
                    m.AttackProcess("BlackOpsColdWar"); //Here?
                    label1.Text = "Disconnected";
                    label1.ForeColor = Color.Red;
                    DevUp.Interval = 100;
                }
            }

        }

        private void DevUp_Tick(object sender, EventArgs e)
        {
            //Extra Values
            metroLabel56.Text = "XP Multiplier: 0x" + address.XPMulti1.ToString("X") + "\r\n-Value 1: " + m.ReadFloat(address.XPMulti1).ToString() + "\r\n-Value 2: " + m.ReadFloat(address.XPMulti2).ToString() + "\r\n-Value 3: " + m.ReadFloat(address.XPMulti3).ToString();          //XP Multiplier
            metroLabel52.Text = "Base Address: 0x" + address.baseadd.ToString("X");
            metroLabel84.Text = "PlayerBasePtr Address: 0x" + address.PlayerBasePtr.ToString("X");
            metroLabel38.Text = "ZM Left: 0x" + address.ZMLeft.ToString("X");
            metroLabel39.Text = "ZM ignore: 0x" + address.ZMIgnore.ToString("X");

            //{DEV}
            metroLabel76.Text = "Cords:\r\n" + m.ReadFloat(address.cords).ToString() + " | " + m.ReadFloat(address.cords + 0x4).ToString() + " | " + m.ReadFloat(address.cords + 0x8);
            metroLabel85.Text = "Cords:\r\n" + m.ReadFloat(address.p2cords).ToString() + " | " + m.ReadFloat(address.p2cords + 0x4).ToString() + " | " + m.ReadFloat(address.p2cords + 0x8);
            metroLabel86.Text = "Cords:\r\n" + m.ReadFloat(address.p3cords).ToString() + " | " + m.ReadFloat(address.p3cords + 0x4).ToString() + " | " + m.ReadFloat(address.p3cords + 0x8);
            metroLabel87.Text = "Cords:\r\n" + m.ReadFloat(address.p4cords).ToString() + " | " + m.ReadFloat(address.p4cords + 0x4).ToString() + " | " + m.ReadFloat(address.p4cords + 0x8);
            ZMIgnoreVal.Text = "" + m.ReadInt32(address.ZMIgnore).ToString();
            metroLabel137.Text = "ZM Left: " + m.ReadInt32(address.ZMLeft).ToString();
            metroLabel135.Text = "UI ID: " + m.ReadInt64(address.uiid).ToString();
            metroLabel136.Text = "Playlist ID: " + m.ReadInt64(address.playlistid).ToString();


            //Player 1 Position
            if (metroRadioButton1.Checked)
            {
                Xvaldisplay.Text = "X: " + X;
                Yvaldisplay.Text = "Y: " + Y;
                Zvaldisplay.Text = "Z: " + Z;
            }
            else if (metroRadioButton2.Checked)
            {
                Xvaldisplay.Text = "X: " + p2X;
                Yvaldisplay.Text = "Y: " + p2Y;
                Zvaldisplay.Text = "Z: " + p2Z;
            }
            else if (metroRadioButton3.Checked)
            {
                Xvaldisplay.Text = "X: " + p3X;
                Yvaldisplay.Text = "Y: " + p3Y;
                Zvaldisplay.Text = "Z: " + p3Z;
            }
            else if (metroRadioButton4.Checked)
            {
                Xvaldisplay.Text = "X: " + p4X;
                Yvaldisplay.Text = "Y: " + p4Y;
                Zvaldisplay.Text = "Z: " + p4Z;
            }

            if (metroRadioButton32.Checked == true)
            { 
                metroRadioButton33.Enabled = false;
                metroRadioButton33.Checked = false;
                metroRadioButton35.Enabled = true;
                metroRadioButton36.Enabled = true;
                metroRadioButton34.Enabled = true;
            }
            else if (metroRadioButton16.Checked == true)
            {
                metroRadioButton33.Enabled = true;
                metroRadioButton35.Enabled = false;
                metroRadioButton35.Checked = false;
                metroRadioButton36.Enabled = true;
                metroRadioButton34.Enabled = true;
            }
            else if (metroRadioButton15.Checked == true)
            {
                metroRadioButton33.Enabled = true;
                metroRadioButton35.Enabled = true;
                metroRadioButton36.Enabled = false;
                metroRadioButton36.Checked = false;
                metroRadioButton34.Enabled = true;
            }
            else if (metroRadioButton14.Checked == true)
            {
                metroRadioButton33.Enabled = true;
                metroRadioButton35.Enabled = true;
                metroRadioButton36.Enabled = true;
                metroRadioButton34.Enabled = false;
                metroRadioButton34.Checked = false;
            }



                //Extra Addys


                // Player 1 Values
                if (m.ReadInt32(address.name).ToString() == "UnnamedPlayer")
                metroLabel57.Text = "Name: Unavailable";
            else metroLabel57.Text = "Name: " + m.ReadString(address.name, 16);                        //Name

            if (m.ReadInt32(address.nohithealth).ToString() == "536870912")                       //Godmode
                metroLabel9.Text = "Godmode: Off";
            else if (m.ReadInt64(address.nohithealth).ToString() == "2684354560")
                metroLabel9.Text = "Godmode: On";
            else metroLabel9.Text = "Godmode: Off";

            metroLabel65.Text = "Health: " + m.ReadInt32(address.hithealth).ToString();           //Health
            metroLabel13.Text = "Cash: " + m.ReadInt32(address.money).ToString();                 //Cash
            metroLabel10.Text = "Primary Ammo: " + m.ReadInt32(address.ammo1).ToString() + " | Max: " + m.ReadInt32(address.maxammo1).ToString();         //Primary
            metroLabel12.Text = "Secondary Ammo: " + m.ReadInt32(address.ammo2).ToString() + " | Max: " + m.ReadInt32(address.maxammo2).ToString(); ;       //Secondary
            metroLabel82.Text = "Secondary Ammo 2: " + m.ReadInt32(address.ammo3).ToString() + " | Max: " + m.ReadInt32(address.maxammo2).ToString(); ;       //Secondary 2

            metroLabel143.Text = "Green Salvage: " + m.ReadInt32(address.p1green).ToString();
            metroLabel142.Text = "Blue Salvage: " + m.ReadInt32(address.p1blue).ToString();
            metroLabel130.Text = "" + m.ReadInt32(address.displaycurrentweapon).ToString();

            //Player 1 Addys
            metroLabel58.Text = "Name: 0x" + address.name.ToString("X");                          //Name
            metroLabel18.Text = "Godmode: 0x" + address.nohithealth.ToString("X");                //Godmode
            metroLabel66.Text = "Health: 0x" + address.hithealth.ToString("X");                   //Health
            metroLabel14.Text = "Cash: 0x" + address.money.ToString("X");                         //Cash
            metroLabel16.Text = "Primary Ammo: 0x" + address.ammo1.ToString("X");                 //Primary
            metroLabel15.Text = "Secondary Ammo: 0x" + address.ammo2.ToString("X");               //Secondary
            metroLabel83.Text = "Secondary Ammo 2: 0x" + address.ammo3.ToString("X");               //Secondary 2


            // Player 2 Values
            if (m.ReadInt32(address.p2name).ToString() == "UnnamedPlayer")                       //Godmode
                metroLabel59.Text = "Name: Unavailable";
            else metroLabel59.Text = "Name: " + m.ReadString(address.p2name, 16);               //Name



            if (m.ReadInt32(address.p2nohithealth).ToString() == "536870912")                     //Godmode
                metroLabel28.Text = "Godmode: Off";
            else if (m.ReadInt64(address.p2nohithealth).ToString() == "2684354560")
                metroLabel28.Text = "Godmode: On";
            else metroLabel28.Text = "Godmode: Off";

            metroLabel67.Text = "Health: " + m.ReadInt32(address.p2hithealth).ToString();         //Health
            metroLabel24.Text = "Cash: " + m.ReadInt32(address.p2money).ToString();               //Cash
            metroLabel26.Text = "Primary Ammo: " + m.ReadInt32(address.p2ammo1).ToString();       //Primary
            metroLabel25.Text = "Secondary Ammo: " + m.ReadInt32(address.p2ammo2).ToString();     //Secondary

            metroLabel140.Text = "Green Salvage: " + m.ReadInt32(address.p2green).ToString();
            metroLabel141.Text = "Blue Salvage: " + m.ReadInt32(address.p2blue).ToString();
            metroLabel131.Text = "" + m.ReadInt32(address.p2displaycurrentweapon).ToString();

            //Player 2 Addys
            metroLabel60.Text = "Name: 0x" + address.p2name.ToString("X");                        //Name
            metroLabel23.Text = "Godmode: 0x" + address.p2nohithealth.ToString("X");              //Godmode
            metroLabel68.Text = "Health: 0x" + address.p2hithealth.ToString("X");                 //Health
            metroLabel19.Text = "Cash: 0x" + address.p2money.ToString("X");                       //Cash
            metroLabel21.Text = "Primary Ammo: 0x" + address.p2ammo1.ToString("X");               //Primary
            metroLabel20.Text = "Secondary Ammo: 0x" + address.p2ammo2.ToString("X");             //Secondary 


            // Player 3 Values
            if (m.ReadInt32(address.p3name).ToString() == "UnnamedPlayer")                       //Godmode
                metroLabel61.Text = "Name: Unavailable";
            else metroLabel61.Text = "Name: " + m.ReadString(address.p3name, 16);                //Name

            if (m.ReadInt32(address.p3nohithealth).ToString() == "536870912")                      //Godmode
                metroLabel38.Text = "Godmode: Off";
            else if (m.ReadInt64(address.p3nohithealth).ToString() == "2684354560")
                metroLabel38.Text = "Godmode: On";
            else metroLabel38.Text = "Godmode: Off";

            metroLabel69.Text = "Health: " + m.ReadInt32(address.p3hithealth).ToString();         //Health
            metroLabel34.Text = "Cash: " + m.ReadInt32(address.p3money).ToString();               //Cash
            metroLabel36.Text = "Primary Ammo: " + m.ReadInt32(address.p3ammo1).ToString();       //Primary
            metroLabel35.Text = "Secondary Ammo: " + m.ReadInt32(address.p3ammo2).ToString();     //Secondary

            metroLabel145.Text = "Green Salvage: " + m.ReadInt32(address.p3green).ToString();
            metroLabel144.Text = "Blue Salvage: " + m.ReadInt32(address.p3blue).ToString();
            metroLabel132.Text = "" + m.ReadInt32(address.p3displaycurrentweapon).ToString();

            //Player 3 Addys
            metroLabel62.Text = "Name: 0x" + address.p3name.ToString("X");                        //Name
            metroLabel33.Text = "Godmode: 0x" + address.p3nohithealth.ToString("X");              //Godmode
            metroLabel70.Text = "Health: 0x" + address.p3hithealth.ToString("X");                 //Health
            metroLabel29.Text = "Cash: 0x" + address.p3money.ToString("X");                       //Cash
            metroLabel31.Text = "Primary Ammo: 0x" + address.p3ammo1.ToString("X");               //Primary
            metroLabel30.Text = "Secondary Ammo: 0x" + address.p3ammo2.ToString("X");             //Secondary 


            // Player 4 Values
            if (m.ReadInt32(address.p4name).ToString() == "UnnamedPlayer")                       //Godmode
                metroLabel63.Text = "Name: Unavailable";
            else metroLabel63.Text = "Name: " + m.ReadString(address.p4name, 16);               //Name

            if (m.ReadInt32(address.p4nohithealth).ToString() == "536870912")                     //Godmode
                metroLabel48.Text = "Godmode: Off";
            else if (m.ReadInt64(address.p4nohithealth).ToString() == "2684354560")
                metroLabel48.Text = "Godmode: On";
            else metroLabel48.Text = "Godmode: Off";

            metroLabel71.Text = "Health: " + m.ReadInt32(address.p4hithealth).ToString();         //Health
            metroLabel44.Text = "Cash: " + m.ReadInt32(address.p4money).ToString();               //Cash
            metroLabel46.Text = "Primary Ammo: " + m.ReadInt32(address.p4ammo1).ToString();       //Primary
            metroLabel45.Text = "Secondary Ammo: " + m.ReadInt32(address.p4ammo2).ToString();     //Secondary

            metroLabel147.Text = "Green Salvage: " + m.ReadInt32(address.p4green).ToString();
            metroLabel146.Text = "Blue Salvage: " + m.ReadInt32(address.p4blue).ToString();
            metroLabel133.Text = "" + m.ReadInt32(address.p4displaycurrentweapon).ToString();

            //Player 4 Addys
            metroLabel64.Text = "Name: 0x" + address.p4name.ToString("X");                        //Name
            metroLabel43.Text = "Godmode: 0x" + address.p4nohithealth.ToString("X");              //Godmode
            metroLabel72.Text = "Health: 0x" + address.p4hithealth.ToString("X");                 //Health
            metroLabel39.Text = "Cash: 0x" + address.p4money.ToString("X");                       //Cash
            metroLabel41.Text = "Primary Ammo: 0x" + address.p4ammo1.ToString("X");               //Primary
            metroLabel40.Text = "Secondary Ammo: 0x" + address.p4ammo2.ToString("X");             //Secondary 
        }

        //---------------====================Begin Players====================---------------\\

        //Player 1

        private void pos_Tick(object sender, EventArgs e)
        {
            //Player Location
            X = m.ReadFloat(address.xpos);
            Y = m.ReadFloat(address.ypos);
            Z = m.ReadFloat(address.zpos);

            p2X = m.ReadFloat(address.p2xpos);
            p2Y = m.ReadFloat(address.p2ypos);
            p2Z = m.ReadFloat(address.p2zpos);

            p3X = m.ReadFloat(address.p3xpos);
            p3Y = m.ReadFloat(address.p3ypos);
            p3Z = m.ReadFloat(address.p3zpos);

            p4X = m.ReadFloat(address.p4xpos);
            p4Y = m.ReadFloat(address.p4ypos);
            p4Z = m.ReadFloat(address.p4zpos);

            Xval.Maximum = decimal.MaxValue;
            Xval.Minimum = decimal.MinValue;
            Yval.Maximum = decimal.MaxValue;
            Yval.Minimum = decimal.MinValue;
            Zval.Maximum = decimal.MaxValue;
            Zval.Minimum = decimal.MinValue;

            if (nocliptoggle.Checked == true)
            {
                if (IsKeyDown(Keys.NumPad4))
                {
                    if (metroRadioButton1.Checked)
                    {
                        m.WriteFloat(address.xpos, X + 20f);
                    };
                    if (metroRadioButton2.Checked)
                    {
                        m.WriteFloat(address.p2xpos, p2X + 20f);
                    };
                    if (metroRadioButton3.Checked)
                    {
                        m.WriteFloat(address.p3xpos, p3X + 20f);
                    };
                    if (metroRadioButton4.Checked)
                    {
                        m.WriteFloat(address.p4xpos, p4X + 20f);
                    };
                }
                if (IsKeyDown(Keys.NumPad6))
                {
                    if (metroRadioButton1.Checked)
                    {
                        m.WriteFloat(address.xpos, X - 20f);
                    };
                    if (metroRadioButton2.Checked)
                    {
                        m.WriteFloat(address.p2xpos, p2X - 20f);
                    };
                    if (metroRadioButton3.Checked)
                    {
                        m.WriteFloat(address.p3xpos, p3X - 20f);
                    };
                    if (metroRadioButton4.Checked)
                    {
                        m.WriteFloat(address.p4xpos, p4X - 20f);
                    };
                }
                if (IsKeyDown(Keys.NumPad2))
                {
                    if (metroRadioButton1.Checked)
                    {
                        m.WriteFloat(address.ypos, Y + 20f);
                    };
                    if (metroRadioButton2.Checked)
                    {
                        m.WriteFloat(address.p2ypos, p2Y + 20f);
                    };
                    if (metroRadioButton3.Checked)
                    {
                        m.WriteFloat(address.p3ypos, p3Y + 20f);
                    };
                    if (metroRadioButton4.Checked)
                    {
                        m.WriteFloat(address.p4ypos, p4Y + 20f);
                    };
                }
                if (IsKeyDown(Keys.NumPad8))
                {
                    if (metroRadioButton1.Checked)
                    {
                        m.WriteFloat(address.ypos, Y - 20f);
                    };
                    if (metroRadioButton2.Checked)
                    {
                        m.WriteFloat(address.p2ypos, p2Y - 20f);
                    };
                    if (metroRadioButton3.Checked)
                    {
                        m.WriteFloat(address.p3ypos, p3Y - 20f);
                    };
                    if (metroRadioButton4.Checked)
                    {
                        m.WriteFloat(address.p4ypos, p4Y - 20f);
                    };
                }
                if (IsKeyDown(Keys.NumPad9))
                {
                    if (metroRadioButton1.Checked)
                    {
                        m.WriteFloat(address.zpos, Z + 50f);
                    };
                    if (metroRadioButton2.Checked)
                    {
                        m.WriteFloat(address.p2zpos, p2Z + 50f);
                    };
                    if (metroRadioButton3.Checked)
                    {
                        m.WriteFloat(address.p3zpos, p3Z + 50f);
                    };
                    if (metroRadioButton4.Checked)
                    {
                        m.WriteFloat(address.p4zpos, p4Z + 50f);
                    };
                }
                if (IsKeyDown(Keys.NumPad3))
                {
                    if (metroRadioButton1.Checked)
                    {
                        m.WriteFloat(address.zpos, Z - 50f);
                    };
                    if (metroRadioButton2.Checked)
                    {
                        m.WriteFloat(address.p2zpos, p2Z - 50f);
                    };
                    if (metroRadioButton3.Checked)
                    {
                        m.WriteFloat(address.p3zpos, p3Z - 50f);
                    };
                    if (metroRadioButton4.Checked)
                    {
                        m.WriteFloat(address.p4zpos, p4Z - 50f);
                    };
                }
            }

            toolTip1.SetToolTip(Xval, "X");
            toolTip1.SetToolTip(Yval, "Y");
            toolTip1.SetToolTip(Zval, "Z");
        }

        private void vita_Tick(object sender, EventArgs e)
        {
            m.WriteByte(address.nohithealth, 0xA0);
        }

        private void health_Tick(object sender, EventArgs e)
        {
            m.WriteInt64(address.hithealth, -1);
        }

        private void money_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.money, Convert.ToInt32(moneyval.Text));
        }

        private void ammo_Tick(object sender, EventArgs e)
        {
            //if (m.ReadInt32(address.ammo1) != 0)
                m.WriteInt32(address.ammo1, 30);

            //if (m.ReadInt32(address.ammo2) != 0)
                m.WriteInt32(address.ammo2, 30);

            //if (m.ReadInt32(address.ammo3) != 0)
                m.WriteInt32(address.ammo3, 30);

            //if (m.ReadInt32(address.ammo4) != 0)
                m.WriteInt32(address.ammo4, 30);

            //if (m.ReadInt32(address.ammo5) != 0)
                m.WriteInt32(address.ammo5, 30);
        }

        private void Rapidfire_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.rapidfire1, 0);
            m.WriteInt32(address.rapidfire2, 0);
        }

        //====================Non Ticks====================\\

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle1.Checked == true)
            {
                vita.Start();
            }
            else
            {
                vita.Stop();
                m.WriteByte(address.nohithealth, 0x20);
            }
        }

        private void metroToggle9_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle9.Checked == true)
            {
                health.Start();
            }
            else
            {
                health.Stop();
                m.WriteInt32(address.hithealth, 150);
            }
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle2.Checked == true)
            {
                ammo.Start();
            }
            else
            {
                ammo.Stop();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            m.WriteInt64(address.money, Convert.ToInt64(moneyval.Text));
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)
            {
                money.Start();
            }
            else
            {
                money.Stop();
            }
        }

        private void metroToggle13_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle13.Checked)
            {
                Rapidfire.Start();
            }
            else
            {
                Rapidfire.Stop();
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (metroRadioButton33.Checked == true) // TP to Player 1
            {
                //metroRadioButton32.Visible = false; // Player 1
                if (metroRadioButton16.Checked == true) // Player 2
                {
                    m.WriteFloat(address.p2xpos, X + 50f);
                    m.WriteFloat(address.p2ypos, Y - 50f);
                    m.WriteFloat(address.p2zpos, Z + 10f);
                }
                else if (metroRadioButton15.Checked == true) // Player 3
                {
                    m.WriteFloat(address.p3xpos, X + 50f);
                    m.WriteFloat(address.p3ypos, Y - 50f);
                    m.WriteFloat(address.p3zpos, Z + 10f);
                }
                else if (metroRadioButton14.Checked == true) // Player 4
                {
                    m.WriteFloat(address.p4xpos, X + 50f);
                    m.WriteFloat(address.p4ypos, Y - 50f);
                    m.WriteFloat(address.p4zpos, Z + 10f);
                }
            }
            else if (metroRadioButton35.Checked == true)// TP to Player 2
            {
               //metroRadioButton16.Visible = false; // Player 2
                if (metroRadioButton32.Checked == true) // Player 1
                {
                    m.WriteFloat(address.xpos, p2X + 50f);
                    m.WriteFloat(address.ypos, p2Y - 50f);
                    m.WriteFloat(address.zpos, p2Z + 10f);
                }
                else if (metroRadioButton15.Checked == true) // Player 3
                {
                    m.WriteFloat(address.p3xpos, p2X + 50f);
                    m.WriteFloat(address.p3ypos, p2Y - 50f);
                    m.WriteFloat(address.p3zpos, p2Z + 10f);
                }
                else if (metroRadioButton14.Checked == true) // Player 4
                {
                    m.WriteFloat(address.p4xpos, p2X + 50f);
                    m.WriteFloat(address.p4ypos, p2Y - 50f);
                    m.WriteFloat(address.p4zpos, p2Z + 10f);
                }
            }
            else if (metroRadioButton36.Checked == true)// TP to Player 3
            {
                //metroRadioButton15.Visible = false; // Player 3
                if (metroRadioButton32.Checked == true) // Player 1
                {
                    m.WriteFloat(address.xpos, p3X + 50f);
                    m.WriteFloat(address.ypos, p3Y - 50f);
                    m.WriteFloat(address.zpos, p3Z + 10f);
                }
                else if (metroRadioButton16.Checked == true) // Player 2
                {
                    m.WriteFloat(address.p2xpos, p3X + 50f);
                    m.WriteFloat(address.p2ypos, p3Y - 50f);
                    m.WriteFloat(address.p2zpos, p3Z + 10f);
                }
                else if (metroRadioButton14.Checked == true) // Player 4
                {
                    m.WriteFloat(address.p4xpos, p3X + 50f);
                    m.WriteFloat(address.p4ypos, p3Y - 50f);
                    m.WriteFloat(address.p4zpos, p3Z + 10f);
                }
            }
            else if (metroRadioButton34.Checked == true)// TP to Player 4
            {
                //metroRadioButton14.Visible = false; // Player 4
                if (metroRadioButton32.Checked == true) // Player 1
                {
                    m.WriteFloat(address.xpos, p4X + 50f);
                    m.WriteFloat(address.ypos, p4Y - 50f);
                    m.WriteFloat(address.zpos, p4Z + 10f);
                }
                if (metroRadioButton16.Checked == true) // Player 2
                {
                    m.WriteFloat(address.p2xpos, p4X + 50f);
                    m.WriteFloat(address.p2ypos, p4Y - 50f);
                    m.WriteFloat(address.p2zpos, p4Z + 10f);
                }
                else if (metroRadioButton15.Checked == true) // Player 3
                {
                    m.WriteFloat(address.p3xpos, p4X + 50f);
                    m.WriteFloat(address.p3ypos, p4Y - 50f);
                    m.WriteFloat(address.p3zpos, p4Z + 10f);
                }
            }
        }

        //Perks
        private void metroCheckBox11_CheckedChanged(object sender, EventArgs e)//Perk 1
        {
            if (metroCheckBox11.Checked == true)
            {
                m.WriteInt32(address.perk1, -1);
            }
            else
            {
                m.WriteInt32(address.perk1, 0);
            }
        }

        private void metroCheckBox12_CheckedChanged(object sender, EventArgs e)//Perk 2
        {
            if (metroCheckBox12.Checked == true)
            {
                m.WriteInt32(address.perk2, -1);
            }
            else
            {
                m.WriteInt32(address.perk2, 0);
            }
        }

        private void metroCheckBox13_CheckedChanged(object sender, EventArgs e)//Perk 3
        {
            if (metroCheckBox13.Checked == true)
            {
                m.WriteInt32(address.perk3, -1);
            }
            else
            {
                m.WriteInt32(address.perk3, 0);
            }
        }

        private void metroCheckBox14_CheckedChanged(object sender, EventArgs e)//Perk 4
        {
            if (metroCheckBox14.Checked == true)
            {
                m.WriteInt32(address.perk4, -1);
            }
            else
            {
                m.WriteInt32(address.perk4, 0);
            }
        }

        private void metroCheckBox15_CheckedChanged(object sender, EventArgs e)//Perk 5
        {
            if (metroCheckBox15.Checked == true)
            {
                m.WriteInt32(address.perk5, -1);
            }
            else
            {
                m.WriteInt32(address.perk5, 0);
            }
        }

        private void metroCheckBox16_CheckedChanged(object sender, EventArgs e)//Perk 6
        {
            if (metroCheckBox16.Checked == true)
            {
                m.WriteInt32(address.perk6, -1);
            }
            else
            {
                m.WriteInt32(address.perk6, 0);
            }
        }

        private void metroCheckBox17_CheckedChanged(object sender, EventArgs e)//Perk 7
        {
            if (metroCheckBox17.Checked == true)
            {
                m.WriteInt32(address.perk7, -1);
            }
            else
            {
                m.WriteInt32(address.perk7, 0);
            }
        }

        private void metroCheckBox18_CheckedChanged(object sender, EventArgs e)//Perk 8
        {
            if (metroCheckBox18.Checked == true)
            {
                m.WriteInt32(address.perk8, -1);
            }
            else
            {
                m.WriteInt32(address.perk8, 0);
            }
        }

        private void metroCheckBox21_CheckedChanged(object sender, EventArgs e) //All Perks | Player 1
        {
            if (metroCheckBox21.Checked == true)
            {
                perks.Start();
                metroCheckBox11.Checked = true;
                metroCheckBox12.Checked = true;
                metroCheckBox13.Checked = true;
                metroCheckBox14.Checked = true;
                metroCheckBox15.Checked = true;
                metroCheckBox16.Checked = true;
                metroCheckBox17.Checked = true;
                metroCheckBox18.Checked = true;
            }
            else
            {
                perks.Stop();
                m.WriteInt32(address.perk1, 0);
                m.WriteInt32(address.perk2, 0);
                m.WriteInt32(address.perk3, 0);
                m.WriteInt32(address.perk4, 0);
                m.WriteInt32(address.perk5, 0);
                m.WriteInt32(address.perk6, 0);
                m.WriteInt32(address.perk7, 0);
                m.WriteInt32(address.perk8, 0);

                metroCheckBox11.Checked = false;
                metroCheckBox12.Checked = false;
                metroCheckBox13.Checked = false;
                metroCheckBox14.Checked = false;
                metroCheckBox15.Checked = false;
                metroCheckBox16.Checked = false;
                metroCheckBox17.Checked = false;
                metroCheckBox18.Checked = false;
            }
        }

        private void perks_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.perk1, 1);
            m.WriteInt32(address.perk2, -1);
            m.WriteInt32(address.perk3, -1);
            m.WriteInt32(address.perk4, -1);
            m.WriteInt32(address.perk5, -1);
            m.WriteInt32(address.perk6, -1);
            m.WriteInt32(address.perk7, -1);
            m.WriteInt32(address.perk8, -1);
        }

        //Player 2
        private void p2vita_Tick(object sender, EventArgs e)
        {
            m.WriteByte(address.p2nohithealth, 0xA0);
        }

        private void p2health_Tick(object sender, EventArgs e)
        {
            m.WriteInt64(address.p2hithealth, -1);
        }

        private void p2money_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p2money, Convert.ToInt32(p2moneyval.Text));
        }

        private void p2ammo_Tick(object sender, EventArgs e)
        {
            //if (m.ReadInt32(address.p2ammo1) != 0)
                m.WriteInt32(address.p2ammo1, 30);

            //if (m.ReadInt32(address.p2ammo2) != 0)
                m.WriteInt32(address.p2ammo2, 30);

            //if (m.ReadInt32(address.p2ammo3) != 0)
                m.WriteInt32(address.p2ammo3, 30);

            //if (m.ReadInt32(address.p2ammo4) != 0)
                m.WriteInt32(address.p2ammo4, 30);

            //if (m.ReadInt32(address.p2ammo5) != 0)
                m.WriteInt32(address.p2ammo5, 30);
        }

        private void p2Rapidfire_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p2rapidfire1, 0);
            m.WriteInt32(address.p2rapidfire2, 0);
        }

        //====================Non Ticks====================\\

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle3.Checked == true)
            {
                p2vita.Start();
            }
            else
            {
                p2vita.Stop();
                m.WriteByte(address.nohithealth, 0x20);
            }
        }

        private void metroToggle10_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle12.Checked == true)
            {
                p2health.Start();
            }
            else
            {
                p2health.Stop();
                m.WriteInt32(address.p2hithealth, 150);
            }
        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle4.Checked == true)
            {
                p2ammo.Start();
            }
            else
            {
                p2ammo.Stop();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            m.WriteInt64(address.p2money, Convert.ToInt64(p2moneyval.Text));
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked)
            {
                p2money.Start();
            }
            else
            {
                p2money.Stop();
            }
        }

        private void metroToggle14_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle14.Checked)
            {
                p2Rapidfire.Start();
            }
            else
            {
                p2Rapidfire.Stop();
            }
        }

        private void metroCheckBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox23.Checked == true)
            {
                m.WriteInt32(address.p2perk1, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk1, 0);
            }
        }

        private void metroCheckBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox25.Checked == true)
            {
                m.WriteInt32(address.p2perk2, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk2, 0);
            }
        }

        private void metroCheckBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox27.Checked == true)
            {
                m.WriteInt32(address.p2perk3, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk3, 0);
            }
        }

        private void metroCheckBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox29.Checked == true)
            {
                m.WriteInt32(address.p2perk4, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk4, 0);
            }
        }

        private void metroCheckBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox30.Checked == true)
            {
                m.WriteInt32(address.p2perk5, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk5, 0);
            }
        }

        private void metroCheckBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox28.Checked == true)
            {
                m.WriteInt32(address.p2perk6, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk6, 0);
            }
        }

        private void metroCheckBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox26.Checked == true)
            {
                m.WriteInt32(address.p2perk7, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk7, 0);
            }
        }

        private void metroCheckBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox24.Checked == true)
            {
                m.WriteInt32(address.p2perk8, -1);
            }
            else
            {
                m.WriteInt32(address.p2perk8, 0);
            }
        }

        private void metroCheckBox20_CheckedChanged(object sender, EventArgs e) //All Perks | Player 2
        {
            if (metroCheckBox20.Checked == true)
            {
                p2perks.Start();
                metroCheckBox23.Checked = true;
                metroCheckBox25.Checked = true;
                metroCheckBox27.Checked = true;
                metroCheckBox29.Checked = true;
                metroCheckBox30.Checked = true;
                metroCheckBox28.Checked = true;
                metroCheckBox26.Checked = true;
                metroCheckBox24.Checked = true;
            }
            else
            {
                p2perks.Stop();
                m.WriteInt32(address.p2perk1, 0);
                m.WriteInt32(address.p2perk2, 0);
                m.WriteInt32(address.p2perk3, 0);
                m.WriteInt32(address.p2perk4, 0);
                m.WriteInt32(address.p2perk5, 0);
                m.WriteInt32(address.p2perk6, 0);
                m.WriteInt32(address.p2perk7, 0);
                m.WriteInt32(address.p2perk8, 0);

                metroCheckBox23.Checked = false;
                metroCheckBox25.Checked = false;
                metroCheckBox27.Checked = false;
                metroCheckBox29.Checked = false;
                metroCheckBox30.Checked = false;
                metroCheckBox28.Checked = false;
                metroCheckBox26.Checked = false;
                metroCheckBox24.Checked = false;
            }
        }

        private void p2perks_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p2perk1, 1);
            m.WriteInt32(address.p2perk2, -1);
            m.WriteInt32(address.p2perk3, -1);
            m.WriteInt32(address.p2perk4, -1);
            m.WriteInt32(address.p2perk5, -1);
            m.WriteInt32(address.p2perk6, -1);
            m.WriteInt32(address.p2perk7, -1);
            m.WriteInt32(address.p2perk8, -1);
        }

        //Player 3
        private void p3vita_Tick(object sender, EventArgs e)
        {
            m.WriteByte(address.p3nohithealth, 0xA0);
        }

        private void p3health_Tick(object sender, EventArgs e)
        {
            m.WriteInt64(address.p3hithealth, -1);
        }

        private void p3money_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p3money, Convert.ToInt32(p3moneyval.Text));
        }

        private void p3ammo_Tick(object sender, EventArgs e)
        {
            //if (m.ReadInt32(address.p3ammo1) != 0)
                m.WriteInt32(address.p3ammo1, 30);

            //if (m.ReadInt32(address.p3ammo2) != 0)
                m.WriteInt32(address.p3ammo2, 30);

            //if (m.ReadInt32(address.p3ammo3) != 0)
                m.WriteInt32(address.p3ammo3, 30);

            //if (m.ReadInt32(address.p3ammo4) != 0)
                m.WriteInt32(address.p3ammo4, 30);

            //if (m.ReadInt32(address.p3ammo5) != 0)
                m.WriteInt32(address.p3ammo5, 30);
        }

        private void p3Rapidfire_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p3rapidfire1, 0);
            m.WriteInt32(address.p3rapidfire2, 0);
        }

        //====================Non Ticks====================\\

        private void metroToggle5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle5.Checked == true)
            {
                p3vita.Start();
            }
            else
            {
                p3vita.Stop();
                m.WriteByte(address.nohithealth, 0x20);
            }
        }

        private void metroToggle11_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle11.Checked == true)
            {
                p3health.Start();
            }
            else
            {
                p3health.Stop();
                m.WriteInt32(address.p3hithealth, 150);
            }
        }

        private void metroToggle6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle6.Checked == true)
            {
                p3ammo.Start();
            }
            else
            {
                p3ammo.Stop();
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            m.WriteInt64(address.p3money, Convert.ToInt64(p3moneyval.Text));
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox6.Checked)
            {
                p3money.Start();
            }
            else
            {
                p3money.Stop();
            }
        }

        private void metroToggle15_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle15.Checked)
            {
                p3Rapidfire.Start();
            }
            else
            {
                p3Rapidfire.Stop();
            }
        }

        private void metroCheckBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox33.Checked == true)
            {
                m.WriteInt32(address.p3perk1, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk1, 0);
            }
        }

        private void metroCheckBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox35.Checked == true)
            {
                m.WriteInt32(address.p3perk2, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk2, 0);
            }
        }

        private void metroCheckBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox37.Checked == true)
            {
                m.WriteInt32(address.p3perk3, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk3, 0);
            }
        }

        private void metroCheckBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox39.Checked == true)
            {
                m.WriteInt32(address.p3perk4, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk4, 0);
            }
        }

        private void metroCheckBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox40.Checked == true)
            {
                m.WriteInt32(address.p3perk5, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk5, 0);
            }
        }

        private void metroCheckBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox38.Checked == true)
            {
                m.WriteInt32(address.p3perk6, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk6, 0);
            }
        }

        private void metroCheckBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox35.Checked == true)
            {
                m.WriteInt32(address.p3perk7, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk7, 0);
            }
        }

        private void metroCheckBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox34.Checked == true)
            {
                m.WriteInt32(address.p3perk8, -1);
            }
            else
            {
                m.WriteInt32(address.p3perk8, 0);
            }
        }

        private void metroCheckBox31_CheckedChanged(object sender, EventArgs e) //All Perks | Player 3
        {
            if (metroCheckBox31.Checked == true)
            {
                p3perks.Start();
                metroCheckBox33.Checked = true;
                metroCheckBox35.Checked = true;
                metroCheckBox37.Checked = true;
                metroCheckBox39.Checked = true;
                metroCheckBox40.Checked = true;
                metroCheckBox38.Checked = true;
                metroCheckBox36.Checked = true;
                metroCheckBox34.Checked = true;
            }
            else
            {
                p3perks.Stop();
                m.WriteInt32(address.p3perk1, 0);
                m.WriteInt32(address.p3perk2, 0);
                m.WriteInt32(address.p3perk3, 0);
                m.WriteInt32(address.p3perk4, 0);
                m.WriteInt32(address.p3perk5, 0);
                m.WriteInt32(address.p3perk6, 0);
                m.WriteInt32(address.p3perk7, 0);
                m.WriteInt32(address.p3perk8, 0);

                metroCheckBox33.Checked = false;
                metroCheckBox35.Checked = false;
                metroCheckBox37.Checked = false;
                metroCheckBox39.Checked = false;
                metroCheckBox40.Checked = false;
                metroCheckBox38.Checked = false;
                metroCheckBox36.Checked = false;
                metroCheckBox34.Checked = false;
            }
        }

        private void p3perks_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p3perk1, 1);
            m.WriteInt32(address.p3perk2, -1);
            m.WriteInt32(address.p3perk3, -1);
            m.WriteInt32(address.p3perk4, -1);
            m.WriteInt32(address.p3perk5, -1);
            m.WriteInt32(address.p3perk6, -1);
            m.WriteInt32(address.p3perk7, -1);
            m.WriteInt32(address.p3perk8, -1);
        }

        //Player 4
        private void p4vita_Tick(object sender, EventArgs e)
        {
            m.WriteByte(address.p4nohithealth, 0xA0);
        }

        private void p4health_Tick(object sender, EventArgs e)
        {
            m.WriteInt64(address.p4hithealth, -1);
        }

        private void p4money_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p4money, Convert.ToInt32(p4moneyval.Text));
        }

        private void p4ammo_Tick(object sender, EventArgs e)
        {
            //if (m.ReadInt32(address.p4ammo1) != 0)
                m.WriteInt32(address.p4ammo1, 30);

            //if (m.ReadInt32(address.p4ammo2) != 0)
                m.WriteInt32(address.p4ammo2, 30);

            //if (m.ReadInt32(address.p4ammo3) != 0)
                m.WriteInt32(address.p4ammo3, 30);

            //if (m.ReadInt32(address.p4ammo4) != 0)
                m.WriteInt32(address.p4ammo4, 30);

            //if (m.ReadInt32(address.p4ammo5) != 0)
                m.WriteInt32(address.p4ammo5, 30);
        }

        private void p4Rapidfire_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p4rapidfire1, 0);
            m.WriteInt32(address.p4rapidfire2, 0);
        }

        //====================Non Ticks====================\\

        private void metroToggle7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle7.Checked == true)
            {
                p4vita.Start();
            }
            else
            {
                p4vita.Stop();
                m.WriteByte(address.nohithealth, 0x20);
            }
        }

        private void metroToggle12_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle12.Checked == true)
            {
                p4health.Start();
            }
            else
            {
                p4health.Stop();
                m.WriteInt32(address.p4hithealth, 150);
            }
        }

        private void metroToggle8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle8.Checked == true)
            {
                p4ammo.Start();
            }
            else
            {
                p4ammo.Stop();
            }
        }
        private void metroButton4_Click(object sender, EventArgs e)
        {
            m.WriteInt64(address.p4money, Convert.ToInt64(p4moneyval.Text));
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox7.Checked)
            {
                p4money.Start();
            }
            else
            {
                p4money.Stop();
            }
        }

        private void metroToggle16_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle16.Checked)
            {
                p4Rapidfire.Start();
            }
            else
            {
                p4Rapidfire.Stop();
            }
        }

        private void metroCheckBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox43.Checked == true)
            {
                m.WriteInt32(address.p4perk1, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk1, 0);
            }
        }

        private void metroCheckBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox45.Checked == true)
            {
                m.WriteInt32(address.p4perk2, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk2, 0);
            }
        }

        private void metroCheckBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox47.Checked == true)
            {
                m.WriteInt32(address.p4perk3, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk3, 0);
            }
        }

        private void metroCheckBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox49.Checked == true)
            {
                m.WriteInt32(address.p4perk4, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk4, 0);
            }
        }

        private void metroCheckBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox50.Checked == true)
            {
                m.WriteInt32(address.p4perk5, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk5, 0);
            }
        }

        private void metroCheckBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox48.Checked == true)
            {
                m.WriteInt32(address.p4perk6, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk6, 0);
            }
        }

        private void metroCheckBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox46.Checked == true)
            {
                m.WriteInt32(address.p4perk7, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk7, 0);
            }
        }

        private void metroCheckBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox44.Checked == true)
            {
                m.WriteInt32(address.p4perk8, -1);
            }
            else
            {
                m.WriteInt32(address.p4perk8, 0);
            }
        }

        private void metroCheckBox41_CheckedChanged(object sender, EventArgs e) //All Perks | Player 4
        {
            if (metroCheckBox41.Checked == true)
            {
                p4perks.Start();
                metroCheckBox43.Checked = true;
                metroCheckBox44.Checked = true;
                metroCheckBox45.Checked = true;
                metroCheckBox46.Checked = true;
                metroCheckBox47.Checked = true;
                metroCheckBox48.Checked = true;
                metroCheckBox49.Checked = true;
                metroCheckBox50.Checked = true;
            }
            else
            {
                p4perks.Stop();
                m.WriteInt32(address.p4perk1, 0);
                m.WriteInt32(address.p4perk2, 0);
                m.WriteInt32(address.p4perk3, 0);
                m.WriteInt32(address.p4perk4, 0);
                m.WriteInt32(address.p4perk5, 0);
                m.WriteInt32(address.p4perk6, 0);
                m.WriteInt32(address.p4perk7, 0);
                m.WriteInt32(address.p4perk8, 0);

                metroCheckBox43.Checked = false;
                metroCheckBox44.Checked = false;
                metroCheckBox45.Checked = false;
                metroCheckBox46.Checked = false;
                metroCheckBox47.Checked = false;
                metroCheckBox48.Checked = false;
                metroCheckBox49.Checked = false;
                metroCheckBox50.Checked = false;
            }
        }

        private void p4perks_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p4perk1, 1);
            m.WriteInt32(address.p4perk2, -1);
            m.WriteInt32(address.p4perk3, -1);
            m.WriteInt32(address.p4perk4, -1);
            m.WriteInt32(address.p4perk5, -1);
            m.WriteInt32(address.p4perk6, -1);
            m.WriteInt32(address.p4perk7, -1);
            m.WriteInt32(address.p4perk8, -1);
        }

        //---------------====================End Players====================---------------\\



        //===============--------------------Begin Extras-------------------===============\\
        private void metroButton8_Click(object sender, EventArgs e)
        {
            //m.WriteFloat(address.XPMulti1, Convert.ToSingle(numericUpDown4.Value));
            //m.WriteFloat(address.XPMulti2, Convert.ToSingle(numericUpDown4.Value));
            //m.WriteFloat(address.XPMulti3, Convert.ToSingle(numericUpDown4.Value));
        }


        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        // Zombies Stuff \\

        private void freeze_z_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < address.vz.Length; i++)
            {
                m.WriteFloat(address.X_z[i], X_z[i]);
                m.WriteFloat(address.Y_z[i], Y_z[i]);
                m.WriteFloat(address.Z_z[i], Z_z[i]);
            }
        }

        private void metroButton6_Click(object sender, EventArgs e) //Changes Zombie Health to zhealthval Input
        {
            for (int i = 0; i < address.vz.Length; i++)
            {
                m.WriteInt32(address.vz[i], Convert.ToInt32(zhealthval.Text));
            }
        }

        private void zhealth_Tick(object sender, EventArgs e) //Zombie health timer
        {
            for (int i = 0; i < address.vz.Length; i++)
            {
                m.WriteInt32(address.vz[i], Convert.ToInt32(zhealthval.Text));
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e) //Enable for constant change of Zombie Health to zhealthval Input 
        {
            if (metroCheckBox2.Checked)
            {
                zhealth.Start();
            }
            else
            {
                zhealth.Stop();
            }
        }

        int num = 1;
        private void metroButton5_Click_1(object sender, EventArgs e) //Teleport All Zombies to Player
        {
            if (metroToggle17.Checked)
            {
                metroToggle17.Checked = false;
                num = 1;
            };
            for (int i = 0; i < address.vz.Length; i++)
            {
                if (metroRadioButton8.Checked)
                {
                    m.WriteFloat(address.X_z[i], X + 50);
                    m.WriteFloat(address.Y_z[i], Y + 50);
                    m.WriteFloat(address.Z_z[i], Z);
                }
                else if (metroRadioButton7.Checked)
                {
                    m.WriteFloat(address.X_z[i], p2X + 50);
                    m.WriteFloat(address.Y_z[i], p2Y + 50);
                    m.WriteFloat(address.Z_z[i], p2Z);
                }
                else if (metroRadioButton6.Checked)
                {
                    m.WriteFloat(address.X_z[i], p3X + 50);
                    m.WriteFloat(address.Y_z[i], p3Y + 50);
                    m.WriteFloat(address.Z_z[i], p3Z);
                }
                else if (metroRadioButton5.Checked)
                {
                    m.WriteFloat(address.X_z[i], p4X + 50);
                    m.WriteFloat(address.Y_z[i], p4Y + 50);
                    m.WriteFloat(address.Z_z[i], p4Z);
                }
            }
            if (num == 1)
            {
                metroToggle17.Checked = true;
            }
        }

        private void metroToggle17_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle17.Checked)
            {
                for (int i = 0; i < address.vz.Length; i++)
                {
                    X_z[i] = m.ReadFloat(address.X_z[i]);
                    Y_z[i] = m.ReadFloat(address.Y_z[i]);
                    Z_z[i] = m.ReadFloat(address.Z_z[i]);
                }
                freeze_z.Start();
                return;
            }
            freeze_z.Stop();
        }

        private void TeleButt_Click(object sender, EventArgs e)
        {
            if (metroRadioButton1.Checked == true)
            {
                m.WriteFloat(address.xpos, Convert.ToSingle(Xval.Text));
                m.WriteFloat(address.ypos, Convert.ToSingle(Yval.Text));
                m.WriteFloat(address.zpos, Convert.ToSingle(Zval.Text));
            }
            else if (metroRadioButton2.Checked == true)
            {
                m.WriteFloat(address.p2xpos, Convert.ToSingle(Xval.Text));
                m.WriteFloat(address.p2ypos, Convert.ToSingle(Yval.Text));
                m.WriteFloat(address.p2zpos, Convert.ToSingle(Zval.Text));
            }
            else if (metroRadioButton3.Checked == true)
            {
                m.WriteFloat(address.p3xpos, Convert.ToSingle(Xval.Text));
                m.WriteFloat(address.p3ypos, Convert.ToSingle(Yval.Text));
                m.WriteFloat(address.p3zpos, Convert.ToSingle(Zval.Text));
            }
            else if (metroRadioButton4.Checked == true)
            {
                 m.WriteFloat(address.p4xpos, Convert.ToSingle(Xval.Text));
                 m.WriteFloat(address.p4ypos, Convert.ToSingle(Yval.Text));
                 m.WriteFloat(address.p4zpos, Convert.ToSingle(Zval.Text));
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dir = String.Empty;
            string[] lines = null;
            try
            {
                dir = Path.GetDirectoryName(Application.ExecutablePath) + @"\tp.txt";
                lines = File.ReadAllLines(dir);
                int index = Array.IndexOf(lines, metroComboBox1.SelectedItem.ToString());
                Xval.Text = lines[index + 1];
                Yval.Text = lines[index + 2];
                Zval.Text = lines[index + 3];
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File 'tp.txt' not found");
            }
            toolTip1.SetToolTip(metroComboBox1, metroComboBox1.Text);
        }

        private void metroComboBox1_DropDown(object sender, EventArgs e)
        {
            metroComboBox1.Items.Clear();
            string dir = String.Empty;
            string[] lines = null;
            try
            {
                dir = Path.GetDirectoryName(Application.ExecutablePath) + @"\tp.txt";
                lines = File.ReadAllLines(dir);
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (i % 5 == 0)
                        metroComboBox1.Items.Add(lines[i]);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File 'tp.txt' not found");
            }
        }

                //--------Send To Console--------\\
        void CbufAddText(string str)
        {
            if (m.IsOpen())
            {
                m.WriteString(m.BaseModule.ToInt64() + address.StC, str + "\n");
                m.WriteByte(m.BaseModule.ToInt64() + address.StC2, 1);
            }

        }

        private void StCButt_Click(object sender, EventArgs e)
        {
            CbufAddText(metroTextBox1.Text);
        }

        private void cbuff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CbufAddText(metroTextBox1.Text);
            }
        }

        private void FastRestartButt_Click(object sender, EventArgs e)
        {
            m.WriteString(m.BaseModule.ToInt64() + address.StC, "fast_restart;");
            m.WriteByte(m.BaseModule.ToInt64() + address.StC2, 1);
        }

        private void PlayerToP1_Tick(object sender, EventArgs e)
        {
        
        }

        private void metroButton11_Click(object sender, EventArgs e) // Player 1
        {
            if (metroRadioButton12.Checked)
                m.WriteInt32(address.setweapon, Convert.ToInt32(WeapNumSelector.Text));
            if (metroRadioButton11.Checked)
                m.WriteInt32(address.setweapon2, Convert.ToInt32(WeapNumSelector.Text));
            if (metroRadioButton10.Checked) ;
                m.WriteInt32(address.setweapon3, Convert.ToInt32(WeapNumSelector.Text));
            if (metroRadioButton13.Checked) ;
                m.WriteInt32(address.setweapon4, Convert.ToInt32(WeapNumSelector.Text));
            if (metroRadioButton9.Checked) ;
                m.WriteInt32(address.setweapon5, Convert.ToInt32(WeapNumSelector.Text));
            if (metroRadioButton37.Checked) ;
                m.WriteInt32(address.setweapon6, Convert.ToInt32(WeapNumSelector.Text));
        }

        private void metroButton12_Click(object sender, EventArgs e) // Player 2
        {
            if (metroRadioButton21.Checked)
                m.WriteInt32(address.p2setweapon, Convert.ToInt32(p2WeapNumSelector.Text));
            if (metroRadioButton20.Checked)
                m.WriteInt32(address.p2setweapon2, Convert.ToInt32(p2WeapNumSelector.Text));
            if (metroRadioButton19.Checked) ;
                m.WriteInt32(address.p2setweapon3, Convert.ToInt32(p2WeapNumSelector.Text));
            if (metroRadioButton17.Checked) ;
                m.WriteInt32(address.p2setweapon4, Convert.ToInt32(p2WeapNumSelector.Text));
            if (metroRadioButton18.Checked) ;
                m.WriteInt32(address.p2setweapon5, Convert.ToInt32(p2WeapNumSelector.Text));
            if (metroRadioButton37.Checked) ;
                m.WriteInt32(address.p2setweapon6, Convert.ToInt32(p2WeapNumSelector.Text));
        }

        private void metroButton13_Click(object sender, EventArgs e) // Player 3
        {
            if (metroRadioButton26.Checked)
                m.WriteInt32(address.p3setweapon, Convert.ToInt32(p3WeapNumSelector.Text));
            if (metroRadioButton25.Checked)
                m.WriteInt32(address.p3setweapon2, Convert.ToInt32(p3WeapNumSelector.Text));
            if (metroRadioButton24.Checked) ;
                m.WriteInt32(address.p3setweapon3, Convert.ToInt32(p3WeapNumSelector.Text));
            if (metroRadioButton22.Checked) ;
                m.WriteInt32(address.p3setweapon4, Convert.ToInt32(p3WeapNumSelector.Text));
            if (metroRadioButton23.Checked) ;
                m.WriteInt32(address.p3setweapon5, Convert.ToInt32(p3WeapNumSelector.Text));
            if (metroRadioButton38.Checked) ;
                m.WriteInt32(address.p3setweapon6, Convert.ToInt32(p3WeapNumSelector.Text));
        }

        private void metroButton14_Click(object sender, EventArgs e) // Player 4
        {
            if (metroRadioButton31.Checked)
                m.WriteInt32(address.p4setweapon, Convert.ToInt32(p4WeapNumSelector.Text));
            if (metroRadioButton30.Checked)
                m.WriteInt32(address.p4setweapon2, Convert.ToInt32(p4WeapNumSelector.Text));
            if (metroRadioButton29.Checked) ;
                m.WriteInt32(address.p4setweapon3, Convert.ToInt32(p4WeapNumSelector.Text));
            if (metroRadioButton27.Checked) ;
                m.WriteInt32(address.p4setweapon4, Convert.ToInt32(p4WeapNumSelector.Text));
            if (metroRadioButton28.Checked) ;
                m.WriteInt32(address.p4setweapon5, Convert.ToInt32(p4WeapNumSelector.Text));
            if (metroRadioButton39.Checked) ;
                m.WriteInt32(address.p4setweapon6, Convert.ToInt32(p4WeapNumSelector.Text));
        }

        private void metroToggle18_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle18.Checked)
            {
                m.WriteInt32(address.ZMIgnore, 1); //ON
            }
            else
            {
                m.WriteInt32(address.ZMIgnore, 0); //OFF
            }
        }

        private void ZMIgnore_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.ZMIgnore, 1);
        }

        private void setpm_Tick(object sender, EventArgs e)
        {
            m.WriteXBytes(address.pmatch, new byte[] { 0x64, 0x69, 0x72, 0x65, 0x63, 0x74, 0x6F, 0x72, 0x5F, 0x6F, 0x6E, 0x6C, 0x69, 0x6E, 0x65, 0x5F, 0x70, 0x72, 0x69, 0x76, 0x61, 0x74, 0x65 });
        }

        private void setcm_Tick(object sender, EventArgs e)
        {
            m.WriteXBytes(address.cmatch, new byte[] { 0x64, 0x69, 0x72, 0x65, 0x63, 0x74, 0x6F, 0x72, 0x5F, 0x6F, 0x6E, 0x6C, 0x69, 0x6E, 0x65, 0x5F, 0x63, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x00 });
        }

        private void metroCheckBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox53.Checked == true)
            {

                setcm.Start();

            }
            else
            {
                setcm.Stop();
                m.WriteXBytes(address.pmatch, new byte[] { 0x64, 0x69, 0x72, 0x65, 0x63, 0x74, 0x6F, 0x72, 0x5F, 0x6F, 0x6E, 0x6C, 0x69, 0x6E, 0x65, 0x5F, 0x70, 0x72, 0x65, 0x67, 0x61, 0x6D, 0x65 });

            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true)
            {

                setpm.Start();

            }
            else
            {
                setpm.Stop();
                m.WriteXBytes(address.pmatch, new byte[] { 0x64, 0x69, 0x72, 0x65, 0x63, 0x74, 0x6F, 0x72, 0x5F, 0x6F, 0x6E, 0x6C, 0x69, 0x6E, 0x65, 0x5F, 0x70, 0x72, 0x65, 0x67, 0x61, 0x6D, 0x65 });

            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            m.WriteInt64(address.jumpheight, Convert.ToInt64(jumpheightval.Value));
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            m.WriteInt64(address.p2green, Convert.ToInt64(GreenVal.Value));
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            m.WriteInt64(address.p2blue, Convert.ToInt64(BlueVal.Value));
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {

        }

        private void metroButton15_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel95_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox19.Checked == true)
            {
                HeadshotOnly.Start();

            }
            else
            {
                HeadshotOnly.Stop();
                m.WriteInt32(address.perk8, 0);
                m.WriteInt32(address.p2perk8, 0);
                m.WriteInt32(address.p3perk8, 0);
                m.WriteInt32(address.p4perk8, 0);
            }
        }

        private void HeadshotOnly_Tick(object sender, EventArgs e)
        {
            m.WriteByte(address.perk8, 255);
            m.WriteByte(address.p2perk8, 255);
            m.WriteByte(address.p3perk8, 255);
            m.WriteByte(address.p4perk8, 255);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Xvaldisplay_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Xvaldisplay.Text);
        }

        private void Yvaldisplay_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Yvaldisplay.Text);
        }

        private void Zvaldisplay_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Zvaldisplay.Text);
        }

        private void moneyval_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle19_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle19.Checked == true)
            {
                FUAmmo.Start();
            }
            else
            {
                FUAmmo.Stop();
                m.WriteInt32(address.RapidFieldUpgrade, 0);
            }
        }

        private void FUAmmo_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.RapidFieldUpgrade, 1);
        }

        private void metroToggle20_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle20.Checked == true)
            {
                p2FUAmmo.Start();
            }
            else
            {
                p2FUAmmo.Stop();
                m.WriteInt32(address.p2RapidFieldUpgrade, 0);
            }
        }

        private void p2FUAmmo_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p2RapidFieldUpgrade, 1);
        }

        private void metroToggle21_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle21.Checked == true)
            {
                p3FUAmmo.Start();
            }
            else
            {
                p3FUAmmo.Stop();
                m.WriteInt32(address.p3RapidFieldUpgrade, 0);
            }
        }

        private void p3FUAmmo_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p3RapidFieldUpgrade, 1);
        }

        private void metroToggle22_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle22.Checked == true)
            {
                p4FUAmmo.Start();
            }
            else
            {
                p4FUAmmo.Stop();
                m.WriteInt32(address.p4RapidFieldUpgrade, 0);
            }
        }


        private void p4FUAmmo_Tick(object sender, EventArgs e)
        {
            m.WriteInt32(address.p4RapidFieldUpgrade, 1);
        }

        private void metroLabel130_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(metroLabel130.Text);
        }

        private void metroLabel131_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(metroLabel131.Text);
        }

        private void metroLabel132_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(metroLabel132.Text);
        }

        private void metroLabel133_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(metroLabel133.Text);
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {

        }

        private void FullRestartButt_Click(object sender, EventArgs e)
        {
            m.WriteString(m.BaseModule.ToInt64() + address.StC, "full_restart;");
            m.WriteByte(m.BaseModule.ToInt64() + address.StC2, 1);
        }

        private void LaunchButt_Click(object sender, EventArgs e)
        {
            m.WriteString(m.BaseModule.ToInt64() + address.StC, "lobbylaunchgame;");
            m.WriteByte(m.BaseModule.ToInt64() + address.StC2, 1);
        }

        private void DCButt_Click(object sender, EventArgs e)
        {


        }

        private void DisableTheaterButt_Click(object sender, EventArgs e)
        {
            m.WriteString(m.BaseModule.ToInt64() + address.StC, "demo_stop;");
            m.WriteByte(m.BaseModule.ToInt64() + address.StC2, 1);
        }

        private void metroCheckBox51_CheckedChanged(object sender, EventArgs e)
        {
            m.WriteString(this.m.BaseModule.ToInt64() + address.StC, "magic_chest_movable 0;");
            m.WriteByte(this.m.BaseModule.ToInt64() + address.StC2, 1);
        }

        private void metroCheckBox52_CheckedChanged(object sender, EventArgs e)
        {
            m.WriteString(this.m.BaseModule.ToInt64() + address.StC, "gts forceradar 2;");
            m.WriteByte(this.m.BaseModule.ToInt64() + address.StC2, 1);
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox8.Checked)
            {
                debug.Start();
            }
            else
            {
                debug.Stop();
                m.WriteString(m.BaseModule.ToInt64() + address.StC, "ui_lobbydebugvis 0;");
                m.WriteByte(m.BaseModule.ToInt64() + address.StC2, 1);
            }
        }

        private void debug_Tick(object sender, EventArgs e)
        {
            m.WriteString(m.BaseModule.ToInt64() + address.StC, "ui_lobbydebugvis 3;");
            m.WriteByte(m.BaseModule.ToInt64() + address.StC2, 1);
        }
        
        //---------------====================End Extras====================---------------\\
    }
}
