using System;
using manhnd_sdk.Scripts.SystemDesign.EventBus;
using UnityEngine;

namespace _Project.Scripts
{
    public class A : MonoBehaviour, IEventBusListener
    {
        private void OnEnable()
        {
            RegisterCallbacks();
        }

        public void RegisterCallbacks()
        {
            EventBus<MyEvent>.Register(OnCalled);
        }
        
        private void OnCalled(MyEvent e)
        {
            Debug.Log($"{e.Value}");
        }

        public void DeregisterCallbacks()
        {
            
        }
    }
}