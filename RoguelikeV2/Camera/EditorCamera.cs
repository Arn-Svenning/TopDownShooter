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
        private Vector2 centre;
        public Vector2 Centre { get { return centre; } }

        public EditorCamera(Viewport VIEW)
        {
            
            centre = new Vector2(VIEW.X , VIEW.Y);
            
        }

        public void Update(GameTime gameTime)
        {
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X,  -centre.Y, 0));

            if (InputManager.HoldKey(Keys.Right))
            {
                centre.X += 10;
            }
            if (InputManager.HoldKey(Keys.Left))
            {
                centre.X -= 10;
            }
            if (InputManager.HoldKey(Keys.Up))
            {
                centre.Y -= 10;
            }
            if (InputManager.HoldKey(Keys.Down))
            {
                centre.Y += 10;
            }

        }
    }
}