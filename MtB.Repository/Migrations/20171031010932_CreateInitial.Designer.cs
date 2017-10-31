﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MtB.Repository.Providers;
using System;

namespace MtB.Repository.Migrations
{
    [DbContext(typeof(MtbStore))]
    [Migration("20171031010932_CreateInitial")]
    partial class CreateInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("MtB.Repository.Entities.CommunicationCapability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("FriendId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.ToTable("CommunicationCapabilities");
                });

            modelBuilder.Entity("MtB.Repository.Entities.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CellPhoneNmuber");

                    b.Property<string>("Email");

                    b.Property<Guid>("ExternalId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("NotificationSequenceNumber");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("MtB.Repository.Entities.CommunicationCapability", b =>
                {
                    b.HasOne("MtB.Repository.Entities.Friend")
                        .WithMany("ComunicationCapabilities")
                        .HasForeignKey("FriendId");
                });
#pragma warning restore 612, 618
        }
    }
}
