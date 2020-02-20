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
    class spring
    {
        #region variables
        #region General Vars
        public Texture2D texture, move,explosion;
        public   Vector2 position;
        public int speedy, speedx;
        #endregion

        #region  Animation Vars
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay ;
        int frames = 0;
        #endregion
        #region Collision vars        
        public bool isColliding, flag = false,Active = true;
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
        public spring()
        {
            
        }

        //Initialize
        public void Initialize()
        {
            texture = null;
            move = null;

            position = new Vector2(1064, 200);           
            speedy = 4;
            speedx = 1;
            isColliding = false;
           
            sourceRect = new Rectangle(0, 0, 200, 54);
        }

        //Load Content
        public void LoadContent(Texture2D character, Rectangle rec)
        {
            destRect = rec;
            move = character;          
            texture = move;
        }

        //Update
        public void Update(GameTime gameTime)
        {

            if (Global.lvBegin == true)
            {
                // set original position at the beginning of a level
                destRect = new Rectangle(1064, 200, 54, 54);
                position = new Vector2(1064, 200);
            }
            
            if (Global.pause == false )
            {
                destRect = new Rectangle((int)position.X, (int)position.Y, 54, 54);                
                    
                    position.X = position.X - speedx;
                    if(  flag)
                {
                    position.Y -= speedy;
                    if(position.Y < 54)
                    {
                        flag = false;
                    }
                }
                else
                {
                    position.Y += speedy;
                    if(position.Y>= 450)
                    {
                        flag = true;
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
            
                if (position.X > -54)
                {                   
                        spriteBatch.Draw(tex,  destRect, sourceRect, Color.White);                    
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
            
            sourceRect = new Rectangle(54 * frames, 0, 54, 54); // size of player
        }              
    }
}
