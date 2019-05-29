using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Meteors
{
    /// <summary>
    /// This is a game component that manages all of the meteors in the game
    /// </summary>
    public class MeteorManager : DrawableGameComponent
    {
        private List<SmallMeteor> _sMeteors; //List of active small meteors
        private List<MediumMeteor> _mMeteors; //List of active medium meteors
        private const int START_METEOR_COUNT = 2; //Constant for initial meteor count
        private const int ADD_SMALL_METEOR_TIME = 150; //Time for a new small meteor
        private const int ADD_MEDIUM_METEOR_TIME = 300; //Time for a new medium meteor

        private Texture2D _sMeteorTexture; //Texture for small meteor
        private Texture2D _mMeteorTexture; //Texture for medium meteor
        private TimeSpan _elapsedTime = TimeSpan.Zero;

        private Random _random = new Random();


        public MeteorManager(Game game, ref Texture2D spriteSheet)
            : base(game)
        {
            // TODO: Construct any child components here
            _sMeteorTexture = spriteSheet;
            _sMeteors = new List<SmallMeteor>(); //Create list for small meteors
            _mMeteorTexture = spriteSheet;
            _mMeteors = new List<MediumMeteor>(); //Create list for medium meteors
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            _sMeteors.Clear(); //Clears the list of small meteors
            _mMeteors.Clear(); //Clears the list of medium meteors

            Start(); //Initialize all meteors in the lists
            foreach (var sMeteor in _sMeteors)
            {
                sMeteor.Initialize();
            }

            foreach (var mMeteor in _mMeteors)
            {
                mMeteor.Initialize();
            }

            base.Initialize();
        }

        public void Start() //Start the meteors
        {
            _elapsedTime = TimeSpan.Zero; //Initialize a counter
            for (var i = 0; i < START_METEOR_COUNT; i++)
            {
                AddNewSmallMeteor();
                AddNewMediumMeteor();
            }
        }

        //List of all small meteors in the game
        public List<SmallMeteor> AllSmallMeteors => _sMeteors;

        //List of all medium meteors in the game
        public List<MediumMeteor> AllMediumMeteors => _mMeteors;

        private void CheckForNewSmallMeteor(GameTime gameTime) //Check if its time for a new small meteor
        {
            //Add a new small meteor each ADD_SMALL_METEOR_TIME
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromSeconds(ADD_SMALL_METEOR_TIME))
            {
                _elapsedTime -= TimeSpan.FromSeconds(ADD_SMALL_METEOR_TIME);
                AddNewSmallMeteor();
            }
        }

        private void CheckForNewMediumMeteor(GameTime gameTime) //Check if its time for a new medium meteor
        {
            //Add a new medium meteor each ADD_MEDIUM_METEOR_TIME
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime > TimeSpan.FromSeconds(ADD_MEDIUM_METEOR_TIME))
            {
                _elapsedTime -= TimeSpan.FromSeconds(ADD_MEDIUM_METEOR_TIME);
                AddNewMediumMeteor();
            }
        }

        private void AddNewSmallMeteor() //Add a new small meteor to the game
        {
            SmallMeteor newSmallMeteor = new SmallMeteor(Game, ref _sMeteorTexture); //Create new small meteor
            newSmallMeteor.Initialize(); //Initialize the new small meteor
            _sMeteors.Add(newSmallMeteor); //Add the new small meteor to the list of small meteors in the game
            newSmallMeteor.Index = _sMeteors.Count - 1; //Sets the identifier
        }

        private void AddNewMediumMeteor() //Add a new medium meteor to the game
        {
            MediumMeteor newMediumMeteor = new MediumMeteor(Game, ref _mMeteorTexture); //Create new medium meteor
            newMediumMeteor.Initialize(); //Initialize the new medium meteor
            _mMeteors.Add(newMediumMeteor); //Add the new medium meteor to the list of medium meteors in the game
            newMediumMeteor.Index = _mMeteors.Count - 1; //Sets the identifier
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            CheckForNewSmallMeteor(gameTime);
            CheckForNewMediumMeteor(gameTime);

            //Update small meteors
            foreach (var sMeteor in _sMeteors)
            {
                sMeteor.Update(gameTime);
            }

            //Update medium meteors
            foreach (var mMeteor in _mMeteors)
            {
                mMeteor.Update(gameTime);
            }

            base.Update(gameTime);
        }

        //Check if the ship collided with a meteor, returns true if a collision occurs
        public bool SmallMeteorCollision(Rectangle rect)
        {
            foreach (var sMeteor in _sMeteors)
            {
                if (sMeteor.CheckCollision(rect))
                {
                    sMeteor.PutinStart_position(); //Reset the meteor
                    return true;
                }
            }

            return false;
        }

        public bool MediumMeteorCollision(Rectangle rect)
        {
            foreach (var mMeteor in _mMeteors)
            {
                if (mMeteor.CheckCollision(rect))
                {
                    mMeteor.PutinStart_position(); //Reset the meteor
                    return true;
                }
            }

            return false;
        }

        public override void Draw(GameTime gameTime)
        {
            //Draw the small meteors
            foreach (var sMeteor in _sMeteors)
            {
                sMeteor.Draw(gameTime);
            }

            //Draw the medium meteors
            foreach (var mMeteor in _mMeteors)
            {
                mMeteor.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}