using ImportRobot.Entities;
using ImportRobot.Services;
using Microsoft.Extensions.Logging;

namespace ImportRobot
{
    public class Runner 
    {
        private readonly ILogger<Runner> _logger;
        private IRepository _repo = new Repository(new CapDbContext());

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        public void DoAction(string name)
        {
            _logger.LogDebug("Doing hard work! {Action}", name);
            int count = _repo.GetMaterialsCount();
            _logger.LogDebug($"Count materials: {count}");
        }
    }
}