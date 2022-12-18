#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace RoguelikeV2.GameLogic
{
    abstract class GameObjects
    {
        protected Rectangle size;
        public Rectangle Size { get { return size; } set { size = value; } }

        protected Texture2D texture;
        public Texture2D Texture { get { return texture; } }

        protected Vector2 position;
        public Vector2 Position { get { return position; } }



        public GameObjects(Rectangle RECTANGLE)
        {
            size = RECTANGLE;

            position = new Vector2(size.X, size.Y);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
