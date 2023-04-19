using System;
using Oculus.Interaction;
using UnityEngine;

namespace Core
{
    public class GestureController : MonoBehaviour
    {
        public ActiveStateSelector gestureStop;
        public ActiveStateSelector gestureScissors;

        public GameObject prefabCube;
        public GameObject prefabSphere;

        public Transform spawnTransform;
        
        void Awake()
        {
            gestureStop.WhenSelected += () => SpawnObject(prefabCube);
            gestureScissors.WhenSelected += () => SpawnObject(prefabSphere);
        }

        void SpawnObject(GameObject prefab)
        {
            Instantiate(prefab, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
