using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BonesOfTheFallen.Services.Tests
{

    [TestClass()]
    public class SystemsManagerTests
    {
        private record TestRecord 
        {
            internal SystemProcessor<AttributeEnum, int> AttributeProcessor = new();
            internal SystemProcessor<PositionEnum, double> PositionProcessor = new();
            internal SystemProcessor<VelocityEnum, double> VelocityProcessor = new();


            public Channel<AttributesModifier> AttributeModChannel = Channel.CreateUnbounded<AttributesModifier>();
            public Channel<Position> PositionChannel = Channel.CreateUnbounded<Position>();
            public Channel<Velocity> VelocityChannel = Channel.CreateUnbounded<Velocity>();
            public TestRecord() : base()
            {

            }

            public async Task WriteAttributeChannel()
            {
                Random random = Random.Shared;
                var sub = from su in (from item in Enumerable.Range(0, 10000)
                                      let enumType = (AttributeEnum)random.Next((int)AttributeEnum.None + 1, (int)AttributeEnum.Wisdom + 1)
                                      let attrMod = 1
                                      select new { enumType, attrMod })
                                       .GroupBy(x => x.enumType)
                          let sum = su.Sum(x => x.attrMod)
                          select new AttributesModifier(su.Key, sum);
                if (sub.Any())
                {
                    foreach (var item in sub)
                    {
                        await AttributeModChannel.Writer.WriteAsync(item);
                    }
                }


            }
        }
        public record TestView : SystemsView
        {
            public TestView()
            {
            }

            public TestView(SystemsView original) : base(original)
            {
            }
        }
        [TestMethod()]
        public void AddSequenceTest()
        {
            TestRecord sequencer = new();
            AttributesSystem Manager = new(true, sequencer.AttributeModChannel);
            sequencer.AttributeProcessor.AddSystem(Manager);
            Assert.IsTrue(sequencer.AttributeProcessor.Next.Contains(Manager) == true);
        }

        [TestMethod()]
        public async Task ProcessTest()
        {
            TestRecord sequencer = new();
            TestView testView = new();
            AttributesSystem attributes = new(true, sequencer.AttributeModChannel);
            PositionSystem position = new(true, sequencer.PositionChannel);
            VelocitySystem velocity = new(true, sequencer.VelocityChannel);
            sequencer.AttributeProcessor.AddSystem(attributes);
            sequencer.PositionProcessor.AddSystem(position);
            sequencer.VelocityProcessor.AddSystem(velocity);

            testView.SystemBaseViewAdd(attributes);
            testView.SystemBaseViewAdd(position);
            testView.SystemBaseViewAdd(velocity);
            
            await sequencer.WriteAttributeChannel();
            var value = attributes.GetPropertyRef(AttributeEnum.Expierence).Value;
            sequencer.AttributeProcessor.Process(0.0f);
            var newvalue = attributes.GetPropertyRef(AttributeEnum.Expierence).Value;
            Assert.IsTrue(newvalue > value);
        }

        [TestMethod()]
        public void TrackNewEntityTest()
        {

        }
    }
}