using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RoguelikeV2.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeV2.GameLogic.Moving.Projectiles
{
    internal class TurretProjectile : ProjectileObjects
    {
        public TurretProjectile(Rectangle RECTANGLE, ProjectileData DATA) : base(RECTANGLE, DATA)
        {
            texture = AssetManager.turretBullet;
            speed = DATA.Speed;
            rotation = DATA.Rotation;
            direction = new((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            LifeSpan = DATA.LifeSpan;
        }
        public void Update(GameTime gameTime)
        {
            size = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            LifeSpan -= (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, null, Color.White, rotation, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
