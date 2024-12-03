using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeControlWinForms.Filter
{
    internal static class FilterClass
    {
        static DataGridView dataGridView;
        static FlowLayoutPanel filterLayoutPanel;
        internal static Dictionary<String, int> KeyComboBox_ValueDataGridColumnDictionary = new Dictionary<String, int>();
        internal static Dictionary<String, int> KeyDateTimePicker_ValueDataGridColumnDictionary = new Dictionary<string, int>();
    }
}
