﻿using System;
using CQRSlite.Domain;
using CQRSlite.Infrastructure;
using CQRSlite.Tests.TestSubstitutes;
using NUnit.Framework;

namespace CQRSlite.Tests.DomainTests
{
	[TestFixture]
    public class When_getting_aggregate_without_contructor
    {
	    private TestAggregateNoParameterLessConstructor _aggregate;
	    private ISession _session;

	    [SetUp]
        public void Setup()
        {
            var eventStore = new TestEventStore();
            var eventPublisher = new TestEventPublisher();
	        var snapshotStrategy = new DefaultSnapshotStrategy();
            _session = new Session(eventStore, null, eventPublisher, snapshotStrategy);
            _aggregate = _session.Get<TestAggregateNoParameterLessConstructor>(Guid.NewGuid());
        }

        [Test]
        public void Should_create_aggregate()
        {
            Assert.That(_aggregate, Is.Not.Null);
        }

        [Test]
        public void Should_playback_events()
        {
            Assert.That(_aggregate.Version,Is.EqualTo(3));
        }


    }
}