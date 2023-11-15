using Components;
using Leopotam.Ecs;

namespace Systems
{
    public class UiScreenSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<ShowScreenEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                _sceneData.Ui.ShowScreen(data.ScreenType);
                entity.Del<ShowScreenEvent>();
            }
        }
    }
}