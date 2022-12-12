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
        public Rectangle Size { get { return size; } }

        protected Texture2D texture;

        protected Vector2 position;



        public GameObjects(Rectangle RECTANGLE)
        {
            size = RECTANGLE;

            position = new Vector2(size.X, size.Y);
        }
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
