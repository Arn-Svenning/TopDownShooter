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

            if (InputManager.PressOnce(Keys.Right))
            {
                centre.X += 64;
            }
            if (InputManager.PressOnce(Keys.Left))
            {
                centre.X -= 64;
            }
            if (InputManager.PressOnce(Keys.Up))
            {
                centre.Y -= 64;
            }
            if (InputManager.PressOnce(Keys.Down))
            {
                centre.Y += 64;
            }

        }
    }
}