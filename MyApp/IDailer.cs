using System;
using System.Threading.Tasks;

namespace MyApp
{
    public interface IDailer
    {
        Task<bool> DialAsync(string number);
    }
}
