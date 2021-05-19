using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private readonly List<Item> ecr;
        /// <summary>
        /// The collection of the Creation Info entries.
        /// </summary>
        public List<Item> ECR
        {
            get { return ecr; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
           ecr = new List<Item>();
           for (int i = 0; i < 2; i++)
           {
               ecr.Add(new Item());
           }
           ecr.ForEach(x => x.Validate());
            //CounterValueCharacteristicRow cv = new CounterValueCharacteristicRow();
            //elementCharacteristicInfoRows.Add(cv);
        }
    }

    public class Item : ViewModelBase
    {
        private readonly List<CharacteristicInfoRow> elementCharacteristicInfoRows;

        /// <summary>
        /// The collection of the Creation Info entries.
        /// </summary>
        public List<CharacteristicInfoRow> DC
        {
            get { return elementCharacteristicInfoRows; }
        }

        public Item()
        {
            elementCharacteristicInfoRows = new List<CharacteristicInfoRow>();
            //for (int i = 0; i < 2; i++)
            //{
            CounterValueCharacteristicRow cr = new CounterValueCharacteristicRow
                //{RowDisplayName = "Short Row Name", SelectedValue = 1};
            { RowDisplayName = "This is a Long Row Name", SelectedValue = 1};

            elementCharacteristicInfoRows.Add(cr);
            cr.PropertyChanged += Cr_PropertyChanged;

            CounterValueCharacteristicRow cr1 = new CounterValueCharacteristicRow
                {RowDisplayName = "Short Row Name", SelectedValue = 1};

            elementCharacteristicInfoRows.Add(cr1);
            cr1.PropertyChanged += Cr_PropertyChanged;
            //}
        }

        private void Cr_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Validate();
        }

        public void Validate()
        {
            if (DC.Any(x => x.SelectedValue.ToString() == "10"))
            {
                AddError("DC", "You cannot give a value 10");
            }
            else
            {
                RemoveError("DC", "You cannot give a value 10");
            }
        }
    }
}
