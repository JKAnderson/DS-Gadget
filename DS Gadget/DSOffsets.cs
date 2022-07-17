using System;
using System.Security.Cryptography.X509Certificates;

namespace DS_Gadget
{
    class DSOffsets
    {
        public const int CheckVersion = 0x400080;

        public const string PosLockAOB = "F3 0F 11 44 24 08 F3 0F 11 0C 24 F3 0F 11 54 24 04 F3 0F 7E 04 24";
        public const int PosLock1AOBOffset = 0x16;
        public const int PosLock2AOBOffset = 0x27;

        public const string NodeGraphAOB = "8B 4C 24 5C 8B 11 50 8B 42 34 FF D0 80 BB 90 00 00 00 ?";
        public const int NodeGraphAOBOffset = 0x12;

        public const string AllNoMagicQtyConsumeAOB = "38 1D ? ? ? ? 0F 94 C1 3A CB";
        public const int AllNoMagicQtyConsumeAOBOffset = 2;

        public const string PlayerNoDeadAOB = "53 56 8B F0 8A 9E C4 03 00 00 8B 06 8B 90 A4 00 00 00 C0 EB 05 8B CE 80 E3 01 FF D2 84 C0 ? ? 80 3D ? ? ? ? 00";
        public const int PlayerNoDeadAOBOffset = 0x22;

        public const string PlayerExterminateAOB = "8B 11 8B 82 A4 00 00 00 FF D0 84 C0 ? ? 80 3D ? ? ? ? 00";
        public const int PlayerExterminateAOBOffset = 0x10;

        public const string AllNoStaminaConsumeAOB = "51 8B 4C 24 08 3B 8A E4 02 00 00 ? ? F6 82 C5 03 00 00 04 ? ? 80 3D ? ? ? ? 00";
        public const int AllNoStaminaConsumeAOBOffset = 0x18;
        public enum ChrDbg
        {
            AllNoStaminaConsume = 0,
            AllNoMPConsume = 1,
            AllNoArrowConsume = 2,
            PlayerHide = 3,
            PlayerSilence = 4,
            AllNoDead = 5,
            AllNoDamage = 6,
            AllNoHit = 7,
            AllNoAttack = 8,
            AllNoMove = 9,
            AllNoUpdateAI = 0xA,
        }

        public const string CompassAOB = "33 FF 85 FF 0F 84 ? ? ? ? 80 3D ? ? ? ? 00";
        public const int CompassSmallAOBOffset = 0xC;
        public const int AltimeterAOBOffset = 0x15;
        public const int CompassLargeAOBOffset = 0x1E;

        public const string DrawMapAOB = "80 3D ? ? ? ? 00 A1 ? ? ? ? 8B 48 08 8B 11 56 8B 72 28 B8 00 00 00 80";
        public const int DrawMapAOBOffset = 2;
        public enum DrawMap
        {
            DrawMap = 0,
            DrawObjects = 0x256,
            DrawCreatures = 0x257,
            DrawSFX = 0x258,
        }

        public const string CharData1AOB = "8B 15 ? ? ? ? F3 0F 10 44 24 30 52";
        public const int CharData1AOBOffset = 2;
        public const int CharData1Offset1 = 0;
        public const int CharData1Offset2 = 4;
        public const int CharData1Offset3 = 0;
        public enum CharData1
        {
            CharMapDataPtr = 0x28,
            ChrType = 0x70,
            TeamType = 0x74,
            ForcePlayAnimation1 = 0xFC,
            CharFlags1 = 0x1FC,
            PlayRegion = 0x284,
            HP = 0x2D4,
            Stamina = 0x2E4,
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

        public const string CharData2AOB = "A1 ? ? ? ? 8B 40 34 53 32 DB 85 C0";
        public const int CharData2AOBOffset = 1;
        public const int CharData2Offset1 = 0;
        public const int CharData2Offset2 = 8;
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
            CharName = 0xA0,
            Sex = 0xC2,
            Class = 0xC6,
            Physique = 0xC7,
            WarriorOfSunlightPoints = 0xE5,
            DarkwraithPoints = 0xE6,
            PathOfTheDragonPoints = 0xE7,
            GravelordServantPoints = 0xE8,
            ForestHunterPoints = 0xE9,
            DarkmoonBladePoints = 0xEA,
            ChaosServantPoints = 0xEB,
            Covenant = 0x10B,
            InventoryIndexStart = 0x1B8,
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
            GesturesEquippedPtr = 0x334,
            GesturesUnlockedPtr = 0x424,
        }

        public const string GraphicsDataAOB = "89 9C 24 A0 01 00 00 A1 ? ? ? ? 8B 48 14 89 8C 24 A0 00 00 00 8B 4F 3C 8B 41 28 8B 40 1C F3 0F 7E 40 10 66 0F D6 84 24 84 00 00 00 F3 0F 7E 40 18 8D 84 24 E4 00 00 00 66 0F D6 84 24 8C 00 00 00";
        public const int GraphicsDataAOBOffset = 8;
        public const int GraphicsDataOffset1 = 0;
        public const int GraphicsDataOffset2 = 0x10;
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

        public const string WorldStateAOB = "8B 54 24 10 8B C8 F7 D9 39 8A B8 0E 00 00 B3 01 0F 95 C2 8B 0D ? ? ? ? 80 B9 A5 0B 00 00 00";
        public const int WorldStateAOBOffset = 0x15;
        public const int WorldStateOffset1 = 0;
        public enum WorldState
        {
            LastBonfire = 0xB04,
            PosStableX = 0xB70,
            PosStableY = 0xB74,
            PosStableZ = 0xB78,
            PosStableAngle = 0xB84,
        }

        public const string MenuManagerAOB = "C6 47 18 01 F3 0F 11 4F 1C 8B 0D ? ? ? ? 83 B9 9C 00 00 00 00";
        public const int MenuManagerAOBOffset = 0xB;
        public const int MenuManagerOffset1 = 0;
        public enum MenuManager
        {
            QuantityDefault = 0x20C,
        }

        public const string ChrFollowCamAOB = "D9 45 08 A1 ? ? ? ? 51 D9 1C 24 50";
        public const int ChrFollowCamAOBOffset = 4;
        public const int ChrFollowCamOffset1 = 0;
        public const int ChrFollowCamOffset2 = 0x3C;
        public const int ChrFollowCamOffset3 = 0x60;
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

        public const string EventFlagsAOB = "56 8B F1 8B 46 1C 50 A1 ? ? ? ? 32 C9";
        public const int EventFlagsAOBOffset = 8;
        public const int EventFlagsOffset1 = 0;
        public const int EventFlagsOffset2 = 0;

        public const string Unknown1AOB = "8B 48 04 8B 11 50 8B 42 34 FF D0 C7 46 2C 00 00 00 00 C3 8B 0D ? ? ? ? 8B 89 50 0B 00 00 32 C0 83 79 28 00";
        public const int Unknown1AOBOffset = 0x15;
        public const int Unknown1Offset1 = 0;
        public enum Unknown1
        {
            Area = 0xA12,
            World = 0xA13,
        }

        public const string Unknown2AOB = "88 5D 15 88 5D 16 88 5D 17 A1 ? ? ? ? 3B C3";
        public const int Unknown2AOBOffset = 0xA;
        public const int Unknown2Offset1 = 0;
        public enum Unknown2
        {
            DeathCam = 0x40,
        }

        public const string Unknown3AOB = "8B 70 3C 8B 2D ? ? ? ? 8B 45 00 8B 8E 48 01 00 00 89 4C 24 34 83 F8 01";
        public const int Unknown3AOBOffset = 5;
        public const int Unknown3Offset1 = 0;
        public enum Unknown3
        {
            MenuKick = 0x0,
        }

        public const string Unknown4AOB = "8B 76 3C 8B 76 0C 89 35 ? ? ? ? 33 C0 8D 72 9C 57 89 44 24 08 83 FE 14";
        public const int Unknown4AOBOffset = 8;
        public const int Unknown4Offset1 = 0;
        public const int Unknown4Offset2 = 0;
        public enum Unknown4
        {
            StoredMagic = 0x1D4,
        }
        
        public enum Gestures
        {
            PointForward = 0x8,
            PointUp = 0xC,
            PointDown = 0x10,
            Beckon = 0x14,
            Wave = 0x18,
            Bow = 0x1C,
            ProperBow = 0x20,
            Hurrah = 0x24,
            Joy = 0x28,
            Shrug = 0x2C,
            LookSkyward = 0x30,
            WellWhatIsIt = 0x34,
            Prostration = 0x38,
            Prayer = 0x3C,
            PraiseTheSun = 0x40,
        }


        public const string FuncItemGetAOB = "55 8B EC 83 E4 F8 83 EC 34 8B 4D 0C 53 8B 5D 08 56 83 C8 FF 33 F6 81 F9 00 00 00 20 57 89 44 24 1C 89 74 24 20 89 B3 8C 01 00 00 89 44 24 18";

        public const string FuncLevelUpAOB = "83 EC 08 8B 15 ? ? ? ? 56 57 8B 7A 08";
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

        public const string FuncBonfireWarpAOB = "33 C0 39 46 04 ? ? 8B 0D ? ? ? ? 8B 15 ? ? ? ? C6 41 44 01";
        public const string FuncBonfireWarpUnknown1AOB = "89 73 44 C6 44 24 2C 00 C7 82 84 00 00 00 06 00 00 00 8B 3D ? ? ? ? 85 FF";
        public const int FuncBonfireWarpUnknown1AOBOffset = 0x14;

        public const string FuncItemDropAOB = "8B 0D ? ? ? ? 83 EC 68 81 C1 28 08 00 00";
        public const string FuncItemDropUnknown1AOB = "88 5D 3C 88 5D 3D F3 0F 10 61 08 F3 0F 11 65 40 39 1D ? ? ? ?";
        public const int FuncItemDropUnknown1AOBOffset = 0x12;
        public const string FuncItemDropUnknown2AOB = "D9 E8 8B 1D ? ? ? ? 83 EC 08 D9 54 24 04 D9 1C 24 8D 44 24 20 6A 03 8B D3";
        public const int FuncItemDropUnknown2AOBOffset = 4;


        public const string AiTimerAOB = "8b 15 ? ? ? ? f3 0f ? ? ? ? 52";
        public const int AiTimerOffset1 = 0x2;
        public const int AiTimerOffset2 = 0x0;
        public const int AiTimerOffset3 = 0x14;
    }
}
