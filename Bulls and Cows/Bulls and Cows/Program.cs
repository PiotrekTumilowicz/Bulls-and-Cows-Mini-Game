
using System;

class Program
{
    static void Main()
    {
        bool PlayerWantsToPlayAgain = true;
        while (PlayerWantsToPlayAgain)
        {
            string secretNumber = "";
            Random random = new Random();
            
            for (int i = 0; i < 4; i++)
            {
                string newDigit = random.Next(0, 9).ToString();
                while (secretNumber.Contains(newDigit))
                {
                    newDigit = random.Next(0, 9).ToString();
                }
                secretNumber += newDigit;
            }

            while (true)
            {

                Console.WriteLine("Please type your guess (4 digits, no repetition)");
                Console.WriteLine($"The secret number is: {secretNumber}");

                string playerGuess = Console.ReadLine();

                while (true)
                {
                    bool isFourDigits = playerGuess.Length == 4;
                    bool isAllDigit = true;
                    foreach (char digit in playerGuess)
                    {
                        if (!char.IsDigit(digit))
                        {
                            isAllDigit = false;
                            break;
                        }
                    }
                    bool hasNoRepetition = true;
                    for (int i = 0; i < playerGuess.Length; i++)
                    {
                        for (int j = 0; j < playerGuess.Length; j++)
                        {
                            if (j != i && playerGuess[i] == playerGuess[j])
                            {
                                hasNoRepetition = false;
                                break;
                            }
                        }
                        if (!hasNoRepetition)
                        {
                            break;
                        }
                    }
                    if (isAllDigit && isFourDigits && hasNoRepetition)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The input is invalid, please type your guess again (4 digits, no repetition)");
                        playerGuess = Console.ReadLine();
                    }
                }

                int bullCount = 0;
                int cowCount = 0;

                for (int i = 0; i < secretNumber.Length; i++)
                {
                    if (playerGuess[i] == secretNumber[i])
                    {
                        bullCount++;
                    }
                    else
                    {
                        foreach (char digit in secretNumber)
                        {
                            if (playerGuess[i] == digit)
                            {
                                cowCount++;
                            }
                        }
                    }
                }

                if (bullCount == secretNumber.Length)
                {
                    Console.WriteLine($"Congrats, you got the correct answer: {secretNumber}");
                    break;
                }
                else
                {
                    Console.WriteLine("You got:");
                    Console.WriteLine($"Bulls: {bullCount}");
                    Console.WriteLine($"Cows: {cowCount}");
                    Console.WriteLine("Try again!");
                    Console.WriteLine("===================");
                }
            }

            Console.WriteLine("Do you want to play again? [y/n]");
            string playerChoice = Console.ReadLine();
            while (playerChoice != "y" && playerChoice != "n")
            {
                Console.WriteLine("Please pick \"y\", or \"n\" ");
                playerChoice = Console.ReadLine();
            }
            if (playerChoice == "n")
            {
                PlayerWantsToPlayAgain = false;
            }
        }
        Console.WriteLine("Thanks for playing the game!");
    }

}
