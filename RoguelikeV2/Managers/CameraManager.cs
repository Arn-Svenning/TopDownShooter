#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving.Players;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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

        public static OnePlayerCamera onePlayer;
       
        public static RenderTarget2D miniMap;
        public static Rectangle viewSize;
        public static void LoadCamera(Viewport VIEW, GraphicsDevice DEVICE)
        {
            onePlayer = new OnePlayerCamera(VIEW);
            editorCamera = new EditorCamera(VIEW);
            splitScreenCamera1 = new SplitScreenCamera();
            splitScreenCamera2 = new SplitScreenCamera();

            miniMap = new RenderTarget2D(DEVICE, Globals.screenWidth, Globals.screenHeight);
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
        #region OnePlayerCamera
        public static void UpdateOnePlayerCamera()
        {
            foreach (Player p1 in MapManager.player1)
            {
                onePlayer.SetPosition(p1.Position);

            }
            viewSize = new Rectangle((int)onePlayer.PlayerPos.X + 510, (int)onePlayer.PlayerPos.Y - 580, 450, 320);
        }
        #endregion
        #region MiniMap
        public static void DrawMiniMap(SpriteBatch spriteBatch)
        {                      
            spriteBatch.Draw(miniMap, viewSize, Color.White);          
        }
        #endregion
    }

}
