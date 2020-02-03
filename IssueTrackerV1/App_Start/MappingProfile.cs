using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IssueTrackerV1.Dtos;
using IssueTrackerV1.Migrations;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.App_Start
{
    public class MappingProfile: Profile
    {   
        //constructor
        public MappingProfile()
        {      
            //Domain to Dto
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<Issue, IssueDto>();

            //Dto to Domain
            Mapper.CreateMap<UserDto, User>()
                .ForMember(u => u.Id, opt => opt.Ignore());

            Mapper.CreateMap<IssueDto, Issue>()
                .ForMember(u => u.Id, opt => opt.Ignore());

        }

    }
}