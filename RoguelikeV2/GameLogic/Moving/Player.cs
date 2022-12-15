#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Managers;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Moving
{
    internal class Player : MovingObjects
    {


        public Player(Rectangle RECTANGLE) : base(RECTANGLE)
        {
            texture = AssetManager.right;
            speed = 250f;
        }
        public void Update(GameTime gameTime)
        {
            size = new Rectangle((int)position.X, (int)position.Y, texture.Width / 3, texture.Height);
            PlayerMovement(gameTime);
            
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);
        }
        public void PlayerMovement(GameTime gameTime)
        {
            position += speed * direction * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (InputManager.HoldKey(Keys.A))
            {
                PlayAnimation(gameTime, 3, texture = AssetManager.left, 100f);
                direction.X = -1;
                direction.Normalize();
            }
            else if (InputManager.HoldKey(Keys.D))
            {
                PlayAnimation(gameTime, 3, texture = AssetManager.right, 100f);
                direction.X = 1;
                direction.Normalize();
            }
            else
            {
                direction.X = 0;
            }

            if (InputManager.HoldKey(Keys.W))
            {
                PlayAnimation(gameTime, 3, texture = AssetManager.up, 100f);
                direction.Y = -1;
                direction.Normalize();
            }
            else if (InputManager.HoldKey(Keys.S))
            {
                PlayAnimation(gameTime, 3, texture = AssetManager.down, 100f);
                direction.Y = 1;
                direction.Normalize();
            }
            else
            {
                direction.Y = 0;
            }

            if (InputManager.HoldKey(Keys.A) && InputManager.HoldKey(Keys.W))
                texture = AssetManager.upLeft;

            if (InputManager.HoldKey(Keys.D) && InputManager.HoldKey(Keys.W))
                texture = AssetManager.upRight;

            if (InputManager.HoldKey(Keys.D) && InputManager.HoldKey(Keys.S))
                texture = AssetManager.downRight;

            if (InputManager.HoldKey(Keys.A) && InputManager.HoldKey(Keys.S))
                texture = AssetManager.downLeft;
        }
    }
}
