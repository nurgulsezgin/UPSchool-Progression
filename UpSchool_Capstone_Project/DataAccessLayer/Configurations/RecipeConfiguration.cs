// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLayer.Concrete;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<RecipeDetail>
    {
        public void Configure(EntityTypeBuilder<RecipeDetail> builder)
        {



            //builder.HasOne(x => x.VideoUrl).WithMany(x => x.WorkRequests).HasForeignKey(x => x.AssignedUserId);

            //builder.Property(x => x.Title).HasMaxLength(300);
            //builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.VideoUrl).HasMaxLength(200);
        }
    }
}
