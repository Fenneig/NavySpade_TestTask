using System;
using NavySpade.Utils;
using UnityEngine;

namespace NavySpade.Model.Properties
{
    [Serializable]
    public class ObservableProperty<TPropertyType>
    {
        [SerializeField] protected TPropertyType _value;

        public delegate void OnPropertyChanged(TPropertyType newValue);

        public event OnPropertyChanged OnChanged;

        public IDisposable Subscribe(OnPropertyChanged call)
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call);
        }

        public virtual TPropertyType Value
        {
            get => _value;
            set
            {
                var isSame = _value?.Equals(value) ?? false;
                if (isSame) return;
                _value = value;
                InvokeChangedEvent(_value);
            }
        }

        protected void InvokeChangedEvent(TPropertyType newValue)
        {
            OnChanged?.Invoke(newValue);
        }
    }
}