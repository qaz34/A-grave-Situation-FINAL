using UnityEngine;
using System.Collections;

public class BodyMaker : MonoBehaviour
{
    public GameObject BodyPrefab;

    public void MakeBody()
    {
        GameObject go = Instantiate(BodyPrefab, transform.position, Random.rotation) as GameObject;
    }

}
