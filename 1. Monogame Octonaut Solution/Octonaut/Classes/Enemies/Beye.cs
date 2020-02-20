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
    public class Beye
    {
        /// <Variables>
        /// ////////////////////////////////////////////////////////
        /// <Variables>

        #region General Vars
        public Texture2D texture, move, close, explosion, bomb;
        public  Vector2 position;
        public int speed;
        
        public List<Bullet> bulletList;
        #endregion

        #region Animation Vars
        Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 50f;
        int frames = 0;
        #endregion

        #region  Collision vars

        public Rectangle boundingBox;
        public bool isColliding, notactive = false, explode = false, near=false, Active= true;
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
        public Beye()
        {
           
        }
        //Initialize
        public void Initialize() {
            texture = null;
            move = null;
            position = new Vector2(1264, 200);
            speed = 2;
            sourceRect = new Rectangle(0, 0, 256, 64);
            isColliding = false;                       
        }
        //Load Content
        public void LoadContent(Texture2D character, Texture2D clo, Texture2D expl, Texture2D boom, Rectangle rec)
        {
            move = character;
            close = clo;
            explosion = expl;
            bomb = boom;
            destRect = rec;
           texture = move;
        }
        public void UnLoadContent(ContentManager content)
        {
            if (texture == explosion)
            {
                content.Unload();
            }

            texture = move;
        }

        //Update
        public void Update(GameTime gameTime)
        {


            if (Global.lvBegin == true)
            {
                // set original position at the beginning of a level
                destRect = new Rectangle(1264, 200, 64, 64);
                position = new Vector2(1264, 200);
            }

           // if (texture == explosion || texture == close || texture == bomb)
               // delay = 300f;



            if (Global.pause == false && Global.gamePause == false)   
            {
                destRect = new Rectangle((int)position.X, (int)position.Y, 64, 64);
                position.X = position.X - speed;
                if (player.position.Y > position.Y)
                {
                    position.Y += speed;
                }
                else if (player.position.Y < position.Y)
                { position.Y -= speed;
                }
                else { position.Y = player.position.Y; }



                if (position.X - player.position.X <= 80 || near)

                {
                    near = true;
                    Animate(gameTime);
                }
            }

        }
        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
                if (notactive == false)
                {
                    if (texture == bomb || texture == explosion)
                    {
                        spriteBatch.Draw(texture, destRect, sourceRect, Color.White);

                    }
                    else { spriteBatch.Draw(texture, destRect, Color.White); }
                }
            
            spriteBatch.End();
        }


        //Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            
            //-------------MOVE--------------//
            


           
                if (texture != bomb && texture != explosion)
                {
                    speed = 0;
                    texture = close;
                    /*delay = 250;

                    if (elapsed >= delay)
                    {

                        elapsed = 0;

                    }*/
                }

                animbomb(gameTime);





                ///////////////////////////////////




            

            ////////////////////////////
            /////BOUNDING CIRCLE///////
            ///////////////////////////

            

        }
        public void animbomb(GameTime gameTime)
        {

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (texture != explosion)
            {
                delay = 150;
                texture = bomb;
                if (elapsed >= delay)
                {


                    if (frames >= 3)
                    {
                        frames = 0;
                        explode = true;
                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;


                   
                }
                sourceRect = new Rectangle(64 * frames, 0, 64, 64); // size of player
            }
            if (explode)
            {
                elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                delay = 100;
                texture = explosion;
                if (elapsed >= delay)
                {


                    if (frames >= 5)
                    {
                        frames = 0;
                        notactive = true;
                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;

                }
                sourceRect = new Rectangle(64 * frames, 0, 64, 64); // size of player


            }
        }


    }
}