using System;
using System.Collections.Generic;
using Leopotam.Ecs.Ui.Systems;
using TMPro;
using UnityComponents;
using UnityEngine;

namespace UnityComponents
{
    public class UI : MonoBehaviour
    {
        public EcsUiEmitter UiEmitter;
        
        public Screen StartScreen;
        public Screen SelectCharScreen;
        public Screen GameScreen;
        public Screen WonScreen;

        public TextMeshProUGUI CounterText;

        public Screen ActiveScreen;
        
        private Dictionary<ScreenType, Screen> _dictScreens = new Dictionary<ScreenType, Screen>();

        private void Start()
        {
            if (!_dictScreens.ContainsKey(StartScreen.Type))  _dictScreens.Add(StartScreen.Type, StartScreen);
            if (!_dictScreens.ContainsKey(GameScreen.Type))  _dictScreens.Add(GameScreen.Type, GameScreen);
            if (!_dictScreens.ContainsKey(WonScreen.Type))  _dictScreens.Add(WonScreen.Type, WonScreen);
            if (!_dictScreens.ContainsKey(SelectCharScreen.Type))  _dictScreens.Add(SelectCharScreen.Type, SelectCharScreen);
        }

        public void DeactivateAllScreens()
        {
            foreach (var screen in _dictScreens)
            {
                screen.Value.Show(false);
            }
        }

        public void ShowScreen(ScreenType screenType)
        {
            DeactivateAllScreens();
            if (_dictScreens.ContainsKey(screenType))
            {
                ActiveScreen = _dictScreens[screenType];
                ActiveScreen.UpdateState();
                ActiveScreen.Show(true);
            }
            else
            {
                Debug.Log("UI::ShowScreen ScreenType not found :" + screenType);
            }
        }

        public void SetTextCounter(int count)
        {
            CounterText.text = count.ToString();
        }
    }
}

