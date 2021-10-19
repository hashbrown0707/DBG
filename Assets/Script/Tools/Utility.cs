using System;
using System.Collections.Generic;

namespace Utility
{
    public static class Utility
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// 回傳list[0]並使他在list中消失
        /// </summary>
        public static T PopFront<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                return default(T);

            T temp = list[0];
            list.RemoveAt(0);
            return temp;
        }

        /// <summary>
        /// 讓list內容進行洗牌
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int rand = random.Next(i, list.Count);
                list.Swap(i, rand);
            }
        }

        /// <summary>
        /// 交換list內物件
        /// </summary>
        /// <param name="a">indexA</param>
        /// <param name="b">indexB</param>
        public static void Swap<T>(this IList<T> list, int a, int b)
        {
            T tmp = list[a];
            list[a] = list[b];
            list[b] = tmp;
        }
    }
}

