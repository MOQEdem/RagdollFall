using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Canvas _tutor;

    private void OnEnable()
    {
        //if(_playerPhase = GetComponent<PhaseChanger>())
        //    _playerPhase.FinalChange += Hide;

        //if (DataPersistenceManager.Instance.CurrentLevel == 1)
        //    _tutor.gameObject.SetActive(true);

    }

    private void Hide() => _tutor.gameObject.SetActive(false);
}