using System.Collections.Generic;

namespace PatternBuddy.StateMachines
{
    public class StateMachine
    {
        private State _currentState;
        private State _defaultState;
        private List<State> _states;

        public IReadOnlyList<State> States => _states.AsReadOnly();

        public State CurrentState
        {
            get => _currentState;
            private set
            {
                _currentState?.Exit();
                _currentState = value;
                _currentState.Enter();
            }
        }

        public StateMachine(State defaultState)
        {
            _defaultState = defaultState;
            _states = new List<State> { defaultState };
        }

        public StateMachine(State defaultState, List<State> states)
        {
            _defaultState = defaultState;
            _states = states;
        }

        public void Start()
        {
            CurrentState = _defaultState;
        }

        public void Update()
        {
            CurrentState.Update();
            CheckTransitions();
        }

        private void CheckTransitions()
        {
            if (CurrentState.ShouldTransition(out var targetState))
            {
                CurrentState = targetState;
            }
        }
    }
}
