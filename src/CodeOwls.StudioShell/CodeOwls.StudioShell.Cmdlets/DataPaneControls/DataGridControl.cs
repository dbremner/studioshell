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


using System.Windows.Forms;

namespace CodeOwls.StudioShell.DataPaneControls
{
    public partial class DataGridControl : UserControl
    {
        public DataGridControl()
        {
            InitializeComponent();
            
        }

        public void SetDataSource( object reader )
        {
            
            bindingSource1.DataSource = reader;
            bindingSource1.CurrencyManager.Refresh();
            
            dataGridView1.AutoGenerateColumns = true;            
            dataGridView1.AllowUserToResizeColumns = true;
            
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
