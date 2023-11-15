using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class ControlWorldSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private EcsWorld _ecsWorld;
        
        public void Run()
        {
            if (!_sceneData.isRunGame)
            {
                return;
            }
            
            if (_sceneData.PlayerController.isCollision & _sceneData.RopeController.isCollision)
            {
                _ecsWorld.NewEntity().Get<FinishWorldEvent>();
            }
        }
    }
}