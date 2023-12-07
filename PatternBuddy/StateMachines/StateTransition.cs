using System;

namespace PatternBuddy.StateMachines
{
    public class StateTransition
    {
        //The higher the byte, the higher the priority.
        public byte Priority { get; }
        public State Target { get; }

        private readonly Func<bool> _check;

        public StateTransition(State target, Func<bool> condition, byte priority = 0)
        {
            Target = target;
            _check = condition;
            Priority = priority;
        }

        public bool TransitionReady()
        {
            return _check();
        }
    }
}