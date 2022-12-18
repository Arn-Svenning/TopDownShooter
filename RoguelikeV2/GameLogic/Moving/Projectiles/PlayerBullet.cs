#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Projectiles
{
    internal class PlayerBullet : MovingObjects
    {
        private float lifeSpan = 0f;
        private bool isRemoved;

        public PlayerBullet(Rectangle RECTANGLE) : base(RECTANGLE)
        {

        }
    }
}
