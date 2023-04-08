// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configurations
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpsPort { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public string Password { get; set; }

    }
}
