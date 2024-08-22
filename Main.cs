namespace AutoFFToggleNW
{
    using PluginAPI.Core;
    using PluginAPI.Core.Attributes;
    using PluginAPI.Enums;
    using PluginAPI.Events;
    public class Plugin
    {
        [PluginConfig]
        public MainConfig MainConfig;

        public static Plugin Instance { get; private set; }
        [PluginEntryPoint("AutoFFToggleNW", "1.0.0", "AutoFFToggle using NW API.", "TosTa")]

        public void OnEnabled()
        {
            if (!MainConfig.IsEnabled) return;
            if (Server.FriendlyFire)
            {
                Log.Warning("Friendly fire is already activated. AutoFFToggleNW will be disabled");
                return;
            }
            Instance = this;
            EventManager.RegisterEvents(this);
            Log.Info("AutoFFToggleNW loaded successfully!");
        }

        [PluginEvent(ServerEventType.WaitingForPlayers)]
        public void OnWaitingForPlayers()
        {
            Server.FriendlyFire = false;
            if (!MainConfig.Logs) return;
            Log.Info("Friendly Fire deactivated!");

        }

        [PluginEvent(ServerEventType.RoundEnd)]
        public void OnRoundEnded(RoundSummary.LeadingTeam leadingTeam)
        {
            Server.FriendlyFire = true;
            if (!MainConfig.Logs) return;
            Log.Info("Friendly Fire activated!");
        }
    }
}
