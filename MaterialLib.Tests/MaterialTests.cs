using System.Diagnostics;
using System.Runtime.Serialization.Json;

namespace MaterialLib.Tests
{
    public class MaterialTests
    {
        private static void Deserialize(string filePath, BaseMaterialFile materialFile)
        {
            using var reader = new BinaryReader(File.OpenRead(filePath));
            materialFile.Deserialize(reader);

            // Must read until the end
            Assert.Equal(reader.BaseStream.Length, reader.BaseStream.Position);
        }

        private static BGSM DeserializeBGSM(string filePath)
        {
            var bgsm = new BGSM();
            Deserialize(filePath, bgsm);
            return bgsm;
        }

        private static BGEM DeserializeBGEM(string filePath)
        {
            var bgem = new BGEM();
            Deserialize(filePath, bgem);
            return bgem;
        }

        [Fact]
        public void Deserialize_V2_BGSM_Default()
        {
            const string filePath = @"Files/Version 2/Default.bgsm";

            var bgsm = DeserializeBGSM(filePath);
            Assert.Equal<uint>(2, bgsm.Version);
            Assert.Equal("Shared/FlatGray01_d.dds", bgsm.DiffuseTexture);
            Assert.Equal("Shared/FlatFlat_n.dds", bgsm.NormalTexture);
        }

        [Fact]
        public void Deserialize_V2_BGEM_Default()
        {
            const string filePath = @"Files/Version 2/DefaultEffect.bgem";

            var bgem = DeserializeBGEM(filePath);
            Assert.Equal<uint>(2, bgem.Version);
            Assert.Equal("Shared/FlatGray01_d.dds", bgem.BaseTexture);
        }

        [Fact]
        public void Deserialize_V21_BGSM_Default()
        {
            const string filePath = @"Files/Version 21/Default.bgsm";

            var bgsm = DeserializeBGSM(filePath);
            Assert.Equal<uint>(21, bgsm.Version);
            Assert.Equal("Shared/FlatGray01_d.dds", bgsm.DiffuseTexture);
            Assert.Equal("Shared/FlatFlat_n.dds", bgsm.NormalTexture);
        }

        [Fact]
        public void Deserialize_V21_BGEM_Default()
        {
            const string filePath = @"Files/Version 21/DefaultEffect.bgem";

            var bgem = DeserializeBGEM(filePath);
            Assert.Equal<uint>(21, bgem.Version);
            Assert.Equal("Shared/FlatGray01_d.dds", bgem.BaseTexture);
        }

        [Fact(Skip = "Optional")]
        public void DeserializeFiles()
        {
            const string path = @"<enter directory>";

            var directory = new DirectoryInfo(path);
            var masks = new[] { "*.bgsm", "*.bgem" };
            var files = masks.SelectMany(m => directory.EnumerateFiles(m, SearchOption.AllDirectories));

            var versions = new HashSet<uint>();

            foreach (var file in files)
            {
                Debug.WriteLine($"Loading '{file.FullName}'...");

                bool isBGEM = file.Extension.Equals(".bgem", StringComparison.InvariantCultureIgnoreCase);
                BaseMaterialFile? materialFile = isBGEM ? new BGEM() : new BGSM();

                using var reader = new BinaryReader(file.OpenRead());

                char start = Convert.ToChar(reader.ReadByte());
                reader.BaseStream.Position = 0;

                // Check for JSON
                if (start == '{' || start == '[')
                {
                    var ser = new DataContractJsonSerializer(materialFile.GetType());
                    var serObj = ser.ReadObject(reader.BaseStream);
                    materialFile = isBGEM ? (BGEM?)serObj : (BGSM?)serObj;
                }
                else
                {
                    materialFile.Deserialize(reader);

                    if (!versions.Contains(materialFile.Version))
                        Debug.WriteLine($"New version number found: " + materialFile.Version);

                    versions.Add(materialFile.Version);
                }

                // Must read until the end
                Assert.Equal(reader.BaseStream.Length, reader.BaseStream.Position);
            }
        }
    }
}