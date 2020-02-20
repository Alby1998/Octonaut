using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


using Microsoft.Xna.Framework.Content;
namespace Octonaut
{
    public class player
    {

        /// <Variables>
        /// ////////////////////////////////////////////////////////
        /// <Variables>
        #region General Vars
        public static Texture2D texture, dodge, move, spin, gameover;
        public Texture2D bulletTexture, bullet1, bullet2;
        public static Vector2 position;
        public int speed, coolDown, bulletSpeed;
        public float bulletDelay, bulletF;
        public static List<Bullet> bulletList;
        public int health = 0;
        public Rectangle rect1;
        public static Vector2 gmPos;
        public static int gmTimer = 2000;
        SoundEffect sd_shoot, sd_panic, sd_death, sd_shield;
        SoundEffectInstance panic_Instance;
        int powerupTimer;
        #endregion


        #region  Animation Vars
        public static Rectangle destRect;
        Rectangle sourceRect;
        float elapsed;
        float delay = 150f;
        int frames = 0;


        //Invincible
        Color flash = Color.White;
        int flashCount = 0;
        int flashTimer;
        float flashElapsed;
        float flashDelay = 50f;
        bool flashFlag = true;
        #endregion


        //RESET PANIC
        int panicTimer;
        bool panicFlag = true;

        bool deathFlag = true;




        #region  Collision vars
        public Rectangle boundingBox;
        public bool isColliding = false, flag = false;
        public static double rad;
        #endregion
        public static Vector2 Position
        {
            get { return position; }
            set { value = position; }
        }
        public int Width
        {
            get { return sourceRect.Width; }
        }
        public int Height
        {
            get { return sourceRect.Height; }
        }


        //Constructor
        public player()
        {

        }

        //Initialize
        public void Initialize()
        {
            bulletList = new List<Bullet>();
            texture = null;
            move = null;
            dodge = null;
            position = new Vector2(64, 200);
            gmPos = new Vector2(1024, 256);
            speed = 6;

            bulletF = 12;//9
            bulletDelay = bulletF;
            bulletSpeed = 15;

            coolDown = 0;
            isColliding = false;
            
        }
        //Load Content
        public void LoadContent(Texture2D character, Texture2D dod, Texture2D death, Texture2D bull1, Texture2D bull2, Texture2D GM, Rectangle Rec, SoundEffect shot, SoundEffect panic_beep, SoundEffect octoDead, SoundEffect shield)
        {
            move = character;
            dodge = dod;
            spin = death;
            gameover = GM;
            bullet1 = bull1;
            bullet2 = bull2;

            destRect = Rec;

            texture = move;
            bulletTexture = bullet1;

            sd_shoot = shot;
            sd_panic = panic_beep;
            sd_shield = shield;
            sd_death = octoDead;

            panic_Instance = sd_panic.CreateInstance();
            panic_Instance.IsLooped = true;
            SoundEffect.MasterVolume = 1;



        }
        //Update
        public void Update(GameTime gameTime)
        {
            //Get Controller State
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            //Get Keyboard State
            KeyboardState keyState = Keyboard.GetState();


            if(Global.powerup == true)
            {
                powerupTimer++;
                bulletF = 6;

                if (powerupTimer >= 600)
                    Global.powerup = false;

            }
            else
            {
                bulletF = 12;
                powerupTimer = 0;
            }



            #region set initial position
            if (Global.lvBegin == true)
            {
                // set original position at the beginning of a level
                destRect = new Rectangle(64, 200, 80, 80);
                position = new Vector2(64, 200);

                gmPos = new Vector2(1024, 256);
                gmTimer = 2000;
                Global.invincible = false;
                Global.Death = false;
                Global.shield = 1000;
                Global.lvScore = 0;

                if (Global.LV == 1)
                    Global.lives = 3;
            }
            #endregion

            #region Controls
            #region skill
            if (Global.pause == false && Global.Death == false)
            {


                if (texture == move)
                {
                    if (keyState.IsKeyDown(Keys.Z) || gamePadState.Buttons.A == ButtonState.Pressed)
                    {
                        Shoot();
                    }
                }
               
                if (Keyboard.GetState().IsKeyDown(Keys.J) || flag == true)
                {
                    // takeDamage(shield, Edamage);
                    flag = true;
                }

                /* if (shield <= 0)// use count to see if it as alredy become panic
                 {

                     Panic();
                 }*/

                /* if (Keyboard.GetState().IsKeyDown(Keys.K))
                {
                    flag = false;
                    speed = 6;

                }*/
                #endregion region


                #region movement
               // position.X += gamePadState.ThumbSticks.Left.X * speed;   //Analouge
               // position.Y -= gamePadState.ThumbSticks.Left.Y * speed;
                //if (gamePadState.IsConnected)
               // {
                    if (keyState.IsKeyDown(Keys.Down) || gamePadState.DPad.Down == ButtonState.Pressed) //Down
                    {
                        position.Y += speed;

                        if (keyState.IsKeyDown(Keys.Up) || gamePadState.DPad.Up == ButtonState.Pressed)
                            position.Y -= speed;
                    }

                    if (keyState.IsKeyDown(Keys.Up) || gamePadState.DPad.Up == ButtonState.Pressed)
                    {

                        position.Y -= speed;
                    }

                    if (keyState.IsKeyDown(Keys.Right) || gamePadState.DPad.Right == ButtonState.Pressed) //RIGHT
                    {
                        position.X += speed;

                        if (keyState.IsKeyDown(Keys.Left) || gamePadState.DPad.Left == ButtonState.Pressed)
                            position.X -= speed;
                    }

                    if (keyState.IsKeyDown(Keys.Left) || gamePadState.DPad.Left == ButtonState.Pressed)
                    {
                        position.X -= speed;

                    }
                //}
                #endregion
            }

            #region dodge
            if (Global.coolDownTime == false && Global.pause == false && Global.Death == false)
            {
                if (keyState.IsKeyDown(Keys.X) || gamePadState.Buttons.B == ButtonState.Pressed || gamePadState.Buttons.X == ButtonState.Pressed)
                {
                    texture = dodge;
                    Global.dodge = true;
                }
            }

            if (texture == dodge)
            {
                speed = 4;
            }
            else
            {
                speed = 6;
            }
            #endregion
            #endregion            

            #region Screen Bounds
            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X >= 1024 - 80)
            {
                position.X = 1024 - 80;
            }

            if (position.Y <= 55)
            {
                position.Y = 55;
            }

            if (position.Y >= 512 - 80)
            {
                position.Y = 512 - 80;
            }
            #endregion

            //---------------------------------------------------SET FLASH TRANSPARANCY//

            if (Global.pause == false && Global.Death == false && Global.gamePause == false)
            {
                if (Global.invincible == false)
                    flashCount = 2;

                if (Global.invincible == true)
                    Flash(gameTime);

                if (flashCount == 0)
                {
                    flash = Color.White * 0.8f;
                }

                if (flashCount == 1)
                {
                    flash = Color.White * 0.5f;
                }

                if (flashCount == 2)
                {
                    flash = Color.White;
                }


                if (Global.invincible == true)
                {

                    if (flashFlag == true)
                    {
                        flashTimer = 100;
                        flashFlag = false;
                    }

                    if (flashTimer > 0)
                        flashTimer--;

                    if (flashTimer <= 0)
                    {
                        flashTimer = 100;
                        Global.invincible = false;
                    }

                }
                else
                {
                    flashFlag = true;
                    flashTimer = 100;
                }

                ///////////////---------------------------------------------------------------->>Reset Shield

                if (Global.panic == true)
                {

                    if (panicFlag == true)
                    {
                        panicTimer = 600;
                        panic_Instance.Play();///////////////////////----->
                       
                        panicFlag = false;
                    }

                    if (panicTimer > 0)
                        panicTimer--;

                    if (panicTimer <= 0)
                    {
                        panic_Instance.Stop();///////////////////////----->
                        sd_shield.Play();
                        Global.shield = 1;
                    }

                }
                else
                {
                    panicFlag = true;
                    panicTimer = 600;
                }






                destRect = new Rectangle((int)position.X, (int)position.Y, 80, 80);


            }

            if (Global.gamePause == false)
            {

                //STOP FLASHING IF LV ENDS
                if (Global.LVEND == true)
                {
                    flashCount = 2;
                    flash = Color.White;
                }


                //Fix spawning with death animation
                if (Global.Death == false && texture == spin)
                    texture = move;


                /////////////
                //Animation//
                /////////////

                Animate(gameTime);
                UpdateBullets();
                Death();

            }

        }
        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destRect, sourceRect, flash);

            foreach (Bullet b in bulletList)
                b.Draw(spriteBatch);

            if (Global.GameOver == true)
            spriteBatch.Draw(gameover, gmPos, Color.White);

            spriteBatch.End();
        }

        #region methods
        #region  Animation
        private void Animate(GameTime gameTime)
        {
            //Animation

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            ////////////////////////////////////
            //-------------MOVE--------------//
            ///////////////////////////////////
            if (texture == move)
            {
                delay = 150;

                if (elapsed >= delay)
                {
                    if (frames >= 1)
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
            ////////////////////////////////////
            //-------------Dodge--------------//
            ///////////////////////////////////
            else if (texture == dodge)
            {
                delay = 50;

                if (elapsed >= delay)
                {
                    if (frames >= 15)
                    {
                        texture = move;
                        Global.dodge = false;
                        frames = 0;
                    }
                    else
                    {
                        frames++;
                    }

                    elapsed = 0;
                }

            }
            ////////////////////////////////////
            //-------------Death-------------//
            ///////////////////////////////////
            else if (texture == spin)
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
            


            ///////////////////////////////////


            sourceRect = new Rectangle(80 * frames, 0, 80, 80); // size of player

        }
        #endregion

        #region Shooting metod
        public void Shoot()
        {

            if (bulletDelay >= 0)
                bulletDelay--;

            if (bulletDelay <= 0)
            {
                Bullet newBullet = new Bullet(bulletTexture);
                newBullet.position = new Vector2(position.X + 60, position.Y + 20); //start in front of the player
                sd_shoot.Play(); // play shot sound
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
                b.position.X = b.position.X + bulletSpeed; //Bullet Speed and Movement

                if (b.position.X >= 1024)
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

       
        private void Flash(GameTime gameTime)
        {
            //FLASH

            flashElapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            ////////////////////////////////////
            //-------------Flash--------------//
            ///////////////////////////////////
            if (Global.invincible == true)
            {
                flashDelay = 50;

                if (flashElapsed >= flashDelay)
                {
                    if (flashCount >= 1)
                    {
                        flashCount = 0;
                    }
                    else
                    {
                        flashCount++;
                    }

                    flashElapsed = 0;
                }
            }


        }
        
        public void Death()
        {
            if (Global.shield < 0 && Global.panic == true && Global.invincible == false && deathFlag == true)
            {
                Global.Death = true;
                panic_Instance.Stop();///////////////////////----->
                sd_death.Play();
                deathFlag = false;
            }

          

            if (Global.Death == true)
            {


                if (Global.lives > 0)
                {
                    if (destRect.Y < 600)
                    {
                        texture = spin;

                        position.X -= 4;
                        position.Y += 4;
                        destRect.X -= 4;
                        destRect.Y += 4;
                    }
                    else
                    {
                        texture = move;
                        Global.invincible = true; 
                        Global.shield = 1000;
                        destRect = new Rectangle(64, 200, 80, 80);
                        position = new Vector2(64, 200);
                        Global.lives -= 1;
                        deathFlag = true;
                        Global.Death = false;
                    }
                }

                if (Global.lives <= 0)
                {
                    if (destRect.Y < 600)
                    {
                        texture = spin;

                        position.X -= 4;
                        position.Y += 4;
                        destRect.X -= 4;
                        destRect.Y += 4;
                    }
                    else
                    {
                        texture = move;
                        deathFlag = true;
                        Global.panic = false;
                        Global.GameOver = true;

                        if(gmPos.X > 430)
                           gmPos.X -= 10;

                        if (gmTimer > 0)
                            gmTimer -= 10;

                        if (gmTimer <= 0)
                        {
                            Global.pause = true;
                            Global.transitionStart = true;
                            gmTimer = 2000;
                        }
                    }
                }

                //Fix spawning with death animation
                if (Global.Death == false && texture == spin)
                    texture = move;

            }

        }

#endregion

    }


}


