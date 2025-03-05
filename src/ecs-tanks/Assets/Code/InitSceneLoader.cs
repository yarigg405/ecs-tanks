using Assets.Code.Infrastructure.Loading;
using Code.Infrastructure;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;


namespace Game
{
    public sealed class InitSceneLoader : MonoBehaviour
    {
        [Inject] private readonly ICoroutineRunner _coroutineRunner;

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            if (_coroutineRunner == null)
                SceneManager.LoadScene(SceneNames.InitScene);
        }
    }
}

