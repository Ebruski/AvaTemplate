using Application.Common.Interfaces.Service;
using System.Threading.Tasks;

namespace Infrastructure.Services.FakeServices
{
    public class FakeTestService : ITestService
    {
        public Task CallTest()
        {
            throw new System.NotImplementedException();
        }
    }
}
