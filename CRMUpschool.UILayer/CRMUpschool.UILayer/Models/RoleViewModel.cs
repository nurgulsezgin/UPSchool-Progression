// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace CRMUpschool.UILayer.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Lütfen rol adını boş geçmeyiniz")]
        public string RoleName { get; set; }
    }
}
