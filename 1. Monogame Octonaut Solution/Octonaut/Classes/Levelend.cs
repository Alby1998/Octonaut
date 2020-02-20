using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace Octonaut
{
    class Levelend
    {
        Texture2D stripMov, stripStill, stripTexture, levelC, name1, name2, name3, name4, name5, name6, name7, name8, name9, lvname, sb, gs;
        Vector2 pos, namepos, gsPos, sbPos;
        Song music_lv1, music_lv2, music_lv3, music_lvend;
        private SpriteFont font;
        int timer, shieldBonus;
        bool release, flag;

        Boolean check = false;
        int state = 0;

        //Animation Vars
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 50f;
        int frames = 0;

        int playerSpd = 3;

        Boolean musicFlag = true;


        //Constructor
        public Levelend()
        {

            
        }
        //Initialize
        public void Initialize()
        {
            pos = new Vector2(1024, 240);
            namepos = new Vector2(1024, 90);
            gsPos = new Vector2(1024, 175);
            sbPos = new Vector2(1024, 225);


            release = true;

            timer = 0;

            stripTexture = null;
            lvname = null;

            destRect = new Rectangle(0, 0, 1024, 512);
        }
        //Load Content
        //Load Content
        public void LoadContent(ContentManager content)
        {
            stripMov = content.Load<Texture2D>("UI/levelend/thestrip");
            stripStill = content.Load<Texture2D>("UI/levelend/strip");
            levelC = content.Load<Texture2D>("UI/levelend/stagecomplete2");
            gs = content.Load<Texture2D>("UI/levelend/gs");
            sb = content.Load<Texture2D>("UI/levelend/sb");

            name1 = content.Load<Texture2D>("UI/levelend/levelname/lv1name");
            name2 = content.Load<Texture2D>("UI/levelend/levelname/lv2name");
            name3 = content.Load<Texture2D>("UI/levelend/levelname/lv3name");
            name4 = content.Load<Texture2D>("UI/levelend/levelname/lv4name");
            name5 = content.Load<Texture2D>("UI/levelend/levelname/lv5name");
            name6 = content.Load<Texture2D>("UI/levelend/levelname/lv6name");
            name7 = content.Load<Texture2D>("UI/levelend/levelname/lv7name");
            name8 = content.Load<Texture2D>("UI/levelend/levelname/lv8name");
            name9 = content.Load<Texture2D>("UI/levelend/levelname/lv9name");

            music_lv1 = content.Load<Song>("Music/music_lv1");
            music_lv2 = content.Load<Song>("Music/music_lv2");
            music_lv3 = content.Load<Song>("Music/music_lv3");
            music_lvend = content.Load<Song>("Music/music_lvend");

            font = content.Load<SpriteFont>("UI/font/fontBP");

            MediaPlayer.Volume = 0.8f;

        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

            if (Global.tMidPoint == false)
            {


                if (stripTexture != null)
                    spriteBatch.Draw(stripTexture, destRect, sourceRect, Color.White);

                if (stripTexture != null)
                    spriteBatch.Draw(levelC, pos, Color.White);

                if (stripTexture != null)
                    spriteBatch.Draw(lvname, namepos, Color.White);

                if (stripTexture != null)
                    spriteBatch.Draw(gs, gsPos, Color.White);

                if (stripTexture != null)
                    spriteBatch.Draw(sb, sbPos, Color.White);

                if (stripTexture != null)
                {
                    spriteBatch.DrawString(font, "" + Convert.ToString(Global.grandScore), new Vector2(gsPos.X + 250 + 2, gsPos.Y), Color.Black);//GRAND SCORE
                    spriteBatch.DrawString(font, "" + Convert.ToString(Global.grandScore), new Vector2(gsPos.X + 250 - 2, gsPos.Y), Color.Black);//GRAND SCORE
                    spriteBatch.DrawString(font, "" + Convert.ToString(Global.grandScore), new Vector2(gsPos.X + 250, gsPos.Y + 2), Color.Black);//GRAND SCORE
                    spriteBatch.DrawString(font, "" + Convert.ToString(Global.grandScore), new Vector2(gsPos.X + 250, gsPos.Y - 2), Color.Black);//GRAND SCORE

                    spriteBatch.DrawString(font, "" + Convert.ToString(Global.grandScore), new Vector2(gsPos.X + 250, gsPos.Y), Color.White); //GRAND SCORE
                }

                if (stripTexture != null)
                {
                    spriteBatch.DrawString(font, "" + Convert.ToString(shieldBonus), new Vector2(sbPos.X + 250 + 2, sbPos.Y), Color.Black); //SHIELD BONUS
                    spriteBatch.DrawString(font, "" + Convert.ToString(shieldBonus), new Vector2(sbPos.X + 250 - 2, sbPos.Y), Color.Black); //SHIELD BONUS
                    spriteBatch.DrawString(font, "" + Convert.ToString(shieldBonus), new Vector2(sbPos.X + 250, sbPos.Y + 2), Color.Black); //SHIELD BONUS
                    spriteBatch.DrawString(font, "" + Convert.ToString(shieldBonus), new Vector2(sbPos.X + 250, sbPos.Y - 2), Color.Black); //SHIELD BONUS

                    spriteBatch.DrawString(font, "" + Convert.ToString(shieldBonus), new Vector2(sbPos.X + 250, sbPos.Y), Color.White); //SHIELD BONUS
                }

            }
             spriteBatch.End();


        }
        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            ////////////////////////////////////
            //-------------MOVE--------------//
            ///////////////////////////////////
            if (stripTexture == stripMov)
            {
                delay = 50;

                if (elapsed >= delay)
                {
                    if (frames >= 7)
                    {
                        stripTexture = stripStill;
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


            sourceRect = new Rectangle(1024 * frames, 0, 1024, 512);

        }






        //Update
        public void Update(GameTime gameTime)
        {


            /////////////
            //Animation//
            /////////////

            Animate(gameTime);


            KeyboardState keyState = Keyboard.GetState();


            /////////////////////////////////////////////////////////////////////////
            //----------------------------MUSIC-----------------------------------//
            ///////////////////////////////////////////////////////////////////////



            if (Global.LVEND == true)
            {
                MediaPlayer.Play(music_lvend);
                MediaPlayer.IsRepeating = false;
                //   musicFlag = true;
            }
            else
            {

            }


            if (Global.LV == 1 && Global.lvBegin == true && musicFlag == true)
            {
                MediaPlayer.Play(music_lv1);
                musicFlag = false;
            }


            if (Global.LV == 2 && Global.lvBegin == true && musicFlag == true)
            {
                MediaPlayer.Play(music_lv2);
                musicFlag = false;
            }

            if (Global.LV == 3 && Global.lvBegin == true && musicFlag == true)
            {
                MediaPlayer.Play(music_lv3);
                musicFlag = false;
            }

            if (Global.lvBegin == false)
                musicFlag = true;



            /////////////////////////////////////////////////////////////////////////////////////////////////////////


            if (Global.pause == false)
            {

                if (Global.LVEND == true) //pause/give textures
                {

                    stripTexture = stripMov;
                    release = false;
                    flag = false;
                    Global.pause = true;
                    shieldBonus = Global.shield;
                    Global.invincible = false;
                    state = 1;
                    Global.LVEND = false;
                }
            }

            if (keyState.IsKeyUp(Keys.L))
                release = true;



            /////////////////////////////////////////////////////////////
            //STATE 1 -----------------------MOVE STRIP AND LV COMP
            ///////////////////////////////////////////////////////////


            if (state == 1)
            {

                if (stripTexture == stripStill && pos.X > 150)
                {
                    pos.X -= 20;
                }

                if (pos.X <= 150 && destRect.Y > -150 && check == false)
                {
                    timer = 70;
                    check = true;
                }

                if (timer > 0 && check == true)//Countdown
                {
                    timer--;
                }

                if (timer <= 0 && pos.X <= 150)//Countdown End
                {
                    flag = true;
                }

                if (stripTexture == stripStill && destRect.Y > -150 && flag == true) //Move 
                {
                    destRect.Y -= 5;
                    pos.Y -= 5;
                }

                if (destRect.Y <= -150 && flag == true)
                {
                    state = 2;

                }


            }

            /////////////////////////////////////////////////////////////
            //STATE 2 ----------------------------TIMER
            ///////////////////////////////////////////////////////////
            else
            if (state == 2)
            {

                if (flag == true)
                {
                    timer = 10;
                    flag = false;
                }

                timer--;

                if (timer == 0)
                {

                    state = 3;
                }

            }

            /////////////////////////////////////////////////////////////
            //STATE 3 -------------------------MOVE LEVEL NAME
            ///////////////////////////////////////////////////////////
            else
            if (state == 3)
            {


                if (stripTexture == stripStill && namepos.X > 650)
                {
                    namepos.X -= 20;
                }

                if (namepos.X <= 650)
                {
                    state = 4;

                }

            }
            /////////////////////////////////////////////////////////////
            //STATE 4 ------------------------TIMER
            ///////////////////////////////////////////////////////////
            else
            if (state == 4)
            {
                if (flag == false)
                {
                    timer = 20;
                    flag = true;
                }

                timer--;

                if (timer == 0)
                {

                    state = 5;
                }
            }
            /////////////////////////////////////////////////////////////
            //STATE 5 --------------------MOVE SCORE
            ///////////////////////////////////////////////////////////
            else
            if (state == 5)
            {


                if (stripTexture == stripStill && gsPos.X > 312)
                {
                    gsPos.X -= 20;
                    sbPos.X -= 20;
                }

                if (gsPos.X <= 312)
                {
                    state = 6;

                }

            }
            /////////////////////////////////////////////////////////////
            //STATE 6 ---------------------TIMER
            ///////////////////////////////////////////////////////////
            else
            if (state == 6)
            {
                if (flag == true)
                {
                    timer = 70;
                    flag = false;
                }

                timer--;

                if (timer == 0)
                {



                    state = 10;
                }

            }
            //////////////////////////////////////////////////////////////////
            //STATE 7 ---------------------CHECK IF PLAYER IS OFF SCREEN
            ////////////////////////////////////////////////////////////////
            else
            if (state == 7)
            {

                if (player.destRect.X >= 1024)
                    state = 8;


            }
            /////////////////////////////////////////////////////////////
            //STATE 8 ---------------------TRANSITION
            ///////////////////////////////////////////////////////////
            else
            if (state == 8)
            {
                Global.transitionStart = true;

                state = 9;

            }








            /////////////////////////////////////////////////////////////
            //STATE 10 ---------------------CALCULATE POINTS
            ///////////////////////////////////////////////////////////
            else
            if (state == 10)
            {

                if (Global.lvScore > 0)
                {


                    if (Global.lvScore >= 100000)
                    {
                        Global.lvScore -= 10000;
                        Global.grandScore += 10000;
                    }
                    else
                    if (Global.lvScore >= 10000 && Global.lvScore < 100000)
                    {
                        Global.lvScore -= 1000;
                        Global.grandScore += 1000;
                    }
                    else
                    if (Global.lvScore >= 1000 && Global.lvScore < 10000)
                    {
                        Global.lvScore -= 100;
                        Global.grandScore += 100;
                    }
                    else
                    if (Global.lvScore < 1000)
                    {
                        Global.lvScore -= 10;
                        Global.grandScore += 10;
                    }
                    else
                    if (Global.lvScore < 100)
                    {
                        Global.lvScore--;
                        Global.grandScore++;
                    }

                }
                else
                {

                    if (shieldBonus > 0)
                    {

                        if (shieldBonus > 100)
                        {
                            shieldBonus -= 10;
                            Global.grandScore += 10;
                        }
                        else
                        {
                            shieldBonus--;
                            Global.grandScore++;
                        }
                    }

                    if (shieldBonus < 0)
                        shieldBonus = 0;

                }




                if (Global.lvScore <= 0 && shieldBonus <= 0)
                    state = 11;

            }
            /////////////////////////////////////////////////////////////
            //STATE 6 ---------------------TIMER
            ///////////////////////////////////////////////////////////
            else
            if (state == 11)
            {
                if (flag == false)
                {
                    timer = 70;
                    flag = true;
                }

                timer--;

                if (timer == 0)
                {



                    state = 7;
                }

            }




            ////////////////////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////
            //--------------------PLAYER STATE------------------------//
            ///////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////////////////

            if (state == 1 || state == 2 || state == 3 || state == 4 || state == 5 || state == 6)
            {

                if (check == true) // MOVE PLAYER TO BOTTOM LEFT POSITION
                {
                    if (player.destRect.X > 64)
                        player.destRect.X -= 3;

                    if (player.destRect.Y > 290)
                        player.destRect.Y -= 3;

                    if (player.destRect.X < 64)
                        player.destRect.X += 3;

                    if (player.destRect.Y < 290)
                        player.destRect.Y += 3;
                }
            }

            if (state == 7) // MOVE PLAYER FORWARD
            {
                if (player.destRect.X < 1024)
                {
                    player.destRect.X += playerSpd;


                    if (playerSpd <= 20)
                        playerSpd++;
                }




                if (player.destRect.X > 600 && player.destRect.Y > 0) // MOVE PLAYER UP AND CHANGE TO DODGE ANIMATION
                {
                    player.texture = player.dodge;
                    player.destRect.Y -= 16;
                }
            }




            if (state == 9) // MOVE PLAYER BACK INTO VIEW
            {



                if (player.destRect.X > 1024 && player.destRect.Y < 0)
                {
                    player.destRect.X = -80;
                    player.destRect.Y = 200;
                    player.position.X = 64;
                    player.position.Y = 200;
                    timer = 200;
                }


                if (timer > 0)
                    timer--;


                if (timer == 0)
                {
                    if (player.destRect.X < 64)
                    {
                        player.destRect.X += 8;
                    }

                }



                if (player.destRect.X >= 64 && player.destRect.Y <= 200)
                    state = 0;



            }










            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            if (timer <= 0)//continue Timer
            {
                timer = 0;
            }

            if (Global.tMidPoint == true) //Reset Position
            {
                stripTexture = null;
                pos = new Vector2(1024, 240);
                namepos = new Vector2(1024, 90);
                gsPos = new Vector2(1024, 175);
                sbPos = new Vector2(1024, 225);
                destRect = new Rectangle(0, 0, 1024, 512);
                check = false;
                playerSpd = 3;

            }

            ////////////////////////////////////////////////////
            // SET LEVEL NAME
            ///////////////////////////////////////////////////

            switch (Global.LV)
            {
                case 1:
                    lvname = name1;
                    break;
                case 2:
                    lvname = name2;
                    break;
                case 3:
                    lvname = name3;
                    break;
                case 4:
                    lvname = name4;
                    break;
                case 5:
                    lvname = name5;
                    break;
                case 6:
                    lvname = name6;
                    break;
                case 7:
                    lvname = name7;
                    break;
                case 8:
                    lvname = name8;
                    break;
                case 9:
                    lvname = name9;
                    break;
                default:
                    lvname = null;
                    break;
            }

         
         


        }
    }
}
