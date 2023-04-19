using System;
using Oculus.Interaction;
using UnityEngine;

namespace Core
{
    public class SpawnButton : MonoBehaviour
    {
        public PokeInteractable interactable;
        public GameObject prefab;
        public Transform spawnTransform;
        
        void Awake()
        {
            interactable.WhenStateChanged += InteractableOnWhenStateChanged;
        }

        void InteractableOnWhenStateChanged(InteractableStateChangeArgs obj)
        {
            if (obj.NewState == InteractableState.Select)
            {
                Instantiate(prefab, spawnTransform.position, spawnTransform.rotation);
            }
        }
    }
}
