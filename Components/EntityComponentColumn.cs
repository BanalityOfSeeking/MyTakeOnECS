using DotNext;
using System;

namespace BonesOfTheFallen.Services
{
    abstract class WorkflowThatReturns<T>
    {
        public abstract WorkflowThatReturns<U> AddStep<U>(Func<T, WorkflowThatReturns<U>> step);
    }
}