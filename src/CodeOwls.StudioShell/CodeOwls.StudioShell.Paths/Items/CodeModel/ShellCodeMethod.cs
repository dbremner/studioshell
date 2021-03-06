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
using EnvDTE;
using EnvDTE80;

namespace CodeOwls.StudioShell.Paths.Items.CodeModel
{
    public class ShellCodeMethod : ShellCodeModelElement2
    {
        private readonly CodeFunction2 _method;

        internal ShellCodeMethod(CodeFunction2 method) : base(method as CodeElement2)
        {
            _method = method;
        }

        public object Parent
        {
            get { return _method.Parent; }
        }

        public vsCMFunction FunctionKind
        {
            get { return _method.FunctionKind; }
        }

        public ShellCodeTypeReference Type
        {
            get { return new ShellCodeTypeReference(_method.Type as CodeTypeRef2); }
            set { _method.Type = value.AsCodeTypeRef(); }
        }

        public IEnumerable<IShellCodeModelElement2> Parameters
        {
            get { return GetEnumerator(_method.Parameters); }
        }

        public vsCMAccess Access
        {
            get { return _method.Access; }
            set { _method.Access = value; }
        }

        public bool IsOverloaded
        {
            get { return _method.IsOverloaded; }
        }

        public bool IsShared
        {
            get { return _method.IsShared; }
            set { _method.IsShared = value; }
        }

        public bool MustImplement
        {
            get { return _method.MustImplement; }
            set { _method.MustImplement = value; }
        }

        public IEnumerable<IShellCodeModelElement2> Overloads
        {
            get { return GetEnumerator(_method.Overloads); }
        }

        public IEnumerable<IShellCodeModelElement2> Attributes
        {
            get { return GetEnumerator(_method.Attributes); }
        }

        public string DocComment
        {
            get { return _method.DocComment; }
            set { _method.DocComment = value; }
        }

        public string Comment
        {
            get { return _method.Comment; }
            set { _method.Comment = value; }
        }

        public bool CanOverride
        {
            get { return _method.CanOverride; }
            set { _method.CanOverride = value; }
        }

        public vsCMOverrideKind OverrideKind
        {
            get { return _method.OverrideKind; }
            set { _method.OverrideKind = value; }
        }

        public bool IsGeneric
        {
            get { return _method.IsGeneric; }
        }

        public ShellCodeParameter AddParameter(string Name, object Type, object Position)
        {
            return new ShellCodeParameter(_method.AddParameter(Name, Type, Position) as CodeParameter2);
        }

        public ShellCodeAttribute AddAttribute(string Name, string Value, object Position)
        {
            return new ShellCodeAttribute(_method.AddAttribute(Name, Value, Position) as CodeAttribute2);
        }

        public void RemoveParameter(object Element)
        {
            _method.RemoveParameter(Element);
        }

        public string get_Prototype(int Flags)
        {
            return _method.get_Prototype(Flags);
        }

        internal CodeFunction AsCodeFunction()
        {
            return _method;
        }
    }
}