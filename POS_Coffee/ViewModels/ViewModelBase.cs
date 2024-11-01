#nullable disable
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void OnPropertyChanged(string propertyName, object value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(
            ref T originalValue,
            T newValue,
            [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(originalValue, newValue))
            {
                originalValue = newValue;
                OnPropertyChanged(propertyName, newValue);

                return true;
            }

            return false;
        }



        readonly Dictionary<string, List<ValidationResult>> _errors = new();
        public bool HasErrors
        {
            get
            {
                return _errors.Any();
            }
        }
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string propertyName)
        {
            return _errors[propertyName];
        }


        private void AddErrors(string propertyName, IEnumerable<ValidationResult> results)
        {
            if (!_errors.TryGetValue(propertyName, out List<ValidationResult> errors))
            {
                errors = new List<ValidationResult>();
                _errors.Add(propertyName, errors);
            }

            errors.AddRange(results);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(string propertyName)
        {
            if (_errors.TryGetValue(propertyName, out List<ValidationResult> errors))
            {
                errors.Clear();
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }


    }
}
