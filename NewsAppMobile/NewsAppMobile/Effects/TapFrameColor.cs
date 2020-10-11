using Sharpnado.MaterialFrame;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NewsAppMobile.Effects
{
    public class TapFrameColor: TriggerAction<MaterialFrame>
    {
        protected override void Invoke(MaterialFrame frame)
        {
            frame.LightThemeBackgroundColor = Color.FromHex("#bde0fe");            
        }
    }
}
