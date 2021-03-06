﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using User.Identity.Services;

namespace User.Identity.Authentication
{
    public class SmsAuthCodeValidator : IExtensionGrantValidator
    {

        private readonly IAuthCodeServices _authCodeService;
        private readonly IUserServices _userServices;

        public SmsAuthCodeValidator(IAuthCodeServices authCodeService, IUserServices userServices)
        {
            _authCodeService = authCodeService;
            _userServices = userServices;
        }
        public string GrantType => "sms_auth_code";

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var phone = context.Request.Raw["phone"];
            var code = context.Request.Raw["auth_code"];
            var errorValidationResult = new GrantValidationResult(TokenRequestErrors.InvalidGrant);

            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(code))
            {
                context.Result = errorValidationResult;
                return;
            }

            //检查验证码
            if (!_authCodeService.Validate(phone,code)) {
                context.Result = errorValidationResult;
                return;
            }

            var userId = _userServices.CheckOrCreate(phone);
            if (userId <= 0)
            {
                context.Result = errorValidationResult;
                return;
            }
            context.Result = new GrantValidationResult(userId.ToString(), GrantType);

        }
    }
}
