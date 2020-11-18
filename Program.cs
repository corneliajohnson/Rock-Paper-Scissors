using System;

namespace RockPaperScissors
{
  class Program
  {
    static void Main(string[] args)
    {
      int userScore = 0;
      int computerScore = 0;
      ShowScore(userScore, computerScore);
      string userThrow = Console.ReadLine();
      AskUser(userThrow, userScore, computerScore);
    }

    static void AskUser(string userThrow, int userScore, int computerScore)
    {
      while (userThrow != "1" && userThrow != "2" && userThrow != "3")
      {
        ShowScore(userScore, computerScore);
        userThrow = Console.ReadLine();
      }

      if (userThrow == "1" || userThrow == "2" || userThrow == "3")
      {
        CompareThrows(int.Parse(userThrow), userScore, computerScore);
      }
    }

    static void ShowScore(int playerScore, int computerScore)
    {
      Console.WriteLine($@"
            _________________________________________
            Player {playerScore}|   Computer {computerScore}    
            _________________________________________
            What would tou like to throw? 
            1) Rock
            2) Paper
            3) Scissors
            ");
    }
    static void CompareThrows(int userThrow, int userScore, int computerScore)
    {

      Random computerRandom = new Random();
      int computerThrow = computerRandom.Next(1, 4);

      if (userThrow == computerThrow)
      {
        Console.WriteLine("tie");
      }
      else if (userThrow == 1 && computerThrow == 3 || userThrow == 2 && computerThrow == 1 || userThrow == 3 && computerThrow == 2)
      {
        userScore++;
        Console.WriteLine("user wins");
      }
      else
      {
        computerScore++;
        Console.WriteLine("computer wins");
      }

      while (userScore < 4 && computerScore < 4)
      {
        if (userScore == 3)
        {
          Console.WriteLine("You Win");
          ShowScore(userScore, computerScore);
          Environment.Exit(-1);
        }
        else if (computerScore == 3)
        {
          Console.WriteLine("Computer Wins!");
          ShowScore(userScore, computerScore);
          Environment.Exit(-1);
        }
        ShowScore(userScore, computerScore);
        string newUserThrow = Console.ReadLine();
        AskUser(newUserThrow, userScore, computerScore);
      }
    }
  }
}
