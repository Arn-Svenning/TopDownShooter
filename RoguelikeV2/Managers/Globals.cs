#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private static void ElapsedSeconds(GameTime gameTime) => DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        #endregion

        #region enum GameStates
        public enum GameState { mainMenu, inGame, pauseGame, end, editingMap }
        public static GameState currentGameState = GameState.mainMenu;
        #endregion

    }
}
