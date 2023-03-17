// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace CRMUpschool.UILayer.Models
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]//Kısıtlamalrın apıldığı attribute dur
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numarınızı giriniz")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor lütfen tekrar deneyiniz")]
        public string ConfirmPassword { get; set; }
    }
}
