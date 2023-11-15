using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class StartWorldSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<StartWorldEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                Debug.Log("StartWorldSystem::Run");
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                _sceneData.isRunGame = true;
                _sceneData.PlayerSprite.sprite = data.PlayerSprite;
                _sceneData.World.SetActive(true);
                _sceneData.Score = 0;
                _sceneData.Ui.SetTextCounter(0);
                entity.Get<ForceRopeAnimComponent>().Animator = _sceneData.RopeController.Anim;
                entity.Get<ForceRopeAnimComponent>().coofSpeed = _sceneData.coofSpeed;
                entity.Get<ForceRopeAnimComponent>().speedAnim = _sceneData.speedAnim;
                entity.Del<StartWorldEvent>();
                _sceneData.entityForceRopeAnimSpeed = entity;
            }
        }
    }
}