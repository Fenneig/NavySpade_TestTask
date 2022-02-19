using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NavySpade.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        public PlayerData Data => _data;

        public static GameSession Instance;

        private void Awake()
        {
            var existSession = GetExistSession();

            if (existSession != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            LoadHud();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        }

        private GameSession GetExistSession()
        {
            var sessions = FindObjectsOfType<GameSession>();

            return sessions.FirstOrDefault(session => session != this);
        }
    }
}