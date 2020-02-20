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
    public class Ghost
    {
        /// <Variables>
        /// ////////////////////////////////////////////////////////
        /// <Variables>

        //General Vars
        public Texture2D texture, dodge, move, bulletTexture, explosion;
        public Vector2 position;
        public int speed, bulletSpeed;
        public float bulletDelay, bulletF;
        public List<Bullet> bulletList;
        public int sizeX, sizeY;

        //Tutorial Vars

        public bool Active = true;
        public int Health = 1;
        public int Damage;
        public int Value;
        float enemyMoveSpeed;

        //Animation Vars
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 150f;
        int frames = 0;

        //Collision vars
        public Rectangle boundingBox;
        public bool isColliding, flag = false;
        public static double rad;
        bool exFlag = false;
        /// <Variables>
        /// ///////////////////////////////////////////////////////
        /// <Variables>
        public int Width
        {
            get { return sourceRect.Width; }
        }
        public int Height
        {
            get { return sourceRect.Height; }
        }
        //Constructor
        public Ghost()
        {


        }
        public void Initialize(Vector2 pos)
        {

            //movement vars
            texture = null;
            move = null;
            Random rand = new Random();
            position = pos;
            position = new Vector2(1200, rand.Next(55, 500));
            speed = 6;

            //animation vars
            bulletList = new List<Bullet>();
            bulletF = 9;
            bulletDelay = bulletF;
            bulletSpeed = 15;
            destRect = new Rectangle((int)position.X, (int)position.Y, 150, 80);
            sourceRect = new Rectangle(0, 0, 50, 80);

          
         
        }
        //Load Content
        public void LoadContent(Texture2D character, Texture2D bull)
        {
            move = character;
            bulletTexture = bull;
            texture = move;
        }

        //Draw



        //Animation

        //Update
        public void Update(GameTime gameTime)
        {


            if (Global.pause == false && Global.gamePause == false)
            { // set original position at the beginning of a level

                //  position = new Vector2(1200, 200);

                if (texture == move)
                {
                    destRect = new Rectangle((int)position.X, (int)position.Y, 52, 60);
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
                    if (flag == true)
                    {

                        Shoot();

                    }

                if (Health > 0)
                    texture = move;

                if (Health <= 0)
                    texture = explosion;


                if (Global.LVEND == true)
                    Active = false;


                if (position.X < -60)
                    Active = false;



            }

            if (Global.gamePause == false)
                UpdateBullets();


            //Screen Bounds
            if (position.Y <= 55)
            {
                position.Y = 55;
            }

            if (position.Y >= 512 - 80)
            {
                position.Y = 512 - 80;
            }


            if (Global.pause == false && Global.gamePause == false)
            {
                destRect = new Rectangle((int)position.X, (int)position.Y, 50, 80);


                /////////////
                //Animation//
                /////////////


                Animate(gameTime);

            }



        }//Draw
        public void Draw(SpriteBatch spriteBatch, Texture2D texture1)
        {
            spriteBatch.Begin();

            if (Active)
            {
                spriteBatch.Draw(texture1, destRect, sourceRect, Color.White);

            }

            Rectangle rect1 = new Rectangle((int)player.Position.X, (int)player.Position.Y, 80, 80);
            foreach (Bullet b in bulletList)
            {
                b.Draw(spriteBatch);
                Rectangle laserRectangle = new Rectangle(
                               (int)b.position.X, (int)b.position.Y, 38, 24);


                if (laserRectangle.Intersects(rect1))
                {

                    b.isVisible = false;

                    if (Global.invincible == false)
                    {
                        Global.shield -= 50;
                    }

                    Global.invincible = true;



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
            if (texture == move)
            {
                delay = 1050;
                if (position.X > 700)
                {
                    position.X -= speed;
                }


                if (elapsed >= delay)
                {
                    if (frames == 2)
                    {
                        flag = true;
                        frames = 0;
                    }
                    else
                    {
                        flag = false;

                        frames++;
                    }

                    elapsed = 0;
                }
                sourceRect = new Rectangle(50 * frames, 0, 50, 80); // size of player
            }
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
                        if (bulletList.Count() <= 0)
                            Active = false;
                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;

                }
                sourceRect = new Rectangle(60 * frames, 0, 60, 60);
            }




        }




        /////////////////////////////////////////////////////////
        //SHOOT METHOD//////////////////////////////////////////
        //////////////////

        public void Shoot()
        {

            if (bulletDelay >= 0)
                bulletDelay--;

            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X - 30, position.Y + 20); //start in front of the player

                newBullet.isVisible = true;

                //Limit bullets on screen to 20
                if (bulletList.Count() < 20)

                {
                    bulletList.Add(newBullet);
                }

            }

            //Reset Delay
            if (bulletDelay == 0)
                bulletDelay = bulletF;


        }

        ///////////////////////////////////////////////////////////
        //Update Bullets//////////////////////////////////////////
        //////////////////

        public void UpdateBullets()
        {
            //Destroy bullets when offscreen
            foreach (Bullet b in bulletList)
            {
                b.position.X = b.position.X - bulletSpeed; //Bullet Speed and Movement

                if (b.position.X <= 0)
                {
                    b.isVisible = false;
                }
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }

            }

        }
    }
}

       
