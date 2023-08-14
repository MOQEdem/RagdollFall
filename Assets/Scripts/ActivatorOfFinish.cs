using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class ActivatorOfFinish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }
}
