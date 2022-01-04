using System;
using System.Collections.Generic;

namespace BonesOfTheFallen.Services
{
    public interface IComponentBase<T> where T : struct,Enum
    {
        public Dictionary<int, string> GetComponentEnum()
        {
            var result = new Dictionary<int, string>();
            var values = Enum.GetValues(typeof(T));

            foreach (int item in values)
                result.Add(item, Enum.GetName(typeof(T), item) ?? "Default");
            return result;
        }
    }
}
