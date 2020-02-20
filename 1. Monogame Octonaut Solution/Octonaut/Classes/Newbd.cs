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
    class Newbd
    {
        #region General vars
        public Texture2D texture1, texture2, texture3, texture4, texture5, lv1_1, lv1_2, lv1_3, lv1_4, lv2_1, lv2_2, lv2_3, lv2_4, lv3_1, lv3_2, lv4_1, lv4_2, lv4_3, lv5_1, lv5_2, lv5_3, lv5_4, lv6_1, lv6_2, lv6_3, lv7_1, lv7_2, lv7_3, lv8_1, lv8_2, lv8_3, lv8_4, lv8_5, lv8_fire, lv9_1, lv9_2, credits;
        public Vector2 bgpos1_1, bgpos1_2, bgpos2_1, bgpos2_2, bgpos3_1, bgpos3_2, bgpos4_1, bgpos4_2, bgpos5_1, bgpos5_2;
        public float speed1, speed2, speed3, speed4, speed5;
        int timer = 0;
        #endregion

        #region Animation Vars
        Rectangle aniPos;
        Rectangle aniRec;
        float elapsed;
        float delay = 70f;
        int frames = 0;
        #endregion
        public Newbd()
        {
           

        }
        //Initialize
        public void Initialize()
        {
            texture1 = null;
            bgpos1_1 = new Vector2(0, 0);
            bgpos1_2 = new Vector2(1024, 0);

            bgpos2_1 = new Vector2(0, 0);
            bgpos2_2 = new Vector2(1024, 0);


            bgpos3_1 = new Vector2(0, 0);
            bgpos3_2 = new Vector2(1024, 0);


            bgpos4_1 = new Vector2(0, 0);
            bgpos4_2 = new Vector2(1024, 0);

            bgpos5_1 = new Vector2(0, 0);
            bgpos5_2 = new Vector2(2048, 0);


            aniPos = new Rectangle(0, 0, 256, 512);
        }

        public void LoadContent(ContentManager Content)
        {





            //Level 1

            lv1_1 = Content.Load<Texture2D>("lv_bg/lv1/lv1tile1");
            lv1_2 = Content.Load<Texture2D>("lv_bg/lv1/lv1tile2");
            lv1_3 = Content.Load<Texture2D>("lv_bg/lv1/lv1tile3");
            lv1_4 = Content.Load<Texture2D>("lv_bg/lv1/lv1tile4");


            //Level 2
            lv2_1 = Content.Load<Texture2D>("lv_bg/lv2/redesign/1");
            lv2_2 = Content.Load<Texture2D>("lv_bg/lv2/redesign/2");
            lv2_3 = Content.Load<Texture2D>("lv_bg/lv2/redesign/3");
            lv2_4 = Content.Load<Texture2D>("lv_bg/lv2/redesign/4");

            //Level 3
            lv3_1 = Content.Load<Texture2D>("lv_bg/lv3/lv3tile1");
            lv3_2 = Content.Load<Texture2D>("lv_bg/lv3/lv3tile2");

            //Level 4
            lv4_1 = Content.Load<Texture2D>("lv_bg/lv4/lv4tile1");
            lv4_2 = Content.Load<Texture2D>("lv_bg/lv4/lv4tile2");
            lv4_3 = Content.Load<Texture2D>("lv_bg/lv4/lv4tile3");

            //Level 5
            lv5_1 = Content.Load<Texture2D>("lv_bg/lv5/lv5tile1");
            lv5_2 = Content.Load<Texture2D>("lv_bg/lv5/lv5tile2");
            lv5_3 = Content.Load<Texture2D>("lv_bg/lv5/lv5tile3");
            lv5_4 = Content.Load<Texture2D>("lv_bg/lv5/lv5tile4");

            //Level 6
            lv6_1 = Content.Load<Texture2D>("lv_bg/lv6/lv6tile1");
            lv6_2 = Content.Load<Texture2D>("lv_bg/lv6/lv6tile2");
            lv6_3 = Content.Load<Texture2D>("lv_bg/lv6/lv6tile3");

            //Level 7
            lv7_1 = Content.Load<Texture2D>("lv_bg/lv7/lv7tile1");
            lv7_2 = Content.Load<Texture2D>("lv_bg/lv7/lv7tile2");
            lv7_3 = Content.Load<Texture2D>("lv_bg/lv7/lv7tile3");

            //Level 8
            lv8_1 = Content.Load<Texture2D>("lv_bg/lv8/lv8tile1");
            lv8_2 = Content.Load<Texture2D>("lv_bg/lv8/lv8tile2");
            lv8_3 = Content.Load<Texture2D>("lv_bg/lv8/lv8tile3");
            lv8_4 = Content.Load<Texture2D>("lv_bg/lv8/lv8tile4");
            lv8_5 = Content.Load<Texture2D>("lv_bg/lv8/lv8tile5");
            lv8_fire = Content.Load<Texture2D>("lv_bg/lv8/lv8_fire");

            //Level 9
            lv9_1 = Content.Load<Texture2D>("lv_bg/lv9/lv9tile1");
            lv9_2 = Content.Load<Texture2D>("lv_bg/lv9/lv9tile2");

            credits = Content.Load<Texture2D>("Titlescreen/splashcredits/Credits");





        }

        public void Draw(SpriteBatch spriteBatch)

        {

            spriteBatch.Begin();
            if (Global.LV != 2 && Global.LV != 4)
            {

                if (texture1 != null)
                {
                    spriteBatch.Draw(texture1, bgpos1_1, Color.White);
                    spriteBatch.Draw(texture1, bgpos1_2, Color.White);
                }

                if (texture2 != null)
                {

                    spriteBatch.Draw(texture2, bgpos2_1, Color.White);
                    spriteBatch.Draw(texture2, bgpos2_2, Color.White);

                }

                if (texture3 != null)
                {

                    spriteBatch.Draw(texture3, bgpos3_1, Color.White);
                    spriteBatch.Draw(texture3, bgpos3_2, Color.White);

                }

                if (texture4 != null)
                {
                    spriteBatch.Draw(texture4, bgpos4_1, Color.White);
                    spriteBatch.Draw(texture4, bgpos4_2, Color.White);
                }

                if (texture5 != null)
                {
                    spriteBatch.Draw(texture5, bgpos5_1, Color.White);
                    spriteBatch.Draw(texture5, bgpos5_2, Color.White);
                }

                if (Global.LV == 8)
                {
                    spriteBatch.Draw(lv8_fire, aniPos, aniRec, Color.White * 0.4f);

                }
            }
            else //IF LV = 2 REVERSE DRAW ORDER 
            if (Global.LV == 2)
            {

                if (texture4 != null)
                {
                    spriteBatch.Draw(texture4, bgpos4_1, Color.White);
                    spriteBatch.Draw(texture4, bgpos4_2, Color.White);
                }

                if (texture3 != null)
                {

                    spriteBatch.Draw(texture3, bgpos3_1, Color.White);
                    spriteBatch.Draw(texture3, bgpos3_2, Color.White);

                }
            
                if (texture2 != null)
                {

                    spriteBatch.Draw(texture2, bgpos2_1, Color.White);
                    spriteBatch.Draw(texture2, bgpos2_2, Color.White);

                }

                if (texture1 != null)
                {
                    spriteBatch.Draw(texture1, bgpos1_1, Color.White);
                    spriteBatch.Draw(texture1, bgpos1_2, Color.White);
                }

            }

            if (Global.LV == 4)
                spriteBatch.Draw(credits, new Vector2(0, 0), Color.White);

            spriteBatch.End();
        }

        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            /////////////////////////////////////
            //---------ANIMATE FIRE-----------//
            ///////////////////////////////////
            if (Global.LV == 8)
            {
                delay = 70;

                if (elapsed >= delay)
                {
                    if (frames >= 5)
                    {
                        frames = 0;
                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;
                }
            }


            ///////////////////////////////////


            aniRec = new Rectangle(256 * frames, 0, 256, 512);

        }



        public void Update(GameTime gameTime)
        {

            KeyboardState keyState = Keyboard.GetState();

            if (Global.LV == 4)
            {
                timer++;
                if (timer >= 1200)
                {
                    Global.LV = 0;
                    Titlescreen.state = 1;
                    Global.pause = false;
                }
            }
            else
            {
                timer = 0;
            }


            if (Global.LV >= 10)
                Global.LV = 1;

            /////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////



            if (Global.LV == 1) //LV 1
            {

                if (Global.lvBegin == true)
                {
                    bgpos2_1.X = 0;
                    bgpos2_2.X = 1024;
                    bgpos3_1.X = 0;
                    bgpos3_2.X = 1024;


                }

                texture1 = lv1_1;
                texture2 = lv1_2;
                texture3 = lv1_3;
                texture4 = lv1_4;
                texture5 = null;

                speed1 = 10;
                speed2 = 8;
                speed3 = 6;
                speed4 = 2;
            }
            //////////////////////////////////////////////////
            if (Global.LV == 2) //LV 2
            {
                texture1 = lv2_1;
                texture2 = lv2_2;
                texture3 = lv2_3;
                texture4 = lv2_4;
                texture5 = null;

                speed1 = 10;
                speed2 = 8;
                speed3 = 6;
                speed4 = 4;
            }
            //////////////////////////////////////////////////
            if (Global.LV == 3) //LV 3
            {
                texture1 = lv3_1;
                texture2 = lv3_2;
                texture3 = null;
                texture4 = null;
                texture5 = null;

                speed1 = 4;
                speed2 = 12;
            }
            //////////////////////////////////////////////////
            if (Global.LV == 4) //LV 4
            {


                if (Global.lvBegin == true)
                {
                    bgpos2_1.X = 0;
                    bgpos2_2.X = 2048;
                    bgpos3_1.X = 0;
                    bgpos3_2.X = 2048;


                }


                texture1 = lv4_1;
                texture2 = lv4_2;
                texture3 = lv4_3;
                texture4 = null;
                texture5 = null;



                speed1 = 2;
                speed2 = 4;
                speed3 = 8;
            }
            //////////////////////////////////////////////////
            if (Global.LV == 5) //LV 5
            {


                if (Global.lvBegin == true)
                {
                    bgpos2_1.X = 0;
                    bgpos2_2.X = 1024;
                    bgpos3_1.X = 0;
                    bgpos3_2.X = 1024;


                }


                texture1 = lv5_1;
                texture2 = lv5_2;
                texture3 = lv5_3;
                texture4 = lv5_4;
                texture5 = null;



                speed1 = 2;
                speed2 = 4;
                speed3 = 6;
                speed4 = 8;

            }
            //////////////////////////////////////////////////
            if (Global.LV == 6) //LV 6
            {

                texture1 = lv6_1;
                texture2 = lv6_2;
                texture3 = lv6_3;
                texture4 = null;
                texture5 = null;



                speed1 = 2;
                speed2 = 4;
                speed3 = 6;

            }
            //////////////////////////////////////////////////
            if (Global.LV == 7) //LV 7
            {

                texture1 = lv7_1;
                texture2 = lv7_2;
                texture3 = lv7_3;
                texture4 = null;
                texture5 = null;



                speed1 = 4;
                speed2 = 6;
                speed3 = 8;

            }
            //////////////////////////////////////////////////
            if (Global.LV == 8) //LV 8
            {

                Animate(gameTime);

                if (Global.lvBegin == true)
                {

                    bgpos5_1.X = 0;
                    bgpos5_2.X = 2048;


                }


                texture1 = lv8_1;
                texture2 = lv8_2;
                texture3 = lv8_3;
                texture4 = lv8_4;
                texture5 = lv8_5;



                speed1 = 4;
                speed2 = 2;
                speed3 = 6;
                speed4 = 10;
                speed5 = 12;

            }
            //////////////////////////////////////////////////
            if (Global.LV == 9) //LV 9
            {


                texture1 = lv9_1;
                texture2 = lv9_2;
                texture3 = null;
                texture4 = null;
                texture5 = null;



                speed1 = 4;
                speed2 = 6;

            }



            Global.lvBegin = false;

            /////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////

            bgpos1_1.X = bgpos1_1.X - speed1;
            bgpos1_2.X = bgpos1_2.X - speed1;

            bgpos2_1.X = bgpos2_1.X - speed2;
            bgpos2_2.X = bgpos2_2.X - speed2;


            bgpos3_1.X = bgpos3_1.X - speed3;
            bgpos3_2.X = bgpos3_2.X - speed3;


            bgpos4_1.X = bgpos4_1.X - speed4;
            bgpos4_2.X = bgpos4_2.X - speed4;

            bgpos5_1.X = bgpos5_1.X - speed5;
            bgpos5_2.X = bgpos5_2.X - speed5;

            /////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////

            //1
            if (bgpos1_1.X <= -1024)
            {
                bgpos1_1.X = 0;
                bgpos1_2.X = 1024;
            }


            //2
            if (Global.LV != 4)
            {
                if (bgpos2_1.X <= -1024)
                {
                    bgpos2_1.X = 0;
                    bgpos2_2.X = 1024;
                }
            }
            else
            {
                if (bgpos2_1.X <= -2048)
                {
                    bgpos2_1.X = 0;
                    bgpos2_2.X = 2048;
                }

            }



            //3
            if (Global.LV != 4)
            {
                if (bgpos3_1.X <= -1024)
                {
                    bgpos3_1.X = 0;
                    bgpos3_2.X = 1024;
                }
            }
            else
            {
                if (bgpos3_1.X <= -2048)
                {
                    bgpos3_1.X = 0;
                    bgpos3_2.X = 2048;
                }
            }

            //4
            if (bgpos4_1.X <= -1024)
            {
                bgpos4_1.X = 0;
                bgpos4_2.X = 1024;
            }

            //5
            if (bgpos5_1.X <= -2048)
            {
                bgpos5_1.X = 0;
                bgpos5_2.X = 2048;
            }


        }

    }
}