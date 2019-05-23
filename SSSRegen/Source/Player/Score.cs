using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SSSRegen.Source.Player
{
    /// <summary>
    /// This is a game component that implements score and health points
    /// </summary>
    public class Score : Microsoft.Xna.Framework.DrawableGameComponent
    {

        private SpriteBatch _spriteBatch = null; //SpriteBatch
        private Vector2 __position = new Vector2(); //Score _position

        //Values
        private int _score; //Score points
        private int _health; //Health points

        private readonly SpriteFont _font;
        private readonly Color _fontColour;


        public Score(Game game, SpriteFont font, Color fontColour)
            : base(game)
        {
            // TODO: Construct any child components here
            _font = font;
            _fontColour = fontColour;
            _spriteBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch)); //Get current sprite batch
        }

        //Score points
        public int ScorePoints 
        {
            get => _score;
            set => _score = value;
        }

        //Health points
        public int HealthPoints 
        {
            get => _health;
            set => _health = value;
        }

        public Vector2 _position
        {
            get => __position;
            set => __position = value;
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

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            string textToDraw = $"Score: {_score}"; //Set the text for score

            //Draw a shadow for the score text
            _spriteBatch.DrawString(_font, textToDraw, new Vector2(__position.X + 1, __position.Y + 1), Color.Black);
            //Draw the score text
            _spriteBatch.DrawString(_font, textToDraw, new Vector2(__position.X, __position.Y), _fontColour);

            float height = _font.MeasureString(textToDraw).Y; //Set a gap so that score and health are drawn on different lines
            textToDraw = $"Health: {_health}"; //Set the text for health
            //Draw a shadow for the health text
            _spriteBatch.DrawString(_font, textToDraw, new Vector2(__position.X + 1, __position.Y + 1 + height), Color.Black);
            //Draw the health text
            _spriteBatch.DrawString(_font, textToDraw, new Vector2(__position.X + 1, __position.Y + 1 + height), _fontColour);

            base.Draw(gameTime);
        }
    }
}