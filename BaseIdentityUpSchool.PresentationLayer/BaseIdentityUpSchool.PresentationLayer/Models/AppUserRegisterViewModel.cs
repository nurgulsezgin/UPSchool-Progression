// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace BaseIdentityUpSchool.PresentationLayer.Models
{
    public class AppUserRegisterViewModel
    {
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Mail boş geçilemez")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar boş geçilemez")]
        public string ConfirmPassword { get; set; }
    }
}
