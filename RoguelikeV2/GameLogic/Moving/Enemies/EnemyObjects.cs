#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using RoguelikeV2.ParticleEngine;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Enemies
{
    abstract class EnemyObjects : MovingObjects
    {
        protected int healthPoints;
        public int HealthPoints { get { return healthPoints; } }

        protected Rectangle rect;
        public Rectangle Rect { get { return rect; } }

        private ParticleSystem bloodParticle;
        protected ParticleSystem deadEnemyBlood;
        public ParticleSystem DeadEnemyBlood { get { return deadEnemyBlood; } }
        
        public bool IsHit { get; set; } = false;
        public float hitTimer = 60 * 0.1f;

        protected Color color = Color.White;
       
        public EnemyObjects(Rectangle RECTANGLE, int HP) : base(RECTANGLE)
        {
            healthPoints = HP;
            bloodParticle = new ParticleSystem(AssetManager.circleParticle, position, Color.DarkRed, 10, 20);        
            deadEnemyBlood = new ParticleSystem(AssetManager.circleParticle, position, Color.DarkRed, 10, 20);            
        }
        public abstract void Update(GameTime gameTime);

        public void TakeDamage(int dmg)
        {
            healthPoints -= dmg;
            IsHit = true;
        }
        #region Alive Particles
        public void UpdateAliveBloodParticles(int randomSize1, int randomSize2, Vector2 location)
        {
            if (IsHit)
            {
                color = Color.Red;
                hitTimer--;
                if (hitTimer > 0)
                {
                    bloodParticle.EmitterLocation = new Vector2(location.X, location.Y);
                    bloodParticle.UpdateBigParticle(randomSize1, randomSize2);                   
                }
                if (hitTimer <= 0)
                {
                    IsHit = false;
                    color = Color.White;
                    hitTimer = 60 * 0.1f;
                }
            }
            else if (!IsHit && healthPoints > 0)
            {
                bloodParticle.DeleteParticle();
            }
        }        
        public void DrawAliveBloodParticles(SpriteBatch spriteBatch) => bloodParticle.DrawParticle(spriteBatch);      
        #endregion

        #region Dead Particles
        public void UpdateDeadBloodParticles(int randomSize1, int randomSize2, Vector2 location)
        {
            deadEnemyBlood.EmitterLocation = new Vector2(location.X, location.Y);
            deadEnemyBlood.UpdateBigParticle(randomSize1, randomSize2);
        }
        public void DrawDeadBloodParticles(SpriteBatch spriteBatch)
        {
            if (healthPoints <= 0)
            {
                deadEnemyBlood.DrawParticle(spriteBatch);                
            }
        }
        #endregion

    }
}
