using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace MugenSandbox.Core.ViewModels
{
    public class MainViewModel : CloseableViewModel, INavigableViewModel
    {
        private bool _isFirstNavigation;

        public MainViewModel()
        {
            ChangeSomeStringCommand = new RelayCommand(ButtonTest);
        }

        public ICommand ChangeSomeStringCommand { get; private set; }

        public string SomeString { get; set; }

        public void OnNavigatedTo(INavigationContext context)
        {
            if (_isFirstNavigation)
                return;

            SomeString = DateTime.Now.ToString();
        }

        public Task<bool> OnNavigatingFrom(INavigationContext context)
        {
            return Empty.TrueTask;
        }

        public void OnNavigatedFrom(INavigationContext context)
        {
        }

        private void ButtonTest()
        {
            SomeString = DateTime.Now.ToString();
        }
    }
}