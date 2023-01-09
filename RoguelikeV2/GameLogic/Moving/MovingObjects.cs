#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.GameLogic.Stationary;
using SharpDX.Direct3D9;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
#endregion

namespace RoguelikeV2.GameLogic.Moving
{
    abstract class MovingObjects : GameObjects
    {
        protected float speed;
        public float Speed { get{ return speed; } }
        
        protected Vector2 direction;
        public Vector2 Dir { get { return direction; } }
        
        #region Animation variables
        private float elapsedTime;
        private float frameTime;
        private float frameSpeed;

        private int numberOfFrames;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;

        protected Rectangle sourceRectangle;
        protected Rectangle sourceRectangleHearts;
        #endregion
        public MovingObjects(Rectangle RECTANGLE) : base(RECTANGLE)
        {
            position = new Vector2(size.X, size.Y);
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
        #region Colission
        protected bool IsTouchingLeft(StationaryObjects obj)
        {
            return this.size.Right + this.direction.X + 6 > obj.Size.Left &&
              this.size.Left < obj.Size.Left &&
              this.size.Bottom > obj.Size.Top &&
              this.size.Top < obj.Size.Bottom;
        }

        protected bool IsTouchingRight(StationaryObjects obj)
        {
            return this.size.Left + this.direction.X - 6 < obj.Size.Right &&
              this.size.Right > obj.Size.Right &&
              this.size.Bottom > obj.Size.Top &&
              this.size.Top < obj.Size.Bottom;
        }

        protected bool IsTouchingTop(StationaryObjects obj)
        {
            return this.size.Bottom + this.direction.Y + 6 > obj.Size.Top &&
              this.size.Top < obj.Size.Top &&
              this.size.Right > obj.Size.Left &&
              this.size.Left < obj.Size.Right;
        }

        protected bool IsTouchingBottom(StationaryObjects obj)
        {
            return this.size.Top + this.direction.Y - 6 < obj.Size.Bottom &&
              this.size.Bottom > obj.Size.Bottom &&
              this.size.Right > obj.Size.Left &&
              this.size.Left < obj.Size.Right;
        }
        #endregion
    }
}
