using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApp3
{
     public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> errorCollection;

        /// <summary>
        /// INotifyPropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// INotifyDataErrorInfo event
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        protected ViewModelBase()
        {
            errorCollection = new Dictionary<string, List<string>>();
        }
        
        /// <summary>
        /// Gets the errors for a property 
        /// </summary>
        public IEnumerable GetErrors(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName) && errorCollection.ContainsKey(propertyName))
            {
                return errorCollection[propertyName];
            }

            return null;
        }

        /// <summary>
        /// Checks if there are errors
        /// </summary>
        public bool HasErrors
        {
            get { return errorCollection.Count > 0; }
        }

        /// <summary>
        /// Add an error message for the specified property
        /// </summary>
        protected void AddError(string propertyName, string errorMessage)
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            if (!errorCollection.ContainsKey(propertyName))
            {
                errorCollection[propertyName] = new List<string>();
            }

            if (errorCollection[propertyName].Contains(errorMessage)) return;

            errorCollection[propertyName].Add(errorMessage);
            RaiseErrorChanged(propertyName);
        }

        /// <summary>
        /// Remove an error for the specified property
        /// </summary>
        protected void RemoveError(string propertyName, string errorMessage)
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            if (!errorCollection.ContainsKey(propertyName) || !errorCollection[propertyName].Contains(errorMessage)) return;

            errorCollection[propertyName].Remove(errorMessage);
            if (errorCollection[propertyName].Count == 0)
            {
                errorCollection.Remove(propertyName);
            }
            RaiseErrorChanged(propertyName);
        }

        /// <summary>
        /// Notify when a property changes value
        /// </summary>
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Notify about the errors
        /// </summary>
        protected void RaiseErrorChanged(string propertyName)
        {
            EventHandler<DataErrorsChangedEventArgs> handler = ErrorsChanged;
            if (handler != null)
            {
                handler(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
    }
}