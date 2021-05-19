using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp3
{
    public abstract class CharacteristicInfoRow : RowBase
    {
        private readonly List<string> associatedAttributes;
        
        /// <summary>
        /// Tooltip
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// Attribue IDs that are associated (linked) with the current row
        /// Populated during the linking process of the rows
        /// </summary>
        public List<string> AssociatedAttributeIds
        {
            get { return associatedAttributes; }
        }
        
        /// <summary>
        /// PropertyChanged handler
        /// Where two rows represent the same attribute or linked attributes, ensure their values update together
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedValue" && sender != this && sender.GetType() == GetType())
            {
                CharacteristicInfoRow row = sender as CharacteristicInfoRow;
                if (row != null && SelectedValue != row.SelectedValue)
                {
                    SelectedValue = row.SelectedValue;
                }
            }
        }
    }
}