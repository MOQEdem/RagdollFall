using UnityEngine;

public class StartButton : LevelControllerButton
{
    [SerializeField] private GameObject _moveToStart;

    public void DisableMoveToStart()
    {
        _moveToStart.SetActive(false);
    }
}
