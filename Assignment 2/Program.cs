using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_2
{
    class Program
    {
        public static int max_value = 1, temp_value = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            Console.WriteLine("[" + r[0] + "," + r[1] + "]");

            Console.WriteLine("Question 2");
            string s = "University of South Florida ";
            string rs = StringReverse(s);
            Console.WriteLine(rs);

            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);

            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);

            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");

            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));

            Console.WriteLine("Question 7");
            int rodLength = 15;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);

            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hhllo";
            Console.WriteLine(DictSearch(userDict, keyword));

            Console.WriteLine("Question 9");
            SolvePuzzle();
        }
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] l1, int t)
        {
            int first = -1;
            int last = -1;
            try
            {
                int n = l1.Length;
               

                for (int i = 0; i < n; i++)
                {
                    if (t != l1[i])
                    {
                        continue;
                    }
                    if (first == -1)
                    {
                        first = i;
                    }
                    last = i;
                }
          /*      if (first != -1)
                {
                    Console.WriteLine("[" + first + "," + last + "]");
                }
                else
                {
                    Console.WriteLine("[-1,-1]");

                    */
                    
                //return new int[] { };
                /*List<int> result = new List<int>();

                for (int i=0;i<l1.Length;i++)
                {
                    if (l1[i] == t)
                    {
                        result.Add(i);
                    }
                }*/
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured");
            }
            return new int[] {first,last};
        }
        public static string StringReverse(string s)
        {
            try
            {
                ArrayList arraylist = new ArrayList();
                string temp = "";
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != ' ')
                    {
                        temp = temp + s[i];
                        continue;
                    }
                    string word = "";
                    for (int j = temp.Length - 1; j >= 0; j--)
                    {
                        word += temp[j];
                    }

                    arraylist.Add(word);
                    temp = "";
                }

                string rs = "";
                for (int i = 0; i < arraylist.Count; i++)
                {
                    rs += " " + arraylist[i];
                }
                return rs;
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public static int MinimumSum(int[] l2)
        {
            try
            {
                int sum = l2[0];
                int n = l2.Length;
                for (int i = 1; i < n; i++)
                {
                    if (l2[i] == l2[i - 1])
                    {
                        int j = i;
                        while (j < n && l2[j] <= l2[j - 1])
                        {
                            l2[j] = l2[j] + 1;
                            j++;
                        }
                    }
                    sum = sum + l2[i];
                }
                return sum;
            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }
        public static string FreqSort(string s2)
        {
            try
            {
                StringBuilder res = new StringBuilder();
                var dic = new Dictionary<char, int>();
                for (int i = 0; i < s2.Length; i++)
                {
                    if (dic.ContainsKey(s2[i]))
                        dic[s2[i]]++;
                    else
                        dic[s2[i]] = 1;
                }
                var list = dic.OrderByDescending(t => t.Value);
                foreach (var item in list)
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        res.Append(item.Key);
                    }
                }
                return res.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                Array.Sort(nums1);
                Array.Sort(nums2);

                int[] outerArray = (nums1.Length <= nums2.Length) ? nums1 : nums2;
                int[] innerArray = (nums1.Length <= nums2.Length) ? nums2 : nums1;
                int i;

                ArrayList intersection = new ArrayList();

                foreach(int num in outerArray)
                {
                    //Find it in inner array
                    if (BinarySearch(innerArray, num))
                    {
                        intersection.Add(num);
                    }
                }
                int[] intersect = new int[intersection.Count];
                for (i = 0; i < intersection.Count; i++)
                {
                    intersect[i] = (int)intersection[i];
                }
                return intersect;

                /*HashSet<int> hs = new HashSet<int>();
                List<int> list = new List<int>();
                for (int i = 0; i < nums1.Length; i++)
                {
                    hs.Add(nums1[i]);
                }
                for (int i = 0; i < nums2.Length; i++)
                {
                    if (hs.Contains(nums2[i]))
                    {
                        list.Add(nums2[i]);
                    }
                }
                return list.ToArray();

                int m = nums1.Length;
                int n = nums2.Length;
                if (m > n)
                {
                    int[] tempp = nums1;
                    nums1 = nums2;
                    nums2 = tempp;

                    int temp = m;
                    m = n;
                    n = temp;
                }
                Array.Sort(nums1);
                for(int i = 0; i < n; i++)
                {
                    if (BinarySearch(nums1, 0, m - 1, nums2[i]) != -1) ;
                    {
                        Console.Write(nums2[i]+" ");
                    }
                }*/
            }
            catch
            {
                throw;
            }
            return new int[] { };
        }
        public static bool BinarySearch(int[]nums,int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (target == nums[mid])
                {
                    return true;
                }
                else if (target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return false;
        }
        public static int[] Intersect2(int[] nums1, int[] nums2)
        {
            try
            {
                Array.Sort(nums1);
                Array.Sort(nums2);
                int m = nums1.Length;
                int n = nums2.Length;
                int i = 0;
                int j = 0;
                List<int> list = new List<int>();

                while (i < m && j < n)
                {
                    if (nums1[i] == nums2[j])
                    {
                        list.Add(nums1[i]);
                        i++;
                        j++;
                    }
                    else if (nums1[i] < nums2[j])
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
                return list.ToArray();
            }
            catch
            {
                throw;
            }
            return new int[] { };
        }
        public static bool ContainsDuplicate(char[] arr, int k)
        {
            try
            {
                int size = arr.Length;
                //Initialize positions of two elements
                int i = 0, j = 1;
                var indexi = arr.ToList().IndexOf(arr[i]);
                var indexj = arr.ToList().IndexOf(arr[j]);


                //Search for a pair
                while (i < size && j < size)
                {
                    if (i != j && arr[j] == arr[i] && indexj - indexi <= k)
                    {
                        Console.WriteLine("Pair Found:" + "(" + arr[i] + "," + arr[j] + ")");
                        return true;
                    }
                    else if (indexj < size)
                    {
                        j++;
                    }

                    else
                    {
                        i++;
                        j = i + 1;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return default;
        }
        static void findCombo(int[] arr, int index,
                                        int num, int reducedNum)
        {
            if (reducedNum < 0)
                return;

            if (reducedNum == 0)
            {
                for (int i = 0; i < index; i++)
                {
                    temp_value = temp_value * arr[i];
                }
                if (temp_value > max_value)
                {
                    max_value = temp_value;
                }
                temp_value = 1;

                return;
            }

            int prev = (index == 0) ?
                                1 : arr[index - 1];

            for (int k = prev; k <= num; k++)
            {
                arr[index] = k;


                findCombo(arr, index + 1, num,
                                        reducedNum - k);
            }
        }

        static int GoldRod(int n)
        {
            int[] arr = new int[n];


            findCombo(arr, 0, n, n);
            return max_value;
        }

        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {
                for (int ii = 0; ii < keyword.Length; ii++)
                {
                    char[] CharArray = keyword.ToCharArray();
                    for (int i = 0; i < 27; i++)
                    {

                        int x = 97 + i;


                        //Console.WriteLine( x);
                        char y = Convert.ToChar(x);

                        CharArray[ii] = y;
                        //string NewKeyword = CharArray.ToString();

                        //   Console.WriteLine(y);


                        string NewKeyword = new string(CharArray);
                        for (int iii = 0; iii < userDict.Length; iii++)
                        {


                            if (string.Equals(NewKeyword, userDict[iii]))
                            {
                                Console.WriteLine("userDict:   " + userDict[iii]);
                                Console.WriteLine("NewKeyword:   " + NewKeyword);
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return default;
        }
        public static void SolvePuzzle()
        {
            try
            {
                //Write Your Code Here
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


