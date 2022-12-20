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
    internal class ProjectileData
    {
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float LifeSpan { get; set; }
        public int Speed { get; set; }  
    }
}
