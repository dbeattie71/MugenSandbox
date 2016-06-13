using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;

namespace MugenSandbox.iOS
{
    public class TouchModule : ModuleBase
    {
        public TouchModule()
            : base(false, LoadMode.Runtime)
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