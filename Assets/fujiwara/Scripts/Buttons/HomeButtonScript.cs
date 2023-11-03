using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeButtonScript : MonoBehaviour
{
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene("Home");
    }
}