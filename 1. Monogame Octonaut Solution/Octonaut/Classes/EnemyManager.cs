using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Octonaut.Classes;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Octonaut.Classes
{
    class EnemyManager
    {

        //Enemies Description
        static public Texture2D enemyTexture, explosion;
        static public List<RedRay> RedRay1 = new List<RedRay>();
        static public List<Ghost> Ghost2 = new List<Ghost>();
        static public List<Jetclaw> JetClaw3 = new List<Jetclaw>();
        static public List<Beye> Beye4 = new List<Beye>();
        static public List<spring> Spring5 = new List<spring>();
        static public List<Disk> Disk6 = new List<Disk>();
        static public List<Turnbot> turn7 = new List<Turnbot>();
        static public BigTreat spin8 = new BigTreat();
        static public int select;
        //static public List<Disk> Disk6 = new List<Disk>();

        public Random rand = new Random();
        public Vector2 position;
        public int posY;
        public static float temp;
       
        //Handle the graphics info
        GraphicsDeviceManager graphics;
        //Rate at which the enemies will appear
        TimeSpan enemySpawnTime = TimeSpan.FromSeconds(2.0f);//Use to determine how fast enemy respawns;
        TimeSpan previousSpawnTime = TimeSpan.Zero;//SET THE TIME KEEPTERS TO ZERO;;
        TimeSpan enemySpawnTime1 = TimeSpan.FromSeconds(0.5f);//Use to determine how fast enemy respawns;
        TimeSpan previousSpawnTime1 = TimeSpan.Zero;//SET THE TIME KEEPTERS TO ZERO;;



        //A random number generator for position to appear
        Random random = new Random();

        //Handle Graphics info
        Vector2 graphicsInfo;

       static SoundEffect eDeath;


        public void Initialize(Texture2D texture, Texture2D ex, int type)
        {
            //graphicsInfo.X = Graphics.Viewport.Width;
            //graphicsInfo.Y = Graphics.Viewport.Height;
            enemyTexture = texture;
            explosion = ex;
            select = type;
        }

        //Load Content
        public void LoadContent(ContentManager content)
        {

            eDeath = content.Load<SoundEffect>("SFX/General/eDeath");
        }
        

        public void UpdateEnemies(GameTime gameTime, player player, ContentManager content, Double time)
        {

            if (Global.GameOver == true || Global.transitionStart == true)
            {
                Clear();
            }
            //spawn a new enemy every 1.5 sec
            enemySpawnTime = TimeSpan.FromSeconds(time);
            if (select != 8)
            {
                if ((gameTime.TotalGameTime - previousSpawnTime > enemySpawnTime) && Global.pause == false && Global.GameOver == false && !Global.wavespause)
                {

                    previousSpawnTime = gameTime.TotalGameTime;

                    posY = (int)rand.Next(100, 450);
                    if (select == 1 || select == 6)
                    {
                        for (int i = 0; i <= 160; i += 40)
                        {
                            position = new Vector2(1000 + i, posY);
                            AddEnemy(content);
                        }
                    }
                    else
                    {
                        AddEnemy(content);
                    }

                }
            }



            UpdateColission(player); //Update Collision

            //Update enemies            
            switch (select)
            {
                #region redray
                case 1:
                    for (int i = (RedRay1.Count - 1); i >= 0; i--)
                    {
                        RedRay1[i].move = enemyTexture;
                        RedRay1[i].explosion = explosion;
                        RedRay1[i].Update(gameTime);
                        if (RedRay1[i].Active == false)
                        {
                            RedRay1.RemoveAt(i);   //REMOVES ENEMY
                        }
                    }
                    break;
                #endregion
                #region ghost
                case 2:
                    for (int i = (Ghost2.Count - 1); i >= 0; i--)
                    {
                        Ghost2[i].move = enemyTexture;
                        Ghost2[i].explosion = explosion;
                        Ghost2[i].Update(gameTime);
                        if (Ghost2[i].Active == false)
                        {
                            Ghost2.RemoveAt(i);   //REMOVES ENEMY
                        }
                    }
                    break;
                #endregion
                #region JetClaw
                case 3:
                    for (int i = (JetClaw3.Count - 1); i >= 0; i--)
                    {
                        JetClaw3[i].move = enemyTexture;
                        JetClaw3[i].explosion = explosion;
                        JetClaw3[i].Update(gameTime);
                        if (JetClaw3[i].Active == false)
                        {
                            JetClaw3.RemoveAt(i);   //REMOVES ENEMY
                        }
                    }
                    break;
                #endregion
                #region Beye
                case 4:
                    for (int i = (Beye4.Count - 1); i >= 0; i--)
                    {
                        Beye4[i].move = enemyTexture;                        
                        Beye4[i].Update(gameTime);
                        if (Beye4[i].notactive == true)
                        {
                            Beye4.RemoveAt(i);   //REMOVES ENEMY
                        }
                    }

                    break;
                #endregion
                #region Spring
                case 5:
                    for (int i = (Spring5.Count - 1); i >= 0; i--)
                    {
                        Spring5[i].move = enemyTexture;
                        Spring5[i].explosion = explosion;
                        Spring5[i].Update(gameTime);
                        if (Spring5[i].Active == false)
                        {
                            Spring5.RemoveAt(i);   //REMOVES ENEMY
                        }
                    }

                    break;
                #endregion
                #region Disk
                case 6:
                    for (int i = (Disk6.Count - 1); i >= 0; i--)
                    {
                        Disk6[i].move = enemyTexture;
                        Disk6[i].explosion = explosion;
                        Disk6[i].Update(gameTime);
                        if (Disk6[i].Active == false)
                        {
                            Disk6.RemoveAt(i);   //REMOVES ENEMY
                        }
                    }
                    break;
                #endregion
                #region Turn
                case 7:
                    for (int i = (turn7.Count - 1); i >= 0; i--)
                    {
                        turn7[i].move = enemyTexture;
                        turn7[i].explosion = explosion;
                        turn7[i].Update(gameTime);
                        if (turn7[i].Active == false)
                        {
                            turn7.RemoveAt(i);   //REMOVES ENEMY
                        }
                    }
                    break;
                #endregion
                #region Spin Boss
                case 8:
                  
                        spin8.texturebig = enemyTexture;
                        spin8.texturesmall = content.Load<Texture2D>("Enemy/Bosses/Treat/small_treat");
                        spin8.explosion = explosion;

                        spin8.Update(gameTime);
                      
                        
                    
                    break;
                    #endregion
            }

        }

        public void DrawEnemies(SpriteBatch spriteBatch)
        {
            switch (select)
            {
                #region redray
                case 1:
                    for (int i = 0; i < RedRay1.Count; i++)
                    {

                        RedRay1[i].Draw(spriteBatch, RedRay1[i].texture);

                    }
                    break;
                #endregion
                #region ghost
                case 2:
                    for (int i = 0; i < Ghost2.Count; i++)
                    {

                        Ghost2[i].Draw(spriteBatch, Ghost2[i].texture);

                    }
                    break;
                #endregion
                #region JetClaw
                case 3:
                    for (int i = 0; i < JetClaw3.Count; i++)
                    {

                        JetClaw3[i].Draw(spriteBatch, JetClaw3[i].texture);

                    }
                    break;
                #endregion
                #region Beye
                case 4:
                    for (int i = 0; i < Beye4.Count; i++)
                    {

                        Beye4[i].Draw(spriteBatch);

                    }
                    break;
                #endregion
                #region Spring
                case 5:
                    for (int i = 0; i < Spring5.Count; i++)
                    {

                        Spring5[i].Draw(spriteBatch, Spring5[i].texture);

                    }
                    break;
                #endregion               
                #region Disk
                case 6:
                    for (int i = 0; i < Disk6.Count; i++)
                    {

                        Disk6[i].Draw(spriteBatch, Disk6[i].texture);

                    }
                    break;
                #endregion
                #region Turnbot
                case 7:
                    for (int i = 0; i < turn7.Count; i++)
                    {

                        turn7[i].Draw(spriteBatch, turn7[i].texture);

                    }
                    break;
                #endregion
                #region Spin Boss
                case 8:
                   
                        spin8.Draw(spriteBatch);

                   
                    break;
                    #endregion
            }

        }


        #region Method
        private void AddEnemy(ContentManager content)
        {
            //create an enemy
            switch (select)
            {

                case 1:
                    RedRay ray = new RedRay();
                    ray.Initialize(position);
                    RedRay1.Add(ray);
                    break;

                case 2:
                    Ghost ghost = new Ghost();
                    ghost.Initialize(position);
                    ghost.LoadContent(content.Load<Texture2D>("Enemy/Ghost/ghost"), content.Load<Texture2D>("player/bullets/Bullet1"));
                    Ghost2.Add(ghost);
                    break;
                case 3:
                    Jetclaw jet = new Jetclaw();
                    jet.Initialize(position);
                    jet.LoadContent(content.Load<Texture2D>("Enemy/Jetclaw/jetclaw"), content.Load<Texture2D>("player/bullets/Bullet1"), new Rectangle(1264, 200, 52, 60), content.Load<Texture2D>("Enemy/explosion/explosion_small"));
                    JetClaw3.Add(jet);
                    break;
                case 4:
                    Beye beye = new Beye();
                    beye.Initialize();
                    beye.LoadContent(content.Load<Texture2D>("Enemy/beye/beye1"), content.Load<Texture2D>("Enemy/beye/beye2"), content.Load<Texture2D>("Enemy/beye/byeExplosion"), content.Load<Texture2D>("Enemy/beye/beye3"), new Rectangle(664, 200, 64, 64));
                    beye.UnLoadContent(content);
                    Beye4.Add(beye);
                    break;
                case 5:
                    spring spring = new spring();
                    spring.Initialize();
                    spring.LoadContent(content.Load<Texture2D>("Enemy/Spring/spring"), new Rectangle(1064, 200, 54, 54));
                    Spring5.Add(spring);
                    break;
                case 6:
                    Disk disk = new Disk();
                    disk.Initialize();
                    disk.LoadContent(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"));
                    Disk6.Add(disk);
                    break;
                case 7:
                    Turnbot turn = new Turnbot();
                    turn.Initialize(rand.Next(1, 3));
                    turn.LoadContent(content.Load<Texture2D>("Enemy/Turnbot/turnbot"));
                    turn7.Add(turn);
                    break;
                case 8:
                    break;

            }
            int newY = (int)graphicsInfo.Y;




        }
        public static void UpdateColission(player player)
        {
            //use the Rectangle's build-in interscect function to determine if
            //two objects are overlapping
            Rectangle rect1, rect2;

            //Only create the rectangle once for the player
            rect1 = new Rectangle(
                (int)player.Position.X,
                (int)player.Position.Y,
                player.Width, player.Height);

            //Do the collision between the player and the enemies
            #region Enemy Collision
            switch (EnemyManager.select)
            {
                #region RedRay
                case 1:
                    for (int i = 0; i < RedRay1.Count; i++)
                    {
                        rect2 = new Rectangle(
                            (int)RedRay1[i].position.X,
                            (int)RedRay1[i].position.Y,
                            RedRay1[i].Width,
                            RedRay1[i].Height);
                        if (Global.dodge == false)
                        {
                            if (rect1.Intersects(rect2) && RedRay1[i].Health != 0)
                            {
                                //Subtract the health from the player based on the enemy damage

                                eDeath.Play();

                                if (Global.invincible == false)
                                    Global.shield -= 40 * Global.LV;

                                if (Global.panic == false)
                                    Global.invincible = true;

                                //Since the enemy collided with the player destroy it


                                RedRay1[i].Health = 0;
                            }
                        }
                    }
                    break;
                #endregion
                #region Ghost
                case 2:
                    for (int i = 0; i < Ghost2.Count; i++)
                    {
                        rect2 = new Rectangle((int)Ghost2[i].position.X, (int)Ghost2[i].position.Y, Ghost2[i].Width, Ghost2[i].Height);
                        if (rect1.Intersects(rect2) && Ghost2[i].Health != 0 && Global.dodge == false)
                        {
                            //Subtract the health from the player based on the enemy damage
                            eDeath.Play();

                            if (Global.invincible == false)
                                Global.shield -= 40 * Global.LV;


                            Global.invincible = true;

                            //Since the enemy collided with the player destroy it


                            Ghost2[i].Health = 0;
                        }
                    }
                    break;
                #endregion
                #region JetClaw
                case 3:
                    for (int i = 0; i < JetClaw3.Count; i++)
                    {
                        rect2 = new Rectangle((int)JetClaw3[i].position.X, (int)JetClaw3[i].position.Y, JetClaw3[i].Width, JetClaw3[i].Height);
                        if (rect1.Intersects(rect2) && JetClaw3[i].Health != 0 && Global.dodge == false)
                        {
                            //Subtract the health from the player based on the enemy damage
                            eDeath.Play();

                            if (Global.invincible == false)
                                Global.shield -= 40 * Global.LV;


                            Global.invincible = true;

                            //Since the enemy collided with the player destroy it


                            JetClaw3[i].Health = 0;
                        }
                    }
                    break;
                #endregion
                #region Beye
                case 4:
                    for (int i = 0; i < Beye4.Count; i++)
                    {
                        rect2 = new Rectangle((int)Beye4[i].position.X, (int)Beye4[i].position.Y, Beye4[i].Width, Beye4[i].Height);
                        if (rect1.Intersects(rect2) && Global.dodge == false)
                        {
                            //Subtract the health from the player based on the enemy damage

                            if (Global.invincible == false)
                                Global.shield -= 40 * Global.LV;


                            Global.invincible = true;
                        }
                    }
                    break;
                #endregion
                #region Spring
                case 5:
                    for (int i = 0; i < Spring5.Count; i++)
                    {
                        rect2 = new Rectangle((int)Spring5[i].position.X, (int)Spring5[i].position.Y, Spring5[i].Width, Spring5[i].Height);
                        if (rect1.Intersects(rect2) && Global.dodge == false)
                        {
                            //Subtract the health from the player based on the enemy damage

                            if (Global.invincible == false)
                                Global.shield -= 50;


                            Global.invincible = true;

                        }
                    }
                    break;
                #endregion
                #region Disk
                case 6:
                    for (int i = 0; i < Disk6.Count; i++)
                    {
                        rect2 = new Rectangle(
                            (int)Disk6[i].position.X,
                            (int)Disk6[i].position.Y,
                            Disk6[i].Width,
                            Disk6[i].Height);
                        if (Global.dodge == false)
                        {
                            if (rect1.Intersects(rect2) && Disk6[i].Health != 0)
                            {
                                //Subtract the health from the player based on the enemy damage
                                eDeath.Play();

                                if (Global.invincible == false)
                                    Global.shield -=  40 * Global.LV;

                                if (Global.panic == false)
                                    Global.invincible = true;

                                //Since the enemy collided with the player destroy it

                                Disk6[i].Health = 0;

                            }
                        }
                        rect2 = new Rectangle(
                            (int)Disk6[i].position2.X,
                            (int)Disk6[i].position2.Y,
                            Disk6[i].Width,
                            Disk6[i].Height);
                        if (Global.dodge == false)
                        {
                            if (rect1.Intersects(rect2) && Disk6[i].Health2 != 0)
                            {
                                //Subtract the health from the player based on the enemy damage
                                eDeath.Play(); //sound glitch
                                if (Global.invincible == false)
                                    Global.shield -= 50;

                                if (Global.panic == false)
                                    Global.invincible = true;

                                //Since the enemy collided with the player destroy it

                                Disk6[i].Health = 0;

                            }
                        }
                    }
                    break;
                #endregion
                #region Turnbot
                case 7:
                    for (int i = 0; i < turn7.Count; i++)
                    {
                        rect2 = new Rectangle(
                            (int)turn7[i].position.X,
                            (int)turn7[i].position.Y,
                            turn7[i].Width,
                            turn7[i].Height);
                        if (Global.dodge == false)
                        {
                            if (rect1.Intersects(rect2) && turn7[i].Health != 0)
                            {
                                //Subtract the health from the player based on the enemy damage

                                if (Global.invincible == false)
                                    Global.shield -= 50;

                                if (Global.panic == false)
                                    Global.invincible = true;

                                //Since the enemy collided with the player destroy it


                                turn7[i].Health = 0;

                                //if the player health is less than zero then player must be destroyed

                                if (player.health <= 0)
                                {

                                }
                            }
                        }
                    }
                    break;
                #endregion
                #region SpinBoss
                case 8 :
                    
                       rect2 = new Rectangle(((int)EnemyManager.spin8.recbig.X-93),((int)EnemyManager.spin8.recbig.Y - 91),186,182);
                    if (rect1.Intersects(rect2) && Global.dodge == false)
                        {
                            //Subtract the health from the player based on the enemy damage

                            if (Global.invincible == false)
                                Global.shield -= 100;


                            Global.invincible = true;
                        }



                
                         
                        BigTreat.rec3 = new Rectangle((int)BigTreat.positionbig.X+(int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[0].X-0),2)+Math.Pow((EnemyManager.spin8.originsmall[0].Y-0), 2))*Math.Cos(EnemyManager.spin8.rotationsmall)),
                                              (int)BigTreat.positionbig.Y+(int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[0].X-0),2)+Math.Pow((EnemyManager.spin8.originsmall[0].Y-0), 2))*Math.Sin(EnemyManager.spin8.rotationsmall)),
                                                64, 62);
                        BigTreat.rec4 = new Rectangle((int)BigTreat.positionbig.X - (int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[1].X +200 ), 2) + Math.Pow((EnemyManager.spin8.originsmall[1].Y -300), 2)) * Math.Cos(EnemyManager.spin8.rotationsmall)),
                                             (int)BigTreat.positionbig.Y - (int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[1].X - 0), 2) + Math.Pow((EnemyManager.spin8.originsmall[1].Y - 0), 2)) * Math.Sin(EnemyManager.spin8.rotationsmall)),
                                              64, 62);
                        BigTreat.rec5 = new Rectangle((int)BigTreat.positionbig.X + (int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[2].X + 200), 2) + Math.Pow((EnemyManager.spin8.originsmall[2].Y - 300), 2)) * Math.Cos(EnemyManager.spin8.rotationsmall)),
                                             (int)BigTreat.positionbig.Y + (int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[2].X - 50), 2) + Math.Pow((EnemyManager.spin8.originsmall[2].Y - 100), 2)) * Math.Sin(EnemyManager.spin8.rotationsmall)),
                                               64, 62);
                        BigTreat.rec6 = new Rectangle((int)BigTreat.positionbig.X - (int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[3].X - 0), 2) + Math.Pow((EnemyManager.spin8.originsmall[3].Y -200), 2)) * Math.Cos(EnemyManager.spin8.rotationsmall)),
                                             (int)BigTreat.positionbig.Y - (int)((double)Math.Sqrt(Math.Pow((EnemyManager.spin8.originsmall[3].X - 100), 2) + Math.Pow((EnemyManager.spin8.originsmall[3].Y - 0), 2)) * Math.Sin(EnemyManager.spin8.rotationsmall)),
                                               64, 62);

                        if ((rect1.Intersects(BigTreat.rec3) || rect1.Intersects(BigTreat.rec4) || rect1.Intersects(BigTreat.rec5) || rect1.Intersects(BigTreat.rec6))  && Global.dodge == false)
                        {
                            //Subtract the health from the player based on the enemy damage

                            if (Global.invincible == false)
                                   Global.shield -= 50;


                            Global.invincible = true;
                        }
                    
                        break;

               #endregion
            }
            #endregion
            


        }
      
        public static void Clear()
        {
            RedRay1.Clear();
            Ghost2.Clear();
            JetClaw3.Clear();
            Beye4.Clear();
            Spring5.Clear();
            Disk6.Clear();
            turn7.Clear();

        }
        #endregion
    }
}