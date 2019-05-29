using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SSSRegen.Source.Core
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameScreen : DrawableGameComponent
    {
        //List of child GameComponents
        private readonly List<GameComponent> _components;

        //Components of Game Screen
        //Used to expose the Components list, to be be able to add to new actors to the scene from the derived classes
        public List<GameComponent> Components => _components;

        public GameScreen(Game game) : base(game)
        {
            // TODO: Construct any child components here
            _components = new List<GameComponent>();
            Visible = false; //Will not be visible initially
            Enabled = false; //Will not have its status updated initially
        }

        public virtual void Show() //Show the scene
        {
            Visible = true;
            Enabled = true;
        }

        public virtual void Hide() //Hide the scene
        {
            Visible = false;
            Enabled = false;
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
            
            //Loops through all of the child GameComponents
            foreach (var t in _components)
            {
                //Update the component if it is enabled
                if (t.Enabled)
                {
                    t.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Draw the child GameComponents (if drawable)
            foreach (var gc in _components)
            {
                if (gc is DrawableGameComponent component && component.Visible)
                {
                    component.Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }
    }
}