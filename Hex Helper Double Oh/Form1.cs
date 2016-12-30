using iniHandler;
using IniParser;
using IniParser.Model;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace HHOHOH
{
    public partial class Form1 : Form
    {
        #region Private Fields
        private long eSeen = 0x31F96;
        private byte[] eSeenB = { 0x00, 0x20 };
        private long eSeen2 = 0x31FA4;
        private long eSeen3 = 0x19A3B0;
        private long eSeen4 = 0x19A3B8;
        private byte[] eSeenBo = { 0x01, 0x20 };

        private long frEV = 0x439FC;
        private long frEV2 = 0x43A02;

        private long eEV = 0x6DC48;
        private long eEV2 = 0x6DC4E;

        private byte[] EV = { 0xFC };
        private byte[] oEV = { 0xFF };

        //private byte[] poisonScript = { 0xFD, 0x02, 0x00, 0xE7, 0xE9, 0xE6, 0xEA, 0xDD, 0xEA, 0xD9, 0xD8, 0x00, 0xE8, 0xDC, 0xD9, 0x00, 0xE4, 0xE3, 0xDD, 0xE7, 0xE3, 0xE2, 0xDD, 0xE2, 0xDB, 0xAD, 0xFE, 0xCE, 0xDC, 0xD9, 0x00, 0xE4, 0xE3, 0xDD, 0xE7, 0xE3, 0xE2, 0x00, 0xDA, 0xD5, 0xD8, 0xD9, 0xD8, 0x00, 0xD5, 0xEB, 0xD5, 0xED, 0xAB, 0xFB };

        private byte[] oBerry = { 0x00, 0x29, 0x04, 0xD1 };

        private long AMapFix = 0x39fbf8;

        private byte[] AMapFixA = { 0xB5, 0xFF, 0x05, 0x08, };

        private byte[] AMapFixB = { 0xF1, 0x31, 0x06, 0x08 };

        private byte[] AMapFixRemoval = { 0x00, 0x00, 0x00, 0x00 };

        private byte[] BackB = { 0x00, 0x00, 0x00, 0x00 };

        private long Background = 0x30882;

        private long Birch = 0x308AC;

        private byte[] oBirch = { 0xB1, 0x08, 0x03, 0x08 };

        private byte[] oBackground = { 0xD1, 0xF7, 0x55, 0xF9 };

        private byte[] oIntro = { 0xBB };

        private byte[] IntroB = { 0x00 };

        private byte[] BirchB = { 0x31, 0x16, 0x03, 0x08 };

        private CultureInfo cul;

        private bool debuggingMode = false;

        private long eBerry = 0x68FD2;

        private long Egg1 = 0x1C3200;

        private long Egg1f = 0x1375B0;

        private long Egg2 = 0x71414;

        private long Egg2f = 0x46CBE;

        private long Egg3 = 0x70A38;

        private long Egg3f = 0x4623E;

        private bool Emerald = false;

        private long EMHM = 0x1b6d14;

        private long EMHM2 = 0x6E7CC;

        private long eRun = 0x11A1E8;

        private FileIniDataParser fileIniData = new FileIniDataParser();

        private string fileLocation;

        private bool FireRed = false;

        private long frDex = 0x10583C;

        private long frDex2 = 0x105856;

        private long frFlash = 0x110F54;

        private long FRHM = 0x441D6;

        private long FRHM2 = 0x125AA8;

        private long FRLGIV = 0x40A92;

        private long frMew = 0x1D402;

        private long frRun = 0xBD494;

        private long Grass = 0x59f34;

        private long Grass2 = 0x5A0EC;

        private byte[] HM = { 0x00 };

        private long Intro = 0x30872;

        private int lanInt = 0;

        private bool LeafGreen = false;

        private long lgDex = 0x105814;

        private long lgDex2 = 0x10582E;

        private long lgFlash = 0x110F2C;

        private long lgRun = 0xBD468;

        private IniFile MyIni = new IniFile(Application.StartupPath + @"\Settings.ini");

        private byte[] nBerry = { 0x02, 0x29, 0x04, 0xDC };

        private long NDEvo = 0xCE91A;

        private byte[] NDEvoBytes = { 0x00, 0x00, 0x14, 0xE0 };

        private byte[] nDex = { 0xff };

        private byte[] nEgg1 = { 0x01, 0x21 };

        private byte[] nEgg2 = { 0x01, 0x22 };

        private byte[] nEgg3 = { 0x01, 0x22 };

        private byte[] newIV = { 0x21, 0x68, 0x69, 0x60, 0x20, 0xE0 };

        private byte[] nFlash = { 0x00, 0x1C, 0x0F, 0xE0 };

        private byte[] nGrass = { 0x00, 0x21, 0x00, 0x06, 0x00, 0x0e, 0x02, 0x28, 0x01, 0xd0, 0xd1, 0x28, 0x01, 0xd1, 0x01, 0x20, 0x00, 0xe0, 0x00, 0x20, 0x00, 0x21, 0x70, 0x47, 0x03, 0x28, 0xf5, 0xe7 };

        private byte[] nGrass2 = { 0x0C, 0x30, 0x09, 0xE0 };

        private byte[] nMew = { 0x00 };

        private byte[] nRepel1 = { 0x0C, 0x48, 0xEB, 0xF7, 0x4C, 0xFA, 0x01, 0x06, 0x00, 0x29, 0x16, 0xD0, 0x41, 0x1E, 0x0C, 0x06, 0x0D, 0x0A, 0x07, 0x48, 0xEB, 0xF7, 0x51, 0xFA, 0x00, 0x2C, 0x0E, 0xD1, 0x03, 0x4C, 0x25, 0x80, 0x05, 0x48, 0xE6, 0xF7, 0xFA, 0xFC, 0x01, 0x20, 0x08, 0xE0, 0x30, 0xAD, 0x03, 0x02 };

        private byte[] nRepel2 = { 0x06 };

        private byte[] nRepel3 = { 0x1c };

        private byte[] nRepel4 = { 0x11 };

        private byte[] nRepel5 = { 0x0f };

        private byte[] nRepel6 = { 0x21, 0x88, 0x09, 0x02, 0x41, 0x40 };

        private byte[] nRepel7 = { 0x34, 0x4B, 0x28, 0x21, 0x71, 0x43, 0x5B, 0x18, 0xD9, 0x79, 0x30, 0x1C, 0x02, 0x22, 0x17, 0x4B, 0xFF, 0xF7, 0x49, 0xfB, 0xC7, 0xF7, 0x85, 0xFF, 0x70, 0xBD, 0x20, 0x40, 0x00, 0x00, 0xFF, 0xFf, 0x00, 0x00, 0x30, 0xAD, 0x03, 0x02 };

        private byte[] nRepel8 = { 0x00, 0x00, 0x00, 0x00 };

        private byte[] nRepel9 = { 0x00, 0x00, 0x00, 0xB5, 0x04, 0x48, 0x50, 0x21, 0x00, 0xF0, 0x01, 0xF8, 0x00, 0xBD, 0x00, 0x4A, 0x10, 0x47, 0x1D, 0x74, 0x07, 0x08, 0x99, 0x19, 0x0A, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        private byte[] nRun = { 0x00 };

        private byte[] oDex = { 0x00 };

        private byte[] oEgg1 = { 0x05, 0x21 };

        private byte[] oEgg2 = { 0x05, 0x22 };

        private byte[] oFlash = { 0x00, 0x28, 0x0F, 0xD0 };

        private byte[] oGrass = { 0x00, 0xB5, 0x00, 0x06, 0x00, 0x0E, 0x02, 0x28, 0x01, 0xD0, 0xD1, 0x28, 0x01, 0xD1, 0x01, 0x20, 0x00, 0xE0, 0x00, 0x20, 0x02, 0xBC, 0x08, 0x47, 0x00, 0x20, 0x70, 0x47 };

        private byte[] oGrass2 = { 0x00, 0x20, 0x70, 0x47 };

        private byte[] oHM = { 0x01 };

        private byte[] oIV = { 0x21, 0x78, 0x1F, 0x24, 0x0A, 0x1C };

        private byte[] oMew = { 0x97 };

        private byte[] oNDEvo = { 0x97, 0x28, 0x14, 0xDD };

        private bool OpenROM = false;

        private byte[] oPoisonB = { 0xD1 };

        private byte[] oRepel1 = { 0x0C, 0x4D, 0x28, 0x1C, 0xEB, 0xF7, 0x4B, 0xFA, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x28, 0x14, 0xD0, 0x44, 0x1E, 0x24, 0x04, 0x24, 0x0C, 0x28, 0x1C, 0x21, 0x1C, 0xEB, 0xF7, 0x4E, 0xFA, 0x00, 0x2C, 0x0B, 0xD1, 0x04, 0x48, 0xE6, 0xF7, 0xF9, 0xFC, 0x01, 0x20, 0x07, 0xE0, 0x00, 0x00 };

        private byte[] oRepel2 = { 0x04 };

        private byte[] oRepel3 = { 0x18 };

        private byte[] oRepel45 = { 0x0D };

        private byte[] oRepel6 = { 0x01, 0x1C, 0x09, 0x06, 0x09, 0x0E };

        private byte[] oRepel7 = { 0x07, 0x4A, 0x07, 0x4B, 0x30, 0x1C, 0x02, 0x21, 0x67, 0xF0, 0x23, 0xFA, 0x70, 0xBC, 0x01, 0xBC, 0x00, 0x47, 0x30, 0xAD, 0x03, 0x02, 0xFF, 0xFF, 0x00, 0x00, 0x20, 0x40, 0x00, 0x00, 0x18, 0x1D, 0x02, 0x02, 0xF9, 0xA1, 0x10, 0x08, 0x10 };

        private byte[] oRepel8 = { 0x67, 0xF0, 0xB5, 0xF9 };

        private byte[] oRepel8_1 = { 0x66, 0xF0, 0xC4, 0xFF };

        private byte[] oRepel9 = { 0x00, 0x6E, 0xFB, 0x1B, 0x08, 0x09, 0x03, 0x02, 0xCC, 0xBF, 0xCA, 0xBF, 0xC6, 0xB4, 0xE7, 0x00, 0xD9, 0xDA, 0xDA, 0xD9, 0xD7, 0xE8, 0x00, 0xEB, 0xE3, 0xE6, 0xD9, 0x00, 0xE3, 0xDA, 0xDA, 0xB0 };

        private byte[] oRFlagB = { 0x12, 0xF0, 0x49, 0xFE };

        private byte[] oRun = { 0x08 };

        private bool other = false;

        private long Poison = 0x06D7C3;

        private byte[] PoisonB = { 0xE0 };

        private long Repel1 = 0x830CA;

        private long Repel2 = 0x83119;

        private long Repel2_1 = 0xA19A5;

        private long Repel3 = 0xA19F6;

        private long Repel4 = 0xA19F8;

        private long Repel5 = 0xA19FC;

        private long Repel6 = 0xA1A0E;

        private long Repel7 = 0xA1A1E;

        private long Repel8 = 0xA1A5A;

        private long Repel8_1 = 0xA1A68;

        private long Repel9 = 0x1BFB66;

        //long RepelS = 0x456640;
        private long RepelF = 0x83100;

        private long RepelF2 = 0x83103;

        private byte[] RepelFN = { 0x40, 0x66, 0x45, 0x08 };

        private byte[] RepelOff = { 0x08 };

        private byte[] RepelSN = { 0x6A, 0x47, 0x0E, 0x80, 0x01, 0x00, 0x21, 0x0D, 0x80, 0x01, 0x00, 0x06, 0x04, 0x1C, 0x00, 0x80, 0x08, 0x0F, 0x00, 0x39, 0x00, 0x80, 0x08, 0x09, 0x03, 0x6C, 0x02, 0xFF, 0x0F, 0x00, 0x54, 0x00, 0x80, 0x08, 0x09, 0x05, 0x68, 0x21, 0x0D, 0x80, 0x01, 0x00, 0x06, 0x01, 0x32, 0x00, 0x80, 0x08, 0x02, 0xFF, 0x23, 0x69, 0xFB, 0x1B, 0x08, 0x02, 0xFF, 0xCC, 0xD9, 0xE4, 0xD9, 0xE0, 0xB4, 0xE7, 0x00, 0xD9, 0xDA, 0xDA, 0xD9, 0xD7, 0xE8, 0x00, 0xEB, 0xE3, 0xE6, 0xD9, 0x00, 0xE3, 0xDA, 0xDA, 0xAD, 0xFF, 0x00, 0xFF, 0xCC, 0xD9, 0xE4, 0xD9, 0xE0, 0xB4, 0xE7, 0x00, 0xD9, 0xDA, 0xDA, 0xD9, 0xD7, 0xE8, 0x00, 0xEB, 0xE3, 0xE6, 0xD9, 0x00, 0xE3, 0xDA, 0xDA, 0xAD, 0xAD, 0xAD, 0xFE, 0xCF, 0xE7, 0xD9, 0x00, 0xD5, 0xE2, 0xE3, 0xE8, 0xDC, 0xD9, 0xE6, 0xAC, 0xFF, 0x00, 0xFF };

        private ResourceManager res_man;

        private long RFlag = 0x05BA3A;

        private byte[] RFlagB = { 0x00, 0x00, 0x00, 0x00 };

        private long rRun = 0xE5E00;

        //RB offset in ROM
        //0x456640
        //IV fix
        private long RSIV = 0x3D89A;

        private bool Ruby = false;

        // declare Resource manager to access to specific cultureinfo
        private bool Sapphire = false;

        //Dex Seen
        private long Seen = 0x00CF56;

        private long Seen1 = 0x00CF64;

        private long Seen2 = 0x0F803C;

        private long Seen3 = 0x0F8044;

        private byte[] SeenB = { 0x00, 0x20 };

        private byte[] SeenO = { 0x01, 0x20 };

        //bytes to add feature
        //LG off set in ROM
        //EM offset in ROM
        private long sRun = 0xE5E00;

        #endregion Private Fields

        #region Public Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static byte[] Combine(byte[] first, byte[] second, byte[] third)
        {
            byte[] ret = new byte[first.Length + second.Length + third.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            Buffer.BlockCopy(third, 0, ret, first.Length + second.Length,
                             third.Length);
            return ret;
        }

        public static byte[] Combine(params byte[][] arrays)
        {
            byte[] ret = new byte[arrays.Sum(x => x.Length)];
            int offset = 0;
            foreach (byte[] data in arrays)
            {
                Buffer.BlockCopy(data, 0, ret, offset, data.Length);
                offset += data.Length;
            }
            return ret;
        }

        public static string GetBytesToString(byte[] value)
        {
            SoapHexBinary shb = new SoapHexBinary(value);
            return shb.ToString();
        }

        public static byte[] GetStringToBytes(string value)
        {
            SoapHexBinary shb = SoapHexBinary.Parse(value);
            return shb.Value;
        }

        #endregion Public Methods

        #region Private Methods

        private static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }

        private static void ExtractLanguage(string FileName, string language)
        {
            if (!File.Exists(Application.StartupPath + "\\" + language + "\\" + FileName))
            {
                DirectoryInfo di = Directory.CreateDirectory(Application.StartupPath + "\\" + language + "\\");
                Extract("HHOHOH", Application.StartupPath + "\\" + language + "\\", language, FileName);
            }
        }

        private static void ExtractSettings(string FileName)
        {
            if (!File.Exists(Application.StartupPath + FileName))
            {
                Extract("HHOHOH", Application.StartupPath, "Resources", FileName);
            }
        }

        private static void ExtractLanguage(string FileName)
        {
            if (!File.Exists(Application.StartupPath + "\\" + FileName + "\\" + "HHOHOH.resources.dll"))
            {
                DirectoryInfo di = Directory.CreateDirectory(Application.StartupPath + "\\" + FileName + "\\");
                Extract("HHOHOH", Application.StartupPath + "\\" + FileName + "\\", "LanguageDLL", "HHOHOH.resources.dll");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = dvTab;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            #region Change Default Options

            long BattleO = 0x05499C;
            long BattleO2 = 0x05499D;
            long TextO = 0x05496C;
            long TextO2 = 0x05496D;
            long BTNModeO = 0x0549A2;
            long BTNModeO2 = 0x0549A3;
            byte[] TwentyB = { 0x20 };

            byte[] Fix1 = { 0x10, 0x75 };
            long Fix1O = 0x5496e;
            byte[] Fix2 = { 0x50, 0x75 };
            long Fix2O = 0x05499E;
            byte[] Fix3 = { 0xC8, 0x74 };
            long Fix3O = 0x0549A4;

            //Text Section
            int Text1 = TextSpeed.SelectedIndex;
            int Text2 = Frame.SelectedIndex * 8;
            int Text3 = (Text1 + Text2);
            byte[] TextByte = BitConverter.GetBytes(Text3);
            WriteData(TextByte, TextO);
            WriteData(TwentyB, TextO2);

            //Battle Section
            int Battle1 = Sound.SelectedIndex;
            int Battle2 = BattleStyle.SelectedIndex * 2;
            int Battle3 = BattleScene.SelectedIndex * 4;
            int Battle4 = (Battle1 + Battle2 + Battle3);
            byte[] BattleB = BitConverter.GetBytes(Battle4);
            WriteData(BattleB, BattleO);
            WriteData(TwentyB, BattleO2);

            //Button
            byte[] ButtonB = BitConverter.GetBytes(BTNMode.SelectedIndex);
            WriteData(ButtonB, BTNModeO);
            WriteData(TwentyB, BTNModeO2);

            //Fix
            WriteData(Fix1, Fix1O);
            WriteData(Fix2, Fix2O);
            WriteData(Fix3, Fix3O);

            #endregion Change Default Options
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = frTab;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextSpeed.SelectedIndex = 1;
            Frame.SelectedIndex = 0;
            Sound.SelectedIndex = 1;
            BattleScene.SelectedIndex = 0;
            BattleStyle.SelectedIndex = 0;
            BTNMode.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            #region Add/Remove Indoor Running

            if (checkBox1.Checked == true)
            {
                try
                {
                    WriteData(nRun, frRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox1.Checked == false)
            {
                try
                {
                    WriteData(oRun, frRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Add/Remove Indoor Running
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            #region Run without flag

            if (checkBox10.Checked == true)
            {
                try
                {
                    WriteData(RFlagB, RFlag);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox10.Checked == false)
            {
                try
                {
                    WriteData(oRFlagB, RFlag);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Run without flag
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            #region Evolve Pokemon without National Dex

            if (checkBox11.Checked == true)
            {
                try
                {
                    WriteData(NDEvoBytes, NDEvo);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox11.Checked == false)
            {
                try
                {
                    WriteData(oNDEvo, NDEvo);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Evolve Pokemon without National Dex
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            #region Seen amount in Menu instead of caught

            if (checkBox12.Checked == true)
            {
                try
                {
                    WriteData(SeenB, Seen);  //stuff here for file writing
                    WriteData(SeenB, Seen1);
                    WriteData(SeenB, Seen2);
                    WriteData(SeenB, Seen3);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox12.Checked == false)
            {
                try
                {
                    WriteData(SeenO, Seen);  //stuff here for file writing
                    WriteData(SeenO, Seen1);
                    WriteData(SeenO, Seen2);
                    WriteData(SeenO, Seen3);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Seen amount in Menu instead of caught
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            #region Disable Overworld Poison

            if (checkBox13.Checked == true)
            {
                try
                {
                    WriteData(PoisonB, Poison);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox13.Checked == false)
            {
                try
                {
                    WriteData(oPoisonB, Poison);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Disable Overworld Poison
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            #region Fix A-Map FaceDown crash

            if (checkBox14.Checked == true)
            {
                try
                {
                    WriteData(AMapFixA, AMapFix);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox14.Checked == false)
            {
                DialogResult result1 = MessageBox.Show("This actually fixes a major bug in A-Map where your game will crash if you select the wrong FaceDown movemnt. Removing this will bring that bug back, are you sure you want to do this?", "Warning", MessageBoxButtons.YesNo);
                if (result1 == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        WriteData(AMapFixRemoval, AMapFix);
                        statusLabel.Text = res_man.GetString("Status_Remove", cul);
                    }
                    catch
                    {
                        MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                    }
                }
                if (result1 == System.Windows.Forms.DialogResult.No)
                {
                    checkBox13.Checked = true;
                }
            }

            #endregion Fix A-Map FaceDown crash
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            #region Add/Remove FR Dex Fix

            if (checkBox2.Checked == true)
            {
                try
                {
                    WriteData(nDex, frDex);  //stuff here for file writing
                    WriteData(nDex, frDex2);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox2.Checked == false)
            {
                try
                {
                    WriteData(oDex, frDex);  //stuff here for file writing
                    WriteData(oDex, frDex2);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Add/Remove FR Dex Fix
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            #region Tall Grass Fix

            if (checkBox3.Checked == true)
            {
                try
                {
                    WriteData(nGrass, Grass);  //stuff here for file writing
                    WriteData(nGrass2, Grass2);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox3.Checked == false)
            {
                try
                {
                    WriteData(oGrass, Grass);  //stuff here for file writing
                    WriteData(oGrass2, Grass2);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Tall Grass Fix
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            #region Level 1 Babies

            if (checkBox4.Checked == true)
            {
                try
                {
                    WriteData(nEgg1, Egg1f);  //stuff here for file writing
                    WriteData(nEgg2, Egg2f);
                    WriteData(nEgg3, Egg3f);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox4.Checked == false)
            {
                try
                {
                    WriteData(oEgg1, Egg1f);  //stuff here for file writing
                    WriteData(oEgg2, Egg2f);
                    WriteData(oEgg2, Egg3f);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Level 1 Babies
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            #region Deleteable HMs

            if (checkBox5.Checked == true)
            {
                try
                {
                    WriteData(HM, FRHM);  //stuff here for file writing
                    WriteData(HM, FRHM2);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox5.Checked == false)
            {
                try
                {
                    WriteData(oHM, FRHM);  //stuff here for file writing
                    WriteData(oHM, FRHM2);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Deleteable HMs
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            #region Remove/Add Flash FR

            if (checkBox6.Checked == true)
            {
                try
                {
                    WriteData(nFlash, frFlash); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            else if (checkBox6.Checked == false)
            {
                try
                {
                    WriteData(oFlash, frFlash); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Remove/Add Flash FR
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            #region Apply BW Repel System

            if (checkBox7.Checked == true)
            {
                DialogResult result = MessageBox.Show(res_man.GetString("bw_Warning", cul), res_man.GetString("notice_Warning", cul), MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox(res_man.GetString("freespace_Warning", cul), "FreeSpace", "efff00", 0, 0);
                    string vIn = input;
                    int vOut = Convert.ToInt32(input, 16);
                    // Store integer 182
                    // Convert integer 182 as a hex in a string variable
                    int long1 = vOut;
                    long long2 = Convert.ToInt64(long1);
                    try
                    {
                        WriteData(nRepel1, Repel1);
                        WriteData(nRepel2, Repel2);
                        WriteData(nRepel2, Repel2_1);
                        WriteData(nRepel3, Repel3);
                        WriteData(nRepel4, Repel4);
                        WriteData(nRepel5, Repel5);
                        WriteData(nRepel6, Repel6);
                        WriteData(nRepel7, Repel7);
                        WriteData(nRepel8, Repel8);
                        WriteData(nRepel8, Repel8_1);
                        WriteData(nRepel9, Repel9);
                        WriteData(RepelSN, long2);
                        int vOut2 = Convert.ToInt32(input, 16);

                        byte[] Final = BitConverter.GetBytes(vOut2);
                        WriteData(Final, RepelF);
                        WriteData(RepelOff, RepelF2);

                        #region Boring Offset Converting shit

                        int vOut3 = (vOut2 + 0x1c);
                        int vOut4 = (vOut2 + 0x39);
                        int vOut5 = (vOut2 + 0x54);
                        int vOut6 = (vOut2 + 0x32);

                        int local = (vOut2 + 0xd);
                        int local2 = (vOut2 + 0x13);
                        int local3 = (vOut2 + 0x1e);
                        int local4 = (vOut2 + 0x2c);
                        long Location1 = Convert.ToInt64(local);
                        long Location2 = Convert.ToInt64(local2);
                        long Location3 = Convert.ToInt64(local3);
                        long Location4 = Convert.ToInt64(local4);

                        byte[] Byte3 = BitConverter.GetBytes(vOut3);
                        byte[] Byte4 = BitConverter.GetBytes(vOut4);
                        byte[] Byte5 = BitConverter.GetBytes(vOut5);
                        byte[] Byte6 = BitConverter.GetBytes(vOut6);

                        #endregion Boring Offset Converting shit

                        WriteData(Byte3, Location1);
                        WriteData(Byte4, Location2);
                        WriteData(Byte5, Location3);
                        WriteData(Byte6, Location4);
                        int vfix = (local + 3);
                        int vfix2 = (local2 + 3);
                        int vfix3 = (local3 + 3);
                        int vfix4 = (local4 + 3);
                        long LocationF = Convert.ToInt64(vfix);
                        long LocationF2 = Convert.ToInt64(vfix2);
                        long LocationF3 = Convert.ToInt64(vfix3);
                        long LocationF4 = Convert.ToInt64(vfix4);
                        byte[] BFix = { 0x08 };
                        WriteData(BFix, LocationF);
                        WriteData(BFix, LocationF2);
                        WriteData(BFix, LocationF3);
                        WriteData(BFix, LocationF4);

                        string S = vOut3.ToString();
                        string S1 = vOut4.ToString();
                        string S2 = vOut5.ToString();
                        string S3 = vOut6.ToString();
                        statusLabel.Text = res_man.GetString("Status_Add", cul);
                    }
                    catch
                    {
                        MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                    }
                }
            }

            #endregion Apply BW Repel System

            #region Remove it

            else if (checkBox7.Checked == false)
            {
                WriteData(oRepel1, Repel1);
                WriteData(oRepel2, Repel2);
                WriteData(oRepel2, Repel2_1);
                WriteData(oRepel3, Repel3);
                WriteData(oRepel45, Repel4);
                WriteData(oRepel45, Repel5);
                WriteData(oRepel6, Repel6);
                WriteData(oRepel7, Repel7);
                WriteData(oRepel8, Repel8);
                WriteData(oRepel8_1, Repel8_1);
                WriteData(oRepel9, Repel9);
                statusLabel.Text = res_man.GetString("Status_Remove", cul);
            }

            #endregion Remove it
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            #region Force Mew Obey

            if (checkBox8.Checked == true)
            {
                try
                {
                    WriteData(nMew, frMew);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox8.Checked == false)
            {
                try
                {
                    WriteData(oMew, frMew);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Force Mew Obey
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            #region Fix Legend IVs

            if (checkBox9.Checked == true)
            {
                try
                {
                    WriteData(newIV, FRLGIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox9.Checked == false)
            {
                try
                {
                    WriteData(oIV, FRLGIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Fix Legend IVs
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            #region EV Cap
            if (checkBox23.Checked == true)
            {
                try
                {
                    WriteData(EV, frEV);  //stuff here for file writing
                    WriteData(EV, frEV2);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox23.Checked == false)
            {
                try
                {
                    WriteData(oEV, frEV);  //stuff here for file writing
                    WriteData(oEV, frEV2);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion
        }

        private bool CheckPatch(byte[] originalBytes, long Offset, BinaryReader br, bool returnValue)
        {
            try
            {
                int length = originalBytes.Length;
                br.BaseStream.Seek(Offset, SeekOrigin.Begin);
                byte[] TempByte = br.ReadBytes(length);
                if (GetBytesToString(TempByte) == GetBytesToString(originalBytes))
                {
                    returnValue = false;
                }
                if (GetBytesToString(TempByte) != GetBytesToString(originalBytes))
                {
                    returnValue = true;
                }
                if (debuggingMode == true)
                {
                    MessageBox.Show("Value " + returnValue.ToString() + " at " + Offset.ToString() + " Bytes read:" + GetBytesToString(TempByte) + " Original Bytes:" + GetBytesToString(originalBytes));
                }
            }
            catch
            {
                MessageBox.Show("Error while reading patch data at offset " + Offset.ToString() + "! Please report this to the developer!");
            }
            return returnValue;
        }

        private int CheckPatch2(byte[] originalBytes, long Offset, BinaryReader br, int returnValue)
        {
            try
            {
                int length = originalBytes.Length;
                br.BaseStream.Seek(Offset, SeekOrigin.Begin);
                byte[] TempByte = br.ReadBytes(length);
                if (GetBytesToString(TempByte) != GetBytesToString(originalBytes))
                {
                    returnValue += 1;
                }
                if (debuggingMode == true)
                {
                    MessageBox.Show("Value " + returnValue.ToString() + " at " + Offset.ToString() + " Bytes read:" + GetBytesToString(TempByte) + " Original Bytes:" + GetBytesToString(originalBytes));
                }
            }
            catch
            {
                MessageBox.Show("Error while reading patch data at offset " + Offset.ToString() + "! Please report this to the developer!");
            }
            return returnValue;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 1;
            switch_language();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + @"\Settings.ini"))
            {
                ExtractSettings("Settings.ini");
                lanInt = 1;
            }
            else
            {
                fileIniData.Parser.Configuration.CommentString = "#";
                //Check if user already exists
                IniData parsedData = fileIniData.ReadFile(Application.StartupPath + @"\Settings.ini");
                lanInt = Int32.Parse(parsedData["Settings"]["Language"]);
            }
            MaximizeBox = false;
            tabControl1.Appearance = TabAppearance.FlatButtons; tabControl1.ItemSize = new Size(0, 1); tabControl1.SizeMode = TabSizeMode.Fixed;

            #region Change Language for default text

            res_man = new ResourceManager("HHOHOH.Resources.Res", typeof(Form1).Assembly);
            switch_language();

            #endregion Change Language for default text
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 2;
            switch_language();
        }

        private void frTab_Click(object sender, EventArgs e)
        {
        }

        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debuggingMode = false;
            oFFToolStripMenuItem.Text = "-OFF-";
            oNToolStripMenuItem.Text = "on";
        }

        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debuggingMode = true;
            oFFToolStripMenuItem.Text = "off";
            oNToolStripMenuItem.Text = "-ON-";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //OpenFileDialog ofd2 = new OpenFileDialog();

            #region Open ROM

            ofd.Filter = "GBA File (*.gba)|*.gba";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bool returnValue = false;
                string filePath = ofd.FileName;
                BinaryReader br = new BinaryReader(File.OpenRead(ofd.FileName));
                br.BaseStream.Seek(0xAC, SeekOrigin.Begin);
                switch (Encoding.UTF8.GetString(br.ReadBytes(4)))

                #region Change Bool value based on ROM

                {
                    case "BPRE":
                        FireRed = true;
                        LeafGreen = false;
                        other = false;
                        Emerald = false;
                        Ruby = false;
                        other = false;
                        break;

                    case "BPGE":
                        FireRed = false;
                        LeafGreen = true;
                        other = false;
                        Emerald = false;
                        Ruby = false;
                        other = false;
                        break;

                    case "BPEE":
                        FireRed = false;
                        LeafGreen = false;
                        Emerald = true;
                        Ruby = false;
                        other = false;
                        break;

                    case "AXVE":
                        FireRed = false;
                        LeafGreen = false;
                        Emerald = false;
                        Ruby = true;
                        other = false;
                        break;

                    case "AXPE":
                        FireRed = false;
                        LeafGreen = false;
                        Ruby = true;
                        Sapphire = false;
                        Emerald = false;
                        other = false;
                        break;

                    default:
                        FireRed = false;
                        LeafGreen = false;
                        Ruby = false;
                        Sapphire = false;
                        Emerald = false;
                        other = true;
                        break;
                }

                #endregion Change Bool value based on ROM

                #region Apply settings based on ROM

                if (other == true)
                {
                    DialogResult result = MessageBox.Show("This game cannot be identified. If this is a ROM with a custom ID but with the normal english offsets then procede with caution. If it is not, it may cause irreversible damage. Do you wish to continue?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        other = false;
                    }
                }
                if (FireRed == true)
                {
                    tabControl1.SelectedTab = frTab;

                    #region Check Currently Applied patches

                    #region disable check changes

                    checkBox1.CheckedChanged -= checkBox1_CheckedChanged;
                    checkBox2.CheckedChanged -= checkBox2_CheckedChanged;
                    checkBox3.CheckedChanged -= checkBox3_CheckedChanged;
                    checkBox4.CheckedChanged -= checkBox4_CheckedChanged;
                    checkBox5.CheckedChanged -= checkBox5_CheckedChanged;
                    checkBox6.CheckedChanged -= checkBox6_CheckedChanged;
                    checkBox7.CheckedChanged -= checkBox7_CheckedChanged;
                    checkBox8.CheckedChanged -= checkBox8_CheckedChanged;
                    checkBox9.CheckedChanged -= checkBox9_CheckedChanged;
                    checkBox10.CheckedChanged -= checkBox10_CheckedChanged;
                    checkBox11.CheckedChanged -= checkBox11_CheckedChanged;
                    checkBox12.CheckedChanged -= checkBox12_CheckedChanged;
                    checkBox13.CheckedChanged -= checkBox13_CheckedChanged;
                    checkBox14.CheckedChanged -= checkBox14_CheckedChanged;
                    checkBox23.CheckedChanged -= checkBox23_CheckedChanged;

                    #endregion disable check changes

                    #region Running Indoors

                    checkBox1.Checked = CheckPatch(oRun, frRun, br, returnValue);

                    #endregion Running Indoors

                    #region FR Pokedex Fix

                    int patchINT = 0;
                    patchINT = +CheckPatch2(oDex, frDex, br, patchINT);
                    patchINT = +CheckPatch2(oDex, frDex2, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox2.Checked = true;
                    }

                    #endregion FR Pokedex Fix

                    #region BW Repel System

                    patchINT = 0;
                    patchINT = +CheckPatch2(oRepel1, Repel1, br, patchINT);
                    patchINT = +CheckPatch2(oRepel2, Repel2, br, patchINT);
                    patchINT = +CheckPatch2(oRepel3, Repel3, br, patchINT);
                    patchINT = +CheckPatch2(oRepel45, Repel4, br, patchINT);
                    patchINT = +CheckPatch2(oRepel45, Repel5, br, patchINT);
                    patchINT = +CheckPatch2(oRepel6, Repel6, br, patchINT);
                    patchINT = +CheckPatch2(oRepel7, Repel7, br, patchINT);
                    patchINT = +CheckPatch2(oRepel8, Repel8, br, patchINT);
                    patchINT = +CheckPatch2(oRepel9, Repel9, br, patchINT);
                    patchINT = +CheckPatch2(oRepel2, Repel2_1, br, patchINT);
                    patchINT = +CheckPatch2(oRepel8_1, Repel8_1, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox7.Checked = true;
                    }

                    #endregion BW Repel System

                    #region Flashback

                    checkBox6.Checked = CheckPatch(oFlash, frFlash, br, returnValue);

                    #endregion Flashback

                    #region Tall Grass

                    patchINT = 0;
                    patchINT = +CheckPatch2(oGrass, Grass, br, patchINT);
                    patchINT = +CheckPatch2(oGrass2, Grass2, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox3.Checked = true;
                    }

                    #endregion Tall Grass

                    #region Forced Mew

                    checkBox8.Checked = CheckPatch(oMew, frMew, br, returnValue);

                    #endregion Forced Mew

                    #region Level 1 Babies

                    patchINT = 0;
                    patchINT = +CheckPatch2(oEgg1, Egg1f, br, patchINT);
                    patchINT = +CheckPatch2(oEgg2, Egg2f, br, patchINT);
                    patchINT = +CheckPatch2(oEgg2, Egg3f, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox4.Checked = true;
                    }

                    #endregion Level 1 Babies

                    #region Legendary IV fix

                    checkBox9.Checked = CheckPatch(oIV, FRLGIV, br, returnValue);

                    #endregion Legendary IV fix

                    #region Deletable HMS

                    patchINT = 0;
                    patchINT = +CheckPatch2(oHM, FRHM, br, patchINT);
                    patchINT = +CheckPatch2(oHM, FRHM2, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox5.Checked = true;
                    }

                    #endregion Deletable HMS

                    #region Evo Without Nat Dex

                    checkBox11.Checked = CheckPatch(oNDEvo, NDEvo, br, returnValue);

                    #endregion Evo Without Nat Dex

                    #region Seen instead of caught

                    patchINT = 0;
                    patchINT = +CheckPatch2(SeenO, Seen, br, patchINT);
                    patchINT = +CheckPatch2(SeenO, Seen1, br, patchINT);
                    patchINT = +CheckPatch2(SeenO, Seen2, br, patchINT);
                    patchINT = +CheckPatch2(SeenO, Seen3, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox12.Checked = true;
                    }

                    #endregion Seen instead of caught

                    #region No Flag running shoes

                    checkBox10.Checked = CheckPatch(oRFlagB, RFlag, br, returnValue);

                    #endregion No Flag running shoes

                    #region No OW Poison

                    checkBox13.Checked = CheckPatch(oPoisonB, Poison, br, returnValue);

                    #endregion No OW Poison

                    #region Fix A-Map

                    checkBox14.Checked = CheckPatch(AMapFixRemoval, AMapFix, br, returnValue);

                    #endregion Fix A-Map

                    #region EV cap

                    patchINT = 0;
                    patchINT = +CheckPatch2(oEV, frEV, br, patchINT);
                    patchINT = +CheckPatch2(oEV, frEV2, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox23.Checked = true;
                    }

                    #endregion Seen instead of caught

                    #region ReEnable Checked Event

                    checkBox1.CheckedChanged += checkBox1_CheckedChanged;
                    checkBox2.CheckedChanged += checkBox2_CheckedChanged;
                    checkBox3.CheckedChanged += checkBox3_CheckedChanged;
                    checkBox4.CheckedChanged += checkBox4_CheckedChanged;
                    checkBox5.CheckedChanged += checkBox5_CheckedChanged;
                    checkBox6.CheckedChanged += checkBox6_CheckedChanged;
                    checkBox7.CheckedChanged += checkBox7_CheckedChanged;
                    checkBox8.CheckedChanged += checkBox8_CheckedChanged;
                    checkBox9.CheckedChanged += checkBox9_CheckedChanged;
                    checkBox10.CheckedChanged += checkBox10_CheckedChanged;
                    checkBox11.CheckedChanged += checkBox11_CheckedChanged;
                    checkBox12.CheckedChanged += checkBox12_CheckedChanged;
                    checkBox13.CheckedChanged += checkBox13_CheckedChanged;
                    checkBox14.CheckedChanged += checkBox14_CheckedChanged;
                    checkBox23.CheckedChanged += checkBox23_CheckedChanged;

                    #endregion ReEnable Checked Event

                    #region Change ROM Information

                    toolStripStatusLabel3.Text = "Fire Red BPRE";

                    #endregion Change ROM Information

                    #endregion Check Currently Applied patches
                }
                if (LeafGreen == true)
                {
                    tabControl1.SelectedTab = lgTab;
                    #region Check Currently Applied patches

                    #region disable check changes

                    checkBox24.CheckedChanged -= checkBox24_CheckedChanged;
                    checkBox25.CheckedChanged -= checkBox25_CheckedChanged;
                    checkBox26.CheckedChanged -= checkBox26_CheckedChanged;
                    checkBox27.CheckedChanged -= checkBox27_CheckedChanged;

                    #endregion disable check changes

                    #region Running Indoors

                    checkBox24.Checked = CheckPatch(oRun, lgRun, br, returnValue);

                    #endregion Running Indoors

                    #region FR Pokedex Fix

                    int patchINT = 0;
                    patchINT = +CheckPatch2(oDex, lgDex, br, patchINT);
                    patchINT = +CheckPatch2(oDex, lgDex2, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox25.Checked = true;
                    }

                    #endregion FR Pokedex Fix

                    #region Flashback

                    checkBox26.Checked = CheckPatch(oFlash, lgFlash, br, returnValue);

                    #endregion Flashback

                    #region Legendary IV fix

                    checkBox27.Checked = CheckPatch(oIV, FRLGIV, br, returnValue);

                    #endregion Legendary IV fix                 

                    #region ReEnable Checked Event

                    checkBox24.CheckedChanged += checkBox24_CheckedChanged;
                    checkBox25.CheckedChanged += checkBox25_CheckedChanged;
                    checkBox26.CheckedChanged += checkBox26_CheckedChanged;
                    checkBox27.CheckedChanged += checkBox27_CheckedChanged;
                    #endregion ReEnable Checked Event

                    #region Change ROM Information

                    toolStripStatusLabel3.Text = "Leaf Green BPGE";

                    #endregion Change ROM Information

                    #endregion Check Currently Applied patches
                }
                if (other == true)
                {
                    tabControl1.SelectedTab = frTab;
                }
                if (Emerald == true)
                {
                    tabControl1.SelectedTab = eTab;
                    #region Check Currently Applied patches

                    #region disable check changes

                    checkBox15.CheckedChanged -= checkBox15_CheckedChanged;
                    checkBox16.CheckedChanged -= checkBox16_CheckedChanged;
                    checkBox17.CheckedChanged -= checkBox17_CheckedChanged;
                    checkBox18.CheckedChanged -= checkBox18_CheckedChanged;
                    checkBox19.CheckedChanged -= checkBox19_CheckedChanged;
                    checkBox20.CheckedChanged -= checkBox20_CheckedChanged;
                    checkBox22.CheckedChanged -= checkBox22_CheckedChanged;
                    #endregion disable check changes
                    int patchINT = 0;
                    #region Running Indoors

                    checkBox17.Checked = CheckPatch(oRun, eRun, br, returnValue);

                    #endregion Running Indoors

                    #region Level 1 Babies

                    patchINT = 0;
                    patchINT = +CheckPatch2(oEgg1, Egg1, br, patchINT);
                    patchINT = +CheckPatch2(oEgg2, Egg2, br, patchINT);
                    patchINT = +CheckPatch2(oEgg2, Egg3, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox15.Checked = true;
                    }

                    #endregion Level 1 Babies

                    #region Deletable HMS

                    patchINT = 0;
                    patchINT = +CheckPatch2(oHM, EMHM, br, patchINT);
                    patchINT = +CheckPatch2(oHM, EMHM2, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox18.Checked = true;
                    }

                    #endregion Deletable HMS

                    #region Seen instead of caught

                    patchINT = 0;
                    patchINT = +CheckPatch2(SeenO, eSeen, br, patchINT);
                    patchINT = +CheckPatch2(SeenO, eSeen4, br, patchINT);
                    patchINT = +CheckPatch2(SeenO, eSeen2, br, patchINT);
                    patchINT = +CheckPatch2(SeenO, eSeen3, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox20.Checked = true;
                    }

                    #endregion Seen instead of caught

                    #region EV cap

                    patchINT = 0;
                    patchINT = +CheckPatch2(oEV, eEV, br, patchINT);
                    patchINT = +CheckPatch2(oEV, eEV2, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox22.Checked = true;
                    }

                    #endregion Seen instead of caught

                    #region Pomeg Fix
                    checkBox16.Checked = CheckPatch(oBerry, eBerry, br, returnValue);
                    #endregion

                    #region Birch
                    patchINT = 0;
                    patchINT = +CheckPatch2(oBirch, Birch, br, patchINT);
                    patchINT = +CheckPatch2(oBackground, Background, br, patchINT);
                    patchINT = +CheckPatch2(oIntro, Intro, br, patchINT);
                    if (patchINT != 0)
                    {
                        checkBox19.Checked = true;
                    }
                    #endregion

                    #region ReEnable Checked Event

                    checkBox15.CheckedChanged += checkBox15_CheckedChanged;
                    checkBox16.CheckedChanged += checkBox16_CheckedChanged;
                    checkBox17.CheckedChanged += checkBox17_CheckedChanged;
                    checkBox18.CheckedChanged += checkBox18_CheckedChanged;
                    checkBox19.CheckedChanged += checkBox19_CheckedChanged;
                    checkBox20.CheckedChanged += checkBox20_CheckedChanged;
                    checkBox22.CheckedChanged += checkBox22_CheckedChanged;


                    #endregion ReEnable Checked Event

                    #region Change ROM Information

                    toolStripStatusLabel3.Text = "Emerald BPEE";

                    #endregion Change ROM Information

                    #endregion Check Currently Applied patches
                }
                if (Ruby == true)
                {
                    tabControl1.SelectedTab = rTab;
                    #region Check Currently Applied patches

                    #region disable check changes

                    checkBox30.CheckedChanged -= checkBox30_CheckedChanged;
                    checkBox31.CheckedChanged -= checkBox31_CheckedChanged;

                    #endregion disable check changes

                    #region Running Indoors

                    checkBox30.Checked = CheckPatch(oRun, rRun, br, returnValue);

                    #endregion Running Indoors


                    #region Legendary IV fix

                    checkBox31.Checked = CheckPatch(oIV, RSIV, br, returnValue);

                    #endregion Legendary IV fix                 

                    #region ReEnable Checked Event

                    checkBox30.CheckedChanged += checkBox30_CheckedChanged;
                    checkBox31.CheckedChanged += checkBox31_CheckedChanged;
                    #endregion ReEnable Checked Event

                    #region Change ROM Information

                    toolStripStatusLabel3.Text = "Ruby";

                    #endregion Change ROM Information

                    #endregion Check Currently Applied patches
                }
                if (Sapphire == true)
                {
                    tabControl1.SelectedTab = sTab;
                    #region Check Currently Applied patches

                    #region disable check changes

                    checkBox28.CheckedChanged -= checkBox28_CheckedChanged;
                    checkBox29.CheckedChanged -= checkBox29_CheckedChanged;

                    #endregion disable check changes

                    #region Running Indoors

                    checkBox28.Checked = CheckPatch(oRun, rRun, br, returnValue);

                    #endregion Running Indoors


                    #region Legendary IV fix

                    checkBox29.Checked = CheckPatch(oIV, RSIV, br, returnValue);

                    #endregion Legendary IV fix                 

                    #region ReEnable Checked Event

                    checkBox28.CheckedChanged += checkBox28_CheckedChanged;
                    checkBox29.CheckedChanged += checkBox29_CheckedChanged;
                    #endregion ReEnable Checked Event

                    #region Change ROM Information

                    toolStripStatusLabel3.Text = "Sapphire";

                    #endregion Change ROM Information

                    #endregion Check Currently Applied patches
                }
                fileLocation = ofd.FileName;
                //Form1.Size = (363, 462);
                OpenROM = true;
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(Application.StartupPath + @"\Backups\");
                    if (!File.Exists(Application.StartupPath + @"\Backups\" + Path.GetFileName(fileLocation) + ".bak"))
                    {
                        File.Copy(fileLocation, Application.StartupPath + @"\Backups\" + Path.GetFileName(fileLocation) + ".bak");
                    }
                    else
                    {
                        int d = 0;
                        for (int i = 1; i < 100; i++)
                        {
                            if (!File.Exists(Application.StartupPath + @"\Backups\" + Path.GetFileName(fileLocation) + i + ".bak"))
                            {
                                File.Copy(fileLocation, Application.StartupPath + @"\Backups\" + Path.GetFileName(fileLocation) + i + ".bak");
                                i = 110;
                                d = 1;
                                statusLabel.Text = res_man.GetString("backup_Status", cul);
                            }
                        }
                        if(d == 0)
                        {
                            statusLabel.Text = res_man.GetString("backup_Status_Failed", cul);
                        }
                    }

                }
                catch { }
                br.Close();

                #endregion Apply settings based on ROM
            }

            #endregion Open ROM
        }

        private void reopenToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 3;
            switch_language();
        }

        private void switch_language()
        {
                if (lanInt == 1)
            {
                cul = CultureInfo.CreateSpecificCulture("en");    //create culture for english
                MyIni.Write("Language", "1", "Settings");
            }
            if (lanInt == 2)
            {
                cul = CultureInfo.CreateSpecificCulture("fr");     //create culture for french
                MyIni.Write("Language", "2", "Settings");
            }
            if (lanInt == 3)
            {
                cul = CultureInfo.CreateSpecificCulture("es");     //create culture for spanish
                MyIni.Write("Language", "3", "Settings");
            }
            if (lanInt == 4)
            {
                cul = CultureInfo.CreateSpecificCulture("ru");     //create culture for spanish
                MyIni.Write("Language", "4", "Settings");
            }
            if (lanInt == 5)
            {
                cul = CultureInfo.CreateSpecificCulture("ch");     //create culture for spanish
                MyIni.Write("Language", "5", "Settings");
            }

            #region strings
            try
            {
                statusLabel.Text = res_man.GetString("welcome_Status", cul);
                open.Text = res_man.GetString("open_Menu", cul);
                debuggingModeToolStripMenuItem.Text = res_man.GetString("debugging_Menu", cul);
                settingsToolStripMenuItem.Text = res_man.GetString("more_Menu", cul);
                languageToolStripMenuItem.Text = res_man.GetString("languages_Menu", cul);
                openBackupFolderToolStripMenuItem.Text = res_man.GetString("backup_Menu", cul);
                helpToolStripMenuItem.Text = res_man.GetString("help_Menu", cul);

                #region Fire Red
                checkBox1.Text = res_man.GetString("running_Text", cul);
                checkBox2.Text = res_man.GetString("pokedex_Text", cul);
                checkBox3.Text = res_man.GetString("grass_Text", cul);
                checkBox4.Text = res_man.GetString("egg_Text", cul);
                checkBox5.Text = res_man.GetString("hm_Text", cul);
                checkBox6.Text = res_man.GetString("flashback_Text", cul);
                checkBox7.Text = res_man.GetString("bw_Text", cul);
                checkBox8.Text = res_man.GetString("mew_Text", cul);
                checkBox9.Text = res_man.GetString("legend_Text", cul);
                checkBox10.Text = res_man.GetString("runFlag_Text", cul);
                checkBox11.Text = res_man.GetString("evo_Text", cul);
                checkBox12.Text = res_man.GetString("dexSeen_Text", cul);
                checkBox13.Text = res_man.GetString("poison_Text", cul);
                checkBox14.Text = res_man.GetString("amap_Text", cul);
                checkBox23.Text = res_man.GetString("ev_Text", cul);
                #endregion

                #region Emerald
                checkBox15.Text = res_man.GetString("egg_Text", cul);
                checkBox16.Text = res_man.GetString("pomeg_Text", cul);
                checkBox17.Text = res_man.GetString("running_Text", cul);
                checkBox18.Text = res_man.GetString("hm_Text", cul);
                checkBox19.Text = res_man.GetString("birch_Text", cul);
                checkBox20.Text = res_man.GetString("dexSeen_Text", cul);
                checkBox22.Text = res_man.GetString("ev_Text", cul);
                #endregion

                #region leaf green
                checkBox24.Text = res_man.GetString("running_Text", cul);
                checkBox25.Text = res_man.GetString("pokedex_Text", cul);
                checkBox26.Text = res_man.GetString("flashback_Text", cul);
                checkBox27.Text = res_man.GetString("legend_Text", cul);
                #endregion

                #region ruby
                checkBox30.Text = res_man.GetString("running_Text", cul);
                checkBox31.Text = res_man.GetString("legend_Text", cul);
                #endregion

                #region Sapphire
                checkBox28.Text = res_man.GetString("running_Text", cul);
                checkBox29.Text = res_man.GetString("legend_Text", cul);
                #endregion
            }
            catch
            {
                MessageBox.Show("Something crashed while loading the languages files");
                MyIni.Write("Language", "1", "Settings");              
            }
            #endregion strings
        }

        private void TextSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void undo_Click(object sender, EventArgs e)
        {
        }

        private void WriteData(byte[] BytesToWrite, long Offset)
        {
            try
            {
                if (OpenROM == true)
                {
                    BinaryWriter bw = new BinaryWriter(File.OpenWrite(fileLocation));
                    bw.BaseStream.Seek(Offset, SeekOrigin.Begin);
                    bw.Write(BytesToWrite);
                    bw.Close();
                }
                else
                {
                    statusLabel.Text = res_man.GetString("write_NoROM", cul);
                }
            }
            catch
            {
                statusLabel.Text = res_man.GetString("write_ERROR", cul);
            }
        }

        #endregion Private Methods

        private void openBackupFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\Backups\");
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 4;
            switch_language();
        }

        private void chineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 5;
            switch_language();
        }

        #region Emerald Checkboxes
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            #region Level 1 Babies

            if (checkBox15.Checked == true)
            {
                try
                {
                    WriteData(nEgg1, Egg1);  //stuff here for file writing
                    WriteData(nEgg2, Egg2);
                    WriteData(nEgg3, Egg3);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox15.Checked == false)
            {
                try
                {
                    WriteData(oEgg1, Egg1);  //stuff here for file writing
                    WriteData(oEgg1, Egg2);
                    WriteData(oEgg1, Egg3);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            #region Pomeg Berry Fix

            if (checkBox16.Checked == true)
            {
                try
                {
                    WriteData(nBerry, eBerry);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox16.Checked == false)
            {
                try
                {
                    WriteData(oBerry, eBerry); //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            #region Running indoors
            if (checkBox17.Checked == true)
            {
                try
                {
                    WriteData(nRun, eRun);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox17.Checked == false)
            {
                try
                {
                    WriteData(oRun, eRun);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

#endregion
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            #region Deletable HMs
            if (checkBox18.Checked == true)
            {
                try
                {
                    WriteData(HM, EMHM);  //stuff here for file writing
                    WriteData(HM, EMHM2);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox18.Checked == false)
            {
                try
                {
                    WriteData(oHM, EMHM);  //stuff here for file writing
                    WriteData(oHM, EMHM2);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            #region Remove Birch Intro
            if (checkBox19.Checked == true)
            {
                try
                {
                    WriteData(IntroB, Intro);  //stuff here for file writing
                    WriteData(BirchB, Birch);
                    WriteData(BackB, Background);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox19.Checked == false)
            {
                try
                {
                    WriteData(oIntro, Intro);  //stuff here for file writing
                    WriteData(oBirch, Birch);
                    WriteData(oBackground, Background);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            #region Seen dex in menu
            if (checkBox20.Checked == true)
            {
                try
                {
                    WriteData(eSeenB, eSeen);
                    WriteData(eSeenB, eSeen2);
                    WriteData(eSeenB, eSeen3);
                    WriteData(eSeenB, eSeen4);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox20.Checked == false)
            {
                try
                {
                    WriteData(eSeenBo, eSeen);
                    WriteData(eSeenBo, eSeen2);
                    WriteData(eSeenBo, eSeen3);
                    WriteData(eSeenBo, eSeen4);

                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            #region OW Poison
            if (checkBox21.Checked == true)
            {
                try
                {

                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox21.Checked == false)
            {
                try
                {

                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            #region EV Cap
            if (checkBox22.Checked == true)
            {
                try
                {
                    WriteData(EV, eEV);  //stuff here for file writing
                    WriteData(EV, eEV2);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox22.Checked == false)
            {
                try
                {
                    WriteData(oEV, eEV);  //stuff here for file writing
                    WriteData(oEV, eEV2);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion
        }
        #endregion

        #region lg check boxes
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            #region Add/Remove Indoor Running

            if (checkBox24.Checked == true)
            {
                try
                {
                    WriteData(nRun, lgRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox24.Checked == false)
            {
                try
                {
                    WriteData(oRun, lgRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Add/Remove Indoor Running

        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            #region Add/Remove FR Dex Fix

            if (checkBox25.Checked == true)
            {
                try
                {
                    WriteData(nDex, lgDex);  //stuff here for file writing
                    WriteData(nDex, lgDex2);
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox25.Checked == false)
            {
                try
                {
                    WriteData(oDex, lgDex);  //stuff here for file writing
                    WriteData(oDex, lgDex2);
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Add/Remove FR Dex Fix

        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            #region Remove/Add Flash lg

            if (checkBox26.Checked == true)
            {
                try
                {
                    WriteData(nFlash, lgFlash); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            else if (checkBox26.Checked == false)
            {
                try
                {
                    WriteData(oFlash, lgFlash); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Remove/Add Flash lg

        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            #region Fix Legend IVs

            if (checkBox27.Checked == true)
            {
                try
                {
                    WriteData(newIV, FRLGIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox27.Checked == false)
            {
                try
                {
                    WriteData(oIV, FRLGIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Fix Legend IVs

        }
        #endregion

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            #region Add/Remove Indoor Running

            if (checkBox28.Checked == true)
            {
                try
                {
                    WriteData(nRun, sRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox28.Checked == false)
            {
                try
                {
                    WriteData(oRun, sRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Add/Remove Indoor Running

        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            #region Fix Legend IVs

            if (checkBox29.Checked == true)
            {
                try
                {
                    WriteData(newIV, RSIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox29.Checked == false)
            {
                try
                {
                    WriteData(oIV, RSIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Fix Legend IVs

        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            #region Fix Legend IVs

            if (checkBox30.Checked == true)
            {
                try
                {
                    WriteData(newIV, RSIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox30.Checked == false)
            {
                try
                {
                    WriteData(oIV, RSIV);  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Fix Legend IVs
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            #region Add/Remove Indoor Running

            if (checkBox31.Checked == true)
            {
                try
                {
                    WriteData(nRun, rRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Add", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            if (checkBox31.Checked == false)
            {
                try
                {
                    WriteData(oRun, rRun); ;  //stuff here for file writing
                    statusLabel.Text = res_man.GetString("Status_Remove", cul);
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }

            #endregion Add/Remove Indoor Running
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.pokecommunity.com/showthread.php?t=338884");
        }
    }
}