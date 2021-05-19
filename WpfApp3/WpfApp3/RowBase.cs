using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public abstract class RowBase : ViewModelBase
    {
        /// <summary>
        /// The display name of the attribute that this row corresponds to.
        /// </summary>
        public string RowDisplayName { get; set; }

        /// <summary>
        /// The key that is associated with this row.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The selected value of the row.
        /// </summary>
        public abstract object SelectedValue { get; set; }

        /// <summary>
        /// Validate the selected value.
        /// </summary>
        public abstract bool ValidateSelectedValue(object value);

        /// <summary>
        /// Whether the row value can be modified
        /// </summary>
        public virtual bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Whether the row value is a duplicate
        /// </summary>
        public virtual bool IsLinked { get; set;}

    }
}
