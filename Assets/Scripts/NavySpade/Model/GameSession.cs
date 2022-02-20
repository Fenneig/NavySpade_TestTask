using System.Linq;
using NavySpade.Model.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NavySpade.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private CrystalData _crystalData;
        [SerializeField] private DistanceData _distanceData;
        public PlayerData Data => _data;
        public SceneData SceneData => _sceneData;
        public CrystalData CrystalData => _crystalData;

        public DistanceData DistanceData => _distanceData;

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

            InitData();
            LoadHud();
        }

        private void InitData()
        {
            _sceneData.InitData();
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