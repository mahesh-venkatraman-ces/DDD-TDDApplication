﻿using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Json;
using TestApplication.Contracts.Config;
using TestApplication.Contracts.UserDetails;

namespace TestApplication.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly UserApiOptions _apiConfig;
        public UserService(HttpClient httpClient, IOptions<UserApiOptions> apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var userResponse = await _httpClient.GetAsync(_apiConfig.EndPoint);
            if (userResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<User>();
            }
            var responseContent =userResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();
        }
    }
}
