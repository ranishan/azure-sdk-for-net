﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventPosition" />
    ///   struct.
    /// </summary>
    ///
    [TestFixture]
    public class EventPositionTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void AnInstanceIsEqualToItself()
        {
            var first = EventPosition.FromOffset(12);
            var second = first;

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void EarliestAndLatestAreNotEqual()
        {
            var first = EventPosition.Earliest;
            var second = EventPosition.Latest;

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void TheSameOffsetAreEqual()
        {
            var first = EventPosition.FromOffset(12);
            var second = EventPosition.FromOffset(12);

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentOffsetsAreNotEqual()
        {
            var first = EventPosition.FromOffset(12);
            var second = EventPosition.FromOffset(34);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void TheSameEnqueueTimesAreEqual()
        {
            var first = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-27T00:00:00Z"));
            var second = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-27T00:00:00Z"));

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentEnqueueTimesAreNotEqual()
        {
            var first = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-27T00:00:00Z"));
            var second = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2012-03-04T08:39:00Z"));

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void TheSameSequenceNumbersAreEqual()
        {
            var first = EventPosition.FromSequenceNumber(12);
            var second = EventPosition.FromSequenceNumber(12);

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentSequenceNumbersAreNotEqual()
        {
            var first = EventPosition.FromSequenceNumber(234234);
            var second = EventPosition.FromSequenceNumber(234234234);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void TheSameInclusiveFlagsAreEqual(bool isInclusive)
        {
            var first = EventPosition.FromSequenceNumber(234234, isInclusive);
            var second = EventPosition.FromSequenceNumber(234234, isInclusive);

            Assert.That(first.Equals((object)second), Is.True, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.True, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.True, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.False, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentInclusiveFlagsAreNotEqual()
        {
            var first = EventPosition.FromSequenceNumber(234234, true);
            var second = EventPosition.FromSequenceNumber(234234, false);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition "/>
        ///   equality.
        /// </summary>
        ///
        [Test]
        public void DifferentMembersAreNotEqual()
        {
            var first = EventPosition.FromSequenceNumber(234234);
            var second = EventPosition.FromOffset(12);

            Assert.That(first.Equals((object)second), Is.False, "The default Equals comparison is incorrect.");
            Assert.That(first.Equals(second), Is.False, "The IEquatable comparison is incorrect.");
            Assert.That((first == second), Is.False, "The == operator comparison is incorrect.");
            Assert.That((first != second), Is.True, "The != operator comparison is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventPosition.GetHashCode "/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetHashCodeReturnsDifferentValuesForDifferentMembers()
        {
            var first = EventPosition.FromOffset(12);
            var second = EventPosition.FromSequenceNumber(123);

            Assert.That(first.GetHashCode(), Is.Not.EqualTo(second.GetHashCode()));
        }
    }
}
