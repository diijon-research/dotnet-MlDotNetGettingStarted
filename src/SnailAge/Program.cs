using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Transforms;
using Microsoft.ML.Trainers;
using System.Threading.Tasks;
using System.Reflection;

namespace MlDotNetGettingStarted.SnailAge
{
    class Program
    {
        private static string _applicationPath = "";
        private static string _datapath = "";

        static void Main(string[] args)
        {
            _applicationPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().Location).LocalPath);
            _datapath = $"{_applicationPath}/data/abalone.data.txt";
            Console.WriteLine(_datapath);
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
