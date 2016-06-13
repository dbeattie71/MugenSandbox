using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;

namespace MugenSandbox.iOS
{
    public class TouchBindingModule : ModuleBase
    {
        public TouchBindingModule() : base(true, LoadMode.All, int.MinValue)
        {
        }

        protected override bool LoadInternal()
        {
            return true;
        }

        protected override void UnloadInternal()
        {
        }
    }
}