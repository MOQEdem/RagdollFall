using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class ActivatorOfFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterBodyPart part))
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;

            SceneManager.LoadScene(0);
        }
    }
}
