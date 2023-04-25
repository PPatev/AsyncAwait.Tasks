using System.Threading.Tasks;

namespace AsyncAwait.Task2.CodeReviewChallenge.Services
{
    public interface ICloudService
    {
        Task<string> GetVisitsCountAsync(string requestPath);
    }
}
