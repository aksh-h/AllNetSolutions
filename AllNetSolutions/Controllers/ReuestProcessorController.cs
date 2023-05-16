using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AllNetSolutions.Controllers
{
    [RoutePrefix("api/process")]
    public class ReuestProcessorController : ApiController
    {

        [HttpGet]
        [Route("first")]
        public async Task<IHttpActionResult> GetfirstData()
        {
            List<Result> dicts = new List<Result>();
            try
            {
                var tasks = new List<Task<(string, TimeSpan)>>();

                tasks.Add(CheckNumber());

                var response = await Task.WhenAll(tasks);
                for (int i = 0; i < response.Length; i++)
                {
                    var dict = new Result();
                    dict.status = response[i].Item1;
                    dict.timeTaken = response[i].Item2;
                    dicts.Add(dict);
                }
                return Content(HttpStatusCode.OK, dicts);
            }
            catch (Exception ex)
            {
                var errorResult = new Dictionary<string, string>()
                {
                    { "error", ex.Message }
                };
                return Content(HttpStatusCode.InternalServerError, errorResult);
            }
        }

        [HttpGet]
        [Route("second")]
        public async Task<IHttpActionResult> GetsecondData()
        {
            List<Result> dicts = new List<Result>();
            try
            {
                var tasks = new List<Task<(string, TimeSpan)>>();

                tasks.Add(CheckNumber());

                var response = await Task.WhenAll(tasks);
                for (int i = 0; i < response.Length; i++)
                {
                    var dict = new Result();
                    dict.status = response[i].Item1;
                    dict.timeTaken = response[i].Item2;
                    dicts.Add(dict);
                }
                return Content(HttpStatusCode.OK, dicts);
            }
            catch (Exception ex)
            {
                var errorResult = new Dictionary<string, string>()
                {
                    { "error", ex.Message }
                };
                return Content(HttpStatusCode.InternalServerError, errorResult);
            }
        }

        [HttpGet]
        [Route("third")]
        public async Task<IHttpActionResult> GetthirdData()
        {
            List<Result> dicts = new List<Result>();
            try
            {
                var tasks = new List<Task<(string, TimeSpan)>>();

                tasks.Add(CheckNumber());

                var response = await Task.WhenAll(tasks);
                for (int i = 0; i < response.Length; i++)
                {
                    var dict = new Result();
                    dict.status = response[i].Item1;
                    dict.timeTaken = response[i].Item2;
                    dicts.Add(dict);
                }
                return Content(HttpStatusCode.OK, dicts);
            }
            catch (Exception ex)
            {
                var errorResult = new Dictionary<string, string>()
                {
                    { "error", ex.Message }
                };
                return Content(HttpStatusCode.InternalServerError, errorResult);
            }
        }

        private async Task<(string, TimeSpan)> CheckNumber()
        {
            try
            {
                // generate random array of numbers of length 10

                int[] numb = new int[10];
                Random rnd = new Random();
                for (int i = 0; i < numb.Length; i++)
                {
                    numb[i] = rnd.Next(1, 10);
                }

                // perform binary search on the array
                int min = 0;
                int max = numb.Length - 1;
                int mid = 0;

                // take the minimum of the array as search element

                int search = numb.Min();
                bool found = false;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while (min <= max)
                {
                    mid = (min + max) / 2;
                    if (numb[mid] == search)
                    {
                        found = true;
                        break;
                    }
                    else if (numb[mid] < search)
                    {
                        min = mid + 1;
                    }
                    else
                    {
                        max = mid - 1;
                    }
                }
                stopwatch.Stop();
                if (found)
                {
                    return ("success", stopwatch.Elapsed);
                }
                else
                {
                    return ("failed", stopwatch.Elapsed);
                }

            }
            catch (Exception ex)
            {
                return ("failed", TimeSpan.Zero);
            }



        }
    }
    public class Result
    {
        public string status { get; set; }
        public TimeSpan timeTaken { get; set; }
    }
}