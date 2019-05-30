using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;

namespace SSSRegen.Source.Player
{
    public class Player : GameObject
    {
        public Player(IInputComponent inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            Reset();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        private void Reset()
        {
            //Put in start position
            //Initialize health
            //Initialize score

            //if (_playerIndex == PlayerIndex.One)
            //{
            //    _position.X = _screenBounds.Width / 3; //Player ones's _position along the bottom of the screen
            //}
            //else
            //{
            //    _position.X = (int)(_screenBounds.Width / 1.5); //Player two's _position along the bottom of the screen
            //}

            //_position.Y = _screenBounds.Height - _sprite.Bounds.Height - 10; //Places the player(s) at the very bottom of the screen
            //_score = 0; //Resets the score to zero
            //_health = INITIAL_HEALTH; //Resets the health to intial value

            //IsEnabled = true;
        }
    }
}