using System.Collections.Generic;
using System.Linq;

namespace PatternBuddy.StateMachines
{
    public class State
    {
        public List<StateTransition> Transitions { get; private set; } = new List<StateTransition>();

        public State(List<StateTransition> transitions)
        {
            if (transitions.Any()) Transitions = transitions.OrderByDescending(t => t.Priority).ToList();
        }

        public void AddTransition(StateTransition transition)
        {
            Transitions.Add(transition);
            Transitions = Transitions.OrderByDescending(t => t.Priority).ToList();
        }

        public virtual bool ShouldTransition(out State nextState)
        {
            nextState = null;
            if (Transitions.Any())
                nextState = Transitions.FirstOrDefault(t => t.TransitionReady())?.Target;
            return nextState != null;
        }
        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}