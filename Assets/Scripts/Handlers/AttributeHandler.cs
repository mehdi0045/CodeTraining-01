using System.Collections.Generic;
using Attribute.Base;
using AttributeBase.Interfaces;
using Handlers.Interfaces;
using UnityEngine;

namespace Handlers
{
    public class AttributeHandler : MonoBehaviour,IHandler
    {
        #region Events

        public delegate void OnIncreaseAttributeDelegate(IAttribute attribute);
        public event OnIncreaseAttributeDelegate OnIncreaseAttribute;
        
        public delegate void OnDecreaseAttributeDelegate(IAttribute attribute);
        public event OnDecreaseAttributeDelegate OnDecreaseAttribute;
        
        public delegate void OnScaleUpAttributeDelegate(IAttribute attribute);
        public event OnScaleUpAttributeDelegate OnScaleUpAttribute;
        
        public delegate void OnScaleDownAttributeDelegate(IAttribute attribute);
        public event OnScaleDownAttributeDelegate OnScaleDownAttribute;
        
        public delegate void OnAttributeChangedDelegate(IAttribute attribute);
        public event OnAttributeChangedDelegate OnSAttributeChanged;

        #endregion
        
        private List<BaseAttribute> _attributes;

        public void Setup(List<BaseAttribute> attribute)
        {
            _attributes = attribute;
        }
        public void Init(IController controller)
        {
        }
        private BaseAttribute Find(string name)
        {
            var attribute = _attributes.Find(i => i.Name == name);
            return attribute;
        }
        
        public void Increase(string name, float amount)
        {
            var attribute = Find(name);
            attribute.Increase(amount);
            OnOnIncreaseAttribute(attribute);
            OnOnAttributeChanged(attribute);
        }

        public void Decrease(string name ,float amount)
        {
            var attribute = Find(name);
            attribute.Decrease(amount);
            OnOnDecreaseAttribute(attribute);
            OnOnAttributeChanged(attribute);
        }

        public void ScaleUp(string name ,float amount)
        {
            var attribute = Find(name);
            attribute.ScaleUp(amount);
            OnOnScaleUpAttribute(attribute);
            OnOnAttributeChanged(attribute);
        }

        public void ScaleDown(string name ,float amount)
        {
            var attribute = Find(name);
            attribute.ScaleDown(amount);
            OnOnScaleDownAttribute(attribute);
            OnOnAttributeChanged(attribute);
        }

        #region OnEvents

        protected virtual void OnOnIncreaseAttribute(IAttribute attribute)
        {
            OnIncreaseAttribute?.Invoke(attribute);
        }
        
        protected virtual void OnOnDecreaseAttribute(IAttribute attribute)
        {
            OnDecreaseAttribute?.Invoke(attribute);
        }
        
        protected virtual void OnOnScaleUpAttribute(IAttribute attribute)
        {
            OnScaleUpAttribute?.Invoke(attribute);
        }
        
        protected virtual void OnOnScaleDownAttribute(IAttribute attribute)
        {
            OnScaleDownAttribute?.Invoke(attribute);
        }
        
        protected virtual void OnOnAttributeChanged(IAttribute attribute)
        {
            OnSAttributeChanged?.Invoke(attribute);
        }
        

        #endregion

        
    }
}
