using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeV2.GameLogic.Stationary.StationaryEnemy;
using RoguelikeV2.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace RoguelikeV2.GameLogic.Moving.Enemies
{
    internal class EnemySpawner
    {        
        private float spawn = 60 * 2;
        private float spawnChance;        
        public void Update(GameTime gameTime)
        {                      
            Spawner();           
        }
        public void Spawner()
        {
            spawn--;
            if(spawn <= 0)
            {
                spawnChance = Globals.random.Next(1, 1000);
                
            }
            if(spawn <= 0)
            {
                if (spawnChance > 500 && spawnChance < 1000)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.chasingEnemy.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.chasingEnemy.Height);
                    MapManager.enemies.Add(new ChasingEnemy(new Rectangle(randX, randY, 64, 64)));
                }
                if (spawnChance > 600 && spawnChance < 900)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.necromancer.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.necromancer.Height);
                    MapManager.enemies.Add(new Necromancer(new Rectangle(randX, randY, 64, 64)));
                }
                if (spawnChance > 700 && spawnChance < 800)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.turret.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.turret.Height);
                    MapManager.enemies.Add(new TurretEnemy(new Rectangle(randX, randY, 64, 64)));
                }
                spawn = 60 * 2;
            }                      
        }        
    }
}
