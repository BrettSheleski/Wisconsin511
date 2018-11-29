using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewModelAttribute : Attribute
    {
        static readonly Type ViewModelBaseType = typeof(ViewModel);

        public ViewModelAttribute(Type vmType)
        {
            if (!ViewModelType.IsAssignableFrom(vmType))
                throw new ArgumentException("vmType must inherit from ViewModelBase");

            this.ViewModelType = vmType;
        }

        public Type ViewModelType { get; }
    }
}