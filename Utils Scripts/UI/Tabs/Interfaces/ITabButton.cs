using Utils.UI.Tabs.Components;

namespace Utils.UI.Tabs.Interfaces
{
    public interface ITabButton
    {
        void Initiate(TabGroupUI tabGroupUI);
        void Select();
        void Deselect();
    }
}