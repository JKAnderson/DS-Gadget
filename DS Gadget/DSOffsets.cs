using System;

namespace DS_Gadget
{
    static class DSOffsets
    {
        public const int CheckVersion = 0x400080;
        public const int PosLock1 = 0xEBDBCF;
        public const int PosLock2 = 0xEBDBE0;

        public const int AllNoMagicQtyConsume = 0x1376EE7;
        public const int PlayerNoDead = 0x13784D2;
        public const int PlayerExterminate = 0x13784D3;
        public const int AllNoStaminaConsume = 0x13784E4;
        public const int AllNoMPConsume = 0x13784E5;
        public const int AllNoArrowConsume = 0x13784E6;
        public const int PlayerHide = 0x13784E7;
        public const int PlayerSilence = 0x13784E8;
        public const int AllNoDead = 0x13784E9;
        public const int AllNoDamage = 0x13784EA;
        public const int AllNoHit = 0x13784EB;
        public const int AllNoAttack = 0x13784EC;
        public const int AllNoMove = 0x13784ED;
        public const int AllNoUpdateAI = 0x13784EE;

        public const int CompassLarge = 0x1378525;
        public const int CompassSmall = 0x137851B;
        public const int Altimeter = 0x1378524;
        public const int DrawMap = 0x12DEFEB;
        public const int DrawObjects = 0x12DF241;
        public const int DrawCreatures = 0x12DF242;
        public const int DrawSFX = 0x12DF243;
        public const int NodeGraph = 0xFA256C;

        public const int CharData1Ptr = 0x137DC70;
        public const int CharData1Ptr2 = 0x4;
        public const int CharData1Ptr3 = 0x0;
        public enum CharData1
        {
            CharMapDataPtr = 0x28,
            PhantomType = 0x70,
            TeamType = 0x74,
            ForcePlayAnimation1 = 0xFC,
            CharFlags1 = 0x1FC,
            HP = 0x2D4,
            CharFlags2 = 0x3C4,
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

        public const int CharData2Ptr = 0x1378700;
        public const int CharData2Ptr2 = 0x8;
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
            Stance = 0x230,
        }

        public const int GraphicsDataPtr = 0x1378520;
        public const int GraphicsDataPtr2 = 0x10;
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

        public const int WorldStatePtr = 0x13784A0;
        public enum WorldState
        {
            LastBonfire = 0xB04,
            PosStableX = 0xB70,
            PosStableY = 0xB74,
            PosStableZ = 0xB78,
            PosStableAngle = 0xB84,
        }

        public const int Unknown1Ptr = 0x137E204;
        public enum Unknown1
        {
            Area = 0xA12,
            World = 0xA13,
        }

        public const int Unknown2Ptr = 0x137D644;
        public enum Unknown2
        {
            DeathCam = 0x40,
        }

        public enum DropItem
        {
            Category = 0x01,
            ItemID = 0x06,
            Count = 0x10,
            Jump = 0x38
        }
    }
}
