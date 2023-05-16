using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace APITests
{
    [TestClass]
    public class CheckNumberExists
    {
        private HttpClient _httpClient;

        public CheckNumberExists() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:54036/");
        }

        [TestMethod]
        public void ChecNumberExistsOrNo()
        {
            Random rnd = new Random();
            int numToCheck = rnd.Next(1, 10);

            var response = _httpClient.GetAsync($"api/checknumberexist/{numToCheck}").Result;
            var resContent = response.Content.ReadAsStringAsync().Result;
            List<Result> results = JsonConvert.DeserializeObject<List<Result>>(resContent);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(results.Count > 0);
            Assert.AreEqual(numToCheck.ToString(), results[0].status);
            Assert.AreEqual(true, results[0].timeTaken.TotalMilliseconds > 0);
        }
    }

    public class Result
    {
        public string status { get; set; }
        public TimeSpan timeTaken { get; set; }
    }
}
