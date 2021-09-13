using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationForDanskeBank.ViewModels
{
    public class SortingNumberViewModel
    {
        [DisplayName("Number")]
       //[Required(ErrorMessage = "Number is required.")]
        //[Range(1, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        //[RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only integer values are allowed.")]
        public string Numbers { get; set; }

        [DisplayName("Sorting Type")]
        //[Required(ErrorMessage = "Sorting Type is required.")]
        public string SortingType { get; set; }

        public List<SelectListItem> SortingTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "bubblesort", Text = "Bubble Sort" },
            new SelectListItem { Value = "mergesort", Text = "Merge Sort" },
            new SelectListItem { Value = "quicksort", Text = "Quick Sort"  },
        };
    }

    public enum SortingTypeEnum
    {

        [Display(Name = "Bubble Sort")]
        bubblesort = 1,
        [Display(Name = "Merge Sort")]
        mergesort = 2,
        [Display(Name = "Quick Sort")]
        quicksort = 3
        
    }
}
