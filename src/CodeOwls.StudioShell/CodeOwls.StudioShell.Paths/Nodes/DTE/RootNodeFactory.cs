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
using System.Collections.Generic;
using System.IO;
using CodeOwls.PowerShell.Provider.PathNodeProcessors;
using CodeOwls.PowerShell.Provider.PathNodes;
using CodeOwls.StudioShell.Paths.Items;
using CodeOwls.StudioShell.Paths.Nodes.CommandBars;
using CodeOwls.StudioShell.Paths.Nodes.Commands;
using CodeOwls.StudioShell.Paths.Nodes.Debugger;
using CodeOwls.StudioShell.Paths.Nodes.ProjectModel;
using CodeOwls.StudioShell.Paths.Nodes.PropertyModel;
using CodeOwls.StudioShell.Paths.Nodes.UI;
using EnvDTE80;
using Microsoft.Win32;


namespace CodeOwls.StudioShell.Paths.Nodes.DTE
{
    public class RootNodeFactory : NodeFactoryBase
    {
        private readonly DTE2 _dte;
        private readonly ShellDTE _shellObject;

        public RootNodeFactory(DTE2 dte)
        {
            _dte = dte;
            _shellObject = new ShellDTE(_dte);
        }

        public override string Name
        {
            get { return "Visual Studio Design-Time Environment"; }
        }

        public override IPathNode GetNodeValue()
        {
            return new PathNode(_shellObject, Name, true);
        }

        public override IEnumerable<INodeFactory>  GetNodeChildren( IContext context )
        {
            var regroot = _dte.RegistryRoot;
            var devenvroot = Path.GetDirectoryName(_dte.FullName);

            var settingsKeyPath = Path.Combine(regroot, @"AutomationProperties");

            DirectoryInfo projectItemTemplateRoot = new DirectoryInfo(
                Path.Combine(devenvroot, "ItemTemplates")
                );
            DirectoryInfo projectTemplateRoot = new DirectoryInfo(
                Path.Combine(devenvroot, "ProjectTemplates")
                );


            var root = new List<INodeFactory>
                       {
                           new DocumentsCollectionNodeFactory(_dte),
                           new DebuggerNodeFactory(_dte),
                           new WindowCollectionNodeFactory(_dte.Windows as Windows2),
                           new WindowConfigurationCollectionNodeFactory(_dte.WindowConfigurations),
                           new PropertyCategoriesNodeFactory(_dte, settingsKeyPath),
                           new CommandCollectionPathNodeFactory(_dte.Commands as Commands2),
                           new CommandBarCollectionNodeFactory(_dte.CommandBars as Microsoft.VisualStudio.CommandBars.CommandBars),
                           new OutputPaneCollectionNodeFactory(_dte.ToolWindows.OutputWindow.OutputWindowPanes),
                           new TaskItemCollectionNodeFactory(_dte.ToolWindows.TaskList.TaskItems),
                           new ErrorListNodeFactory(_dte.ToolWindows.ErrorList.ErrorItems, _dte),
                           new SelectedItemsNodeFactory(_dte),
                           new TemplateCollectionNodeFactory(projectItemTemplateRoot, projectTemplateRoot),
                           new AddInNodeCollectionFactory(_dte.AddIns),
                           new SolutionNodeFactory(_dte),
                       };
            root.Sort((a, b) => StringComparer.InvariantCultureIgnoreCase.Compare(a.Name, b.Name));
            return root;
        }
    }
}