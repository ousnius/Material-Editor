/* Copyright (c) 2015 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

/* Modified by ousnius
 * - removed Json (de)serialization and dependency
 * - removed Gibbed.IO dependency
 * - added binary serialization
 * - added Open/Save methods
 */

using System;
using System.ComponentModel;
using System.IO;

namespace Material_Editor
{
    public abstract class BaseMaterialFile
    {
        private readonly uint _Signature;

        #region Fields
        private uint _Version;
        private bool _TileU;
        private bool _TileV;
        private float _UOffset;
        private float _VOffset;
        private float _UScale = 1.0f;
        private float _VScale = 1.0f;
        private float _Alpha = 1.0f;
        private AlphaBlendModeType _AlphaBlendMode;
        private sbyte _AlphaTestRef;
        private bool _AlphaTest;
        private bool _ZBufferWrite = true;
        private bool _ZBufferTest = true;
        private bool _ScreenSpaceReflections;
        private bool _WetnessControlScreenSpaceReflections;
        private bool _Decal;
        private bool _TwoSided;
        private bool _DecalNoFade;
        private bool _NonOccluder;
        private bool _Refraction;
        private bool _RefractionFalloff;
        private float _RefractionPower;
        private bool _EnvironmentMapping;
        private float _EnvironmentMappingMaskScale = 1.0f;
        private bool _GrayscaleToPaletteColor;
        #endregion

        protected BaseMaterialFile(uint signature)
        {
            this._Signature = signature;
        }

        #region Properties
        public uint Version
        {
            get { return this._Version; }
            set { this._Version = value; }
        }

        public bool TileU
        {
            get { return this._TileU; }
            set { this._TileU = value; }
        }

        public bool TileV
        {
            get { return this._TileV; }
            set { this._TileV = value; }
        }

        public float UOffset
        {
            get { return this._UOffset; }
            set { this._UOffset = value; }
        }

        public float VOffset
        {
            get { return this._VOffset; }
            set { this._VOffset = value; }
        }

        [DefaultValue(1.0f)]
        public float UScale
        {
            get { return this._UScale; }
            set { this._UScale = value; }
        }

        [DefaultValue(1.0f)]
        public float VScale
        {
            get { return this._VScale; }
            set { this._VScale = value; }
        }

        [DefaultValue(1.0f)]
        public float Alpha
        {
            get { return this._Alpha; }
            set { this._Alpha = value; }
        }

        [DefaultValue(AlphaBlendModeType.Unknown)]
        public AlphaBlendModeType AlphaBlendMode
        {
            get { return this._AlphaBlendMode; }
            set { this._AlphaBlendMode = value; }
        }

        public sbyte AlphaTestRef
        {
            get { return this._AlphaTestRef; }
            set { this._AlphaTestRef = value; }
        }

        public bool AlphaTest
        {
            get { return this._AlphaTest; }
            set { this._AlphaTest = value; }
        }

        [DefaultValue(true)]
        public bool ZBufferWrite
        {
            get { return this._ZBufferWrite; }
            set { this._ZBufferWrite = value; }
        }

        [DefaultValue(true)]
        public bool ZBufferTest
        {
            get { return this._ZBufferTest; }
            set { this._ZBufferTest = value; }
        }

        public bool ScreenSpaceReflections
        {
            get { return this._ScreenSpaceReflections; }
            set { this._ScreenSpaceReflections = value; }
        }

        public bool WetnessControlScreenSpaceReflections
        {
            get { return this._WetnessControlScreenSpaceReflections; }
            set { this._WetnessControlScreenSpaceReflections = value; }
        }

        public bool Decal
        {
            get { return this._Decal; }
            set { this._Decal = value; }
        }

        public bool TwoSided
        {
            get { return this._TwoSided; }
            set { this._TwoSided = value; }
        }

        public bool DecalNoFade
        {
            get { return this._DecalNoFade; }
            set { this._DecalNoFade = value; }
        }

        public bool NonOccluder
        {
            get { return this._NonOccluder; }
            set { this._NonOccluder = value; }
        }

        public bool Refraction
        {
            get { return this._Refraction; }
            set { this._Refraction = value; }
        }

        public bool RefractionFalloff
        {
            get { return this._RefractionFalloff; }
            set { this._RefractionFalloff = value; }
        }

        public float RefractionPower
        {
            get { return this._RefractionPower; }
            set { this._RefractionPower = value; }
        }

        public bool EnvironmentMapping
        {
            get { return this._EnvironmentMapping; }
            set { this._EnvironmentMapping = value; }
        }

        [DefaultValue(1.0f)]
        public float EnvironmentMappingMaskScale
        {
            get { return this._EnvironmentMappingMaskScale; }
            set { this._EnvironmentMappingMaskScale = value; }
        }

        public bool GrayscaleToPaletteColor
        {
            get { return this._GrayscaleToPaletteColor; }
            set { this._GrayscaleToPaletteColor = value; }
        }
        #endregion

        public virtual void Deserialize(BinaryReader input)
        {
            var magic = input.ReadUInt32();
            if (magic != _Signature)
            {
                throw new FormatException();
            }

            this._Version = input.ReadUInt32();

            var tileFlags = input.ReadUInt32();
            this._TileU = (tileFlags & 2) != 0;
            this._TileV = (tileFlags & 1) != 0;
            this._UOffset = input.ReadSingle();
            this._VOffset = input.ReadSingle();
            this._UScale = input.ReadSingle();
            this._VScale = input.ReadSingle();

            this._Alpha = input.ReadSingle();
            var alphaBlendMode0 = input.ReadByte();
            var alphaBlendMode1 = input.ReadUInt32();
            var alphaBlendMode2 = input.ReadUInt32();
            this._AlphaBlendMode = ConvertAlphaBlendMode(alphaBlendMode0, alphaBlendMode1, alphaBlendMode2);
            this._AlphaTestRef = input.ReadSByte();
            this._AlphaTest = input.ReadBoolean();

            this._ZBufferWrite = input.ReadBoolean();
            this._ZBufferTest = input.ReadBoolean();
            this._ScreenSpaceReflections = input.ReadBoolean();
            this._WetnessControlScreenSpaceReflections = input.ReadBoolean();
            this._Decal = input.ReadBoolean();
            this._TwoSided = input.ReadBoolean();
            this._DecalNoFade = input.ReadBoolean();
            this._NonOccluder = input.ReadBoolean();

            this._Refraction = input.ReadBoolean();
            this._RefractionFalloff = input.ReadBoolean();
            this._RefractionPower = input.ReadSingle();

            this._EnvironmentMapping = input.ReadBoolean();
            this._EnvironmentMappingMaskScale = input.ReadSingle();

            this._GrayscaleToPaletteColor = input.ReadBoolean();
        }

        public virtual void Serialize(BinaryWriter output)
        {
            throw new NotImplementedException();
        }

        public bool Open(string fileName)
        {
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(file))
                    {
                        this.Deserialize(reader);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Save(string fileName)
        {
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(file))
                    {
                        this.Serialize(writer);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        protected static string ReadString(BinaryReader input)
        {
            var length = input.ReadUInt32();
            string str = new string(input.ReadChars((int)length));

            int index = str.LastIndexOf('\0');
            if (index >= 0)
                str = str.Remove(index, 1);

            return str;
        }

        protected static void WriteString(BinaryWriter output, string str)
        {
            var length = str.Length + 1;
            output.Write(length);
            output.Write((str + "\0").ToCharArray());
        }

        public enum AlphaBlendModeType
        {
            Unknown = 0,
            None,
            Standard,
            Additive,
            Multiplicative,
        }

        private static AlphaBlendModeType ConvertAlphaBlendMode(byte a, uint b, uint c)
        {
            if (a == 0 && b == 6 && c == 7)
            {
                return AlphaBlendModeType.Unknown;
            }
            else if (a == 0 && b == 0 && c == 0)
            {
                return AlphaBlendModeType.None;
            }
            else if (a == 1 && b == 6 && c == 7)
            {
                return AlphaBlendModeType.Standard;
            }
            else if (a == 1 && b == 6 && c == 0)
            {
                return AlphaBlendModeType.Additive;
            }
            else if (a == 1 && b == 4 && c == 1)
            {
                return AlphaBlendModeType.Multiplicative;
            }

            throw new NotSupportedException();
        }

        protected struct Color
        {
            public readonly float R;
            public readonly float G;
            public readonly float B;

            public Color(float r, float g, float b)
            {
                this.R = r;
                this.G = g;
                this.B = b;
            }

            public uint ToUInt32()
            {
                uint value = 0;
                value |= (byte)(this.R * 255);
                value <<= 8;
                value |= (byte)(this.G * 255);
                value <<= 8;
                value |= (byte)(this.B * 255);
                return value;
            }

            public static Color FromUInt32(uint value)
            {
                const float multiplier = 1.0f / 255;
                var b = (byte)(value & 0xFF);
                value >>= 8;
                var g = (byte)(value & 0xFF);
                value >>= 8;
                var r = (byte)(value & 0xFF);
                return new Color(r * multiplier, g * multiplier, b * multiplier);
            }

            public static Color Read(BinaryReader input)
            {
                var r = input.ReadSingle();
                var g = input.ReadSingle();
                var b = input.ReadSingle();
                return new Color(r, g, b);
            }

            public void Write(BinaryWriter output)
            {
                output.Write(R);
                output.Write(G);
                output.Write(B);
            }
        }
    }
}
