using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudApiProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace CloudApiProject.Controllers
{
    [Route("api/v1/results")]
    public class ResultsController : Controller
    {
        [HttpGet]
        public List<Result> getResults()
        {
            List<Result> x = new List<Result>();
            return x;
        }
        [Route("{id}")]
        [HttpGet]
        public Result getResult(int id)
        {
            Result k = new Result();
            return k;

        }
        [Route("{id}")]
        [HttpPut]
        public void UpdateResult(int id)
        {

        }
        [HttpPost]
        public void addNewResults()
        {

        }
    } 
}