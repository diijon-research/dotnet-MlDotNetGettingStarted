using System;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Transforms;
using Microsoft.ML.Trainers;
using System.Threading.Tasks;


namespace MlDotNetGettingStarted.SnailAge
{
    class Program
    {
        private static string _datapath;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static async Task<PredictionModel<Abalone, AbaloneAgePrediction>> Train()
        {
            var pipeline = new LearningPipeline
            {
                new TextLoader(_datapath).CreateFrom<Abalone>(separator: ','),
                new ColumnCopier(("Age", "Label")),
                new CategoricalOneHotVectorizer("Sex"),
                new ColumnConcatenator("Features",
                "Sex",
                "Length",
                "Diameter",
                "Height",
                "WholeWeight",
                "ShellWeight"),
                new FastTreeRegressor()
            };

            return null;
        }
    }
}
