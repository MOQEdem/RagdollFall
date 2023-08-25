using System.Collections;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    private LevelLoader _levelLoader;

    private void Awake()
    {
        _levelLoader = GetComponent<LevelLoader>();
    }

    private IEnumerator Start()
    {
        _levelLoader.LoadStartLevel();
        yield return null;
    }
}
