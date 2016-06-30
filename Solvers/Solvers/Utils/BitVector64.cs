using System;

namespace Solvers.Utils
{
    public struct BitVector64
    {
        /// <summary>
        /// Internal location for bits
        /// </summary>
        private ulong _bits;

        public BitVector64(ulong value)
        {
            _bits = value;
        }

        public BitVector64(BitVector64 value)
        {
            _bits = value._bits;
        }

        /// <summary>
        /// Number of bitflags set
        /// Source: http://stackoverflow.com/a/2709523
        /// </summary>
        public byte Count
        {
            get
            {
                ulong i = _bits - ((_bits >> 1) & 0x5555555555555555UL);
                i = (i & 0x3333333333333333UL) + ((i >> 2) & 0x3333333333333333UL);
                return (byte) (unchecked(((i + (i >> 4)) & 0xF0F0F0F0F0F0F0FUL)*0x101010101010101UL) >> 56);
            }
        }

        /// <summary>
        /// Get or set a bitflag
        /// Source: http://stackoverflow.com/a/47990
        /// </summary>
        public bool this[int index]
        {
            get
            {
                if (index < 0 || index > 63) throw new IndexOutOfRangeException($"Index smaller then 0, or larger then 63, index: {index}");
                return (_bits & ((ulong)1 << index)) != 0; //Compare that flag at index is set
            }
            set
            {
                if (index < 0 || index > 63) throw new IndexOutOfRangeException($"Index smaller then 0, or larger then 63, index: {index}");
                if (value)
                {
                    _bits |= (ulong)1 << index;
                }
                else
                {
                    _bits &= ~((ulong)1 << index);
                }
            }
        }

        /// <summary>
        /// & operator returns a new BitVector64 with the & operator executed on the bits
        /// </summary>
        public static BitVector64 operator &(BitVector64 one, BitVector64 other)
        {
            return new BitVector64(one._bits & other._bits);
        }

        /// <summary>
        /// | operator returns a new BitVector64 with the | operator executed on the bits
        /// </summary>
        public static BitVector64 operator |(BitVector64 one, BitVector64 other)
        {
            return new BitVector64(one._bits | other._bits);
        }

        /// <summary>
        /// ^ operator returns a new BitVector64 with the ^ operator executed on the bits
        /// </summary>
        public static BitVector64 operator ^(BitVector64 one, BitVector64 other)
        {
            return new BitVector64(one._bits ^ other._bits);
        }

        /// <summary>
        /// Print bitstring
        /// Source: http://www.dotnetperls.com/binary-representation
        /// </summary>
        public override string ToString()
        {
            char[] bits = new char[64];
            for (int i = 0; i < 64; i++)
            {
                if (this[i])
                {
                    bits[63-i] = '1';
                }
                else
                {
                    bits[63-i] = '0';
                }
            }
            return new string(bits);
        }
    }
}
