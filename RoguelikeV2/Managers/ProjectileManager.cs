using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeV2.Managers
{
    internal class ProjectileManager
    {
        public static List<PlayerBullet> PlayerBullets { get; } = new List<PlayerBullet>();


        public static void AddProjectile(ProjectileData projectile, int player)
        {
            PlayerBullets.Add(new(new Rectangle((int)projectile.Position.X, (int)projectile.Position.Y, AssetManager.circleParticle.Width, AssetManager.circleParticle.Height),projectile, player));
        }
        public static void Update(GameTime gameTime)
        {
            foreach(PlayerBullet bullet in PlayerBullets)
            {
                bullet.Update(gameTime);
                
            }
            PlayerBullets.RemoveAll((p) => p.LifeSpan <= 0);
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach(PlayerBullet bullet in PlayerBullets)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }
}
