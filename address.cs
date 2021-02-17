using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VroomMachine
{
    class address
    {
        public static long baseadd = 0;
        public static Int64 StC;
        public static Int64 StC2;
        public static Int64 timescale;
        public static Int64 ZMIgnore;
        public static Int64 ZMLeft;

        public static Int64 PlayerBasePtr;
        public static Int64 PlayerPedPtr;
        public static Int64 ZMGlobalBase;
        public static Int64 ZMBotBase;
        public static Int64 ZMBotListBase;

        public static Int64 jumpheight;

        //Player 1
        public static Int64 name;
        public static Int64 clantag;
        public static Int64 money;
        public static Int64 IR;
        public static Int64 cords;
        public static Int64 cordsy;
        public static Int64 cordsz;

        public static Int64 p1green;
        public static Int64 p1blue;

        public static Int64 xpos;
        public static Int64 ypos;
        public static Int64 zpos;

        public static Int64 hithealth;
        public static Int64 maxhithealth;
        public static Int64 nohithealth;
        public static Int64 speed;

        public static Int64 displaycurrentweapon;
        public static Int64 setweapon;
        public static Int64 setweapon2;
        public static Int64 setweapon3;
        public static Int64 setweapon4;
        public static Int64 setweapon5;
        public static Int64 setweapon6;
        public static Int64 confirmslot1;
        public static Int64 confirmslot2;

        public static Int64 rapidfire1;
        public static Int64 rapidfire2;
        public static Int64 ammo;
        public static Int64 ammo1;
        public static Int64 maxammo1;
        public static Int64 ammo2;
        public static Int64 maxammo2;
        public static Int64 ammo3;
        public static Int64 maxammo3;
        public static Int64 ammo4;
        public static Int64 maxammo4;
        public static Int64 ammo5;
        public static Int64 maxammo5;

        public static Int64 RapidFieldUpgrade;

        public static Int64 perk1;
        public static Int64 perk2;
        public static Int64 perk3;
        public static Int64 perk4;
        public static Int64 perk5;
        public static Int64 perk6;
        public static Int64 perk7;
        public static Int64 perk8;
        public static Int64 perk9;

        //Player 2
        public static Int64 p2name;
        public static Int64 p2clantag;
        public static Int64 p2money;
        public static Int64 p2IR;

        public static Int64 p2green;
        public static Int64 p2blue;

        public static Int64 p2cords;
        public static Int64 p2cordsy;
        public static Int64 p2cordsz;

        public static Int64 p2xpos;
        public static Int64 p2ypos;
        public static Int64 p2zpos;

        public static Int64 p2hithealth;
        public static Int64 p2maxhithealth;
        public static Int64 p2nohithealth;
        public static Int64 p2speed;

        public static Int64 p2displaycurrentweapon;
        public static Int64 p2setweapon;
        public static Int64 p2setweapon2;
        public static Int64 p2setweapon3;
        public static Int64 p2setweapon4;
        public static Int64 p2setweapon5;
        public static Int64 p2setweapon6;
        public static Int64 p2confirmslot1;
        public static Int64 p2confirmslot2;

        public static Int64 p2rapidfire1;
        public static Int64 p2rapidfire2;
        public static Int64 p2ammo1;
        public static Int64 p2ammo2;
        public static Int64 p2ammo3;
        public static Int64 p2ammo4;
        public static Int64 p2ammo5;

        public static Int64 p2RapidFieldUpgrade;

        public static Int64 p2perk1;
        public static Int64 p2perk2;
        public static Int64 p2perk3;
        public static Int64 p2perk4;
        public static Int64 p2perk5;
        public static Int64 p2perk6;
        public static Int64 p2perk7;
        public static Int64 p2perk8;
        public static Int64 p2perk9;

        //Player 3
        public static Int64 p3name;
        public static Int64 p3clantag;
        public static Int64 p3money;
        public static Int64 p3IR;
        public static Int64 p3cords;
        public static Int64 p3cordsy;
        public static Int64 p3cordsz;

        public static Int64 p3green;
        public static Int64 p3blue;

        public static Int64 p3xpos;
        public static Int64 p3ypos;
        public static Int64 p3zpos;

        public static Int64 p3hithealth;
        public static Int64 p3maxhithealth;
        public static Int64 p3nohithealth;
        public static Int64 p3speed;

        public static Int64 p3displaycurrentweapon;
        public static Int64 p3setweapon;
        public static Int64 p3setweapon2;
        public static Int64 p3setweapon3;
        public static Int64 p3setweapon4;
        public static Int64 p3setweapon5;
        public static Int64 p3setweapon6;
        public static Int64 p3confirmslot1;
        public static Int64 p3confirmslot2;

        public static Int64 p3rapidfire1;
        public static Int64 p3rapidfire2;
        public static Int64 p3ammo1;
        public static Int64 p3ammo2;
        public static Int64 p3ammo3;
        public static Int64 p3ammo4;
        public static Int64 p3ammo5;

        public static Int64 p3RapidFieldUpgrade;

        public static Int64 p3perk1;
        public static Int64 p3perk2;
        public static Int64 p3perk3;
        public static Int64 p3perk4;
        public static Int64 p3perk5;
        public static Int64 p3perk6;
        public static Int64 p3perk7;
        public static Int64 p3perk8;
        public static Int64 p3perk9;

        //Player 4
        public static Int64 p4name;
        public static Int64 p4clantag;
        public static Int64 p4money;
        public static Int64 p4IR;
        public static Int64 p4cords;
        public static Int64 p4cordsy;
        public static Int64 p4cordsz;

        public static Int64 p4green;
        public static Int64 p4blue;

        public static Int64 p4xpos;
        public static Int64 p4ypos;
        public static Int64 p4zpos;

        public static Int64 p4hithealth;
        public static Int64 p4maxhithealth;
        public static Int64 p4nohithealth;
        public static Int64 p4speed;

        public static Int64 p4displaycurrentweapon;
        public static Int64 p4setweapon;
        public static Int64 p4setweapon2;
        public static Int64 p4setweapon3;
        public static Int64 p4setweapon4;
        public static Int64 p4setweapon5;
        public static Int64 p4setweapon6;
        public static Int64 p4confirmslot1;
        public static Int64 p4confirmslot2;

        public static Int64 p4rapidfire1;
        public static Int64 p4rapidfire2;
        public static Int64 p4ammo1;
        public static Int64 p4ammo2;
        public static Int64 p4ammo3;
        public static Int64 p4ammo4;
        public static Int64 p4ammo5;

        public static Int64 p4RapidFieldUpgrade;

        public static Int64 p4perk1;
        public static Int64 p4perk2;
        public static Int64 p4perk3;
        public static Int64 p4perk4;
        public static Int64 p4perk5;
        public static Int64 p4perk6;
        public static Int64 p4perk7;
        public static Int64 p4perk8;
        public static Int64 p4perk9;

        //Uh..? 
        //public static Int64 range1;
        //public static Int64 range2;

        //XP
        public static Int64 XPMulti1;
        public static Int64 XPMulti2;
        public static Int64 XPMulti3;

        //public static Int64 zhealth;
        public static Int64 zhealth1;
        public static Int64 zhealth2;
        public static Int64 zhealth3;
        public static Int64 zhealth4;
        public static Int64 zhealth5;
        public static Int64 zhealth6;
        public static Int64 zhealth7;
        public static Int64 zhealth8;
        public static Int64 zhealth9;
        public static Int64 zhealth10;
        public static Int64 zhealth11;
        public static Int64 zhealth12;
        public static Int64 zhealth13;
        public static Int64 zhealth14;
        public static Int64 zhealth15;
        public static Int64 zhealth16;
        public static Int64 zhealth17;
        public static Int64 zhealth18;
        public static Int64 zhealth19;
        public static Int64 zhealth20;
        public static Int64 zhealth21;
        public static Int64 zhealth22;
        public static Int64 zhealth23;
        public static Int64 zhealth24;
        public static Int64 zhealth25;
        public static Int64 zhealth26;
        public static Int64 zhealth27;
        public static Int64 zhealth28;
        public static Int64 zhealth29;
        public static Int64 zhealth30;
        public static Int64 zhealth31;
        public static Int64 zhealth32;
        public static Int64 zhealth33;
        public static Int64 zhealth34;
        public static Int64 zhealth35;

        public static Int64 pmatch;
        public static Int64 cmatch;
        public static Int64 uiid;
        public static Int64 playlistid;



        public static long[] X_z = new long[40];
        public static long[] Y_z = new long[40];
        public static long[] Z_z = new long[40];
        public static long[] vz = new long[40];

        //===================++++++++++++++++++===================\\

        // Bases [Gameversion: 1.8.2.8521522 Only works as HOST/Lobby-Leader

        public static long PlayerBase = 0x10A97348;
        public static Int64 JumpHeightBase = 0x10B8E008;
        public static Int64 XPScaleBase = 0x10AC8BC0; // Use them results in Instand Ban!!! but try :P | So: Use at own Risk!
        public static Int64 CMDBufferBase = 0x12469150; // there are much more stuff at this Base ;-)! The Offset was stable for about 3 patches so this reagion is a BIG one with many things have fun!
        public static Int64 TimeScaleBase = 0xFB557DC; // Got XOR Obfusicated. Simple ^ or << >> parse and done :P they only waste Double Memory Usage with this...


        // Cache Addresses from PlayerBase (more at yourthread-code)
        //public UInt64 PlayerCompPtr, PlayerPedPtr, ZMGlobalBase, ZMBotBase, ZMBotListBase; // Used to Cache the Pointers at the PlayerBase by his Offsets (more infos at the yourthread() script)

        // Offsets
        // PlayerCompPtr - Offsets
        public static int PC_ArraySize_Offset = 0xB900; // Size of Array between Players Data [IDK if it got changed with 1.7.1 if it got changed, please post the new Offset, i will update them here. dont have the time to check it self]
        public static int CurrentUsedWeaponID = 0x28; // Shows Current Used WeaponID (this are only Readable IDs, so change is not working with them on me)
        public static int SetWeaponID = 0xB0; // +(1-5 * 0x40 for WP2 to WP6) Can be used to change a WeaponID correctly from ID 1-300 (! info !, some IDs can result in GameCrashes!).
        public static int InfraredVision = 0xE66; // (byte) On=0x10|Off=0x0
        public static int GodMode = 0xE67; // (byte) On=0xA0|Off=0x20
        public static int RapidFire1 = 0xE6C; // Freeze to 0 how long you press Left Mouse-Key or Reloading and other stuff is not working.
        public static int RapidFire2 = 0xE80; // Freeze to 0 how long you press Left Mouse-Key or Reloading and other stuff is not working.
        public static int MaxAmmo = 0x1360; // +(1-5 * 0x8 for WP1 to WP6) (WP0 Mostly used in MP, ZM first WP is WP1 | WP3-6 Mostly used for Granades and Special) The Game assign the next Free WP Slot so WP1 is MainWeapon, you get a granade, then WP2 is the Granade, you buy a Weapon from wall then this is WP3 and so on..
        public static int Ammo = 0x13D4; // +(1-5 * 0x4 for WP1 to WP6) (WP0 Mostly used in MP, ZM first WP is WP1 | WP3-6 Mostly used for Granades and Special)
        public static int Points = 0x5D04; // ZM Points / Money
        public static int Name = 0x603C; // Playername
        public static int RunSpeed = 0x5C50; // (float)
        public static int ClanTags = 0x605C; // Player Clan/Crew-Tag

        public static int RapidFieldUpgrade_Offset = 0xF24;

        public static int Perk1Base = 0x10CC; // have nothing to do with crit
        public static int Perk2Base = 0x10D2; // have nothing to do with crit
        public static int Perk3Base = 0x10E4; // have nothing to do with crit
        public static int Perk4Base = 0x10E8; // have nothing to do with crit
        public static int Perk5Base = 0x10C4; // have nothing to do with crit
        public static int Perk6Base = 0x10C8; // have nothing to do with crit
        public static int Perk7Base = 0x10D4; // have nothing to do with crit
        public static int Perk8Base = 0x10D6; // yes its crit BUT

        // PlayerPedPtr - Offsets
        public static int PP_ArraySize_Offset = 0x5F8; // ArraySize to next Player.
        public static int Health = 0x398;
        public static int MaxHealth = 0x39C; // Max Health dont increase by using Perk Juggernog
        public static int Coords = 0x2D4; // Vector3
        public static int Heading_Z = 0x34; // float
        public static int Heading_XY = 0x38; // float | can be used to TP Zombies in front of you by your Heading Position and Forward Distance.

        // ZMGlobalBase - Offsets
        public static int ZM_Global_MovedOffset = 0x0; //  ZMGlobalBase + ZM_Global_MovedOffset + ZM_Global_ZombiesIgnoreAll is the corretly Offset to ZombiesIgnoreAll
        public static int ZM_Global_ZombiesIgnoreAll = 0x14; // Zombies Ignore any Player in the Lobby.
        public static int ZM_Global_ZMLeftCount = 0x3C; // Zombies Left

        // ZMBotBase - Offsets
        public static int ZM_Bot_List_Offset = 0x8; // Offset to Pointer at ZMBotBase + 0x8 -> ZMBotListBase

        // ZMBotListBase - Offsets
        public static int ZM_Bot_ArraySize_Offset = 0x5F8; // ArraySize to next Zombie.
        public static int ZM_Bot_Health = 0x398;
        public static int ZM_Bot_MaxHealth = 0x39C;
        public static int ZM_Bot_Coords = 0x2D4; // Cam be used to Teleport all Zombies in front of any Player with a Heading Variable from the Players.


        // CMDBufferBase - Offsets
        public static int CMDBB_Exec = -0x1B;

        public static void setadd()
        {

            memory m = new memory();

            try
            {
                baseadd = memory.GetBaseAddress("BlackOpsColdWar").ToInt64();
                m.AttackProcess("BlackOpsColdWar");

            }

            catch (Exception)
            {

            }


            /*memory m = new memory();
            baseadd = memory.GetBaseAddress("BlackOpsColdWar").ToInt64();
            m.AttackProcess("BlackOpsColdWar");*/

            StC = CMDBufferBase;
            StC2 = StC + CMDBB_Exec; //they work i think
            timescale = TimeScaleBase;
            jumpheight = JumpHeightBase; // All Clients

            PlayerBasePtr = m.GetPointerInt(baseadd + PlayerBase, new long[] { 0x0 }, 1);   //PlayerBase
            PlayerPedPtr = m.GetPointerInt(baseadd + PlayerBase, new long[] { 0x8 }, 1);    //Always 0x8 from PlayerBase
            ZMGlobalBase = m.GetPointerInt(baseadd + PlayerBase, new long[] { 0x60 }, 1);    //Always 0x60 from PlayerBase
            ZMBotBase = m.GetPointerInt(baseadd + PlayerBase, new long[] { 0x68 }, 1);       //Always 0x68 from PlayerBase
            ZMBotListBase = ZMBotBase + 0x8;                                                //Always 0x8 from ZMBotBase

            ZMIgnore = ZMGlobalBase + ZM_Global_ZombiesIgnoreAll;
            ZMLeft = ZMGlobalBase + ZM_Global_ZMLeftCount;

            #region Player 1
            //Player 1
            name = PlayerBasePtr + Name;
            clantag = PlayerBasePtr + ClanTags;
            money = m.GetPointerInt(baseadd + PlayerBase, new long[] { Points }, 1); // Always D24
            IR = m.GetPointerInt(baseadd + PlayerBase, new long[] { InfraredVision }, 1); 
            
            //givechopper = m.GetPointerInt(baseadd + PlayerBase, new long[] { 0x50 }, 1);
            //givechopper1 = m.GetPointerInt(baseadd + PlayerBase, new long[] { 0x170 }, 1);
            //givechopper2 = m.GetPointerInt(baseadd + PlayerBase, new long[] { 0x1F0 }, 1);

            hithealth = m.GetPointerInt(baseadd + PlayerBase + 0x8, new long[] { Health }, 1);  // Always 3D8
            maxhithealth = PlayerPedPtr + MaxHealth;
            nohithealth = m.GetPointerInt(baseadd + PlayerBase, new long[] { GodMode }, 1); // In-game 2000000 in HEX or 536870912 in DECIMAL | (byte) On=0xA0|Off=0x20
            speed = m.GetPointerInt(baseadd + PlayerBase, new long[] { RunSpeed }, 1);

            p1green = p2green - PC_ArraySize_Offset;
            p1blue = p2blue - PC_ArraySize_Offset;

            displaycurrentweapon = m.GetPointerInt(baseadd + PlayerBase, new long[] { CurrentUsedWeaponID }, 1);
            setweapon = PlayerBasePtr + SetWeaponID;
            setweapon2 = PlayerBasePtr + SetWeaponID + 0x40;
            setweapon3 = PlayerBasePtr + SetWeaponID + 0x80;
            setweapon4 = PlayerBasePtr + SetWeaponID + 0xC0;
            setweapon5 = PlayerBasePtr + SetWeaponID + 0x100;
            setweapon6 = PlayerBasePtr + SetWeaponID + 0x140;

            rapidfire1 = m.GetPointerInt(baseadd + PlayerBase, new long[] { RapidFire1 }, 1);
            rapidfire2 = m.GetPointerInt(baseadd + PlayerBase, new long[] { RapidFire2 }, 1);
            ammo = money - 0x490C;
            ammo1 = m.GetPointerInt(baseadd + PlayerBase, new long[] { Ammo + 0x4 }, 1); //First that ends with 418 address
            maxammo1 = m.GetPointerInt(baseadd + PlayerBase, new long[] { MaxAmmo + 0x8 }, 1);
            ammo2 = ammo1 + 0x4; //Second that end with 41C address
            maxammo2 = maxammo1 + 0x8;
            ammo3 = ammo2 + 0x4; //Third that end with 420 address
            maxammo3 = maxammo2 + 0x8;
            ammo4 = ammo3 + 0x4; //Third that end with 420 address
            maxammo4 = maxammo3 + 0x8;
            ammo5 = ammo4 + 0x4; //Third that end with 420 address
            maxammo5 = maxammo4 + 0x8;

            RapidFieldUpgrade = PlayerBasePtr + RapidFieldUpgrade_Offset;
            //RapidFieldUpgrade = m.GetPointerInt(baseadd + 0x10AA0BC8, new long[] { 0xF24 }, 1);

            perk1 = PlayerBasePtr + Perk1Base;
            perk2 = PlayerBasePtr + Perk2Base;
            perk3 = PlayerBasePtr + Perk3Base;
            perk4 = PlayerBasePtr + Perk4Base;
            perk5 = PlayerBasePtr + Perk5Base;
            perk6 = PlayerBasePtr + Perk6Base;
            perk7 = PlayerBasePtr + Perk7Base;
            perk8 = PlayerBasePtr + Perk8Base; //All Headshots + 4 other things

            cords = PlayerPedPtr + Coords;
            cordsy = PlayerPedPtr + Coords + 0x4;
            cordsz = PlayerPedPtr + Coords + 0x8;

            //P1 X,Y,Z
            xpos = ammo1 - 0x5F0;
            ypos = xpos + 0x4;
            zpos = xpos + 0x8;
            #endregion


            #region Player 2
            //Player 2
            p2name = name + PC_ArraySize_Offset;
            p2clantag = clantag + PC_ArraySize_Offset;
            p2money = money + PC_ArraySize_Offset;
            p2IR = IR + PC_ArraySize_Offset;

            p2green = p2name + 0x13E;
            p2blue = p2name + 0x592;

            p2hithealth = hithealth + PP_ArraySize_Offset;
            p2maxhithealth = maxhithealth + PP_ArraySize_Offset;
            p2nohithealth = nohithealth + PC_ArraySize_Offset; // In-game 2000000 in HEX or 536870912 in DECIMAL | (byte) On=0xA0|Off=0x20
            p2speed = speed + PC_ArraySize_Offset;

            p2displaycurrentweapon = displaycurrentweapon + PC_ArraySize_Offset;
            p2setweapon = setweapon + PC_ArraySize_Offset;
            p2setweapon2 = setweapon2 + PC_ArraySize_Offset;
            p2setweapon3 = setweapon3 + PC_ArraySize_Offset;
            p2setweapon4 = setweapon4 + PC_ArraySize_Offset;
            p2setweapon5 = setweapon5 + PC_ArraySize_Offset;
            p2setweapon6 = setweapon6 + PC_ArraySize_Offset;
            p2confirmslot1 = confirmslot1 + PC_ArraySize_Offset;
            p2confirmslot2 = confirmslot2 + PC_ArraySize_Offset;

            p2rapidfire1 = rapidfire1 + PC_ArraySize_Offset;
            p2rapidfire2 = rapidfire2 + PC_ArraySize_Offset;
            p2ammo1 = ammo1 + PC_ArraySize_Offset;
            p2ammo2 = ammo2 + PC_ArraySize_Offset;
            p2ammo3 = ammo3 + PC_ArraySize_Offset;
            p2ammo4 = ammo4 + PC_ArraySize_Offset;
            p2ammo5 = ammo5 + PC_ArraySize_Offset;

            p2RapidFieldUpgrade = RapidFieldUpgrade + PC_ArraySize_Offset;

            p2perk1 = perk1 + PC_ArraySize_Offset;
            p2perk2 = perk2 + PC_ArraySize_Offset;
            p2perk3 = perk3 + PC_ArraySize_Offset;
            p2perk4 = perk4 + PC_ArraySize_Offset;
            p2perk5 = perk5 + PC_ArraySize_Offset;
            p2perk6 = perk6 + PC_ArraySize_Offset;
            p2perk7 = perk7 + PC_ArraySize_Offset;
            p2perk8 = perk8 + PC_ArraySize_Offset;

            p2cords = cords + PP_ArraySize_Offset;
            p2cordsy = cordsy + PP_ArraySize_Offset;
            p2cordsz = cordsz + PP_ArraySize_Offset;

            p2xpos = xpos + PC_ArraySize_Offset;
            p2ypos = p2xpos + 0x4;
            p2zpos = p2xpos + 0x8;
            #endregion


            #region Player 3
            //Player 3
            p3name = p2name + PC_ArraySize_Offset;
            p3clantag = p2clantag + PC_ArraySize_Offset;
            p3money = p2money + PC_ArraySize_Offset;
            p3IR = p2IR + PC_ArraySize_Offset;

            p3green = p2green + PC_ArraySize_Offset;
            p3blue = p2blue + PC_ArraySize_Offset;

            p3hithealth = p2hithealth + PP_ArraySize_Offset;
            p3maxhithealth = p2maxhithealth + PP_ArraySize_Offset;
            p3nohithealth = p2nohithealth + PC_ArraySize_Offset; // In-game 2000000 in HEX or 536870912 in DECIMAL | (byte) On=0xA0|Off=0x20
            p3speed = p2speed + PC_ArraySize_Offset;

            p3displaycurrentweapon = p2displaycurrentweapon + PC_ArraySize_Offset;
            p3setweapon = p2setweapon + PC_ArraySize_Offset;
            p3setweapon2 = p2setweapon2 + PC_ArraySize_Offset;
            p3setweapon3 = p2setweapon3 + PC_ArraySize_Offset;
            p3setweapon4 = p2setweapon4 + PC_ArraySize_Offset;
            p3setweapon5 = p2setweapon5 + PC_ArraySize_Offset;
            p3setweapon6 = p2setweapon6 + PC_ArraySize_Offset;
            p3confirmslot1 = p2confirmslot1 + PC_ArraySize_Offset;
            p3confirmslot2 = p2confirmslot2 + PC_ArraySize_Offset;

            p3rapidfire1 = p2rapidfire1 + PC_ArraySize_Offset;
            p3rapidfire2 = p2rapidfire2 + PC_ArraySize_Offset;
            p3ammo1 = p2ammo1 + PC_ArraySize_Offset;
            p3ammo2 = p2ammo2 + PC_ArraySize_Offset;
            p3ammo3 = p2ammo3 + PC_ArraySize_Offset;
            p3ammo4 = p2ammo4 + PC_ArraySize_Offset;
            p3ammo5 = p2ammo5 + PC_ArraySize_Offset;

            p3RapidFieldUpgrade = p2RapidFieldUpgrade + PC_ArraySize_Offset;

            p3perk1 = p2perk1 + PC_ArraySize_Offset;
            p3perk2 = p2perk2 + PC_ArraySize_Offset;
            p3perk3 = p2perk3 + PC_ArraySize_Offset;
            p3perk4 = p2perk4 + PC_ArraySize_Offset;
            p3perk5 = p2perk5 + PC_ArraySize_Offset;
            p3perk6 = p2perk6 + PC_ArraySize_Offset;
            p3perk7 = p2perk7 + PC_ArraySize_Offset;
            p3perk8 = p2perk8 + PC_ArraySize_Offset;

            p3cords = p2cords + PP_ArraySize_Offset;
            p3cordsy = p2cordsy + PP_ArraySize_Offset;
            p3cordsz = p2cordsz + PP_ArraySize_Offset;

            p3xpos = p2xpos + PC_ArraySize_Offset;
            p3ypos = p3xpos + 0x4;
            p3zpos = p3xpos + 0x8;
            #endregion


            #region Player 4
            //Player 4
            p4name = p3name + PC_ArraySize_Offset;
            p4clantag = p3clantag + PC_ArraySize_Offset;
            p4money = p3money + PC_ArraySize_Offset;
            p4IR = p3IR + PC_ArraySize_Offset;

            p4green = p3green + PC_ArraySize_Offset;
            p4blue = p3blue + PC_ArraySize_Offset;

            p4hithealth = p3hithealth + PP_ArraySize_Offset;
            p4maxhithealth = p3maxhithealth + PP_ArraySize_Offset;
            p4nohithealth = p3nohithealth + PC_ArraySize_Offset; // In-game 2000000 in HEX or 536870912 in DECIMAL | (byte) On=0xA0|Off=0x20
            p4speed = p3speed + PC_ArraySize_Offset;

            p4displaycurrentweapon = p3displaycurrentweapon + PC_ArraySize_Offset;
            p4setweapon = p3setweapon + PC_ArraySize_Offset;
            p4setweapon2 = p3setweapon2 + PC_ArraySize_Offset;
            p4setweapon3 = p3setweapon3 + PC_ArraySize_Offset;
            p4setweapon4 = p3setweapon4 + PC_ArraySize_Offset;
            p4setweapon5 = p3setweapon5 + PC_ArraySize_Offset;
            p4setweapon6 = p3setweapon6 + PC_ArraySize_Offset;
            p4confirmslot1 = p3confirmslot1 + PC_ArraySize_Offset;
            p4confirmslot2 = p3confirmslot2 + PC_ArraySize_Offset;

            p4rapidfire1 = p3rapidfire1 + PC_ArraySize_Offset;
            p4rapidfire2 = p3rapidfire2 + PC_ArraySize_Offset;
            p4ammo1 = p3ammo1 + PC_ArraySize_Offset;
            p4ammo2 = p3ammo2 + PC_ArraySize_Offset;
            p4ammo3 = p3ammo3 + PC_ArraySize_Offset;
            p4ammo4 = p3ammo4 + PC_ArraySize_Offset;
            p4ammo5 = p3ammo5 + PC_ArraySize_Offset;

            p4RapidFieldUpgrade = p3RapidFieldUpgrade + PC_ArraySize_Offset;

            p4perk1 = p3perk1 + PC_ArraySize_Offset;
            p4perk2 = p3perk2 + PC_ArraySize_Offset;
            p4perk3 = p3perk3 + PC_ArraySize_Offset;
            p4perk4 = p3perk4 + PC_ArraySize_Offset;
            p4perk5 = p3perk5 + PC_ArraySize_Offset;
            p4perk6 = p3perk6 + PC_ArraySize_Offset;
            p4perk7 = p3perk7 + PC_ArraySize_Offset;
            p4perk8 = p3perk8 + PC_ArraySize_Offset;

            p4cords = p3cords + PP_ArraySize_Offset;
            p4cordsy = p3cordsy + PP_ArraySize_Offset;
            p4cordsz = p3cordsz + PP_ArraySize_Offset;

            p4xpos = p3xpos + PC_ArraySize_Offset;
            p4ypos = p4xpos + 0x4;
            p4zpos = p4xpos + 0x8;
            #endregion


            #region XP Pointers
            //XP = m.FindPattern(range1, range2, "\xF3\x0F\x10\x0D\x00\x00\x00\x00\x8B\xCB\xE8\x00\x00\x00\x00\x48\xB8\x00\x00\x00\x00\x00\x00\x00\x00\x48\x8D\x55\xF0", "xxxx????xxx????xx????????xxxx");

            //Scan for Array of byte = "F3 0F 10 0D ? ? ? ? 8B CB E8 ? ? ? ? 48 B8 ? ? ? ? ? ? ? ? 48 8D 55 F0"
            //XP Stuff
            //XPMulti1 = baseadd + 0xFD2E560;
            //XPMulti2 = XPMulti1 + 0x8;
            //XPMulti3 = XPMulti2 + 0x8;
            #endregion


            #region Zombie Teleports
            //zhealth = m.GetPointerInt(baseadd + 0x0F3F2A20, new long[] { 0x398 }, 1); //
            zhealth1 = hithealth + 0x331B8; // 331B8 Distance From My Health > Zombies Health
            //zhealth1 = ZMBotListBase;
            zhealth2 = zhealth1 + ZM_Bot_ArraySize_Offset; // 5F8 Distance From ZH 1 > ZH 2+
            zhealth3 = zhealth2 + ZM_Bot_ArraySize_Offset;
            zhealth4 = zhealth3 + ZM_Bot_ArraySize_Offset;
            zhealth5 = zhealth4 + ZM_Bot_ArraySize_Offset;
            zhealth6 = zhealth5 + ZM_Bot_ArraySize_Offset;
            zhealth7 = zhealth6 + ZM_Bot_ArraySize_Offset;
            zhealth8 = zhealth7 + ZM_Bot_ArraySize_Offset;
            zhealth9 = zhealth8 + ZM_Bot_ArraySize_Offset;
            zhealth10 = zhealth9 + ZM_Bot_ArraySize_Offset;
            zhealth11 = zhealth10 + ZM_Bot_ArraySize_Offset;
            zhealth12 = zhealth11 + ZM_Bot_ArraySize_Offset;
            zhealth13 = zhealth12 + ZM_Bot_ArraySize_Offset;
            zhealth14 = zhealth13 + ZM_Bot_ArraySize_Offset;
            zhealth15 = zhealth14 + ZM_Bot_ArraySize_Offset;
            zhealth16 = zhealth15 + ZM_Bot_ArraySize_Offset;
            zhealth17 = zhealth16 + ZM_Bot_ArraySize_Offset;
            zhealth18 = zhealth17 + ZM_Bot_ArraySize_Offset;
            zhealth19 = zhealth18 + ZM_Bot_ArraySize_Offset;
            zhealth20 = zhealth19 + ZM_Bot_ArraySize_Offset;
            zhealth21 = zhealth20 + ZM_Bot_ArraySize_Offset;
            zhealth22 = zhealth21 + ZM_Bot_ArraySize_Offset;
            zhealth23 = zhealth22 + ZM_Bot_ArraySize_Offset;
            zhealth24 = zhealth23 + ZM_Bot_ArraySize_Offset;
            zhealth25 = zhealth24 + ZM_Bot_ArraySize_Offset;
            zhealth26 = zhealth25 + ZM_Bot_ArraySize_Offset;
            zhealth27 = zhealth26 + ZM_Bot_ArraySize_Offset;
            zhealth28 = zhealth27 + ZM_Bot_ArraySize_Offset;
            zhealth29 = zhealth28 + ZM_Bot_ArraySize_Offset;
            zhealth30 = zhealth29 + ZM_Bot_ArraySize_Offset;
            zhealth31 = zhealth30 + ZM_Bot_ArraySize_Offset;
            zhealth32 = zhealth31 + ZM_Bot_ArraySize_Offset;
            zhealth33 = zhealth32 + ZM_Bot_ArraySize_Offset;
            zhealth34 = zhealth33 + ZM_Bot_ArraySize_Offset;
            zhealth35 = zhealth34 + ZM_Bot_ArraySize_Offset;

            for (int i = 0; i < vz.Length; i++)
            {
                vz[i] = zhealth1 + ZM_Bot_ArraySize_Offset * i;
            }
            for (int j = 0; j < X_z.Length; j++)
            {
                X_z[j] = vz[0] - 0xC4 + ZM_Bot_ArraySize_Offset * j; // Distance From Zxyz 1 > Zxyz 2+ 
                Y_z[j] = X_z[j] + 0x4;
                Z_z[j] = X_z[j] + 0x8;
            }
            #endregion

            uiid = baseadd + 0xDAECAE8;
            playlistid = baseadd + 0x136D68D0;
        }
    }
}