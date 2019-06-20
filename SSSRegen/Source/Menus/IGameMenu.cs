using System.Collections.Generic;
using Microsoft.Xna.Framework;

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
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}