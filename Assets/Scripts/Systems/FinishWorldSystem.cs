using Components;
using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;
using YG;

namespace Systems
{
    public class FinishWorldSystem : IEcsRunSystem
    {
        private readonly SceneData _sceneData;
        private EcsFilter<FinishWorldEvent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                var data = _filter.Get1(i);
                _sceneData.isRunGame = false;
                _sceneData.World.SetActive(false);
                _sceneData.PlayerController.Reset();
                _sceneData.RopeController.Reset();
                _sceneData.entityForceRopeAnimSpeed.Del<ForceRopeAnimComponent>();
                
                if (_sceneData.NewScore > _sceneData.Score)
                {
                    if (YandexGame.auth)
                    {
                        Debug.Log("Save progress");
                        _sceneData.Score = _sceneData.NewScore;
                        YandexGame.savesData.score = _sceneData.NewScore;
                        YandexGame.SaveProgress();
                        _sceneData.LeaderboardYg.NewScore(_sceneData.NewScore);
                        _sceneData.LeaderboardYg.UpdateLB();
                    }
                    else
                    {
                        _sceneData.Score = _sceneData.NewScore;
                        PlayerPrefs.SetInt("Score", _sceneData.Score);
                    }
                }
                _sceneData.Ui.SetTextCounter(_sceneData.Score);

                entity.Get<ShowScreenEvent>().ScreenType = ScreenType.WonScreen;
                entity.Del<FinishWorldEvent>();
            }
        }
    }
}