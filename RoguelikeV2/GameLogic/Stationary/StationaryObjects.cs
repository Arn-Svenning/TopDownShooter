#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace RoguelikeV2.GameLogic.Stationary
{
    abstract class StationaryObjects : GameObjects
    {      
        public StationaryObjects(Rectangle RECTANGLE) : base(RECTANGLE)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
