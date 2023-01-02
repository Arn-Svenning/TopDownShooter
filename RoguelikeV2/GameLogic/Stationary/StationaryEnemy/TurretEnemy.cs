#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Stationary.StationaryEnemy
{
    internal class TurretEnemy : EnemyObjects
    {
        private const int shootRange = 1000;
        private SpriteEffects effect;
        private float dir;
        private float shootTimer;
        public TurretEnemy(Rectangle RECTANGLE, int HP) : base(RECTANGLE,HP)
        {
            texture = AssetManager.turret;
            shootTimer = 60 * 1;           
        }
        public override void Update(GameTime gameTime)
        {
            rect = new Rectangle((int)position.X , (int)position.Y, 64, 64);

            UpdateAliveBloodParticles(1, 2, new Vector2(position.X + 30, position.Y + 20));
            TargetPlayers(gameTime);
            PlayAnimation(gameTime, 3, texture, 200f);
            UpdateDeadBloodParticles(1, 3, new Vector2(position.X + 30, position.Y + 20));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawAliveBloodParticles(spriteBatch);
            if(healthPoints > 0)
            spriteBatch.Draw(texture, size, sourceRectangle, color, 0f, Vector2.Zero, effect, 1f);
            //spriteBatch.Draw(texture, rect, Color.Red);

            DrawDeadBloodParticles(spriteBatch);
        }
        public void TargetPlayers(GameTime gameTime)
        {
            float closestDistance = float.MaxValue;
            Vector2 closestPlayerPosition = Vector2.Zero;

            float distanceToPlayer1;
            float distanceToPlayer2;

            if(Globals.currentGameState == Globals.GameState.inGame2Player)
            {
                // Calculate the distances between the enemy and both players
                foreach (Player p in MapManager.player1)
                {
                    distanceToPlayer1 = (float)Math.Sqrt(Math.Pow(p.Position.X - position.X, 2) + Math.Pow(p.Position.Y - position.Y, 2));
                    if (distanceToPlayer1 < closestDistance)
                    {
                        closestDistance = distanceToPlayer1;
                        closestPlayerPosition = p.Position;
                    }
                    if (distanceToPlayer1 <= shootRange)
                    {
                        ShootAtPlayer();
                    }

                }

                foreach (Player p in MapManager.player2)
                {

                    distanceToPlayer2 = (float)Math.Sqrt(Math.Pow(p.Position.X - position.X, 2) + Math.Pow(p.Position.Y - position.Y, 2));
                    if (distanceToPlayer2 < closestDistance)
                    {
                        closestDistance = distanceToPlayer2;
                        closestPlayerPosition = p.Position;
                    }
                    if (distanceToPlayer2 <= shootRange)
                    {
                        ShootAtPlayer();
                    }


                }
            }
            else
            {
                foreach (Player p in MapManager.player1)
                {
                    distanceToPlayer1 = (float)Math.Sqrt(Math.Pow(p.Position.X - position.X, 2) + Math.Pow(p.Position.Y - position.Y, 2));
                    if (distanceToPlayer1 < closestDistance)
                    {
                        closestDistance = distanceToPlayer1;
                        closestPlayerPosition = p.Position;
                    }
                    if (distanceToPlayer1 <= shootRange)
                    {
                        ShootAtPlayer();
                    }

                }
            }
            

            // Calculate the direction from the enemy to the closer player
            dir = (float)Math.Atan2(closestPlayerPosition.Y - position.Y, closestPlayerPosition.X - position.X);


            // Update the enemy's position based on the direction and speed
            position.X += (float)Math.Cos(dir) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += (float)Math.Sin(dir) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if ((float)Math.Cos(dir) * speed < 0)
                effect = SpriteEffects.FlipHorizontally;

            if ((float)Math.Cos(dir) * speed > 0)
                effect = SpriteEffects.None;

        }
        private void ShootAtPlayer()
        {
            shootTimer--;
            if (shootTimer <= 0)
            {
                ProjectileData pd = new()
                {
                    Position = position + new Vector2(40, 30),
                    Rotation = dir,
                    LifeSpan = 3,
                    Speed = 300
                };
                ProjectileManager.AddTurretProjectile(pd);
                shootTimer = 60 * 1;
            }

        }
    }
}
