#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.Camera
{
    internal class EditorCamera
    {
        private Matrix transform;
        public Matrix Transform { get { return transform; } }       
        private Vector2 firstCentre;
        public Vector2 FirstCentre { get { return firstCentre; } }

        private Vector2 newCentre;
        public Vector2 NewCenter { get { return newCentre; } }
        

        public EditorCamera(GameWindow WINDOW)
        {
            //view = VIEW;
            firstCentre = new Vector2(WINDOW.ClientBounds.X, WINDOW.ClientBounds.Y);
            
        }

        public void Update(GameTime gameTime)
        {
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-firstCentre.X,  -firstCentre.Y, 0));

            if (InputManager.HoldKey(Keys.Right))
            {
                firstCentre.X += 10;
            }
            if (InputManager.HoldKey(Keys.Left))
            {
                firstCentre.X -= 10;
            }
            if (InputManager.HoldKey(Keys.Up))
            {
                firstCentre.Y -= 10;
            }
            if (InputManager.HoldKey(Keys.Down))
            {
                firstCentre.Y += 10;
            }

        }
    }
}