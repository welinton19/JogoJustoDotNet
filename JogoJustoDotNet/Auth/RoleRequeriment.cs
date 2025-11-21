using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace JogoJustoDotNet.Auth;

public class RoleRequeriment : IAuthorizationRequirement
{
    public string Role { get; }
    public RoleRequeriment(string role)
    {
        Role = role;
    }


}



    


    

