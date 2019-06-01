using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.Score;

namespace SSSRegen.Source.Player
{
    public class Player : GameObject, IHandleScore
    {
        private readonly IScoreComponent _scoreComponent;

        public Player(IScoreComponent scoreComponent, IInputComponent inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
            _scoreComponent = scoreComponent ?? throw new ArgumentNullException(nameof(scoreComponent));
        }

        public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated = delegate { };

        public void UpdateScore(int scoreAmount)
        {
            ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs(scoreAmount));
        }

        public override void Initialize()
        {
            _scoreComponent.Initialize(this);
            base.Initialize();

            Reset();
        }

        public override void Update()
        {
            _scoreComponent.Update(this);
            base.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            _scoreComponent.Draw(this);
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