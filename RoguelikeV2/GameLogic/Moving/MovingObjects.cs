#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
#endregion

namespace RoguelikeV2.GameLogic.Moving
{
    abstract class MovingObjects : GameObjects
    {
        protected float velocity;

        protected Vector2 direction;

        #region Animation variables
        private float elapsedTime;
        private float frameTime;
        private float frameSpeed;

        private int numberOfFrames;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;

        protected Rectangle sourceRectangle;
        #endregion
        public MovingObjects(Rectangle RECTANGLE) : base(RECTANGLE)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {

        }
        protected void PlayAnimation(GameTime gameTime, int numberOfFrames, Texture2D animationTex, float frameSpeed)
        {
            frameTime = frameSpeed;

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            sourceRectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);

            this.numberOfFrames = numberOfFrames;
            frameWidth = (animationTex.Width / numberOfFrames);
            frameHeight = (animationTex.Height);

            if (elapsedTime >= frameTime)
            {
                if (currentFrame >= numberOfFrames - 1)
                {
                    currentFrame = 0;

                }
                else
                {
                    currentFrame++;
                }
                elapsedTime = 0;
            }
        }
    }
}
