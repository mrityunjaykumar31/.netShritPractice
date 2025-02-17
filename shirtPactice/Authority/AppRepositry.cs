namespace shirtPactice.Authority
{
    public static class AppRepositry
    {
        private static List<Application> _application = new List<Application>() { 
            new Application()
            {
                ApplicationId = 1,
                ApplicationName = "TestAuthentication",
                ClientId = "c9fe56d8-ac25-431c-9b41-3f1bdc07bd5c",
                Secret = "bc3e0c53-fd27-4ab0-ad00-8cce451d9ef3",
                Scopes = "read"
            }
        };

        public static bool Authenticate(string clientId, string secret) {
            return _application.Any(x => x.ClientId == clientId && x.Secret == secret);
        }

        public static Application? GetApplicationByClientId(string clentId)
        {
            return _application.FirstOrDefault(x => x.ClientId == clentId);
        }
    }
}
