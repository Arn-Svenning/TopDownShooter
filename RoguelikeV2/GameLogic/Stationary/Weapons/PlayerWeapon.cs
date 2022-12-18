#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System;
#endregion


namespace RoguelikeV2.GameLogic.Stationary.Weapons
{
    internal class PlayerWeapon : Weapon
    {
        SpriteEffects effect;
       
        public PlayerWeapon(Rectangle RECTANGLE, Vector2 ORIGIN) : base(RECTANGLE)
        {
            texture = AssetManager.normalGun;
            origin = ORIGIN;
        }
        public void Update(GameTime gameTime, Keys left, Keys right, Keys down, Keys up)
        {
            RotateGun(gameTime, left, right, down, up);
           
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, null, Color.White, rotation, origin, effect, 1);
        }
        private void RotateGun(GameTime gameTime, Keys left, Keys right, Keys down, Keys up)
        {
            if(InputManager.HoldKey(left))
            {
                rotation = MathHelper.ToRadians(0);
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            if(InputManager.HoldKey(right))
            {
                rotation = MathHelper.ToRadians(180);
                effect = SpriteEffects.FlipHorizontally;                                
            }
            if(InputManager.HoldKey(up))
            {
                rotation = MathHelper.ToRadians(90);
                effect=SpriteEffects.FlipHorizontally;
            }
            if(InputManager.HoldKey(down))
            {
                rotation = MathHelper.ToRadians(-90);
                effect = SpriteEffects.FlipHorizontally;
            }
            if(InputManager.HoldKey(left) && InputManager.HoldKey(up))
            {
                rotation = MathHelper.ToRadians(45);
            }
            if(InputManager.HoldKey(left) && InputManager.HoldKey(down))
            {
                rotation = MathHelper.ToRadians(-45);
            }
            if(InputManager.HoldKey(right) && InputManager.HoldKey(up))
            {
                rotation = MathHelper.ToRadians(145);
            }
            if(InputManager.HoldKey(right) && InputManager.HoldKey(down))
            {
                rotation = MathHelper.ToRadians(-145);
            }        
            

        }
    }
}
