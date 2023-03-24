namespace SortingGeneric {

    interface ISort<T> {
        T[] Sort(T[] arr);
    }

    class Program {
        static void Main(string[] args) {
            // Take input from console
            if (args[1] == "-Bubble") {
                if (args[2] == "-string") {
                    string[] arr = args[3].Split(',');
                    BubbleSort<string> bs = new BubbleSort<string>();
                    string[] sortedArr = bs.Sort(arr);
                    WriteArray(sortedArr, "Sorted Array using BubbleSort: ");
                }
                if (args[2] == "-int") {
                    int[] arr = args[3].Split(',').Select(int.Parse).ToArray<int>();
                    BubbleSort<int> bs = new BubbleSort<int>();
                    int[] sortedArr = bs.Sort(arr);
                    WriteArray(sortedArr, "Sorted Array using BubbleSort: ");
                }
            }

            if (args[1] == "-Merge") {
                if (args[2] == "-string") {
                    string[] arr = args[3].Split(',');
                    MergeSort<string> ms = new MergeSort<string>();
                    string[] sortedArr = ms.Sort(arr);
                    WriteArray(sortedArr, "Sorted Array using MergeSort: ");
                }
                if (args[2] == "-int") {
                    int[] arr = args[3].Split(',').Select(int.Parse).ToArray<int>();
                    MergeSort<int> ms = new MergeSort<int>();
                    int[] sortedArr = ms.Sort(arr);
                    WriteArray(sortedArr, "Sorted Array using MergeSort: ");
                }
            }
        }

        static void WriteArray<T>(T[] arr, string msg) {
            Console.Write(msg);
            for (int i = 0; i < arr.Length; i++) {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class BubbleSort<T> : ISort<T> where T : IComparable<T> {
        public T[] Sort(T[] arr) {
            for (int i = 0; i < arr.Length - 1; i++) {
                for (int j = 0; j < arr.Length - i - 1; j++) {
                    if (arr[j].CompareTo(arr[j + 1]) > 0) {
                        T temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
    }

    class MergeSort<T> : ISort<T> where T : IComparable<T> {
        public T[] Sort(T[] arr) {
            MergeSplit(arr, 0, arr.Length - 1);
            return arr;
        }

        static void MergeSplit(T[] arr, int left, int right) {
            //left = first index of Array
            //right = last index of Array

            // Split Array in half and recursively call function for both resulting subarrays.
            if (left < right) {
                int mid = (left + right) / 2;

                MergeSplit(arr, left, mid);
                MergeSplit(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        static void Merge(T[] arr, int left, int mid, int right) {

            // Get number of items for both arrays
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Create temporary arrays
            T[] tempArrLeft = new T[n1];
            T[] tempArrRight = new T[n2];

            int i;
            int j;

            // Fill temporary arrays with given data
            for (i = 0; i < n1; i++) {
                tempArrLeft[i] = arr[left + i];
            }
            for (j = 0; j < n2; j++) {
                tempArrRight[j] = arr[mid + 1 + j];
            }

            i = 0;
            j = 0;

            int k = left;

            // As long as both subarrays contain items, sort by smaller item and increment index of that subarray
            while (i < n1 && j < n2) {
                if (tempArrLeft[i].CompareTo(tempArrRight[j]) <= 0) {
                    arr[k] = tempArrLeft[i];
                    i++;
                }
                else {
                    arr[k] = tempArrRight[j];
                    j++;
                }
                k++;
            }

            // Fill array with remaining data
    	    while (i < n1) {
                arr[k] = tempArrLeft[i];
                i++;
                k++;
            }

            while (j < n2) {
                arr[k] = tempArrRight[j];
                j++;
                k++;
            }
        }
    }
}