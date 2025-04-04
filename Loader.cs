using Exiled.API.Features;
using Exiled.CustomItems.API;
using System.ComponentModel;

namespace Dublicator {
    internal class Loader : Plugin<Config.Config> {
        public static Loader Instance;
        public override void OnEnabled() {
            Instance = this;
            Config.item.Register();
            base.OnEnabled();
        }

        public override void OnDisabled() {
            Instance = null;
            Config.item.Unregister();
            base.OnDisabled();
        }
    }
}
