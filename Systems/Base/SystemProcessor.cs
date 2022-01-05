// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BonesOfTheFallen.Services
{
    public class SystemProcessor : IEnumerable<SystemBase>
    {
        public IEnumerable<SystemBase> Next = new List<SystemBase>();
        public SystemProcessor()
        {

        }

        public SystemProcessor AddSystem(SystemBase newSystem)
        {
            ((IList)Next).Add(newSystem);
            return this;
        }

        public IEnumerator<SystemBase> GetEnumerator()
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
        public SystemsView GetSystemsView()
        {
            var sv = new SystemsView();

            if (Next.Any())
            {
                
                foreach (var system in Next)
                {
                    sv.SystemBaseViewAdd(system);
                }
                return sv;
            }

            return sv;
        }
    }
}