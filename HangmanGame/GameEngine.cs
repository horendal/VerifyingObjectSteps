using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public class GameEngine
    {
        private readonly List<char> _guessedLetters = new List<char>();
        private readonly string _wordToGuess;
        private int _guessesRemaining = 10;

        public GameEngine(string wordToGuess)
        {
            _wordToGuess = wordToGuess.ToUpperInvariant();
        }

        public string RevealedWord
        {
            get
            {
                var sb = new StringBuilder();

                foreach (var letter in _wordToGuess.ToCharArray())
                {
                    if (_guessedLetters.Contains(letter))
                    {
                        sb.Append(letter);
                    }
                    else
                    {
                        sb.Append('-');
                    }
                }

                return sb.ToString();
            }
        }

        public void Guess(char letter)
        {
            letter = ToUpperChar(letter);

            _guessedLetters.Add(letter);

            if (! _wordToGuess.ToCharArray().Any(x => x == letter))
            {
                _guessesRemaining--;
            }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Guessed letters: {0}", new String(_guessedLetters.ToArray()));
            sb.AppendLine();

            sb.AppendFormat("Guesses remaining: {0}", _guessesRemaining);
            sb.AppendLine();

            sb.AppendLine(_wordToGuess);

            sb.AppendLine(RevealedWord);

            return sb.ToString();
        }

        #region helper code
        private static char ToUpperChar(char letter)
        {
            return letter.ToString(CultureInfo.InvariantCulture).ToUpperInvariant().ToCharArray()[0];
        }
        #endregion

    }
}