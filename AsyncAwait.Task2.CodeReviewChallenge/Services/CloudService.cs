using CloudServices.Interfaces;
using System;
using System.Threading.Tasks;

namespace AsyncAwait.Task2.CodeReviewChallenge.Services
{
    public class CloudService : ICloudService
    {
        private readonly IStatisticService _statisticService;

        public CloudService(IStatisticService statisticService)
        {
            _statisticService = statisticService ?? throw new ArgumentNullException(nameof(statisticService));
        }

        public async Task<string> GetVisitsCountAsync(string requestPath)
        {
            await _statisticService.RegisterVisitAsync(requestPath).ConfigureAwait(false);

            var visitsCount = await _statisticService.GetVisitsCountAsync(requestPath);

            return visitsCount.ToString();
        }
    }
}
