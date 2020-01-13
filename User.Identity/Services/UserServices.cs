using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
namespace User.Identity.Services
{
    public class UserServices : IUserServices
    {
        private HttpClient _httpClient;
        private readonly string _userServiceUrl = "http://localhost/";


        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<int> CheckOrCreate(string phone)
        {
            var form = new Dictionary<string, string> { { "phone", phone } };
            var content = new FormUrlEncodedContent(form);
            var response = await _httpClient.PostAsync(_userServiceUrl + "/api/user/check-or-create", content);

            if (response.StatusCode==HttpStatusCode.OK)
            {
                var userId = await response.Content.ReadAsStringAsync();
                int.TryParse(userId,out int  intUsserId);
                return intUsserId;
            }
            return 0; ;

        }
      
    }
}
