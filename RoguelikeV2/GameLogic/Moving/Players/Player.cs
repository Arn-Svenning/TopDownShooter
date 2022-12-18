﻿#region Using...
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Stationary;
using RoguelikeV2.GameLogic.Stationary.Weapons;
using RoguelikeV2.Managers;
using RoguelikeV2.ParticleEngine;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Players
{
    internal class Player : MovingObjects
    {
        bool isMoving;
        ParticleSystem dustParticle;
        PlayerWeapon playerWeapon;
        public Player(Rectangle RECTANGLE) : base(RECTANGLE)
        {
            texture = AssetManager.right;
            speed = 250f;

            dustParticle = new ParticleSystem(AssetManager.circleParticle, position, Color.BurlyWood, 3, 15);

            
        }
        public void Update(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player)
        {
            //gun
            HoldGun();
            playerWeapon.Update(gameTime, left, right, down, up);

            size = new Rectangle((int)position.X, (int)position.Y, texture.Width / 3, texture.Height);
            PlayerMovement(gameTime, up, down, right, left, player);
            

            if (isMoving)
            {
                dustParticle.EmitterLocation = new Vector2(position.X + 30, position.Y + size.Height - 10);
                dustParticle.UpdateParticle(0.3f);
            }
            else
                dustParticle.DeleteParticle();

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            dustParticle.DrawParticle(spriteBatch);
            spriteBatch.Draw(texture, size, sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);
            playerWeapon.Draw(spriteBatch);
        }
        #region Player Movement
        public void PlayerMovement(GameTime gameTime, Keys up, Keys down, Keys right, Keys left, int player)
        {
            position += speed * direction * (float)gameTime.ElapsedGameTime.TotalSeconds;

            float frameSpeed = 600f;

            if (InputManager.HoldKey(left))
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.left, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.leftBlue, 100f);

                direction.X = -1;
                direction.Normalize();

            }
            else if (InputManager.HoldKey(right))
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.right, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.rightBlue, 100f);

                direction.X = 1;
                direction.Normalize();

            }
            else
            {
                isMoving = false;
                direction.X = 0;
            }

            if (InputManager.HoldKey(up))
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.up, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upBlue, 100f);

                direction.Y = -1;
                direction.Normalize();

            }
            else if (InputManager.HoldKey(down))
            {
                isMoving = true;
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.down, 100f);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downBlue, 100f);

                direction.Y = 1;
                direction.Normalize();
            }
            else
            {
                direction.Y = 0;
            }

            if (InputManager.HoldKey(left) && InputManager.HoldKey(up))
            {
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upLeft, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upLeftBlue, frameSpeed);
            }


            if (InputManager.HoldKey(right) && InputManager.HoldKey(up))
            {
                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upRight, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.upRightBlue, frameSpeed);
            }


            if (InputManager.HoldKey(right) && InputManager.HoldKey(down))
            {

                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downRight, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downRightBlue, frameSpeed);
            }


            if (InputManager.HoldKey(left) && InputManager.HoldKey(down))
            {

                if (player == 1)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downLeft, frameSpeed);

                else if (player == 2)
                    PlayAnimation(gameTime, 3, texture = AssetManager.downLeftBlue, frameSpeed);
            }

        }
        #endregion
        private void HoldGun()
        {
            //regular gun
            playerWeapon = new PlayerWeapon(new Rectangle((int)position.X + 35, (int)position.Y + 30, 64, 64), new Vector2(texture.Width / 2, texture.Height / 2));

            //sniper
            //playerWeapon = new PlayerWeapon(new Rectangle((int)position.X + 35, (int)position.Y + 30, 128, 128), new Vector2(texture.Width - 30, texture.Height));
        }
    }
}