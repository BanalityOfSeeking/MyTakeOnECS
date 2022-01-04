// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BonesOfTheFallen.Services
{
    public record SystemProcessor<T> : IEnumerable<SystemBase<T>> where T : struct, Enum
    {
        public IEnumerable<SystemBase<T>> Next = new List<SystemBase<T>>();

        public SystemProcessor()
        {
        }

        public SystemProcessor<T> AddSystem(SystemBase<T> newSystem)
        {
            ((IList)Next).Add(newSystem);
            return this;
        }

        public IEnumerator<SystemBase<T>> GetEnumerator()
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