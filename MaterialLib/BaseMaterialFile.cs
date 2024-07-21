using System.Globalization;
using System.Runtime.Serialization;

namespace MaterialLib
{
    [DataContract]
    public abstract class BaseMaterialFile
    {
        private readonly uint _Signature;

        #region Fields
        protected virtual void SetDefaults()
        {
            Version = 2;
            TileU = true;
            TileV = true;
            UScale = 1.0f;
            VScale = 1.0f;
            Alpha = 1.0f;
            AlphaTestRef = 128;
            ZBufferWrite = true;
            ZBufferTest = true;
            EnvironmentMappingMaskScale = 1.0f;
            MaskWrites = MaskWriteFlags.ALBEDO | MaskWriteFlags.NORMAL | MaskWriteFlags.SPECULAR | MaskWriteFlags.AMBIENT_OCCLUSION | MaskWriteFlags.EMISSIVE | MaskWriteFlags.GLOSS;
        }
        #endregion

        protected BaseMaterialFile(uint signature)
        {
            _Signature = signature;
            SetDefaults();
        }

        #region Properties
        public uint Version { get; set; }

        [DataMember(Name = "bTileU")]
        public bool TileU { get; set; }

        [DataMember(Name = "bTileV")]
        public bool TileV { get; set; }

        [DataMember(Name = "fUOffset")]
        public float UOffset { get; set; }

        [DataMember(Name = "fVOffset")]
        public float VOffset { get; set; }

        [DataMember(Name = "fUScale")]
        public float UScale { get; set; }

        [DataMember(Name = "fVScale")]
        public float VScale { get; set; }

        [DataMember(Name = "fAlpha")]
        public float Alpha { get; set; }

        public AlphaBlendModeType AlphaBlendMode { get; set; }

        [DataMember(Name = "eAlphaBlendMode")]
        private string AlphaBlendModeString
        {
            get { return AlphaBlendMode.ToString(); }
            set
            {
                AlphaBlendMode = Enum.TryParse(value, true, out AlphaBlendModeType mode) ? mode : AlphaBlendModeType.None;
            }
        }

        [DataMember(Name = "fAlphaTestRef")]
        public byte AlphaTestRef { get; set; }

        [DataMember(Name = "bAlphaTest")]
        public bool AlphaTest { get; set; }

        [DataMember(Name = "bZBufferWrite")]
        public bool ZBufferWrite { get; set; }

        [DataMember(Name = "bZBufferTest")]
        public bool ZBufferTest { get; set; }

        [DataMember(Name = "bScreenSpaceReflections")]
        public bool ScreenSpaceReflections { get; set; }

        [DataMember(Name = "bWetnessControl_ScreenSpaceReflections")]
        public bool WetnessControlScreenSpaceReflections { get; set; }

        [DataMember(Name = "bDecal")]
        public bool Decal { get; set; }

        [DataMember(Name = "bTwoSided")]
        public bool TwoSided { get; set; }

        [DataMember(Name = "bDecalNoFade")]
        public bool DecalNoFade { get; set; }

        [DataMember(Name = "bNonOccluder")]
        public bool NonOccluder { get; set; }

        [DataMember(Name = "bRefraction")]
        public bool Refraction { get; set; }

        [DataMember(Name = "fRefractionFalloff")]
        public bool RefractionFalloff { get; set; }

        [DataMember(Name = "fRefractionPower")]
        public float RefractionPower { get; set; }

        [DataMember(Name = "bEnvironmentMapping")]
        public bool EnvironmentMapping { get; set; }

        [DataMember(Name = "fEnvironmentMappingMaskScale")]
        public float EnvironmentMappingMaskScale { get; set; }

        [DataMember(Name = "bDepthBias")]
        public bool DepthBias { get; set; }

        [DataMember(Name = "bGrayscaleToPaletteColor")]
        public bool GrayscaleToPaletteColor { get; set; }

        [DataMember(Name = "bWriteMaskAlbedo")]
        private bool WriteMaskAlbedo
        {
            get { return MaskWrites.HasFlag(MaskWriteFlags.ALBEDO); }
            set { MaskWrites |= MaskWriteFlags.ALBEDO; }
        }

        [DataMember(Name = "bWriteMaskNormal")]
        private bool WriteMaskNormal
        {
            get { return MaskWrites.HasFlag(MaskWriteFlags.NORMAL); }
            set { MaskWrites |= MaskWriteFlags.NORMAL; }
        }

        [DataMember(Name = "bWriteMaskSpecular")]
        private bool WriteMaskSpecular
        {
            get { return MaskWrites.HasFlag(MaskWriteFlags.SPECULAR); }
            set { MaskWrites |= MaskWriteFlags.SPECULAR; }
        }

        [DataMember(Name = "bWriteMaskAmbientOcclusion")]
        private bool WriteMaskAmbientOcclusion
        {
            get { return MaskWrites.HasFlag(MaskWriteFlags.AMBIENT_OCCLUSION); }
            set { MaskWrites |= MaskWriteFlags.AMBIENT_OCCLUSION; }
        }

        [DataMember(Name = "bWriteMaskEmissive")]
        private bool WriteMaskEmissive
        {
            get { return MaskWrites.HasFlag(MaskWriteFlags.EMISSIVE); }
            set { MaskWrites |= MaskWriteFlags.EMISSIVE; }
        }

        [DataMember(Name = "bWriteMaskGloss")]
        private bool WriteMaskGloss
        {
            get { return MaskWrites.HasFlag(MaskWriteFlags.GLOSS); }
            set { MaskWrites |= MaskWriteFlags.GLOSS; }
        }

        public MaskWriteFlags MaskWrites { get; set; }
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

            Version = input.ReadUInt32();

            var tileFlags = input.ReadUInt32();
            TileU = (tileFlags & 2) != 0;
            TileV = (tileFlags & 1) != 0;
            UOffset = input.ReadSingle();
            VOffset = input.ReadSingle();
            UScale = input.ReadSingle();
            VScale = input.ReadSingle();

            Alpha = input.ReadSingle();
            var alphaBlendMode0 = input.ReadByte();
            var alphaBlendMode1 = input.ReadUInt32();
            var alphaBlendMode2 = input.ReadUInt32();
            AlphaBlendMode = ConvertAlphaBlendMode(alphaBlendMode0, alphaBlendMode1, alphaBlendMode2);
            AlphaTestRef = input.ReadByte();
            AlphaTest = input.ReadBoolean();

            ZBufferWrite = input.ReadBoolean();
            ZBufferTest = input.ReadBoolean();
            ScreenSpaceReflections = input.ReadBoolean();
            WetnessControlScreenSpaceReflections = input.ReadBoolean();
            Decal = input.ReadBoolean();
            TwoSided = input.ReadBoolean();
            DecalNoFade = input.ReadBoolean();
            NonOccluder = input.ReadBoolean();

            Refraction = input.ReadBoolean();
            RefractionFalloff = input.ReadBoolean();
            RefractionPower = input.ReadSingle();

            if (Version < 10)
            {
                EnvironmentMapping = input.ReadBoolean();
                EnvironmentMappingMaskScale = input.ReadSingle();
            }
            else
            {
                DepthBias = input.ReadBoolean();
            }

            GrayscaleToPaletteColor = input.ReadBoolean();

            if (Version >= 6)
            {
                MaskWrites = (MaskWriteFlags)input.ReadByte();
            }
        }

        public virtual void Serialize(BinaryWriter output)
        {
            output.Write(_Signature);
            output.Write(Version);

            uint tileFlags = 0;
            if (TileU) tileFlags += 2;
            if (TileV) tileFlags += 1;
            output.Write(tileFlags);

            output.Write(UOffset);
            output.Write(VOffset);
            output.Write(UScale);
            output.Write(VScale);

            output.Write(Alpha);

            byte alphaBlendMode0 = 0;
            uint alphaBlendMode1 = 0;
            uint alphaBlendMode2 = 0;
            ConvertAlphaBlendMode(AlphaBlendMode, ref alphaBlendMode0, ref alphaBlendMode1, ref alphaBlendMode2);
            output.Write(alphaBlendMode0);
            output.Write(alphaBlendMode1);
            output.Write(alphaBlendMode2);

            output.Write(AlphaTestRef);
            output.Write(AlphaTest);

            output.Write(ZBufferWrite);
            output.Write(ZBufferTest);
            output.Write(ScreenSpaceReflections);
            output.Write(WetnessControlScreenSpaceReflections);
            output.Write(Decal);
            output.Write(TwoSided);
            output.Write(DecalNoFade);
            output.Write(NonOccluder);

            output.Write(Refraction);
            output.Write(RefractionFalloff);
            output.Write(RefractionPower);
            
            if (Version < 10)
            {
                output.Write(EnvironmentMapping);
                output.Write(EnvironmentMappingMaskScale);
            }
            else
            {
                output.Write(DepthBias);
            }

            output.Write(GrayscaleToPaletteColor);

            if (Version >= 6)
            {
                output.Write((byte)MaskWrites);
            }
        }

        public bool Open(FileStream file)
        {
            try
            {
                using BinaryReader reader = new(file);
                Deserialize(reader);
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
                using BinaryWriter writer = new(file);
                Serialize(writer);
                writer.Flush();
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
            string str = new(input.ReadChars((int)length));

            int index = str.LastIndexOf('\0');
            if (index >= 0)
                str = str.Remove(index, 1);

            return str;
        }

        protected static void WriteString(BinaryWriter output, string? str)
        {
            if (str != null)
            {
                int length = str.Length + 1;
                output.Write(length);
                output.Write((str + "\0").ToCharArray());
            }
            else
            {
                int length = 1;
                output.Write(length);
                output.Write("\0".ToCharArray());
            }
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

        protected readonly struct Color(float r, float g, float b)
        {
            public readonly float R = r;
            public readonly float G = g;
            public readonly float B = b;

            public uint ToUInt32()
            {
                uint value = 0;
                value |= (byte)(R * 255);
                value <<= 8;
                value |= (byte)(G * 255);
                value <<= 8;
                value |= (byte)(B * 255);
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
                if (text.StartsWith('#'))
                    text = text[1..];

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

        public enum MaskWriteFlags
        {
            ALBEDO = 1,
            NORMAL = 2,
            SPECULAR = 4,
            AMBIENT_OCCLUSION = 8,
            EMISSIVE = 16,
            GLOSS = 32
        }
    }
}
