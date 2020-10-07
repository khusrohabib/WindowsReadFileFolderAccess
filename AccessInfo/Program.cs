using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AccessInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Folder Path:");
            string folderPath = Console.ReadLine();
            Console.WriteLine("Type,Name,Path,User,Rights,Authorization");
            accessRights(folderPath);

        }


        public static void accessRights(string folderPath)
        {
            try
            {

                System.Collections.Generic.List<string> dirs = new List<string>(Directory.EnumerateDirectories(folderPath));

                foreach (var dir in dirs)
                {

                    getDirAccessControl(dir);
                    accessRights(dir); //recursive function for drill down into directory
                }
                
                var files = Directory.EnumerateFiles(folderPath, "*.*");
                foreach (string currentFile in files)
                {
                    string fileName = currentFile.Substring(folderPath.Length + 1);
                    //Console.WriteLine("--------------------------- File {0} --------------------------------", fileName);
                    getFileAccessControl(currentFile, fileName);
                }
                
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void getDirAccessControl(string path)
        {
            try
            {
                // Create a new DirectoryInfo object.
                var dirName = $"{path.Substring(path.LastIndexOf(Path.DirectorySeparatorChar) + 1)}";
                
                //Console.WriteLine("########################### Directory - {0} ##################################", dirName);
                DirectoryInfo dInfo = new DirectoryInfo(path);
                //Console.WriteLine("Path {0}", path);
                // Get a DirectorySecurity object that represents the
                // current security settings.
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                AuthorizationRuleCollection acl = dSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                foreach (FileSystemAccessRule ace in acl)
                {
                    var user = ace.IdentityReference.Value;
                    var rights = ace.FileSystemRights;
                    var allowOrDeny = ace.AccessControlType;

                    Console.WriteLine("Directory, {0}, {1}, {2}, {3}, {4}", dirName, path, user, rights, allowOrDeny);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void getFileAccessControl(string path, string fileName)
        {
            try { 

            // Create a new DirectoryInfo object.
            FileSecurity security = File.GetAccessControl(path);

            // Get a DirectorySecurity object that represents the
            // current security settings.
           //Console.WriteLine("Path {0}", path);

            AuthorizationRuleCollection acl = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
            foreach (FileSystemAccessRule ace in acl)
            {
                var user = ace.IdentityReference.Value;
                var rights = ace.FileSystemRights;
                var allowOrDeny = ace.AccessControlType;
                Console.WriteLine("File,{0}, {1}, {2}, {3},{4}",fileName,path, user, rights.ToString(), allowOrDeny.ToString());
            }
        }
                        catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
