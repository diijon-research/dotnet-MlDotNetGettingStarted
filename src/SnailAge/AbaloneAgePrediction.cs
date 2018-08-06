using Microsoft.ML.Runtime.Api;

namespace MlDotNetGettingStarted.SnailAge
{
    public class AbaloneAgePrediction
    {
        [ColumnName("Score")]
        public float Age;
    }
}
