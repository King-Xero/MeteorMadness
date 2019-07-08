using System;
using Microsoft.Xna.Framework;
using SSSRegen.Source.Core;
using SSSRegen.Source.Core.Interfaces;
using SSSRegen.Source.GameData;
using SSSRegen.Source.Health;
using SSSRegen.Source.Projectiles;
using SSSRegen.Source.Score;

namespace SSSRegen.Source.Player
{
    public class Player : GameObject, IHandleHealth, IHandleScore, IShootProjectiles
    {
        private readonly IHealthComponent _healthComponent;
        private readonly IScoreComponent _scoreComponent;
        private readonly IProjectilesManager _projectileManager;

        public Player(IHealthComponent healthComponent, IScoreComponent scoreComponent, IComponent<IGameObject> inputComponent, IComponent<IGameObject> physicsComponent, IDrawableComponent<IGameObject> graphicsComponent, IProjectilesManager projectileManager) :
            base(inputComponent, physicsComponent, graphicsComponent)
        {
            _healthComponent = healthComponent ?? throw new ArgumentNullException(nameof(healthComponent));
            _scoreComponent = scoreComponent ?? throw new ArgumentNullException(nameof(scoreComponent));
            _projectileManager = projectileManager ?? throw new ArgumentNullException(nameof(projectileManager));
        }

        public event EventHandler<HealEventArgs> Healed = delegate { };
        public event EventHandler<DamageEventArgs> Damaged = delegate { };
        public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated = delegate { };

        public int MaxHealth { get; private set; }

        public Vector2 BulletPosition => new Vector2(Position.X + (Size.X / 2), Position.Y - (Size.Y / 2));

        public override void Initialize()
        {
            MaxHealth = GameConstants.Player.InitialMaxHealth;

            _healthComponent.Initialize(this);
            _healthComponent.Died += PlayerOnDied;

            _scoreComponent.Initialize(this);

            _projectileManager.Initialize();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _healthComponent.Update(this);
            _scoreComponent.Update(this);

            _projectileManager.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _healthComponent.Draw(this);
            _scoreComponent.Draw(this);

            _projectileManager.Draw(gameTime);

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
            _projectileManager.Shoot(this);
        }

        private void PlayerOnDied(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //Player died
        }
    }
}