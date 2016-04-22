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
 */

using System;
using System.IO;
using System.Runtime.Serialization;

namespace Material_Editor
{
    [DataContract]
    public class BGSM : BaseMaterialFile
    {
        public const uint Signature = 0x4D534742u;

        #region Fields
        private string _DiffuseTexture;
        private string _NormalTexture;
        private string _SmoothSpecTexture;
        private string _GreyscaleTexture;
        private string _EnvmapTexture;
        private string _GlowTexture;
        private string _InnerLayerTexture;
        private string _WrinklesTexture;
        private string _DisplacementTexture;
        private bool _EnableEditorAlphaRef;
        private bool _RimLighting;
        private float _RimPower;
        private float _BackLightPower;
        private bool _SubsurfaceLighting;
        private float _SubsurfaceLightingRolloff;
        private bool _SpecularEnabled;
        private uint _SpecularColor;
        private float _SpecularMult;
        private float _Smoothness;
        private float _FresnelPower;
        private float _WetnessControlSpecScale;
        private float _WetnessControlSpecPowerScale;
        private float _WetnessControlSpecMinvar;
        private float _WetnessControlEnvMapScale;
        private float _WetnessControlFresnelPower;
        private float _WetnessControlMetalness;
        private string _RootMaterialPath;
        private bool _AnisoLighting;
        private bool _EmitEnabled;
        private uint _EmittanceColor;
        private float _EmittanceMult;
        private bool _ModelSpaceNormals;
        private bool _ExternalEmittance;
        private bool _BackLighting;
        private bool _ReceiveShadows;
        private bool _HideSecret;
        private bool _CastShadows;
        private bool _DissolveFade;
        private bool _AssumeShadowmask;
        private bool _Glowmap;
        private bool _EnvironmentMappingWindow;
        private bool _EnvironmentMappingEye;
        private bool _Hair;
        private uint _HairTintColor;
        private bool _Tree;
        private bool _Facegen;
        private bool _SkinTint;
        private bool _Tessellate;
        private float _DisplacementTextureBias;
        private float _DisplacementTextureScale;
        private float _TessellationPNScale;
        private float _TessellationBaseFactor;
        private float _TessellationFadeDistance;
        private float _GrayscaleToPaletteScale;
        private bool _SkewSpecularAlpha;

        protected override void SetDefaults()
        {
            base.SetDefaults();

            _DiffuseTexture = "";
            _NormalTexture = "";
            _SmoothSpecTexture = "";
            _GreyscaleTexture = "";
            _EnvmapTexture = "";
            _GlowTexture = "";
            _InnerLayerTexture = "";
            _WrinklesTexture = "";
            _DisplacementTexture = "";
            _RimPower = 2.0f;
            _SubsurfaceLightingRolloff = 0.3f;
            _SpecularColor = 0xFFFFFFFFu;
            _SpecularMult = 1.0f;
            _Smoothness = 1.0f;
            _FresnelPower = 5.0f;
            _WetnessControlSpecScale = -1.0f;
            _WetnessControlSpecPowerScale = -1.0f;
            _WetnessControlSpecMinvar = -1.0f;
            _WetnessControlEnvMapScale = -1.0f;
            _WetnessControlFresnelPower = -1.0f;
            _WetnessControlMetalness = -1.0f;
            _RootMaterialPath = "";
            _EmittanceColor = 0xFFFFFFFFu;
            _EmittanceMult = 1.0f;
            _HairTintColor = 0x808080u;
            _DisplacementTextureBias = -0.5f;
            _DisplacementTextureScale = 10.0f;
            _TessellationPNScale = 1.0f;
            _TessellationBaseFactor = 1.0f;
            _GrayscaleToPaletteScale = 1.0f;
        }
        #endregion

        public BGSM()
            : base(Signature)
        {
        }

        #region Properties
        [DataMember(Name = "sDiffuseTexture")]
        public string DiffuseTexture
        {
            get { return this._DiffuseTexture; }
            set { this._DiffuseTexture = value; }
        }

        [DataMember(Name = "sNormalTexture")]
        public string NormalTexture
        {
            get { return this._NormalTexture; }
            set { this._NormalTexture = value; }
        }

        [DataMember(Name = "sSmoothSpecTexture")]
        public string SmoothSpecTexture
        {
            get { return this._SmoothSpecTexture; }
            set { this._SmoothSpecTexture = value; }
        }

        [DataMember(Name = "sGreyscaleTexture")]
        public string GreyscaleTexture
        {
            get { return this._GreyscaleTexture; }
            set { this._GreyscaleTexture = value; }
        }

        [DataMember(Name = "sEnvmapTexture")]
        public string EnvmapTexture
        {
            get { return this._EnvmapTexture; }
            set { this._EnvmapTexture = value; }
        }

        [DataMember(Name = "sGlowTexture")]
        public string GlowTexture
        {
            get { return this._GlowTexture; }
            set { this._GlowTexture = value; }
        }

        [DataMember(Name = "sInnerLayerTexture")]
        public string InnerLayerTexture
        {
            get { return this._InnerLayerTexture; }
            set { this._InnerLayerTexture = value; }
        }

        [DataMember(Name = "sWrinklesTexture")]
        public string WrinklesTexture
        {
            get { return this._WrinklesTexture; }
            set { this._WrinklesTexture = value; }
        }

        [DataMember(Name = "sDisplacementTexture")]
        public string DisplacementTexture
        {
            get { return this._DisplacementTexture; }
            set { this._DisplacementTexture = value; }
        }

        [DataMember(Name = "bEnableEditorAlphaRef")]
        public bool EnableEditorAlphaRef
        {
            get { return this._EnableEditorAlphaRef; }
            set { this._EnableEditorAlphaRef = value; }
        }

        [DataMember(Name = "bRimLighting")]
        public bool RimLighting
        {
            get { return this._RimLighting; }
            set { this._RimLighting = value; }
        }

        [DataMember(Name = "fRimPower")]
        public float RimPower
        {
            get { return this._RimPower; }
            set { this._RimPower = value; }
        }

        [DataMember(Name = "fBackLightPower")]
        public float BackLightPower
        {
            get { return this._BackLightPower; }
            set { this._BackLightPower = value; }
        }

        [DataMember(Name = "bSubsurfaceLighting")]
        public bool SubsurfaceLighting
        {
            get { return this._SubsurfaceLighting; }
            set { this._SubsurfaceLighting = value; }
        }

        [DataMember(Name = "fSubsurfaceLightingRolloff")]
        public float SubsurfaceLightingRolloff
        {
            get { return this._SubsurfaceLightingRolloff; }
            set { this._SubsurfaceLightingRolloff = value; }
        }

        [DataMember(Name = "bSpecularEnabled")]
        public bool SpecularEnabled
        {
            get { return this._SpecularEnabled; }
            set { this._SpecularEnabled = value; }
        }

        public uint SpecularColor
        {
            get { return this._SpecularColor; }
            set { this._SpecularColor = value; }
        }

        [DataMember(Name = "cSpecularColor")]
        string SpecularColorString
        {
            get { return Color.FromUInt32(_SpecularColor).ToHexString(); }
            set { _SpecularColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fSpecularMult")]
        public float SpecularMult
        {
            get { return this._SpecularMult; }
            set { this._SpecularMult = value; }
        }

        [DataMember(Name = "fSmoothness")]
        public float Smoothness
        {
            get { return this._Smoothness; }
            set { this._Smoothness = value; }
        }

        [DataMember(Name = "fFresnelPower")]
        public float FresnelPower
        {
            get { return this._FresnelPower; }
            set { this._FresnelPower = value; }
        }

        [DataMember(Name = "fWetnessControl_SpecScale")]
        public float WetnessControlSpecScale
        {
            get { return this._WetnessControlSpecScale; }
            set { this._WetnessControlSpecScale = value; }
        }

        [DataMember(Name = "fWetnessControl_SpecPowerScale")]
        public float WetnessControlSpecPowerScale
        {
            get { return this._WetnessControlSpecPowerScale; }
            set { this._WetnessControlSpecPowerScale = value; }
        }

        [DataMember(Name = "fWetnessControl_SpecMinvar")]
        public float WetnessControlSpecMinvar
        {
            get { return this._WetnessControlSpecMinvar; }
            set { this._WetnessControlSpecMinvar = value; }
        }

        [DataMember(Name = "fWetnessControl_EnvMapScale")]
        public float WetnessControlEnvMapScale
        {
            get { return this._WetnessControlEnvMapScale; }
            set { this._WetnessControlEnvMapScale = value; }
        }

        [DataMember(Name = "fWetnessControl_FresnelPower")]
        public float WetnessControlFresnelPower
        {
            get { return this._WetnessControlFresnelPower; }
            set { this._WetnessControlFresnelPower = value; }
        }

        [DataMember(Name = "fWetnessControl_Metalness")]
        public float WetnessControlMetalness
        {
            get { return this._WetnessControlMetalness; }
            set { this._WetnessControlMetalness = value; }
        }

        [DataMember(Name = "sRootMaterialPath")]
        public string RootMaterialPath
        {
            get { return this._RootMaterialPath; }
            set { this._RootMaterialPath = value; }
        }

        [DataMember(Name = "bAnisoLighting")]
        public bool AnisoLighting
        {
            get { return this._AnisoLighting; }
            set { this._AnisoLighting = value; }
        }

        [DataMember(Name = "bEmitEnabled")]
        public bool EmitEnabled
        {
            get { return this._EmitEnabled; }
            set { this._EmitEnabled = value; }
        }

        public uint EmittanceColor
        {
            get { return this._EmittanceColor; }
            set { this._EmittanceColor = value; }
        }

        [DataMember(Name = "cEmittanceColor")]
        string EmittanceColorString
        {
            get { return Color.FromUInt32(_EmittanceColor).ToHexString(); }
            set { _EmittanceColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "fEmittanceMult")]
        public float EmittanceMult
        {
            get { return this._EmittanceMult; }
            set { this._EmittanceMult = value; }
        }

        [DataMember(Name = "bModelSpaceNormals")]
        public bool ModelSpaceNormals
        {
            get { return this._ModelSpaceNormals; }
            set { this._ModelSpaceNormals = value; }
        }

        [DataMember(Name = "bExternalEmittance")]
        public bool ExternalEmittance
        {
            get { return this._ExternalEmittance; }
            set { this._ExternalEmittance = value; }
        }

        [DataMember(Name = "bBackLighting")]
        public bool BackLighting
        {
            get { return this._BackLighting; }
            set { this._BackLighting = value; }
        }

        [DataMember(Name = "bReceiveShadows")]
        public bool ReceiveShadows
        {
            get { return this._ReceiveShadows; }
            set { this._ReceiveShadows = value; }
        }

        [DataMember(Name = "bHideSecret")]
        public bool HideSecret
        {
            get { return this._HideSecret; }
            set { this._HideSecret = value; }
        }

        [DataMember(Name = "bCastShadows")]
        public bool CastShadows
        {
            get { return this._CastShadows; }
            set { this._CastShadows = value; }
        }

        [DataMember(Name = "bDissolveFade")]
        public bool DissolveFade
        {
            get { return this._DissolveFade; }
            set { this._DissolveFade = value; }
        }

        [DataMember(Name = "bAssumeShadowmask")]
        public bool AssumeShadowmask
        {
            get { return this._AssumeShadowmask; }
            set { this._AssumeShadowmask = value; }
        }

        [DataMember(Name = "bGlowmap")]
        public bool Glowmap
        {
            get { return this._Glowmap; }
            set { this._Glowmap = value; }
        }

        [DataMember(Name = "bEnvironmentMappingWindow")]
        public bool EnvironmentMappingWindow
        {
            get { return this._EnvironmentMappingWindow; }
            set { this._EnvironmentMappingWindow = value; }
        }

        [DataMember(Name = "bEnvironmentMappingEye")]
        public bool EnvironmentMappingEye
        {
            get { return this._EnvironmentMappingEye; }
            set { this._EnvironmentMappingEye = value; }
        }

        [DataMember(Name = "bHair")]
        public bool Hair
        {
            get { return this._Hair; }
            set { this._Hair = value; }
        }

        public uint HairTintColor
        {
            get { return this._HairTintColor; }
            set { this._HairTintColor = value; }
        }

        [DataMember(Name = "cHairTintColor")]
        string HairTintColorString
        {
            get { return Color.FromUInt32(_HairTintColor).ToHexString(); }
            set { _HairTintColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember(Name = "bTree")]
        public bool Tree
        {
            get { return this._Tree; }
            set { this._Tree = value; }
        }

        [DataMember(Name = "bFacegen")]
        public bool Facegen
        {
            get { return this._Facegen; }
            set { this._Facegen = value; }
        }

        [DataMember(Name = "bSkinTint")]
        public bool SkinTint
        {
            get { return this._SkinTint; }
            set { this._SkinTint = value; }
        }

        [DataMember(Name = "bTessellate")]
        public bool Tessellate
        {
            get { return this._Tessellate; }
            set { this._Tessellate = value; }
        }

        [DataMember(Name = "fDisplacementTextureBias")]
        public float DisplacementTextureBias
        {
            get { return this._DisplacementTextureBias; }
            set { this._DisplacementTextureBias = value; }
        }

        [DataMember(Name = "fDisplacementTextureScale")]
        public float DisplacementTextureScale
        {
            get { return this._DisplacementTextureScale; }
            set { this._DisplacementTextureScale = value; }
        }

        [DataMember(Name = "fTessellationPnScale")]
        public float TessellationPnScale
        {
            get { return this._TessellationPNScale; }
            set { this._TessellationPNScale = value; }
        }

        [DataMember(Name = "fTessellationBaseFactor")]
        public float TessellationBaseFactor
        {
            get { return this._TessellationBaseFactor; }
            set { this._TessellationBaseFactor = value; }
        }

        [DataMember(Name = "fTessellationFadeDistance")]
        public float TessellationFadeDistance
        {
            get { return this._TessellationFadeDistance; }
            set { this._TessellationFadeDistance = value; }
        }

        [DataMember(Name = "fGrayscaleToPaletteScale")]
        public float GrayscaleToPaletteScale
        {
            get { return this._GrayscaleToPaletteScale; }
            set { this._GrayscaleToPaletteScale = value; }
        }

        [DataMember(Name = "bSkewSpecularAlpha")]
        public bool SkewSpecularAlpha
        {
            get { return this._SkewSpecularAlpha; }
            set { this._SkewSpecularAlpha = value; }
        }
        #endregion

        public override void Deserialize(BinaryReader input)
        {
            base.Deserialize(input);
            var version = this.Version;

            this._DiffuseTexture = ReadString(input);
            this._NormalTexture = ReadString(input);
            this._SmoothSpecTexture = ReadString(input);
            this._GreyscaleTexture = ReadString(input);
            this._EnvmapTexture = ReadString(input);
            this._GlowTexture = ReadString(input);
            this._InnerLayerTexture = ReadString(input);
            this._WrinklesTexture = ReadString(input);
            this._DisplacementTexture = ReadString(input);

            this._EnableEditorAlphaRef = input.ReadBoolean();
            this._RimLighting = input.ReadBoolean();
            this._RimPower = input.ReadSingle();
            this._BackLightPower = input.ReadSingle();

            this._SubsurfaceLighting = input.ReadBoolean();
            this._SubsurfaceLightingRolloff = input.ReadSingle();

            this._SpecularEnabled = input.ReadBoolean();
            this._SpecularColor = Color.Read(input).ToUInt32();
            this._SpecularMult = input.ReadSingle();
            this._Smoothness = input.ReadSingle();
            this._FresnelPower = input.ReadSingle();
            this._WetnessControlSpecScale = input.ReadSingle();
            this._WetnessControlSpecPowerScale = input.ReadSingle();
            this._WetnessControlSpecMinvar = input.ReadSingle();
            this._WetnessControlEnvMapScale = input.ReadSingle();
            this._WetnessControlFresnelPower = input.ReadSingle();
            this._WetnessControlMetalness = input.ReadSingle();

            this._RootMaterialPath = ReadString(input);

            this._AnisoLighting = input.ReadBoolean();
            this._EmitEnabled = input.ReadBoolean();
            this._EmittanceColor = this._EmitEnabled == true ? Color.Read(input).ToUInt32() : 0;
            this._EmittanceMult = input.ReadSingle();
            this._ModelSpaceNormals = input.ReadBoolean();
            this._ExternalEmittance = input.ReadBoolean();
            this._BackLighting = input.ReadBoolean();

            this._ReceiveShadows = input.ReadBoolean();
            this._HideSecret = input.ReadBoolean();
            this._CastShadows = input.ReadBoolean();
            this._DissolveFade = input.ReadBoolean();
            this._AssumeShadowmask = input.ReadBoolean();

            this._Glowmap = input.ReadBoolean();
            this._EnvironmentMappingWindow = input.ReadBoolean();
            this._EnvironmentMappingEye = input.ReadBoolean();
            this._Hair = input.ReadBoolean();
            this._HairTintColor = Color.Read(input).ToUInt32();
            this._Tree = input.ReadBoolean();
            this._Facegen = input.ReadBoolean();
            this._SkinTint = input.ReadBoolean();

            this._Tessellate = input.ReadBoolean();
            this._DisplacementTextureBias = input.ReadSingle();
            this._DisplacementTextureScale = input.ReadSingle();
            this._TessellationPNScale = input.ReadSingle();
            this._TessellationBaseFactor = input.ReadSingle();
            this._TessellationFadeDistance = input.ReadSingle();

            this._GrayscaleToPaletteScale = input.ReadSingle();
            this._SkewSpecularAlpha = version >= 1 && input.ReadBoolean();
        }

        public override void Serialize(BinaryWriter output)
        {
            base.Serialize(output);

            WriteString(output, this._DiffuseTexture);
            WriteString(output, this._NormalTexture);
            WriteString(output, this._SmoothSpecTexture);
            WriteString(output, this._GreyscaleTexture);
            WriteString(output, this._EnvmapTexture);
            WriteString(output, this._GlowTexture);
            WriteString(output, this._InnerLayerTexture);
            WriteString(output, this._WrinklesTexture);
            WriteString(output, this._DisplacementTexture);

            output.Write(this._EnableEditorAlphaRef);
            output.Write(this._RimLighting);
            output.Write(this._RimPower);
            output.Write(this._BackLightPower);

            output.Write(this._SubsurfaceLighting);
            output.Write(this._SubsurfaceLightingRolloff);

            output.Write(this._SpecularEnabled);
            Color.FromUInt32(this._SpecularColor).Write(output);
            output.Write(this._SpecularMult);
            output.Write(this._Smoothness);
            output.Write(this._FresnelPower);
            output.Write(this._WetnessControlSpecScale);
            output.Write(this._WetnessControlSpecPowerScale);
            output.Write(this._WetnessControlSpecMinvar);
            output.Write(this._WetnessControlEnvMapScale);
            output.Write(this._WetnessControlFresnelPower);
            output.Write(this._WetnessControlMetalness);

            WriteString(output, this._RootMaterialPath);

            output.Write(this._AnisoLighting);
            output.Write(this._EmitEnabled);
            if (this._EmitEnabled)
                Color.FromUInt32(this._EmittanceColor).Write(output);

            output.Write(this._EmittanceMult);
            output.Write(this._ModelSpaceNormals);
            output.Write(this._ExternalEmittance);
            output.Write(this._BackLighting);

            output.Write(this._ReceiveShadows);
            output.Write(this._HideSecret);
            output.Write(this._CastShadows);
            output.Write(this._DissolveFade);
            output.Write(this._AssumeShadowmask);

            output.Write(this._Glowmap);
            output.Write(this._EnvironmentMappingWindow);
            output.Write(this._EnvironmentMappingEye);
            output.Write(this._Hair);
            Color.FromUInt32(this._HairTintColor).Write(output);
            output.Write(this._Tree);
            output.Write(this._Facegen);
            output.Write(this._SkinTint);

            output.Write(this._Tessellate);
            output.Write(this._DisplacementTextureBias);
            output.Write(this._DisplacementTextureScale);
            output.Write(this._TessellationPNScale);
            output.Write(this._TessellationBaseFactor);
            output.Write(this._TessellationFadeDistance);

            output.Write(this._GrayscaleToPaletteScale);
            if (this.Version >= 1)
                output.Write(this._SkewSpecularAlpha);
        }
    }
}
