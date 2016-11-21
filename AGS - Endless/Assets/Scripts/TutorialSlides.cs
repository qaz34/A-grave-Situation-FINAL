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
    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            if (slide >= ImageSlides.Count)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                GetComponent<Image>().sprite = ImageSlides[slide];
                slide++;
            }
        }
    }
}
