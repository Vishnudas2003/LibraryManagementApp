﻿using Core.Models.Account.VM;
using Microsoft.AspNetCore.Identity;

namespace Services.Interfaces.Services.Authorization;

public interface IRegisterService
{
    Task<IdentityResult> RegisterUserAsync(RegisterViewModel registerViewModel);
}