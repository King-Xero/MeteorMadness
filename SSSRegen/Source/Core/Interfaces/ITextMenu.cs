using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core.Interfaces
{
    public interface ITextMenu
    {
        bool IsVisible { get; set; }
        bool Enabled { get; set; }
        Vector2 Position { get; set; }
        int Width { get; }
        int Height { get; }
        int SelectedIndex { get; set; }
        void SetMenuItems(string[] items);
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}