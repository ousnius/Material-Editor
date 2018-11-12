using System;
using System.IO;
using System.Runtime.Serialization;

namespace Material_Editor
{
    [DataContract]
    public class BGEM : BaseMaterialFile
    {
        public const uint Signature = 0x4D454742u;

        #region Fields
        protected override void SetDefaults()
        {
            base.SetDefaults();

            BaseTexture = "";
            GrayscaleTexture = "";
            EnvmapTexture = "";
            NormalTexture = "";
            EnvmapMaskTexture = "";
            SpecularTexture = "";
            LightingTexture = "";
            DistanceFieldAlphaTexture = "";
            BaseColor = 0xFFFFFFFFu;
            BaseColorScale = 1.0f;
            FalloffStartAngle = 1.0f;
            FalloffStopAngle = 1.0f;
            LightingInfluence = 1.0f;
            SoftDepth = 100.0f;
            EmittanceColor = 0xFFFFFFFFu;
        }
        #endregion

        public BGEM()
            : base(Signature)
        {
        }

        #region Properties
        [DataMember(Name = "sBaseTexture")]
        public string BaseTexture { get; set; }

        [DataMember(Name = "sGrayscaleTexture")]
        public string GrayscaleTexture { get; set; }

        [DataMember(Name = "sEnvmapTexture")]
        public string EnvmapTexture { get; set; }

        [DataMember(Name = "sNormalTexture")]
        public string NormalTexture { get; set; }

        [DataMember(Name = "sEnvmapMaskTexture")]
        public string EnvmapMaskTexture { get; set; }

        [DataMember(Name = "sSpecularTexture")]
        public string SpecularTexture { get; set; }

        [DataMember(Name = "sLightingTexture")]
        public string LightingTexture { get; set; }

        [DataMember(Name = "sDistanceFieldAlphaTexture")]
        public string DistanceFieldAlphaTexture { get; set; }

        [DataMember(Name = "bBloodEnabled")]
        public bool BloodEnabled { get; set; }

        [DataMember(Name = "bEffectLightingEnabled")]
        public bool EffectLightingEnabled { get; set; }

        [DataMember(Name = "bFalloffEnabled")]
        public bool FalloffEnabled { get; set; }

        [DataMember(Name = "bFalloffColorEnabled")]
        public bool FalloffColorEnabled { get; set; }

        [DataMember(Name = "bGrayscaleToPaletteAlpha")]
        public bool GrayscaleToPaletteAlpha { get; set; }

        [DataMember(Name = "bSoftEnabled")]
        public bool SoftEnabled { get; set; }

        public uint BaseColor { get; set; }

        [DataMember(Name = "cBaseColor")]
        string BaseColorString
        {
            get { return Color.FromUInt32(BaseColor).ToHexString(); }
            set { BaseColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fBaseColorScale")]
        public float BaseColorScale { get; set; }

        [DataMember(Name = "fFalloffStartAngle")]
        public float FalloffStartAngle { get; set; }

        [DataMember(Name = "fFalloffStopAngle")]
        public float FalloffStopAngle { get; set; }

        [DataMember(Name = "fFalloffStartOpacity")]
        public float FalloffStartOpacity { get; set; }

        [DataMember(Name = "fFalloffStopOpacity")]
        public float FalloffStopOpacity { get; set; }

        [DataMember(Name = "fLightingInfluence")]
        public float LightingInfluence { get; set; }

        [DataMember(Name = "iEnvmapMinLOD")]
        public byte EnvmapMinLOD { get; set; }

        [DataMember(Name = "fSoftDepth")]
        public float SoftDepth { get; set; }

        public uint EmittanceColor { get; set; }

        [DataMember(Name = "cEmittanceColor")]
        string EmittanceColorString
        {
            get { return Color.FromUInt32(EmittanceColor).ToHexString(); }
            set { EmittanceColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fLumEmittance")]
        public float LumEmittance { get; set; }

        public float UnkSingle1 { get; set; }

        public float UnkSingle2 { get; set; }

        public byte UnkByte1 { get; set; }

        public byte UnkByte2 { get; set; }
        #endregion

        public override void Deserialize(BinaryReader input)
        {
            base.Deserialize(input);

            BaseTexture = ReadString(input);
            GrayscaleTexture = ReadString(input);
            EnvmapTexture = ReadString(input);
            NormalTexture = ReadString(input);
            EnvmapMaskTexture = ReadString(input);

            if (Version >= 11)
            {
                SpecularTexture = ReadString(input);
                LightingTexture = ReadString(input);
                DistanceFieldAlphaTexture = ReadString(input);
            }

            if (Version >= 10)
            {
                EnvironmentMapping = input.ReadBoolean();
                EnvironmentMappingMaskScale = input.ReadSingle();
            }

            BloodEnabled = input.ReadBoolean();
            EffectLightingEnabled = input.ReadBoolean();
            FalloffEnabled = input.ReadBoolean();
            FalloffColorEnabled = input.ReadBoolean();
            GrayscaleToPaletteAlpha = input.ReadBoolean();
            SoftEnabled = input.ReadBoolean();

            BaseColor = Color.Read(input).ToUInt32();
            BaseColorScale = input.ReadSingle();

            FalloffStartAngle = input.ReadSingle();
            FalloffStopAngle = input.ReadSingle();
            FalloffStartOpacity = input.ReadSingle();
            FalloffStopOpacity = input.ReadSingle();

            LightingInfluence = input.ReadSingle();
            EnvmapMinLOD = input.ReadByte();
            SoftDepth = input.ReadSingle();

            if (Version >= 11)
            {
                EmittanceColor = Color.Read(input).ToUInt32();
            }

            if (Version >= 15)
            {
                LumEmittance = input.ReadSingle();
                UnkSingle1 = input.ReadSingle();
                UnkSingle2 = input.ReadSingle();
                UnkByte1 = input.ReadByte();
                UnkByte2 = input.ReadByte();
            }
        }

        public override void Serialize(BinaryWriter output)
        {
            base.Serialize(output);

            WriteString(output, BaseTexture);
            WriteString(output, GrayscaleTexture);
            WriteString(output, EnvmapTexture);
            WriteString(output, NormalTexture);
            WriteString(output, EnvmapMaskTexture);

            if (Version >= 11)
            {
                WriteString(output, SpecularTexture);
                WriteString(output, LightingTexture);
                WriteString(output, DistanceFieldAlphaTexture);
            }

            if (Version >= 10)
            {
                output.Write(EnvironmentMapping);
                output.Write(EnvironmentMappingMaskScale);
            }

            output.Write(BloodEnabled);
            output.Write(EffectLightingEnabled);
            output.Write(FalloffEnabled);
            output.Write(FalloffColorEnabled);
            output.Write(GrayscaleToPaletteAlpha);
            output.Write(SoftEnabled);

            Color.FromUInt32(BaseColor).Write(output);
            output.Write(BaseColorScale);

            output.Write(FalloffStartAngle);
            output.Write(FalloffStopAngle);
            output.Write(FalloffStartOpacity);
            output.Write(FalloffStopOpacity);

            output.Write(LightingInfluence);
            output.Write(EnvmapMinLOD);
            output.Write(SoftDepth);

            if (Version >= 11)
            {
                Color.FromUInt32(EmittanceColor).Write(output);
            }

            if (Version >= 15)
            {
                output.Write(LumEmittance);
                output.Write(UnkSingle1);
                output.Write(UnkSingle2);
                output.Write(UnkByte1);
                output.Write(UnkByte2);
            }
        }
    }
}
