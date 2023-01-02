#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.GameLogic.Stationary.Weapons;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using RoguelikeV2.Menus;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
#endregion

namespace RoguelikeV2.Managers
{
    internal class WeaponSpawnManager
    {
        public static WeaponSpawner spawner;

        public WeaponSpawnManager()
        {
            spawner = new WeaponSpawner();
        }
        public static void UpdateSpawner()
        {
            spawner.Update();
        }
        public static void DrawSpawner(SpriteBatch spriteBatch)
        {
            spawner.DrawWep(spriteBatch);
        }
    }
}
