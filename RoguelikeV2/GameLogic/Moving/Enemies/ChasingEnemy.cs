#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Enemies
{
    internal class ChasingEnemy : EnemyObjects
    {
        public Player Target { get; set; }
        SpriteEffects effect;

        public ChasingEnemy(Rectangle RECTANGLE) : base(RECTANGLE)
        {
            texture = AssetManager.chasingEnemy;
            healthPoints = 3;
            speed = 100;
        }
        public override void Update(GameTime gameTime)
        {
            size = new Rectangle((int)position.X, (int)position.Y, texture.Width / 4, texture.Height);
            ChasePlayers(gameTime);
            PlayAnimation(gameTime, 8, texture, 100f);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, sourceRectangle, Color.White, rotation, Vector2.Zero, effect, 1f);

        }
        public void ChasePlayers(GameTime gameTime)
        {
            float closestDistance = float.MaxValue;
            Vector2 closestPlayerPosition = Vector2.Zero;

            float distanceToPlayer1;
            float distanceToPlayer2;

            // Calculate the distances between the enemy and both players
            foreach (Player p in MapManager.player1)
            {
                distanceToPlayer1 = (float)Math.Sqrt(Math.Pow(p.Position.X - position.X, 2) + Math.Pow(p.Position.Y - position.Y, 2));
                if (distanceToPlayer1 < closestDistance)
                {
                    closestDistance = distanceToPlayer1;
                    closestPlayerPosition = p.Position;
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

    }
}

