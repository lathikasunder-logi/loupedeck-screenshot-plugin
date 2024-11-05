namespace Loupedeck.MyProjectPlugin
{
    using System;
    using System.Runtime.InteropServices;

    // This class implements an example command that counts button presses.
    public class CounterCommand : PluginDynamicCommand
    {
        // Define the external method here, within the class.
        [DllImport("plugin.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void CaptureScreenshot(String filename);

        // private Int32 _counter = 0;

        // Initializes the command class.
        public CounterCommand()
            : base(displayName: "Capture ss", description: "post to ifttt", groupName: "Commands")
        {
        }

        // This method is called when the user executes the command.
        protected override void RunCommand(String actionParameter)
        {
            // this._counter++;
            // this.ActionImageChanged(); // Notify the plugin service that the command display name and/or image has changed.
            // PluginLog.Info($"Counter value is {this._counter}"); // Write the current counter value to the log file.

            var filename = "screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            PluginLog.Info("Capturing screenshot to " + filename);
            // Call the external function
            CaptureScreenshot(filename);
            PluginLog.Info("Screenshot captured.");
        }

        // This method is called when Loupedeck needs to show the command on the console or the UI.
        protected override String GetCommandDisplayName(String actionParameter, PluginImageSize imageSize) =>
            $"Click to capture{Environment.NewLine}";
    }
}
