using System;
using manhnd_sdk.Scripts.SystemDesign.EventBus;
using UnityEngine;

namespace _Project.Scripts
{
    public struct MyEvent : IEventDTO
    {
        public int Value;
    }
    
    public class B : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EventBus<MyEvent>.Raise(new MyEvent(){ Value = 10 });
            }
        }
    }
}