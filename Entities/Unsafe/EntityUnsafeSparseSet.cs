using Microsoft.Toolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BonesOfTheFallen.Services
{
    /// <summary>
    /// Represents an unordered sparse set of natural numbers, and provides constant-time operations on it.
    /// </summary>
    public sealed class EntityUnsafeSparseSet
    {
        private readonly int _max;      // maximal value the set can contain
                                        // _max = 100; implies a range of [0..99]
        private int _n;                 // current size of the set
        private readonly int[] _d;      // dense array
        private readonly int[] _s;      // sparse array
        private readonly Memory2D<IComponentBase> _l;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityUnsafeSparseSet"/> class.
        /// </summary>
        /// <param name="maxValue">The maximal value the set can contain.</param>
        public EntityUnsafeSparseSet(int maxValue)
        {
            _max = maxValue + 1;
            _n = 0;
            _d = new int[_max];
            _s = new int[_max];
            _l = new Memory2D<IComponentBase>(new IComponentBase[_max, 64]);
        }

        /// <summary>
        /// Adds the given value.
        /// If the value already exists in the set it will be ignored.
        /// </summary>
        /// <param name="entity">The value.</param>
        // Chance to Allocate Slice or Memory2D as Memory<T>.
        public void AddEntity(EntityUnsafe entity)
        {
            if ((entity) >= 0 && entity < _max && !Contains(entity))
            {
                _d[_n] = entity;     // insert new value in the dense array...
                _s[entity] = _n;     // ...and link it to the sparse array
                _n++;
            }
        }
        public void AddComponent<Component>(ref  EntityUnsafe entity, Component component) where Component : struct, IComponentBase
        {
            if (Contains(entity))
            {
                _l[new Range((int)entity, (int)entity + 1), new Range(0, 64)].Span[0, entity.ComponentCount] = component;
                Interlocked.Increment(ref entity.ComponentCount);    
            } 
        }
        /// <summary>
        /// Removes the given value in case it exists.
        /// </summary>
        /// <param name="entity">The value.</param>
        public void RemoveEntity(EntityUnsafe entity)
        {
            if (Contains(entity))
            {
                // effectively delete the span for this enity
                _l[new Range(entity.Id, entity.Id + 1), new Range(0, entity.ComponentCount)].Span.Fill(default!);
                _d[_s[entity]] = _d[_n - 1];     // put the value at the end of the dense array
                                                // into the slot of the removed value
                _s[_d[_n - 1]] = _s[entity];     // put the link to the removed value in the slot
                                                // of the replaced value
                _n--;
            }
        }
        public void RemoveComponent<Component>(EntityUnsafe entity)
        {
            // iterate the RefEnumerable from the Memory2d.Span
            foreach (ref var x in _l[new Range(entity.Id, entity.Id + 1), new Range(0, entity.ComponentCount)]
                .Span.GetRow(0))
            {
                // check type
                if(x.GetType() == typeof(Component))
                {
                    
                    x = default!;
                }
            }
        }
        /// <summary>
        /// Determines whether the set contains the given value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the set contains the given value; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(int value)
        {
            if (value >= _max || value < 0)
                return false;
            else
                return _s[value] < _n && _d[_s[value]] == value;    // value must meet two conditions:
                                                                    // 1. link value from the sparse array
                                                                    // must point to the current used range
                                                                    // in the dense array
                                                                    // 2. there must be a valid two-way link
        }

        /// <summary>
        /// Removes all elements from the set.
        /// </summary>
        public void Clear()
        {
            _n = 0;     // simply set n to 0 to clear the set; no re-initialization is required
        }

        /// <summary>
        /// Gets the number of elements in the set.
        /// </summary>
        public int Count
        {
            get { return _n; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through all elements in the set.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<int> GetEnumerator()
        {
            var i = 0;
            while (i < _n)
            {
                yield return _d[i];
                i++;
            }
        }
    }
}
