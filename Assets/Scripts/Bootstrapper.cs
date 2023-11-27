using System;
using Systems;
using Components;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using Leopotam.Ecs.Ui.Systems;
using LeopotamGroup.Globals;
using TMPro;
#if UNITY_EDITOR
using Leopotam.Ecs.UnityIntegration;
#endif

using UnityEngine;
using YG;

sealed class Bootstrapper : MonoBehaviour 
{
    private EcsWorld _world;
    private EcsSystems _systems;
    private EcsSystems _phisicSystems;

    public SceneData SceneData;

    public YandexGame yg;
    
    private void OnEnable() => YandexGame.GetDataEvent += Run;

    private void OnDisable() => YandexGame.GetDataEvent -= Run;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            Run();
        }
    }
    
    private void Run()
    {
        var score = YandexGame.savesData.score;
        
        SceneData.OldScore = score;

        PlayerPrefs.SetInt("buySlot1", 1);
        PlayerPrefs.SetInt("buySlot2", 2);
        if (SceneData.OldScore > 0)
        {
            SceneData.Ui.CounterText.text = SceneData.OldScore.ToString();
        }
        else
        {
            SceneData.Ui.CounterText.text = "";
        }
            
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        _phisicSystems = new EcsSystems(_world);
        
        Service<EcsWorld>.Set(_world);
        /*Service<SceneData>.Get();*/
        
#if UNITY_EDITOR
        EcsWorldObserver.Create (_world);
        EcsSystemsObserver.Create (_systems);
#endif
        _systems
            .Add(new UiClickEventSystem()).OneFrame<EcsUiClickEvent>()
            .Add(new UiScreenSystem())
                
            .Add(new StartWorldSystem()).OneFrame<StartWorldEvent>()
            .Add(new PlayerInputSystem())
            
            .Add(new CounterSystem())
            .Add(new ControlWorldSystem())
            .Add(new FinishWorldSystem()).OneFrame<FinishWorldEvent>()
                
            .Add(new ShopSystem()).OneFrame<ClickShopEvent>()
                
            .InjectUi (SceneData.Ui.UiEmitter)
            .Inject (SceneData)
            .Init ();
        _phisicSystems
            .Add(new JumpingSystem())
            .Add(new ForceRopeAnimSpeedSystem())
            .Inject (SceneData)
            .Init();
    }

    private void Update () 
    {
        _systems?.Run ();
    }

    private void FixedUpdate()
    {
        _phisicSystems?.Run();
    }

    private void OnDestroy () 
    {
        if (_systems != null) 
        {
            _systems.Destroy ();
            _systems = null;
            _world?.Destroy ();
            _world = null;
        }
        if (_systems != null) 
        {
            _phisicSystems.Destroy ();
            _phisicSystems = null;
            _world?.Destroy ();
            _world = null;
        }
    }
}