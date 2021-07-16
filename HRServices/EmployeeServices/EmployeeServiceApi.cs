using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace HRServices.EmployeeServices
{

    public class EmployeeServiceApiConfig
    {
        public string ApiUrl { get; set; }
    }
    public class EmployeeServiceApi : IEmployeeService
    {
        private HttpClient _httpclient;
        private readonly EmployeeServiceApiConfig _apiUrlConfig;
        public EmployeeServiceApi(HttpClient httpClient, IOptionsMonitor<EmployeeServiceApiConfig> optionsMonitor)
        {
            _httpclient = httpClient;
            _apiUrlConfig = optionsMonitor.CurrentValue;

        }
        /// <summary>Get List of Employees
        /// <para>Provides a list of current employees</para>
        /// </summary>
        public IEnumerable<Employee> ListEmployees()
        {
            var employeeList = ListEmployeesAsync().Result.Data;
            
            return employeeList;
        }

        private async Task<EmployeeApiResponse> ListEmployeesAsync()
        {
            EmployeeApiResponse result = null;
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_apiUrlConfig.ApiUrl),
                Method = HttpMethod.Get
            };
            var response = await _httpclient.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<EmployeeApiResponse>();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase, null, response.StatusCode);
            }
            return result;
        }
    }
}
