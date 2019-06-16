


    class Program
    {
        static void Main(string[] args)
        {
            var binaryProperty = "Base64 int string(typical binary property) ";
            int someProperty = 0;
            List<CardinalityEstimator> temp = new List<CardinalityEstimator>();
            
                byte[] byteArray2 = Convert.FromBase64String((binaryProperty));
                MemoryStream stream2 = new MemoryStream(byteArray2);
                var dstream2 = new GZipStream(stream2, CompressionMode.Decompress);
                var reader2 = new BinaryReader(dstream2, Encoding.UTF8, true);
                var yourObject = DeserializeCardinalityEstimatorWithCount(reader2);
                someProperty += yourObject.ActionCount;
                // listContainingMergedResults is an object containing various properties amongst which one is the property which is HLL and merged
                // say i have aproperty of distinct users
                listContainingMergedResults.Add(yourObject.CardinalityEstimatorDistinctUsers);// here we merge the distinct users
                var ans = CardinalityEstimator.Merge(temp);
                temp.Clear();
                temp.Add(ans);

            Console.WriteLine("PRESS A KEY");
        }

        public static CardinalityEstimator DeserializeCardinalityEstimatorWithCount(BinaryReader reader)
        {
            CardinalityEstimatorSerializer cardinalityEstimatorSerializer = new CardinalityEstimatorSerializer();
            CardinalityEstimator estimator = cardinalityEstimatorSerializer.Read(reader);
            return estimator;
        }
     
    }
