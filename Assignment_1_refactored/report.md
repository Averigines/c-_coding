# Assignment 2: Bubble- & Mergesort Refactored

## Interface

``` c#
interface ISort<T> {
        T[] Sort(T[] arr);
    }

```

I added this very simple interface with generic type, from which both classes (BubbleSort & MergeSort) inherit.

<br>

## Bubblesort

``` c#
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

```

The BubbleSort is now a class with the Sort method that extends from the ISort interface.

<br>

## Mergesort

``` c#
class MergeSort<T> : ISort<T> where T : IComparable<T> {
        public T[] Sort(T[] arr) {
            MergeSplit(arr, 0, arr.Length - 1);
            return arr;
        }
```

Same goes for MergeSort, where the Sort method initially calls the recursive function, which stays pretty much the same, except for again changing variables to be genereic where needed.

<br>

## Main

``` c#
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
```

We are now checking if we want to sort Integers or Strings and depending on that initialize the array with the correct type. We then create an instance of the class with which we want to sort and call class.Sort(arr).