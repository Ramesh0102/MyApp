using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;
using MyApp.iOS;

[assembly: Dependency(typeof(PhoneDialer))]

namespace MyApp.iOS
{
    public class PhoneDialer : IDailer
    {
        public Task<bool> DialAsync(string number)
        {
            return Task.FromResult(
                UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number))
            );
        }
    }
}
