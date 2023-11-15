using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class JumpingSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<JumpComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                ref var data = ref _filter.Get1(i);
                _sceneData.PlayerController.rgb.AddForce(new Vector2(0, 
                    data.p_Impulse * data.strengImpuls * data.dumping), ForceMode2D.Impulse);
                entity.Get<CounterPointEvent>();
                entity.Del<JumpComponent>();
            }
        }
    }
}