#r "References/FaunaDB.Client.dll"
#r "nuget:DotNetEnv"

using System.Threading.Tasks;
using FaunaDB.Client;
using FaunaDB.Types;

using static FaunaDB.Query.Language;

public class FaunaDbClient
{
    private static string ENDPOINT = null;
    private static string SECRET = null;
    private static FaunaClient client = null;

    public static void Init(string secret, string endpoint)
    {
        SECRET = secret;
        ENDPOINT = endpoint;
    }

    public static FaunaClient GetClient()
    {
        if (client == null)
        {
            client = new FaunaClient(secret: SECRET, endpoint: ENDPOINT);
        }
        return client;
    }

    public static async Task<Value> CreateDocument(string collection, string refId, object data)
    {
        var client = GetClient();
        return await client.Query(
            Create(
                Ref(Collection(collection), refId),
                Obj("data", Encoder.Encode(data))
            )
        );
    }

    public static async Task<Value> GetDocuments(string collection)
    {
        var client = GetClient();
        return await client.Query(Map(
            Paginate(Documents(Collection(collection))),
            Lambda(x => Get(x)))
        );
    }

    public static async Task<Value> QueryDb(FaunaDB.Query.Expr query)
    {
        var client = GetClient();
        return await client.Query(query);
    }
}

DotNetEnv.Env.Load();

FaunaDbClient.Init(System.Environment.GetEnvironmentVariable("FAUNA_DB_SECRET"),
    System.Environment.GetEnvironmentVariable("FAUNA_DB_ENDPOINT"));