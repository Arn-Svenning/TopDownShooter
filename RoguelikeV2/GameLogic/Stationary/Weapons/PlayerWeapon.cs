#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
#endregion


namespace RoguelikeV2.GameLogic.Stationary.Weapons
{
    internal class PlayerWeapon : Weapon
    {
        private SpriteEffects effect;


        private readonly float normalGunShootTimer;
        private readonly float sniperShootTimer;
        private readonly float RPGTimer;
        private float timeLeft;
        public PlayerWeapon(Rectangle RECTANGLE, Vector2 ORIGIN, Texture2D TEXTURE) : base(RECTANGLE)
        {        
            texture = TEXTURE;
            origin = ORIGIN;
            timeLeft = 0f;

            
            normalGunShootTimer = 0.25f;           
            sniperShootTimer = 1f;
            RPGTimer = 1.5f;
        }
        public void Update(GameTime gameTime, Keys left, Keys right, Keys down, Keys up, Keys shoot, int player, GamePadState state)
        {           
            RotateGun(gameTime, left, right, down, up, state);
            if (timeLeft > 0) timeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(player == 1)
            {               
                if (InputManager.PressOnce(shoot) || InputManager.ControllerPressedOnce(Buttons.RightTrigger))
                {
                    Shoot(1);
                }
            }
            else if(player == 2)
            {
                if (InputManager.PressOnce(shoot) || InputManager.ControllerPressedOnce2(Buttons.RightTrigger))
                {
                    Shoot(2);
                }
            }
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, size, null, Color.White, rotation, origin, effect, 1);
           
        }       
        private void RotateGun(GameTime gameTime, Keys left, Keys right, Keys down, Keys up, GamePadState state)
        {
            if (InputManager.HoldKey(left) || state.ThumbSticks.Right.X < -0.5f)
            {
                rotation = MathHelper.ToRadians(0);
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            if (InputManager.HoldKey(right) || state.ThumbSticks.Right.X > +0.5f)
            {
                rotation = MathHelper.ToRadians(180);
                effect = SpriteEffects.FlipHorizontally;
            }
            if (InputManager.HoldKey(up) || state.ThumbSticks.Right.Y > +0.5f)
            {
                rotation = MathHelper.ToRadians(90);
                effect = SpriteEffects.FlipHorizontally;
            }
            if (InputManager.HoldKey(down) || state.ThumbSticks.Right.Y < -0.5f)
            {
                rotation = MathHelper.ToRadians(-90);
                effect = SpriteEffects.FlipHorizontally;
            }
            if (InputManager.HoldKey(left) && InputManager.HoldKey(up) || state.ThumbSticks.Right.X < -0.5f && state.ThumbSticks.Right.Y > +0.5f)
            {
                rotation = MathHelper.ToRadians(45);
            }
            if (InputManager.HoldKey(left) && InputManager.HoldKey(down) || state.ThumbSticks.Right.X < -0.5f && state.ThumbSticks.Right.Y < -0.5f)
            {
                rotation = MathHelper.ToRadians(-45);
            }
            if (InputManager.HoldKey(right) && InputManager.HoldKey(up) || state.ThumbSticks.Right.X > +0.5f && state.ThumbSticks.Right.Y > +0.5f)
            {
                rotation = MathHelper.ToRadians(145);
            }
            if (InputManager.HoldKey(right) && InputManager.HoldKey(down) || state.ThumbSticks.Right.X > +0.5f && state.ThumbSticks.Right.Y < -0.5f)
            {
                rotation = MathHelper.ToRadians(-145);
            }


        }
        public override void Shoot(int player)
        {
            if (timeLeft > 0) return;
            {
                if (texture == AssetManager.normalGun)
                {
                    timeLeft = normalGunShootTimer;
                    base.Shoot(player);
                }
                else if (texture == AssetManager.sniper)
                {

                    timeLeft = sniperShootTimer;
                    AmmoRestrictedShot(player, 1000, SniperAmmo);

                }
                else if(texture == AssetManager.RPG)
                {
                    timeLeft = RPGTimer;
                    AmmoRestrictedShot(player, 700, RPGAmmo);
                    
                }
            }
                        
        }    
        

    }
}
