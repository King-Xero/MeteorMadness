using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SSSRegen.Source.Core
{
    /// <summary>
    /// Gamepad rumble
    /// </summary>
    public class RumblePad : GameComponent
    {

        private int _time; //Vibration time
        private int _lastTickCount;

        public RumblePad(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            if (_time > 0)
            {
                int elapsed = System.Environment.TickCount - _lastTickCount;
                if (elapsed >= _time)
                {
                    _time = 0;
                    GamePad.SetVibration(PlayerIndex.One, 0, 0);
                    GamePad.SetVibration(PlayerIndex.Two, 0, 0);
                }
            }

            base.Update(gameTime);
        }

        //Turn the vibration off
        protected override void Dispose(bool disposing)
        {
            GamePad.SetVibration(PlayerIndex.One, 0, 0);

            base.Dispose(disposing);
        }

        //Set the vibration
        public void GamePadRumble(PlayerIndex playerIndex, int Time, float LeftMotor, float RightMotor)
        {
            _lastTickCount = System.Environment.TickCount;
            _time = Time;
            GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
        }

        public void Stop(PlayerIndex playerIndex) //Stop the vibration
        {
            GamePad.SetVibration(playerIndex, 0, 0);
        }
    }
}