using ApprovalTests;
using ApprovalTests.Reporters;
using HangmanGame;
using System.Text;
using Xunit;

namespace Tests
{
    public class GameEngineTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void GameState()
        {
            var sb = new StringBuilder();

            var sut = new GameEngine("Pluralsight");

            sut.Guess('x');
            sut.Guess('p');
            sut.Guess('l');

            sb.AppendLine(sut.ToString());

            Approvals.Verify(sb.ToString());
        }
    }
}
