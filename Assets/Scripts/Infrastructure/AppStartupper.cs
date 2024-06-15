using System;
using Factories;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure
{
    public class AppStartupper : MonoBehaviour
    {
        private ICanvasFactory _canvasFactory;

        [Inject]
        public void Constructor(ICanvasFactory canvasFactory)
        {
            _canvasFactory = canvasFactory;
        }

        private void Start()
        {
            SceneManager.LoadScene("MainScene");
            _canvasFactory.CreateMainClickerCanvas();
        }
    }
}
