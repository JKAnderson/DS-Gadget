using System;

namespace DS_Gadget
{
    class DSOffsets
    {
        public const int CheckVersion = 0x400080;

        public int PosLock1 = 0xEBDBCF;
        public int PosLock2 = 0xEBDBE0;
        public int NodeGraph = 0xFA256C;

        public int AllNoMagicQtyConsume = 0x1376EE7;
        public int PlayerNoDead = 0x13784D2;
        public int PlayerExterminate = 0x13784D3;
        public int AllNoStaminaConsume = 0x13784E4;
        public int AllNoMPConsume = 0x13784E5;
        public int AllNoArrowConsume = 0x13784E6;
        public int PlayerHide = 0x13784E7;
        public int PlayerSilence = 0x13784E8;
        public int AllNoDead = 0x13784E9;
        public int AllNoDamage = 0x13784EA;
        public int AllNoHit = 0x13784EB;
        public int AllNoAttack = 0x13784EC;
        public int AllNoMove = 0x13784ED;
        public int AllNoUpdateAI = 0x13784EE;

        public int CompassSmall = 0x137851B;
        public int Altimeter = 0x1378524;
        public int CompassLarge = 0x1378525;
        public int DrawMap = 0x12DEFEB;
        public int DrawObjects = 0x12DF241;
        public int DrawCreatures = 0x12DF242;
        public int DrawSFX = 0x12DF243;

        public int CharData1Ptr = 0x137DC70;
        public int CharData1Ptr2 = 0x4;
        public int CharData1Ptr3 = 0x0;
        public enum CharData1
        {
            CharMapDataPtr = 0x28,
            PhantomType = 0x70,
            TeamType = 0x74,
            ForcePlayAnimation1 = 0xFC,
            CharFlags1 = 0x1FC,
            HP = 0x2D4,
            CharFlags2 = 0x3C4,
            StoredItem = 0x628,
        }

        // Most of these are very much not verified.
        [Flags]
        public enum CharFlags1 : uint
        {
            // Can't die, but still take damage from killboxes and trigger deathcams
            SetDeadMode = 0x02000000,
            // Doesn't prevent healing
            DisableDamage = 0x04000000,
            // Super armor and disable damage, still die to killbox
            EnableInvincible = 0x08000000,
            FirstPerson = 0x00100000,
            SetDrawEnable = 0x00800000,
            SetSuperArmor = 0x00010000,
            SetDisableGravity = 0x00004000,
            ForceSetOmission = 0x00000100,
            ForceUpdateNextFrame = 0x00000200,
            ForcePlayAnimation = 0x00000100,
            SetEventGenerate = 0x00000010,
            DisableHPGauge = 0x00000008,
        }

        [Flags]
        public enum CharFlags2 : uint
        {
            NoGoodsConsume = 0x01000000,
            DrawCounter = 0x00200000,
            DrawDirection = 0x00004000,
            NoUpdate = 0x00008000,
            NoAttack = 0x00000100,
            NoMove = 0x00000200,
            NoStamConsume = 0x00000400,
            NoMPConsume = 0x00000800,
            // Can't die, killboxes and death cams do nothing
            NoDead = 0x00000020,
            // Also prevents healing
            NoDamage = 0x00000040,
            NoHit = 0x00000080,
            DrawHit = 0x00000004,
        }

        public enum CharMapData
        {
            AnimDataPtr = 0x14,
            CharPosDataPtr = 0x1C,
            CharMapFlags = 0xC4,
            Warp = 0xC8,
            WarpX = 0xD0,
            WarpY = 0xD4,
            WarpZ = 0xD8,
            WarpAngle = 0xE4,
        }

        public enum AnimData
        {
            PlaySpeed = 0x64,
        }

        [Flags]
        public enum CharMapFlags : uint
        {
            DisableMapHit = 0x00000010,
        }

        public enum CharPosData
        {
            PosAngle = 0x4,
            PosX = 0x10,
            PosY = 0x14,
            PosZ = 0x18,
        }

        public int CharData2Ptr = 0x1378700;
        public int CharData2Ptr2 = 0x8;
        public enum CharData2
        {
            HP = 0xC,
            HPModMax = 0x10,
            HPMax = 0x14,
            Stamina = 0x28,
            StaminaModMax = 0x2C,
            StaminaMax = 0x30,
            Vitality = 0x38,
            Attunement = 0x40,
            Endurance = 0x48,
            Strength = 0x50,
            Dexterity = 0x58,
            Intelligence = 0x60,
            Faith = 0x68,
            Humanity = 0x7C,
            Resistance = 0x80,
            SoulLevel = 0x88,
            Souls = 0x8C,
            Class = 0xC6,
            EquipLeft1Idx = 0x1D4,
            EquipRight1Idx = 0x1D8,
            EquipLeft2Idx = 0x1DC,
            EquipRight2Idx = 0x1E0,
            EquipArrow1Idx = 0x1E4,
            EquipBolt1Idx = 0x1E8,
            EquipArrow2Idx = 0x1EC,
            EquipBolt2Idx = 0x1F0,
            EquipHelmetIdx = 0x1F4,
            EquipChestIdx = 0x1F8,
            EquipGloveIdx = 0x1FC,
            EquipPantsIdx = 0x200,
            EquipHairIdx = 0x204,
            EquipRing1Idx = 0x208,
            EquipRing2Idx = 0x20C,
            EquipItem1Idx = 0x210,
            EquipItem2Idx = 0x214,
            EquipItem3Idx = 0x218,
            EquipItem4Idx = 0x21C,
            EquipItem5Idx = 0x220,
            Stance = 0x230,
            EquipLeft1ID = 0x24C,
            EquipRight1ID = 0x250,
            EquipLeft2ID = 0x254,
            EquipRight2ID = 0x258,
            EquipArrow1ID = 0x25C,
            EquipBolt1ID = 0x260,
            EquipArrow2ID = 0x264,
            EquipBolt2ID = 0x268,
            EquipHelmetID = 0x26C,
            EquipChestID = 0x270,
            EquipGloveID = 0x274,
            EquipPantsID = 0x278,
            EquipHairID = 0x27C,
            EquipRing1ID = 0x280,
            EquipRing2ID = 0x284,
            EquipItem1ID = 0x288,
            EquipItem2ID = 0x28C,
            EquipItem3ID = 0x290,
            EquipItem4ID = 0x294,
            EquipItem5ID = 0x298,
        }

        public int GraphicsDataPtr = 0x1378520;
        public int GraphicsDataPtr2 = 0x10;
        public enum GraphicsData
        {
            DepthDraw_DepthTexEdge = 0x23F,
            DrawTextures = 0x240,
            DrawBoundingBoxes = 0x241,
            NormalDraw_TexEdge = 0x242,
            NormalDraw_Trans = 0x245,
            DrawShadows = 0x246,
            DrawSpriteShadows = 0x247,
            EnableFilter = 0x26D,
            BrightnessR = 0x270,
            BrightnessG = 0x274,
            BrightnessB = 0x278,
            Saturation = 0x27C,
            ContrastR = 0x280,
            ContrastG = 0x284,
            ContrastB = 0x288,
            Hue = 0x28C,
        }

        public int WorldStatePtr = 0x13784A0;
        public enum WorldState
        {
            LastBonfire = 0xB04,
            PosStableX = 0xB70,
            PosStableY = 0xB74,
            PosStableZ = 0xB78,
            PosStableAngle = 0xB84,
        }

        public int ChrFollowCamPtr = 0x137D6DC;
        public int ChrFollowCamPtr2 = 0x3C;
        public int ChrFollowCamPtr3 = 0x60;
        public enum ChrFollowCam
        {
            RotX = 0xE0,
            RotY = 0xE4,
            RotZ = 0xE8,
            PosX = 0x100,
            PosY = 0x104,
            PosZ = 0x108,
            CamRotX = 0x140,
            CamRotY = 0x144,
            CamRotZ = 0x148,
            TargetRotX = 0x150,
            TargetRotY = 0x154,
            TargetRotZ = 0x158,
        }

        public int EventFlagsPtr = 0x137D7D4;
        public int EventFlagsPtr2 = 0x0;

        public int Unknown1Ptr = 0x137E204;
        public enum Unknown1
        {
            Area = 0xA12,
            World = 0xA13,
        }

        public int Unknown2Ptr = 0x137D644;
        public enum Unknown2
        {
            DeathCam = 0x40,
        }

        public int Unknown3Ptr = 0x13784A4;
        public enum Unknown3
        {
            MenuKick = 0x0,
        }

        public int Unknown4Ptr = 0x12E29E8;
        public int Unknown4Ptr2 = 0x0;
        public enum Unknown4
        {
            StoredMagic = 0x1D4,
        }

        public int FuncItemDropPtr = 0xDC8C60;
        public int FuncItemDropUnknown1 = 0x13786D0;
        public int FuncItemDropUnknown2 = 0x137D6BC;

        public int FuncLevelUpPtr = 0xC75DD0;
        public enum FuncLevelUp
        {
            Vitality = 0x0,
            Attunement = 0x4,
            Endurance = 0x8,
            Strength = 0xC,
            Dexterity = 0x10,
            Resistance = 0x14,
            Intelligence = 0x18,
            Faith = 0x1C,
            SoulLevel = 0x16C,
            Souls = 0x178,
        }

        public static DSOffsets Release = new DSOffsets();
        public static DSOffsets Debug = new DSOffsets()
        {
            PosLock1 = 0xEC0A8F,
            PosLock2 = 0xEC0AA0,
            NodeGraph = 0xFA618C,

            AllNoMagicQtyConsume = 0x137B0A8,
            PlayerNoDead = 0x137C68B,
            PlayerExterminate = 0x137C6A4,
            AllNoStaminaConsume = 0x137C6A5,
            AllNoMPConsume = 0x137C6A6,
            AllNoArrowConsume = 0x137C6A7,
            PlayerHide = 0x137C6A8,
            PlayerSilence = 0x137C6A9,
            AllNoDead = 0x137C6AA,
            AllNoDamage = 0x137C6AB,
            AllNoHit = 0x137C6AC,
            AllNoAttack = 0x137C6AD,
            AllNoMove = 0x137C6AE,
            AllNoUpdateAI = 0x137C6AF,

            CompassSmall = 0x137C6E4,
            Altimeter = 0x137C6E5,
            CompassLarge = 0x137C6E6,
            DrawMap = 0x12E2FEB,
            DrawObjects = 0x12E3241,
            DrawCreatures = 0x12E3242,
            DrawSFX = 0x12E3243,

            CharData1Ptr = 0x1381E30,
            CharData2Ptr = 0x137C8C0,
            GraphicsDataPtr = 0x137C6E0,
            WorldStatePtr = 0x137C660,
            ChrFollowCamPtr = 0x138189C,
            EventFlagsPtr = 0x1381994,
            Unknown1Ptr = 0x13823C4,
            Unknown2Ptr = 0x1381804,
            Unknown3Ptr = 0x137C664,
            Unknown4Ptr = 0x12E69E8,

            FuncItemDropUnknown1 = 0x137C890,
            FuncItemDropUnknown2 = 0x138187C,
            FuncItemDropPtr = 0xDCB550,

            FuncLevelUpPtr = 0xC75850,
        };
    }
}
