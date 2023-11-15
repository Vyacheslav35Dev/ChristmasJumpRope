using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ForceRopeAnimSpeedSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<ForceRopeAnimComponent, ClickShopEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var data = ref _filter.Get1(i);
                _filter.Get2(i);
                data.speedAnim = data.speedAnim + data.coofSpeed;
                data.Animator.speed = Time.deltaTime * data.speedAnim;
            }
        }
    }
}