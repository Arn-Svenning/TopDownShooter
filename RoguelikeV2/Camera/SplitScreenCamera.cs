#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.Camera
{
    internal class SplitScreenCamera
    {
        private Matrix transform;
        public Matrix Transform { get { return transform; } }

        private Vector2 centre;
        public Vector2 Center { get { return centre; } }

        public SplitScreenCamera()
        {
            
        }
        public void Update(Vector2 cameraPosition)
        {
            centre = new Vector2(cameraPosition.X - Globals.screenWidth / 4, cameraPosition.Y - Globals.screenHeight / 2);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));             
        }
    }
}
