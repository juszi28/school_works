using System;
using System.Windows.Forms;

namespace TabControlFüggvények
{ 
    public static class TabOldalakKiegszítése
    {

        public static bool Látható(this TabPage tabPage)
        {
            if (tabPage.Parent == null)
                return false;
            else if (tabPage.Parent.Contains(tabPage))
                return true;
            else
                return false;
        }

        public static void TabHide(this TabPage tabPage)
        {
            TabControl parent = (TabControl)tabPage.Parent;
            parent.TabPages.Remove(tabPage);
        }

        public static void TabMegjelenítése(this TabPage tabPage, TabControl parent)
        {
            parent.TabPages.Add(tabPage);
        }
    }
}
