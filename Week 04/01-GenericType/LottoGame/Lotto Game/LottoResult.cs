namespace Lotto_Game
{
    public class LottoResult<T, U>
    {
        public LottoResult()
        {
            IsWinning = false;
            MatchedNumbersCount = 0;
        }

        public bool IsWinning { get; }
        public byte MatchedNumbersCount { get; }

        public LottoResult(Combination<T, U> combination, Combination<T, U> winningCombination)
        {
            MatchedNumbersCount = 0;
            for (int i = 0; i < combination.FirstHalf.Length; i++)
            {
                if (combination.FirstHalf[i].Equals(winningCombination.FirstHalf[i]))
                    MatchedNumbersCount++;
                if (combination.SecondHalf[i].Equals(winningCombination.SecondHalf[i]))
                    MatchedNumbersCount++;
            }

            if (MatchedNumbersCount > 1)
                IsWinning = true;
        }

    }
}