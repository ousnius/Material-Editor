using System.Runtime.Serialization;

namespace MaterialLib
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
            GlowTexture = "";

            BaseColor = 0xFFFFFFFFu;
            BaseColorScale = 1.0f;
            FalloffStartAngle = 1.0f;
            FalloffStopAngle = 1.0f;
            LightingInfluence = 1.0f;
            SoftDepth = 100.0f;
            EmittanceColor = 0xFFFFFFFFu;

            GlassRoughnessScratch = "";
            GlassDirtOverlay = "";

            GlassFresnelColor = 0xFFFFFFFFu;
            GlassRefractionScaleBase = 0.05f;
            GlassBlurScaleBase = 0.4f;
            GlassBlurScaleFactor = 1.0f;
        }
        #endregion

        public BGEM()
            : base(Signature)
        {
        }

        #region Properties
        [DataMember(Name = "sBaseTexture")]
        public string? BaseTexture { get; set; }

        [DataMember(Name = "sGrayscaleTexture")]
        public string? GrayscaleTexture { get; set; }

        [DataMember(Name = "sEnvmapTexture")]
        public string? EnvmapTexture { get; set; }

        [DataMember(Name = "sNormalTexture")]
        public string? NormalTexture { get; set; }

        [DataMember(Name = "sEnvmapMaskTexture")]
        public string? EnvmapMaskTexture { get; set; }

        [DataMember(Name = "sSpecularTexture")]
        public string? SpecularTexture { get; set; }

        [DataMember(Name = "sLightingTexture")]
        public string? LightingTexture { get; set; }

        [DataMember(Name = "sGlowTexture")]
        public string? GlowTexture { get; set; }

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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by JSON serialization.")]
        private string BaseColorString
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by JSON serialization.")]
        private string EmittanceColorString
        {
            get { return Color.FromUInt32(EmittanceColor).ToHexString(); }
            set { EmittanceColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fAdaptativeEmissive_ExposureOffset")]
        public float AdaptativeEmissive_ExposureOffset { get; set; }

        [DataMember(Name = "fAdaptativeEmissive_FinalExposureMin")]
        public float AdaptativeEmissive_FinalExposureMin { get; set; }

        [DataMember(Name = "fAdaptativeEmissive_FinalExposureMax")]
        public float AdaptativeEmissive_FinalExposureMax { get; set; }

        [DataMember(Name = "bGlowmap")]
        public bool Glowmap { get; set; }

        [DataMember(Name = "bEffectPbrSpecular")]
        public bool EffectPbrSpecular { get; set; }

        [DataMember(Name = "sGlassRoughnessScratch")]
        public string? GlassRoughnessScratch { get; set; }

        [DataMember(Name = "sGlassDirtOverlay")]
        public string? GlassDirtOverlay { get; set; }

        [DataMember(Name = "bGlassEnabled")]
        public bool GlassEnabled { get; set; }

        public uint GlassFresnelColor { get; set; }

        [DataMember(Name = "cGlassFresnelColor")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by JSON serialization.")]
        private string GlassFresnelColorString
        {
            get { return Color.FromUInt32(GlassFresnelColor).ToHexString(); }
            set { GlassFresnelColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fGlassRefractionScaleBase")]
        public float GlassRefractionScaleBase { get; set; }

        [DataMember(Name = "fGlassBlurScaleBase")]
        public float GlassBlurScaleBase { get; set; }

        [DataMember(Name = "fGlassBlurScaleFactor")]
        public float GlassBlurScaleFactor { get; set; }
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
                GlowTexture = ReadString(input);
            }

            if (Version >= 21)
            {
                GlassRoughnessScratch = ReadString(input);
                GlassDirtOverlay = ReadString(input);
                GlassEnabled = input.ReadBoolean();

                if (GlassEnabled)
                {
                    GlassFresnelColor = Color.Read(input).ToUInt32(); // 1.0, 1.0, 1.0

                    // FIXME: Order might be wrong
                    GlassBlurScaleBase = input.ReadSingle(); // Occurring values: 0.05, 0.005, 0.01, -0.09, 0.0

                    if (Version >= 22)
                        GlassBlurScaleFactor = input.ReadSingle(); // Occurring values: 1.0, 0.0

                    GlassRefractionScaleBase = input.ReadSingle(); // Occurring values: 0.4, 0.1, 0.01, 0.0
                }
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
                AdaptativeEmissive_ExposureOffset = input.ReadSingle();
                AdaptativeEmissive_FinalExposureMin = input.ReadSingle();
                AdaptativeEmissive_FinalExposureMax = input.ReadSingle();
            }

            if (Version >= 16)
            {
                Glowmap = input.ReadBoolean();
            }

            if (Version >= 20)
            {
                EffectPbrSpecular = input.ReadBoolean();
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
                WriteString(output, GlowTexture);
            }

            if (Version >= 21)
            {
                WriteString(output, GlassRoughnessScratch);
                WriteString(output, GlassDirtOverlay);
                output.Write(GlassEnabled);

                if (GlassEnabled)
                {
                    Color.FromUInt32(GlassFresnelColor).Write(output);

                    // FIXME: Order might be wrong
                    output.Write(GlassBlurScaleBase);

                    if (Version >= 22)
                        output.Write(GlassBlurScaleFactor);

                    output.Write(GlassRefractionScaleBase);
                }
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
                output.Write(AdaptativeEmissive_ExposureOffset);
                output.Write(AdaptativeEmissive_FinalExposureMin);
                output.Write(AdaptativeEmissive_FinalExposureMax);
            }

            if (Version >= 16)
            {
                output.Write(Glowmap);
            }

            if (Version >= 20)
            {
                output.Write(EffectPbrSpecular);
            }
        }
    }
}
