using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForDanskeBank.ViewModels;

namespace WebApplicationForDanskeBank.Controllers
{
    public class SortingNumberController : Controller
    {
        [HttpGet]
        [Route("Number/Sorting")]
        public IActionResult CreateSortingNumber()
        {
            var sortingNumberViewModel = new SortingNumberViewModel();
            
            return View(sortingNumberViewModel);
        }
        [HttpPost]
        [Route("Number/Sorting")]
        public IActionResult CreateSortingNumber(SortingNumberViewModel sortingNumberViewModel)
        {
            //var sortingNumberViewModel = new SortingNumberViewModel();
            if (ModelState.IsValid)
            {
                string[] splited = sortingNumberViewModel.Numbers.Split(" ");
                int[] numberArr = splited.Select(int.Parse).ToArray();
                //List<int> sorted = new List<int>();
                var watch = System.Diagnostics.Stopwatch.StartNew();
                if (!watch.IsRunning)
                    watch.Start();
                if (sortingNumberViewModel.SortingType == "quicksort")
                {
                    QuickSort(numberArr, 0, numberArr.Length - 1);
                }
                else if(sortingNumberViewModel.SortingType == "mergesort")
                {
                    MergeSort(numberArr, 0, numberArr.Length - 1);
                }
                else
                {
                    BubbleSort(numberArr);
                }
                storeArray(numberArr,watch);
            }
            return View(sortingNumberViewModel);
            //return RedirectToAction("CreateSortingNumber", "SortingNumber");
        }
        public void QuickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }
        public int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        public void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }
        public void Merge(int[] input, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }
        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }
        static void storeArray(int[] arr, System.Diagnostics.Stopwatch watch)
        {
            //int n = arr.Length;
            
                using (StreamWriter writer = new StreamWriter("C:\\WebApplicationWithAPI.NetCore\\Result.txt"))
                {
                    Console.SetOut(writer);
                   //Console.WriteLine("hi");
                    for (int i = 0; i < arr.Length; ++i)
                    Console.WriteLine(arr[i] + " ");
                    watch.Stop();
                   Console.WriteLine($"Total Execution Time: {watch.ElapsedMilliseconds} ms");
                }

           
        }
    }
}
