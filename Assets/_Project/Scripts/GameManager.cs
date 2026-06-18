using System;
using System.Collections.Generic;
using Horcrux.Runtime.Abstractions.Pooling;
using Horcrux.Runtime.Implementations.Pooling;
using Sisus.Init;
using UnityEngine;

namespace _Project
{
    public class GameManager : MonoBehaviour<IPoolManager>
    {
        private IPoolManager _poolManager;
        [SerializeField] private List<PrefabBaseA> _prefabsAList = new();
        [SerializeField] private List<PrefabBaseB> _prefabsBList = new();

        protected override void OnAwake()
        {
            base.OnAwake();
            _poolManager.Initialize(destroyCancellationToken);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _prefabsAList.Add(_poolManager.Get<PrefabBaseA>());
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_prefabsAList.Count > 0)
                {
                    _poolManager.Return(_prefabsAList[0]);
                    _prefabsAList.RemoveAt(0);
                }
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                _prefabsBList.Add(_poolManager.Get<PrefabBaseB>());
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_prefabsBList.Count > 0)
                {
                    _poolManager.Return(_prefabsBList[0]);
                    _prefabsBList.RemoveAt(0);
                }
            }
        }

        protected override void Init(IPoolManager argument)
        {
            _poolManager = argument;
        }
    }
}