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
        private record TestRecord : SystemProcessor
        { 


            public Channel<AttributesModifier> AttributeModChannel = Channel.CreateUnbounded<AttributesModifier>();
            public Channel<Position> PositionChannel = Channel.CreateUnbounded<Position>();
            public Channel<Velocity> VelocityChannel = Channel.CreateUnbounded<Velocity>();
            public TestRecord() : base()
            {

            }
            public void VelocityUpdate()
            {
                Velocity vel = new();

                if (NativeKeyboard.IsKeyDown(KeyCode.Down))
                {
                    vel.Y = -100f;
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Up))
                {
                    vel.Y = 100f;
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Left))
                {
                    vel.X = -100f;
                }
                if (NativeKeyboard.IsKeyDown(KeyCode.Right))
                {
                    vel.X = 100f;
                }
                VelocityChannel.Writer.TryWrite(vel);

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
        [TestMethod()]
        public void AddSequenceTest()
        {
            TestRecord sequencer = new();
            AttributesSystem Manager = new(true, sequencer.AttributeModChannel);
            sequencer.AddSystem(Manager);
            Assert.IsTrue(sequencer.Next.Contains(Manager) == true);
        }

        [TestMethod()]
        public async Task ProcessTest()
        {
            TestRecord sequencer = new();
            AttributesSystem attributes = new(true, sequencer.AttributeModChannel);
            PositionSystem position = new(true, sequencer.PositionChannel);
            VelocitySystem velocity = new(true, sequencer.VelocityChannel, sequencer.PositionChannel);

            // Add Systems to Manager
            sequencer.AddSystem(attributes);
            // layout importance.. :: BAD ::
            sequencer.AddSystem(velocity);
            sequencer.AddSystem(position);
            // Add Systems to View
            var testView = sequencer.GetSystemsView();
            var positionTest = testView.PositionComponent;
            await sequencer.WriteAttributeChannel();
            sequencer.VelocityUpdate();
            sequencer.Process(0.0f);
            
            Assert.IsTrue(positionTest > testView.PositionComponent);
        }

        [TestMethod()]
        public void TrackNewEntityTest()
        {

        }
    }
}