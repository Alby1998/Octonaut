using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Octonaut
{
    class UI
    {
        Texture2D UItex, cooldown, texture, panicTex;
        private SpriteFont font;
        public Vector2 UIpos;


        #region animation vars
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 150f;
        int frames = 0;

        //animation2
        Rectangle destRect2;
        Rectangle sourceRect2;
        float elapsed2;
        float delay2 = 100f;
        int frames2 = 0;
        #endregion
        public UI()
        {
           

        }
        //Initialize
        public void Initialize() {
            UItex = null;
            UIpos = new Vector2(0, 0);
            destRect = new Rectangle(10, 470, 32, 32);
            destRect2 = new Rectangle(0, 0, 1024, 64);
        }

        public void LoadContent(ContentManager Content)
        {
            UItex = Content.Load<Texture2D>("UI/UI");
            cooldown = Content.Load<Texture2D>("UI/cooldown2");
            panicTex = Content.Load<Texture2D>("UI/panic");

            font = Content.Load<SpriteFont>("UI/font/fontBP");



            texture = cooldown;
        }



        public void Update(GameTime gameTime)
        {



            //Get Controller State
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyState = Keyboard.GetState();

            ///////////////////////////////////////////////////////////////
            //--------------------COOL DOWN TIMER-----------------------//
            /////////////////////////////////////////////////////////////

            if (Global.pause == false && Global.Death == false)
            {

                if (keyState.IsKeyDown(Keys.X) || gamePadState.Buttons.B == ButtonState.Pressed || gamePadState.Buttons.X == ButtonState.Pressed)
                {
                    if (Global.coolDownTime == false)
                    {

                        if (frames == 0)
                            frames = 1; Global.coolDownTime = true;


                    }
                }
            }
            ///////////////////////////////////////////////////////////////


            Animate(gameTime);




        }




        public void Draw(SpriteBatch spriteBatch)

        {
             spriteBatch.Begin();
           spriteBatch.Draw(UItex, UIpos, Color.White);
            spriteBatch.Draw(texture, destRect, sourceRect, Color.White * 0.5f);

            if (Global.panic == true)
                spriteBatch.Draw(panicTex, destRect2, sourceRect2, Color.White);


            if (Global.lives < 10)
                spriteBatch.DrawString(font, "0" + Convert.ToString(Global.lives), new Vector2(100, 18), Color.White);

            if (Global.lives >= 10 && Global.lives < 99)
                spriteBatch.DrawString(font, Convert.ToString(Global.lives), new Vector2(100, 18), Color.White);

            if (Global.lives >= 99)
                spriteBatch.DrawString(font, "99", new Vector2(100, 18), Color.White);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            if (Global.lvScore >= 1000000)
                spriteBatch.DrawString(font, "999999", new Vector2(462, 18), Color.White);

            if (Global.lvScore >= 100000 && Global.lvScore < 1000000)
                spriteBatch.DrawString(font, "" + Convert.ToString(Global.lvScore), new Vector2(462, 18), Color.White);

            if (Global.lvScore < 100000 && Global.lvScore >= 10000)
                spriteBatch.DrawString(font, "0" + Convert.ToString(Global.lvScore), new Vector2(462, 18), Color.White);

            if (Global.lvScore < 10000 && Global.lvScore >= 1000)
                spriteBatch.DrawString(font, "00" + Convert.ToString(Global.lvScore), new Vector2(462, 18), Color.White);

            if (Global.lvScore < 1000 && Global.lvScore >= 100)
                spriteBatch.DrawString(font, "000" + Convert.ToString(Global.lvScore), new Vector2(462, 18), Color.White);

            if (Global.lvScore < 100 && Global.lvScore >= 10)
                spriteBatch.DrawString(font, "0000" + Convert.ToString(Global.lvScore), new Vector2(462, 18), Color.White);

            if (Global.lvScore < 10)
                spriteBatch.DrawString(font, "00000" + Convert.ToString(Global.lvScore), new Vector2(462, 18), Color.White);


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (Global.shield >= 1000)
                spriteBatch.DrawString(font, "1000", new Vector2(895, 18), Color.White);

            if (Global.shield < 1000 && Global.shield >= 100)
                spriteBatch.DrawString(font, "0" + Convert.ToString(Global.shield), new Vector2(895, 18), Color.White);

            if (Global.shield < 100 && Global.shield >= 10)
                spriteBatch.DrawString(font, "00" + Convert.ToString(Global.shield), new Vector2(895, 18), Color.White);

            if (Global.shield < 10 && Global.shield > 0)
                spriteBatch.DrawString(font, "000" + Convert.ToString(Global.shield), new Vector2(895, 18), Color.White);

            if (Global.shield <= 0)
                spriteBatch.DrawString(font, "0000", new Vector2(895, 18), Color.White);




            spriteBatch.End();

        }




        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            ///////////////////////////////////////////////
            //-------------COOL DOWN TIMER--------------//
            /////////////////////////////////////////////

            if (frames != 0)
            {
                delay = 150f;

                if (elapsed >= delay)
                {
                    if (frames >= 14)
                    {
                        frames = 0;
                        Global.coolDownTime = false;
                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;
                }
            }



            ///////////////////////////////////////////////
            //---------------PANIC MODE-----------------//
            /////////////////////////////////////////////

            elapsed2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            if (Global.panic == true)
            {
                delay2 = 100f;

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
            }


            ///////////////////////////////////
            sourceRect = new Rectangle(32 * frames, 0, 32, 32);

            sourceRect2 = new Rectangle(1024 * frames2, 0, 1024, 64);

        }

    }
}