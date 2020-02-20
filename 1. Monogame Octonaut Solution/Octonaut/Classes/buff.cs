using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Octonaut
{
    public class Buff
    {



        //General Vars
        public Texture2D texture, move ;
        public Vector2 position;
        public int speed, count;
        SoundEffect powerUp;




        //Tutorial Vars
        public Vector2 Position;
        public bool Active = true;
        public int Damage;
        public int Value;
        float enemyMoveSpeed;



        //Animation Vars
        Rectangle destRect;
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
        public Buff()
        {

            position = new Vector2(1200, 250);


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
            sourceRect = new Rectangle(0, 0, 192, 48);
            speed = 4;
           

        }

        //Load Content
        public void LoadContent(ContentManager content)
        {
            destRect = new Rectangle(1200, 250, 192, 48);
            move = content.Load<Texture2D>("Buff/buff");

            powerUp = content.Load<SoundEffect>("SFX/General/powerUp");

            texture = move;
        }

        //Update
        public void Update(GameTime gameTime)
        {

          
            #region movement and animation
            if (Global.pause == false && Global.gamePause == false)
            {

                if (texture == move)
                {
                    destRect = new Rectangle((int)position.X, (int)position.Y, 48, 48);

                }

                
                if ( Active)
                    position.X -= speed;
                
                if (Global.LVEND == true)
                    Active = false;


                if (position.X < -50)
                    Active = false;


                /////////////
                //Animation//
                /////////////
                updateCollision();
                Animate(gameTime);

            }
            #endregion


        }
        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

           

                    if (Active)
                    {
                       
                            spriteBatch.Draw(move, destRect, sourceRect, Color.White);
                        
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

            }

            if (texture == move)
                sourceRect = new Rectangle(24 * frames, 0, 24, 24); // size of player

          

        }
        public  void updateCollision()
        {
            Rectangle rect1 = new Rectangle(
                  (int)player.Position.X,
                  (int)player.Position.Y,
                  80, 80);
            Rectangle rect2 = new Rectangle((int)position.X, (int)position.Y, 48, 48);
            if (rect1.Intersects(rect2) && Global.dodge == false && Active == true)
            {
                Active = false;
                powerUp.Play();
                Global.powerup = true;
            }
        }




}
}
