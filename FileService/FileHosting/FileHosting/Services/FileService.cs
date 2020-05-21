using FileHosting.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FileHosting.Services
{

    [ServiceBehavior(
        MaxItemsInObjectGraph = 10000,
        IncludeExceptionDetailInFaults = true
        )]
    internal class FileService : IFileService
    {
        public DirectoryInfo[] GetDirectories(string Path) => new DirectoryInfo(Path).GetDirectories();

        public DriveInfo[] GetDrives() => DriveInfo.GetDrives();

        public FileInfo[] GetFiles(string Path) => new DirectoryInfo(Path).GetFiles();

        public DateTime GetServiceTime() => DateTime.Now;

        public int StartProcess(string Path, string Args)
        {
            Process process = Process.Start(Path, Args);

            return process?.Id ?? -1;
        }
    }
}
