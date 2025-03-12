using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace L_AI.Commands.ToolbarHelper
{
    public static class MenuStatusHandler
    {
        public enum IconStatusColor
        {
            Red,
            Yellow,
            Green,
            Blue
        }
        private static CommandBarButton _iconButton = null;

        public static async Task SetIconColorAsync(IconStatusColor color)
        {
            string base64 = "";
            switch (color)
            {
                case IconStatusColor.Red:
                    base64 = Base64Colors.redBase64;
                    break;
                case IconStatusColor.Yellow:
                    base64 = Base64Colors.yellowBase64;
                    break;
                case IconStatusColor.Green:
                    base64 = Base64Colors.greenBase64;
                    break;
                case IconStatusColor.Blue:
                    base64 = Base64Colors.blueBase64;
                    break;
             }

            string newText = "";
            switch (color)
            {
                case IconStatusColor.Red:
                    newText = "[L.AI] Unable to connect to your AI backend. Check your settings.";
                    break;
                case IconStatusColor.Yellow:
                    newText = "[L.AI] Connecting to the AI backend...";
                    break;
                case IconStatusColor.Green:
                    newText = "[L.AI] Waiting for suggestion request.";
                    break;
                case IconStatusColor.Blue:
                    newText = "[L.AI] Processing the request.";
                    break;
            }

            var allCaptions = new List<string>();

            if(_iconButton != null)
            {
                var bmp = Base64ToBitmap(base64);
                _iconButton.Picture = (stdole.StdPicture)IconConverter.GetIPictureDispFromImage(bmp);
                _iconButton.Caption = newText;
                _iconButton.TooltipText = newText;
                return;
            }

            try
            {
                var dte2 = (DTE2)await LAIPackage.Instance.GetServiceAsync(typeof(DTE));
                CommandBars commandBars = (CommandBars)dte2.CommandBars;
                foreach (CommandBar commandBar in commandBars)
                {
                    foreach (CommandBarControl control in commandBar.Controls)
                    {
                        allCaptions.Add(control.Caption);
                        if (control is CommandBarButton button && control.Caption.Contains("[L.AI]"))
                        {
                            _iconButton = button;

                            var bmp = Base64ToBitmap(base64);
                            button.Picture = (stdole.StdPicture)IconConverter.GetIPictureDispFromImage(bmp);
                            button.Caption = newText;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LAIPackage.Serilog.Error($"[MenuStatusHandler] Error while trying to update the toolbar: {ex.Message}");
            }
        }

        private static Bitmap Base64ToBitmap(string base64String)
        {
            byte[] imageAsBytes = Convert.FromBase64String(base64String);
            using (MemoryStream memoryStream = new MemoryStream(imageAsBytes))
            {
                var bmpReturn = (Bitmap)System.Drawing.Image.FromStream(memoryStream);
                memoryStream.Close();
                return bmpReturn;
            }
        }
    }
}
