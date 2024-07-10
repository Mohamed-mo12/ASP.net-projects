using System.ComponentModel.DataAnnotations;

namespace Kitchen.Model
{
    public enum SubscriptionEnum
    {
        [Display(Name = "1 Month")]
        OneMonth = 1,
        [Display(Name = "6 Months")]
        SixMonths = 6,
        [Display(Name = "1 Year")]
        OneYear = 12

    }
}
