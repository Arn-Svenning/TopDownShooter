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
using RoguelikeV2.ParticleEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Enemies
{
    internal class ChasingEnemy : EnemyObjects
    {
        public Player Target { get; set; }
        SpriteEffects effect;

        private const int attackRange = 100;
        public ChasingEnemy(Rectangle RECTANGLE, int HP) : base(RECTANGLE, HP)
        {
            texture = AssetManager.chasingEnemy;
            speed = 100;

        }
        public override void Update(GameTime gameTime)
        {
            size = new Rectangle((int)position.X, (int)position.Y, texture.Width / 8, texture.Height);

            rect = new Rectangle((int)position.X, (int)position.Y, 70,70);
            if (effect == SpriteEffects.None)
                rect.X = (int)position.X;
            UpdateAliveBloodParticles(1, 2, new Vector2(position.X, position.Y + 30));
            ChasePlayers(gameTime);
            
           
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {           
            DrawAliveBloodParticles(spriteBatch);
            if (healthPoints > 0)
            spriteBatch.Draw(texture, size, sourceRectangle, color, rotation, Vector2.Zero, effect, 1f);           
            //spriteBatch.Draw(texture, rect, Color.Red);           
        }
        public void ChasePlayers(GameTime gameTime)
        {
            float closestDistance = float.MaxValue;
            Vector2 closestPlayerPosition = Vector2.Zero;

            float distanceToPlayer1;
            float distanceToPlayer2;
           
            if (Globals.currentGameState == Globals.GameState.inGame2Player)
            {
                // Calculate the distances between the enemy and both players
                foreach (Player p in MapManager.player1)
                {
                    distanceToPlayer1 = (float)Math.Sqrt(Math.Pow(p.Position.X - position.X, 2) + Math.Pow(p.Position.Y - position.Y, 2));
                    if (distanceToPlayer1 < closestDistance)
                    {
                        closestDistance = distanceToPlayer1;
                        closestPlayerPosition = p.Position;
                        SwitchAnimation(gameTime, distanceToPlayer1);
                    }                   

                }

                foreach (Player p in MapManager.player2)
                {

                    distanceToPlayer2 = (float)Math.Sqrt(Math.Pow(p.Position.X - position.X, 2) + Math.Pow(p.Position.Y - position.Y, 2));
                    if (distanceToPlayer2 < closestDistance)
                    {
                        closestDistance = distanceToPlayer2;
                        closestPlayerPosition = p.Position;
                        SwitchAnimation(gameTime, distanceToPlayer2);
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
                        SwitchAnimation(gameTime, distanceToPlayer1);
                    }
                    
                }
            }
            

            // Calculate the direction from the enemy to the closer player
            float direction = (float)Math.Atan2(closestPlayerPosition.Y - position.Y, closestPlayerPosition.X - position.X);
            

            // Update the enemy's position based on the direction and speed
            position.X += (float)Math.Cos(direction) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += (float)Math.Sin(direction) * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if ((float)Math.Cos(direction) * speed < 0)
                effect = SpriteEffects.FlipHorizontally;

            if ((float)Math.Cos(direction) * speed > 0)
                effect = SpriteEffects.None;

        }
        public void SwitchAnimation(GameTime gameTime, float distanceToPlayer)
        {
            if (distanceToPlayer > attackRange)
            {
                texture = AssetManager.chasingEnemy;
                PlayAnimation(gameTime, 8, texture, 200f);
            }

            else if (distanceToPlayer <= attackRange)
            {
                texture = AssetManager.chaserAttack;
                size.Width = texture.Width / 9;
                PlayAnimation(gameTime, 9, texture, 100f);
            }
        }

    }
}

