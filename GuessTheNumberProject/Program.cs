﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberProject {

	class Program {
		int GenerateMagicNumber(int HighestNumber) {
			Random rnd = new Random();
			var MagicNumber = rnd.Next(11);
			Debug($"The magic number is {MagicNumber}");
			return MagicNumber;
		}

		int AskForTheGuess() {
			Console.Write($"Enter your guess : ");
			var TheGuess = Console.ReadLine();
			int GuessNumber = int.Parse(TheGuess);
			return GuessNumber;
		}

		int CompareGuessToMagicNumber(int MagicNumber, int TheGuess) {
			if (MagicNumber == TheGuess) { // is the guess correct?}
				return 0;
			}
			if (MagicNumber > TheGuess) {// guess it too low
				return -1;
			}
			if (TheGuess > MagicNumber) {// guess is too high
				return 1;
			}

			return -2;
		}


		bool PrintOutcomeResult(int Result) {
			if(Result == 0) { //if the guess matched - they won
				Debug("Correct! - You Won!");
				return true;
			}
			if (Result == -1) {  // if the guess is too low
				Debug("Too low - guess again.");
				return false;
			}
			if (Result == 1) {  //if the guess is too high
				Debug("Too high - guess again.");
				return false;
			}
			return true;
		}

		void Debug(string message) {
			Console.WriteLine(message);
		}

		void RunGameOnce() {
			var MagicNumber = GenerateMagicNumber(100);
			bool GameOver = false;
			while (GameOver == false) {
				var UserGuess = AskForTheGuess();
				var GuessResult = CompareGuessToMagicNumber(MagicNumber, UserGuess);
				GameOver = PrintOutcomeResult(GuessResult);
			
			}
		}
		void Run() {
			bool PlayAgain = true;
			while (PlayAgain == true) {
				RunGameOnce();
				Console.Write($"Do you want to play again? Y/N : ");
				var answer = Console.ReadLine();
				if(answer == "Y" || answer == "y") {
					PlayAgain = true;
				} else {
					PlayAgain = false;
				}
			}
		}

		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
