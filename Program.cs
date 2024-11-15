using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                {
                    return mid;
                }
                if (arr[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
        void Search()
        {
            int[] arr = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
            int target = 13;

            int result = BinarySearch(arr, target);

            if (result != -1)
            {
                Console.WriteLine("Phan tu tim thay tai chi so: " + result);
            }
            else
            {
                Console.WriteLine("Phan tu không có trong mang.");
            }
        }

        long[] memo;
        long Fibonacci(int n)
        {
            if (n <= 1)
                return n;

            if (memo[n] != -1)
                return memo[n];

            memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            return memo[n];
        }
        void Fibonacci()
        {
            int n = 50;
            memo = new long[n + 1];
            for (int i = 0; i <= n; i++)
                memo[i] = -1;
            Console.WriteLine("Fibonacci({0}) = {1}", n, Fibonacci(n));
        }

        public static string GetSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder hexString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hexString.AppendFormat("{0:x2}", b);
                }
                return hexString.ToString();
            }
        }
        void Hash()
        {
            string input = "Hello, World!";
            string hash = GetSHA256Hash(input);
            Console.WriteLine($"SHA-256 Hash: {hash}");
        }


        static void Main()
        {

            Program program = new Program();
            program.Hash();
            Console.WriteLine();

            program.Fibonacci();
            Console.WriteLine();

            program.Search();
            Console.ReadKey();


        }
    }
}
