using Foundation;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Binding.Builders;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Binding;
using MugenMvvmToolkit.iOS.Binding.Infrastructure;
using MugenMvvmToolkit.iOS.Views;
using MugenSandbox.Core.Models;
using MugenSandbox.Core.ViewModels;
using UIKit;

namespace MugenSandbox.iOS.Views
{
    [ViewModel(typeof(TableViewModel))]
    public class TableViewController : MvvmViewController
    {
        protected UITableView TableView { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView = new UITableView(View.Frame);// { AutoresizingMask = UIViewAutoresizing.All };
            View.AddSubview(TableView);
            TableView.SetBindingMemberValue(AttachedMembers.UITableView.ItemTemplateSelector, PersonCellTemplateSelector.Instance);


            using (var set = new BindingSet<TableViewModel>())
            {
                set.Bind(TableView, AttachedMembers.UIView.ItemsSource).To<TableViewModel>(() => (vm, context) => vm.GridViewModel.ItemsSource);
            }

        }
    }

    public class PersonCellTemplateSelector : TableCellTemplateSelectorBase<Person, UITableViewCell>
    {
        private static readonly NSString GrainBinLevelHistoryId = new NSString(nameof(Person));

        public static readonly PersonCellTemplateSelector Instance =
            new PersonCellTemplateSelector();

        private PersonCellTemplateSelector()
        {
        }

        protected override NSString GetIdentifier(Person item, UITableView container)
        {
            return GrainBinLevelHistoryId;
        }

        protected override void Initialize(
            UITableViewCell template, BindingSet<UITableViewCell, Person> bindingSet)
        {
            template.SetEditingStyle(UITableViewCellEditingStyle.None);
            template.TextLabel.AdjustsFontSizeToFitWidth = true;
            bindingSet.Bind(template.TextLabel).To(() => (m, ctx) => m.Name);
        }

        protected override UITableViewCell SelectTemplate(UITableView container, NSString identifier)
        {
            return new UITableViewCellBindable(UITableViewCellStyle.Default, identifier);
        }
    }
}