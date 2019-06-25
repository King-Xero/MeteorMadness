using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameComponents.Graphics;
using SSSRegen.Source.GameComponents.Input;
using SSSRegen.Source.GameComponents.Physics;
using SSSRegen.Source.Health;
using SSSRegen.Source.Score;

namespace SSSRegen.Source.Player
{
    public class Player : GameObject, IHandleHealth, IHandleScore
    {
        private readonly IHealthComponent _healthComponent;
        private readonly IScoreComponent _scoreComponent;
        public Player(IHealthComponent healthComponent, IScoreComponent scoreComponent, IInputComponent<IGameObject> inputComponent, IPhysicsComponent physicsComponent, IGraphicsComponent<IGameObject> graphicsComponent) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
            _scoreComponent = scoreComponent ?? throw new ArgumentNullException(nameof(scoreComponent));
        }

        public event EventHandler<HealEventArgs> Healed = delegate { };
        public event EventHandler<DamageEventArgs> Damaged = delegate { };
        public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated = delegate { };

        public override void Initialize()
        {
            _healthComponent.Initialize(this);
            _healthComponent.Died += PlayerOnDied;

            _scoreComponent.Initialize(this);

            base.Initialize();
        }

        public override void Update()
        {
            _healthComponent.Update(this);
            _scoreComponent.Update(this);
            base.Update();
        }

        public override void Draw(GameTime gameTime)
        {
            _healthComponent.Draw(this);
            _scoreComponent.Draw(this);
            base.Draw(gameTime);
        }

        public void Heal(int healAmount)
        {
            Healed?.Invoke(this, new HealEventArgs(healAmount));
        }

        public void Damage(int damageAmount)
        {
            Damaged?.Invoke(this, new DamageEventArgs(damageAmount));
        }

        public void UpdateScore(int scoreAmount)
        {
            ScoreUpdated?.Invoke(this, new ScoreUpdatedEventArgs(scoreAmount));
        }

        public void Shoot()
        {
            Console.WriteLine("Pew!!!");
        }

        private void PlayerOnDied(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //Player died
        }
    }
}