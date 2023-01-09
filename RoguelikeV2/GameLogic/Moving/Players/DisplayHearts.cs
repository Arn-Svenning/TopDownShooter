#region Using...
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Moving.Enemies;
using RoguelikeV2.GameLogic.Moving.Projectiles;
using RoguelikeV2.GameLogic.Stationary;
using RoguelikeV2.GameLogic.Stationary.Tiles;
using RoguelikeV2.GameLogic.Stationary.Weapons;
using RoguelikeV2.Managers;
using RoguelikeV2.ParticleEngine;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace RoguelikeV2.GameLogic.Moving.Players
{   
    internal class DisplayHearts : MovingObjects
    {
        private Vector2 hpPos;

        private List<Player> players;
        private Color color;
        public DisplayHearts(Rectangle RECTANGLE, Color COLOR) : base(RECTANGLE)
        {
            color = COLOR;
            players = new List<Player>();
            texture = AssetManager.hearts;
        }
        public void Update(GameTime gameTime, List<Player> player)
        {
            players = player;
            foreach(Player p in player)
            {
                
                UpdateHP(p.Position, gameTime);
            }
          
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            DisplayHp(spriteBatch);
        }
        private void DisplayHp(SpriteBatch spriteBatch)
        {
            foreach (Player player in players)
            {
                for (int i = 0; i < player.healhPoints; i++)
                {                    
                    spriteBatch.Draw(texture, new Vector2(hpPos.X - 25 * i, hpPos.Y + 40),sourceRectangle, 
                        color, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 1);
                }
            }

        }
        private void UpdateHP(Vector2 pos, GameTime gameTime)
        {
            PlayAnimation(gameTime, 8, texture, 200f);
            hpPos = new Vector2(pos.X + 64, pos.Y + 64);
        }
    }
}
