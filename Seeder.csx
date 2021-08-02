#r "references\Gretly.dll"
#r "nuget:Serilog"

#load "FaunaDBClient.csx"
#load "Queries.csx"
#load "Roles.cs"
#load "DBConstants.cs"

using System.Threading.Tasks;
using FaunaDB.Errors;
using Gretly.Models;
using Serilog;
using System.Collections.Generic;
using FaunaDB.Types;
using Newtonsoft.Json;

// insert roles into databasex
var roles = Roles.GetRoles();
foreach (var role in roles)
{
    try
    {
        if (!await RoleExists(role.Name))
        {
            await FaunaDbClient.CreateDocument(DBCollections.ROLE, role.Id, new Role(role));
        }
    }
    catch (FaunaException ex)
    {
        Log.Error(ex.Errors.ToString());
    }
}