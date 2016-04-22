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
    public class BGEM : BaseMaterialFile
    {
        public const uint Signature = 0x4D454742u;

        #region Fields
        private string _BaseTexture;
        private string _GrayscaleTexture;
        private string _EnvmapTexture;
        private string _NormalTexture;
        private string _EnvmapMaskTexture;
        private bool _BloodEnabled;
        private bool _EffectLightingEnabled;
        private bool _FalloffEnabled;
        private bool _FalloffColorEnabled;
        private bool _GrayscaleToPaletteAlpha;
        private bool _SoftEnabled;
        private uint _BaseColor;
        private float _BaseColorScale;
        private float _FalloffStartAngle;
        private float _FalloffStopAngle;
        private float _FalloffStartOpacity;
        private float _FalloffStopOpacity;
        private float _LightingInfluence;
        private byte _EnvmapMinLOD;
        private float _SoftDepth;

        protected override void SetDefaults()
        {
            base.SetDefaults();

            _BaseTexture = "";
            _GrayscaleTexture = "";
            _EnvmapTexture = "";
            _NormalTexture = "";
            _EnvmapMaskTexture = "";
            _BaseColor = 0xFFFFFFFFu;
            _BaseColorScale = 1.0f;
            _FalloffStartAngle = 1.0f;
            _FalloffStopAngle = 1.0f;
            _LightingInfluence = 1.0f;
            _SoftDepth = 100.0f;
        }
        #endregion

        public BGEM()
            : base(Signature)
        {
        }

        #region Properties
        [DataMember(Name = "sBaseTexture")]
        public string BaseTexture
        {
            get { return this._BaseTexture; }
            set { this._BaseTexture = value; }
        }

        [DataMember(Name = "sGrayscaleTexture")]
        public string GrayscaleTexture
        {
            get { return this._GrayscaleTexture; }
            set { this._GrayscaleTexture = value; }
        }

        [DataMember(Name = "sEnvmapTexture")]
        public string EnvmapTexture
        {
            get { return this._EnvmapTexture; }
            set { this._EnvmapTexture = value; }
        }

        [DataMember(Name = "sNormalTexture")]
        public string NormalTexture
        {
            get { return this._NormalTexture; }
            set { this._NormalTexture = value; }
        }

        [DataMember(Name = "sEnvmapMaskTexture")]
        public string EnvmapMaskTexture
        {
            get { return this._EnvmapMaskTexture; }
            set { this._EnvmapMaskTexture = value; }
        }

        [DataMember(Name = "bBloodEnabled")]
        public bool BloodEnabled
        {
            get { return this._BloodEnabled; }
            set { this._BloodEnabled = value; }
        }

        [DataMember(Name = "bEffectLightingEnabled")]
        public bool EffectLightingEnabled
        {
            get { return this._EffectLightingEnabled; }
            set { this._EffectLightingEnabled = value; }
        }

        [DataMember(Name = "bFalloffEnabled")]
        public bool FalloffEnabled
        {
            get { return this._FalloffEnabled; }
            set { this._FalloffEnabled = value; }
        }

        [DataMember(Name = "bFalloffColorEnabled")]
        public bool FalloffColorEnabled
        {
            get { return this._FalloffColorEnabled; }
            set { this._FalloffColorEnabled = value; }
        }

        [DataMember(Name = "bGrayscaleToPaletteAlpha")]
        public bool GrayscaleToPaletteAlpha
        {
            get { return this._GrayscaleToPaletteAlpha; }
            set { this._GrayscaleToPaletteAlpha = value; }
        }

        [DataMember(Name = "bSoftEnabled")]
        public bool SoftEnabled
        {
            get { return this._SoftEnabled; }
            set { this._SoftEnabled = value; }
        }

        public uint BaseColor
        {
            get { return this._BaseColor; }
            set { this._BaseColor = value; }
        }

        [DataMember(Name = "cBaseColor")]
        string BaseColorString
        {
            get { return Color.FromUInt32(_BaseColor).ToHexString(); }
            set { _BaseColor = Color.FromHexString(value).ToUInt32(); }
        }

        [DataMember]
        public float BaseColorScale
        {
            get { return this._BaseColorScale; }
            set { this._BaseColorScale = value; }
        }

        [DataMember(Name = "fFalloffStartAngle")]
        public float FalloffStartAngle
        {
            get { return this._FalloffStartAngle; }
            set { this._FalloffStartAngle = value; }
        }

        [DataMember(Name = "fFalloffStopAngle")]
        public float FalloffStopAngle
        {
            get { return this._FalloffStopAngle; }
            set { this._FalloffStopAngle = value; }
        }

        [DataMember(Name = "fFalloffStartOpacity")]
        public float FalloffStartOpacity
        {
            get { return this._FalloffStartOpacity; }
            set { this._FalloffStartOpacity = value; }
        }

        [DataMember(Name = "fFalloffStopOpacity")]
        public float FalloffStopOpacity
        {
            get { return this._FalloffStopOpacity; }
            set { this._FalloffStopOpacity = value; }
        }

        [DataMember(Name = "fLightingInfluence")]
        public float LightingInfluence
        {
            get { return this._LightingInfluence; }
            set { this._LightingInfluence = value; }
        }

        [DataMember(Name = "iEnvmapMinLOD")]
        public byte EnvmapMinLOD
        {
            get { return this._EnvmapMinLOD; }
            set { this._EnvmapMinLOD = value; }
        }

        [DataMember(Name = "fSoftDepth")]
        public float SoftDepth
        {
            get { return this._SoftDepth; }
            set { this._SoftDepth = value; }
        }
        #endregion

        public override void Deserialize(BinaryReader input)
        {
            base.Deserialize(input);

            this._BaseTexture = ReadString(input);
            this._GrayscaleTexture = ReadString(input);
            this._EnvmapTexture = ReadString(input);
            this._NormalTexture = ReadString(input);
            this._EnvmapMaskTexture = ReadString(input);
            this._BloodEnabled = input.ReadBoolean();
            this._EffectLightingEnabled = input.ReadBoolean();
            this._FalloffEnabled = input.ReadBoolean();
            this._FalloffColorEnabled = input.ReadBoolean();
            this._GrayscaleToPaletteAlpha = input.ReadBoolean();
            this._SoftEnabled = input.ReadBoolean();
            this._BaseColor = Color.Read(input).ToUInt32();
            this._BaseColorScale = input.ReadSingle();
            this._FalloffStartAngle = input.ReadSingle();
            this._FalloffStopAngle = input.ReadSingle();
            this._FalloffStartOpacity = input.ReadSingle();
            this._FalloffStopOpacity = input.ReadSingle();
            this._LightingInfluence = input.ReadSingle();
            this._EnvmapMinLOD = input.ReadByte();
            this._SoftDepth = input.ReadSingle();
        }

        public override void Serialize(BinaryWriter output)
        {
            base.Serialize(output);

            WriteString(output, this._BaseTexture);
            WriteString(output, this._GrayscaleTexture);
            WriteString(output, this._EnvmapTexture);
            WriteString(output, this._NormalTexture);
            WriteString(output, this._EnvmapMaskTexture);

            output.Write(this._BloodEnabled);
            output.Write(this._EffectLightingEnabled);
            output.Write(this._FalloffEnabled);
            output.Write(this._FalloffColorEnabled);
            output.Write(this._GrayscaleToPaletteAlpha);
            output.Write(this._SoftEnabled);
            Color.FromUInt32(this._BaseColor).Write(output);
            output.Write(this._BaseColorScale);
            output.Write(this._FalloffStartAngle);
            output.Write(this._FalloffStopAngle);
            output.Write(this._FalloffStartOpacity);
            output.Write(this._FalloffStopOpacity);
            output.Write(this._LightingInfluence);
            output.Write(this._EnvmapMinLOD);
            output.Write(this._SoftDepth);
        }
    }
}
