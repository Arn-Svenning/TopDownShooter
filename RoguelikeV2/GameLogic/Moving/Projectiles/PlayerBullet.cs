#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.GameLogic.Stationary.Weapons;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using RoguelikeV2.ParticleEngine;
using SharpDX.DirectWrite;
using SharpDX.MediaFoundation;
using System;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Projectiles
{
    internal class PlayerBullet : ProjectileObjects
    {
        SpriteEffects effect = SpriteEffects.None;
        
        public PlayerBullet(Rectangle RECTANGLE,ProjectileData DATA, int player) : base(RECTANGLE, DATA)
        {
            
            if (player == 1)
                texture = AssetManager.regularBulletRed;
            if(player == 2)
                texture = AssetManager.regularBulletBlue;            
            speed = DATA.Speed;
            rotation = DATA.Rotation;
            direction = new((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            LifeSpan = DATA.LifeSpan;

           
        }
        public void Update(GameTime gameTime, int player)
        {
            size = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            position += -direction * (int)speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            LifeSpan -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (LifeSpan <= 0 && texture == AssetManager.RPGBullet)
            {
                RPGExplosionParticles.endPos = position;
                RPGExplosionParticles.explosion = true;
                AssetManager.RPGExplosion.Play(volume: 0.6f, pitch: 0.1f, pan: 0.0f);
            }
            if (player == 1)
            {
                foreach (Player player1 in MapManager.player1)
                {
                    if (player1.PlayerWeapon.texture == AssetManager.sniper)
                    {
                        texture = AssetManager.sniperShot;
                        size.Height = 55;
                        size.Width = 64;
                        Damage = 3;
                    }
                    else if(player1.PlayerWeapon.texture == AssetManager.RPG)
                    {
                        texture = AssetManager.RPGBullet;
                        effect = SpriteEffects.FlipHorizontally;
                        size.Height = 55;
                        size.Width = 64;
                        Damage = 5;
                       
                    }
                }
            }
            else if(player == 2)
            {
                foreach (Player player2 in MapManager.player2)
                {
                    if (player2.PlayerWeapon.texture == AssetManager.sniper)
                    {
                        texture = AssetManager.sniperShot;
                        size.Height = 55;
                        size.Width = 64;
                        Damage = 3;
                    }
                    else if(player2.PlayerWeapon.texture == AssetManager.RPG)
                    {
                        texture = AssetManager.RPGBullet;
                        effect = SpriteEffects.FlipHorizontally;
                        size.Height = 55;
                        size.Width = 64;
                        Damage = 5;
                    }
                }
            }

            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {          

            spriteBatch.Draw(texture, size, null, Color.White, rotation, Vector2.Zero, effect, 1);
            
        }        
        public void DestroyBullet()
        {            
            LifeSpan = 0;
            if(texture == AssetManager.RPGBullet)
            {
                AssetManager.RPGExplosion.Play(volume: 0.6f, pitch: 0.1f, pan: 0.0f);
            }
        }

    }
}
