#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
#endregion
namespace RoguelikeV2.GameLogic.Moving.Enemies
{
    internal class Necromancer : EnemyObjects
    {
        private const int shootRange = 500;
        private float direction;
        SpriteEffects effect;
        private float shootTimer; 
        
        public Necromancer(Rectangle RECTANGLE, int HP) : base(RECTANGLE, HP)
        {
            texture = AssetManager.necromancer;            
            shootTimer = 60 * 3;
        }
        public override void Update(GameTime gameTime)
        {
            size = new Rectangle((int)position.X, (int)position.Y, texture.Width / 3, texture.Height + 10);

            rect = new Rectangle((int)position.X + 60, (int)position.Y, 64, 64);
            if (effect == SpriteEffects.None)
                rect.X = (int)position.X + 40;
            UpdateAliveBloodParticles(1, 2, new Vector2(position.X + 100, position.Y + 50));
            ChasePlayers(gameTime);
            PlayAnimation(gameTime, 8, texture, 100f);

            UpdateDeadBloodParticles(1,3, new Vector2(position.X + 100, position.Y + 50));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawAliveBloodParticles(spriteBatch);
            if(healthPoints > 0)
            spriteBatch.Draw(texture, size, sourceRectangle, color, 0, Vector2.Zero, effect, 1);
            //spriteBatch.Draw(texture, rect, Color.Red);
            DrawDeadBloodParticles(spriteBatch);
        }
        public void ChasePlayers(GameTime gameTime)
        {
            float closestDistance = float.MaxValue;
            Vector2 closestPlayerPosition = Vector2.Zero;

            float distanceToPlayer1;
            float distanceToPlayer2;

            // Calculate the distances between the enemy and both players
            if(Globals.currentGameState == Globals.GameState.inGame2Player)
            {
                foreach (Player p in MapManager.player1)
                {
                    distanceToPlayer1 = (float)Math.Sqrt(Math.Pow(p.Position.X - position.X, 2) + Math.Pow(p.Position.Y - position.Y, 2));
                    if (distanceToPlayer1 < closestDistance)
                    {
                        closestDistance = distanceToPlayer1;
                        closestPlayerPosition = p.Position;
                    }
                    if (distanceToPlayer1 > shootRange)
                        speed = 50;
                    else if (distanceToPlayer1 <= shootRange)
                    {
                        speed = 0;
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
                    if (distanceToPlayer2 > shootRange)
                        speed = 50;
                    else if (distanceToPlayer2 <= shootRange)
                    {
                        speed = 0;

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
                    if (distanceToPlayer1 > shootRange)
                        speed = 50;
                    else if (distanceToPlayer1 <= shootRange)
                    {
                        speed = 0;
                        ShootAtPlayer();
                    }

                }
            }
            

            // Calculate the direction from the enemy to the closer player
            direction = (float)Math.Atan2(closestPlayerPosition.Y - position.Y, closestPlayerPosition.X - position.X);


            // Update the enemy's position based on the direction and speed
            position.X += (float)Math.Cos(direction) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += (float)Math.Sin(direction) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if ((float)Math.Cos(direction) * speed < 0)
                effect = SpriteEffects.FlipHorizontally;

            if ((float)Math.Cos(direction) * speed > 0)
                effect = SpriteEffects.None;

        }
        private void ShootAtPlayer()
        {
            shootTimer--;
            if(shootTimer <= 0)
            {
                ProjectileData pd = new()
                {
                    Position = position + new Vector2(70,20),
                    Rotation = direction,
                    LifeSpan = 3,
                    Speed = 300
                };
                ProjectileManager.AddNecroMancerProjectile(pd);
                AssetManager.necroAttackSound.Play(volume: 0.1f, pitch: 0.1f, pan: 0.0f);
                shootTimer = 60 * 3;
            }
            
        }
    }
}
