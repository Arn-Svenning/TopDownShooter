using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeV2.GameLogic.Moving.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeV2.Managers
{
    internal class EnemySpawnManager
    {
        public static EnemySpawner spawner = new EnemySpawner();

        public static void UpdateSpawner(GameTime gameTime)
        {
            spawner.Update(gameTime);
        }       
    }
}
