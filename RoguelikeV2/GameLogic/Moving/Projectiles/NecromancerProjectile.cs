#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Projectiles
{
    internal class NecromancerProjectile : ProjectileObjects
    {
        
        public NecromancerProjectile(Rectangle RECTANGLE, ProjectileData DATA) : base(RECTANGLE, DATA)
        {
            texture = AssetManager.regularBulletRed;
            speed = DATA.Speed;
            rotation = DATA.Rotation;
            direction = new((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            LifeSpan = DATA.LifeSpan;
        }
        public void Update(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            LifeSpan -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, rotation, Vector2.Zero, 1, SpriteEffects.None, 1);
        }
    }
}
