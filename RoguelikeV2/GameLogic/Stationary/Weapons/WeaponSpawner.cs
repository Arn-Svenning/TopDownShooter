using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeV2.Managers;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeV2.GameLogic.Stationary.Weapons
{
    internal class WeaponSpawner
    {
        private PlayerWeapon wep;             
        public static List<PlayerWeapon> weapons = new List<PlayerWeapon>();
        Rectangle spawnedWeponRect;        
        
        int posX;
        int posY;

        private static float weaponTimer = 60 * 15;
        public WeaponSpawner()
        {            
            wep = new PlayerWeapon(new Rectangle(posX, posY, AssetManager.normalGun.Width, AssetManager.normalGun.Height),
                Vector2.Zero, AssetManager.normalGun);
        }
        public void Update()
        {
            weaponTimer--;
            if(weaponTimer <= 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    int RPGtex = 1;
                    int sniperTex = 2;
                    

                    int randomWeapon = Globals.random.Next(RPGtex,sniperTex + 1);                    
                    if (randomWeapon == RPGtex)
                    {
                        wep.texture = AssetManager.RPG;
                    }   
                    else if(randomWeapon == sniperTex)
                    {
                        wep.texture = AssetManager.sniper;
                    }
                    //gunTex = AssetManager.normalGun;
                    posX = Globals.random.Next(0, Globals.screenWidth - AssetManager.sniper.Width);
                    posY = Globals.random.Next(0, Globals.screenHeight - AssetManager.sniper.Height);

                    spawnedWeponRect = new Rectangle(posX, posY, wep.texture.Width, wep.texture.Height);
                    weapons.Add(new(spawnedWeponRect, Vector2.Zero, wep.texture));
                    weaponTimer = 60 * 15;
                }
            }
           
        }
        public void DrawWep(SpriteBatch spriteBatch)
        {
            foreach(var weapon in weapons)
            {
                weapon.Draw(spriteBatch);
            }
        }
       
    }
}
