using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using Octonaut.Classes;

namespace Octonaut
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Octonaut : Game
    {

       public enum GameState {titleScreen, play };

       public static GameState gameState = GameState.titleScreen;
        

        /////////////////////////////////////////////////////////////////////////
       


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        bool flag = false;

       // SoundEffect deathEX;



        Titlescreen ts = new Titlescreen();
        GamePause gamePause = new GamePause();

        EnemySpawn waves = new EnemySpawn();
        EnemyManager RedRay = new EnemyManager();
        EnemyManager ghost = new EnemyManager();
        EnemyManager jet = new EnemyManager();
        EnemyManager beye = new EnemyManager();
        EnemyManager bot = new EnemyManager();
        EnemyManager turn = new EnemyManager();
        LaserManager LazerBeams = new LaserManager();
        player octonaut = new player();               
        
        
        Texture2D explosion;

        DEBUG debug = new DEBUG();

        Newbd bd = new Newbd();
        Transition transition = new Transition();
        UI UI = new UI();
        Levelend lvend = new Levelend();

        public Octonaut()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1024;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 512;   // set this value to the desired height of your window


            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (graphics.PreferredBackBufferWidth / 2), (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - (graphics.PreferredBackBufferHeight / 2));

            this.Window.Title = "Octonaut";
            graphics.ApplyChanges();

           

            IsMouseVisible = true;

            //Fixes Lag
            this.IsFixedTimeStep = false;
        }

        ///<summary>/////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ///</summary>//////////////////////////////////////////////////////////////////////////

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            bd.Initialize();
            octonaut.Initialize();     
            lvend.Initialize();
            UI.Initialize();
            
            base.Initialize();
        }

        ///<summary>/////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ///</summary>//////////////////////////////////////////////////////////////////////////
        ///
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

           

            bd.LoadContent(Content);
            UI.LoadContent(Content);
            octonaut.LoadContent(Content.Load<Texture2D>("player/Octo_Player"), Content.Load<Texture2D>("player/Octo_dodge"), Content.Load<Texture2D>("player/Octo_death"), Content.Load<Texture2D>("player/bullets/Bullet1"), Content.Load<Texture2D>("player/bullets/Bullet2"), Content.Load<Texture2D>("UI/gameover"), new Rectangle(64, 200, 80, 80), Content.Load<SoundEffect>("SFX/General/sd_shot1"), Content.Load<SoundEffect>("SFX/General/panic"), Content.Load<SoundEffect>("SFX/General/pDeath"), Content.Load<SoundEffect>("SFX/General/shield"));
           
          

            explosion = Content.Load<Texture2D>("Enemy/beye/byeExplosion");

            LazerBeams.LoadContent(Content, Content.Load<SoundEffect>("SFX/General/eDeath"));

            //deathEX = Content.Load<SoundEffect>("SFX/General/eDeath"); //enemy death explosion // null error fix

            RedRay.LoadContent(Content);

            ts.LoadContent(Content);

            gamePause.LoadContent(Content);


            lvend.LoadContent(Content);
            transition.LoadContent(Content);


            
        }

        ///<summary>/////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ///</summary>//////////////////////////////////////////////////////////////////////////
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        ///<summary>/////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ///</summary>//////////////////////////////////////////////////////////////////////////

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //set death Ex becouse of Null Error
               // LazerBeams.eDeath = deathEX;



            if (Keyboard.GetState().IsKeyDown(Keys.F4) && flag == false)
            {
                

                if (graphics.IsFullScreen == false && flag == false)
                {
                    graphics.IsFullScreen = true;
                    flag = true;
                    graphics.HardwareModeSwitch = false;
                    graphics.ApplyChanges();
                }

                if (graphics.IsFullScreen == true && flag == false)
                {
                    graphics.IsFullScreen = false;
                    flag = true;

                   
                    Window.IsBorderless = false;
                    graphics.ApplyChanges();
                }


            }

            if (Keyboard.GetState().IsKeyUp(Keys.F4))
            {
                flag = false;
               
            }


            ///////////////////////////////////////////////////////////////
            //--------------------SET PANIC MODE------------------------//
            /////////////////////////////////////////////////////////////

            if (Global.panic == false && Global.shield <= 0)
            {
                Global.shield = 0;
                Global.panic = true;
            }
            
            if (Global.shield > 0)
            {
                Global.panic = false;
            }




            ///////////////////////////////////////////////////////////////
            //----------------------SET LV SCORE BOUNDS-----------------//
            /////////////////////////////////////////////////////////////
            if (Global.lvScore >= 999999)
            {
                Global.lvScore = 999999;
            }

            if (Global.lvScore <= 0)
            {
                Global.lvScore = 0;
            }


            if(Global.lvBegin == true)
            {



            }




            ///////////////////////////////////////////////////////////////
            //-----------------------Game States------------------------//
            /////////////////////////////////////////////////////////////

            switch (gameState)
            {
                case GameState.titleScreen:  //TITLE SCREEN STATE

                    if (Global.LV > 0)
                        gameState = GameState.play;

                    ts.Update(gameTime);

                    //////////////////////////////////////////////////////////
                    //------------RESET VALUES FOR NEXT RUN OF GAME--------//
                    ////////////////////////////////////////////////////////
                    player.destRect = new Rectangle(64, 200, 80, 80);
                    player.position = new Vector2(64, 200);

                    Global.grandScore = 0;

                    player.gmPos = new Vector2(1024, 256);
                    player.gmTimer = 2000;
                    Global.invincible = false;
                    Global.panic = false;
                    Global.GameOver = false;
                    Global.Death = false;
                    Global.shield = 1000;
                    Global.lvScore = 0;

                    EnemySpawn.timer = 0;
                    if (Global.LV == 1)
                        Global.lives = 3;

                    EnemyManager.Clear();

                    //////////////////////////////////////////////////////


                    break;

                case GameState.play:  //PLAYING THE GAME STATE

                    if (Global.LV == 0)
                        gameState = GameState.titleScreen;

                    //--!!!!!!!--READ ME--!!!!!!!--//
                    //  RedRay.UpdateEnemies(gameTime, octonaut); //For some reason This enemy still spawns in other LVs but invisible (The player can collide and take damage with invisible enemies)//

                    if (Global.gamePause == false)
                    {

                        LazerBeams.UpdateManagerLaser(gameTime, explosion);                                          // we can fix this when we set up the wave class, so don't worry about it.//
                        bd.Update(gameTime);

                        if (Global.LV != 4)
                            octonaut.Update(gameTime);


                        


                        UI.Update(gameTime);
                    }

                    gamePause.Update(gameTime);

                    break;
            }

            transition.Update(gameTime);
            lvend.Update(gameTime);
           
            debug.Update(gameTime);



                        

            base.Update(gameTime);
        }


        ///<summary>/////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ///</summary>//////////////////////////////////////////////////////////////////////////

        void FullScreen(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;  
            graphics.PreferredBackBufferHeight = height;   
            graphics.ApplyChanges();
          

        }


        ///<summary>/////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ///</summary>//////////////////////////////////////////////////////////////////////////


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            if (gameState == GameState.play)
            {

                bd.Draw(spriteBatch);

                if (Global.dodge == true)
                {
                    if (Global.LV != 4)
                        octonaut.Draw(spriteBatch);

                }

                waves.Update(spriteBatch, gameTime, octonaut, Content);
               
               
                if (Global.dodge == false)
                {
                    if (Global.LV != 4)
                        octonaut.Draw(spriteBatch);
                }

            }


            //  spin.Draw(spriteBatch);

            if (gameState == GameState.play)
            {
                if (Global.LV != 4)
                    UI.Draw(spriteBatch);
            }


            if (gameState == GameState.titleScreen)
            {
                ts.Draw(spriteBatch);
            }

            gamePause.Draw(spriteBatch);
            lvend.Draw(spriteBatch);
            transition.Draw(spriteBatch);
            base.Draw(gameTime);


            
        }   
    }
}
