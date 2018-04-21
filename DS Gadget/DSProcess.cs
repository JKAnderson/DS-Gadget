using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DS_Gadget
{
    class DSProcess
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private const uint VERSION_RELEASE = 0xFC293654;
        private const uint VERSION_DEBUG = 0xCE9634B4;
        private const uint VERSION_BETA = 0xE91B11E2;

        public static DSProcess GetProcess()
        {
            DSProcess result = null;
            Process[] candidates = Process.GetProcessesByName("DARKSOULS");
            foreach (Process candidate in candidates)
            {
                if (result == null)
                    result = new DSProcess(candidate);
            }
            return result;
        }


        private readonly Process process;
        private readonly DSInterface dsInterface;
        private readonly DSOffsets offsets;

        public readonly int ID;
        public readonly string Version;
        public readonly bool Valid;

        public DSProcess(Process candidate)
        {
            process = candidate;
            ID = process.Id;
            dsInterface = DSInterface.Attach(process);
            switch (dsInterface?.ReadUInt32(DSOffsets.CheckVersion))
            {
                case VERSION_RELEASE:
                    Version = "Steam";
                    offsets = DSOffsets.Release;
                    Valid = true;
                    break;
                case VERSION_DEBUG:
                    Version = "Debug";
                    offsets = DSOffsets.Debug;
                    Valid = true;
                    break;
                case VERSION_BETA:
                    Version = "Beta";
                    Valid = false;
                    break;
                default:
                    Version = "Unknown";
                    Valid = false;
                    break;
            }

            /*
            DSOffsets offsets;
            if (some condition)
                offsets = new DSOffsets();
            else
                offsets = new DSOffsetsDebug();
            DoThing(offsets.SomeValue);
            */
        }

        public void Close()
        {
            dsInterface.Close();
        }

        public bool Alive()
        {
            return !process.HasExited;
        }

        public bool Loaded()
        {
            return Valid && getCharData1() != 0;
        }

        public bool Focused()
        {
            IntPtr hwnd = GetForegroundWindow();
            GetWindowThreadProcessId(hwnd, out uint pid);
            return pid == process.Id;
        }

        #region Pointer loading
        private struct DSPointers
        {
            public int CharData1, CharMapData, AnimData, CharPosData, CharData2, GraphicsData,
                WorldState, MenuManager, ChrFollowCam, EventFlags, Unknown1, Unknown2, Unknown3, Unknown4;
        }
        private DSPointers pointers;

        public void LoadPointers()
        {
            pointers.CharData1 = getCharData1();

            pointers.CharMapData = dsInterface.ReadInt32(pointers.CharData1 + (int)DSOffsets.CharData1.CharMapDataPtr);

            pointers.AnimData = dsInterface.ReadInt32(pointers.CharMapData + (int)DSOffsets.CharMapData.AnimDataPtr);

            pointers.CharPosData = dsInterface.ReadInt32(pointers.CharMapData + (int)DSOffsets.CharMapData.CharPosDataPtr);

            int pointer = dsInterface.ReadInt32(offsets.CharData2Ptr);
            pointers.CharData2 = dsInterface.ReadInt32(pointer + offsets.CharData2Ptr2);

            pointer = dsInterface.ReadInt32(offsets.GraphicsDataPtr);
            pointers.GraphicsData = dsInterface.ReadInt32(pointer + offsets.GraphicsDataPtr2);

            pointers.WorldState = dsInterface.ReadInt32(offsets.WorldStatePtr);

            pointers.MenuManager = dsInterface.ReadInt32(offsets.MenuManagerPtr);

            pointer = dsInterface.ReadInt32(offsets.ChrFollowCamPtr);
            pointer = dsInterface.ReadInt32(pointer + offsets.ChrFollowCamPtr2);
            pointers.ChrFollowCam = dsInterface.ReadInt32(pointer + offsets.ChrFollowCamPtr3);

            pointer = dsInterface.ReadInt32(offsets.EventFlagsPtr);
            pointers.EventFlags = dsInterface.ReadInt32(pointer + offsets.EventFlagsPtr2);

            pointers.Unknown1 = dsInterface.ReadInt32(offsets.Unknown1Ptr);

            pointers.Unknown2 = dsInterface.ReadInt32(offsets.Unknown2Ptr);

            pointers.Unknown3 = dsInterface.ReadInt32(offsets.Unknown3Ptr);

            pointer = dsInterface.ReadInt32(offsets.Unknown4Ptr);
            pointers.Unknown4 = dsInterface.ReadInt32(pointer + offsets.Unknown4Ptr2);
        }

        // Also used to check if game is loaded
        private int getCharData1()
        {
            int pointer = dsInterface.ReadInt32(offsets.CharData1Ptr);
            pointer = dsInterface.ReadInt32(pointer + offsets.CharData1Ptr2);
            return dsInterface.ReadInt32(pointer + offsets.CharData1Ptr3);
        }
        #endregion

        #region Player Tab
        public float GetHP()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.HP);
        }

        public void SetHP(int value)
        {
            // HP in CharData2 can't be written
            dsInterface.WriteInt32(pointers.CharData1 + (int)DSOffsets.CharData1.HP, value);
        }

        public float GetHPMax()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.HPMax);
        }

        public float GetHPModMax()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.HPModMax);
        }

        public float GetStam()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Stamina);
        }

        public float GetStamMax()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.StaminaMax);
        }

        public float GetStamModMax()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.StaminaModMax);
        }

        public int GetPhantomType()
        {
            return dsInterface.ReadInt32(pointers.CharData1 + (int)DSOffsets.CharData1.PhantomType);
        }

        public void SetPhantomType(int value)
        {
            dsInterface.WriteInt32(pointers.CharData1 + (int)DSOffsets.CharData1.PhantomType, value);
        }

        public int GetTeamType()
        {
            return dsInterface.ReadInt32(pointers.CharData1 + (int)DSOffsets.CharData1.TeamType);
        }

        public void SetTeamType(int value)
        {
            dsInterface.WriteInt32(pointers.CharData1 + (int)DSOffsets.CharData1.TeamType, value);
        }

        public int GetWorld()
        {
            return dsInterface.ReadByte(pointers.Unknown1 + (int)DSOffsets.Unknown1.World);
        }

        public int GetArea()
        {
            return dsInterface.ReadByte(pointers.Unknown1 + (int)DSOffsets.Unknown1.Area);
        }

        public void SetPosLock(bool enable)
        {
            if (enable)
            {
                dsInterface.WriteBytes(offsets.PosLock1, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 });
                dsInterface.WriteBytes(offsets.PosLock2, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 });
            }
            else
            {
                dsInterface.WriteBytes(offsets.PosLock1, new byte[] { 0x66, 0x0F, 0xD6, 0x46, 0x10 });
                dsInterface.WriteBytes(offsets.PosLock2, new byte[] { 0x66, 0x0F, 0xD6, 0x46, 0x18 });
            }
        }

        public void SetPos(float x, float y, float z)
        {
            dsInterface.WriteFloat(pointers.CharPosData + (int)DSOffsets.CharPosData.PosX, x);
            dsInterface.WriteFloat(pointers.CharPosData + (int)DSOffsets.CharPosData.PosY, y);
            dsInterface.WriteFloat(pointers.CharPosData + (int)DSOffsets.CharPosData.PosZ, z);
        }

        public float GetPosX()
        {
            return dsInterface.ReadFloat(pointers.CharPosData + (int)DSOffsets.CharPosData.PosX);
        }

        public float GetPosY()
        {
            return dsInterface.ReadFloat(pointers.CharPosData + (int)DSOffsets.CharPosData.PosY);
        }

        public float GetPosZ()
        {
            return dsInterface.ReadFloat(pointers.CharPosData + (int)DSOffsets.CharPosData.PosZ);
        }

        public float GetPosAngle()
        {
            return dsInterface.ReadFloat(pointers.CharPosData + (int)DSOffsets.CharPosData.PosAngle);
        }

        public float GetPosStableX()
        {
            return dsInterface.ReadFloat(pointers.WorldState + (int)DSOffsets.WorldState.PosStableX);
        }

        public float GetPosStableY()
        {
            return dsInterface.ReadFloat(pointers.WorldState + (int)DSOffsets.WorldState.PosStableY);
        }

        public float GetPosStableZ()
        {
            return dsInterface.ReadFloat(pointers.WorldState + (int)DSOffsets.WorldState.PosStableZ);
        }

        public float GetPosStableAngle()
        {
            return dsInterface.ReadFloat(pointers.WorldState + (int)DSOffsets.WorldState.PosStableAngle);
        }

        public void PosWarp(float x, float y, float z, float angle)
        {
            dsInterface.WriteFloat(pointers.CharMapData + (int)DSOffsets.CharMapData.WarpX, x);
            dsInterface.WriteFloat(pointers.CharMapData + (int)DSOffsets.CharMapData.WarpY, y);
            dsInterface.WriteFloat(pointers.CharMapData + (int)DSOffsets.CharMapData.WarpZ, z);
            dsInterface.WriteFloat(pointers.CharMapData + (int)DSOffsets.CharMapData.WarpAngle, angle);
            dsInterface.WriteBool(pointers.CharMapData + (int)DSOffsets.CharMapData.Warp, true);
        }

        public byte[] DumpFollowCam()
        {
            return dsInterface.ReadBytes(pointers.ChrFollowCam, 512);
        }

        public void UndumpFollowCam(byte[] bytes)
        {
            dsInterface.WriteBytes(pointers.ChrFollowCam, bytes);
        }

        public void SetGravity(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetDisableGravity, !enable);
        }

        public void SetCollision(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharMapData + (int)DSOffsets.CharMapData.CharMapFlags, (uint)DSOffsets.CharMapFlags.DisableMapHit, !enable);
        }

        public bool GetDeathCam()
        {
            return dsInterface.ReadBool(pointers.Unknown2 + (int)DSOffsets.Unknown2.DeathCam);
        }

        public void SetDeathCam(bool enable)
        {
            dsInterface.WriteBool(pointers.Unknown2 + (int)DSOffsets.Unknown2.DeathCam, enable);
        }

        public int GetBonfire()
        {
            return dsInterface.ReadInt32(pointers.WorldState + (int)DSOffsets.WorldState.LastBonfire);
        }

        public void SetBonfire(int id)
        {
            dsInterface.WriteInt32(pointers.WorldState + (int)DSOffsets.WorldState.LastBonfire, id);
        }

        public void SetSpeed(float speed)
        {
            dsInterface.WriteFloat(pointers.AnimData + (int)DSOffsets.AnimData.PlaySpeed, speed);
        }
        #endregion

        #region Stats Tab
        public int GetClass()
        {
            return dsInterface.ReadByte(pointers.CharData2 + (int)DSOffsets.CharData2.Class);
        }
        public void SetClass(byte value)
        {
            dsInterface.WriteByte(pointers.CharData2 + (int)DSOffsets.CharData2.Class, value);
        }

        public int GetSoulLevel()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.SoulLevel);
        }
        public void SetSoulLevel(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.SoulLevel, value);
        }

        public int GetHumanity()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Humanity);
        }
        public void SetHumanity(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Humanity, value);
        }

        public int GetSouls()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Souls);
        }
        public void SetSouls(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Souls, value);
        }

        public int GetVitality()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Vitality);
        }
        public void SetVitality(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Vitality, value);
        }

        public int GetAttunement()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Attunement);
        }
        public void SetAttunement(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Attunement, value);
        }

        public int GetEndurance()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Endurance);
        }
        public void SetEndurance(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Endurance, value);
        }

        public int GetStrength()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Strength);
        }
        public void SetStrength(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Strength, value);
        }

        public int GetDexterity()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Dexterity);
        }
        public void SetDexterity(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Dexterity, value);
        }

        public int GetResistance()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Resistance);
        }
        public void SetResistance(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Resistance, value);
        }

        public int GetIntelligence()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Intelligence);
        }
        public void SetIntelligence(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Intelligence, value);
        }

        public int GetFaith()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Faith);
        }
        public void SetFaith(int value)
        {
            dsInterface.WriteInt32(pointers.CharData2 + (int)DSOffsets.CharData2.Faith, value);
        }

        public void LevelUp(int vitality, int attunement, int endurance, int strength, int dexterity, int resistance, int intelligence, int faith, int level)
        {
            int humanity = GetHumanity();

            int stats = dsInterface.Allocate(2048);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Vitality, vitality);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Attunement, attunement);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Endurance, endurance);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Strength, strength);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Dexterity, dexterity);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Resistance, resistance);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Intelligence, intelligence);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Faith, faith);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.SoulLevel, level);
            dsInterface.WriteInt32(stats + (int)DSOffsets.FuncLevelUp.Souls, GetSouls());

            string asm = String.Format(
                "mov eax, 0x{0:X}\n" +
                "mov ecx, 0x{0:X}\n" +
                "call 0x{1:X}\n" +
                "ret",
                stats, offsets.FuncLevelUpPtr);

            dsInterface.AsmExecute(asm);
            dsInterface.Free(stats);

            SetHumanity(humanity);
        }
        #endregion

        #region Items Tab
        public void DropItem(int category, int itemID, int count)
        {
            string asm = String.Format(
                "mov ebp, 0x{0:X}\n" +
                "mov ebx, 0x{1:X}\n" +
                "mov ecx, 0xFFFFFFFF\n" +
                "mov edx, 0x{2:X}\n" +
                "mov eax, [0x{3:X}]\n" +
                "mov [eax + 0x828], ebp\n" +
                "mov [eax + 0x82C], ebx\n" +
                "mov [eax + 0x830], ecx\n" +
                "mov [eax + 0x834], edx\n" +
                "mov eax, [0x{4:X}]\n" +
                "push eax\n" +
                "call 0x{5:X}\n" +
                "ret",
                category, itemID, count, offsets.FuncItemDropUnknown1, offsets.FuncItemDropUnknown2, offsets.FuncItemDropPtr);

            dsInterface.AsmExecute(asm);
        }
        #endregion

        #region Graphics Tab
        public void DrawBounding(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.DrawBoundingBoxes, enable);
        }

        public void DrawSpriteMasks(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.DepthDraw_DepthTexEdge, enable);
        }

        public void DrawTextures(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.DrawTextures, enable);
        }

        public void DrawSprites(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.NormalDraw_TexEdge, enable);
        }

        public void DrawTrans(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.NormalDraw_Trans, enable);
        }

        public void DrawShadows(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.DrawShadows, enable);
        }

        public void DrawSpriteShadows(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.DrawSpriteShadows, enable);
        }

        public void DrawMap(bool enable)
        {
            dsInterface.WriteBool(offsets.DrawMap, enable);
        }

        public void DrawCreatures(bool enable)
        {
            dsInterface.WriteBool(offsets.DrawCreatures, enable);
        }

        public void DrawObjects(bool enable)
        {
            dsInterface.WriteBool(offsets.DrawObjects, enable);
        }

        public void DrawSFX(bool enable)
        {
            dsInterface.WriteBool(offsets.DrawSFX, enable);
        }

        public void DrawCompassLarge(bool enable)
        {
            dsInterface.WriteBool(offsets.CompassLarge, enable);
        }

        public void DrawCompassSmall(bool enable)
        {
            dsInterface.WriteBool(offsets.CompassSmall, enable);
        }

        public void DrawAltimeter(bool enable)
        {
            dsInterface.WriteBool(offsets.Altimeter, enable);
        }

        public void DrawNodes(bool enable)
        {
            dsInterface.WriteBool(offsets.NodeGraph, enable);
        }

        public void OverrideFilter(bool enable)
        {
            dsInterface.WriteBool(pointers.GraphicsData + (int)DSOffsets.GraphicsData.EnableFilter, enable);
        }

        public void SetBrightness(float brightnessR, float brightnessG, float brightnessB)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.BrightnessR, brightnessR);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.BrightnessG, brightnessG);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.BrightnessB, brightnessB);
        }

        public void SetContrast(float contrastR, float contrastG, float contrastB)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.ContrastR, contrastR);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.ContrastG, contrastG);
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.ContrastB, contrastB);
        }

        public void SetSaturation(float saturation)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.Saturation, saturation);
        }

        public void SetHue(float hue)
        {
            dsInterface.WriteFloat(pointers.GraphicsData + (int)DSOffsets.GraphicsData.Hue, hue);
        }
        #endregion

        #region Cheats Tab
        public void SetPlayerDeadMode(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetDeadMode, enable);
        }

        public void SetPlayerNoDamage(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoDamage, enable);
        }

        public void SetPlayerNoHit(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoHit, enable);
        }

        public void SetPlayerNoStamina(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoStamConsume, enable);
        }

        public void SetPlayerSuperArmor(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetSuperArmor, enable);
        }

        public void SetPlayerNoGoods(bool enable)
        {
            dsInterface.WriteFlag32(pointers.CharData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoGoodsConsume, enable);
        }

        public void SetAllNoMagic(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoMagicQtyConsume, enable);
        }

        public void SetNoDead(bool enable)
        {
            dsInterface.WriteBool(offsets.PlayerNoDead, enable);
        }

        public void SetExterminate(bool enable)
        {
            dsInterface.WriteBool(offsets.PlayerExterminate, enable);
        }

        public void SetAllStamina(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoStaminaConsume, enable);
        }

        public void SetAllMP(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoMPConsume, enable);
        }

        public void SetAllAmmo(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoArrowConsume, enable);
        }

        public void SetHide(bool enable)
        {
            dsInterface.WriteBool(offsets.PlayerHide, enable);
        }

        public void SetSilence(bool enable)
        {
            dsInterface.WriteBool(offsets.PlayerSilence, enable);
        }

        public void SetAllNoDead(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoDead, enable);
        }

        public void SetAllNoDamage(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoDamage, enable);
        }

        public void SetAllNoHit(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoHit, enable);
        }

        public void SetAllNoAttack(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoAttack, enable);
        }

        public void SetAllNoMove(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoMove, enable);
        }

        public void SetAllNoUpdateAI(bool enable)
        {
            dsInterface.WriteBool(offsets.AllNoUpdateAI, enable);
        }
        #endregion

        #region Internals Tab
        public int GetEquipRight1Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRight1Idx);
        }

        public int GetEquipRight1ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRight1ID);
        }

        public int GetEquipRight2Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRight2Idx);
        }

        public int GetEquipRight2ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRight2ID);
        }

        public int GetEquipLeft1Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipLeft1Idx);
        }

        public int GetEquipLeft1ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipLeft1ID);
        }

        public int GetEquipLeft2Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipLeft2Idx);
        }

        public int GetEquipLeft2ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipLeft2ID);
        }

        public int GetEquipArrow1Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipArrow1Idx);
        }

        public int GetEquipArrow1ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipArrow1ID);
        }

        public int GetEquipArrow2Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipArrow2Idx);
        }

        public int GetEquipArrow2ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipArrow2ID);
        }

        public int GetEquipBolt1Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipBolt1Idx);
        }

        public int GetEquipBolt1ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipBolt1ID);
        }

        public int GetEquipBolt2Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipBolt2Idx);
        }

        public int GetEquipBolt2ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipBolt2ID);
        }

        public int GetEquipHelmetIdx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipHelmetIdx);
        }

        public int GetEquipHelmetID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipHelmetID);
        }

        public int GetEquipChestIdx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipChestIdx);
        }

        public int GetEquipChestID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipChestID);
        }

        public int GetEquipGloveIdx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipGloveIdx);
        }

        public int GetEquipGloveID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipGloveID);
        }

        public int GetEquipPantsIdx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipPantsIdx);
        }

        public int GetEquipPantsID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipPantsID);
        }

        public int GetEquipHairIdx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipHairIdx);
        }

        public int GetEquipHairID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipHairID);
        }

        public int GetEquipRing1Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRing1Idx);
        }

        public int GetEquipRing1ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRing1ID);
        }

        public int GetEquipRing2Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRing2Idx);
        }

        public int GetEquipRing2ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipRing2ID);
        }

        public int GetEquipItem1Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem1Idx);
        }

        public int GetEquipItem1ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem1ID);
        }

        public int GetEquipItem2Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem2Idx);
        }

        public int GetEquipItem2ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem2ID);
        }

        public int GetEquipItem3Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem3Idx);
        }

        public int GetEquipItem3ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem3ID);
        }

        public int GetEquipItem4Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem4Idx);
        }

        public int GetEquipItem4ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem4ID);
        }

        public int GetEquipItem5Idx()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem5Idx);
        }

        public int GetEquipItem5ID()
        {
            return dsInterface.ReadInt32(pointers.CharData2 + (int)DSOffsets.CharData2.EquipItem5ID);
        }

        public int GetStoredMagic()
        {
            return dsInterface.ReadInt32(pointers.Unknown4 + (int)DSOffsets.Unknown4.StoredMagic);
        }

        public int GetStoredItem()
        {
            return dsInterface.ReadInt32(pointers.CharData1 + (int)DSOffsets.CharData1.StoredItem);
        }

        public int GetStoredQuantity()
        {
            return dsInterface.ReadInt32(pointers.MenuManager + (int)DSOffsets.MenuManager.QuantityDefault);
        }
        #endregion

        #region Misc Tab
        private static Dictionary<string, int> eventFlagGroups = new Dictionary<string, int>()
        {
            {"0", 0x00000},
            {"1", 0x00500},
            {"5", 0x05F00},
            {"6", 0x0B900},
            {"7", 0x11300},
        };

        private static Dictionary<string, int> eventFlagAreas = new Dictionary<string, int>()
        {
            {"000", 00},
            {"100", 01},
            {"101", 02},
            {"102", 03},
            {"110", 04},
            {"120", 05},
            {"121", 06},
            {"130", 07},
            {"131", 08},
            {"132", 09},
            {"140", 10},
            {"141", 11},
            {"150", 12},
            {"151", 13},
            {"160", 14},
            {"170", 15},
            {"180", 16},
            {"181", 17},
        };

        private int getEventFlagAddress(int ID, out uint mask)
        {
            string idString = ID.ToString("D8");
            if (idString.Length == 8)
            {
                string group = idString.Substring(0, 1);
                string area = idString.Substring(1, 3);
                int section = Int32.Parse(idString.Substring(4, 1));
                int number = Int32.Parse(idString.Substring(5, 3));

                if (eventFlagGroups.ContainsKey(group) && eventFlagAreas.ContainsKey(area))
                {
                    int offset = eventFlagGroups[group];
                    offset += eventFlagAreas[area] * 0x500;
                    offset += section * 128;
                    offset += (number - (number % 32)) / 8;

                    mask = 0x80000000 >> (number % 32);
                    return pointers.EventFlags + offset; ;
                }
            }
            throw new ArgumentException("Unknown event flag ID: " + ID);
        }

        public bool ReadEventFlag(int ID)
        {
            int address = getEventFlagAddress(ID, out uint mask);
            return dsInterface.ReadFlag32(address, mask);
        }

        public void WriteEventFlag(int ID, bool value)
        {
            int address = getEventFlagAddress(ID, out uint mask);
            dsInterface.WriteFlag32(address, mask, value);
        }
        #endregion

        #region Hotkeys Tab
        public void MenuKick()
        {
            dsInterface.WriteInt32(pointers.Unknown3 + (int)DSOffsets.Unknown3.MenuKick, 2);
        }

        public void MoveSwap()
        {
            dsInterface.WriteInt64(pointers.CharData2 + (int)DSOffsets.CharData2.Stance, 2);
        }

        public void ResetAnim()
        {
            dsInterface.WriteInt32(pointers.CharData1 + (int)DSOffsets.CharData1.ForcePlayAnimation1, 0);
        }

        public void HotkeyTest1()
        {
        }

        public void HotkeyTest2()
        {
        }
        #endregion
    }
}
