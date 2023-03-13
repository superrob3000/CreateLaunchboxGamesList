
using System.Drawing;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace RB_CreateGamesList
{
    class TheMenuItem : ISystemMenuItemPlugin
    {
        string ISystemMenuItemPlugin.Caption
        {
            get { return "Create game list file"; }
        }

        bool ISystemMenuItemPlugin.ShowInLaunchBox { get { return true; } }

        bool ISystemMenuItemPlugin.ShowInBigBox { get { return false; } }

        bool ISystemMenuItemPlugin.AllowInBigBoxWhenLocked { get { return false; } }

        Image ISystemMenuItemPlugin.IconImage { get { return Properties.Resources.list; } }

        void ISystemMenuItemPlugin.OnSelected()
        {
            CreateGamelist_Form frm = new CreateGamelist_Form();
            frm.Show();
        }
    }
}
