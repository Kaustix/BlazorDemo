using AutoMapper;
using BlazorDemoClient.Contracts;
using BlazorDemoClient.Models;

namespace BlazorDemoClient.Mappers
{
    public class HockeyProfile : Profile
    {
        public HockeyProfile()
        {
            CreateMap<TeamDto, Team>();
        }
    }
}