﻿using Core.Models.Shared;

namespace Core.Models.Account.ViewModels;

public class ProfileViewModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public AlertViewModel? AlertViewModel { get; set; }
}