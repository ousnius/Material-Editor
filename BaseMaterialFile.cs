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
 * - removed JSON serialization
 * - removed Gibbed.IO dependency
 * - added binary serialization
 * - added Open/Save methods
 */

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Globalization;

namespace Material_Editor
{
    [DataContract]
    public abstract class BaseMaterialFile
    {
        private readonly uint _Signature;

        #region Fields
        private uint _Version;
        private bool _TileU;
        private bool _TileV;
        private float _UOffset;
        private float _VOffset;
        private float _UScale;
        private float _VScale;
        private float _Alpha;
        private AlphaBlendModeType _AlphaBlendMode;
        private byte _AlphaTestRef;
        private bool _AlphaTest;
        private bool _ZBufferWrite;
        private bool _ZBufferTest;
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
        private float _EnvironmentMappingMaskScale;
        private bool _GrayscaleToPaletteColor;

        protected virtual void SetDefaults()
        {
            _Version = 1;
            _TileU = true;
            _TileV = true;
            _UScale = 1.0f;
            _VScale = 1.0f;
            _Alpha = 1.0f;
            _AlphaTestRef = 128;
            _ZBufferWrite = true;
            _ZBufferTest = true;
            _EnvironmentMappingMaskScale = 1.0f;
        }
        #endregion

        protected BaseMaterialFile(uint signature)
        {
            this._Signature = signature;
            SetDefaults();
        }

        #region Properties
        public uint Version
        {
            get { return this._Version; }
            set { this._Version = value; }
        }

        [DataMember(Name = "bTileU")]
        public bool TileU
        {
            get { return this._TileU; }
            set { this._TileU = value; }
        }

        [DataMember(Name = "bTileV")]
        public bool TileV
        {
            get { return this._TileV; }
            set { this._TileV = value; }
        }

        [DataMember(Name = "fUOffset")]
        public float UOffset
        {
            get { return this._UOffset; }
            set { this._UOffset = value; }
        }

        [DataMember(Name = "fVOffset")]
        public float VOffset
        {
            get { return this._VOffset; }
            set { this._VOffset = value; }
        }

        [DataMember(Name = "fUScale")]
        public float UScale
        {
            get { return this._UScale; }
            set { this._UScale = value; }
        }

        [DataMember(Name = "fVScale")]
        public float VScale
        {
            get { return this._VScale; }
            set { this._VScale = value; }
        }

        [DataMember(Name = "fAlpha")]
        public float Alpha
        {
            get { return this._Alpha; }
            set { this._Alpha = value; }
        }

        public AlphaBlendModeType AlphaBlendMode
        {
            get { return this._AlphaBlendMode; }
            set { this._AlphaBlendMode = value; }
        }

        [DataMember(Name = "eAlphaBlendMode")]
        string AlphaBlendModeString
        {
            get { return _AlphaBlendMode.ToString(); }
            set
            {
                AlphaBlendModeType mode;
                _AlphaBlendMode = Enum.TryParse(value, true, out mode) ? mode : AlphaBlendModeType.None;
            }
        }

        [DataMember(Name = "fAlphaTestRef")]
        public byte AlphaTestRef
        {
            get { return this._AlphaTestRef; }
            set { this._AlphaTestRef = value; }
        }

        [DataMember(Name = "bAlphaTest")]
        public bool AlphaTest
        {
            get { return this._AlphaTest; }
            set { this._AlphaTest = value; }
        }

        [DataMember(Name = "bZBufferWrite")]
        public bool ZBufferWrite
        {
            get { return this._ZBufferWrite; }
            set { this._ZBufferWrite = value; }
        }

        [DataMember(Name = "bZBufferTest")]
        public bool ZBufferTest
        {
            get { return this._ZBufferTest; }
            set { this._ZBufferTest = value; }
        }

        [DataMember(Name = "bScreenSpaceReflections")]
        public bool ScreenSpaceReflections
        {
            get { return this._ScreenSpaceReflections; }
            set { this._ScreenSpaceReflections = value; }
        }

        [DataMember(Name = "bWetnessControl_ScreenSpaceReflections")]
        public bool WetnessControlScreenSpaceReflections
        {
            get { return this._WetnessControlScreenSpaceReflections; }
            set { this._WetnessControlScreenSpaceReflections = value; }
        }

        [DataMember(Name = "bDecal")]
        public bool Decal
        {
            get { return this._Decal; }
            set { this._Decal = value; }
        }

        [DataMember(Name = "bTwoSided")]
        public bool TwoSided
        {
            get { return this._TwoSided; }
            set { this._TwoSided = value; }
        }

        [DataMember(Name = "bDecalNoFade")]
        public bool DecalNoFade
        {
            get { return this._DecalNoFade; }
            set { this._DecalNoFade = value; }
        }

        [DataMember(Name = "bNonOccluder")]
        public bool NonOccluder
        {
            get { return this._NonOccluder; }
            set { this._NonOccluder = value; }
        }

        [DataMember(Name = "bRefraction")]
        public bool Refraction
        {
            get { return this._Refraction; }
            set { this._Refraction = value; }
        }

        [DataMember(Name = "fRefractionFalloff")]
        public bool RefractionFalloff
        {
            get { return this._RefractionFalloff; }
            set { this._RefractionFalloff = value; }
        }

        [DataMember(Name = "fRefractionPower")]
        public float RefractionPower
        {
            get { return this._RefractionPower; }
            set { this._RefractionPower = value; }
        }

        [DataMember(Name = "bEnvironmentMapping")]
        public bool EnvironmentMapping
        {
            get { return this._EnvironmentMapping; }
            set { this._EnvironmentMapping = value; }
        }

        [DataMember(Name = "fEnvironmentMappingMaskScale")]
        public float EnvironmentMappingMaskScale
        {
            get { return this._EnvironmentMappingMaskScale; }
            set { this._EnvironmentMappingMaskScale = value; }
        }

        [DataMember(Name = "bGrayscaleToPaletteColor")]
        public bool GrayscaleToPaletteColor
        {
            get { return this._GrayscaleToPaletteColor; }
            set { this._GrayscaleToPaletteColor = value; }
        }
        #endregion

        [OnDeserializing]
        private void OnDeserializing(StreamingContext c)
        {
            SetDefaults();
        }

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
            this._AlphaTestRef = input.ReadByte();
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
            output.Write(this._Signature);
            output.Write(this._Version);

            uint tileFlags = 0;
            if (this._TileU) tileFlags += 2;
            if (this._TileV) tileFlags += 1;
            output.Write(tileFlags);

            output.Write(this._UOffset);
            output.Write(this._VOffset);
            output.Write(this._UScale);
            output.Write(this._VScale);

            output.Write(this._Alpha);

            byte alphaBlendMode0 = 0;
            uint alphaBlendMode1 = 0;
            uint alphaBlendMode2 = 0;
            ConvertAlphaBlendMode(this._AlphaBlendMode, ref alphaBlendMode0, ref alphaBlendMode1, ref alphaBlendMode2);
            output.Write(alphaBlendMode0);
            output.Write(alphaBlendMode1);
            output.Write(alphaBlendMode2);

            output.Write(this._AlphaTestRef);
            output.Write(this._AlphaTest);

            output.Write(this._ZBufferWrite);
            output.Write(this._ZBufferTest);
            output.Write(this._ScreenSpaceReflections);
            output.Write(this._WetnessControlScreenSpaceReflections);
            output.Write(this._Decal);
            output.Write(this._TwoSided);
            output.Write(this._DecalNoFade);
            output.Write(this._NonOccluder);

            output.Write(this._Refraction);
            output.Write(this._RefractionFalloff);
            output.Write(this._RefractionPower);

            output.Write(this._EnvironmentMapping);
            output.Write(this._EnvironmentMappingMaskScale);

            output.Write(this._GrayscaleToPaletteColor);
        }

        public bool Open(FileStream file)
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(file))
                {
                    this.Deserialize(reader);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Save(FileStream file)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    this.Serialize(writer);
                    writer.Flush();
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

        private static void ConvertAlphaBlendMode(AlphaBlendModeType type, ref byte a, ref uint b, ref uint c)
        {
            if (type == AlphaBlendModeType.Unknown)
            {
                a = 0;
                b = 6;
                c = 7;
            }
            else if (type == AlphaBlendModeType.None)
            {
                a = 0;
                b = 0;
                c = 0;
            }
            else if (type == AlphaBlendModeType.Standard)
            {
                a = 1;
                b = 6;
                c = 7;
            }
            else if (type == AlphaBlendModeType.Additive)
            {
                a = 1;
                b = 6;
                c = 0;
            }
            else if (type == AlphaBlendModeType.Multiplicative)
            {
                a = 1;
                b = 4;
                c = 1;
            }
            else
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

            public string ToHexString()
            {
                return string.Format("#{0:x6}", ToUInt32() & 0xFFFFFFu);
            }

            public static Color FromHexString(string str)
            {
                var text = str.ToLowerInvariant();
                if (text.StartsWith("#") == true)
                    text = text.Substring(1);

                if (text == "000")
                    return FromUInt32(0x000000u);

                if (text == "fff")
                    return FromUInt32(0xFFFFFFu);

                if (text.Length == 3)
                {
                    uint val = uint.Parse(text, NumberStyles.AllowHexSpecifier);
                    val = ((val & 0xF00) << 8) | ((val & 0x0F0) << 4) | ((val & 0x00F) << 0);
                    val |= val << 4;
                    return FromUInt32(val);
                }

                if (text.Length == 6)
                    return FromUInt32(uint.Parse(text, NumberStyles.AllowHexSpecifier));

                return new Color(1.0f, 1.0f, 1.0f);
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
