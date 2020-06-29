using System;
using System.IO;
using NUnit.Framework;
using Task4;

namespace UnitTests
{
    public class Task4Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Creation_TypeInstruction_ReturnsSameType()
        {
            MeetingWithType meetingWithType = new MeetingWithType(MeetingWithType.MeetingType.Instruction);
            Assert.AreEqual(meetingWithType.Type, MeetingWithType.MeetingType.Instruction);
        }

        [Test]
        public void Creation_WithoutEnd_ReturnsMaxSpan()
        {
            MeetingWithNoEnd meetingWithNoEnd = new MeetingWithNoEnd(DateTime.Now);
            Assert.AreEqual(TimeSpan.MaxValue, meetingWithNoEnd.Duration);
        }
    }
}