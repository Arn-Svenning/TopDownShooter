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
        private float spawnNumber;
        private float spawn = 5;
        private float spawnChance;

        private int randomSpawnX = 1;
        private int randomSpawnY = 10;
        public void Update(GameTime gameTime)
        {                       
            Spawner(gameTime);           
        }
        public void Spawner(GameTime gameTime)
        {
            
            spawn -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            Debug.WriteLine(spawn);
            if(spawn <= 0)
            {
                spawnChance = Globals.random.Next(randomSpawnX, randomSpawnY);
                
            }
            if(spawn <= 0)
            {
                //CHASING
                if (spawnChance > 1)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.chasingEnemy.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.chasingEnemy.Height);
                    MapManager.enemies.Add(new ChasingEnemy(new Rectangle(randX, randY, 64, 64), 3));
                }
                //NECROMANCER
                if (spawnChance > 8 && Globals.SurviveTimer < 70)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.necromancer.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.necromancer.Height);
                    MapManager.enemies.Add(new Necromancer(new Rectangle(randX, randY, 64, 64), 2));
                }
                else if(Globals.SurviveTimer > 70 && spawnChance > 7)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.necromancer.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.necromancer.Height);
                    MapManager.enemies.Add(new Necromancer(new Rectangle(randX, randY, 64, 64), 2));
                }
                //TURRET
                if (spawnChance == 5)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.turret.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.turret.Height);
                    MapManager.enemies.Add(new TurretEnemy(new Rectangle(randX, randY, 64, 64), 5));
                }
                else if(Globals.SurviveTimer > 90 && spawnChance > 7 && Globals.currentGameState == Globals.GameState.inGame2Player)
                {
                    int randX = Globals.random.Next(100, Globals.screenWidth - AssetManager.turret.Width);
                    int randY = Globals.random.Next(100, Globals.screenHeight - AssetManager.turret.Height);
                    MapManager.enemies.Add(new TurretEnemy(new Rectangle(randX, randY, 64, 64), 5));
                }
                IncreaseSpawnChance();
                spawn = spawnNumber;
            }                      
        }    
        public void IncreaseSpawnChance()
        {   if(Globals.SurviveTimer < 40)
            {
                spawnNumber = 5;
            }
            else if(Globals.SurviveTimer > 40 && Globals.SurviveTimer < 80)
            {
                spawnNumber = 4;              
            }
            else if(Globals.SurviveTimer > 80 && Globals.SurviveTimer < 120)
            {
                spawnNumber = 3;
            }
            else if(Globals.SurviveTimer > 120 )
            {
                spawnNumber = 2;
            }                   
        }
    }
}
