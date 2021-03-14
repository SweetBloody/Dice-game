using System;
using System.Xml;

namespace Dice
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            
            string choice = "Y";

            while (choice != "N")
            {
                Console.Clear();
                Console.WriteLine("---          Start game          ---");
                Console.WriteLine("");

                int userPoints = 0;
                int compPoints = 0;

                
                //User results
                int[] userPred = new int[3];
                int[] userDice = new int[3];
                int[] userResults = new int[3];
                int[] userPenalties = {0, 0, 0};

                //Computer results
                int[] compPred = new int[3];
                int[] compDice = new int[3];
                int[] compResults = new int[3];
                int[] compPenalties = {0, 0, 0};
                

                // 3 rounds
                for (int i = 0; i < 3; i++)
                {
                    
                    //User
                    
                    Console.WriteLine("U S E R");
                    Console.WriteLine("");
                    
                    Console.Write("Predict the points number (2..12): ");
                    int userNumber = Int32.Parse(Console.ReadLine());
                    
                    Console.Write("Do you want to cheat? (Y/N): ");
                    string userCheatChoice = Console.ReadLine();

                    int userSum = 0;
                    int userResult = 0;
                    
                    switch (userCheatChoice)
                    {
                        // Decide to cheat
                        case "Y":
                            
                            int userVariant = 0;
                            switch (i)
                            {
                                case 0:
                                    userVariant = chooseVariant(1, 2);
                                    break;
                                
                                case 1:
                                    userVariant = chooseVariant(1, 4);
                                    break;
                                
                                case 2:
                                    userVariant = chooseVariant(1, 6);
                                    break;
                            }
                            
                            // Successful cheat
                            if (userVariant == 1)
                            {
                                userSum = userNumber;
                                Console.WriteLine("User successfully cheated!");
                            
                                int cheatUserSum = 20;
                                int firstDice = 20;
                                int secondDice = 20;
                                                                    
                                while (cheatUserSum != userSum)
                                {
                                    firstDice = rnd.Next(1, 7);
                                    secondDice = userSum - firstDice;
                                    if (secondDice <= 0 | secondDice >= 7)
                                    {
                                        secondDice = 20;
                                    }
                                    cheatUserSum = firstDice + secondDice;
                                }
                                                                    
                                Console.WriteLine("User rolls the dice:");
                                PrintDice(firstDice);
                                PrintDice(secondDice);
                                Console.WriteLine("On the dice fell {0} points.", userSum);
                                                                    
                                userResult = userSum - Math.Abs(userSum - userNumber) * 2;
                                Console.WriteLine("Result is {0}-abs({0}-{1})*2: {2} points", userSum, userNumber, userResult);
                            }
                            
                            // Unsuccessful cheat
                            else
                            {
                                Console.WriteLine("User unsuccessfully cheated!");
                                Console.WriteLine("User rolls the dice:");
                                userSum = RollTheDice();
                            
                                userResult = userSum - Math.Abs(userSum - userNumber) * 2 - 10;
                                Console.WriteLine("Result is {0}-abs({0}-{1})*2-10: {2} points", userSum, userNumber, userResult);

                                userPenalties[i] = -10;
                            }
                            break;
                        
                        
                        // Decide not to cheat
                        case "N":
                            
                            Console.WriteLine("User rolls the dice:");
                            userSum = RollTheDice();
                            
                            userResult = userSum - Math.Abs(userSum - userNumber) * 2;
                            Console.WriteLine("Result is {0}-abs({0}-{1})*2: {2} points", userSum, userNumber, userResult);
                            break;
                    }



                    Console.WriteLine("");

                    // Computer
                    
                    Console.WriteLine("C O M P U T E R");
                    Console.WriteLine("");
                    
                    int compNumber = rnd.Next(2, 13);
                    Console.WriteLine("Computer predicted {0} points.", compNumber);

                    string compCheatChoice = "";
                    int pointDifference = Math.Abs(userPoints - compPoints);

                    
                    // Probability of cheating
                    switch (i)
                    {
                        case 0:
                            
                            if (chooseVariant(1, 5) == 1)
                            {
                                compCheatChoice = "Y";
                            }
                            else
                            {
                                compCheatChoice = "N";
                            }
                            break;
                        
                        case 1:

                            if (pointDifference > 5)
                            {
                                if (pointDifference > 15)
                                {
                                    if (chooseVariant(3, 5) == 1)
                                    {
                                        compCheatChoice = "Y";
                                    }
                                    else
                                    {
                                        compCheatChoice = "N";
                                    }
                                }
                                else
                                {
                                    if (chooseVariant(2, 5) == 1)
                                    {
                                        compCheatChoice = "Y";
                                    }
                                    else
                                    {
                                        compCheatChoice = "N";
                                    }
                                }
                            }
                            else
                            {
                                if (chooseVariant(1, 5) == 1)
                                {
                                    compCheatChoice = "Y";
                                }
                                else
                                {
                                    compCheatChoice = "N";
                                }
                            }
                            break;
                        
                        case 2:
                            
                            if (pointDifference > 5)
                            {
                                if (pointDifference > 15)
                                {
                                    if (chooseVariant(3, 5) == 1)
                                    {
                                        compCheatChoice = "Y";
                                    }
                                    else
                                    {
                                        compCheatChoice = "N";
                                    }
                                }
                                else
                                {
                                    if (chooseVariant(2, 5) == 1)
                                    {
                                        compCheatChoice = "Y";
                                    }
                                    else
                                    {
                                        compCheatChoice = "N";
                                    }
                                }
                            }
                            else
                            {
                                if (chooseVariant(1, 5) == 1)
                                {
                                    compCheatChoice = "Y";
                                }
                                else
                                {
                                    compCheatChoice = "N";
                                }
                            }
                            break;
                    }

                    
                    int compSum = 0;
                    int compResult = 0;
                    
                    switch (compCheatChoice)
                    {
                        // Decide to cheat
                        case "Y":
                            
                            int compVariant = 0;
                            switch (i)
                            {
                                case 0:
                                    compVariant = chooseVariant(1, 2);
                                    break;
                                
                                case 1:
                                    compVariant = chooseVariant(1, 4);
                                    break;
                                
                                case 2:
                                    compVariant = chooseVariant(1, 6);
                                    break;
                            }
                            
                            // Successful cheat
                            if (compVariant == 1)
                            {
                                compSum = compNumber;
                                Console.WriteLine("Computer successfully cheated!");
                            
                                int cheatCompSum = 20;
                                int firstDice = 20;
                                int secondDice = 20;
                                                                    
                                while (cheatCompSum != compSum)
                                {
                                    firstDice = rnd.Next(1, 7);
                                    secondDice = compSum - firstDice;
                                    if (secondDice <= 0 | secondDice >= 7)
                                    {
                                        secondDice = 20;
                                    }
                                    cheatCompSum = firstDice + secondDice;
                                }
                                                                    
                                Console.WriteLine("Computer rolls the dice:");
                                PrintDice(firstDice);
                                PrintDice(secondDice);
                                Console.WriteLine("On the dice fell {0} points.", compSum);
                                                                    
                                compResult = compSum - Math.Abs(compSum - compNumber) * 2;
                                Console.WriteLine("Result is {0}-abs({0}-{1})*2: {2} points", compSum, compNumber, compResult);
                            }
                            
                            // Unuccessful cheat
                            else
                            {
                                Console.WriteLine("Computer unsuccessfully cheated!");
                                Console.WriteLine("Computer rolls the dice:");
                                compSum = RollTheDice();
                            
                                compResult = compSum - Math.Abs(compSum - compNumber) * 2 - 10;
                                Console.WriteLine("Result is {0}-abs({0}-{1})*2-10: {2} points", compSum, compNumber, compResult);

                                compPenalties[i] = -10;
                            }
                            break;
                        
                        
                        // Decide not to cheat
                        case "N":
                            
                            Console.WriteLine("Computer rolls the dice:");
                            compSum = RollTheDice();
                            
                            compResult = compSum - Math.Abs(compSum - compNumber) * 2;
                            Console.WriteLine("Result is {0}-abs({0}-{1})*2: {2} points", compSum, compNumber, compResult);
                            break;
                    }
                    
                    
                    userPoints += userResult;
                    compPoints += compResult;
                    
                    
                    Console.WriteLine("");
                    Console.WriteLine("---------- Current score ----------");
                    Console.WriteLine("User:        {0} points", userPoints);
                    Console.WriteLine("Computer:    {0} points", compPoints);
                    Console.WriteLine("");
                    if (userPoints > compPoints)
                    {
                        Console.WriteLine("User is ahead by {0} points!", userPoints - compPoints);
                    }
                    else if (compPoints > userPoints)
                    {
                        Console.WriteLine("Computer is ahead by {0} points!", compPoints - userPoints);
                    }
                    else
                    {
                        Console.WriteLine("Amount of points is equal now.");
                    }

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    

                    userPred[i] = userNumber;
                    userDice[i] = userSum;
                    userResults[i] = userResult;

                    compPred[i] = compNumber;
                    compDice[i] = compSum;
                    compResults[i] = compResult;
                }


                Console.WriteLine("");
                Console.WriteLine("-------------- Finish game --------------");
                Console.WriteLine("");
                Console.WriteLine(" Round |           User |      Computer  ");
                
                Console.WriteLine("-------+----------------+----------------");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("       | Predicted: {0,3} | Predicted: {1,3}", userPred[i], compPred[i]);
                    Console.WriteLine("       | Dice:      {0,3} | Dice:      {1,3}", userDice[i], compDice[i]);
                    Console.WriteLine(" - {0} - | Result:    {1,3} | Result:    {2,3}", i + 1, userResults[i], compResults[i]);
                    Console.WriteLine("       |                |                ");
                    Console.WriteLine("       | Penalty:   {0,3} | Penalty:   {1,3}", userPenalties[i], compPenalties[i]);
                    Console.WriteLine("-------+----------------+----------------");
                }

                Console.WriteLine(" Total | Points:    {0,3} | Points:    {1,3}", userPoints, compPoints);
                Console.WriteLine("");


                if (userPoints > compPoints)
                {
                    Console.WriteLine("User wins {0} points more.", userPoints - compPoints);
                    Console.WriteLine("Congratulations!");
                }

                else if (compPoints > userPoints)
                {
                    Console.WriteLine("Computer wins {0} points more.", compPoints - userPoints);
                }

                else
                {
                    Console.WriteLine("Draw!");
                }
                
                Console.WriteLine("");
                Console.WriteLine("Do you want to play ones more? (Y/N)");
                choice = Console.ReadLine();
            }
        }

        
        static void PrintDice(int number)
        {
            Console.WriteLine("-----------");
            switch (number)
            {
                case 1:
                    Console.WriteLine("|         |");
                    Console.WriteLine("|    #    |");
                    Console.WriteLine("|         |");
                    break;
                
                case 2:
                    Console.WriteLine("| #       |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|       # |");
                    break;
                
                case 3:
                    Console.WriteLine("| #       |");
                    Console.WriteLine("|    #    |");
                    Console.WriteLine("|       # |");
                    break;
                
                case 4:
                    Console.WriteLine("| #     # |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("| #     # |");
                    break;
                
                case 5:
                    Console.WriteLine("| #     # |");
                    Console.WriteLine("|    #    |");
                    Console.WriteLine("| #     # |");
                    break;
                
                case 6:
                    Console.WriteLine("| #  #  # |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("| #  #  # |");
                    break;
            }
            Console.WriteLine("-----------");
        }


        static int RollTheDice()
        {
            Random rnd = new Random();
            

            int number = rnd.Next(1, 7);
            int sum = number;
            PrintDice(number);

            number = rnd.Next(1, 7);
            sum += number;
            PrintDice(number);
            
            Console.WriteLine("On the dice fell {0} points.", sum);
            return sum;
        }


        static int chooseVariant(int firstMax, int secondMax)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, secondMax + 1);
            if (number <= firstMax)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }    
    }
}
