using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ToolOffset_Application.Core;

namespace ToolOffset_Application.Wrappers.Base
{
    public class ModelWrapper<T> : BaseNotification, IRevertibleChangeTracking
    {
        private Dictionary<string, object> _orignalValues;

        private List<IRevertibleChangeTracking> _trakingObjects;

        public ModelWrapper(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            Model = model;
            _orignalValues = new Dictionary<string, object>();
            _trakingObjects = new List<IRevertibleChangeTracking>();
        }

        public T Model { get; private set; }

        public bool IsChanged { get { return _orignalValues.Count > 0 || _trakingObjects.Any(t => t.IsChanged); } }

        public void AcceptChanges()
        {
            _orignalValues.Clear();
            foreach (var trackingObject in _trakingObjects)
            {
                trackingObject.AcceptChanges();
            }
            OnPropertyChanged("");
        }

        public void RejectChanges()
        {
            foreach (var originalValueEntry in _orignalValues)
            {
                typeof(T).GetProperty(originalValueEntry.Key).SetValue(Model, originalValueEntry.Value, null);
            }
            _orignalValues.Clear();
            foreach (var trackingObject in _trakingObjects)
            {
                trackingObject.RejectChanges();
            }
            OnPropertyChanged("");
        }

        protected TValue GetValue<TValue>(string propertyName)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            return (TValue)propertyInfo.GetValue(Model, null);
        }

        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            return _orignalValues.ContainsKey(propertyName)
                ? (TValue)_orignalValues[propertyName]
                : GetValue<TValue>(propertyName);
        }

        protected bool GetIsChanged(string propertyName)
        {
            return _orignalValues.ContainsKey(propertyName);
        }

        protected void SetValue<TValue>(TValue newValue, string propertyName)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model, null);
            if (!Equals(currentValue, newValue))
            {
                UpdateOriginalValue(currentValue, newValue, propertyName);
                propertyInfo.SetValue(Model, newValue, null);
                OnPropertyChanged(propertyName);
                OnPropertyChanged(propertyName + "IsChanged");
            }
        }

        private void UpdateOriginalValue(object currentValue, object newValue, string propertyName)
        {
            if (!_orignalValues.ContainsKey(propertyName))
            {
                _orignalValues.Add(propertyName, currentValue);
                OnPropertyChanged("IsChanged");
            }
            else
            {
                if (Equals(_orignalValues[propertyName], newValue))
                {
                    _orignalValues.Remove(propertyName);
                    OnPropertyChanged("IsChanged");
                }
            }
        }

        protected void RegisterCollection<TWrapper, TModel>(
            ChangeTrackingCollection<TWrapper> wrapperCollection,
            List<TModel> modelCollection) where TWrapper : ModelWrapper<TModel>
        {
            wrapperCollection.CollectionChanged += (s, e) =>
            {
                modelCollection.Clear();
                modelCollection.AddRange(wrapperCollection.Select(w => w.Model));
            };
            RegisterTrackingObject(wrapperCollection);
        }

        protected void RegisterComplex<TModel>(ModelWrapper<TModel> wrapper)
        {
            RegisterTrackingObject(wrapper);
        }

        private void RegisterTrackingObject<TTrackingObject>(TTrackingObject trackingObject)
            where TTrackingObject : IRevertibleChangeTracking, INotifyPropertyChanged
        {
            if (!_trakingObjects.Contains(trackingObject))
            {
                _trakingObjects.Add(trackingObject);
                trackingObject.PropertyChanged += TrackingObjectPropertyChanged;
            }
        }

        private void TrackingObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsChanged))
            {
                OnPropertyChanged(nameof(IsChanged));
            }
        }
    }
}
