using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MtB.BuddyList;
using MtB.Repository.Entities;

namespace MtB.Repository.Providers
{
    public class BuddiesProvider : IProvideBuddies
    {
        private readonly FriendsProvider _friendsProvider;

        public BuddiesProvider(FriendsProvider friendsProvider)
        {
            _friendsProvider = friendsProvider;
        }

        public IEnumerator<Buddy> GetEnumerator()
        {
            return _friendsProvider.Friends.Select(ToBuddy).GetEnumerator();
        }

        private Buddy ToBuddy(Friend friend)
        {
            return friend.ToBuddy();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => typeof(Buddy);
        public Expression Expression => _friendsProvider.Friends.Select(f=> f.ToBuddy()).AsQueryable().Expression;
        public IQueryProvider Provider => _friendsProvider.Friends.Select(f => f.ToBuddy()).AsQueryable().Provider;
        public void Save(Buddy buddy)
        {

        }
    }

    public class FriendsProvider: DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        public DbSet<CommunicationCapability> CommunicationCapabilities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration["Configuration:BuddiesProvider"]);
        }
    }
}
