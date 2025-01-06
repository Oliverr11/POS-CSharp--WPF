using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace iPOS
{
    public class FileManager
    {
        private string path = @".\data";
        private string extension = ".json";
        public void Wirte(string fileName, object data)
        {
            if (!IsPathExist())
            {
                CreateFolder();
            }
            string fullPath = GetFullPath(fileName);
            string jsonContent = JsonConvert.SerializeObject(data);
            StreamWriter streamWriter = new StreamWriter(fullPath);
            streamWriter.Write(jsonContent);
            streamWriter.Close();
        }
        public T Read<T>(string fileName)
        {
            string fullPath = GetFullPath(fileName);
            if (!File.Exists(fullPath))
            {
                return default(T);
            }
            string jsonContent = File.ReadAllText(fullPath);
            
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
        private void CreateFolder()
        {
            Directory.CreateDirectory(path);

        }
        private bool IsPathExist()
        {
            return File.Exists(path);
        }
        public string GetFullPath(string fileName)
        {
            return string.Format(@"{0}\{1}{2}", path, fileName, extension);
        }
    }
}
