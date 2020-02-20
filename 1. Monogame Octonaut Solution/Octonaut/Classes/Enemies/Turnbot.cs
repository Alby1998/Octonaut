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
    class Turnbot
    {
        #region variables
        #region General Vars
        public Texture2D texture, move, explosion;
        public Vector2 position;
        public int speedx,speedy;
        int up_down;
        #endregion

        #region  Animation Vars
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay;
        int frames = 0;
        public int Health = 1;
        public int Damage;
        #endregion
        #region Collision vars        
        public bool isColliding, flag = false, Active = true;
        #endregion region
        #endregion
        public int Width
        {
            get { return sourceRect.Width; }
        }
        public int Height
        {
            get { return sourceRect.Height; }
        }
        //Constructor
        public Turnbot()
        {

        }

        //Initialize
        public void Initialize( int up)
        {
            texture = null;
            move = null;
            Random rand = new Random();
            up_down = up;
            //position = new Vector2(1064, 200);
            speedx = 4;
            speedy = 4;
            isColliding = false;

            sourceRect = new Rectangle(0, 0, 240, 60);


            if (up_down == 1)
            {
                destRect = new Rectangle(1064, -100, 60, 60);
                position = new Vector2(1064, 0);
            }
            else
            {
                destRect = new Rectangle(1064, 600, 60, 60);
                position = new Vector2(1064, 600);
            }
        }

        //Load Content
        public void LoadContent(Texture2D character)
        {
            
            move = character;
            texture = move;
        }

        //Update
        public void Update(GameTime gameTime)
        {

          
          

            if (Global.pause == false)
            {
                destRect = new Rectangle((int)position.X, (int)position.Y, 60, 60);
                
                    position.X = position.X - speedx;
                if (position.X <= player.position.X || flag)
                {
                    flag = true;
                    speedx = 0;
                    if (up_down == 1)
                    {
                        position.Y += speedy;
                    }
                    else {
                        position.Y -= speedy;
                    }
                }
               
                
                

                /////////////
                //Animation//
                /////////////
                Animate(gameTime);

            }
        }
        //Draw
        public void Draw(SpriteBatch spriteBatch, Texture2D tex)
        {
            spriteBatch.Begin();

            if (position.X <= player.position.X || flag)
            {
                spriteBatch.Draw(tex, destRect, sourceRect, Color.White);
            }

            spriteBatch.End();
        }


        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
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

            sourceRect = new Rectangle(60 * frames, 0, 60, 60); // size of player
        }
    }
}