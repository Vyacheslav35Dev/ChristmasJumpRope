using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class FinishWorldSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<FinishWorldEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                _sceneData.isRunGame = false;
                _sceneData.World.SetActive(false);
                _sceneData.PlayerController.Reset();
                _sceneData.RopeController.Reset();
                _sceneData.entityForceRopeAnimSpeed.Del<ForceRopeAnimComponent>();
                
                if (_sceneData.OldScore < _sceneData.Score)
                {
                    PlayerPrefs.SetInt("score", _sceneData.Score);
                }
                
                entity.Get<ShowScreenEvent>().ScreenType = ScreenType.WonScreen;
                entity.Del<FinishWorldEvent>();
            }
        }
    }
}