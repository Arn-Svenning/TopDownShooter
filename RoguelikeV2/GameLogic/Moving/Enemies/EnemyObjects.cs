#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Enemies
{
    abstract class EnemyObjects : MovingObjects
    {
        protected int healthPoints;
        public EnemyObjects(Rectangle RECTANGLE) : base(RECTANGLE)
        {

        }
        public abstract void Update(GameTime gameTime);
       
    }
}
