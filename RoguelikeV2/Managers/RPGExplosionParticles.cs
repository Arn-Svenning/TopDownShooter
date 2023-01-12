#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.ParticleEngine;
using Color = Microsoft.Xna.Framework.Color;
#endregion

namespace RoguelikeV2.Managers
{
    internal class RPGExplosionParticles
    {
        public static float timer;
        public static bool explosion;
        public static Vector2 endPos = new Vector2(9000, 9000);
        public static ParticleSystem particle;

        public static void LoadExplosionParticles()
        {
            particle = new ParticleSystem(AssetManager.circleParticle, Color.OrangeRed, 10, 40);
            timer = 60 * 1;
            explosion = false;
        }
        public static void Update()
        {

            particle.UpdateBigParticle(5, 10);
            particle.EmitterLocation = endPos;
            if (explosion)
            {                
                timer--;               
            }
            if (timer <= 0)
            {
                
                timer = 60 * 1;
                explosion = false;
                endPos = new Vector2(9000, 9000);

            }               
            foreach (EnemyObjects enemy in MapManager.enemies)
            {
                if (particle.Rect.Intersects(enemy.Size))
                {
                    
                    enemy.TakeDamage(5);                   
                }

            }
            MapManager.enemies.RemoveAll((enemy) => enemy.HealthPoints <= 0);

        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (explosion)
            {
                particle.DrawParticle(spriteBatch);
            }
        }
    }
}
