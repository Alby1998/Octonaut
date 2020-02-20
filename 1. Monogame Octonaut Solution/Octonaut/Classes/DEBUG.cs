using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Octonaut.Classes
{
    class DEBUG
    {


        //Update
        public void Update(GameTime gameTime)
        {

            //Get Keyboard State
            KeyboardState keyState = Keyboard.GetState();


            if (Global.pause == false)
            {
                /*
                 * 
                if (keyState.IsKeyDown(Keys.P))
                    Global.lvScore++;

                if (keyState.IsKeyDown(Keys.O))
                    Global.lvScore += 10000;

                if (keyState.IsKeyDown(Keys.I))
                    Global.shield -=10;

                if (keyState.IsKeyDown(Keys.U))
                    Global.lives++;

                if (keyState.IsKeyDown(Keys.L))
                   Global.LVEND = true;
                   
                
                if (keyState.IsKeyDown(Keys.N))
                    EnemySpawn.timer += 20;

               
                 */


            }

       
        }

    }
}
