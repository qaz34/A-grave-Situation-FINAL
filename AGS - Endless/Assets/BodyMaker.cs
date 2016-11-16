using UnityEngine;
using System.Collections;

public class BodyMaker : MonoBehaviour
{
    public GameObject BodyPrefab;

    public void MakeBody()
    {
        Instantiate(BodyPrefab, transform.position, Random.rotation);
    }

}
