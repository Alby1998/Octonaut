using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Octonaut.Classes
{
    class Disk
    {



        //General Vars
        public Texture2D texture, move, explosion, texture2, move2, explosion2;
        public Vector2 position, position2;
        public int speed, count;
        public Random rand = new Random();
        public int sizeX, sizeY;




        //Tutorial Vars
        public Vector2 Position;
        public bool Active = true;
        public int Health = 1, Health2 = 1;
        public int Damage;
        public int Value;
        float enemyMoveSpeed;



        //Animation Vars
        Rectangle destRect;
        Rectangle destRect2;
        Rectangle sourceRect;
        float elapsed;
        float delay = 150f;
        int frames = 0;
        bool exFlag = false;






        //Collision vars
        
        public bool isColliding, flag = false;
        



        //Animation Vars


        /// <Variables>
        /// ///////////////////////////////////////////////////////
        /// <Variables>

        //Constructor
        public Disk()
        {
            


        }
        //Initialize




        public int Width
        {
            get { return sourceRect.Width; }
        }
        public int Height
        {
            get { return sourceRect.Height; }
        }



        public void Initialize()
        {
            texture = null;
            move = null;
            texture2 = null;
            move2 = null;
            sourceRect = new Rectangle(0, 0, 192, 32);
            speed = 3;
           

            count = 0;
            isColliding = false;
            destRect = new Rectangle(464, 600, 32, 32);
            position = new Vector2(464, 600);
            destRect2 = new Rectangle(464, 0, 32, 32);
            position2 = new Vector2(464, 0);


        }

        //Load Content
        public void LoadContent(Texture2D text, Texture2D expl)
        {
            
            move = text;
            explosion = expl;
            texture = move;
            move2 = text;           
            texture2 = move;
        }

        //Update
        public void Update(GameTime gameTime)
        {

           

            #region movement and animation
            if (Global.pause == false)
            {

                if (texture == move)
                {
                    destRect = new Rectangle((int)position.X, (int)position.Y, 32, 32);
                    sizeX = 32;
                    sizeY = 32;
                }

                if (texture == explosion)
                {
                    destRect = new Rectangle((int)position.X, (int)position.Y, 60, 60);
                    sizeX = 60;
                    sizeY = 60;
                }

                if (texture2 == move2)
                {
                    destRect = new Rectangle((int)position2.X, (int)position2.Y, 32, 32);
                    sizeX = 32;
                    sizeY = 32;
                }

                if (texture2 == explosion)
                {
                    destRect = new Rectangle((int)position2.X, (int)position2.Y, 60, 60);
                    sizeX = 60;
                    sizeY = 60;
                }
                if (texture != explosion)
                {
                   
                        
                        if (position.Y <= 400)
                        { 
                            if (position.X >= 800|| flag)
                            { 
                                if (position.Y <= 300)
                                {
                                    flag = true;
                                    speed = 12;
                                    position.X -= speed;
                                position2.X -= speed;


                                }
                                else
                                {                                
                                position.Y -= speed;
                                position2.Y += speed;
                                }
                            }
                            else
                            {
                            position.X += speed;
                            position2.X += speed;
                            }
                        }else
                        {
                        position.Y -= speed;
                        position2.Y += speed;
                        }
                    
                   
                }
              

                if (Health > 0)
                    texture = move;

                if (Health <= 0)
                    texture = explosion;
                


                if (Global.LVEND == true)
                    Active = false;


                if (position.X < -50)
                    Active = false;


                /////////////
                //Animation//
                /////////////
                Animate(gameTime);

            }
            #endregion


        }
        //Draw
        public void Draw(SpriteBatch spriteBatch, Texture2D texture1)
        {

            spriteBatch.Begin();

            if (position.X > -234)
            {
                // for (int i = 0; i <= 160; i += 40)
                {

                    if (Active)
                    {
                        if (texture == move)
                            spriteBatch.Draw(texture1, new Rectangle((int)position.X/*+i*/, (int)position.Y, sizeX, sizeY), sourceRect, Color.White);
                            spriteBatch.Draw(texture1, new Rectangle((int)position2.X/*+i*/, (int)position2.Y, sizeX, sizeY), sourceRect, Color.White);

                        if (texture == explosion)
                            spriteBatch.Draw(texture1, new Rectangle((int)position.X/*+i*/, (int)position.Y - 10, sizeX, sizeY), sourceRect, Color.White);
                           // spriteBatch.Draw(texture1, new Rectangle((int)position2.X/*+i*/, (int)position2.Y - 10, sizeX, sizeY), sourceRect, Color.White);

                    }
                }



            }

            spriteBatch.End();
        }


        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation


            ///////////////////////////------------------------------->>>>>> MOVE

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (texture == move)
            {

                delay = 50;

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
            ///////////////////////////------------------------------->>>>>> EXPLOSION

            if (texture == explosion)
            {

                if (exFlag == false)
                {
                    frames = 0;
                    exFlag = true;
                }

                delay = 50;

                if (elapsed >= delay)
                {


                    if (frames >= 7)
                    {

                        Active = false;
                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;

                }

            }



            if (texture == move)
                sourceRect = new Rectangle(32 * frames, 0, 32, 32); // size of player

            if (texture == explosion)
                sourceRect = new Rectangle(60 * frames, 0, 60, 60);

        }




    }
}
