using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BlazorDemoClient.Contracts;
using BlazorDemoClient.Models;
using hockey.Api;
using Microsoft.AspNetCore.Components;

namespace BlazorDemoClient.Api
{
    public class HockeyApi : IHockeyApi
    {
        private const string BaseUrl = "https://statsapi.web.nhl.com/api/v1";
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public HockeyApi(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<Team>> GetTeams()
        {
            var json = await _httpClient.GetJsonAsync<TeamsDto>($"{BaseUrl}/teams");
            var logos = await GetLogos();
            var teams = _mapper.Map<List<Team>>(json.Teams);

            foreach (var team in teams)
            {
                team.Logo = logos.Single(x => x.Id == team.Id).Url;
            }

            return teams;
        }

        public async Task<List<LogoDto>> GetLogos() => await _httpClient.GetJsonAsync<List<LogoDto>>("sample-data/logos.json");
    }
}