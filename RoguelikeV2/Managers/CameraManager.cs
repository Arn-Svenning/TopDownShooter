#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.Managers
{
    internal class CameraManager
    {
        public static EditorCamera editorCamera;


        public static void LoadCamera(Viewport VIEW)
        {
            editorCamera = new EditorCamera(VIEW);
        }

        #region EditorCamera
        public static void UpdateEditorCamera(GameTime gameTime) => editorCamera.Update(gameTime);

        #endregion
    }
}
