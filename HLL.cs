


    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan averageLifetimeHllTime = TimeSpan.Zero;
            var DocumentAnalyticsLifetimeHLLCountsAccessmul = "H4sIAAAAAAAEAAE7A8T8AgABAAEOAAAAA2QAAAAd0MiifRKxC6O+d+sdD/2okEB3S9THvdSUkFkgv1REMXpYw3+SKLdP/38HSdOfCF0t9tmoWnujUCEzY57zPT6BW3nUs2FxUEI9Rva3Yd6AJm9VSkSJYmT5qugQxY0Q72yiTTZ3bTKDi6YDJTMLm5ZVrJkE9kLc1XmS4GpaRNR9iYnmgUgcGN8VrJ2SfCGvjfdssNxFWEL1URFH6mNub6PRQqtlT97ddxuN1vr5DtpI2c5NAfB3oVNlhIarM6v8wqwJ/DarLgowOCfxeUKCOLAZA1P/rngTUJjs0fcH5kIFWZqAy7i3i9QJGNrMKioHDOqJxk7oyioSEh3foIeXwGao9EkFFPTWhx6HNB1xuACTGmgFokVHG+v27Yv2hU2J/UinhLdKamCu09e1adt07cOmpkpXCOqLiD4qMhB7xRN2tkMXhHLZWAZ7c/yadwsvrDBt/m29y7iulT8JgGzYLTNGR2PP/u2A8Izy/BJ9SbOMnUEtBuwXYQLisNaCZh10+1oqdNXcamdgtYW8CtKvbMLypiWdXQXbvSQSyOsH+ivna7HH/pDru+fmAv9SYZAW5qeY08vERwH7o/3WZSdWJm1opkYtvnZs48DECM9bSqKa0mvcmdV7v0/IwJ54CgE622ObbdVA10bVdXh8u7nNvZ+jcgRqCsyK+m8RavbDiIm8vcvDcgYb3ENeO+y5G76NO3fgbSKGCMwLTMMcgyVQMX3nq4ut/DhGJnxlxqVecoOtx4sFSJpM0EemZoPKZDRA4GJrfiznFyCAciS6ISjT2CCFSMXpQ6/zQjVIYwCKmltk/IDr35Rtf4YaRqE94I67hsYFRho+yAqrgJ7h/N1xZEbyKCOfroXo33SgX0PG8sfZKCoiqtx6kV7w2+2vy2KUJwPCrMiobP/ocll+BXQhbtuqN6Aoaru7uA6aJJzZbGNPJZ/BqysN49qeZwHNRND64LSRAScGfcjgdlIanoguhDiTmAjKEqb5h3tQjqABYXqNnP2YgNRnBmGvj46twU0qcHi6n2ly1wXDLz1JLc1iAet/B5zTKk0cao0lJfffKfe9BWQAAAAAAAAABQAAAACGjWtvOwMAAA==,H4sIAAAAAAAEAGNiYGRg5GNgYGDmAhIZHy943LbmyK1ac21eGYvqr6RZC83YpCpdF3eYdWx4vTllyp0tkzcb2URsvXhJ9Ez2hmt+OSzqpiJNPq+PqrBZbTxdccZrir7njsW269pFuKa8uZYLMhMEWEEEAJNkQr1rAAAA,H4sIAAAAAAAEAGNiYGRg5GNgYGDmAhIZHy943LbmyK1ac21eGYvqr6RZC83YpCpdF3eYdWx4vTllyp0tkzcb2URsvXhJ9Ez2hmt+OSzqpiJNPq+PqrBZbTxdccZrir7njsW269pFuKa8uZYLMhMEWEEEAJNkQr1rAAAA";
            string[] list2 = DocumentAnalyticsLifetimeHLLCountsAccessmul.Split(',');
          
            int lifetimeViews = 0;
            List<CardinalityEstimator> resultOfLifeTimeCounts = new List<CardinalityEstimator>();
            
                #region lifetimehllcounts
                Stopwatch lifetimehllcountsWatch = new Stopwatch();
                lifetimehllcountsWatch.Start();
                string DocumentAnalyticsLifetimeHLLCountsAccess = list2[i % 6];
                byte[] byteArray2 = Convert.FromBase64String((DocumentAnalyticsLifetimeHLLCountsAccess));//LifetimeHLLCounts  cardinalityEstimatorSerializer
                MemoryStream stream2 = new MemoryStream(byteArray2);
                var dstream2 = new GZipStream(stream2, CompressionMode.Decompress);
                var reader2 = new BinaryReader(dstream2, Encoding.UTF8, true);
                var SerializedLifetimeHLLCountsAccess = DeserializeCardinalityEstimatorWithCount(reader2);
                lifetimeViews += SerializedLifetimeHLLCountsAccess.ActionCount;
                resultOfLifeTimeCounts.Add(SerializedLifetimeHLLCountsAccess.CardinalityEstimatorDistinctUsers);
                var ans = CardinalityEstimator.Merge(resultOfLifeTimeCounts);
                resultOfLifeTimeCounts.Clear();
                resultOfLifeTimeCounts.Add(ans);
                lifetimehllcountsWatch.Stop();
                averageLifetimeHllTime += lifetimehllcountsWatch.Elapsed;

            Console.WriteLine("PRESS A KEY");
        }

        public static CardinalityEstimatorWithCount DeserializeCardinalityEstimatorWithCount(BinaryReader reader)
        {
            CardinalityEstimatorSerializer cardinalityEstimatorSerializer = new CardinalityEstimatorSerializer();
            CardinalityEstimator estimator = cardinalityEstimatorSerializer.Read(reader);
            int count = reader.ReadInt32();
            bool wasThrottled = reader.ReadBoolean();
            return new CardinalityEstimatorWithCount(estimator, count);
        }
     
    }
