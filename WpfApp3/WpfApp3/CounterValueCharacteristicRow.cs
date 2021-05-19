using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class CounterValueCharacteristicRow:CharacteristicInfoRow
    {
        private object selectedValue;

        public CounterValueCharacteristicRow()
        {
            RowDisplayName = "Counter Value";
        }

        public string RowDisplayName { get; set; }

        public override object SelectedValue
        {
            get => selectedValue;
            set
            {
                if (!ValidateSelectedValue(value))
                {
                    return;
                }

                

                if (value != null && Int32.TryParse(value.ToString(), out int newValue))
                {
                    selectedValue = newValue;
                    if (newValue == 10)
                    {
                        AddError("DontCare", "Really!");
                    }
                    else
                    {
                        RemoveError("DontCare", "Really!");
                    }
                }
                else
                {
                    selectedValue = value != null ? string.Empty : null;
                }
                    
                RaisePropertyChanged("SelectedValue");
            }
        }

        public override bool ValidateSelectedValue(object value)
        {
            if (string.IsNullOrEmpty(Convert.ToString(value)))
            {
                AddError("SelectedValue", "The value should be numeric");
                return true;
            }

            if (int.TryParse(Convert.ToString(value), out int newValue))
            {
                if (newValue >= 1)
                {
                    RemoveError("SelectedValue", "The value should be numeric");
                    return true;
                }
                else
                {
                    AddError("SelectedValue", "The value should be numeric");
                    return true;
                }
            }
            else
            {
                // This condition is for scenario when user enters in textbox value more than  upper limit of integer
                AddError("SelectedValue", "The value should be numeric");
                return false;
            }
        }
    }
}
