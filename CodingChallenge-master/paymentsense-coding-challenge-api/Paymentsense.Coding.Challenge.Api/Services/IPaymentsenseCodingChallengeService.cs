﻿using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface IPaymentsenseCodingChallengeService
    {
        Task<List<Country>> GetCountries();
    }
}
