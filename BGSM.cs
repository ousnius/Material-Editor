using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Material_Editor
{
    struct ColorRGB
    {
        public float Red;
        public float Green;
        public float Blue;

        public ColorRGB(float r, float g, float b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }
    }

    class BGSM
    {
        string header = "BGSM";
        public uint unk1;
        public uint unk2;
        public uint unk3;
        public uint unk4;

        public float unkF1;
        public float unkF2;
        public float unkF3;

        public uint flags1 = 1536;
        public uint flags2 = 1792;

        public byte mysteryB1;
        public byte mysteryB2;
        public bool useAlpha = false;
        public byte mysteryB4;
        public byte mysteryB5;
        public byte mysteryB6;
        public byte mysteryB7;
        public byte mysteryB8;
        public bool useDoubleSided = false;
        public byte mysteryB10;
        public byte mysteryB11;
        public byte mysteryB12;
        public byte mysteryB13;
        public byte mysteryB14;
        public byte mysteryB15;
        public byte mysteryB16;
        public byte mysteryB17;
        public byte mysteryB18;
        public byte mysteryB19;
        public byte mysteryB20;
        public byte mysteryB21;
        public byte mysteryB22;
        public byte mysteryB23;

        public List<string> textures = Enumerable.Repeat(string.Empty, 9).ToList();

        public byte unkB1;
        public byte unkB2;

        public float unkF4;
        public float unkF5;

        public byte unkB3;
        public float unkF6;

        public bool useWet = true;

        public ColorRGB unkColor1 = new ColorRGB(1.0f, 1.0f, 1.0f);
        public float specularStrength = 1.0f;

        public float unkF7_5;
        public float unkF7_6;
        public float unkF7_7;
        public float unkF7_8;
        public float unkF7_9;
        public float unkF7_10;
        public float unkF7_11;
        public float unkF7_12;

        public string template = "";

        public byte unkB5;
        public byte unkB6;
        public float unkF8;

        public byte unkB7;
        public byte unkB8;
        public byte unkB9;
        public byte unkB10;
        public byte unkB11;
        public byte unkB12;
        public byte unkB13;
        public byte unkB14;
        public byte unkB15;
        public byte unkB16;
        public byte unkB17;
        public byte unkB18;

        public ColorRGB unkColor2 = new ColorRGB(1.0f, 1.0f, 1.0f);

        public byte unkB19;
        public byte unkB20;
        public bool useSkinColor = false;
        public byte unkB21;

        public float unkF12;
        public float unkF13;
        public float unkF14;
        public float unkF15;
        public float unkF16;
        public float unkF17;

        public byte unkB22;

        public BGSM(string fileName = null)
        {
            if (!string.IsNullOrEmpty(fileName))
                Open(fileName);
        }

        public bool Open(string fileName)
        {
            try
            {
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(file))
                    {
                        header = new string(reader.ReadChars(4));
                        if (header == "BGSM")
                        {
                            unk1 = reader.ReadUInt32();
                            unk2 = reader.ReadUInt32();
                            unk3 = reader.ReadUInt32();
                            unk4 = reader.ReadUInt32();

                            unkF1 = reader.ReadSingle();
                            unkF2 = reader.ReadSingle();
                            unkF3 = reader.ReadSingle();

                            flags1 = reader.ReadUInt32();
                            flags2 = reader.ReadUInt32();

                            mysteryB1 = reader.ReadByte();
                            mysteryB2 = reader.ReadByte();
                            useAlpha = reader.ReadBoolean();
                            mysteryB4 = reader.ReadByte();
                            mysteryB5 = reader.ReadByte();
                            mysteryB6 = reader.ReadByte();
                            mysteryB7 = reader.ReadByte();
                            mysteryB8 = reader.ReadByte();
                            useDoubleSided = reader.ReadBoolean();
                            mysteryB10 = reader.ReadByte();
                            mysteryB11 = reader.ReadByte();
                            mysteryB12 = reader.ReadByte();
                            mysteryB13 = reader.ReadByte();
                            mysteryB14 = reader.ReadByte();
                            mysteryB15 = reader.ReadByte();
                            mysteryB16 = reader.ReadByte();
                            mysteryB17 = reader.ReadByte();
                            mysteryB18 = reader.ReadByte();
                            mysteryB19 = reader.ReadByte();
                            mysteryB20 = reader.ReadByte();
                            mysteryB21 = reader.ReadByte();
                            mysteryB22 = reader.ReadByte();
                            mysteryB23 = reader.ReadByte();

                            for (int i = 0; i < 9; ++i)
                            {
                                uint length = reader.ReadUInt32();
                                textures[i] = new string(reader.ReadChars((int)length));
                                textures[i] = textures[i].Remove(textures[i].Length - 1, 1);
                            }

                            unkB1 = reader.ReadByte();
                            unkB2 = reader.ReadByte();

                            unkF4 = reader.ReadSingle();
                            unkF5 = reader.ReadSingle();

                            unkB3 = reader.ReadByte();
                            unkF6 = reader.ReadSingle();

                            useWet = reader.ReadBoolean();

                            unkColor1.Red = reader.ReadSingle();
                            unkColor1.Green = reader.ReadSingle();
                            unkColor1.Blue = reader.ReadSingle();
                            specularStrength = reader.ReadSingle();

                            unkF7_5 = reader.ReadSingle();
                            unkF7_6 = reader.ReadSingle();
                            unkF7_7 = reader.ReadSingle();
                            unkF7_8 = reader.ReadSingle();
                            unkF7_9 = reader.ReadSingle();
                            unkF7_10 = reader.ReadSingle();
                            unkF7_11 = reader.ReadSingle();
                            unkF7_12 = reader.ReadSingle();

                            uint templateLength = reader.ReadUInt32();
                            template = new string(reader.ReadChars((int)templateLength));
                            template = template.Remove(template.Length - 1, 1);

                            unkB5 = reader.ReadByte();
                            unkB6 = reader.ReadByte();
                            unkF8 = reader.ReadSingle();

                            unkB7 = reader.ReadByte();
                            unkB8 = reader.ReadByte();
                            unkB9 = reader.ReadByte();
                            unkB10 = reader.ReadByte();
                            unkB11 = reader.ReadByte();
                            unkB12 = reader.ReadByte();
                            unkB13 = reader.ReadByte();
                            unkB14 = reader.ReadByte();
                            unkB15 = reader.ReadByte();
                            unkB16 = reader.ReadByte();
                            unkB17 = reader.ReadByte();
                            unkB18 = reader.ReadByte();

                            unkColor2.Red = reader.ReadSingle();
                            unkColor2.Green = reader.ReadSingle();
                            unkColor2.Blue = reader.ReadSingle();

                            unkB19 = reader.ReadByte();
                            unkB20 = reader.ReadByte();
                            useSkinColor = reader.ReadBoolean();
                            unkB21 = reader.ReadByte();

                            unkF12 = reader.ReadSingle();
                            unkF13 = reader.ReadSingle();
                            unkF14 = reader.ReadSingle();
                            unkF15 = reader.ReadSingle();
                            unkF16 = reader.ReadSingle();
                            unkF17 = reader.ReadSingle();

                            unkB22 = reader.ReadByte();
                            reader.Close();
                        }
                        else
                        {
                            return false;
                        }
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
                        writer.Write(header.ToCharArray(), 0, 4);

                        writer.Write(unk1);
                        writer.Write(unk2);
                        writer.Write(unk3);
                        writer.Write(unk4);

                        writer.Write(unkF1);
                        writer.Write(unkF2);
                        writer.Write(unkF3);

                        writer.Write(flags1);
                        writer.Write(flags2);

                        writer.Write(mysteryB1);
                        writer.Write(mysteryB2);
                        writer.Write(useAlpha);
                        writer.Write(mysteryB4);
                        writer.Write(mysteryB5);
                        writer.Write(mysteryB6);
                        writer.Write(mysteryB7);
                        writer.Write(mysteryB8);
                        writer.Write(useDoubleSided);
                        writer.Write(mysteryB10);
                        writer.Write(mysteryB11);
                        writer.Write(mysteryB12);
                        writer.Write(mysteryB13);
                        writer.Write(mysteryB14);
                        writer.Write(mysteryB15);
                        writer.Write(mysteryB16);
                        writer.Write(mysteryB17);
                        writer.Write(mysteryB18);
                        writer.Write(mysteryB19);
                        writer.Write(mysteryB20);
                        writer.Write(mysteryB21);
                        writer.Write(mysteryB22);
                        writer.Write(mysteryB23);

                        for (int i = 0; i < 9; ++i)
                        {
                            writer.Write(textures[i].Length + 1);
                            if (textures[i].Length > 0)
                            {
                                writer.Write(textures[i].ToCharArray());
                            }
                            writer.Write('\0');
                        }

                        writer.Write(unkB1);
                        writer.Write(unkB2);

                        writer.Write(unkF4);
                        writer.Write(unkF5);

                        writer.Write(unkB3);
                        writer.Write(unkF6);

                        writer.Write(useWet);

                        writer.Write(unkColor1.Red);
                        writer.Write(unkColor1.Green);
                        writer.Write(unkColor1.Blue);
                        writer.Write(specularStrength);

                        writer.Write(unkF7_5);
                        writer.Write(unkF7_6);
                        writer.Write(unkF7_7);
                        writer.Write(unkF7_8);
                        writer.Write(unkF7_9);
                        writer.Write(unkF7_10);
                        writer.Write(unkF7_11);
                        writer.Write(unkF7_12);

                        writer.Write(template.Length + 1);
                        if (template.Length > 0)
                        {
                            writer.Write(template.ToCharArray());
                        }
                        writer.Write('\0');

                        writer.Write(unkB5);
                        writer.Write(unkB6);
                        writer.Write(unkF8);

                        writer.Write(unkB7);
                        writer.Write(unkB8);
                        writer.Write(unkB9);
                        writer.Write(unkB10);
                        writer.Write(unkB11);
                        writer.Write(unkB12);
                        writer.Write(unkB13);
                        writer.Write(unkB14);
                        writer.Write(unkB15);
                        writer.Write(unkB16);
                        writer.Write(unkB17);
                        writer.Write(unkB18);

                        writer.Write(unkColor2.Red);
                        writer.Write(unkColor2.Green);
                        writer.Write(unkColor2.Blue);

                        writer.Write(unkB19);
                        writer.Write(unkB20);
                        writer.Write(useSkinColor);
                        writer.Write(unkB21);

                        writer.Write(unkF12);
                        writer.Write(unkF13);
                        writer.Write(unkF14);
                        writer.Write(unkF15);
                        writer.Write(unkF16);
                        writer.Write(unkF17);

                        writer.Write(unkB22);
                        writer.Close();
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
