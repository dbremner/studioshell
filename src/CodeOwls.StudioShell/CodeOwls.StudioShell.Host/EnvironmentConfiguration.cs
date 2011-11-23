/*
   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.

   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.opensource.org/licenses/ms-rl

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/


using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeOwls.StudioShell.Host
{
    public static class EnvironmentConfiguration
    {
        static public void UpdateEnvironmentForHost()
        {
            var personalModulePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "WindowsPowershell\\Modules"
                );

            AddEnvironmentPath("psmodulepath", personalModulePath);

            UpdateEnvironmentForModule();
        }

        static public void UpdateEnvironmentForModule()
        {
            var rootPath = StudioShellInfo.InstallationPath;

            AddEnvironmentPath("psmodulepath", rootPath, "Module");
            AddEnvironmentPath("path", rootPath, "Scripts");
        }

        static private void AddEnvironmentPath(string environmentVariable, string rootPath, string subdir)
        {                       
            var newPath = Path.Combine(
                rootPath,
                subdir
                );
            AddEnvironmentPath(environmentVariable, newPath);
        }

        static private void AddEnvironmentPath(string environmentVariable, string path)
        {
            var pspaths = (Environment.GetEnvironmentVariable(environmentVariable) ?? "").Split(';').ToList();
            if (pspaths.Contains(path, StringComparer.InvariantCultureIgnoreCase))
            {
                return;
            }
            pspaths.Add(path);
            Environment.SetEnvironmentVariable(environmentVariable, String.Join(";", pspaths.ToArray()));
        }

    }
}
