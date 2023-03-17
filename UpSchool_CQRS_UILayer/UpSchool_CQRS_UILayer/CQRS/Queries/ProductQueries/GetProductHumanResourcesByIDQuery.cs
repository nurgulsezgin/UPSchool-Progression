// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace UpSchool_CQRS_UILayer.CQRS.Queries.ProductQueries
{
    public class GetProductHumanResourcesByIDQuery
    {
        public int ID { get; set; }

        public GetProductHumanResourcesByIDQuery(int id)
        {
            ID = id;
        }
    }
}
