using System.Windows.Forms;

namespace ExtensionMethods
{
    public static class TabPageExtensions
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

        public static void Elrejt(this TabPage tabPage)
        {
            TabControl parent = (TabControl)tabPage.Parent;
            parent.TabPages.Remove(tabPage);
        }

        public static void Megjelenít(this TabPage tabPage, TabControl parent)
        {
            parent.TabPages.Add(tabPage);
        }
    }
}