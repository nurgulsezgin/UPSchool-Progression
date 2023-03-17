// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace CRMUpschool.UILayer.Areas.Employee.Models
{
    public class MailRequest
    {
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
    }
}
