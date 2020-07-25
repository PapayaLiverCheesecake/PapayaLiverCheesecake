using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FSM : MonoBehaviour
    {
        AbstractState currentState;
        public int previousState { get; protected set;}
        
        List<AbstractState> playerStates;
        Dictionary<int, AbstractState> fsmStates;

        void Awake()
        {
        
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            //Load all states.
            AbstractState[] tempArray;
            tempArray = this.GetComponents<AbstractState>();
            playerStates = new List<AbstractState>();
            fsmStates = new Dictionary<int, AbstractState>();

            for(int i = 0; i< tempArray.Length; ++i)
            {
                /*
                if (tempArray == null)
                    Debug.Log("Temp array null");
                if (playerStates == null)
                    Debug.Log("Player states null");
                */
                playerStates.Add(tempArray[i]);
            }
            
            foreach (AbstractState state in playerStates)
            {
                fsmStates.Add(state.StateType, state);
            }

        }

        private void Start()
        {
            EnterState(fsmStates[0]);
        }
        // Update is called once per frame
        void Update()
        {
            currentState.UpdateState();
        }

        private void EnterState(AbstractState state)
        {

            if (currentState != null)
            {
                previousState = currentState.StateType;
                currentState.ExitState();
            }
            
            currentState = state;

            currentState.EnterState();

            return;
        }
        //At first, it is not obvious of why this is useful (to me, at least), which is why it wasn't there before.
        //This allows you to reference a state from outside of the class easily without needing exact references to the state
        //you want.
        public void EnterState(int state)
        {
            if (fsmStates.ContainsKey(state))
            {
                this.EnterState(fsmStates[state]);
            }
            else
                Debug.Log("State not found when entering from: " + currentState.ToString());
        }
    }

}
