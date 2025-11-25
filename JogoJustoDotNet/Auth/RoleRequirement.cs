using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace JogoJustoDotNet.Auth;

public class RoleRequirement : IAuthorizationRequirement
{
    public string Role { get; }
    public RoleRequirement(string role)
    {
        Role = role;
    }


}



    


    

