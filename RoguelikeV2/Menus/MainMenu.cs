#region Using...
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RoguelikeV2.Camera;
using RoguelikeV2.GameLogic.Moving;
using RoguelikeV2.Json;
using RoguelikeV2.Managers;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using MonoGame.UI.Forms;
using Button = MonoGame.UI.Forms.Button;
using System;
#endregion

namespace RoguelikeV2.Menus
{
    internal class MainMenu : ControlManager
    {
        private static bool startButtonClicked;
        private static bool onePlayerButton;
        private static bool twoPlayerButton;       

        private static Button playerOneButton;
        private static Button playerTwoButton;
        private static Button exitButton;
        public MainMenu(Game game) : base (game)
        {
            startButtonClicked = false;
            onePlayerButton = false;
            twoPlayerButton = false;
            
        }
        public override void InitializeComponent()
        {
            var startButton = new Button()
            {
                Text = "Start Game",
                Size = new Vector2(400, 200),
                BackgroundColor = Color.Blue,
                Location = new Vector2(Globals.screenWidth / 2 - 200, 500)
            };
            startButton.Clicked += StartButtonClick;
            Controls.Add(startButton);

            exitButton = new Button()
            {
                Text = "Exit Game",
                Size = new Vector2(400, 200),
                BackgroundColor = Color.Blue,
                Location = new Vector2(Globals.screenWidth / 2 - 200, 750)
            };
            exitButton.Clicked += ExitButtonClick;
            Controls.Add(exitButton);

            playerOneButton = new Button()
            {
                Text = "One Player",                    
                Size = new Vector2(300, 100),
                BackgroundColor = Color.Blue,
                Location = new Vector2(Globals.screenWidth/2 - 150, 500)
            };
            playerOneButton.Clicked += PlayerOneSelect;                

            playerTwoButton = new Button()
            {
                Text = "Two Player",
                Size = new Vector2(300, 100),
                BackgroundColor = Color.Blue,
                Location = new Vector2(Globals.screenWidth / 2 - 150, 650)
            };
            playerTwoButton.Clicked += PlayerTwoSelect;
                         
        }
        private void StartButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;            
            button.IsVisible = false;
            startButtonClicked = true;
            Controls.Add(playerOneButton);
            Controls.Add(playerTwoButton);
            AssetManager.click.Play(volume: 0.4f, pitch: 0.1f, pan: 0.0f);
            
        }
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Globals.exitGame = true;                     
        }
        private void PlayerOneSelect(object sender, EventArgs e)
        {            
            Button buttonOne = sender as Button;            
            onePlayerButton = true;
            Controls.Remove(exitButton);
            AssetManager.click.Play(volume: 0.4f, pitch: 0.1f, pan: 0.0f);
        }
        private void PlayerTwoSelect(object sender, EventArgs e)
        {
            Button buttonTwo = sender as Button;            
            twoPlayerButton = true;
            Controls.Remove(exitButton);
            AssetManager.click.Play(volume: 0.4f, pitch: 0.1f, pan: 0.0f);
        }
        public static void UpdateMenu()
        {    
            if(startButtonClicked)
            {
                exitButton.Size = new Vector2(300, 100);
                exitButton.Location = new Vector2(Globals.screenWidth / 2 - 150, 800);
            }
                          
            if (onePlayerButton || twoPlayerButton)
            {
                playerOneButton.IsVisible = false;                    
                playerTwoButton.IsVisible = false;                    
            }
                               
            if (twoPlayerButton)
            {
                Globals.currentGameState = Globals.GameState.inGame2Player;
            }
            else if(onePlayerButton)
            {
                Globals.currentGameState = Globals.GameState.inGame1Player;
            }
        }
        public static void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(AssetManager.menuBackground, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
    }
}
