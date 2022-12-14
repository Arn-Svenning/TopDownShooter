#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace RoguelikeV2.Managers
{
    internal class InputManager
    {
        #region KeyboardVariables
        private static KeyboardState currentKeyState; 
        private static KeyboardState previousKeyState;
        #endregion
        public static void UpdateInput()
        {
            KeyboardGetState();
            MouseGetState();
        }
        #region KeyboardMethods
        public static KeyboardState KeyboardGetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            return currentKeyState;
        }

        public static bool HoldKey(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public static bool PressOnce(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
        }
        #endregion

        #region MouseVariables
        private static MouseState currentMouseState;
        public static MouseState CurrentMouse { get { return currentMouseState; } }
        private static MouseState previousMouseState;
        #endregion

        #region MouseMethods
        public static MouseState MouseGetState()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            return currentMouseState;
        }
        #endregion


    }
}
