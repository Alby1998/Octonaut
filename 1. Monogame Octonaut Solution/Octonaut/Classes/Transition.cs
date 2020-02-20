using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace Octonaut
{
    class Transition
    {
        Texture2D t1, t2, t3, texture, texture2;
        Vector2 pos, pos2;
        int speed, timer, state;
        bool flag;

        //Constructor
        public Transition()
        {

            pos = new Vector2(-2048, 0);
            pos2 = new Vector2(-3072, 0);
            speed = 30;
            
            timer = 0;

            texture = null;

        }

        public void LoadContent(ContentManager content)
        {
            t1 = content.Load<Texture2D>("UI/transition/t1");
            t2 = content.Load<Texture2D>("UI/transition/t2");
            t3 = content.Load<Texture2D>("UI/transition/t3");
        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
             spriteBatch.Begin();

            if (texture != null)
                spriteBatch.Draw(texture, pos, Color.White);


            if (texture2 != null)
                spriteBatch.Draw(texture2, pos2, Color.White);





             spriteBatch.End();


        }

        //Update
        public void Update(GameTime gameTime)
        {

            KeyboardState keyState = Keyboard.GetState();

            if (Global.transitionStart == true)
            {
                state = 1;

                MediaPlayer.IsRepeating = false;

                texture = t1;
                texture2 = t2;
                pos = new Vector2(-2048, 0);
                pos2 = new Vector2(-3072, 0);

                flag = false;
                Global.transitionStart = false;
                Global.transition = true;
                




            }



            /////////////////////////////////////////////////////////////


            if (Global.transition == true)
            {
                if (state == 1)
                {

                    if (Global.pause == true) //Move 
                    {
                        pos.X = pos.X + speed;
                        pos2.X = pos2.X + speed;
                    }

                    if (pos.X >= 1024 && flag == false) //pause/start timer/move to new position
                    {
                        speed = 0;
                        texture = t3;
                        timer = 40;

                        Global.tMidPoint = true;

                        MediaPlayer.IsRepeating = true;

                        if (Global.Death == false  && Global.gamePause == false)
                        {
                            Global.LV++;
                            Global.lvBegin = true;
                        }
                        else
                        {
                            Global.LV = 0;
                            Global.Death = false;
                            Global.gamePause = false;
                            Titlescreen.state = 1;
                        }

                        Global.shield = 1000;

                        pos.X = -2048;
                        pos2.X = 0;
                        flag = true;


                    }

                    if (speed == 0)//Countdown
                    {
                        timer--;

                    }

                    if (timer <= 0)//continue
                    {
                        timer = 0;
                        speed = 30;
                        Global.lvBegin = false;


                    }




                    if (pos.X >= 1024 && flag == true)//return control
                    {
                        state = 2;
                    }




                }
                else
                if (state == 2)
                {

                    if (flag == true)
                    {
                        timer = 60;
                        flag = false;
                    }



                    if (timer == 0)
                    {
                        speed = 0;
                        texture = null;
                        texture2 = null;
                        Global.pause = false;
                        Global.lvBegin = false;
                        Global.tMidPoint = false;
                        Global.transition = false;
                    }


                    if (timer < 0)//If timer is less than 0 timer = 0
                    {
                        timer = 0;
                    }


                    if (timer > 0)//Count Down
                    {
                        timer--;
                    }




                }


            }

            

        }
    }
}
