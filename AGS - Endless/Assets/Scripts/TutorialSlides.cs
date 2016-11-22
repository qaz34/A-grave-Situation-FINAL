using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialSlides : MonoBehaviour
{
    [Tooltip("Images in order")]
    public List<Sprite> ImageSlides;
    int slide;
    public int nextScene;
    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            if (slide >= ImageSlides.Count)
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                GetComponent<Image>().sprite = ImageSlides[slide];
                slide++;
            }
        }
    }
}
