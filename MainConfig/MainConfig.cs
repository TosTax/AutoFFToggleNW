namespace AutoFFToggleNW
{
    using System.ComponentModel;

    public class MainConfig
    {
        [Description("Wheter the plugin is enabled")]
        public bool IsEnabled { get; set; } = true;

        [Description("Plugin sends activation and deactivation messages to console")]
        public bool Logs { get; set; } = true;
    }
}