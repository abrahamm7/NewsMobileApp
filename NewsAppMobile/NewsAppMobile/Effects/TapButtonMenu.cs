using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NewsAppMobile.Effects
{
    public class TapButtonMenu : TriggerAction<Button>
    {
        protected async override void Invoke(Button button)
        {
            await button.ScaleTo(0.95, 50, Easing.CubicOut);
            await button.ScaleTo(1, 50, Easing.CubicIn);
        }
    }
}
