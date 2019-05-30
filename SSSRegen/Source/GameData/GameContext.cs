using Microsoft.Xna.Framework;

namespace SSSRegen.Source.GameData
{
    public class GameContext
    {
        public GameContext(Game game)
        {
            ScreenBounds = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }

        public Rectangle ScreenBounds { get; }
    }
}