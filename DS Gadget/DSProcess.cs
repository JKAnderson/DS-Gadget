using System;
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

        public static DSProcess Attach(Process candidate, out string versionName, out bool valid)
        {
            DSProcess result = null;
            versionName = "Unknown";
            valid = false;
            DSInterface dsInterface = DSInterface.Attach(candidate);
            if (dsInterface != null)
            {
                uint version = dsInterface.ReadUInt32(DSOffsets.CheckVersion);
                if (version == VERSION_RELEASE)
                {
                    result = new DSProcess(candidate, dsInterface, true);
                    versionName = "Steam";
                    valid = true;
                }
                else if (version == VERSION_DEBUG)
                {
                    result = new DSProcess(candidate, dsInterface, false);
                    versionName = "Debug";
                }
                else if (version == VERSION_BETA)
                {
                    result = new DSProcess(candidate, dsInterface, false);
                    versionName = "Beta";
                }
            }
            return result;
        }


        private Process process;
        private DSInterface dsInterface;
        private bool enabled;

        public DSProcess(Process setProcess, DSInterface setDSInterface, bool setEnabled)
        {
            process = setProcess;
            dsInterface = setDSInterface;
            enabled = setEnabled;
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
            if (enabled)
            {
                return getCharData1() != 0;
            }
            else
                return false;
        }

        public bool Focused()
        {
            IntPtr hwnd = GetForegroundWindow();
            GetWindowThreadProcessId(hwnd, out uint pid);
            return pid == process.Id;
        }

        private void ReplaceBytes(byte[] victim, int value, int index)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Copy(bytes, 0, victim, index, bytes.Length);
        }

        public void Test()
        {
            bool flag = dsInterface.ReadFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.FirstPerson);
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.FirstPerson, !flag);
        }

        #region Pointer loading
        private int charData1, charMapData, animData, charPosData, charData2, graphicsData, worldState, unknown1, unknown2;

        public void LoadPointers()
        {
            charData1 = getCharData1();

            charMapData = dsInterface.ReadInt32(charData1 + (int)DSOffsets.CharData1.CharMapDataPtr);

            animData = dsInterface.ReadInt32(charMapData + (int)DSOffsets.CharMapData.AnimDataPtr);

            charPosData = dsInterface.ReadInt32(charMapData + (int)DSOffsets.CharMapData.CharPosDataPtr);

            int pointer = dsInterface.ReadInt32(DSOffsets.CharData2Ptr);
            charData2 = dsInterface.ReadInt32(pointer + DSOffsets.CharData2Ptr2);

            pointer = dsInterface.ReadInt32(DSOffsets.GraphicsDataPtr);
            graphicsData = dsInterface.ReadInt32(pointer + DSOffsets.GraphicsDataPtr2);

            worldState = dsInterface.ReadInt32(DSOffsets.WorldStatePtr);

            unknown1 = dsInterface.ReadInt32(DSOffsets.Unknown1Ptr);

            unknown2 = dsInterface.ReadInt32(DSOffsets.Unknown2Ptr);
        }

        // Also used to check if game is loaded
        private int getCharData1()
        {
            int pointer = dsInterface.ReadInt32(DSOffsets.CharData1Ptr);
            pointer = dsInterface.ReadInt32(pointer + DSOffsets.CharData1Ptr2);
            return dsInterface.ReadInt32(pointer + DSOffsets.CharData1Ptr3);
        }
        #endregion

        #region Player Tab
        public float GetHP()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.HP);
        }

        public float GetHPMax()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.HPMax);
        }

        public float GetHPModMax()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.HPModMax);
        }

        public float GetStam()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Stamina);
        }

        public float GetStamMax()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.StaminaMax);
        }

        public float GetStamModMax()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.StaminaModMax);
        }

        public int GetPhantomType()
        {
            return dsInterface.ReadInt32(charData1 + (int)DSOffsets.CharData1.PhantomType);
        }

        public void SetPhantomType(int value)
        {
            dsInterface.WriteInt32(charData1 + (int)DSOffsets.CharData1.PhantomType, value);
        }

        public int GetTeamType()
        {
            return dsInterface.ReadInt32(charData1 + (int)DSOffsets.CharData1.TeamType);
        }

        public void SetTeamType(int value)
        {
            dsInterface.WriteInt32(charData1 + (int)DSOffsets.CharData1.TeamType, value);
        }

        public int GetWorld()
        {
            return dsInterface.ReadByte(unknown1 + (int)DSOffsets.Unknown1.World);
        }

        public int GetArea()
        {
            return dsInterface.ReadByte(unknown1 + (int)DSOffsets.Unknown1.Area);
        }

        public void SetPosLock(bool enable)
        {
            if (enable)
            {
                dsInterface.WriteBytes(DSOffsets.PosLock1, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 });
                dsInterface.WriteBytes(DSOffsets.PosLock2, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 });
            }
            else
            {
                dsInterface.WriteBytes(DSOffsets.PosLock1, new byte[] { 0x66, 0x0F, 0xD6, 0x46, 0x10 });
                dsInterface.WriteBytes(DSOffsets.PosLock2, new byte[] { 0x66, 0x0F, 0xD6, 0x46, 0x18 });
            }
        }

        public void SetPos(float x, float y, float z)
        {
            dsInterface.WriteFloat(charPosData + (int)DSOffsets.CharPosData.PosX, x);
            dsInterface.WriteFloat(charPosData + (int)DSOffsets.CharPosData.PosY, y);
            dsInterface.WriteFloat(charPosData + (int)DSOffsets.CharPosData.PosZ, z);
        }

        public float GetPosX()
        {
            return dsInterface.ReadFloat(charPosData + (int)DSOffsets.CharPosData.PosX);
        }

        public float GetPosY()
        {
            return dsInterface.ReadFloat(charPosData + (int)DSOffsets.CharPosData.PosY);
        }

        public float GetPosZ()
        {
            return dsInterface.ReadFloat(charPosData + (int)DSOffsets.CharPosData.PosZ);
        }

        public float GetPosAngle()
        {
            return dsInterface.ReadFloat(charPosData + (int)DSOffsets.CharPosData.PosAngle);
        }

        public float GetPosStableX()
        {
            return dsInterface.ReadFloat(worldState + (int)DSOffsets.WorldState.PosStableX);
        }

        public float GetPosStableY()
        {
            return dsInterface.ReadFloat(worldState + (int)DSOffsets.WorldState.PosStableY);
        }

        public float GetPosStableZ()
        {
            return dsInterface.ReadFloat(worldState + (int)DSOffsets.WorldState.PosStableZ);
        }

        public float GetPosStableAngle()
        {
            return dsInterface.ReadFloat(worldState + (int)DSOffsets.WorldState.PosStableAngle);
        }

        public void PosWarp(float x, float y, float z, float angle)
        {
            dsInterface.WriteFloat(charMapData + (int)DSOffsets.CharMapData.WarpX, x);
            dsInterface.WriteFloat(charMapData + (int)DSOffsets.CharMapData.WarpY, y);
            dsInterface.WriteFloat(charMapData + (int)DSOffsets.CharMapData.WarpZ, z);
            dsInterface.WriteFloat(charMapData + (int)DSOffsets.CharMapData.WarpAngle, angle);
            dsInterface.WriteBool(charMapData + (int)DSOffsets.CharMapData.Warp, true);
        }

        public void SetGravity(bool enable)
        {
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetDisableGravity, !enable);
        }

        public void SetCollision(bool enable)
        {
            dsInterface.WriteFlag32(charMapData + (int)DSOffsets.CharMapData.CharMapFlags, (uint)DSOffsets.CharMapFlags.DisableMapHit, !enable);
        }

        public bool GetDeathCam()
        {
            return dsInterface.ReadBool(unknown2 + (int)DSOffsets.Unknown2.DeathCam);
        }

        public void SetDeathCam(bool enable)
        {
            dsInterface.WriteBool(unknown2 + (int)DSOffsets.Unknown2.DeathCam, enable);
        }

        public int GetBonfire()
        {
            return dsInterface.ReadInt32(worldState + (int)DSOffsets.WorldState.LastBonfire);
        }

        public void SetBonfire(int id)
        {
            dsInterface.WriteInt32(worldState + (int)DSOffsets.WorldState.LastBonfire, id);
        }

        public void SetSpeed(float speed)
        {
            dsInterface.WriteFloat(animData + (int)DSOffsets.AnimData.PlaySpeed, speed);
        }
        #endregion

        #region Stats Tab
        public int GetClass()
        {
            return dsInterface.ReadByte(charData2 + (int)DSOffsets.CharData2.Class);
        }
        public void SetClass(byte value)
        {
            dsInterface.WriteByte(charData2 + (int)DSOffsets.CharData2.Class, value);
        }

        public long GetSoulLevel()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.SoulLevel);
        }
        public void SetSoulLevel(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.SoulLevel, value);
        }

        public int GetHumanity()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Humanity);
        }
        public void SetHumanity(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Humanity, value);
        }

        public long GetSouls()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Souls);
        }
        public void SetSouls(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Souls, value);
        }

        public long GetVitality()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Vitality);
        }
        public void SetVitality(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Vitality, value);
        }

        public long GetAttunement()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Attunement);
        }
        public void SetAttunement(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Attunement, value);
        }

        public long GetEndurance()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Endurance);
        }
        public void SetEndurance(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Endurance, value);
        }

        public long GetStrength()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Strength);
        }
        public void SetStrength(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Strength, value);
        }

        public long GetDexterity()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Dexterity);
        }
        public void SetDexterity(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Dexterity, value);
        }

        public long GetResistance()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Resistance);
        }
        public void SetResistance(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Resistance, value);
        }

        public long GetIntelligence()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Intelligence);
        }
        public void SetIntelligence(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Intelligence, value);
        }

        public long GetFaith()
        {
            return dsInterface.ReadInt32(charData2 + (int)DSOffsets.CharData2.Faith);
        }
        public void SetFaith(int value)
        {
            dsInterface.WriteInt32(charData2 + (int)DSOffsets.CharData2.Faith, value);
        }
        #endregion

        #region Cheats Tab
        public void SetPlayerDeadMode(bool enable)
        {
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetDeadMode, enable);
        }

        public void SetPlayerNoDamage(bool enable)
        {
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoDamage, enable);
        }

        public void SetPlayerNoHit(bool enable)
        {
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoHit, enable);
        }

        public void SetPlayerNoStamina(bool enable)
        {
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoStamConsume, enable);
        }

        public void SetPlayerSuperArmor(bool enable)
        {
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetSuperArmor, enable);
        }

        public void SetPlayerNoGoods(bool enable)
        {
            dsInterface.WriteFlag32(charData1 + (int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoGoodsConsume, enable);
        }

        public void SetAllNoMagic(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoMagicQtyConsume, enable);
        }

        public void SetNoDead(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.PlayerNoDead, enable);
        }

        public void SetExterminate(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.PlayerExterminate, enable);
        }

        public void SetAllStamina(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoStaminaConsume, enable);
        }

        public void SetAllMP(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoMPConsume, enable);
        }

        public void SetAllAmmo(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoArrowConsume, enable);
        }

        public void SetHide(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.PlayerHide, enable);
        }

        public void SetSilence(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.PlayerSilence, enable);
        }

        public void SetAllNoDead(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoDead, enable);
        }

        public void SetAllNoDamage(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoDamage, enable);
        }

        public void SetAllNoHit(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoHit, enable);
        }

        public void SetAllNoAttack(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoAttack, enable);
        }

        public void SetAllNoMove(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoMove, enable);
        }

        public void SetAllNoUpdateAI(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.AllNoUpdateAI, enable);
        }
        #endregion

        #region Graphics Tab
        public void DrawBounding(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.DrawBoundingBoxes, enable);
        }

        public void DrawSpriteMasks(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.DepthDraw_DepthTexEdge, enable);
        }

        public void DrawTextures(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.DrawTextures, enable);
        }

        public void DrawSprites(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.NormalDraw_TexEdge, enable);
        }

        public void DrawTrans(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.NormalDraw_Trans, enable);
        }

        public void DrawShadows(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.DrawShadows, enable);
        }

        public void DrawSpriteShadows(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.DrawSpriteShadows, enable);
        }

        public void DrawMap(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.DrawMap, enable);
        }

        public void DrawCreatures(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.DrawCreatures, enable);
        }

        public void DrawObjects(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.DrawObjects, enable);
        }

        public void DrawSFX(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.DrawSFX, enable);
        }

        public void DrawCompassLarge(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.CompassLarge, enable);
        }

        public void DrawCompassSmall(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.CompassSmall, enable);
        }

        public void DrawAltimeter(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.Altimeter, enable);
        }

        public void DrawNodes(bool enable)
        {
            dsInterface.WriteBool(DSOffsets.NodeGraph, enable);
        }

        public void OverrideFilter(bool enable)
        {
            dsInterface.WriteBool(graphicsData + (int)DSOffsets.GraphicsData.EnableFilter, enable);
        }

        public void SetBrightness(float brightnessR, float brightnessG, float brightnessB)
        {
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.BrightnessR, brightnessR);
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.BrightnessG, brightnessG);
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.BrightnessB, brightnessB);
        }

        public void SetContrast(float contrastR, float contrastG, float contrastB)
        {
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.ContrastR, contrastR);
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.ContrastG, contrastG);
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.ContrastB, contrastB);
        }

        public void SetSaturation(float saturation)
        {
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.Saturation, saturation);
        }

        public void SetHue(float hue)
        {
            dsInterface.WriteFloat(graphicsData + (int)DSOffsets.GraphicsData.Hue, hue);
        }
        #endregion

        #region Items Tab
        public void DropItem(int category, int itemID, int count)
        {
            byte[] bytes =
            {
                0xBD, 0x00, 0x00, 0x00, 0x00, 0xBB, 0xF0, 0x00,
                0x00, 0x00, 0xB9, 0xFF, 0xFF, 0xFF, 0xFF, 0xBA,
                0x00, 0x00, 0x00, 0x00, 0xA1, 0xD0, 0x86, 0x37,
                0x01, 0x89, 0xA8, 0x28, 0x08, 0x00, 0x00, 0x89,
                0x98, 0x2C, 0x08, 0x00, 0x00, 0x89, 0x88, 0x30,
                0x08, 0x00, 0x00, 0x89, 0x90, 0x34, 0x08, 0x00,
                0x00, 0xA1, 0xBC, 0xD6, 0x37, 0x01, 0x50, 0xE8,
                0x00, 0x00, 0x00, 0x00, 0xC3
            };

            ReplaceBytes(bytes, category, (int)DSOffsets.DropItem.Category);
            ReplaceBytes(bytes, itemID, (int)DSOffsets.DropItem.ItemID);
            ReplaceBytes(bytes, count, (int)DSOffsets.DropItem.Count);
            ReplaceBytes(bytes, 0x13786D0, (int)DSOffsets.DropItem.Ptr1);
            ReplaceBytes(bytes, 0x137D6BC, (int)DSOffsets.DropItem.Ptr2);

            IntPtr insertPtr = dsInterface.VirtualAllocEx(1024);
            ReplaceBytes(bytes, 0 - ((int)insertPtr + 0x3C - 0xDC8C60), (int)DSOffsets.DropItem.Jump);

            dsInterface.WriteProcessMemory(insertPtr, bytes, 1024);
            dsInterface.CreateRemoteThread(insertPtr);
        }
        #endregion

        #region Hotkeys Tab
        public void MoveSwap()
        {
            dsInterface.WriteInt64(charData2 + (int)DSOffsets.CharData2.Stance, 2);
        }

        public void ResetAnim()
        {
            dsInterface.WriteInt32(charData1 + (int)DSOffsets.CharData1.ForcePlayAnimation1, 0);
        }
        #endregion
    }
}
