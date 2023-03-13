namespace inCommodities.test.external.Services
{
    public class LogicService
    {
        private static String logicServicePath = "https://localhost:7235/";
        private static String WindStationBasePath = "WindStation";
        private static String MarketPricePath = "MarketPrice";
        private static String ProductionTargetPath = "ProductionTarget";
        private static String ExpectedProductionPath = "ExpectedProduction";

        private static HttpResponseMessage doHttpGetRequest(String url)
        {
            var client = new HttpClient();
            var webRequest = new HttpRequestMessage(HttpMethod.Get, logicServicePath + url);
            var response = client.Send(webRequest);

            return response;
        }

        private static HttpResponseMessage doHttpPutRequest(String url)
        {
            var client = new HttpClient();
            var webRequest = new HttpRequestMessage(HttpMethod.Put, logicServicePath + url);
            var response = client.Send(webRequest);
            return response;
        }

        public static HttpResponseMessage GetCurrentMarketPrice()
        {
            return doHttpGetRequest($"{WindStationBasePath}/{MarketPricePath}");
        }

        public static HttpResponseMessage SetCurrentMarketPrice(uint marketPrice)
        {
            return doHttpPutRequest($"{WindStationBasePath}/{MarketPricePath}/{marketPrice}");
        }

        public static HttpResponseMessage GetCurrentProductionTarget()
        {
            return doHttpGetRequest($"{WindStationBasePath}/{ProductionTargetPath}");
        }

        public static HttpResponseMessage UpdateCurrentProductionTarget(int delta)
        {
            return doHttpPutRequest($"{WindStationBasePath}/{ProductionTargetPath}/{delta}");
        }

        public static HttpResponseMessage GetExpectedProduction()
        {
            return doHttpGetRequest($"{WindStationBasePath}/{ExpectedProductionPath}");
        }
    }
}

