using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;


namespace Octonaut.Classes
{

    class LaserManager
    {
        //Enemies Description
        static Texture2D laserTexture;
        static Rectangle laserRectangle;
        static public List<Bullet> laserBeams;
        const float SECONDS_IN_MINUTE = 60f;
        const float RATE_OF_FIRE = 200f;
        public SoundEffect eDeath, eDeath2;

        // govern how fast our laser can fire.
        static TimeSpan laserSpawnTime = TimeSpan.FromSeconds(SECONDS_IN_MINUTE / RATE_OF_FIRE);
        static TimeSpan previousLaserSpawnTime;

        //Handle the graphics info
        GraphicsDeviceManager graphics;
        //Handle Graphics info
        static Vector2 graphicsInfo;

        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        // Gamepad states used to determine button presses
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        public void LoadContent(ContentManager Content, SoundEffect death)
        {
            eDeath2 = death;
        }

        public void Initialize(Texture2D texture, GraphicsDevice Graphics)
        {
            laserBeams = new List<Bullet>();
            previousLaserSpawnTime = TimeSpan.Zero;
            laserTexture = texture;
            graphicsInfo.X = Graphics.Viewport.Width;
            graphicsInfo.Y = Graphics.Viewport.Height;
        }



        public void UpdateManagerLaser(GameTime gameTime, Texture2D ex)
        {
            if (eDeath2 != null)
            {
                eDeath = eDeath2;
            }

            //Save the previous state of the keyboard and game pad so we can determine single key/button presses
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            //Read the current state of the keyboard and gamepad and store it
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            currentKeyboardState = Keyboard.GetState();

            switch (EnemyManager.select)
            {
                #region RedRay
                case 1:
                    foreach (RedRay enemy in EnemyManager.RedRay1)
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle = new Rectangle(
                            (int)enemy.position.X,
                            (int)enemy.position.Y,
                            enemy.Width,
                            enemy.Height);

                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {


                                if (enemy.Health != 0)
                                {
                                    L.isVisible = false;
                                    Global.lvScore += 20;

                                    if(eDeath != null)
                                        eDeath.Play();
                                }
                               
                                enemy.Health = 0;
                               
                               
                            }
                        }
                    }
                    break;
                #endregion
                #region Ghost

                case 2:
                    foreach (Ghost enemy in EnemyManager.Ghost2)
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle = new Rectangle(
                            (int)enemy.position.X,
                            (int)enemy.position.Y,
                            enemy.Width,
                            enemy.Height);

                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {


                                if (enemy.Health != 0)
                                {
                                    enemy.Health = 0;
                                    Global.lvScore += 20;
                                    if (eDeath != null)
                                        eDeath.Play();
                                    L.isVisible = false;
                                }
                            }
                        }
                    }

                    break;
                #endregion
                #region JetClaw
                case 3:
                
                    foreach (Jetclaw enemy in EnemyManager.JetClaw3)
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle = new Rectangle(
                            (int)enemy.position.X,
                            (int)enemy.position.Y,
                            enemy.Width,
                            enemy.Height);

                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {


                                if (enemy.Health != 0)
                                {
                                    L.isVisible = false;
                                    Global.lvScore += 20;
                                    if (eDeath != null)
                                        eDeath.Play();
                                }
                                // enemy.explosion = ex;
                                enemy.Health = 0;
                                // enemy.Active = false;

                            }
                        }
                    }
                    break;

                    
                #endregion
                #region Beye
                case 4:

                    foreach (Beye enemy in EnemyManager.Beye4)
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle = new Rectangle(
                            (int)enemy.position.X,
                            (int)enemy.position.Y,
                            enemy.Width,
                            enemy.Height);

                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {


                               
                                    L.isVisible = false;
                                    //Global.lvScore += 20;                              
                               
                            }
                        }
                    }
                    break;
                #endregion
                #region Spring
                case 5:
                    foreach (spring enemy in EnemyManager.Spring5)
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle = new Rectangle(
                            (int)enemy.position.X,
                            (int)enemy.position.Y,
                            enemy.Width,
                            enemy.Height);
                        
                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {



                                L.isVisible = false;
                               // Global.lvScore += 20;

                            }
                        }
                    }
                    break;
                #endregion
                #region Disk
                case 6:
                    foreach (Disk enemy in EnemyManager.Disk6)
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle = new Rectangle(
                            (int)enemy.position.X,
                            (int)enemy.position.Y,
                            enemy.Width,
                            enemy.Height);

                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {

                                if (enemy.Health != 0)
                                {

                                    L.isVisible = false;
                                    Global.lvScore += 20;
                                    enemy.Health = 0;
                                    if (eDeath != null)
                                        eDeath.Play();
                                }
                            }
                        }
                        enemyRectangle = new Rectangle(
                            (int)enemy.position2.X,
                            (int)enemy.position2.Y,
                            enemy.Width,
                            enemy.Height);

                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {



                                if (enemy.Health != 0)
                                {
                                    L.isVisible = false;
                                    Global.lvScore += 20;
                                    enemy.Health = 0;
                                    if (eDeath != null)
                                        eDeath.Play();
                                }
                            }
                        }
                    }
                    break;
                #endregion
                #region Turnbot
                case 7:
                    foreach (Turnbot enemy in EnemyManager.turn7)
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle = new Rectangle(
                            (int)enemy.position.X,
                            (int)enemy.position.Y,
                            enemy.Width,
                            enemy.Height);

                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {
                                    L.isVisible = false;
                                    //Global.lvScore += 20;
                                
                             
                            }
                        }
                    }
                    break;
                #endregion
                #region Spin Boss
                case 8:
                   
                    {
                        //create a retangle for the enemy
                        Rectangle enemyRectangle =  new Rectangle(((int)EnemyManager.spin8.recbig.X - 93), ((int)EnemyManager.spin8.recbig.Y - 91), 186, 182);


                        // now see if this enemy collide with any laser shots
                        foreach (Bullet L in player.bulletList)
                        {
                            // create a rectangle for this laserbeam
                            laserRectangle = new Rectangle(
                            (int)L.position.X, (int)L.position.Y, 38, 24);


                            if (laserRectangle.Intersects(enemyRectangle))
                            {
                                L.isVisible = false;
                                Global.lvScore += 20;
                                BigTreat.hp -= 50;
                              
                                if (eDeath != null)
                                    eDeath.Play();
                            }
                            if (laserRectangle.Intersects(BigTreat.rec3))
                            {
                                L.isVisible = false;  
                            }
                            if (laserRectangle.Intersects(BigTreat.rec4))
                            {
                                L.isVisible = false;
                            }
                            if (laserRectangle.Intersects(BigTreat.rec5))
                            {
                                L.isVisible = false;
                            }
                            if (laserRectangle.Intersects(BigTreat.rec6))
                            {
                                L.isVisible = false;
                            }
                        }
                    }
                    break;
                    #endregion
            }

            // detect collisions between the player and all enemies.



        }
                }
            }
        
