using Binarysharp.Assemblers.Fasm;
using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DS_Gadget
{
    class DSInterface
    {
        private const uint PROCESS_ALL_ACCESS = 0x1F0FFF;
        private const uint MEM_COMMIT = 0x1000;
        private const uint MEM_RELEASE = 0x8000;
        private const uint PAGE_READWRITE = 0x4;

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(SafeProcessHandle hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, uint lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(SafeProcessHandle hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, uint lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr VirtualAllocEx(SafeProcessHandle hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        private static extern bool VirtualFreeEx(SafeProcessHandle hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);

        [DllImport("kernel32.dll")]
        private static extern IntPtr CreateRemoteThread(SafeProcessHandle hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        private static extern int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        public static DSInterface Attach(Process process)
        {
            DSInterface result = null;
            IntPtr handle = OpenProcess(PROCESS_ALL_ACCESS, false, (uint)process.Id);
            if (handle != IntPtr.Zero)
                result = new DSInterface(new SafeProcessHandle(handle, true));
            return result;
        }


        private SafeProcessHandle handle;

        private DSInterface(SafeProcessHandle setHandle)
        {
            handle = setHandle;
        }

        public void Close()
        {
            handle.Close();
        }

        private IntPtr VirtualAllocEx(int size)
        {
            return VirtualAllocEx(handle, IntPtr.Zero, (uint)size, MEM_COMMIT, PAGE_READWRITE);
        }

        private bool VirtualFreeEx(IntPtr address)
        {
            return VirtualFreeEx(handle, address, 0, MEM_RELEASE);
        }

        private void WriteProcessMemory(IntPtr address, byte[] bytes)
        {
            WriteProcessMemory(handle, address, bytes, (uint)bytes.Length, 0);
        }

        private void WriteProcessMemory(int address, byte[] bytes)
        {
            WriteProcessMemory((IntPtr)address, bytes);
        }

        private IntPtr CreateRemoteThread(IntPtr address)
        {
            return CreateRemoteThread(handle, IntPtr.Zero, 0, address, IntPtr.Zero, 0, IntPtr.Zero);
        }

        private byte[] ReadProcessMemory(int address, uint size)
        {
            byte[] result = new byte[size];
            ReadProcessMemory(handle, (IntPtr)address, result, size, 0);
            return result;
        }


        public void AsmExecute(string asm)
        {
            // Assemble once to determine size
            byte[] bytes = FasmNet.Assemble("use32\norg 0x0\n" + asm);
            IntPtr insertPtr = VirtualAllocEx(bytes.Length);
            // Then rebase and inject
            // Note: you can't use String.Format here because IntPtr is not IFormattable
            bytes = FasmNet.Assemble("use32\norg 0x" + insertPtr.ToString("X") + "\n" + asm);
            WriteProcessMemory(insertPtr, bytes);
            IntPtr thread = CreateRemoteThread(insertPtr);
            WaitForSingleObject(thread, 0xFFFFFFFF);
            VirtualFreeEx(insertPtr);
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

        public double ReadDouble(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 8);
            return BitConverter.ToDouble(bytes, 0);
        }

        public short ReadInt16(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 2);
            return BitConverter.ToInt16(bytes, 0);
        }

        public ushort ReadUInt16(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 2);
            return BitConverter.ToUInt16(bytes, 0);
        }

        public int ReadInt32(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        public uint ReadUInt32(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 4);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public long ReadInt64(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 8);
            return BitConverter.ToInt64(bytes, 0);
        }

        public ulong ReadUInt64(int address)
        {
            byte[] bytes = ReadProcessMemory(address, 8);
            return BitConverter.ToUInt64(bytes, 0);
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

        public void WriteInt16(int address, short value)
        {
            WriteProcessMemory(address, BitConverter.GetBytes(value));
        }

        public void WriteUInt16(int address, ushort value)
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

        public void WriteUInt64(int address, ulong value)
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
