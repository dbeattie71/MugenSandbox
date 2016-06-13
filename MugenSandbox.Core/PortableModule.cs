using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Modules;

namespace MugenSandbox.Core
{
    public class PortableModule : ModuleBase
    {
        public PortableModule()
            : base(false, LoadMode.All)
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