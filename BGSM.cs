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
 */

using System;
using System.ComponentModel;
using System.IO;

namespace Material_Editor
{
    public class BGSM : BaseMaterialFile
    {
        public const uint Signature = 0x4D534742;

        #region Fields
        private string _DiffuseTexture = "";
        private string _NormalTexture = "";
        private string _SmoothSpecTexture = "";
        private string _GreyscaleTexture = "";
        private string _EnvmapTexture = "";
        private string _GlowTexture = "";
        private string _InnerLayerTexture = "";
        private string _WrinklesTexture = "";
        private string _DisplacementTexture = "";
        private bool _EnableEditorAlphaRef;
        private bool _RimLighting;
        private float _RimPower;
        private float _BackLightPower;
        private bool _SubsurfaceLighting;
        private float _SubsurfaceLightingRolloff;
        private bool _SpecularEnabled;
        private uint _SpecularColor;
        private float _SpecularMult;
        private float _Smoothness = 1.0f;
        private float _FresnelPower = 5.0f;
        private float _WetnessControlSpecScale = -1.0f;
        private float _WetnessControlSpecPowerScale = -1.0f;
        private float _WetnessControlSpecMinvar = -1.0f;
        private float _WetnessControlEnvMapScale = -1.0f;
        private float _WetnessControlFresnelPower = -1.0f;
        private float _WetnessControlMetalness = -1.0f;
        private string _RootMaterialPath = "";
        private bool _AnisoLighting;
        private bool _EmitEnabled;
        private uint _EmittanceColor;
        private float _EmittanceMult = 1.0f;
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
        private uint _HairTintColor = 0x808080;
        private bool _Tree;
        private bool _Facegen;
        private bool _SkinTint;
        private bool _Tessellate;
        private float _DisplacementTextureBias;
        private float _DisplacementTextureScale;
        private float _TessellationPNScale;
        private float _TessellationBaseFactor;
        private float _TessellationFadeDistance;
        private float _GrayscaleToPaletteScale = 1.0f;
        private bool _SkewSpecularAlpha;
        #endregion

        public BGSM()
            : base(Signature)
        {
        }

        #region Properties
        [DefaultValue("")]
        public string DiffuseTexture
        {
            get { return this._DiffuseTexture; }
            set { this._DiffuseTexture = value; }
        }

        [DefaultValue("")]
        public string NormalTexture
        {
            get { return this._NormalTexture; }
            set { this._NormalTexture = value; }
        }

        [DefaultValue("")]
        public string SmoothSpecTexture
        {
            get { return this._SmoothSpecTexture; }
            set { this._SmoothSpecTexture = value; }
        }

        [DefaultValue("")]
        public string GreyscaleTexture
        {
            get { return this._GreyscaleTexture; }
            set { this._GreyscaleTexture = value; }
        }

        [DefaultValue("")]
        public string EnvmapTexture
        {
            get { return this._EnvmapTexture; }
            set { this._EnvmapTexture = value; }
        }

        [DefaultValue("")]
        public string GlowTexture
        {
            get { return this._GlowTexture; }
            set { this._GlowTexture = value; }
        }

        [DefaultValue("")]
        public string InnerLayerTexture
        {
            get { return this._InnerLayerTexture; }
            set { this._InnerLayerTexture = value; }
        }

        [DefaultValue("")]
        public string WrinklesTexture
        {
            get { return this._WrinklesTexture; }
            set { this._WrinklesTexture = value; }
        }

        [DefaultValue("")]
        public string DisplacementTexture
        {
            get { return this._DisplacementTexture; }
            set { this._DisplacementTexture = value; }
        }

        public bool EnableEditorAlphaRef
        {
            get { return this._EnableEditorAlphaRef; }
            set { this._EnableEditorAlphaRef = value; }
        }

        public bool RimLighting
        {
            get { return this._RimLighting; }
            set { this._RimLighting = value; }
        }

        public float RimPower
        {
            get { return this._RimPower; }
            set { this._RimPower = value; }
        }

        public float BackLightPower
        {
            get { return this._BackLightPower; }
            set { this._BackLightPower = value; }
        }

        public bool SubsurfaceLighting
        {
            get { return this._SubsurfaceLighting; }
            set { this._SubsurfaceLighting = value; }
        }

        public float SubsurfaceLightingRolloff
        {
            get { return this._SubsurfaceLightingRolloff; }
            set { this._SubsurfaceLightingRolloff = value; }
        }

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

        public float SpecularMult
        {
            get { return this._SpecularMult; }
            set { this._SpecularMult = value; }
        }

        [DefaultValue(1.0f)]
        public float Smoothness
        {
            get { return this._Smoothness; }
            set { this._Smoothness = value; }
        }

        [DefaultValue(5.0f)]
        public float FresnelPower
        {
            get { return this._FresnelPower; }
            set { this._FresnelPower = value; }
        }

        [DefaultValue(-1.0f)]
        public float WetnessControlSpecScale
        {
            get { return this._WetnessControlSpecScale; }
            set { this._WetnessControlSpecScale = value; }
        }

        [DefaultValue(-1.0f)]
        public float WetnessControlSpecPowerScale
        {
            get { return this._WetnessControlSpecPowerScale; }
            set { this._WetnessControlSpecPowerScale = value; }
        }

        [DefaultValue(-1.0f)]
        public float WetnessControlSpecMinvar
        {
            get { return this._WetnessControlSpecMinvar; }
            set { this._WetnessControlSpecMinvar = value; }
        }

        [DefaultValue(-1.0f)]
        public float WetnessControlEnvMapScale
        {
            get { return this._WetnessControlEnvMapScale; }
            set { this._WetnessControlEnvMapScale = value; }
        }

        [DefaultValue(-1.0f)]
        public float WetnessControlFresnelPower
        {
            get { return this._WetnessControlFresnelPower; }
            set { this._WetnessControlFresnelPower = value; }
        }

        [DefaultValue(-1.0f)]
        public float WetnessControlMetalness
        {
            get { return this._WetnessControlMetalness; }
            set { this._WetnessControlMetalness = value; }
        }

        public string RootMaterialPath
        {
            get { return this._RootMaterialPath; }
            set { this._RootMaterialPath = value; }
        }

        public bool AnisoLighting
        {
            get { return this._AnisoLighting; }
            set { this._AnisoLighting = value; }
        }

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

        [DefaultValue(1.0f)]
        public float EmittanceMult
        {
            get { return this._EmittanceMult; }
            set { this._EmittanceMult = value; }
        }

        public bool ModelSpaceNormals
        {
            get { return this._ModelSpaceNormals; }
            set { this._ModelSpaceNormals = value; }
        }

        public bool ExternalEmittance
        {
            get { return this._ExternalEmittance; }
            set { this._ExternalEmittance = value; }
        }

        public bool BackLighting
        {
            get { return this._BackLighting; }
            set { this._BackLighting = value; }
        }

        public bool ReceiveShadows
        {
            get { return this._ReceiveShadows; }
            set { this._ReceiveShadows = value; }
        }

        public bool HideSecret
        {
            get { return this._HideSecret; }
            set { this._HideSecret = value; }
        }

        public bool CastShadows
        {
            get { return this._CastShadows; }
            set { this._CastShadows = value; }
        }

        public bool DissolveFade
        {
            get { return this._DissolveFade; }
            set { this._DissolveFade = value; }
        }

        public bool AssumeShadowmask
        {
            get { return this._AssumeShadowmask; }
            set { this._AssumeShadowmask = value; }
        }

        public bool Glowmap
        {
            get { return this._Glowmap; }
            set { this._Glowmap = value; }
        }

        public bool EnvironmentMappingWindow
        {
            get { return this._EnvironmentMappingWindow; }
            set { this._EnvironmentMappingWindow = value; }
        }

        public bool EnvironmentMappingEye
        {
            get { return this._EnvironmentMappingEye; }
            set { this._EnvironmentMappingEye = value; }
        }

        public bool Hair
        {
            get { return this._Hair; }
            set { this._Hair = value; }
        }

        [DefaultValue(0x808080u)]
        public uint HairTintColor
        {
            get { return this._HairTintColor; }
            set { this._HairTintColor = value; }
        }

        public bool Tree
        {
            get { return this._Tree; }
            set { this._Tree = value; }
        }

        public bool Facegen
        {
            get { return this._Facegen; }
            set { this._Facegen = value; }
        }

        public bool SkinTint
        {
            get { return this._SkinTint; }
            set { this._SkinTint = value; }
        }

        public bool Tessellate
        {
            get { return this._Tessellate; }
            set { this._Tessellate = value; }
        }

        public float DisplacementTextureBias
        {
            get { return this._DisplacementTextureBias; }
            set { this._DisplacementTextureBias = value; }
        }

        public float DisplacementTextureScale
        {
            get { return this._DisplacementTextureScale; }
            set { this._DisplacementTextureScale = value; }
        }

        public float TessellationPnScale
        {
            get { return this._TessellationPNScale; }
            set { this._TessellationPNScale = value; }
        }

        public float TessellationBaseFactor
        {
            get { return this._TessellationBaseFactor; }
            set { this._TessellationBaseFactor = value; }
        }

        public float TessellationFadeDistance
        {
            get { return this._TessellationFadeDistance; }
            set { this._TessellationFadeDistance = value; }
        }

        [DefaultValue(1.0f)]
        public float GrayscaleToPaletteScale
        {
            get { return this._GrayscaleToPaletteScale; }
            set { this._GrayscaleToPaletteScale = value; }
        }

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
