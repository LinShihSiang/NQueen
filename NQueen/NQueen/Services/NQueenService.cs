using Microsoft.Extensions.Logging;
using NQueen.Models;

namespace NQueen.Services
{
    public class NQueenService
    {
        private readonly ILogger<NQueenService> _logger;

        public NQueenService(
            ILogger<NQueenService> logger)
        {
            _logger = logger;
        }

        public void Start()
        {
            var count = GetCount();

            if (count < 0)
            {
                return;
            }

            var queen = new NQueenModel(count);
            var solutions = queen.GetSolutions();

            _logger.LogInformation(queen.GetAnswer());

            foreach (var solution in solutions)
            {
                foreach (var row in solution) {
                    _logger.LogInformation(row);
                }
                _logger.LogInformation("");
            }
        }

        public int GetCount()
        {
            Console.WriteLine("請輸入 NQueen 數量 (No 離開):");

            var input = Console.ReadLine() ?? string.Empty;

            if (input.ToLower() == "no")
            {
                return -1;
            }

            if (!int.TryParse(input, out var count) ||
                count <= 0)
            {
                Console.WriteLine("請輸入大於 0 的正整數");

                GetCount();
            }

            return count;
        }
    }
}
