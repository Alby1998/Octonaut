using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace Octonaut
{
    class Titlescreen
    {
        Texture2D start, controls, credits, texture, texture2, background, copyright, logotag, pressStart, keyboard, controller, teamTentacle, pause, splashscreen;
        Boolean flagUp, flagDown, flagX, flagZ, flagA, flagB, dUp, dDown;
        Song titleScreen;
        SoundEffect select, selected;
        int timer = 0;
        


        //Animation Vars
        public static Rectangle destRect, destRect2;
        Rectangle sourceRect, sourceRect2;
        float elapsed;
        float delay = 150f;
        int frames = 0;
        public static int state = 0;

        //Animation ver for controller and keyboard
        public static Rectangle destRect3, destRect4;
        Rectangle sourceRect3;
        float elapsed2;
        float delay2 = 150f;
        int frames2 = 0;

        bool songFlag = true;



        //Constructor
        public Titlescreen()
        {

            texture = null;
            flagUp = false;
            flagDown = false;
            dUp = false;
            dDown = false;
            flagA = false;
            flagB = false;

            destRect = new Rectangle(318, 96, 396, 122);
            destRect2 = new Rectangle(398, 320, 226, 26);
            destRect3 = new Rectangle(70, 80, 216, 386);
            destRect4 = new Rectangle(750, 80, 216, 386);

        }


        //Load Content
        public void LoadContent(ContentManager content)
        {


            start = content.Load<Texture2D>("Titlescreen/start");
            controls = content.Load<Texture2D>("Titlescreen/controls");
            credits = content.Load<Texture2D>("Titlescreen/credits");
            background = content.Load<Texture2D>("Titlescreen/ts-background");
            copyright = content.Load<Texture2D>("Titlescreen/copyright");
            logotag = content.Load<Texture2D>("Titlescreen/logotype");
            keyboard = content.Load<Texture2D>("Titlescreen/KEYBOARD");
            controller = content.Load<Texture2D>("Titlescreen/controller");
            teamTentacle = content.Load<Texture2D>("Titlescreen/mCredits");
            titleScreen = content.Load<Song>("Music/music_ts");
            select = content.Load<SoundEffect>("SFX/TitleScreen/Select");
            selected = content.Load<SoundEffect>("SFX/TitleScreen/Selected");

            pause = content.Load<Texture2D>("Titlescreen/Pause");
            splashscreen = content.Load<Texture2D>("Titlescreen/splashcredits/Splash Screen");

            // MediaPlayer.Play(titleScreen);

            MediaPlayer.IsRepeating = true;


            pressStart = content.Load<Texture2D>("Titlescreen/pressstart");
            texture = start;





        }

        ///UPDATE///
        public void Update(GameTime gameTime)
        {
            Animate(gameTime);

            //Get Controller State
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            //Get Keyboard State
            KeyboardState keyState = Keyboard.GetState();

            if (state == 0)
            {
                timer++;

                if (timer == 500)
                    state++;

            }

            if (state != 0)
                timer = 0;

            if (state == 1)
            {
                texture2 = pressStart;

                if (songFlag == true)
                {
                    MediaPlayer.Play(titleScreen);
                    songFlag = false;
                }
                


                if (keyState.IsKeyDown(Keys.X) || keyState.IsKeyDown(Keys.Z) || gamePadState.Buttons.A == ButtonState.Pressed || gamePadState.Buttons.B == ButtonState.Pressed || gamePadState.Buttons.Start == ButtonState.Pressed)  //X and Z 
                {

                    texture2 = null;

                    flagX = true;
                    flagZ = true;

                    flagA = true;
                    flagB = true;

                    state = 2;
                   
                    selected.Play();
                }
            }


            if (state == 2)
            {
                songFlag = true;

                if (texture == start) //HOVER OVER START
                {
                    if (keyState.IsKeyDown(Keys.Down) && flagDown == false || gamePadState.DPad.Down == ButtonState.Pressed && dDown == false)   //X and Z 
                    {
                        texture = controls;
                        dDown = true;
                        flagDown = true;
                        select.Play();
                    }


                    if (keyState.IsKeyDown(Keys.X) && flagX == false || keyState.IsKeyDown(Keys.Z) && flagZ == false || gamePadState.Buttons.A == ButtonState.Pressed && flagA == false || gamePadState.Buttons.B == ButtonState.Pressed && flagB == false ) //X and Z  //START GAME
                    {

                        Global.transitionStart = true;
                        Global.pause = true;
                        state = 3;

                        flagX = true;
                        flagZ = true;

                        flagA = true;
                        flagB = true;

                        selected.Play();
                        MediaPlayer.Stop();
                    }

                }

                if (texture == controls) //HOVER OVER CONTROLS
                {
                    if (keyState.IsKeyDown(Keys.Up) && flagUp == false || gamePadState.DPad.Up == ButtonState.Pressed && dUp == false)    //X and Z 
                    {
                        texture = start;
                        dUp = true;
                        flagUp = true;
                        select.Play();
                    }

                    if (keyState.IsKeyDown(Keys.Down) && flagDown == false || gamePadState.DPad.Down == ButtonState.Pressed && dDown == false)    //X and Z 
                    {
                        texture = credits;
                        dDown = true;
                        flagDown = true;
                        select.Play();
                    }
                }
                if (texture == credits) //HOVER OVER CREDITS
                {
                    if (keyState.IsKeyDown(Keys.Up) && flagUp == false || gamePadState.DPad.Up == ButtonState.Pressed && dUp == false)    //X and Z 
                    {
                        texture = controls;
                        dUp = true;
                        flagUp = true;
                        select.Play();
                    }
                }

                if (keyState.IsKeyUp(Keys.Up))
                {
                    flagUp = false;
                }
                if (keyState.IsKeyUp(Keys.Down))
                {
                    flagDown = false;
                }

                if (keyState.IsKeyUp(Keys.X))
                {
                    flagX = false;
                }
                if (keyState.IsKeyUp(Keys.Z))
                {
                    flagZ = false;
                }
                if (gamePadState.Buttons.A == ButtonState.Released)
                {
                    flagA = false;
                }
                if (gamePadState.Buttons.B == ButtonState.Released)
                {
                    flagB = false;
                }
                if (gamePadState.DPad.Down == ButtonState.Released)
                {
                    dDown = false;
                }
                if (gamePadState.DPad.Up == ButtonState.Released)
                {
                    dUp = false;
                }




            }




          

           


        }



        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            ////////////////////////////////////
            //-------------MOVE--------------//
            ///////////////////////////////////

            delay = 150;

            if (elapsed >= delay)
            {
                if (frames >= 1)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }

                elapsed = 0;
            }

            ////////////////////////////


            //if (elapsed >= delay)
            //{
            //    if (frames >= 1)
            //    {
            //        frames = 0;
            //    }
            //    else
            //    {
            //        frames++;
            //    }

            //    elapsed = 0;
            //}

            elapsed2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            delay2 = 250;

            if (elapsed2 >= delay2)
            {
                if (frames2 >= 1)
                {
                    frames2 = 0;
                }
                else
                {
                    frames2++;
                }

                elapsed2 = 0;
            }


            sourceRect = new Rectangle(396 * frames, 0, 396, 122);
            sourceRect2 = new Rectangle(226 * frames, 0, 226, 26);
            sourceRect3 = new Rectangle(216 * frames2, 0, 216, 386);

        }



        //Draw
        public void Draw(SpriteBatch spriteBatch)

        {
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(copyright, new Vector2(343, 500), Color.White);
            spriteBatch.Draw(logotag, destRect, sourceRect, Color.White);

            if (state == 2 || state == 3)
                spriteBatch.Draw(texture, new Vector2(417, 250), Color.White);


            if (texture2 != null)
                spriteBatch.Draw(pressStart, destRect2, sourceRect2, Color.White);

            if (texture == controls)
            {
                spriteBatch.Draw(keyboard, destRect3, sourceRect3, Color.White);
                spriteBatch.Draw(controller, destRect4, sourceRect3, Color.White);
                spriteBatch.Draw(pause, new Vector2(435,480), Color.White);
            }

            if (texture == credits)
                spriteBatch.Draw(teamTentacle, new Rectangle(70, 80, 216, 386), Color.White);

            if (state == 0)
                spriteBatch.Draw(splashscreen, new Vector2(0, 0), Color.White);

            spriteBatch.End();

        }


    }
}