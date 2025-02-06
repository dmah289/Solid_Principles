using System;
using UnityEngine;

namespace Interface
{
    public interface IInteracted
    {
        event Action<GameObject> OnGetInteracted;
        event Action OnExitInteraction;

        void GetInteracted(GameObject gameObj);
        void ExitInteraction();
    }
}