using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheLastWitness.Core.Menu
{
    public class MainMenuManager : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene("DydouLevelScene");
        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}