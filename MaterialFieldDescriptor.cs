using MaterialLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Material_Editor
{
    public enum FieldCategory
    {
        General,
        Material,
        Effect
    }

    public sealed class MaterialFieldDescriptor
    {
        public string Label { get; }
        public FieldCategory Category { get; }
        public Func<BaseMaterialFile, object> Getter { get; }
        public Action<BaseMaterialFile, object> Setter { get; }
        public Func<BaseMaterialFile, bool> Supports { get; }

        public MaterialFieldDescriptor(
            string label,
            FieldCategory category,
            Func<BaseMaterialFile, object> getter,
            Action<BaseMaterialFile, object> setter,
            Func<BaseMaterialFile, bool> supports = null)
        {
            Label = label;
            Category = category;
            Getter = getter;
            Setter = setter;
            Supports = supports;
        }

        public bool IsSupported(BaseMaterialFile material)
        {
            return material != null && (Supports?.Invoke(material) ?? true);
        }

        public object GetValue(BaseMaterialFile material) => Getter(material);

        public void SetValue(BaseMaterialFile material, object value)
        {
            Setter(material, value);
        }

        public bool HasChanged(BaseMaterialFile baseline, BaseMaterialFile current)
        {
            if (baseline == null || current == null)
                return false;

            var original = Getter(baseline);
            var modified = Getter(current);

            return !ValuesEqual(original, modified);
        }

        private static bool ValuesEqual(object original, object modified)
        {
            if (original == null && modified == null)
                return true;

            if (original == null || modified == null)
                return false;

            if (original is float of && modified is float mf)
                return Math.Abs(of - mf) < 0.0001f;

            if (original is double od && modified is double md)
                return Math.Abs(od - md) < 0.0001;

            if (original is decimal oc && modified is decimal mc)
                return Math.Abs(oc - mc) < 0.0001m;

            return original.Equals(modified);
        }
    }

    public static class MaterialFieldRegistry
    {
        public static IReadOnlyList<MaterialFieldDescriptor> GetDescriptors(BaseMaterialFile material)
        {
            if (material == null)
                return Array.Empty<MaterialFieldDescriptor>();

            return AllFields.Where(descriptor => descriptor.IsSupported(material)).ToList();
        }

        private static readonly IReadOnlyList<MaterialFieldDescriptor> GeneralFields = new MaterialFieldDescriptor[] {
            CreateGeneral(ControlNames.TileU, m => m.TileU, (m, v) => m.TileU = v),
            CreateGeneral(ControlNames.TileV, m => m.TileV, (m, v) => m.TileV = v),
            CreateGeneral(ControlNames.OffsetU, m => m.UOffset, (m, v) => m.UOffset = v),
            CreateGeneral(ControlNames.OffsetV, m => m.VOffset, (m, v) => m.VOffset = v),
            CreateGeneral(ControlNames.ScaleU, m => m.UScale, (m, v) => m.UScale = v),
            CreateGeneral(ControlNames.ScaleV, m => m.VScale, (m, v) => m.VScale = v),
            CreateGeneral(ControlNames.Alpha, m => m.Alpha, (m, v) => m.Alpha = v),
            CreateGeneral(ControlNames.AlphaBlendMode, m => m.AlphaBlendMode, (m, v) => m.AlphaBlendMode = v),
            CreateGeneral(ControlNames.AlphaTestReference, m => m.AlphaTestRef, (m, v) => m.AlphaTestRef = v),
            CreateGeneral(ControlNames.AlphaTest, m => m.AlphaTest, (m, v) => m.AlphaTest = v),
            CreateGeneral(ControlNames.ZBufferWrite, m => m.ZBufferWrite, (m, v) => m.ZBufferWrite = v),
            CreateGeneral(ControlNames.ZBufferTest, m => m.ZBufferTest, (m, v) => m.ZBufferTest = v),
            CreateGeneral(ControlNames.ScreenSpaceReflections, m => m.ScreenSpaceReflections, (m, v) => m.ScreenSpaceReflections = v),
            CreateGeneral(ControlNames.WetnessControlSSR, m => m.WetnessControlScreenSpaceReflections, (m, v) => m.WetnessControlScreenSpaceReflections = v),
            CreateGeneral(ControlNames.Decal, m => m.Decal, (m, v) => m.Decal = v),
            CreateGeneral(ControlNames.TwoSided, m => m.TwoSided, (m, v) => m.TwoSided = v),
            CreateGeneral(ControlNames.DecalNoFade, m => m.DecalNoFade, (m, v) => m.DecalNoFade = v),
            CreateGeneral(ControlNames.NonOccluder, m => m.NonOccluder, (m, v) => m.NonOccluder = v),
            CreateGeneral(ControlNames.Refraction, m => m.Refraction, (m, v) => m.Refraction = v),
            CreateGeneral(ControlNames.RefractionFalloff, m => m.RefractionFalloff, (m, v) => m.RefractionFalloff = v, m => m.Refraction),
            CreateGeneral(ControlNames.RefractionPower, m => m.RefractionPower, (m, v) => m.RefractionPower = v, m => m.Refraction),
            CreateGeneral(ControlNames.EnvironmentMapping, m => m.EnvironmentMapping, (m, v) => m.EnvironmentMapping = v, m => m.Version < 10),
            CreateGeneral(ControlNames.EnvironmentMaskScale, m => m.EnvironmentMappingMaskScale, (m, v) => m.EnvironmentMappingMaskScale = v, m => m.Version < 10 && m.EnvironmentMapping),
            CreateGeneral(ControlNames.DepthBias, m => m.DepthBias, (m, v) => m.DepthBias = v, m => m.Version >= 10),
            CreateGeneral(ControlNames.GrayscaleToPaletteColor, m => m.GrayscaleToPaletteColor, (m, v) => m.GrayscaleToPaletteColor = v),
            CreateGeneral(ControlNames.MaskWrites, m => m.MaskWrites, (m, v) => m.MaskWrites = v, m => m.Version >= 6),
        };

        private static readonly IReadOnlyList<MaterialFieldDescriptor> MaterialFields = new MaterialFieldDescriptor[] {
            CreateBGSM(ControlNames.Diffuse, m => m.DiffuseTexture, (m, v) => m.DiffuseTexture = v),
            CreateBGSM(ControlNames.Normal, m => m.NormalTexture, (m, v) => m.NormalTexture = v),
            CreateBGSM(ControlNames.SmoothSpec, m => m.SmoothSpecTexture, (m, v) => m.SmoothSpecTexture = v),
            CreateBGSM(ControlNames.Greyscale, m => m.GreyscaleTexture, (m, v) => m.GreyscaleTexture = v),
            CreateBGSM(ControlNames.Environment, m => m.EnvmapTexture, (m, v) => m.EnvmapTexture = v, m => m.Version <= 2),
            CreateBGSM(ControlNames.Glow, m => m.GlowTexture, (m, v) => m.GlowTexture = v),
            CreateBGSM(ControlNames.InnerLayer, m => m.InnerLayerTexture, (m, v) => m.InnerLayerTexture = v, m => m.Version <= 2),
            CreateBGSM(ControlNames.Wrinkles, m => m.WrinklesTexture, (m, v) => m.WrinklesTexture = v),
            CreateBGSM(ControlNames.Displacement, m => m.DisplacementTexture, (m, v) => m.DisplacementTexture = v, m => m.Version <= 2),
            CreateBGSM(ControlNames.Specular, m => m.SpecularTexture, (m, v) => m.SpecularTexture = v, m => m.Version > 2),
            CreateBGSM(ControlNames.Lighting, m => m.LightingTexture, (m, v) => m.LightingTexture = v, m => m.Version > 2),
            CreateBGSM(ControlNames.Flow, m => m.FlowTexture, (m, v) => m.FlowTexture = v, m => m.Version > 2),
            CreateBGSM(ControlNames.DistanceFieldAlpha, m => m.DistanceFieldAlphaTexture, (m, v) => m.DistanceFieldAlphaTexture = v, m => m.Version > 2),
            CreateBGSM(ControlNames.EnableEditorAlphaRef, m => m.EnableEditorAlphaRef, (m, v) => m.EnableEditorAlphaRef = v),
            CreateBGSM(ControlNames.RimLighting, m => m.RimLighting, (m, v) => m.RimLighting = v, m => m.Version < 8),
            CreateBGSM(ControlNames.RimPower, m => m.RimPower, (m, v) => m.RimPower = v, m => m.Version < 8 && m.RimLighting),
            CreateBGSM(ControlNames.BacklightPower, m => m.BackLightPower, (m, v) => m.BackLightPower = v, m => m.Version < 8),
            CreateBGSM(ControlNames.SubsurfaceLighting, m => m.SubsurfaceLighting, (m, v) => m.SubsurfaceLighting = v, m => m.Version < 8),
            CreateBGSM(ControlNames.SubsurfaceLightingRolloff, m => m.SubsurfaceLightingRolloff, (m, v) => m.SubsurfaceLightingRolloff = v, m => m.Version < 8 && m.SubsurfaceLighting),
            CreateBGSM(ControlNames.Translucency, m => m.Translucency, (m, v) => m.Translucency = v, m => m.Version >= 8),
            CreateBGSM(ControlNames.TranslucencyThickObject, m => m.TranslucencyThickObject, (m, v) => m.TranslucencyThickObject = v, m => m.Version >= 8),
            CreateBGSM(ControlNames.TranslucencyAlbSubsurfColor, m => m.TranslucencyMixAlbedoWithSubsurfaceColor, (m, v) => m.TranslucencyMixAlbedoWithSubsurfaceColor = v, m => m.Version >= 8),
            CreateBGSM(ControlNames.TranslucencySubsurfaceColor, m => m.TranslucencySubsurfaceColor, (m, v) => m.TranslucencySubsurfaceColor = v, m => m.Version >= 8),
            CreateBGSM(ControlNames.TranslucencyTransmissiveScale, m => m.TranslucencyTransmissiveScale, (m, v) => m.TranslucencyTransmissiveScale = v, m => m.Version >= 8),
            CreateBGSM(ControlNames.TranslucencyTurbulence, m => m.TranslucencyTurbulence, (m, v) => m.TranslucencyTurbulence = v, m => m.Version >= 8),
            CreateBGSM(ControlNames.SpecularEnabled, m => m.SpecularEnabled, (m, v) => m.SpecularEnabled = v),
            CreateBGSM(ControlNames.SpecularColor, m => m.SpecularColor, (m, v) => m.SpecularColor = v),
            CreateBGSM(ControlNames.SpecularMultiplier, m => m.SpecularMult, (m, v) => m.SpecularMult = v),
            CreateBGSM(ControlNames.Smoothness, m => m.Smoothness, (m, v) => m.Smoothness = v),
            CreateBGSM(ControlNames.FresnelPower, m => m.FresnelPower, (m, v) => m.FresnelPower = v),
            CreateBGSM(ControlNames.WetSpecScale, m => m.WetnessControlSpecScale, (m, v) => m.WetnessControlSpecScale = v),
            CreateBGSM(ControlNames.WetSpecPowerScale, m => m.WetnessControlSpecPowerScale, (m, v) => m.WetnessControlSpecPowerScale = v),
            CreateBGSM(ControlNames.WetSpecMinVar, m => m.WetnessControlSpecMinvar, (m, v) => m.WetnessControlSpecMinvar = v),
            CreateBGSM(ControlNames.WetEnvMapScale, m => m.WetnessControlEnvMapScale, (m, v) => m.WetnessControlEnvMapScale = v, m => m.Version < 10),
            CreateBGSM(ControlNames.WetFresnelPower, m => m.WetnessControlFresnelPower, (m, v) => m.WetnessControlFresnelPower = v),
            CreateBGSM(ControlNames.WetMetalness, m => m.WetnessControlMetalness, (m, v) => m.WetnessControlMetalness = v),
            CreateBGSM(ControlNames.PBR, m => m.PBR, (m, v) => m.PBR = v, m => m.Version > 2),
            CreateBGSM(ControlNames.CustomPorosity, m => m.CustomPorosity, (m, v) => m.CustomPorosity = v, m => m.Version >= 9),
            CreateBGSM(ControlNames.PorosityValue, m => m.PorosityValue, (m, v) => m.PorosityValue = v, m => m.Version >= 9),
            CreateBGSM(ControlNames.RootMaterialPath, m => m.RootMaterialPath, (m, v) => m.RootMaterialPath = v),
            CreateBGSM(ControlNames.AnisoLighting, m => m.AnisoLighting, (m, v) => m.AnisoLighting = v),
            CreateBGSM(ControlNames.EmittanceEnabled, m => m.EmitEnabled, (m, v) => m.EmitEnabled = v),
            CreateBGSM(ControlNames.EmittanceColor, m => m.EmittanceColor, (m, v) => m.EmittanceColor = v),
            CreateBGSM(ControlNames.EmittanceMultiplier, m => m.EmittanceMult, (m, v) => m.EmittanceMult = v),
            CreateBGSM(ControlNames.ModelSpaceNormals, m => m.ModelSpaceNormals, (m, v) => m.ModelSpaceNormals = v),
            CreateBGSM(ControlNames.ExternalEmittance, m => m.ExternalEmittance, (m, v) => m.ExternalEmittance = v),
            CreateBGSM(ControlNames.LumEmittance, m => m.LumEmittance, (m, v) => m.LumEmittance = v, m => m.Version >= 12),
            CreateBGSM(ControlNames.AdaptativeEmissive, m => m.UseAdaptativeEmissive, (m, v) => m.UseAdaptativeEmissive = v, m => m.Version >= 13),
            CreateBGSM(ControlNames.AdaptEmissiveExposureOffset, m => m.AdaptativeEmissive_ExposureOffset, (m, v) => m.AdaptativeEmissive_ExposureOffset = v, m => m.Version >= 13 && m.UseAdaptativeEmissive),
            CreateBGSM(ControlNames.AdaptEmissiveFinalExposureMin, m => m.AdaptativeEmissive_FinalExposureMin, (m, v) => m.AdaptativeEmissive_FinalExposureMin = v, m => m.Version >= 13 && m.UseAdaptativeEmissive),
            CreateBGSM(ControlNames.AdaptEmissiveFinalExposureMax, m => m.AdaptativeEmissive_FinalExposureMax, (m, v) => m.AdaptativeEmissive_FinalExposureMax = v, m => m.Version >= 13 && m.UseAdaptativeEmissive),
            CreateBGSM(ControlNames.BackLighting, m => m.BackLighting, (m, v) => m.BackLighting = v, m => m.Version < 8),
            CreateBGSM(ControlNames.ReceiveShadows, m => m.ReceiveShadows, (m, v) => m.ReceiveShadows = v),
            CreateBGSM(ControlNames.HideSecret, m => m.HideSecret, (m, v) => m.HideSecret = v),
            CreateBGSM(ControlNames.CastShadows, m => m.CastShadows, (m, v) => m.CastShadows = v),
            CreateBGSM(ControlNames.DissolveFade, m => m.DissolveFade, (m, v) => m.DissolveFade = v),
            CreateBGSM(ControlNames.AssumeShadowmask, m => m.AssumeShadowmask, (m, v) => m.AssumeShadowmask = v),
            CreateBGSM(ControlNames.Glowmap, m => m.Glowmap, (m, v) => m.Glowmap = v),
            CreateBGSM(ControlNames.EnvironmentMapWindow, m => m.EnvironmentMappingWindow, (m, v) => m.EnvironmentMappingWindow = v, m => m.Version < 7),
            CreateBGSM(ControlNames.EnvironmentMapEye, m => m.EnvironmentMappingEye, (m, v) => m.EnvironmentMappingEye = v, m => m.Version < 7),
            CreateBGSM(ControlNames.Hair, m => m.Hair, (m, v) => m.Hair = v),
            CreateBGSM(ControlNames.HairTintColor, m => m.HairTintColor, (m, v) => m.HairTintColor = v),
            CreateBGSM(ControlNames.Tree, m => m.Tree, (m, v) => m.Tree = v),
            CreateBGSM(ControlNames.Facegen, m => m.Facegen, (m, v) => m.Facegen = v),
            CreateBGSM(ControlNames.SkinTint, m => m.SkinTint, (m, v) => m.SkinTint = v),
            CreateBGSM(ControlNames.Tessellate, m => m.Tessellate, (m, v) => m.Tessellate = v),
            CreateBGSM(ControlNames.DisplacementTexBias, m => m.DisplacementTextureBias, (m, v) => m.DisplacementTextureBias = v, m => m.Version < 3 && m.Tessellate),
            CreateBGSM(ControlNames.DisplacementTexScale, m => m.DisplacementTextureScale, (m, v) => m.DisplacementTextureScale = v, m => m.Version < 3 && m.Tessellate),
            CreateBGSM(ControlNames.TessellationPNScale, m => m.TessellationPnScale, (m, v) => m.TessellationPnScale = v, m => m.Version < 3 && m.Tessellate),
            CreateBGSM(ControlNames.TessellationBaseFactor, m => m.TessellationBaseFactor, (m, v) => m.TessellationBaseFactor = v, m => m.Version < 3 && m.Tessellate),
            CreateBGSM(ControlNames.TessellationFadeDistance, m => m.TessellationFadeDistance, (m, v) => m.TessellationFadeDistance = v, m => m.Version < 3 && m.Tessellate),
            CreateBGSM(ControlNames.GrayscaleToPaletteScale, m => m.GrayscaleToPaletteScale, (m, v) => m.GrayscaleToPaletteScale = v),
            CreateBGSM(ControlNames.SkewSpecularAlpha, m => m.SkewSpecularAlpha, (m, v) => m.SkewSpecularAlpha = v, m => m.Version >= 1),
            CreateBGSM(ControlNames.Terrain, m => m.Terrain, (m, v) => m.Terrain = v, m => m.Version >= 3),
            CreateBGSM(ControlNames.UnkInt1BGSM, m => m.UnkInt1, (m, v) => m.UnkInt1 = v, m => m.Version == 3 && m.Terrain),
            CreateBGSM(ControlNames.TerrainThresholdFalloff, m => m.TerrainThresholdFalloff, (m, v) => m.TerrainThresholdFalloff = v, m => m.Version >= 3 && m.Terrain),
            CreateBGSM(ControlNames.TerrainTilingDistance, m => m.TerrainTilingDistance, (m, v) => m.TerrainTilingDistance = v, m => m.Version >= 3 && m.Terrain),
            CreateBGSM(ControlNames.TerrainRotationAngle, m => m.TerrainRotationAngle, (m, v) => m.TerrainRotationAngle = v, m => m.Version >= 3 && m.Terrain),
        };

        private static readonly IReadOnlyList<MaterialFieldDescriptor> EffectFields = new MaterialFieldDescriptor[] {
            CreateBGEM(ControlNames.BaseTexture, m => m.BaseTexture, (m, v) => m.BaseTexture = v),
            CreateBGEM(ControlNames.GrayscaleTexture, m => m.GrayscaleTexture, (m, v) => m.GrayscaleTexture = v),
            CreateBGEM(ControlNames.EnvmapTexture, m => m.EnvmapTexture, (m, v) => m.EnvmapTexture = v),
            CreateBGEM(ControlNames.NormalTexture, m => m.NormalTexture, (m, v) => m.NormalTexture = v),
            CreateBGEM(ControlNames.EnvmapMaskTexture, m => m.EnvmapMaskTexture, (m, v) => m.EnvmapMaskTexture = v),
            CreateBGEM(ControlNames.SpecularTexture, m => m.SpecularTexture, (m, v) => m.SpecularTexture = v, m => m.Version >= 11),
            CreateBGEM(ControlNames.LightingTexture, m => m.LightingTexture, (m, v) => m.LightingTexture = v, m => m.Version >= 11),
            CreateBGEM(ControlNames.GlowTexture, m => m.GlowTexture, (m, v) => m.GlowTexture = v, m => m.Version >= 11),
            CreateBGEM(ControlNames.GlassRoughnessScratch, m => m.GlassRoughnessScratch, (m, v) => m.GlassRoughnessScratch = v, m => m.Version >= 21),
            CreateBGEM(ControlNames.GlassDirtOverlay, m => m.GlassDirtOverlay, (m, v) => m.GlassDirtOverlay = v, m => m.Version >= 21),
            CreateBGEM(ControlNames.GlassEnabled, m => m.GlassEnabled, (m, v) => m.GlassEnabled = v, m => m.Version >= 21),
            CreateBGEM(ControlNames.GlassFresnelColor, m => m.GlassFresnelColor, (m, v) => m.GlassFresnelColor = v, m => m.Version >= 21 && m.GlassEnabled),
            CreateBGEM(ControlNames.GlassBlurScaleBase, m => m.GlassBlurScaleBase, (m, v) => m.GlassBlurScaleBase = v, m => m.Version >= 21 && m.GlassEnabled),
            CreateBGEM(ControlNames.GlassBlurScaleFactor, m => m.GlassBlurScaleFactor, (m, v) => m.GlassBlurScaleFactor = v, m => m.Version >= 22 && m.GlassEnabled),
            CreateBGEM(ControlNames.GlassRefractionScaleBase, m => m.GlassRefractionScaleBase, (m, v) => m.GlassRefractionScaleBase = v, m => m.Version >= 21 && m.GlassEnabled),
            CreateBGEM(ControlNames.EnvMapping, m => m.EnvironmentMapping, (m, v) => m.EnvironmentMapping = v, m => m.Version >= 10),
            CreateBGEM(ControlNames.EnvMappingMaskScale, m => m.EnvironmentMappingMaskScale, (m, v) => m.EnvironmentMappingMaskScale = v, m => m.Version >= 10),
            CreateBGEM(ControlNames.BloodEnabled, m => m.BloodEnabled, (m, v) => m.BloodEnabled = v),
            CreateBGEM(ControlNames.EffectLightingEnabled, m => m.EffectLightingEnabled, (m, v) => m.EffectLightingEnabled = v),
            CreateBGEM(ControlNames.FalloffEnabled, m => m.FalloffEnabled, (m, v) => m.FalloffEnabled = v),
            CreateBGEM(ControlNames.FalloffColorEnabled, m => m.FalloffColorEnabled, (m, v) => m.FalloffColorEnabled = v),
            CreateBGEM(ControlNames.GrayscaleToPaletteAlpha, m => m.GrayscaleToPaletteAlpha, (m, v) => m.GrayscaleToPaletteAlpha = v),
            CreateBGEM(ControlNames.SoftEnabled, m => m.SoftEnabled, (m, v) => m.SoftEnabled = v),
            CreateBGEM(ControlNames.BaseColor, m => m.BaseColor, (m, v) => m.BaseColor = v),
            CreateBGEM(ControlNames.BaseColorScale, m => m.BaseColorScale, (m, v) => m.BaseColorScale = v),
            CreateBGEM(ControlNames.FalloffStartAngle, m => m.FalloffStartAngle, (m, v) => m.FalloffStartAngle = v, m => m.FalloffEnabled),
            CreateBGEM(ControlNames.FalloffStopAngle, m => m.FalloffStopAngle, (m, v) => m.FalloffStopAngle = v, m => m.FalloffEnabled),
            CreateBGEM(ControlNames.FalloffStartOpacity, m => m.FalloffStartOpacity, (m, v) => m.FalloffStartOpacity = v, m => m.FalloffEnabled),
            CreateBGEM(ControlNames.FalloffStopOpacity, m => m.FalloffStopOpacity, (m, v) => m.FalloffStopOpacity = v, m => m.FalloffEnabled),
            CreateBGEM(ControlNames.LightingInfluence, m => m.LightingInfluence, (m, v) => m.LightingInfluence = v),
            CreateBGEM(ControlNames.EnvmapMinLOD, m => m.EnvmapMinLOD, (m, v) => m.EnvmapMinLOD = v),
            CreateBGEM(ControlNames.SoftDepth, m => m.SoftDepth, (m, v) => m.SoftDepth = v, m => m.SoftEnabled),
            CreateBGEM(ControlNames.EmitColor, m => m.EmittanceColor, (m, v) => m.EmittanceColor = v, m => m.Version >= 11),
            CreateBGEM(ControlNames.AdaptativeEmissiveExposureOffset, m => m.AdaptativeEmissive_ExposureOffset, (m, v) => m.AdaptativeEmissive_ExposureOffset = v, m => m.Version >= 15),
            CreateBGEM(ControlNames.AdaptativeEmissiveFinalExposureMin, m => m.AdaptativeEmissive_FinalExposureMin, (m, v) => m.AdaptativeEmissive_FinalExposureMin = v, m => m.Version >= 15),
            CreateBGEM(ControlNames.AdaptativeEmissiveFinalExposureMax, m => m.AdaptativeEmissive_FinalExposureMax, (m, v) => m.AdaptativeEmissive_FinalExposureMax = v, m => m.Version >= 15),
            CreateBGEM(ControlNames.EffectGlowmap, m => m.Glowmap, (m, v) => m.Glowmap = v, m => m.Version >= 16),
            CreateBGEM(ControlNames.EffectPBRSpecular, m => m.EffectPbrSpecular, (m, v) => m.EffectPbrSpecular = v, m => m.Version >= 20),
        };

        private static readonly IReadOnlyList<MaterialFieldDescriptor> AllFields = GeneralFields
            .Concat(MaterialFields)
            .Concat(EffectFields)
            .ToList();

        private static MaterialFieldDescriptor CreateGeneral<T>(string label, Func<BaseMaterialFile, T> getter, Action<BaseMaterialFile, T> setter, Func<BaseMaterialFile, bool> supports = null)
        {
            return new MaterialFieldDescriptor(label, FieldCategory.General, m => getter(m), (m, v) => setter(m, (T)v), supports);
        }

        private static MaterialFieldDescriptor CreateBGSM<T>(string label, Func<BGSM, T> getter, Action<BGSM, T> setter, Func<BGSM, bool> supports = null)
        {
            return new MaterialFieldDescriptor(label, FieldCategory.Material, m => getter((BGSM)m), (m, v) => setter((BGSM)m, (T)v), m => m is BGSM bgsm && (supports?.Invoke(bgsm) ?? true));
        }

        private static MaterialFieldDescriptor CreateBGEM<T>(string label, Func<BGEM, T> getter, Action<BGEM, T> setter, Func<BGEM, bool> supports = null)
        {
            return new MaterialFieldDescriptor(label, FieldCategory.Effect, m => getter((BGEM)m), (m, v) => setter((BGEM)m, (T)v), m => m is BGEM bgem && (supports?.Invoke(bgem) ?? true));
        }
    }
}
