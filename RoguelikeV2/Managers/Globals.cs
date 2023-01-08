#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
#endregion

namespace RoguelikeV2.Managers
{
    internal class Globals
    {
        #region Screen
        public static int screenWidth = 1920;
        public static int screenHeight = 1080;
        #endregion

        #region GameTime
        public static float DeltaTime { get; set; }
        public static void ElapsedSeconds(GameTime gameTime) => DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        public static float SurviveTimer { get; set; } = 0;
        #endregion

        #region enum GameStates
        public enum GameState { mainMenu, inGame1Player, inGame2Player, pauseGame, end, editingMap }
        public static GameState currentGameState = GameState.mainMenu;
        #endregion

        public static Random random = new Random();

        public static bool exitGame = false;

    }
}
