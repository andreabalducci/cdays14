using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bookings.Engine.Domain.Auth.Users;
using Bookings.Engine.Domain.Bookings.BookingRequest;
using Bookings.Engine.Domain.Bookings.Resource;
using Bookings.Engine.Domain.Bookings.Resource.Events;
using Bookings.Engine.Support;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using Machine.Specifications;
using NEventStore;
using NEventStore.Dispatcher;

namespace Bookings.Specs.Evenstore
{
    // ReSharper disable InconsistentNaming

    [Subject("Store")]
    public class StoreSpecs
    {
        static Eventstore _eventstore;
        static IRepository _repository;
        static ResourceAggregate _resource;
        static readonly IList<Commit> _dispatchedCommits = new List<Commit>();
        static readonly Guid _commitId = Guid.NewGuid();

        Establish context = () =>
        {
            _eventstore = new Eventstore(new DelegateMessageDispatcher(c => _dispatchedCommits.Add(c)));
            _eventstore.Start();
            _repository = _eventstore.GetRepository();

            _resource = new ResourceAggregate();
            _resource.Create(
                new ResourceId(),
                new ResourceName("Azure - North Europe"),
                new UserId()
            );
        };

        Because of = () =>
            _repository.Save(_resource, _commitId, h => h.Add("user", "me"));

        It commit_has_been_dispatched = () =>
            _dispatchedCommits.Single().CommitId.ShouldBeLike(_commitId);

        It commit_has_two_events = () =>
        {
            var commit = _dispatchedCommits.Single();
            commit.Events.Count.ShouldBeLike(2);

            commit.Events[0].Body.ShouldBeOfExactType<ResourceCreated>();
            commit.Events[1].Body.ShouldBeOfExactType<ResourceManagerAdded>();
        };

        It commit_has_custom_headers = () =>
            _dispatchedCommits.Single().Headers["user"].ShouldBeLike("me");
    }
}
