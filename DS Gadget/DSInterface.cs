using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DS_Gadget
{
    class DSInterface
    {
        private const uint PROCESS_ALL_ACCESS = 0x001F0FFF;
        private const uint MEM_COMMIT = 4096;
        private const uint PAGE_READWRITE = 4;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, uint lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, uint lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);


        public static DSInterface Attach(Process process)
        {
            DSInterface result = null;
            IntPtr handle = OpenProcess(PROCESS_ALL_ACCESS, false, (uint)process.Id);
            if (handle != IntPtr.Zero)
                result = new DSInterface(handle);
            return result;
        }

        private IntPtr handle;

        private DSInterface(IntPtr setHandle)
        {
            handle = setHandle;
        }

        public void Close()
        {
            CloseHandle(handle);
        }

        public IntPtr VirtualAllocEx(int size)
        {
            return VirtualAllocEx(handle, IntPtr.Zero, (uint)size, MEM_COMMIT, PAGE_READWRITE);
        }

        public void WriteProcessMemory(IntPtr address, byte[] bytes)
        {
            WriteProcessMemory(handle, address, bytes, (uint)bytes.Length, 0);
        }

        public void WriteProcessMemory(int address, byte[] bytes)
        {
            WriteProcessMemory((IntPtr)address, bytes);
        }

        public void WriteProcessMemory(IntPtr address, byte[] bytes, int size)
        {
            WriteProcessMemory(handle, address, bytes, (uint)size, 0);
        }

        public void CreateRemoteThread(IntPtr address)
        {
            IntPtr threadID = new IntPtr();
            CreateRemoteThread(handle, IntPtr.Zero, 0, address, IntPtr.Zero, 0, threadID);
        }

        private byte[] ReadProcessMemory(int address, uint size)
        {
            byte[] result = new byte[size];
            ReadProcessMemory(handle, (IntPtr)address, result, size, 0);
            return result;
        }

        public bool ReadBool(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 1);
            return BitConverter.ToBoolean(bytes, 0);
        }

        public byte ReadByte(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 1);
            return bytes[0];
        }

        public byte[] ReadBytes(int address, int size)
        {
            return ReadProcessMemory(address, (uint)size);
        }

        public float ReadFloat(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 4);
            return BitConverter.ToSingle(bytes, 0);
        }

        public Int32 ReadInt32(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        public UInt32 ReadUInt32(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 4);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public Int64 ReadInt64(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 8);
            return BitConverter.ToInt64(bytes, 0);
        }

        public bool ReadFlag32(int address, uint mask)
        {
            byte[] bytes = ReadProcessMemory(address, 4);
            uint flags = BitConverter.ToUInt32(bytes, 0);
            return (flags & mask) != 0;
        }

        public void WriteBool(int address, bool value)
        {
            WriteProcessMemory(address, BitConverter.GetBytes(value));
        }

        public void WriteByte(int address, byte value)
        {
            WriteProcessMemory(address, BitConverter.GetBytes(value));
        }

        public void WriteBytes(int address, byte[] bytes)
        {
            WriteProcessMemory(address, bytes);
        }

        public void WriteFloat(int address, float value)
        {
            WriteProcessMemory(address, BitConverter.GetBytes(value));
        }

        public void WriteInt32(int address, int value)
        {
            WriteProcessMemory(address, BitConverter.GetBytes(value));
        }

        public void WriteUInt32(int address, uint value)
        {
            WriteProcessMemory(address, BitConverter.GetBytes(value));
        }

        public void WriteInt64(int address, long value)
        {
            WriteProcessMemory(address, BitConverter.GetBytes(value));
        }

        public void WriteFlag32(int address, uint mask, bool enable)
        {
            uint flags = ReadUInt32(address);
            if (enable)
                flags |= mask;
            else
                flags &= ~mask;
            WriteUInt32(address, flags);
        }
    }
}
