using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace HHOHOH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Offsets and Values
        int lanInt = 0;

        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info

        string fileLocation;
        bool FireRed = false;
        bool LeafGreen = false;
        bool Emerald = false;
        bool Sapphire = false;
        bool Ruby = false;
        bool other = false;

        bool OpenROM = false;

        bool debuggingMode = false;

        //RemoveFlashBack
        byte[] nFlash = { 0x00, 0x1C, 0x0F, 0xE0 }; //bytes to remove feature
        byte[] oFlash = { 0x00, 0x28, 0x0F, 0xD0 }; //bytes to add feature
        long frFlash = 0x110F54; //FR offset in ROM
        long lgFlash = 0x110F2C; //LG off set in ROM

        //Indoor Running
        byte[] nRun = { 0x00 }; //bytes to remove feature
        byte[] oRun = { 0x08 }; //bytes to add feature
        long frRun = 0xBD494; //FR offset in ROM
        long lgRun = 0xBD468; //LG off set in ROM
        long eRun = 0x11A1E8; //EM offset in ROM
        long sRun = 0xE5E00; //SA off set in ROM
        long rRun = 0xE5E00; //RB offset in ROM

        //Repel
        byte[] nRepel1 = { 0x0C, 0x48, 0xEB, 0xF7, 0x4C, 0xFA, 0x01, 0x06, 0x00, 0x29, 0x16, 0xD0, 0x41, 0x1E, 0x0C, 0x06, 0x0D, 0x0A, 0x07, 0x48, 0xEB, 0xF7, 0x51, 0xFA, 0x00, 0x2C, 0x0E, 0xD1, 0x03, 0x4C, 0x25, 0x80, 0x05, 0x48, 0xE6, 0xF7, 0xFA, 0xFC, 0x01, 0x20, 0x08, 0xE0, 0x30, 0xAD, 0x03, 0x02 };
        byte[] nRepel2 = { 0x06 };
        byte[] nRepel3 = { 0x1c };
        byte[] nRepel4 = { 0x11 };
        byte[] nRepel5 = { 0x0f };
        byte[] nRepel6 = { 0x21, 0x88, 0x09, 0x02, 0x41, 0x40 };
        byte[] nRepel7 = { 0x34, 0x4B, 0x28, 0x21, 0x71, 0x43, 0x5B, 0x18, 0xD9, 0x79, 0x30, 0x1C, 0x02, 0x22, 0x17, 0x4B, 0xFF, 0xF7, 0x49, 0xfB, 0xC7, 0xF7, 0x85, 0xFF, 0x70, 0xBD, 0x20, 0x40, 0x00, 0x00, 0xFF, 0xFf, 0x00, 0x00, 0x30, 0xAD, 0x03, 0x02 };
        byte[] nRepel8 = { 0x00, 0x00, 0x00, 0x00 };
        byte[] nRepel9 = { 0x00, 0x00, 0x00, 0xB5, 0x04, 0x48, 0x50, 0x21, 0x00, 0xF0, 0x01, 0xF8, 0x00, 0xBD, 0x00, 0x4A, 0x10, 0x47, 0x1D, 0x74, 0x07, 0x08, 0x99, 0x19, 0x0A, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] RepelSN = { 0x6A, 0x47, 0x0E, 0x80, 0x01, 0x00, 0x21, 0x0D, 0x80, 0x01, 0x00, 0x06, 0x04, 0x1C, 0x00, 0x80, 0x08, 0x0F, 0x00, 0x39, 0x00, 0x80, 0x08, 0x09, 0x03, 0x6C, 0x02, 0xFF, 0x0F, 0x00, 0x54, 0x00, 0x80, 0x08, 0x09, 0x05, 0x68, 0x21, 0x0D, 0x80, 0x01, 0x00, 0x06, 0x01, 0x32, 0x00, 0x80, 0x08, 0x02, 0xFF, 0x23, 0x69, 0xFB, 0x1B, 0x08, 0x02, 0xFF, 0xCC, 0xD9, 0xE4, 0xD9, 0xE0, 0xB4, 0xE7, 0x00, 0xD9, 0xDA, 0xDA, 0xD9, 0xD7, 0xE8, 0x00, 0xEB, 0xE3, 0xE6, 0xD9, 0x00, 0xE3, 0xDA, 0xDA, 0xAD, 0xFF, 0x00, 0xFF, 0xCC, 0xD9, 0xE4, 0xD9, 0xE0, 0xB4, 0xE7, 0x00, 0xD9, 0xDA, 0xDA, 0xD9, 0xD7, 0xE8, 0x00, 0xEB, 0xE3, 0xE6, 0xD9, 0x00, 0xE3, 0xDA, 0xDA, 0xAD, 0xAD, 0xAD, 0xFE, 0xCF, 0xE7, 0xD9, 0x00, 0xD5, 0xE2, 0xE3, 0xE8, 0xDC, 0xD9, 0xE6, 0xAC, 0xFF, 0x00, 0xFF };
        long Repel1 = 0x830CA;
        long Repel2 = 0x83119;
        long Repel2_1 = 0xA19A5;
        long Repel3 = 0xA19F6;
        long Repel4 = 0xA19F8;
        long Repel5 = 0xA19FC;
        long Repel6 = 0xA1A0E;
        long Repel7 = 0xA1A1E;
        long Repel8 = 0xA1A5A;
        long Repel8_1 = 0xA1A68;
        long Repel9 = 0x1BFB66;

        byte[] oRepel1 = {0x0C, 0x4D, 0x28, 0x1C, 0xEB, 0xF7, 0x4B, 0xFA, 0x00, 0x04, 0x00, 0x0C, 0x00, 0x28, 0x14, 0xD0, 0x44, 0x1E, 0x24, 0x04, 0x24, 0x0C, 0x28, 0x1C, 0x21, 0x1C, 0xEB, 0xF7, 0x4E, 0xFA, 0x00, 0x2C, 0x0B, 0xD1, 0x04, 0x48, 0xE6, 0xF7, 0xF9, 0xFC, 0x01, 0x20, 0x07, 0xE0, 0x00, 0x00};
        byte[] oRepel2 = { 0x04 };
        byte[] oRepel3 = { 0x18 };
        byte[] oRepel45 = { 0x0D };
        byte[] oRepel6 = { 0x01, 0x1C, 0x09, 0x06, 0x09, 0x0E };
        byte[] oRepel7 = { 0x07, 0x4A, 0x07, 0x4B, 0x30, 0x1C, 0x02, 0x21, 0x67, 0xF0, 0x23, 0xFA, 0x70, 0xBC, 0x01, 0xBC, 0x00, 0x47, 0x30, 0xAD, 0x03, 0x02, 0xFF, 0xFF, 0x00, 0x00, 0x20, 0x40, 0x00, 0x00, 0x18, 0x1D, 0x02, 0x02, 0xF9, 0xA1, 0x10, 0x08, 0x10 };
        byte[] oRepel8 = { 0x67, 0xF0, 0xB5, 0xF9 };
        byte[] oRepel8_1 = { 0x66, 0xF0, 0xC4, 0xFF };
        byte[] oRepel9 = { 0x00, 0x6E, 0xFB, 0x1B, 0x08, 0x09, 0x03, 0x02, 0xCC, 0xBF, 0xCA, 0xBF, 0xC6, 0xB4, 0xE7, 0x00, 0xD9, 0xDA, 0xDA, 0xD9, 0xD7, 0xE8, 0x00, 0xEB, 0xE3, 0xE6, 0xD9, 0x00, 0xE3, 0xDA, 0xDA, 0xB0 };


        //long RepelS = 0x456640;
        long RepelF = 0x83100;
        long RepelF2 = 0x83103;
        byte[] RepelOff = { 0x08 };
        byte[] RepelFN = { 0x40, 0x66, 0x45, 0x08 }; //0x456640

        //Fixing Tall Grass
        byte[] nGrass = { 0x00, 0x21, 0x00, 0x06, 0x00, 0x0e, 0x02, 0x28, 0x01, 0xd0, 0xd1, 0x28, 0x01, 0xd1, 0x01, 0x20, 0x00, 0xe0, 0x00, 0x20, 0x00, 0x21, 0x70, 0x47, 0x03, 0x28, 0xf5, 0xe7 };
        byte[] nGrass2 = { 0x0C, 0x30, 0x09, 0xE0 };
        long Grass = 0x59f34;
        long Grass2 = 0x5A0EC;

        byte[] oGrass = { 0x00, 0xB5, 0x00, 0x06, 0x00, 0x0E, 0x02, 0x28, 0x01, 0xD0, 0xD1, 0x28, 0x01, 0xD1, 0x01, 0x20, 0x00, 0xE0, 0x00, 0x20, 0x02, 0xBC, 0x08, 0x47, 0x00, 0x20, 0x70, 0x47 };
        byte[] oGrass2 = { 0x00, 0x20, 0x70, 0x47 };


        //Level 1 eggs
        byte[] nEgg1 = { 0x01, 0x21 };
        byte[] nEgg2 = { 0x01, 0x22 };
        byte[] nEgg3 = { 0x01, 0x22 };
        long Egg1 = 0x1C3200;
        long Egg2 = 0x71414;
        long Egg3 = 0x70A38;
        long Egg1f = 0x1375B0;
        long Egg2f = 0x46CBE;
        long Egg3f = 0x4623E;

        byte[] oEgg1 = { 0x05, 0x21 };
        byte[] oEgg2 = { 0x05, 0x22 };

        //Pokedex Fix
        long frDex = 0x10583C;
        long frDex2 = 0x105856;
        long lgDex2 = 0x10582E;
        long lgDex = 0x105814;
        byte[] nDex = { 0xff };
        byte[] oDex = { 0x00 };

        //Mew fix
        long frMew = 0x1D402;
        byte[] nMew = { 0x00 };
        byte[] oMew = { 0x97 };

        //Berry fix
        long eBerry = 0x68FD2;
        byte[] nBerry = { 0x02, 0x29, 0x04, 0xDC };

        //IV fix
        long RSIV = 0x3D89A;
        long FRLGIV = 0x40A92;
        byte[] newIV = { 0x21, 0x68, 0x69, 0x60, 0x20, 0xE0 };
        byte[] oIV = { 0x21, 0x78, 0x1F, 0x24, 0x0A, 0x1C };

        //National Dex Evo
        long NDEvo = 0xCE91A;
        byte[] NDEvoBytes = { 0x00, 0x00, 0x14, 0xE0 };
        byte[] oNDEvo = { 0x97, 0x28, 0x14, 0xDD };

        //Removable HMs
        long EMHM = 0x1b6d14;
        long EMHM2 = 0x6E7CC;
        long FRHM = 0x441D6;
        long FRHM2 = 0x125AA8;
        byte[] HM = { 0x00 };
        byte[] oHM = { 0x01 };

        //OW Poison
        long Poison = 0x06D7C3;
        byte[] PoisonB = { 0xE0 };
        byte[] oPoisonB = { 0xD1 };

        //Dex Seen
        long Seen = 0x00CF56;
        long Seen1 = 0x00CF64;
        long Seen2 = 0x0F803C;
        long Seen3 = 0x0F8044;
        byte[] SeenB = { 0x00, 0x20 };
        byte[] SeenO = { 0x01, 0x20 };

        //Amap fix
        long AMapFix = 0x39fbf8;
        byte[] AMapFixA = { 0xB5, 0xFF, 0x05, 0x08, };
        byte[] AMapFixB = { 0xF1, 0x31, 0x06, 0x08 };
        byte[] AMapFixRemoval = { 0x00, 0x00, 0x00, 0x00 };

        //Birch
        long Birch = 0x308AC;
        long Intro = 0x30872;
        long Background = 0x30882;
        byte[] BirchB = { 0x31, 0x16, 0x03, 0x08 };
        byte[] BackB = { 0x00, 0x00, 0x00, 0x00 };

        //Run Without Flag
        long RFlag = 0x05BA3A;
        byte[] RFlagB = { 0x00, 0x00, 0x00, 0x00 };
        byte[] oRFlagB = { 0x12, 0xF0, 0x49, 0xFE };
        #endregion

        void switch_language()
        {
            if (lanInt == 1)
            {
                cul = CultureInfo.CreateSpecificCulture("en");    //create culture for english
            }
            else if (lanInt == 2)                                           
            {
                cul = CultureInfo.CreateSpecificCulture("fr");     //create culture for french
            }
            else if (lanInt == 3)                                           
            {
                cul = CultureInfo.CreateSpecificCulture("sp");     //create culture for spanish
            }
            else
            {
                cul = CultureInfo.CreateSpecificCulture("en");    //create culture for english
            }
            #region strings
            statusLabel.Text = res_man.GetString("welcome_Status", cul);

            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lanInt = 1;
            MaximizeBox = false;
            tabControl1.Appearance = TabAppearance.FlatButtons; tabControl1.ItemSize = new Size(0, 1); tabControl1.SizeMode = TabSizeMode.Fixed;

            #region Change Language for default text
            res_man = new ResourceManager("HHOHOH.Resources.Res", typeof(Form1).Assembly);
            switch_language();

            #endregion
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
                OpenFileDialog ofd = new OpenFileDialog();
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
                    #endregion
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
                        #endregion

                        #region Running Indoors                       
                        checkBox1.Checked = CheckPatch(oRun, frRun, br, returnValue);
                        #endregion

                        #region FR Pokedex Fix
                        int patchINT = 0;
                        patchINT =+ CheckPatch2(oDex, frDex, br, patchINT);
                        patchINT =+ CheckPatch2(oDex, frDex2, br, patchINT);
                        if (patchINT != 0)
                        {
                            checkBox2.Checked = true;
                        }
                        #endregion

                        #region BW Repel System
                        patchINT = 0;
                        patchINT =+ CheckPatch2(oRepel1, Repel1, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel2, Repel2, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel3, Repel3, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel45, Repel4, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel45, Repel5, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel6, Repel6, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel7, Repel7, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel8, Repel8, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel9, Repel9, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel2, Repel2_1, br, patchINT);
                        patchINT =+ CheckPatch2(oRepel8_1, Repel8_1, br, patchINT);
                        if (patchINT != 0)
                        {
                            checkBox7.Checked = true;
                        }
                        #endregion

                        #region Flashback                     
                        checkBox6.Checked = CheckPatch(oFlash, frFlash, br, returnValue);
                        #endregion

                        #region Tall Grass
                        patchINT = 0;
                        patchINT =+ CheckPatch2(oGrass, Grass, br, patchINT);
                        patchINT =+ CheckPatch2(oGrass2, Grass2, br, patchINT);
                        if (patchINT != 0)
                        {
                            checkBox3.Checked = true;
                        }
                        #endregion

                        #region Forced Mew
                        checkBox8.Checked = CheckPatch(oMew, frMew, br, returnValue);
                        #endregion

                        #region Level 1 Babies
                        patchINT = 0;
                        patchINT =+ CheckPatch2(oEgg1, Egg1f, br, patchINT);
                        patchINT =+ CheckPatch2(oEgg2, Egg2f, br, patchINT);
                        patchINT =+ CheckPatch2(oEgg2, Egg3f, br, patchINT);
                        if (patchINT != 0)
                        {
                            checkBox4.Checked = true;
                        }
                        #endregion

                        #region Legendary IV fix
                        checkBox9.Checked = CheckPatch(oIV, FRLGIV, br, returnValue);
                        #endregion

                        #region Deletable HMS
                        patchINT = 0;
                        patchINT =+ CheckPatch2(oHM, FRHM, br, patchINT);
                        patchINT =+ CheckPatch2(oHM, FRHM2, br, patchINT);
                        if (patchINT != 0)
                        {
                            checkBox5.Checked = true;
                        }
                        #endregion

                        #region Evo Without Nat Dex
                        checkBox11.Checked = CheckPatch(oNDEvo, NDEvo, br, returnValue);
                        #endregion

                        #region Seen instead of caught
                        patchINT = 0;
                        patchINT =+ CheckPatch2(SeenO, Seen, br, patchINT);
                        patchINT =+ CheckPatch2(SeenO, Seen1, br, patchINT);
                        patchINT =+ CheckPatch2(SeenO, Seen2, br, patchINT);
                        patchINT =+ CheckPatch2(SeenO, Seen3, br, patchINT);
                        if (patchINT != 0)
                        {
                            checkBox12.Checked = true;
                        }
                        #endregion

                        #region No Flag running shoes
                        checkBox10.Checked = CheckPatch(oRFlagB, RFlag, br, returnValue);
                        #endregion

                        #region No OW Poison
                        checkBox13.Checked = CheckPatch(oPoisonB, Poison, br, returnValue);
                        #endregion

                        #region Fix A-Map
                        checkBox14.Checked = CheckPatch(AMapFixRemoval, AMapFix, br, returnValue);
                        #endregion

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
                    #endregion

                    #region Change ROM Information
                    toolStripStatusLabel3.Text = "Fire Red BPRE";
                    #endregion
                    #endregion
                }
                    if (LeafGreen == true)
                    {
                        tabControl1.SelectedTab = lgTab;
                    }
                    if (other == true)
                    {
                        tabControl1.SelectedTab = frTab;
                    }
                    if (Emerald == true)
                    {
                        tabControl1.SelectedTab = eTab;
                    }
                    if (Ruby == true)
                    {
                        tabControl1.SelectedTab = rTab;
                    }
                    if (Sapphire == true)
                    {
                        tabControl1.SelectedTab = sTab;
                    }
                    fileLocation = ofd.FileName;
                    //Form1.Size = (363, 462);
                    OpenROM = true;
                    br.Close();

                    #endregion
                }
                #endregion
            
        }

        private void undo_Click(object sender, EventArgs e)
        {

        }


        #region Functions
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

        private void WriteData(byte[] BytesToWrite, long Offset)
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

            }
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

        public static byte[] GetStringToBytes(string value)
        {
            SoapHexBinary shb = SoapHexBinary.Parse(value);
            return shb.Value;
        }

        public static string GetBytesToString(byte[] value)
        {
            SoapHexBinary shb = new SoapHexBinary(value);
            return shb.ToString();
        }
        #endregion

        #region Fire Red CheckBoxes
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = dvTab;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = frTab;
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
            #endregion
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            #region Apply BW Repel System
            if (checkBox7.Checked == true)
            {
                DialogResult result = MessageBox.Show("This hack is for FireRed v1 only, and uses the freespace for around 0x80 bytes. If you have used this space it will overwrite it and delete your data which could result in corruption or a bad script. Click yes if you understand the risks.", "Notice", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Please enter a location of free space 0x80 bytes in length.Leave out '0x'.", "FreeSpace", "efff00", 0, 0);
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
                        #endregion

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
                        statusLabel.Text = "BW Repel System Added";
                    }
                    catch
                    {
                        MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                    }
                }
            }
            #endregion
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
                statusLabel.Text = "BW Repel System Removed";
            }
            #endregion
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            #region Remove/Add Flash FR
            if (checkBox6.Checked == true)
            {
                try
                {
                    WriteData(nFlash, frFlash); ;  //stuff here for file writing
                    statusLabel.Text = "Flashbacks have been removed";
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
                    statusLabel.Text = "Flashbacks have been added";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            #region Add/Remove Indoor Running
            if (checkBox1.Checked == true)
            {
                try
                {
                    WriteData(nRun, frRun); ;  //stuff here for file writing
                    statusLabel.Text = "Running indoors Added";
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
                    statusLabel.Text = "Running indoors removed";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
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
                    statusLabel.Text = "Fire Red Dex Fix has been added";
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
                    statusLabel.Text = "Fire Red Dex Fix has been removed";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
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
                    statusLabel.Text = "Tall Grass fix has been added";
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
                    statusLabel.Text = "Tall Grass fix has been removed";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            #region Force Mew Obey
            if (checkBox8.Checked == true)
            {
                try
                {
                    WriteData(nMew, frMew);  //stuff here for file writing
                    statusLabel.Text = "Forced Mew obey added";
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
                    statusLabel.Text = "Forced Mew obey removed";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
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
                    statusLabel.Text = "Eggs hatch at level 1";
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
                    statusLabel.Text = "Eggs hatch at level 5";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            #region Fix Legend IVs
            if (checkBox9.Checked == true)
            {
                try
                {
                    WriteData(newIV, FRLGIV);  //stuff here for file writing
                    statusLabel.Text = "Added fix for legendary IV RNG";
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
                    statusLabel.Text = "Removed fix for legendary IV RNG";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
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
                    statusLabel.Text = "HMs are deletable";
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
                    statusLabel.Text = "HMs cannot be deleted";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            #region Evolve Pokemon without National Dex
            if (checkBox11.Checked == true)
            {
                try
                {
                    WriteData(NDEvoBytes, NDEvo);  //stuff here for file writing
                    statusLabel.Text = "Evolve Pokemon without national dex";
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
                    statusLabel.Text = "National dex required for evolving";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
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
                    statusLabel.Text = "Seen Pokemon now displayed in menu";
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
                    statusLabel.Text = "Caught Pokemon now displayed in menu";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            #region Run without flag
            if (checkBox10.Checked == true)
            {
                try
                {
                    WriteData(RFlagB, RFlag);  //stuff here for file writing
                    statusLabel.Text = "Removed flag check for running";
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
                    statusLabel.Text = "Added flag check for running";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void frTab_Click(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            #region Disable Overworld Poison
            if (checkBox13.Checked == true)
            {
                try
                {
                    WriteData(PoisonB, Poison);  //stuff here for file writing
                    statusLabel.Text = "Poison won't work in OW";
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
                    statusLabel.Text = "Poison works like normal";
                }
                catch
                {
                    MessageBox.Show("Failed! Please make sure that there is no other program with your ROM opened.");//Put messages here if you want...
                }
            }
            #endregion
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            #region Fix A-Map FaceDown crash
            if (checkBox14.Checked == true)
            {
                try
                {
                    WriteData(AMapFixA, AMapFix);
                    statusLabel.Text = "A-Map crash fixed";
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
                        statusLabel.Text = "A-Map crash added back in";
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
            #endregion

        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            TextSpeed.SelectedIndex = 1;
            Frame.SelectedIndex = 0;
            Sound.SelectedIndex = 1;
            BattleScene.SelectedIndex = 0;
            BattleStyle.SelectedIndex = 0;
            BTNMode.SelectedIndex = 0;
        }

        private void TextSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debuggingMode = true;
            oFFToolStripMenuItem.Text = "off";
            oNToolStripMenuItem.Text = "-ON-";

        }

        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debuggingMode = false;
            oFFToolStripMenuItem.Text = "-OFF-";
            oNToolStripMenuItem.Text = "on";
        }

        private void reopenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 1;
            switch_language();
        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 2;
            switch_language();
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lanInt = 3;
            switch_language();
        }
    }
}
