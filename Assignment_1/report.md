# Assignment 1: Bubble- & Mergesort

## Bubblesort

``` c#
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
```

I implemented the Bubblesort with a nested for-loop. In the first iteration we go through the whole array and always compare the next two numbers adjacent to each other (eg. arr[0] and arr[1], followed by arr[1] and arr[2], ...). We swap the two numbers if the first one is bigger than the second one. 

Because we go from start to end of the array, after each iteration, we can ensure that the highest number is at the end of the array. For the following iterations, we can now always ignore the last index from the previous iteration.

<br>

## Mergesort

``` c#
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
```

For the Mergesort, we start by passing the full Array into the function above, providing the first and last index respectively.

By recursively calling itself, the function will divide the Array into Subarrays, until the first index is not smaller than the last index anymore (meaning the Subarray consists of only one element).

As soon as we have two undivisible Arrays, the function 'Merge' will be called, which will sort and merge together the last two subarrays.

<br>

``` c#
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
```

This function gets the first index of the first subarray(int left), the last index of the first subarray(int mid) and the last index of the second subarray(int right).

With that we can get the number of items in both subarrays and create temporaray arrays of the same size. We then fill those arrays with the correct data in the for-loops.

<br>

``` c#
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
```

Since we know that each subarray in itself is sorted thanks to the recursive approach, we only need to focus on sorting between both subarrays when merging them together.

To sort the two subarrays, we start by comparing the first number of the first subarray with the first number of the second subarray and assigning the smaller number to the correct position in the original Array. We then increment the index of the processed number and compare again, assigning the smaller number to the next position in the original Array. We will stay in this loop, as long as we still have numbers to be sorted in both Arrays. As soon as one Array is finished, we exit the while loop.

<br>

``` c#
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
```

Finally, we will have one subarray fully merged back and one subarray still having numbers left. We can now check which subarray is not fully processed yet and just assign the remaining numbers of that subarray to the next indices of the original array.

After this step, we have fully merged both subarrays and step back to the MergeSort function.

<br>

## Main

``` c#
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
```

To call either sorting algorithm, we look for the keyword "-Bubble" or "-Merge".

We pass every number provided after this keyword into an array. Since we can assume correct input, I have not implemented any format or syntax checking.

After sorting the array, we pass it to the following 'WriteArray' function.

<br>

## WriteArray

``` c#
static void WriteArray(int[] arr, string msg) {
            Console.Write(msg);
            for (int i = 0; i < arr.Length; i++) {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
```

This function just handles correct output of the sorted array by displaying the correct sorting algorithm used and displaying the sorted array afterwards.