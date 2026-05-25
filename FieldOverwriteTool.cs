using MaterialLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Material_Editor
{
    public enum FieldCopyStatus
    {
        Success,
        Skipped,
        Failed
    }

    public sealed class FieldCopyResult
    {
        public string TargetPath { get; }
        public FieldCopyStatus Status { get; }
        public string Message { get; }

        public FieldCopyResult(string targetPath, FieldCopyStatus status, string message)
        {
            TargetPath = targetPath;
            Status = status;
            Message = message;
        }
    }

    public sealed class FieldOverwriteTool
    {
        public IReadOnlyList<FieldCopyResult> Run(BaseMaterialFile sourceState, IReadOnlyList<MaterialFieldDescriptor> descriptors, IReadOnlyList<string> targetFiles, bool backupBeforeWrite)
        {
            var results = new List<FieldCopyResult>();

            foreach (var target in targetFiles)
            {
                var result = ProcessTarget(sourceState, descriptors, target, backupBeforeWrite);
                results.Add(result);
            }

            return results;
        }

        private FieldCopyResult ProcessTarget(BaseMaterialFile sourceState, IReadOnlyList<MaterialFieldDescriptor> descriptors, string filePath, bool backupBeforeWrite)
        {
            if (!File.Exists(filePath))
                return new FieldCopyResult(filePath, FieldCopyStatus.Failed, "Target file does not exist.");

            if (!TryLoadMaterial(filePath, out var targetMaterial, out var isJson, out var loadError))
                return new FieldCopyResult(filePath, FieldCopyStatus.Failed, loadError ?? "Failed to load material.");

            if (targetMaterial.GetType() != sourceState.GetType())
                return new FieldCopyResult(filePath, FieldCopyStatus.Skipped, "Skipped incompatible material type.");

            var supportedDescriptors = descriptors.Where(d => d.IsSupported(targetMaterial)).ToList();
            if (supportedDescriptors.Count == 0)
                return new FieldCopyResult(filePath, FieldCopyStatus.Skipped, "No compatible fields for target version.");

            foreach (var descriptor in supportedDescriptors)
            {
                descriptor.SetValue(targetMaterial, descriptor.GetValue(sourceState));
            }

            try
            {
                if (backupBeforeWrite)
                {
                    File.Copy(filePath, $"{filePath}.bak", true);
                }

                SaveMaterial(filePath, targetMaterial, isJson);
            }
            catch (Exception ex)
            {
                return new FieldCopyResult(filePath, FieldCopyStatus.Failed, ex.Message);
            }

            return new FieldCopyResult(filePath, FieldCopyStatus.Success, "Updated successfully.");
        }

        private static bool TryLoadMaterial(string filePath, out BaseMaterialFile material, out bool isJson, out string errorMessage)
        {
            material = null;
            isJson = false;
            errorMessage = null;

            try
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                int start = stream.ReadByte();
                if (start == -1)
                {
                    errorMessage = "Target file is empty.";
                    return false;
                }

                stream.Position = 0;

                BaseMaterialFile candidate = Path.GetExtension(filePath).Equals(".bgem", StringComparison.OrdinalIgnoreCase)
                    ? new BGEM()
                    : new BGSM();

                if (start == '{' || start == '[')
                {
                    isJson = true;
                    var serializer = new DataContractJsonSerializer(candidate.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
                    material = (BaseMaterialFile)serializer.ReadObject(stream);
                }
                else
                {
                    stream.Position = 0;
                    if (!candidate.Open(stream))
                    {
                        errorMessage = "Failed to read binary material.";
                        return false;
                    }

                    material = candidate;
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private static void SaveMaterial(string filePath, BaseMaterialFile material, bool asJson)
        {
            using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            if (asJson)
            {
                using var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, true, true, "  ");
                var serializer = new DataContractJsonSerializer(material.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
                serializer.WriteObject(writer, material);
                writer.Flush();
            }
            else
            {
                if (!material.Save(stream))
                    throw new IOException("Failed to write binary material.");
            }
        }
    }
}
