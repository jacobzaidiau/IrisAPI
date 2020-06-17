using System;
using System.Collections.Generic;
using System.IO;
using IrisAPI.Models;
using IrisAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IrisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClusterController : ControllerBase
    {
        // GET: api/<ClusterController>
        [HttpGet]
        public IEnumerable<OutputModel> Get()
        {
            var predictor = ClusteringService.KMeans();
            List<OutputModel> output = new List<OutputModel>();

            StreamReader file = new StreamReader("./iris.data");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] splitLine = line.Split(',');
                InputModel irisData = new InputModel 
                { 
                    SepalLength = float.Parse(splitLine[0]), 
                    SepalWidth = float.Parse(splitLine[1]), 
                    PetalLength = float.Parse(splitLine[2]), 
                    PetalWidth = float.Parse(splitLine[3]) 
                };

                var prediction = predictor.Predict(irisData);
                output.Add(new OutputModel(irisData, prediction.PredictedClusterId));

            }
            file.Close();
            return output;
        }
    }
}
