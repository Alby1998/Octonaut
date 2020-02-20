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
    public class BigTreat
    {
        /// <Variables>
        /// ////////////////////////////////////////////////////////
        /// <Variables>

        //General Vars
        public   Texture2D texturebig, texturesmall, move,explosion;
        public  static Vector2 positionbig, originbig, positionsmall;        
        public  Vector2[] originsmall = new Vector2[4];
        
        public static int speed, hp=3000;
        
        public Rectangle recbig, recsmall, sourceRect, sourceRect1;
        public float rotation, rotationsmall;
        public static Rectangle rec3, rec4, rec5, rec6;
      
        //Animation Vars
        float elapsed, elapsed1;
        float delay = 150f, delay1 = 150f;
        int frames = 0, frames1 = 0;
        public Vector2 Center;

        //Collision vars       
         bool  flag = false, flag1 = false;
        public static bool Active = true; 
        //movement
        int state = 0;
        bool top = false;
        Random rand = new Random();
        TimeSpan attack;//Use to determine how fast enemy respawns;
        TimeSpan previousattack = TimeSpan.Zero;//SET THE TIME KEEPTERS TO ZERO;;


        public int Width
        {
            get { return sourceRect.Width; }
        }
        public int Height
        {
            get { return sourceRect.Height; }
        }
        //Constructor
        public BigTreat()
        {      
            positionbig = new Vector2(1440,  250);            
            speed = 8 ;
        }
        public void Initialize()
        {
               
        }
        //Load Content
        public void LoadContent(Texture2D texbig, Texture2D move )
        {
            texturebig = texbig;
            texturesmall = move;
            
        }

        //Draw



        //Animation

        //Update
        public void Update(GameTime gameTime)
        {
           

            if (Global.pause == false)
            { // set original position at the beginning of a level

                 
                
             
                recbig = new Rectangle((int)positionbig.X, (int)positionbig.Y, 186, 182);
                originsmall[0] = new Vector2(140,120);//left
                originsmall[1] = new Vector2(-60, 140); //up
                
                originsmall[2] = new Vector2(-60, -80); //right
                originsmall[3] = new Vector2(+140, -60);//down
                

                originbig = new Vector2(texturebig.Width / 2, texturebig.Height / 2);
                
                rotation += 0.1f;
                rotationsmall -= 0.02f;
              
               

               
            }



            KeyboardState keyState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            if (Global.pause == false)
            {

                #region Screen Bounds
                if (positionbig.X <= 100)
                {
                    positionbig.X = 100;
                }


                #endregion
                //Movement
                if (hp <= 0)
                    texturebig = explosion;
                else
                {
                    switch (state)
                    {
                        case 0:
                            if (positionbig.X > 800)
                            {
                                positionbig.X -= speed;
                            }
                            else if (positionbig.X < 800)
                            {
                                positionbig.X += speed;
                            }
                            if (positionbig.X == 800)
                            {
                                state++;
                            }
                            break;
                        case 1:
                            if (top)
                            {
                                positionbig.Y -= 4;
                                if (positionbig.Y < 155)
                                {
                                    top = false;
                                }
                            }
                            else
                            {
                                positionbig.Y += 4;
                                if (positionbig.Y >= 420)
                                {
                                    top = true;
                                }
                            }
                            if ((gameTime.TotalGameTime - previousattack > attack) && Global.GameOver == false && !Global.wavespause)
                            {
                                attack = TimeSpan.FromSeconds(rand.Next(1, 7));
                                previousattack = gameTime.TotalGameTime;
                                state++;
                            }
                            break;
                        case 2:
                            positionbig.X -= speed;
                            if (positionbig.X <= 110)
                            {
                                state = 0;
                            }

                            break;

                    }
                }



             
                /////////////
                //Animation//
                /////////////


                Animate(gameTime);
            }

            

        
        }//Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //draws the boss
            if (Active)
            {
                if (texturebig != explosion)
                {
                    spriteBatch.Draw(texturebig, positionbig, null, Color.White, rotation, originbig, 1f, SpriteEffects.None, 0);
                    spriteBatch.Draw(texturesmall, rec3, sourceRect, Color.White);
                    spriteBatch.Draw(texturesmall, rec4, sourceRect, Color.White);
                    spriteBatch.Draw(texturesmall, rec5, sourceRect, Color.White);
                    spriteBatch.Draw(texturesmall, rec6, sourceRect, Color.White);
                }
                else
                {
                   spriteBatch.Draw(explosion, positionbig, sourceRect1, Color.White,0f, new Vector2(+20,+20), 5f, SpriteEffects.None, 0);
                }

                //draws the 4 little bosses 


            }
            else { Global.LVEND = true; }

            spriteBatch.End();
        }


        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
           
                delay = 50;
                if (elapsed > 2000)
                {
                    flag = true;
                }

                if (elapsed >= delay)
                {
                    if (frames == 7)
                    {
                        frames = 0;
                    }
                    else
                    {

                        frames++;
                    }

                    elapsed = 0;
                }
            

            sourceRect = new Rectangle(64 * frames, 0, 64, 62); // size of player

            elapsed1 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (texturebig== explosion)
            {
                delay1 = 50;
                if (elapsed1 > 2000)
                {
                    flag1 = true;
                }

                if (elapsed1 >= delay1)
                {
                    if (frames1 == 7)
                    {
                        frames1 = 0;
                        Active = false;
                    }
                    else
                    {

                        frames1++;
                    }

                    elapsed1 = 0;
                }


                sourceRect1 = new Rectangle(60 * frames1, 0, 60, 60); // size of player

            }


        }

        }


        
              
    }
