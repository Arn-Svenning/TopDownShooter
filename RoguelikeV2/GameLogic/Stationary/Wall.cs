#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.GameLogic.Stationary
{
    internal class Wall : StationaryObjects
    {

        public Wall(Rectangle RECTANGLE, Texture2D tex) : base (RECTANGLE)
        {
            texture = tex;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Size, Color.White);
        }
    }
}
