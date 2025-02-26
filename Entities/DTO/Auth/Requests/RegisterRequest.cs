using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Entities.DTO.Auth.Requests;

public class RegisterRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    [EmailAddress] public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int RoleId { get; set; }
}