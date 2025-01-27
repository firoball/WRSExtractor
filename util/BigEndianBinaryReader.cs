using System;
using System.IO;
using System.Text;

namespace Acknex
{
    public class BigEndianBinaryReader : BinaryReader
    {
        private readonly byte[] _data2 = new byte[2];
        private readonly byte[] _data4 = new byte[4];
        private readonly byte[] _data8 = new byte[8];

        public BigEndianBinaryReader(System.IO.Stream stream) : base(stream) { }

        public BigEndianBinaryReader(System.IO.Stream stream, Encoding encoding, bool leaveOpen) : base(stream, encoding, leaveOpen) { }

        public override int ReadInt32()
        {
            Array.Clear(_data4, 0, 4);
            base.Read(_data4, 0, 4);
            Array.Reverse(_data4);
            return BitConverter.ToInt32(_data4, 0);
        }

        public override Int16 ReadInt16()
        {
            Array.Clear(_data2, 0, 2);
            base.Read(_data2, 0, 2);
            Array.Reverse(_data2);
            return BitConverter.ToInt16(_data2, 0);
        }

        public override Int64 ReadInt64()
        {
            Array.Clear(_data8, 0, 8);
            base.Read(_data8, 0, 8);
            Array.Reverse(_data8);
            return BitConverter.ToInt64(_data8, 0);
        }

        public override UInt32 ReadUInt32()
        {
            Array.Clear(_data4, 0, 4);
            base.Read(_data4, 0, 4);
            Array.Reverse(_data4);
            return BitConverter.ToUInt32(_data4, 0);
        }

        public override Single ReadSingle()
        {
            Array.Clear(_data4, 0, 4);
            base.Read(_data4, 0, 4);
            Array.Reverse(_data4);
            return BitConverter.ToSingle(_data4, 0);
        }

        //todo: 4???
        public override Double ReadDouble()
        {
            Array.Clear(_data8, 0, 8);
            base.Read(_data8, 0, 8);
            Array.Reverse(_data8);
            return BitConverter.ToDouble(_data8, 0);
        }

    }
}