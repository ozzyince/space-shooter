using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnNewGameBtnClick()
    {
        SceneManager.LoadScene(1);
    }
}
