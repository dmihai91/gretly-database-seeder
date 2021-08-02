#r "references\Gretly.dll"
#r "nuget:Newtonsoft.Json"
#load "FaunaDBClient.csx"
#load "DBConstants.cs"

using System;
using System.Reflection.Emit;
using System.Threading.Tasks;
using FaunaDB.Types;
using Gretly.Models;
using Newtonsoft.Json;

using static FaunaDB.Query.Language;

async Task<bool> RoleExists(string name)
{
    try
    {
        var response = await FaunaDbClient.QueryDb(
            Map(
                Paginate(Match(Index(DBIndexes.ROLE_BY_NAME), name)),
                Lambda("ref", Get(Var("ref")))
            )
        );
        FaunaResultDto[] data = Decoder.Decode<FaunaResultDto[]>(response.At("data"));
        if (data.Length > 0)
        {
            return true;
        }
        return false;
    }
    catch (Exception ex)
    {
        Console.Write(ex.ToString());
        return false;
    }
}