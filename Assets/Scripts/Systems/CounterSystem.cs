using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class CounterSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<CounterPointEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                _sceneData.NewScore++;
                _sceneData.Ui.SetTextCounter(_sceneData.NewScore);
                entity.Del<CounterPointEvent>();
            }
        }
    }
}