using System.Collections.Generic;
using SSSRegen.Source.Core.Interfaces;

namespace SSSRegen.Source.Menus
{
    public interface IGameMenu
    {
        bool IsEnabled { get; set; }
        int SelectedIndex { get; set; }
        //Create menu base class that SetsMenuItems, Initializes, Updates, and Draws
        void SetMenuItems(List<IMenuOption> items);
        void SelectCurrentItem();
        void Initialize();
        void Update(IGameTime gameTime);
        void Draw(IGameTime gameTime);
    }
}