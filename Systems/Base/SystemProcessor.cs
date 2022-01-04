// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BonesOfTheFallen.Services
{
    public record SystemProcessor<T, U> : IEnumerable<SystemBase<T, U>> where T : struct, Enum
    {
        public IEnumerable<SystemBase<T, U>> Next = new List<SystemBase<T,U>>();

        public SystemProcessor()
        {
        }

        public SystemProcessor<T, U> AddSystem(SystemBase<T, U> newSystem)
        {
            ((IList)Next).Add(newSystem);
            return this;
        }

        public IEnumerator<SystemBase<T, U>> GetEnumerator()
        {
            return Next.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Process(float time)
        {
            if (Next.Any())
            {
                foreach (var system in Next)
                {
                    system.Process(time);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Next).GetEnumerator();
        }
    }
}