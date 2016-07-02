using System.Collections.Generic;
using MugenMvvmToolkit.Interfaces.Navigation;
using MugenMvvmToolkit.ViewModels;
using MugenSandbox.Core.Models;

namespace MugenSandbox.Core.ViewModels
{
    public class TableViewModel : WorkspaceViewModel
    {
        public GridViewModel<Person> GridViewModel { get; set; }

        protected override void OnNavigatedTo(INavigationContext context)
        {
            base.OnNavigatedTo(context);

            var persons = new List<Person>();
            for (var i = 0; i < 10; i++)
                persons.Add(new Person {Name = $"Name {i}"});

            GridViewModel = GetViewModel<GridViewModel<Person>>();
            GridViewModel.UpdateItemsSource(persons);
        }
    }
}