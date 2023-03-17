// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace UpSchool_CQRS_UILayer.DAL.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Faculty { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
        public int Age { get; set; } 
    }
}
