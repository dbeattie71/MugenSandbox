using System;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS.Views;
using MugenSandbox.Core.ViewModels;

namespace MugenSandbox.iOS.Views
{
    [ViewModel(typeof (MainViewModel))]
    public partial class MainView : MvvmViewController
    {
        private string _someString;

        public MainView() : base("MainView", null)
        {
        }

        public string SomeString
        {
            get
            {
                return _someString;
            }
            set
            {
                _someString = value;

                if (value !=null)
                    SomeStringLb.Text = value;
            }
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            using (var set = new BindingSet<MainViewModel>())
            {
                set.Bind(ChangeSomeStringBtn).To(() => (vm, ctx) => vm.ChangeSomeStringCommand);
                set.Bind(this, nameof(SomeString)).To(() => (vm, ctx) => vm.SomeString).TwoWay();
            }
        }

        public event EventHandler SomeStringChanged;
    }
}