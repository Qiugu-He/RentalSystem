using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IssueTrackerV1.Dtos;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.App_Start
{
    public class MappingProfile: Profile
    {   
        //constructor
        public MappingProfile()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();
        }


    }
}