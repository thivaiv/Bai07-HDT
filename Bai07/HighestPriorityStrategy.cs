/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai07
{
    //chiến lược chọn đối tượng có điểm ưu tiên cao nhất
    public class HighestPriorityStrategy<T> : ISelectionStrategy<T>
    {
        private readonly Func<T, double> scoreSelector;

        public HighestPriorityStrategy(Func<T, double> scoreSelector)
        {
            this.scoreSelector = scoreSelector ?? throw new ArgumentNullException(nameof(scoreSelector));
        }

        public T Select(IReadOnlyList<T> candidates)
        {
            //kiểm tra danh sách ứng viên
            if (candidates == null || candidates.Count == 0)
            {
                throw new NoSuitableItemException("không có ứng viên phù hợp.");
            }

            T best = candidates[0];
            double bestScore = scoreSelector(best);

            for (int i = 1; i < candidates.Count; i++)
            {
                double score = scoreSelector(candidates[i]);
                if (score > bestScore)
                {
                    bestScore = score;
                    best = candidates[i];
                }
            }

            return best;
        }
    }
}
