﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IssueTrackerV1.Models;

namespace IssueTrackerV1.ViewModels
{
    public class NewUserViewModel
    {
        public IEnumerable <MembershipType> MembershipTypes { get; set; }
        public User User { get; set; }
    }
}