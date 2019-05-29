using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Enemies
{
    /// <summary>
    /// This is a game component that manages all of the enemies in the game
    /// </summary>
    public class EnemyManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private List<Enemy1> _enemy1S; //List of active ememy1s
        private List<Enemy2> _enemy2S; //List of active ememy2s
        private List<Enemy3> _enemy3S; //List of active ememy3s
        private List<EnemyBoss> _enemyBs; //List of active Bosses
        private const int START_ENEMY_COUNT = 4; //Constant for initial enemy count
        private const int ADD_ENEMY1_TIME = 120; //Time for a new enemy1
        private const int ADD_ENEMY2_TIME = 180; //Time for a new enemy2
        private const int ADD_ENEMY3_TIME = 240; //Time for a new enemy3
        private const int ADD_ENEMY_BOSS_TIME = 5; //Time for a new boss

        private Texture2D _enemy1Texture; //Texture for enemy 1
        private Texture2D _enemy2Texture; //Texture for enemy 2
        private Texture2D _enemy3Texture; //Texture for enemy 3
        private Texture2D _enemyBTexture; //Texture for boss
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        private Random _random = new Random();


        public EnemyManager(Game game, ref Texture2D spriteSheet)
            : base(game)
        {
            // TODO: Construct any child components here
            _enemy1Texture = spriteSheet;
            _enemy1S = new List<Enemy1>();
            _enemy2Texture = spriteSheet;
            _enemy2S = new List<Enemy2>();
            _enemy3Texture = spriteSheet;
            _enemy3S = new List<Enemy3>();
            _enemyBTexture = spriteSheet;
            _enemyBs = new List<EnemyBoss>();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            _enemy1S.Clear(); //Clears the list of enemy1s
            _enemy2S.Clear(); //Clears the list of enemy2s
            _enemy3S.Clear(); //Clears the list of enemy3s
            _enemyBs.Clear(); //Clears the list of bosses            

            Start(); //Initialize all enemies in the list

            for (int i = 0; i < _enemy1S.Count; i++)
            {
                _enemy1S[i].Initialize();
            }

            for (int i = 0; i < _enemy2S.Count; i++)
            {
                _enemy2S[i].Initialize();
            }

            for (int i = 0; i < _enemy3S.Count; i++)
            {
                _enemy3S[i].Initialize();
            }

            for (int i = 0; i < _enemyBs.Count; i++)
            {
                _enemyBs[i].Initialize();
            }

            base.Initialize();
        }

        public void Start() //Start the enemies
        {
            _elapsedTime = TimeSpan.Zero; //Initialize a counter
            for (int i = 0; i < START_ENEMY_COUNT; i++)
            {
                AddNewEnemy1();
                //Other enemy types won't spawn in game unless they are started here. 
                //However as a result of this they appear at the beginning of the game which was not intended.
                //AddNewEnemy2();
                //AddNewEnemy3();
                //AddNewEnemyB();
            }
        }

        public List<Enemy1> AllEnemy1s => _enemy1S;

        public List<Enemy2> AllEnemy2s => _enemy2S;

        public List<Enemy3> AllEnemy3s => _enemy3S;

        public List<EnemyBoss> AllEnemyBs => _enemyBs;

        private void CheckForNewEnemy1(GameTime gameTime) //Check if its time for a new enemy1
        {
            //Add a new enemy1 each ADD_ENEMY1_TIME
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromSeconds(ADD_ENEMY1_TIME))
            {
                _elapsedTime -= TimeSpan.FromSeconds(ADD_ENEMY1_TIME);
                AddNewEnemy1();
            }
        }

        private void CheckForNewEnemy2(GameTime gameTime) //Check if its time for a new enemy2
        {
            //Add a new enemy2 each ADD_ENEMY2_TIME
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromSeconds(ADD_ENEMY2_TIME))
            {
                _elapsedTime -= TimeSpan.FromSeconds(ADD_ENEMY2_TIME);
                AddNewEnemy2();
            }
        }

        private void CheckForNewEnemy3(GameTime gameTime) //Check if its time for a new enemy3
        {
            //Add a new enemy3 each ADD_ENEMY3_TIME
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromSeconds(ADD_ENEMY3_TIME))
            {
                _elapsedTime -= TimeSpan.FromSeconds(ADD_ENEMY3_TIME);
                AddNewEnemy3();
            }
        }

        private void CheckForNewEnemyB(GameTime gameTime) //Check if its time for a new boss
        {
            //Add a new boss each ADD_ENEMYB_TIME
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromMinutes(ADD_ENEMY_BOSS_TIME))
            {
                _elapsedTime -= TimeSpan.FromMinutes(ADD_ENEMY_BOSS_TIME);
                AddNewEnemyB();
            }
        }

        private void AddNewEnemy1() //Add a new enemy1 to the game
        {
            Enemy1 newEnemy1 = new Enemy1(Game, ref _enemy1Texture); //Create new enemy1
            newEnemy1.Initialize(); //Initialize the new enemy1
            _enemy1S.Add(newEnemy1); //Add the new enemy1 to the list of enemy1s in the game
            newEnemy1.Index = _enemy1S.Count - 1; //Sets the identifier
        }

        private void AddNewEnemy2() //Add a new enemy2 to the game
        {
            Enemy2 newEnemy2 = new Enemy2(Game, ref _enemy2Texture); //Create new enemy2
            newEnemy2.Initialize(); //Initialize the new enemy2
            _enemy2S.Add(newEnemy2); //Add the new enemy2 to the list of enemy2s in the game
            newEnemy2.Index = _enemy2S.Count - 1; //Sets the identifier
        }

        private void AddNewEnemy3() //Add a new enemy3 to the game
        {
            Enemy3 newEnemy3 = new Enemy3(Game, ref _enemy3Texture); //Create new enemy3
            newEnemy3.Initialize(); //Initialize the new enemy3
            _enemy3S.Add(newEnemy3); //Add the new enemy3 to the list of enemy3s in the game
            newEnemy3.Index = _enemy3S.Count - 1; //Sets the identifier
        }

        private void AddNewEnemyB() //Add a new boss to the game
        {
            EnemyBoss newEnemyB = new EnemyBoss(Game, ref _enemyBTexture); //Create new boss
            newEnemyB.Initialize(); //Initialize the new boss
            _enemyBs.Add(newEnemyB); //Add the new boss to the list of bosses in the game
            newEnemyB.Index = _enemyBs.Count - 1; //Sets the identifier
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            CheckForNewEnemy1(gameTime);
            CheckForNewEnemy2(gameTime);
            CheckForNewEnemy3(gameTime);
            CheckForNewEnemyB(gameTime);

            //Update enemy1s
            foreach (var enemy1 in _enemy1S)
            {
                enemy1.Update(gameTime);
            }

            //Update enemy2s
            foreach (var enemy2 in _enemy2S)
            {
                enemy2.Update(gameTime);
            }

            //Update enemy3s
            foreach (var enemy3 in _enemy3S)
            {
                enemy3.Update(gameTime);
            }

            //Update bosses
            foreach (var enemyB in _enemyBs)
            {
                enemyB.Update(gameTime);
            }

            base.Update(gameTime);
        }

        //Check if the ship collided with an enemy, returns true if a collision occurs
        public bool Enemy1Collision(Rectangle rect)
        {
            foreach (var enemy1 in _enemy1S)
            {
                if (enemy1.CheckCollision(rect))
                {
                    enemy1.PutinStartPosition(); //Reset the enemy
                    return true;
                }
            }

            return false;
        }

        public bool Enemy2Collision(Rectangle rect)
        {
            foreach (var enemy2 in _enemy2S)
            {
                if (enemy2.CheckCollision(rect))
                {
                    enemy2.PutinStart_position(); //Reset the enemy
                    return true;
                }
            }

            return false;
        }


        public bool Enemy3Collision(Rectangle rect)
        {
            foreach (var enemy3 in _enemy3S)
            {
                if (enemy3.CheckCollision(rect))
                {
                    enemy3.PutinStart_position(); //Reset the enemy
                    return true;
                }
            }

            return false;
        }

        public bool BossCollision(Rectangle rect)
        {
            foreach (var enemyB in _enemyBs)
            {
                if (enemyB.CheckCollision(rect))
                {
                    enemyB.PutinStart_position(); //Reset the enemy
                    return true;
                }
            }

            return false;
        }

        public override void Draw(GameTime gameTime)
        {
            //Draw the enemy1s
            foreach (var enemy1 in _enemy1S)
            {
                enemy1.Draw(gameTime);
            }

            //Draw the enemy2s
            foreach (var enemy2 in _enemy2S)
            {
                enemy2.Draw(gameTime);
            }

            //Draw the enemy3s
            foreach (var enemy3 in _enemy3S)
            {
                enemy3.Draw(gameTime);
            }

            //Draw the bosses
            foreach (var enemyB in _enemyBs)
            {
                enemyB.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}