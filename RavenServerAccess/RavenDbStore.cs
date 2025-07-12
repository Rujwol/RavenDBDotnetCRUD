using Raven.Client.Documents;

namespace RavenDbAccessLayer
{
    public static class RavenDbStore
    {
        private static readonly Lazy<IDocumentStore> lazyStore = new Lazy<IDocumentStore>(() =>
        {
            var store = new DocumentStore
            {
                Urls = new[] { "http://127.0.0.1:8080/" },
                Database = "RTest1"
            }.Initialize();

            return store;
        });

        public static IDocumentStore Store => lazyStore.Value;
    }
}
