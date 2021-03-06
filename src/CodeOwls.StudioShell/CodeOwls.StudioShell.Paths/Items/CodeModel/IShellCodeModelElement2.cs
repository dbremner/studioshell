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


using CodeOwls.StudioShell.Paths.Items.ProjectModel;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.CodeModel
{
    public interface IShellCodeModelElement2
    {
        string Name { get; set; }
        string FullName { get; }

        ShellProjectItem ProjectItem { get; }
        vsCMElement Kind { get; }
        bool IsCodeType { get; }
        vsCMInfoLocation InfoLocation { get; }

        string Language { get; }
        TextPoint StartPoint { get; }
        TextPoint EndPoint { get; }

        bool IsContainer { get; }
        TextPoint GetStartPoint(vsCMPart Part);
        TextPoint GetEndPoint(vsCMPart Part);
        void RenameSymbol(string NewName);
    }
}