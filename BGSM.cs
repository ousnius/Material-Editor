using System;
using System.IO;

namespace Material_Editor
{
    struct ColorRGB
    {
        public float Red;
        public float Green;
        public float Blue;
    }

    class BGSM
    {
        string header;
        uint unk1;
        uint unk2;
        uint unk3;
        uint unk4;

        float unkF1;
        float unkF2;
        float unkF3;

        uint flags1;
        uint flags2;

        byte mysteryB1;
        byte mysteryB2;
        bool useAlpha;
        byte mysteryB4;
        byte mysteryB5;
        byte mysteryB6;
        byte mysteryB7;
        byte mysteryB8;
        bool useDoubleSided;
        byte mysteryB10;
        byte mysteryB11;
        byte mysteryB12;
        byte mysteryB13;
        byte mysteryB14;
        byte mysteryB15;
        byte mysteryB16;
        byte mysteryB17;
        byte mysteryB18;
        byte mysteryB19;
        byte mysteryB20;
        byte mysteryB21;
        byte mysteryB22;
        byte mysteryB23;

        string[] textures = new string[9];

        byte unkB1;
        byte unkB2;

        float unkF4;
        float unkF5;

        byte unkB3;
        float unkF6;

        bool useWet;

        ColorRGB unkColor1;
        float specularStrength;

        float unkF7_5;
        float unkF7_6;
        float unkF7_7;
        float unkF7_8;
        float unkF7_9;
        float unkF7_10;
        float unkF7_11;
        float unkF7_12;

        string template;

        byte unkB5;
        byte unkB6;
        float unkF8;

        byte unkB7;
        byte unkB8;
        byte unkB9;
        byte unkB10;
        byte unkB11;
        byte unkB12;
        byte unkB13;
        byte unkB14;
        byte unkB15;
        byte unkB16;
        byte unkB17;
        byte unkB18;

        ColorRGB unkColor2;

        byte unkB19;
        byte unkB20;
        bool skinColor;
        byte unkB21;

        float unkF12;
        float unkF13;
        float unkF14;
        float unkF15;
        float unkF16;
        float unkF17;

        byte unkB22;

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

                            unkB5 = reader.ReadByte();
                            unkB6 = reader.ReadByte();
                            unkF8 = reader.ReadByte();

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
                            skinColor = reader.ReadBoolean();
                            unkB21 = reader.ReadByte();

                            unkF12 = reader.ReadSingle();
                            unkF13 = reader.ReadSingle();
                            unkF14 = reader.ReadSingle();
                            unkF15 = reader.ReadSingle();
                            unkF16 = reader.ReadSingle();
                            unkF17 = reader.ReadSingle();

                            unkB22 = reader.ReadByte();
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
                            int length = textures[i].Length;
                            writer.Write(length);
                            writer.Write(textures[i]);
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

                        int templateLength = template.Length;
                        writer.Write(templateLength);
                        writer.Write(template);

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
                        writer.Write(skinColor);
                        writer.Write(unkB21);

                        writer.Write(unkF12);
                        writer.Write(unkF13);
                        writer.Write(unkF14);
                        writer.Write(unkF15);
                        writer.Write(unkF16);
                        writer.Write(unkF17);

                        writer.Write(unkB22);
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
