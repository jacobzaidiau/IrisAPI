using IrisAPI.Models;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IrisAPI.Services
{
    public class ClusteringService
    {
        public static PredictionEngine<InputModel, ClusterModel> KMeans()
        {
            var context = new MLContext(seed: 0);
            var dataView = context.Data.LoadFromTextFile<InputModel>("./iris.data", hasHeader: false, separatorChar: ',');
            var pipeline = context.Transforms
                .Concatenate("Features", "SepalLength", "SepalWidth", "PetalLength", "PetalWidth")
                .Append(context.Clustering.Trainers.KMeans("Features", numberOfClusters: 3));
            var model = pipeline.Fit(dataView);
            var predictor = context.Model.CreatePredictionEngine<InputModel, ClusterModel>(model);

            return predictor;
        }
    }
}