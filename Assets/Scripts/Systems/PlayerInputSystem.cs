using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private readonly EcsWorld _ecsWorld;
        
        public void Run()
        {
            if (!_sceneData.isRunGame)
            {
                return;
            }
            if (Input.GetMouseButtonUp(0) & _sceneData.PlayerController.isCollision)
            {
                var entity = _ecsWorld.NewEntity();
                entity.Get<JumpComponent>().dumping = _sceneData.dumping;
                entity.Get<JumpComponent>().p_Impulse = _sceneData.p_Impulse;
                entity.Get<JumpComponent>().strengImpuls = _sceneData.strengImpuls;
            }
        }
    }
}