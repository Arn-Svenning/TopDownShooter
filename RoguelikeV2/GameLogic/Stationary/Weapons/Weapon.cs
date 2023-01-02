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
using System.Diagnostics;
#endregion

namespace RoguelikeV2.GameLogic.Stationary.Weapons
{
    abstract class Weapon : StationaryObjects
    {
        public Vector2 origin { get; set; }       

        public int SniperAmmo { get; private set; }
        public int RPGAmmo { get; private set; }
        private readonly int sniperMaxAmmo;
        private readonly int RPGMaxAmmo;
       

        public Weapon(Rectangle RECTANGLE) : base(RECTANGLE)
        {
            sniperMaxAmmo = 5;
            SniperAmmo = sniperMaxAmmo;

            RPGMaxAmmo = 4;
            RPGAmmo = RPGMaxAmmo;
        }       
        public virtual void Shoot(int player)
        {
            
            ProjectileData pdN = new()
            {
                Position = new Vector2(Size.X, size.Y),
                Rotation = rotation,
                LifeSpan = 2,
                Speed = 600
            };
            if(player == 1)
            ProjectileManager.AddPlayer1Projectile(pdN, player);  
            
            else if(player == 2)
                ProjectileManager.AddPlayer2Projectile(pdN, player);
        }
        public virtual void AmmoRestrictedShot(int player, int speed, int ammo)
        {
           
            if(ammo > 0)
            {
                ProjectileData pdN = new()
                {
                    Position = new Vector2(Size.X, size.Y),
                    Rotation = rotation,
                    LifeSpan = 2,
                    Speed = speed
                };
                if (player == 1)
                    ProjectileManager.AddPlayer1Projectile(pdN, player);

                else if (player == 2)
                    ProjectileManager.AddPlayer2Projectile(pdN, player);
                SniperAmmo--;
                RPGAmmo--;                
            }
                     
        }       
        public void DrawBulletsLeft(SpriteBatch spriteBatch, Texture2D bulletTex, Vector2 pos, int weaponType)
        {
            Vector2 textPos = pos + new Vector2(-30, 64);            
            if (weaponType == 2)                
            {
                spriteBatch.DrawString(AssetManager.minecraftFont, "Sniper: " + SniperAmmo, textPos, Color.White);
            }
            else if(weaponType == 1)
            {
                spriteBatch.DrawString(AssetManager.minecraftFont, "RPG: " + RPGAmmo, textPos, Color.White);
            }
        }
    }
}
