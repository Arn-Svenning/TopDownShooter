﻿#region Using...
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

        #region XBOX Variables
        private static GamePadState currentPadState;
        private static GamePadState previousPadState;
        private static GamePadState currentPadState2;
        private static GamePadState previousPadState2;
        #endregion
        public static void UpdateInput()
        {
            KeyboardGetState();
            MouseGetState();
            GamePadStateGetState();
            GamePadStateGetState2();
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

        #region XBOX

        public static GamePadState GamePadStateGetState()
        {
            previousPadState = currentPadState;
            currentPadState = GamePad.GetState(PlayerIndex.One);
            return currentPadState;

        }
        public static GamePadState GamePadStateGetState2()
        {
            previousPadState2 = currentPadState2;
            currentPadState2 = GamePad.GetState(PlayerIndex.Two);
            return currentPadState2;

        }
        public static bool ControllerPressedOnce(Buttons button)
        {
            return currentPadState.IsButtonDown(button) && !previousPadState.IsButtonDown(button);
        }
        public static bool ControllerPressedOnce2(Buttons button)
        {
            return currentPadState2.IsButtonDown(button) && !previousPadState2.IsButtonDown(button);
        }

        #endregion
    }
}
