using FluentAssertions;
using NQueen.Models;

namespace NQueenUnitTests.Models
{
    public class Tests
    {
        private NQueenModel _nQueen;

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 1)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 2)]
        [TestCase(8, 92)]
        public void solutions_count_should_be_correct(int count, int solutionsCount)
        {
            _nQueen = new NQueenModel(count);

            var actual = _nQueen.GetSolutions().Count();
            var expected = solutionsCount;

            actual.Should().Be(expected);
        }

        [TestCase]
        public void solutions_for_4_queens_pulzz_should_be_correct()
        {
            _nQueen = new NQueenModel(4);

            var actual = _nQueen.GetSolutions();
            var expected = new List<string[]> {
                new string[]{
                    ".Q..",
                    "...Q",
                    "Q...",
                    "..Q."},
                new string[]{
                    "..Q.",
                    "Q...",
                    "...Q",
                    ".Q.."},
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase]
        public void part_of_solutions_for_8_queens_pulzz_should_contains()
        {
            _nQueen = new NQueenModel(8);

            var actual = _nQueen.GetSolutions();
            var expecteds = new List<string[]> {
                new string[]{
                    ".......Q",
                    "...Q....",
                    "Q.......",
                    "..Q.....",
                    ".....Q..",
                    ".Q......",
                    "......Q.",
                    "....Q..."
                },
                new string[]{
                    ".......Q",
                    ".Q......",
                    "...Q....",
                    "Q.......",
                    "......Q.",
                    "....Q...",
                    "..Q.....",
                    ".....Q.."
                },
                new string[]{
                    ".....Q..",
                    ".......Q",
                    ".Q......",
                    "...Q....",
                    "Q.......",
                    "......Q.",
                    "....Q...",
                    "..Q....."
                },
                new string[]{
                    ".....Q..",
                    "..Q.....",
                    "Q.......",
                    "......Q.",
                    "....Q...",
                    ".......Q",
                    ".Q......",
                    "...Q...."
                },
                new string[]{
                    ".....Q..",
                    ".Q......",
                    "......Q.",
                    "Q.......",
                    "...Q....",
                    ".......Q",
                    "....Q...",
                    "..Q....."
                }
            };

            foreach (var expected in expecteds)
            {
                actual.Should().ContainEquivalentOf(expected);
            }
        }
    }
}