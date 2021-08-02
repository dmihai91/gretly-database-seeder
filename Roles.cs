using Gretly.Models;

public class Roles
{
    private Role[] roles;
    private static Roles instance = null;

    public Roles()
    {
        roles = new Role[] {
                new Role("1", "User", new Permission[]{
                    // permissions for user_profile resource
                    new Permission(Resource.USER_PROFILE, PermissionType.READ, 1),
                    new Permission(Resource.USER_PROFILE, PermissionType.WRITE, 1),
                    new Permission(Resource.USER_PROFILE, PermissionType.MODIFY, 1),
                    new Permission(Resource.USER_PROFILE, PermissionType.DELETE, 1),

                    // permissions for user resource
                    new Permission(Resource.USER, PermissionType.READ, 1),
                    new Permission(Resource.USER, PermissionType.WRITE, 0),
                    new Permission(Resource.USER, PermissionType.MODIFY, 0),
                    new Permission(Resource.USER, PermissionType.DELETE, 0),
                    
                    // permissions for project resource
                    new Permission(Resource.PROJECT, PermissionType.READ, 1),
                    new Permission(Resource.PROJECT, PermissionType.WRITE, 1),
                    new Permission(Resource.PROJECT, PermissionType.MODIFY, 1),
                    new Permission(Resource.PROJECT, PermissionType.DELETE, 1),

                    // permissions for ads resource
                    new Permission(Resource.ADS, PermissionType.READ, 1),
                    new Permission(Resource.ADS, PermissionType.WRITE, 0),
                    new Permission(Resource.ADS, PermissionType.MODIFY, 0),
                    new Permission(Resource.ADS, PermissionType.DELETE, 0),
                }),
                new Role("2", "Admin", new Permission[]{
                     // permissions for user_profile resource
                    new Permission(Resource.USER_PROFILE, PermissionType.READ, 1),
                    new Permission(Resource.USER_PROFILE, PermissionType.WRITE, 1),
                    new Permission(Resource.USER_PROFILE, PermissionType.MODIFY, 1),
                    new Permission(Resource.USER_PROFILE, PermissionType.DELETE, 1),

                    // permissions for user resource
                    new Permission(Resource.USER, PermissionType.READ, 1),
                    new Permission(Resource.USER, PermissionType.WRITE, 1),
                    new Permission(Resource.USER, PermissionType.MODIFY, 1),
                    new Permission(Resource.USER, PermissionType.DELETE, 1),
                    
                    // permissions for project resource
                    new Permission(Resource.PROJECT, PermissionType.READ, 1),
                    new Permission(Resource.PROJECT, PermissionType.WRITE, 1),
                    new Permission(Resource.PROJECT, PermissionType.MODIFY, 1),
                    new Permission(Resource.PROJECT, PermissionType.DELETE, 1),
                }),
            };
    }

    public static Role[] GetRoles()
    {
        if (instance == null)
        {
            instance = new Roles();
        }
        return instance.roles;
    }
}