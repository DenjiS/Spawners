using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;

    public void Load()
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
