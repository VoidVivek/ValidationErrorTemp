using System.Collections.Generic;
using System.Dynamic;

namespace WpfApp3
{
    class CounterTypeCharacteristicRow: CharacteristicInfoRow
    {
        private object selectedValue;
        private bool showValueField;

        public override object SelectedValue
        {
            get
            {
                return selectedValue;
            }
            set
            {
                if (ValidateSelectedValue(value))
                {
                    selectedValue = value;
                    RaisePropertyChanged("SelectedValue");
                }
            }
        }
        
        /// <summary>
        /// The available values for this row.
        /// </summary>
        public List<string> Values { get; set; }

        public override bool ValidateSelectedValue(object value)
        {
            return true;
        }

        public bool ShowValueField
        {
            set
            {
                showValueField = SelectedValue.ToString().Equals(Values[2]);
                RaisePropertyChanged("ShowValueField");
            }
            get
            {
                return showValueField;
            }
        }

        public string CounterTypeRowDisplayName { get; set; }

        public string CounterValueRowDisplayName { get; set; }

        public CounterTypeCharacteristicRow()
        {
            Values = new List<string>{"First", "Next", "Override"};
            CounterTypeRowDisplayName = "Counter Type";
            CounterValueRowDisplayName = "Counter Value";
            SelectedValue = Values[2];
        }
        
    }
}