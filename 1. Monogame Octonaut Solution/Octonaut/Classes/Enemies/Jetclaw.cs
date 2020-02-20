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
    public class Jetclaw
    {
        /// <Variables>
        /// ////////////////////////////////////////////////////////
        /// <Variables>

        #region General Vars

        public Texture2D texture, move, bulletTexture, explosion;
        public Vector2 position;
        public int speed, bulletSpeed, count;
        public float bulletDelay, bulletF;
        public List<Bullet> bulletList;
        public Random rand;
        public int sizeX, sizeY;
        #endregion
        #region   Tutorial Vars
        public Vector2 Position;
        public bool Active = true;
        public int Health = 1;
        public int Damage;
        public int Value;
        float enemyMoveSpeed;
        #endregion
        #region Animation Vars
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 150f;
        int frames = 0;
        #endregion
        #region Collision vars
        public Rectangle boundingBox;
        public bool isColliding, flag = false;
        bool exFlag = false;
        # endregion        
        public int Width
        {
            get { return sourceRect.Width; }
        }
        public int Height
        {
            get { return sourceRect.Height; }
        }
        //Constructor
        public Jetclaw()
        {




        }
        //Initialize
        public void Initialize(Vector2 pos)
        {
            texture = null;
            move = null;
            bulletList = new List<Bullet>();
            rand = new Random();
            bulletDelay = bulletF;
            bulletSpeed = 15;
            count = 0;
            speed = 4;
            position = pos;
            position = new Vector2(1264, (int)rand.Next(55, 450));
            isColliding = false;
            destRect = new Rectangle(1264, 200, 52, 60);
            sourceRect = new Rectangle(0, 0, 208, 60);
        }
        //Load Content
        public void LoadContent(Texture2D character, Texture2D bullet, Rectangle rec, Texture2D expl)
        {
            move = character;
            bulletTexture = bullet;
            texture = move;
            destRect = rec;
            explosion = expl;
        }

        //Update
        public void Update(GameTime gameTime)
        {


            if (Global.lvBegin == true)
            {
                // set original position at the beginning of a level
                destRect = new Rectangle(1264, 200, 52, 60);
                position = new Vector2(1264, (int)rand.Next(200, 450));
            }




            #region animation
            if (Global.pause == false && Global.gamePause == false)
            {

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
                    if (position.X < -50)
                        Active = false;
                if (position.X <= 500 || flag == true)
                {
                    if (count == 0)
                    {
                        speed = 0;
                        elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                        delay = 550;



                        Shoot();
                        if (elapsed >= delay)
                        {


                            speed = 4;
                            elapsed = 0;
                            count = 1;
                        }


                    }
                    position.X = position.X + speed;
                    flag = true;
                    UpdateBullets();
                }
                else
                {

                    speed = 4;
                    position.X = position.X - speed;

                }

                if (Health > 0)
                    texture = move;

                if (Health <= 0)
                    texture = explosion;


                if (Global.LVEND == true)
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
           
                if (Active)
                {
                    if (position.X < 1030)
                    { spriteBatch.Draw(texture1, destRect, sourceRect, Color.White); }
                    
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

        #region method

        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (texture == move)
            {

                delay = 550;

                if (elapsed >= delay)
                {


                    if (frames >= 3)
                    {
                        frames = 0;

                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;

                }
                sourceRect = new Rectangle(52 * frames, 0, 52, 60); // size of player
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
                sourceRect = new Rectangle(60 * frames, 0, 60, 60); // size of explosion
            }





        }

        ////////////////////////////
        /////BOUNDING CIRCLE///////
        ///////////////////////////

        public void Shoot()
        {


            if (bulletDelay >= 0)
                bulletDelay--;

            if (bulletDelay <= 0 && texture == move)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X - 30, position.Y + 20); //start in front of the player

                newBullet.isVisible = true;

                //Limit bullets on screen to 20
                if (bulletList.Count() < 4)

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
        #endregion
    }
}