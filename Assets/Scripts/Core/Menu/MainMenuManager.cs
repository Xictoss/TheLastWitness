using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheLastWitness.Core.Menu
{
    public class MainMenuManager : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene("SceneLevelDesign");
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}