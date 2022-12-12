#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace RoguelikeV2.GameLogic.Moving
{
    abstract class MovingObjects : GameObjects
    {
        protected float velocity;

        protected Vector2 direction;
        public MovingObjects(Rectangle RECTANGLE) : base(RECTANGLE)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
