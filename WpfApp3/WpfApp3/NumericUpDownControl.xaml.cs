using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
     /// <summary>
    /// Interaction logic for NumericUpDownControl.xaml
    /// </summary>
    public partial class NumericUpDownControl
    {
        private BaseCommand increaseCommand;
        private BaseCommand decreaseCommand;

        /// <summary>
        /// Register a dependency property for the value of this control.
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(NumericUpDownControl), new PropertyMetadata("1"));

        /// <summary>
        /// The value of this control.
        /// </summary>
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public NumericUpDownControl()
        {
            InitializeComponent();
            Root.DataContext = this;
            InitialiseCommands();

            
        }

        private void InitialiseCommands()
        {
            increaseCommand = new BaseCommand(this.OnIncrease, o => true);
            decreaseCommand = new BaseCommand(this.OnDecrease, o => true);
        }

        private void OnIncrease(object parameters)
        {
            int value = Convert.ToInt32(Value);
            value++;
            this.Value = value.ToString();
        }

        private void OnDecrease(object parameters)
        {
            int value = Convert.ToInt32(Value);
            if (value < 1)
            {
                return;
            }
            else
            { 
                value--;
                this.Value = value.ToString();
            };
        }

        /// <summary>
        /// Event to handle the text inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // this is to allow only numbers  in the textbox. Text[0] picks first char of the string and is equivalent to KeyChar in winforms.
            e.Handled = !char.IsDigit(e.Text[0]) && !char.IsControl(e.Text[0]);
        }
    }
}
