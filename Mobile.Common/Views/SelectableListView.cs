using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.Common.Views
{
    public class SelectableListView : ListView
    {
        public SelectableListView() : base()
        {
            this.ItemSelected += HandleItemSelected;
        }


        public SelectableListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            this.ItemSelected += HandleItemSelected;
        }


        public static readonly BindableProperty SelectItemCommandProperty = BindableProperty.Create(nameof(SelectItemCommand), typeof(ICommand), typeof(SelectableListView), null, BindingMode.OneWay, propertyChanged: SelectItemCommandPropertyChanged);

        public ICommand SelectItemCommand
        {
            get { return (ICommand)GetValue(SelectItemCommandProperty); }
            set { SetValue(SelectItemCommandProperty, value); }
        }

        private static void SelectItemCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SelectableListView)bindable).SelectItemCommandChanged((ICommand)oldValue, (ICommand)newValue);
        }

        protected virtual void SelectItemCommandChanged(ICommand oldValue, ICommand newValue)
        {
        }

        private void HandleItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.SelectedItem != null && this.SelectItemCommand?.CanExecute(this.SelectedItem) == true)
            {
                this.SelectItemCommand.Execute(this.SelectedItem);
            }
        }

    }
}