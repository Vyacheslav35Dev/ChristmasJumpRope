using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class ShopSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<ClickShopEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                //_sceneData.Store.Buy(data);
                entity.Del<ClickShopEvent>();
            }
        }
    }
}