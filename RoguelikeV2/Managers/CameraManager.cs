#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.Managers
{
    internal class CameraManager
    {
        public static EditorCamera editorCamera;

        public static Viewport defaultView;
        public static Viewport leftView;
        public static Viewport rightView;
        public static SplitScreenCamera splitScreenCamera1;
        public static SplitScreenCamera splitScreenCamera2;
        public static void LoadCamera(Viewport VIEW)
        {
            editorCamera = new EditorCamera(VIEW);
            splitScreenCamera1 = new SplitScreenCamera();
            splitScreenCamera2 = new SplitScreenCamera();
            
        }

        #region EditorCamera
        public static void UpdateEditorCamera(GameTime gameTime) => editorCamera.Update(gameTime);

        #endregion
        #region SplitScreenCamera
        public static void UpdateSplitScreenCamera()
        {
           foreach(Player p1 in MapManager.player1)
           {
                splitScreenCamera1.Update(p1.Position);
           }
           foreach(Player p2 in MapManager.player2)
           {
                splitScreenCamera2.Update(p2.Position);
           }
                                   
           
                       
        }
        #endregion
    }
}
