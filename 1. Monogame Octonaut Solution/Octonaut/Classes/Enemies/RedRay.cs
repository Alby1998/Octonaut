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
    class RedRay
    {



        //General Vars
        public Texture2D texture, move, explosion;
        public Vector2 position;
        public int speed, count;
        public Random rand = new Random();
        public int sizeX, sizeY;




        //Tutorial Vars
        public Vector2 Position;
        public bool Active = true;
        public int Health = 1;
        public int Damage;
        public int Value;
        float enemyMoveSpeed;



        //Animation Vars
        Rectangle destRect = new Rectangle(964, 200, 34, 38);
        Rectangle sourceRect;
        float elapsed;
        float delay = 150f;
        int frames = 0;
        bool exFlag = false;






        //Collision vars
        public Rectangle boundingBox;
        public bool isColliding, flag = false;
        public static double rad;



        //Animation Vars


        /// <Variables>
        /// ///////////////////////////////////////////////////////
        /// <Variables>

        //Constructor
        public RedRay()
        {
            destRect = new Rectangle(964, 200, 34, 38);


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



        public void Initialize(Vector2 pos)
        {
            texture = null;
            move = null;
            sourceRect = new Rectangle(0, 0, 272, 38);
            speed = 4;

            count = 0;
            isColliding = false;

            position = pos;

        }

        //Load Content
        public void LoadContent(ContentManager content)
        {
            destRect = new Rectangle(964, 200, 34, 38);
            move = content.Load<Texture2D>("Enemy/RedRay/redray");
            explosion = content.Load<Texture2D>("Enemy/explosion/explosion_small");
            texture = move;
        }

        //Update
        public void Update(GameTime gameTime)
        {

            #region set original location
            //if (Global.lvBegin == true)
            // {
            // set original position at the beginning of a level
            // destRect = new Rectangle(1264, 200, 34, 38);


            //position = new Vector2(400, (int)rand.Next(200, 250));
            // }
            #endregion

            #region movement and animation
            if (Global.pause == false && Global.gamePause == false)    
            {

                if (texture == move)
                {
                    destRect = new Rectangle((int)position.X, (int)position.Y, 34, 38);
                    sizeX = 34;
                    sizeY = 38;
                }

                if (texture == explosion)
                {
                    destRect = new Rectangle((int)position.X, (int)position.Y, 60, 60);
                    sizeX = 60;
                    sizeY = 60;
                }

                if (texture != explosion)
                    position.X -= speed;

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
                    
                    {

                        if (Active)
                        {
                            if (texture == move)
                                spriteBatch.Draw(texture1, new Rectangle((int)position.X, (int)position.Y, sizeX, sizeY), sourceRect, Color.White);

                            if (texture == explosion)
                                spriteBatch.Draw(texture1, new Rectangle((int)position.X, (int)position.Y - 10, sizeX, sizeY), sourceRect, Color.White);

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


                    if (frames >= 7)
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
                sourceRect = new Rectangle(34 * frames, 0, 34, 38); // size of player

            if (texture == explosion)
                sourceRect = new Rectangle(60 * frames, 0, 60, 60);

        }
        



    }
}
