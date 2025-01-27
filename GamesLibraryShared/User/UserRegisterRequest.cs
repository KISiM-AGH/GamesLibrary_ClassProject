﻿namespace GamesLibraryShared.User;

public class UserRegisterRequest
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password {  get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
}