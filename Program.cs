using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3 {
    internal class Program {
        static void Main(string[] args) {
            int[,] matrix = { { 7, 8, 9 },
                              { 4, 5, 6 },
                              { 9, 9, 9 },
                              { 10, 11, 12 },
                              { 1, 2, 3 }
            };

            int[,] finalMatrix = SortRowsBySum(matrix);
            for (int i = 0; i < finalMatrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    Console.Write(finalMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] SortRowsBySum(int[,] matrix) {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            // Store each row's elements (as a key) along with their sum (as a value) for sorting.
            // Note: This is not a Dictionary, but a List of Tuples.
            List<(int[] values, int sum)> lines = new List<(int[] values, int sum)>(n);

            for (int i = 0; i < n; i++) {
                int[] val = new int[m];
                int sum = 0;
                for (int j = 0; j < m; j++) {
                    val[j] = matrix[i, j];
                    sum += val[j];
                }
                lines.Add((val, sum));
            }


            //lines.Sort(comparison: (a, b) => a.sum.CompareTo(b.sum));
            BubbleSort(lines);

            // Reconstruct the matrix with rows reordered based on the sorted lines.
            int[,] finalMatrix = new int[n, m];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    finalMatrix[i, j] = lines[i].values[j];
                }
            }
            return finalMatrix;
        }

        public static void BubbleSort(List<(int[] values, int sum)> lines) {
            for (int i = 0; i < lines.Count - 1; i++) {
                // Iterate adjacent pairs to bubble the largest sum to the end (Bubble Sort).
                // Iterate only up to the last unsorted element.
                //                       |
                //                       |
                //                       ↓
                // (lines.Count - i - 1) — each pass places the largest sum at the end.
                for (int j = 0; j < lines.Count - i - 1; j++) {
                    if (lines[j].sum > lines[j + 1].sum) {
                        var temp = lines[j];
                        lines[j] = lines[j + 1];
                        lines[j + 1] = temp;
                    }
                }
            }
        }
    }
}