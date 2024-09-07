namespace NQueen.Models
{
    public class NQueenModel
    {
        private readonly int _count;
        private readonly List<int[]> _result;
        private readonly int[] _queens;
        private readonly HashSet<int> _columns;
        private readonly HashSet<int> _leftDiags;
        private readonly HashSet<int> _rightDiags;

        public NQueenModel(int count)
        {
            _count = count;
            _result = new List<int[]>();
            _queens = new int[count];
            _columns = new HashSet<int>();
            _leftDiags = new HashSet<int>();
            _rightDiags = new HashSet<int>();
        }

        public List<string[]> GetSolutions()
        {
            if (!_result.Any())
                Solve(0);

            return _result.Select(item => item.Select(value => {
                var text = Convert.ToString(value, 2).PadLeft(_count, '0');

                return text.Replace('1', 'Q').Replace('0', '.');
            }).ToArray()).ToList();
        }

        private void Solve(int row)
        {
            if (row == _count)
            {
                _result.Add((int[])_queens.Clone());
                return;
            }

            for (int col = 0; col < _count; col++)
            {
                int leftDiag = row - col;   // 左上位置
                int rightDiag = row + col;  // 右上位置

                // 如果有 Queen 在相同列或對角線則跳過
                if (Unsafe(col, leftDiag, rightDiag))
                {
                    continue; 
                }

                // 使用位運算來表示 Queen 的位置
                _queens[row] = 1 << col;

                // 新增 Queen 的位置到列、對角線暫存 HashSet
                _columns.Add(col);
                _leftDiags.Add(leftDiag);
                _rightDiags.Add(rightDiag);

                Solve(row + 1);

                // 回溯，移除皇后並清理 HashSet
                _columns.Remove(col);
                _leftDiags.Remove(leftDiag);
                _rightDiags.Remove(rightDiag);
            }
        }

        private bool Unsafe(int col, int leftDiag, int rightDiag)
        {
            return _columns.Contains(col) ||
                _leftDiags.Contains(leftDiag) ||
                _rightDiags.Contains(rightDiag);
        }

        public string GetAnswer()
        {
            return $"{_count}-Queen 共 {_result.Count} 組排序";
        }
    }
}