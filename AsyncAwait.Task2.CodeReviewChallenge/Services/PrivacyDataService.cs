using AsyncAwait.Task2.CodeReviewChallenge.Constants;

namespace AsyncAwait.Task2.CodeReviewChallenge.Services;

public class PrivacyDataService : IPrivacyDataService
{
    public string GetPrivacyData()
    {
        return PrivacyDataConstants.PersonalDataPolicy;
    }
}
