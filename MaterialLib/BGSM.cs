using System.Runtime.Serialization;

namespace MaterialLib
{
    [DataContract]
    public class BGSM : BaseMaterialFile
    {
        public const uint Signature = 0x4D534742u;

        #region Fields
        protected override void SetDefaults()
        {
            base.SetDefaults();

            DiffuseTexture = "";
            NormalTexture = "";
            SmoothSpecTexture = "";
            GreyscaleTexture = "";
            EnvmapTexture = "";
            GlowTexture = "";
            InnerLayerTexture = "";
            WrinklesTexture = "";
            DisplacementTexture = "";
            SpecularTexture = "";
            LightingTexture = "";
            FlowTexture = "";
            DistanceFieldAlphaTexture = "";
            RimPower = 2.0f;
            SubsurfaceLightingRolloff = 0.3f;
            SpecularColor = 0xFFFFFFFFu;
            SpecularMult = 1.0f;
            Smoothness = 1.0f;
            FresnelPower = 5.0f;
            WetnessControlSpecScale = -1.0f;
            WetnessControlSpecPowerScale = -1.0f;
            WetnessControlSpecMinvar = -1.0f;
            WetnessControlEnvMapScale = -1.0f;
            WetnessControlFresnelPower = -1.0f;
            WetnessControlMetalness = -1.0f;
            RootMaterialPath = "";
            EmittanceColor = 0xFFFFFFFFu;
            EmittanceMult = 1.0f;
            HairTintColor = 0x808080u;
            DisplacementTextureBias = -0.5f;
            DisplacementTextureScale = 10.0f;
            TessellationPnScale = 1.0f;
            TessellationBaseFactor = 1.0f;
            GrayscaleToPaletteScale = 1.0f;
        }
        #endregion

        public BGSM()
            : base(Signature)
        {
        }

        #region Properties
        [DataMember(Name = "sDiffuseTexture")]
        public string? DiffuseTexture { get; set; }

        [DataMember(Name = "sNormalTexture")]
        public string? NormalTexture { get; set; }

        [DataMember(Name = "sSmoothSpecTexture")]
        public string? SmoothSpecTexture { get; set; }

        [DataMember(Name = "sGreyscaleTexture")]
        public string? GreyscaleTexture { get; set; }

        [DataMember(Name = "sEnvmapTexture")]
        public string? EnvmapTexture { get; set; }

        [DataMember(Name = "sGlowTexture")]
        public string? GlowTexture { get; set; }

        [DataMember(Name = "sInnerLayerTexture")]
        public string? InnerLayerTexture { get; set; }

        [DataMember(Name = "sWrinklesTexture")]
        public string? WrinklesTexture { get; set; }

        [DataMember(Name = "sDisplacementTexture")]
        public string? DisplacementTexture { get; set; }

        [DataMember(Name = "sSpecularTexture")]
        public string? SpecularTexture { get; set; }

        [DataMember(Name = "sLightingTexture")]
        public string? LightingTexture { get; set; }

        [DataMember(Name = "sFlowTexture")]
        public string? FlowTexture { get; set; }

        [DataMember(Name = "sDistanceFieldAlphaTexture")]
        public string? DistanceFieldAlphaTexture { get; set; }

        [DataMember(Name = "bEnableEditorAlphaRef")]
        public bool EnableEditorAlphaRef { get; set; }

        [DataMember(Name = "bRimLighting")]
        public bool RimLighting { get; set; }

        [DataMember(Name = "fRimPower")]
        public float RimPower { get; set; }

        [DataMember(Name = "fBackLightPower")]
        public float BackLightPower { get; set; }

        [DataMember(Name = "bSubsurfaceLighting")]
        public bool SubsurfaceLighting { get; set; }

        [DataMember(Name = "fSubsurfaceLightingRolloff")]
        public float SubsurfaceLightingRolloff { get; set; }

        [DataMember(Name = "bSpecularEnabled")]
        public bool SpecularEnabled { get; set; }

        public uint SpecularColor { get; set; }

        [DataMember(Name = "cSpecularColor")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by JSON serialization.")]
        private string SpecularColorString
        {
            get { return Color.FromUInt32(SpecularColor).ToHexString(); }
            set { SpecularColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fSpecularMult")]
        public float SpecularMult { get; set; }

        [DataMember(Name = "fSmoothness")]
        public float Smoothness { get; set; }

        [DataMember(Name = "fFresnelPower")]
        public float FresnelPower { get; set; }

        [DataMember(Name = "fWetnessControl_SpecScale")]
        public float WetnessControlSpecScale { get; set; }

        [DataMember(Name = "fWetnessControl_SpecPowerScale")]
        public float WetnessControlSpecPowerScale { get; set; }

        [DataMember(Name = "fWetnessControl_SpecMinvar")]
        public float WetnessControlSpecMinvar { get; set; }

        [DataMember(Name = "fWetnessControl_EnvMapScale")]
        public float WetnessControlEnvMapScale { get; set; }

        [DataMember(Name = "fWetnessControl_FresnelPower")]
        public float WetnessControlFresnelPower { get; set; }

        [DataMember(Name = "fWetnessControl_Metalness")]
        public float WetnessControlMetalness { get; set; }

        [DataMember(Name = "sRootMaterialPath")]
        public string? RootMaterialPath { get; set; }

        [DataMember(Name = "bAnisoLighting")]
        public bool AnisoLighting { get; set; }

        [DataMember(Name = "bEmitEnabled")]
        public bool EmitEnabled { get; set; }

        public uint EmittanceColor { get; set; }

        [DataMember(Name = "cEmittanceColor")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by JSON serialization.")]
        private string EmittanceColorString
        {
            get { return Color.FromUInt32(EmittanceColor).ToHexString(); }
            set { EmittanceColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fEmittanceMult")]
        public float EmittanceMult { get; set; }

        [DataMember(Name = "bModelSpaceNormals")]
        public bool ModelSpaceNormals { get; set; }

        [DataMember(Name = "bExternalEmittance")]
        public bool ExternalEmittance { get; set; }

        [DataMember(Name = "bBackLighting")]
        public bool BackLighting { get; set; }

        [DataMember(Name = "bReceiveShadows")]
        public bool ReceiveShadows { get; set; }

        [DataMember(Name = "bHideSecret")]
        public bool HideSecret { get; set; }

        [DataMember(Name = "bCastShadows")]
        public bool CastShadows { get; set; }

        [DataMember(Name = "bDissolveFade")]
        public bool DissolveFade { get; set; }

        [DataMember(Name = "bAssumeShadowmask")]
        public bool AssumeShadowmask { get; set; }

        [DataMember(Name = "bGlowmap")]
        public bool Glowmap { get; set; }

        [DataMember(Name = "bEnvironmentMappingWindow")]
        public bool EnvironmentMappingWindow { get; set; }

        [DataMember(Name = "bEnvironmentMappingEye")]
        public bool EnvironmentMappingEye { get; set; }

        [DataMember(Name = "bHair")]
        public bool Hair { get; set; }

        public uint HairTintColor { get; set; }

        [DataMember(Name = "cHairTintColor")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by JSON serialization.")]
        private string HairTintColorString
        {
            get { return Color.FromUInt32(HairTintColor).ToHexString(); }
            set { HairTintColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "bTree")]
        public bool Tree { get; set; }

        [DataMember(Name = "bFacegen")]
        public bool Facegen { get; set; }

        [DataMember(Name = "bSkinTint")]
        public bool SkinTint { get; set; }

        [DataMember(Name = "bTessellate")]
        public bool Tessellate { get; set; }

        [DataMember(Name = "fDisplacementTextureBias")]
        public float DisplacementTextureBias { get; set; }

        [DataMember(Name = "fDisplacementTextureScale")]
        public float DisplacementTextureScale { get; set; }

        [DataMember(Name = "fTessellationPnScale")]
        public float TessellationPnScale { get; set; }

        [DataMember(Name = "fTessellationBaseFactor")]
        public float TessellationBaseFactor { get; set; }

        [DataMember(Name = "fTessellationFadeDistance")]
        public float TessellationFadeDistance { get; set; }

        [DataMember(Name = "fGrayscaleToPaletteScale")]
        public float GrayscaleToPaletteScale { get; set; }

        [DataMember(Name = "bSkewSpecularAlpha")]
        public bool SkewSpecularAlpha { get; set; }

        [DataMember(Name = "bTranslucency")]
        public bool Translucency { get; set; }
        
        public uint TranslucencySubsurfaceColor { get; set; }

        [DataMember(Name = "cTranslucencySubsurfaceColor")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by JSON serialization.")]
        private string TranslucencySubsurfaceColorString
        {
            get { return Color.FromUInt32(TranslucencySubsurfaceColor).ToHexString(); }
            set { TranslucencySubsurfaceColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fTranslucencyTransmissiveScale")]
        public float TranslucencyTransmissiveScale { get; set; }

        [DataMember(Name = "fTranslucencyTurbulence")]
        public float TranslucencyTurbulence { get; set; }

        [DataMember(Name = "bPBR")]
        public bool PBR { get; set; }

        [DataMember(Name = "bCustomPorosity")]
        public bool CustomPorosity { get; set; }

        [DataMember(Name = "fPorosityValue")]
        public float PorosityValue { get; set; }

        [DataMember(Name = "fLumEmittance")]
        public float LumEmittance { get; set; }

        [DataMember(Name = "bTranslucencyThickObject")]
        public bool TranslucencyThickObject { get; set; }

        [DataMember(Name = "bTranslucencyMixAlbedoWithSubsurfaceColor")]
        public bool TranslucencyMixAlbedoWithSubsurfaceColor { get; set; }

        [DataMember(Name = "bUseAdaptativeEmissive")]
        public bool UseAdaptativeEmissive { get; set; }

        [DataMember(Name = "fAdaptativeEmissive_ExposureOffset")]
        public float AdaptativeEmissive_ExposureOffset { get; set; }

        [DataMember(Name = "fAdaptativeEmissive_FinalExposureMin")]
        public float AdaptativeEmissive_FinalExposureMin { get; set; }

        [DataMember(Name = "fAdaptativeEmissive_FinalExposureMax")]
        public float AdaptativeEmissive_FinalExposureMax { get; set; }

        [DataMember(Name = "bTerrain")]
        public bool Terrain { get; set; }

        [DataMember(Name = "fTerrainThresholdFalloff")]
        public float TerrainThresholdFalloff { get; set; }

        [DataMember(Name = "fTerrainTilingDistance")]
        public float TerrainTilingDistance { get; set; }

        [DataMember(Name = "fTerrainRotationAngle")]
        public float TerrainRotationAngle { get; set; }

        [DataMember]
        public uint UnkInt1 { get; set; }
        #endregion

        public override void Deserialize(BinaryReader input)
        {
            base.Deserialize(input);

            DiffuseTexture = ReadString(input);
            NormalTexture = ReadString(input);
            SmoothSpecTexture = ReadString(input);
            GreyscaleTexture = ReadString(input);

            if (Version > 2)
            {
                GlowTexture = ReadString(input);
                WrinklesTexture = ReadString(input);
                SpecularTexture = ReadString(input);
                LightingTexture = ReadString(input);
                FlowTexture = ReadString(input);

                if (Version >= 17)
                {
                    DistanceFieldAlphaTexture = ReadString(input);
                }
            }
            else
            {
                EnvmapTexture = ReadString(input);
                GlowTexture = ReadString(input);
                InnerLayerTexture = ReadString(input);
                WrinklesTexture = ReadString(input);
                DisplacementTexture = ReadString(input);
            }

            EnableEditorAlphaRef = input.ReadBoolean();

            if (Version >= 8)
            {
                Translucency = input.ReadBoolean();
                TranslucencyThickObject = input.ReadBoolean();
                TranslucencyMixAlbedoWithSubsurfaceColor = input.ReadBoolean();
                TranslucencySubsurfaceColor = Color.Read(input).ToUInt32();
                TranslucencyTransmissiveScale = input.ReadSingle();
                TranslucencyTurbulence = input.ReadSingle();
            }
            else
            {
                RimLighting = input.ReadBoolean();
                RimPower = input.ReadSingle();
                BackLightPower = input.ReadSingle();

                SubsurfaceLighting = input.ReadBoolean();
                SubsurfaceLightingRolloff = input.ReadSingle();
            }

            SpecularEnabled = input.ReadBoolean();
            SpecularColor = Color.Read(input).ToUInt32();
            SpecularMult = input.ReadSingle();
            Smoothness = input.ReadSingle();

            FresnelPower = input.ReadSingle();
            WetnessControlSpecScale = input.ReadSingle();
            WetnessControlSpecPowerScale = input.ReadSingle();
            WetnessControlSpecMinvar = input.ReadSingle();

            if (Version < 10)
            {
                WetnessControlEnvMapScale = input.ReadSingle();
            }

            WetnessControlFresnelPower = input.ReadSingle();
            WetnessControlMetalness = input.ReadSingle();

            if (Version > 2)
            {
                PBR = input.ReadBoolean();

                if (Version >= 9)
                {
                    CustomPorosity = input.ReadBoolean();
                    PorosityValue = input.ReadSingle();
                }
            }

            RootMaterialPath = ReadString(input);

            AnisoLighting = input.ReadBoolean();
            EmitEnabled = input.ReadBoolean();

            if (EmitEnabled)
            {
                EmittanceColor = Color.Read(input).ToUInt32();
            }

            EmittanceMult = input.ReadSingle();
            ModelSpaceNormals = input.ReadBoolean();
            ExternalEmittance = input.ReadBoolean();

            if (Version >= 12)
            {
                LumEmittance = input.ReadSingle();
            }

            if (Version >= 13)
            {
                UseAdaptativeEmissive = input.ReadBoolean();
                AdaptativeEmissive_ExposureOffset = input.ReadSingle();
                AdaptativeEmissive_FinalExposureMin = input.ReadSingle();
                AdaptativeEmissive_FinalExposureMax = input.ReadSingle();
            }

            if (Version < 8)
            {
                BackLighting = input.ReadBoolean();
            }

            ReceiveShadows = input.ReadBoolean();
            HideSecret = input.ReadBoolean();
            CastShadows = input.ReadBoolean();
            DissolveFade = input.ReadBoolean();
            AssumeShadowmask = input.ReadBoolean();

            Glowmap = input.ReadBoolean();

            if (Version < 7)
            {
                EnvironmentMappingWindow = input.ReadBoolean();
                EnvironmentMappingEye = input.ReadBoolean();
            }

            Hair = input.ReadBoolean();
            HairTintColor = Color.Read(input).ToUInt32();

            Tree = input.ReadBoolean();
            Facegen = input.ReadBoolean();
            SkinTint = input.ReadBoolean();
            Tessellate = input.ReadBoolean();

            if (Version < 3)
            {
                DisplacementTextureBias = input.ReadSingle();
                DisplacementTextureScale = input.ReadSingle();
                TessellationPnScale = input.ReadSingle();
                TessellationBaseFactor = input.ReadSingle();
                TessellationFadeDistance = input.ReadSingle();
            }

            GrayscaleToPaletteScale = input.ReadSingle();

            if (Version >= 1)
            {
                SkewSpecularAlpha = input.ReadBoolean();
            }

            if (Version >= 3)
            {
                Terrain = input.ReadBoolean();

                if (Terrain)
                {
                    if (Version == 3)
                    {
                        UnkInt1 = input.ReadUInt32();
                    }

                    TerrainThresholdFalloff = input.ReadSingle();
                    TerrainTilingDistance = input.ReadSingle();
                    TerrainRotationAngle = input.ReadSingle();
                }
            }
        }

        public override void Serialize(BinaryWriter output)
        {
            base.Serialize(output);

            WriteString(output, DiffuseTexture);
            WriteString(output, NormalTexture);
            WriteString(output, SmoothSpecTexture);
            WriteString(output, GreyscaleTexture);

            if (Version > 2)
            {
                WriteString(output, GlowTexture);
                WriteString(output, WrinklesTexture);
                WriteString(output, SpecularTexture);
                WriteString(output, LightingTexture);
                WriteString(output, FlowTexture);

                if (Version >= 17)
                {
                    WriteString(output, DistanceFieldAlphaTexture);
                }
            }
            else
            {
                WriteString(output, EnvmapTexture);
                WriteString(output, GlowTexture);
                WriteString(output, InnerLayerTexture);
                WriteString(output, WrinklesTexture);
                WriteString(output, DisplacementTexture);
            }

            output.Write(EnableEditorAlphaRef);
            
            if (Version >= 8)
            {
                output.Write(Translucency);
                output.Write(TranslucencyThickObject);
                output.Write(TranslucencyMixAlbedoWithSubsurfaceColor);
                Color.FromUInt32(TranslucencySubsurfaceColor).Write(output);
                output.Write(TranslucencyTransmissiveScale);
                output.Write(TranslucencyTurbulence);
            }
            else
            {
                output.Write(RimLighting);
                output.Write(RimPower);
                output.Write(BackLightPower);

                output.Write(SubsurfaceLighting);
                output.Write(SubsurfaceLightingRolloff);
            }

            output.Write(SpecularEnabled);
            Color.FromUInt32(SpecularColor).Write(output);
            output.Write(SpecularMult);
            output.Write(Smoothness);

            output.Write(FresnelPower);
            output.Write(WetnessControlSpecScale);
            output.Write(WetnessControlSpecPowerScale);
            output.Write(WetnessControlSpecMinvar);

            if (Version < 10)
            {
                output.Write(WetnessControlEnvMapScale);
            }
            
            output.Write(WetnessControlFresnelPower);
            output.Write(WetnessControlMetalness);

            if (Version > 2)
            {
                output.Write(PBR);

                if (Version >= 9)
                {
                    output.Write(CustomPorosity);
                    output.Write(PorosityValue);
                }
            }

            WriteString(output, RootMaterialPath);

            output.Write(AnisoLighting);
            output.Write(EmitEnabled);

            if (EmitEnabled)
            {
                Color.FromUInt32(EmittanceColor).Write(output);
            }

            output.Write(EmittanceMult);
            output.Write(ModelSpaceNormals);
            output.Write(ExternalEmittance);

            if (Version >= 12)
            {
                output.Write(LumEmittance);
            }

            if (Version >= 13)
            {
                output.Write(UseAdaptativeEmissive);
                output.Write(AdaptativeEmissive_ExposureOffset);
                output.Write(AdaptativeEmissive_FinalExposureMin);
                output.Write(AdaptativeEmissive_FinalExposureMax);
            }

            if (Version < 8)
            {
                output.Write(BackLighting);
            }

            output.Write(ReceiveShadows);
            output.Write(HideSecret);
            output.Write(CastShadows);
            output.Write(DissolveFade);
            output.Write(AssumeShadowmask);

            output.Write(Glowmap);

            if (Version < 7)
            {
                output.Write(EnvironmentMappingWindow);
                output.Write(EnvironmentMappingEye);
            }

            output.Write(Hair);
            Color.FromUInt32(HairTintColor).Write(output);

            output.Write(Tree);
            output.Write(Facegen);
            output.Write(SkinTint);
            output.Write(Tessellate);
            
            if (Version < 3)
            {
                output.Write(DisplacementTextureBias);
                output.Write(DisplacementTextureScale);
                output.Write(TessellationPnScale);
                output.Write(TessellationBaseFactor);
                output.Write(TessellationFadeDistance);
            }

            output.Write(GrayscaleToPaletteScale);

            if (Version >= 1)
            {
                output.Write(SkewSpecularAlpha);
            }

            if (Version >= 3)
            {
                output.Write(Terrain);

                if (Terrain)
                {
                    if (Version == 3)
                    {
                        output.Write(UnkInt1);
                    }

                    output.Write(TerrainThresholdFalloff);
                    output.Write(TerrainTilingDistance);
                    output.Write(TerrainRotationAngle);
                }
            }
        }
    }
}
