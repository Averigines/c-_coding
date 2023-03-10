namespace Sorting {
    class Program {
        static void Main(string[] args) {

            // Take input from console
            int[] arr = args[2].Split(',').Select(int.Parse).ToArray<int>();
            if (args[1] == "-Bubble") {
                BubbleSort(arr);
                WriteArray(arr, "Sorted Array using BubbleSort: ");
            }
            if (args[1] == "-Merge") {
                MergeSort(arr, 0, arr.Length-1);
                WriteArray(arr, "Sorted Array using MergeSort: ");
            }
        }

        static void BubbleSort(int[] arr) {
            for (int i = 0; i < arr.Length-1; i++) {
                for (int j = 0; j < arr.Length-i-1; j++) {
                    if (arr[j] > arr[j+1]) {
                        int temp = arr[j+1];
                        arr[j+1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        static void MergeSort(int[] arr, int left, int right) {
            //left = first index of Array
            //right = last index of Array

            // Split Array in half and recursively call function for both resulting subarrays.
            if (left < right) {
                int mid = (left + right) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right) {

            // Get number of items for both arrays
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Create temporary arrays
            int[] tempArrLeft = new int[n1];
            int[] tempArrRight = new int[n2];

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
                if (tempArrLeft[i] <= tempArrRight[j]) {
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

        // Write result array to console
        static void WriteArray(int[] arr, string msg) {
            Console.Write(msg);
            for (int i = 0; i < arr.Length; i++) {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}