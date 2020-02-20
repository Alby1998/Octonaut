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


namespace Octonaut
{

    class EnemySpawn
    {
        public static int timer = 0, pause = 0, wait = 300;
        Boolean inPause = true;
        EnemyManager RedRay = new EnemyManager();
        EnemyManager ghost = new EnemyManager();
        EnemyManager jet = new EnemyManager();
        EnemyManager beye = new EnemyManager();
        EnemyManager bot = new EnemyManager();
        EnemyManager disk = new EnemyManager();
        EnemyManager turn = new EnemyManager();
        Buff buff = new Buff();

        EnemyManager spin = new EnemyManager();
        LaserManager LazerBeams = new LaserManager();
        public bool buffActive = false;
        int c;
        public void Initialize()
        {
            
            
        }
        public void LoadContent()
        {

        }
        public void Update(SpriteBatch spriteBatch, GameTime gameTime, player octonaut, ContentManager content)
        {
            if (Global.GameOver == true || Global.lvBegin == true || Global.LV == 0)
            {
               
                c = 0;
                timer = 0;
                pause = 0;
                wait = 300;
                Global.wavespause = false;
                BigTreat.hp = 3000;
                BigTreat.Active = true;
                BigTreat.positionbig =new Vector2 (1400, 260);
            }

            switch (Global.LV)
            {

                case 1:
                    wave1(spriteBatch, gameTime, octonaut, content);
                    break;
                case 2:
                    wave2(spriteBatch, gameTime, octonaut, content);
                    break;
                case 3:
                    wave3(spriteBatch, gameTime, octonaut, content);
                    break;
            }

        }




        public void wave1(SpriteBatch spriteBatch, GameTime gameTime, player octonaut, ContentManager content)
        {

            if (Global.pause == false && Global.gamePause == false)
            {//Wave 1 RedRay
                if (timer < 1200)
                {
                    RedRay.Initialize(content.Load<Texture2D>("Enemy/RedRay/redray"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 1);
                    RedRay.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    RedRay.DrawEnemies(spriteBatch);
                    
                        

                    timer = timer + 1;
                    if (timer > 900)
                    {
                        Global.wavespause = true;
                    }
                }
                else if (timer < 2800)
                { //Wave 2 Disk
                    if (c == 0)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    disk.Initialize(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 6);
                    disk.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    disk.DrawEnemies(spriteBatch);
                    timer += 1;
                    if (timer > 2300)
                    {
                        Global.wavespause = true;
                    }
                    timer += 1;
                }
                else if (timer < 4800)
                {//Wave 3 turn
                    if (c == 1)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    turn.DrawEnemies(spriteBatch);
                    if (timer > 4200)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;
                }
                else if (timer < 6000)
                {//Wave 4 Red + Turn
                    if (c == 2)
                    {
                        c++;
                        Global.wavespause = false;
                    }

                    if (timer > 5300)
                    {
                        
                        buff.Initialize();
                        buff.LoadContent(content);
                        buff.Update(gameTime);
                        buff.Draw(spriteBatch);
                    }
                    else 
                    {
                        buff.Active = true;
                        buff.position = new Vector2(1200, 250);
                    }

                    RedRay.Initialize(content.Load<Texture2D>("Enemy/RedRay/redray"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 1);
                    RedRay.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    RedRay.DrawEnemies(spriteBatch);
                    
                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    turn.DrawEnemies(spriteBatch);


                    if (timer > 5700)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;

                }
                else if (timer < 8000)
                {// waves 5 disk + turn
                    if (c == 3)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    if (timer > 7300)
                    {
                        buffActive = true;
                        buff.Initialize();
                        buff.LoadContent(content);
                        buff.Update(gameTime);
                        buff.Draw(spriteBatch);
                    }
                   
                    else 
                    {
                    buff.Active = true;
                    buff.position = new Vector2(1200, 250);
                    }
                   

                    disk.Initialize(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 6);
                    disk.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    disk.DrawEnemies(spriteBatch);

                   
                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    turn.DrawEnemies(spriteBatch);

                    if (timer > 7700)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;

                }

                else if (timer <= 11000)
                {// waves 6  Red + disk
                    if (c == 4)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    RedRay.Initialize(content.Load<Texture2D>("Enemy/RedRay/redray"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 1);
                    RedRay.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    RedRay.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    disk.Initialize(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 6);
                    disk.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    disk.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    turn.DrawEnemies(spriteBatch);


                    if (timer > 10500)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;



                }
                else { Global.LVEND = true; }
            }

        }
        public void wave2(SpriteBatch spriteBatch, GameTime gameTime, player octonaut, ContentManager content)
        {

            if (Global.pause == false && Global.gamePause == false)
            {//Wave 1 Ghost
                if (timer < 1200)
                {
                    ghost.Initialize(content.Load<Texture2D>("Enemy/Ghost/ghost"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 2);
                    ghost.UpdateEnemies(gameTime, octonaut, content, 3.0f);
                    ghost.DrawEnemies(spriteBatch);
                    timer = timer + 1;
                    if (timer > 900)
                    {
                        Global.wavespause = true;
                    }
                }
                else if (timer < 3200)
                { //Wave 2 Ghost + Turn
                    if (c == 0)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    ghost.Initialize(content.Load<Texture2D>("Enemy/Ghost/ghost"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 2);
                    ghost.UpdateEnemies(gameTime, octonaut, content, 3.0f);
                    ghost.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    turn.DrawEnemies(spriteBatch);
                    timer += 1;
                    if (timer > 2600)
                    {
                        Global.wavespause = true;
                    }
                    timer += 1;
                }
                else if (timer < 4500)
                {//Wave 3 JetClaws + Beye
                    if (c == 1)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    if (timer > 3400)
                    {
                        buffActive = true;
                        buff.Initialize();
                        buff.LoadContent(content);
                        buff.Update(gameTime);
                        buff.Draw(spriteBatch);
                    }

                    else if (timer == 3400)
                    {
                        buff.Active = true;
                        buff.position = new Vector2(1200, 250);
                    }
                    jet.Initialize(content.Load<Texture2D>("Enemy/jetclaw/jetclaw"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 3);
                    jet.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    jet.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    beye.Initialize(content.Load<Texture2D>("Enemy/beye/beye1"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 4);
                    beye.UpdateEnemies(gameTime, octonaut, content, 5.0f);
                    beye.DrawEnemies(spriteBatch);
                    if (timer > 4000)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;
                }
                else if (timer < 5700)
                {//Wave 4 Turn + Disk
                    if (c == 2)
                    {
                        c++;
                        Global.wavespause = false;
                    }

                    disk.Initialize(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 6);
                    disk.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    disk.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    turn.DrawEnemies(spriteBatch);


                    if (timer > 5400)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;

                }
                else if (timer < 7500)
                {// waves 5 Jetclaw + Bot
                    if (c == 3)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    if (timer > 7200)
                    {
                        buffActive = true;
                        buff.Initialize();
                        buff.LoadContent(content);
                        buff.Update(gameTime);
                        buff.Draw(spriteBatch);
                    }

                    else if (timer == 7200)
                    {
                        buff.Active = true;
                        buff.position = new Vector2(1200, 250);
                    }
                    jet.Initialize(content.Load<Texture2D>("Enemy/jetclaw/jetclaw"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 3);
                    jet.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    jet.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    bot.Initialize(content.Load<Texture2D>("Enemy/Spring/spring"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 5);
                    bot.UpdateEnemies(gameTime, octonaut, content, 5.0f);
                    bot.DrawEnemies(spriteBatch);
                    if (timer > 7000)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;

                }

                else if (timer <= 9000)
                {// waves 6  JetClaws + Bot + Beye
                    if (c == 4)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    jet.Initialize(content.Load<Texture2D>("Enemy/jetclaw/jetclaw"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 3);
                    jet.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    jet.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    bot.Initialize(content.Load<Texture2D>("Enemy/Spring/spring"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 5);
                    bot.UpdateEnemies(gameTime, octonaut, content, 5.0f);
                    bot.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    beye.Initialize(content.Load<Texture2D>("Enemy/beye/beye1"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 4);
                    beye.UpdateEnemies(gameTime, octonaut, content, 5.0f);
                    beye.DrawEnemies(spriteBatch);


                    if (timer > 8500)
                    {
                        Global.wavespause = true;
                    }
                  

                    timer += 1;



                }
                else { Global.LVEND = true; }
               
            }

        }
        public void wave3(SpriteBatch spriteBatch, GameTime gameTime, player octonaut, ContentManager content)
        {

            if (Global.pause == false && Global.gamePause == false)
            {//Wave 1 Disk + Beye
                if (timer < 1300)
                {
                    RedRay.Initialize(content.Load<Texture2D>("Enemy/RedRay/redray"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 1);
                    RedRay.UpdateEnemies(gameTime, octonaut, content, 1.5f);
                    RedRay.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    beye.Initialize(content.Load<Texture2D>("Enemy/beye/beye1"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 4);
                    beye.UpdateEnemies(gameTime, octonaut, content, 4.6f);
                    beye.DrawEnemies(spriteBatch);
                    timer = timer + 1;
                    if (timer > 650)
                    {
                        Global.wavespause = true;
                    }
                }
                else if (timer < 3400)
                { //Wave 2 Bot + Turn
                    if (c == 0)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    bot.Initialize(content.Load<Texture2D>("Enemy/Spring/spring"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 5);
                    bot.UpdateEnemies(gameTime, octonaut, content, 4.0f);
                    bot.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 1.6f);
                    turn.DrawEnemies(spriteBatch);
                    timer += 1;
                    if (timer > 2600)
                    {
                        Global.wavespause = true;
                    }
                    timer += 1;
                }
                else if (timer < 5800)
                {//Wave 3 JetClaws + Beye + bot
                    if (c == 1)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    bot.Initialize(content.Load<Texture2D>("Enemy/Spring/spring"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 5);
                    bot.UpdateEnemies(gameTime, octonaut, content, 4.0f);
                    bot.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    jet.Initialize(content.Load<Texture2D>("Enemy/jetclaw/jetclaw"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 3);
                    jet.UpdateEnemies(gameTime, octonaut, content, 0.5f);
                    jet.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    beye.Initialize(content.Load<Texture2D>("Enemy/beye/beye1"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 4);
                    beye.UpdateEnemies(gameTime, octonaut, content, 5.0f);
                    beye.DrawEnemies(spriteBatch);
                    if (timer > 4400)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;
                }
                else if (timer < 6700)
                {//Wave 4  Red + Disk + Ghost
                    if (c == 2)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    if (timer > 5800)
                    {
                        buffActive = true;
                        buff.Initialize();
                        buff.LoadContent(content);
                        buff.Update(gameTime);
                        buff.Draw(spriteBatch);
                    }

                    else if (timer == 5800)
                    {
                        buff.Active = true;
                        buff.position = new Vector2(1200, 250);
                    } 
                    RedRay.Initialize(content.Load<Texture2D>("Enemy/RedRay/redray"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 1);
                    RedRay.UpdateEnemies(gameTime, octonaut, content, 1.5f);
                    RedRay.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    disk.Initialize(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 6);
                    disk.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    disk.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    ghost.Initialize(content.Load<Texture2D>("Enemy/Ghost/ghost"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 2);
                    ghost.UpdateEnemies(gameTime, octonaut, content, 2.8f);
                    ghost.DrawEnemies(spriteBatch);
                   

                    if (timer > 6400)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;

                }
                else if (timer < 8500)
                {// waves 5 Jetclaw + Bot
                    if (c == 3)
                    {
                        c++;
                        Global.wavespause = false;
                    }

                    jet.Initialize(content.Load<Texture2D>("Enemy/jetclaw/jetclaw"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 3);
                    jet.UpdateEnemies(gameTime, octonaut, content, 0.8f);
                    jet.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    bot.Initialize(content.Load<Texture2D>("Enemy/Spring/spring"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 5);
                    bot.UpdateEnemies(gameTime, octonaut, content, 3.0f);
                    bot.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    disk.Initialize(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 6);
                    disk.UpdateEnemies(gameTime, octonaut, content, 0.5f);
                    disk.DrawEnemies(spriteBatch);
                    if (timer > 8000)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;

                }

                else if (timer <= 10200)
                {// waves 6  JetClaws + Bot + Beye
                    if (c == 4)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    if (timer > 8800)
                    {
                        buffActive = true;
                        buff.Initialize();
                        buff.LoadContent(content);
                        buff.Update(gameTime);
                        buff.Draw(spriteBatch);
                    }

                    else if (timer == 8800)
                    {
                        buff.Active = true;
                        buff.position = new Vector2(1200, 250);
                    }
                    jet.Initialize(content.Load<Texture2D>("Enemy/jetclaw/jetclaw"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 3);
                    jet.UpdateEnemies(gameTime, octonaut, content, 1.0f);
                    jet.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    turn.Initialize(content.Load<Texture2D>("Enemy/Turnbot/turnbot"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 7);
                    turn.UpdateEnemies(gameTime, octonaut, content, 2.0f);
                    turn.DrawEnemies(spriteBatch);

                    LazerBeams.LoadContent(content, content.Load<SoundEffect>("SFX/General/eDeath"));
                    LazerBeams.UpdateManagerLaser(gameTime, content.Load<Texture2D>("Enemy/beye/byeExplosion"));

                    disk.Initialize(content.Load<Texture2D>("Enemy/Disk/disk"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 6);
                    disk.UpdateEnemies(gameTime, octonaut, content, 0.5f);
                    disk.DrawEnemies(spriteBatch);


                    if (timer > 9200)
                    {
                        Global.wavespause = true;
                    }

                    timer += 1;



                }
                else
                {
                    if (c == 5)
                    {
                        c++;
                        Global.wavespause = false;
                    }
                    if (BigTreat.Active)
                    {
                        spin.Initialize(content.Load<Texture2D>("Enemy/Bosses/Treat/big_treat"), content.Load<Texture2D>("Enemy/explosion/explosion_small"), 8);
                        spin.UpdateEnemies(gameTime, octonaut, content, 0f);
                        spin.DrawEnemies(spriteBatch);
                    }

                  
                }
            }

        }

    }

}



