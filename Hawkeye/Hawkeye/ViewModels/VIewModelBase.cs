using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hawkeye.ViewModels
{
    public abstract class VIewModelBase : INotifyPropertyChanged, IDisposable
    {
        public virtual string DisplayName { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>( ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(value, storage))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
