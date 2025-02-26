﻿namespace ProductAPI.Entities.DTO.Auth.Responses;

public class LoginResponse
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}