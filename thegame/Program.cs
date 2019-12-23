using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thegame
{
    class Program
    {
        //Attributes / Variables
        static int playerPosX = 1, playerPosY = 1;
        static int enemyPosX = 5, enemyPosY = 7;
        static int length = 8, height = 8;
        static char player = '0', enemy = 'x', space = '.';
        static int actionNumber = 1;
        static bool inCombat = false;
        static int enemyHealth = 10;

        //Main game
        static void Main(string[] args)
        {
            while (inCombat == false)
            {
                Draw();
                if (playerPosX == enemyPosX && playerPosY == enemyPosY)
                {
                    inCombat = true;
                    Combat();
                }
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                    if ((keyPressed.Key == ConsoleKey.W && playerPosY != 1) || (keyPressed.Key == ConsoleKey.S && playerPosY != height))
                    {
                        playerPosY += (keyPressed.Key == ConsoleKey.S) ? 1 : -1;
                    }
                    if ((keyPressed.Key == ConsoleKey.A && playerPosX != 1) || (keyPressed.Key == ConsoleKey.D && playerPosX != length))
                    {
                        playerPosX += (keyPressed.Key == ConsoleKey.D) ? 1 : -1;
                    }
            }
            if (inCombat == true)
            {
                Combat();
            }
        }
        //Draw the game
        static void Draw()
        {
            Console.Clear();
            Console.WriteLine("player ("+playerPosX+","+playerPosY+")");
            if (enemyPosX != 0 && enemyPosY != 0)
            {
                Console.WriteLine("enemy (" + enemyPosX + "," + enemyPosY + ")");
            }
            for (int y = 1; y<= height; y++)
            {
                for (int x = 1; x <= length; x++)
                {
                    if (x == playerPosX && y == playerPosY)
                    {
                        Console.Write(player);
                    }

                    else if (x == enemyPosX && y == enemyPosY)
                    {
                        Console.Write(enemy);
                    }
                    else Console.Write(space);
                }
                Console.WriteLine();
            }
        }
    
        //Combat system
        static void Combat()
        {
            actionNumber = 1;
            while (inCombat == true)
            {
                
                Console.Clear();
                Draw();

                if (actionNumber == 1)
                {
                    Console.WriteLine("(FIGHT)     SPARE ");
                }
                if (actionNumber == 2)
                {
                    Console.WriteLine(" FIGHT     (SPARE)");
                }

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.Enter && actionNumber == 1)
                {
                    actionNumber = 1;
                    while (inCombat == true)
                    {

                        Console.Clear();

                        Console.WriteLine("Enemy:");
                        Console.WriteLine("Health: ");
                        if (enemyHealth == 10) { Console.WriteLine("-x|##########|x-"); }
                        if (enemyHealth == 9) { Console.WriteLine("-x|#########-|x-"); }
                        if (enemyHealth == 8) { Console.WriteLine("-x|########--|x-"); }
                        if (enemyHealth == 7) { Console.WriteLine("-x|#######---|x-"); }
                        if (enemyHealth == 6) { Console.WriteLine("-x|######----|x-"); }
                        if (enemyHealth == 5) { Console.WriteLine("-x|#####-----|x-"); }
                        if (enemyHealth == 4) { Console.WriteLine("-x|####------|x-"); }
                        if (enemyHealth == 3) { Console.WriteLine("-x|###-------|x-"); }
                        if (enemyHealth == 2) { Console.WriteLine("-x|##--------|x-"); }
                        if (enemyHealth == 1) { Console.WriteLine("-x|#---------|x-"); }
                        if (enemyHealth == 0) { Console.WriteLine("-x|----------|x-"); }
                        if (enemyHealth == 0)
                        {
                            Console.WriteLine("Enemy killed!");
                            Console.WriteLine("(Continue)");
                            ConsoleKeyInfo keyPressed1 = Console.ReadKey();
                            if (keyPressed1.Key == ConsoleKey.Enter)
                            {
                                actionNumber = 6;
                                inCombat = false;
                                enemyPosX = 0;
                                enemyPosY = 0;
                                Console.Clear();
                                Draw();
                            }
                        }
                        if (actionNumber == 1)
                        {
                            Console.WriteLine("(FIGHT)     HEAL ");
                        }
                        if (actionNumber == 2)
                        {
                            Console.WriteLine(" FIGHT     (HEAL)");
                        }
                        ConsoleKeyInfo keyPressed2 = Console.ReadKey();
                        if (keyPressed2.Key == ConsoleKey.Enter && actionNumber == 1)
                        {
                            enemyHealth--;
                        }
                            if (keyPressed2.Key == ConsoleKey.Enter && actionNumber == 2)
                        {
                            //nothing now
                        }
                        if (keyPressed2.Key == ConsoleKey.D && actionNumber != 2)
                        {
                            actionNumber++;
                        }
                        if (keyPressed2.Key == ConsoleKey.A && actionNumber != 1)
                        {
                            actionNumber--;
                        }
                    }
                }
                if (keyPressed.Key == ConsoleKey.Enter && actionNumber == 2)
                {
                    inCombat = false;
                    Console.Clear();
                    Draw();
                    actionNumber = 1;
                }
                if (keyPressed.Key == ConsoleKey.D && actionNumber != 2)
                {
                    actionNumber++;
                }
                if (keyPressed.Key == ConsoleKey.A && actionNumber != 1)
                {
                    actionNumber--;
                }
                           
            }
        }
    }
}
