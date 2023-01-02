#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
#endregion

namespace RoguelikeV2.Camera
{
    internal class OnePlayerCamera
    {
        private Matrix transform;
        private Vector2 playerPos;
        public Vector2 PlayerPos { get { return playerPos; } }
        private Viewport view;

        public Matrix Transform { get { return transform; } }

        public OnePlayerCamera(Viewport view)
        {
            this.view = view;
        }
        public void SetPosition(Vector2 pos)
        {
            this.playerPos = pos;
            transform = Matrix.CreateTranslation(-playerPos.X + view.Width / 2, -playerPos.Y + view.Height - 500, 0);
        }
    }
}
