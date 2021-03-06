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


using System.Collections.Generic;
using System.Linq;
using CodeOwls.StudioShell.Paths.Items.PropertyModel;
using EnvDTE;

namespace CodeOwls.StudioShell.Paths.Items.ProjectModel
{
    public class ShellProject
    {
        private readonly Project _project;

        internal ShellProject(Project project)
        {
            _project = project;
        }

        public string Name
        {
            get { return _project.Name; }
            set { _project.Name = value; }
        }

        public string FileName
        {
            get { return _project.FileName; }
        }

        public bool IsDirty
        {
            get { return _project.IsDirty; }
            set { _project.IsDirty = value; }
        }

        public string Kind
        {
            get { return _project.Kind; }
        }

        public IEnumerable<ShellProjectItem> ProjectItems
        {
            get
            {
                return from ProjectItem item in _project.ProjectItems
                       select new ShellProjectItem(item);
            }
        }

        public IEnumerable<ShellProperty> Properties
        {
            get
            {
                return from Property prop in _project.Properties
                       select new ShellProperty(prop);
            }
        }

        public string UniqueName
        {
            get { return _project.UniqueName; }
        }

        public object Object
        {
            get { return _project.Object; }
        }

        public string FullName
        {
            get { return _project.FullName; }
        }

        public bool Saved
        {
            get { return _project.Saved; }
            set { _project.Saved = value; }
        }

        public ConfigurationManager ConfigurationManager
        {
            get { return _project.ConfigurationManager; }
        }

        public Globals Globals
        {
            get { return _project.Globals; }
        }

        public void SaveAs(string NewFileName)
        {
            _project.SaveAs(NewFileName);
        }

        public void Save(string FileName)
        {
            _project.Save(FileName);
        }

        public void Delete()
        {
            _project.Delete();
        }

        internal Project AsProject()
        {
            return _project;
        }
    }
}