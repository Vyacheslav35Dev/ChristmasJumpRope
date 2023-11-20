using Client.Components;
using Components;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityComponents;
using UnityEngine;

namespace Systems
{
    public class UiClickEventSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private EcsFilter<EcsUiClickEvent> _filter;
        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                
                switch (data.WidgetName)
                {
                    default:
                        Debug.Log("UiClickEventSystem::Run unknowed id widgetName: " + data.WidgetName);
                        break;
                    case "BtnPlay":
                        var entityData1 = _world.NewEntity();
                        entityData1.Get<ShowScreenEvent>().ScreenType = ScreenType.SelectScreen;
                        break;
                    case "BtnSelectChar1":
                        var entityData2 = _world.NewEntity();
                        entityData2.Get<ShowScreenEvent>().ScreenType = ScreenType.GameScreen;
                        entityData2.Get<StartWorldEvent>().PlayerSprite = _sceneData.TreeSprite;
                        break;
                    case "BtnSelectChar2":
                        var entityData5 = _world.NewEntity();
                        entityData5.Get<ShowScreenEvent>().ScreenType = ScreenType.GameScreen;
                        entityData5.Get<StartWorldEvent>().PlayerSprite = _sceneData.PinguinSprite;
                        /*entityData5.Get<ClickShopEvent>().PlayerSprite = _sceneData.PinguinSprite;
                        entityData5.Get<ClickShopEvent>().PurchaseId = _sceneData.PurchaseIdPenguin;*/
                        break;
                    case "BtnSelectChar3":
                        var entityData6 = _world.NewEntity();
                        entityData6.Get<ShowScreenEvent>().ScreenType = ScreenType.GameScreen;
                        entityData6.Get<StartWorldEvent>().PlayerSprite = _sceneData.SnomanSprite;
                        /*entityData6.Get<ClickShopEvent>().PlayerSprite = _sceneData.SnomanSprite;
                        entityData6.Get<ClickShopEvent>().PurchaseId = _sceneData.PurchaseIdSnoMan;*/
                        break;
                    case "BtnWon":
                        var entityData3 = _world.NewEntity();
                        entityData3.Get<ShowScreenEvent>().ScreenType = ScreenType.SelectScreen;
                        break;
                    case "AreaClick":
                        var entityData4 = _world.NewEntity();
                        entityData4.Get<AreaClickWorldEvent>();
                        break;
                    
                    case "BtnTestWon":
                        var entityData = _world.NewEntity();
                        entityData.Get<FinishWorldEvent>();
                        break;
                }
            }
        }
    }
}