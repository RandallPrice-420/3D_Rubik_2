using UnityEngine;
using UnityEngine.SceneManagement;


public class StartingSceneManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");

        //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        //if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        //{
        //    SceneManager.LoadScene(nextSceneIndex);
        //}

    }   // NewGame()


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }   // QuitGame()


}   // class StartingSceneManager

