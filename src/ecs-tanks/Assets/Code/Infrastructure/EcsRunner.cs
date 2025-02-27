using Assets.Code.Gameplay;
using UnityEngine;
using VContainer;


namespace Assets.Code.Infrastructure
{
    public sealed class EcsRunner : MonoBehaviour
    {
        [Inject] private readonly GameFeature _gameFeature;

        private void Start()
        {
            _gameFeature.Initialize();
        }

        private void Update()
        {
            _gameFeature.Execute();
            _gameFeature.Cleanup();
        }


        private void OnDestroy()
        {
            _gameFeature.TearDown();
        }
    }
}
