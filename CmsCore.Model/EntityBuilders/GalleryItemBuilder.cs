﻿using CmsCore.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CmsCore.Model.EntityBuilders
{
    public class GalleryItemBuilder
    {
        public GalleryItemBuilder(EntityTypeBuilder<GalleryItem> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            entityBuilder.HasOne(p => p.Gallery).WithMany(gi => gi.GalleryItems).HasForeignKey(g => g.GalleryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
