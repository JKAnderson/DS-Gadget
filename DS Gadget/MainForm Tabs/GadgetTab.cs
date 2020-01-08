using System.Windows.Forms;

namespace DS_Gadget
{
    internal class GadgetTab : UserControl
    {
        protected static Properties.Settings Settings = Properties.Settings.Default;

        protected MainForm Main;
        protected DSHook Hook => Main.Hook;
        protected bool Loaded => Main.Loaded;
        protected bool Reading => Main.Reading;

        public virtual void InitTab(MainForm parent)
        {
            Main = parent;
        }

        public virtual void ResetTab() { }

        public virtual void SaveTab() { }

        public virtual void ReloadTab() { }

        public virtual void UpdateTab() { }
    }
}
