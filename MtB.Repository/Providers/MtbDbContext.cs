using System;
using System.Collections.Generic;
using Core.Communication.Components.ForSendingEmail;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.StorageRecords;

namespace Repository.Providers
{
    public class MtbDbContext : DbContext
    {
        public List<BuddyRecord> BuddyRecords { get; set; }
        public List<CommunicationCapabilityRecord> CommunicationCapabilities { get; set; }
        public List<PlayInvitationRecord> PlayInvitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //optionsBuilder.UseSqlServer(configuration["Configuration:BuddiesProvider"]);
            //optionsBuilder.UseSqlite(configuration["Configuration:BuddiesProviderSqlite"]);
            Seed();
        }

        private void Seed()
        {
            BuddyRecords.Add(new BuddyRecord()
            {
                ExternalId =  Guid.NewGuid(),
                FirstName =  "Dimitar",
                LastName =  "Ginev",
                Position = 1,
                Email = "gindio@gmail.com",
                CellPhoneNmuber = "1234554",
                ComunicationCapabilities = new List<CommunicationCapabilityRecord> { new CommunicationCapabilityRecord(){Type = typeof(ReceiveEmailCapability).FullName}},
                UserId = new Guid("00000000-0000-0000-00000000"),
                Id = 1
            });
            BuddyRecords.Add(new BuddyRecord()
            {
                ExternalId =  Guid.NewGuid(),
                FirstName =  "John",
                LastName =  "Doe",
                Position = 1,
                Email = "doe@gmail.com",
                CellPhoneNmuber = "5555555",
                ComunicationCapabilities = new List<CommunicationCapabilityRecord> { new CommunicationCapabilityRecord(){Type = typeof(ReceiveEmailCapability).FullName}},
                UserId = new Guid("00000000-0000-0000-00000000"),
                Id = 1
            });
        }
    }
}