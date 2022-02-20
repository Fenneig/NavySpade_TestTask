using UnityEngine;
using UnityEngine.SceneManagement;

namespace NavySpade.Components
{
    public class LoadLevelComponent : MonoBehaviour
    {
        public void LoadLevel(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}