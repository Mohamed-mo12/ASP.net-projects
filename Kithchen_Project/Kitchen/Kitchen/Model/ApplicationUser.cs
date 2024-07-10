using Microsoft.AspNetCore.Identity;

namespace Kitchen.Model
{
    public class ApplicationUser : IdentityUser<int>
    {
        public SubscriptionEnum Subscription_Duration { get; set; }
        
    }
}
