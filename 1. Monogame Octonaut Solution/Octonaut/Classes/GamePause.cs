using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Octonaut.Classes
{
    class GamePause
    {

        Texture2D texture, menu, cont;
        bool flagDown = false, flagUp = false, flagZ = true, flagC = false, flagStart = false, flagA = false, flagB = false, dDown = false, dUp = false;
        SoundEffect select, sd_pause;




        //Load Content
        public void LoadContent(ContentManager content)
        {

            menu = content.Load<Texture2D>("Pause/menu");
            cont = content.Load<Texture2D>("Pause/continue");

            select = content.Load<SoundEffect>("SFX/TitleScreen/Select");
            sd_pause = content.Load<SoundEffect>("SFX/General/gamePause");

            texture = cont;

        }

        public void Update(GameTime gameTime)
        {
            //Get Controller State
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            //Get Keyboard State
            KeyboardState keyState = Keyboard.GetState();

            if (Global.pause == false)
            {
                if(Global.gamePause == false)
                {

                    if (keyState.IsKeyDown(Keys.C) && flagC == false || gamePadState.Buttons.Start == ButtonState.Pressed && flagStart == false)
                    {
                        sd_pause.Play();
                        flagStart = true;
                        flagC = true;
                        Global.gamePause = true;
                    }
                }


                if (Global.gamePause == true)
                {

                    if (texture == cont) //Select Cont
                    {
                        if (keyState.IsKeyDown(Keys.Z) && flagZ == false || gamePadState.Buttons.A == ButtonState.Pressed && flagA == false || gamePadState.Buttons.B == ButtonState.Pressed && flagB == false)
                        {
                            flagDown = false;
                            flagUp = false;
                            flagZ = true;
                            flagA = true;
                            flagB = true;
                            Global.gamePause = false;
                        }
                    }


                    if (texture == menu) //select Menu
                    {
                        if (keyState.IsKeyDown(Keys.Z) && flagZ == false || gamePadState.Buttons.A == ButtonState.Pressed && flagA == false || gamePadState.Buttons.B == ButtonState.Pressed && flagB == false)
                        {
                            flagDown = false;
                            flagUp = false;
                            flagZ = true;
                            flagA = true;
                            flagB = true;
                            Global.pause = true;
                            Global.transitionStart = true;
                        }
                    }




                    if (texture == cont) //HOVER OVER Cont
                    {
                        if (keyState.IsKeyDown(Keys.Down) && flagDown == false || gamePadState.DPad.Down == ButtonState.Pressed && dDown == false)   //X and Z 
                        {
                            select.Play();
                            dDown = true;
                            texture = menu;
                            flagDown = true;
                        }
                            
                    }

                    if (texture == menu) //HOVER OVER Menu
                    {
                        if (keyState.IsKeyDown(Keys.Up) && flagUp == false || gamePadState.DPad.Up == ButtonState.Pressed && dUp == false)   //X and Z 
                        {
                            select.Play();
                            dUp = true;
                            texture = cont;
                            flagUp = true;
                        }

                    }


                    if (keyState.IsKeyUp(Keys.Up)) //Reset Flags
                    {
                        flagUp = false;
                    }
                    if (keyState.IsKeyUp(Keys.Down))
                    {
                        flagDown = false;
                    }
                    if (keyState.IsKeyUp(Keys.Z))
                    {
                        flagZ = false;
                    }
                    if (keyState.IsKeyUp(Keys.C))
                    {
                        flagC = false;
                    }
                    if (gamePadState.Buttons.Start == ButtonState.Released)
                    {
                        flagStart = false;
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
                else
                {
                    texture = cont;
                    flagZ = true;
                    flagA = true;
                    flagB = true;
                }

            }
        }


        public void Draw(SpriteBatch spriteBatch)

        {
            spriteBatch.Begin();

            if(Global.gamePause == true)
            spriteBatch.Draw(texture, new Vector2(0, 0), Color.White);
      
            spriteBatch.End();

        }

    }
}
