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
        public MtbDbContext()
        {
            CommunicationCapabilities = new List<CommunicationCapabilityRecord>();
            PlayInvitations = new List<PlayInvitationRecord>();
            Seed();
        }
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
            BuddyRecords = new List<BuddyRecord>{new BuddyRecord()
            {
                ExternalId =  Guid.NewGuid(),
                FirstName =  "Dimitar",
                LastName =  "Ginev",
                Position = 1,
                Email = "gindio@gmail.com",
                CellPhoneNmuber = "1234554",
                ComunicationCapabilities = new List<CommunicationCapabilityRecord> { new CommunicationCapabilityRecord(){Type = typeof(ReceiveEmailCapability).FullName}},
                UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                Id = 1
            },new BuddyRecord()
            {
                ExternalId =  Guid.NewGuid(),
                FirstName =  "Dimitar",
                LastName =  "Ginev",
                Position = 1,
                Email = "gindio@gmail.com",
                CellPhoneNmuber = "1234554",
                ComunicationCapabilities = new List<CommunicationCapabilityRecord> { new CommunicationCapabilityRecord(){Type = typeof(ReceiveEmailCapability).FullName}},
                UserId = new Guid("00000000-0000-0000-0000-000000000000"),
                Id = 1
            }};
        }

        public override int SaveChanges()
        {
            return 1;
        }
    }
}