using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playerAlive = true;

            if (playerAlive)
            {
                Console.WriteLine("You are still alive!");
            }
            else
            {
                Console.WriteLine("Unfortunately, you are deceased )x");
            }

            int invulnTimer = 5;
            invulnTimer -= 2;

            if (invulnTimer > 0)
            {
                Console.WriteLine("You are invulnerable muahaha");
                if (playerAlive)
                {
                    invulnTimer -= 1;
                }
            }
            else if (invulnTimer == 0)
            {
                Console.WriteLine("You are vulnerable, BEWARE");
            }
            else if (invulnTimer < 0)
            {
                invulnTimer = 0;
            }
            Console.ReadLine();
        }
    }
}
