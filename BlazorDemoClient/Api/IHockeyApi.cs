using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDemoClient.Models;
using hockey.Api;

namespace BlazorDemoClient.Api
{
    public interface IHockeyApi
    {
        Task<List<Team>> GetTeams();
        Task<List<LogoDto>> GetLogos();
    }
}