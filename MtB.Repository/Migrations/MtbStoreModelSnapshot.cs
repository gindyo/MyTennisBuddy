﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.Providers;

namespace Repository.Migrations
{
    [DbContext(typeof(MtbDbContext))]
    partial class MtbStoreModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("MtB.Repository.Entities.CommunicationCapabilityRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FriendId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.ToTable("CommunicationCapabilities");
                });

            modelBuilder.Entity("MtB.Repository.Entities.BuddyRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhoneNmuber");

                    b.Property<string>("Email");

                    b.Property<Guid>("ExternalId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Position");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("BuddyRecords");
                });

            modelBuilder.Entity("MtB.Repository.Entities.CommunicationCapabilityRecord", b =>
                {
                    b.HasOne("MtB.Repository.Entities.BuddyRecord")
                        .WithMany("ComunicationCapabilities")
                        .HasForeignKey("FriendId");
                });
#pragma warning restore 612, 618
        }
    }
}
