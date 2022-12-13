using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RoguelikeV2.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeV2.Managers
{
    internal class CameraManager
    {
        public static EditorCamera editorCamera;


        public static void LoadCamera(GameWindow WINDOW)
        {
            editorCamera = new EditorCamera(WINDOW);
        }

        #region EditorCamera
        public static void UpdateEditorCamera(GameTime gameTime) => editorCamera.Update(gameTime);

        #endregion
    }
}
