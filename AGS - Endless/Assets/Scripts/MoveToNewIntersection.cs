﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.ImageEffects;
[System.Serializable]
public struct Sounds
{
    public AudioClip moveSound;
    public AudioClip foundSound;
    public List<AudioClip> foundPlayerSounds;
    public List<AudioClip> alertSounds;
}
public class MoveToNewIntersection : MonoBehaviour
{
    [Tooltip("Player in scene")]
    public Transform Player;
    [Tooltip("The empty of the Waypoint Markers")]
    public GameObject markerContainer;
    [Tooltip("The layer of Walls")]
    public LayerMask Walls;
    [Tooltip("The move speed of the agent when he has found something")]
    public float findMoveSpeed = 3;
    [Tooltip("How long the guard will stay at the coin in seconds")]
    public float coinStayTime = 5;
    [Tooltip("Ignore")]
    public Pathing currentPathing;
    [Tooltip("How fast the time scale reduces")]
    public float fadeSpeed = .01f;
    [Tooltip("How fast the blur increses")]
    public float blurSpeed = .01f;
    public Sounds sounds;
    [Tooltip("Delay before he serches around for graves")]
    public float delaySpeed = 1;
    private NavMeshAgent m_agent;
    private List<Transform> m_markers;
    [HideInInspector]
    public fieldOfView m_fieldOfView;
    private float normalMoveSpeed;
    private int currentPath;
    private List<Transform> m_searchMarkers = new List<Transform>();
    private int searchPath;
    [HideInInspector]
    public bool foundGrave = false;
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        var markers = markerContainer.GetComponentsInChildren<Transform>();
        m_fieldOfView = GetComponent<fieldOfView>();
        m_markers = markers.ToList();
        m_markers.RemoveAt(0);
        currentPathing = new follow(m_agent);
        normalMoveSpeed = m_agent.speed;
    }
    float calculatePathLength(Vector3 startPos, Vector3 endPos)
    {
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(startPos, endPos, NavMesh.AllAreas, path);
        if (path.corners.Length < 2)
        {
            return 0;
        }
        Vector3 previousCorner = path.corners[0];
        float lengthSoFar = .0f;
        for (int i = 1; i < path.corners.Length; i++)
        {
            Vector3 currentCorner = path.corners[i];
            lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
            previousCorner = currentCorner;
        }
        return lengthSoFar;
    }
    public void followPath()
    {
        if (m_searchMarkers.Count > 0)
        {
            m_agent.destination = m_searchMarkers[searchPath % m_searchMarkers.Count].position;
            searchPath++;
            if (searchPath >= m_searchMarkers.Count)
            {
                foundGrave = false;
                m_fieldOfView.exclamation.SetActive(false);
                m_searchMarkers = new List<Transform>();
                m_agent.speed = normalMoveSpeed;
            }

        }
        else
        {
            m_agent.destination = m_markers[currentPath % m_markers.Count].position;
            currentPath++;
        }
    }
    public void FoundEmptyGrave(GameObject grave)
    {
        GetComponent<AudioSource>().clip = sounds.alertSounds[Random.Range(0, sounds.alertSounds.Count)];
        GetComponent<AudioSource>().Play();
        foundGrave = true;
        currentPathing = new coin(m_agent, grave.transform);
        StartCoroutine(FindGraveWait(grave));
    }
    IEnumerator FindGraveWait(GameObject grave)
    {
        while (m_agent.remainingDistance > 1)
        {
            m_fieldOfView.exclamation.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
            m_agent.destination = grave.transform.position;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(delaySpeed);
        foundGrave = true;
        currentPathing = new follow(m_agent);
        m_agent.speed = findMoveSpeed;
        foreach (var point in m_markers)
            if (Vector3.Distance(transform.position, point.position) <= GetComponent<fieldOfView>().MarkerRadius)
                m_searchMarkers.Add(point.transform);
    }
    IEnumerator StayAtCoin(float sec)
    {
        coin current = currentPathing as coin;
        while (m_agent.remainingDistance > 1)
        {
            m_fieldOfView.exclamation.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
            m_agent.destination = current.m_coin.transform.position;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(sec);
        m_fieldOfView.exclamation.SetActive(false);
        Destroy(current.m_coin.gameObject);
        currentPathing = new follow(m_agent);
        currentPathing.followPath();
    }
    void Captured()
    {
        PauseMenu pm = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        pm.ShowMenu(2);
    }
    IEnumerator playerFoundFade(float FadeTick)
    {
        for (;;)
        {
            if (Time.timeScale >= .2 + FadeTick)
            {
                Time.timeScale -= FadeTick;
                BlurOptimized main = Camera.main.GetComponent<BlurOptimized>();
                main.blurSize += blurSpeed;
                yield return new WaitForSeconds(.01f);
            }
            else
            {
                Time.timeScale = 0;
                Captured();
                break;
            }
        }
    }
    public void FoundPlayer()
    {
        if (sounds.foundPlayerSounds.Count > 0 && Player.GetComponent<PlayerCont>().enabled)
        {
            GetComponent<AudioSource>().clip = sounds.foundPlayerSounds[Random.Range(0, sounds.alertSounds.Count)];
            GetComponent<AudioSource>().Play();
            Player.GetComponent<PlayerCont>().enabled = false;
            BlurOptimized blur = Camera.main.gameObject.GetComponent<BlurOptimized>();
            blur.enabled = true;
            StartCoroutine(playerFoundFade(fadeSpeed));
        }

        currentPathing = new coin(m_agent, Player);
        m_agent.destination = Player.position;
        m_agent.speed = findMoveSpeed;
        m_agent.angularSpeed = 500;
        m_agent.acceleration = 500;
    }
    public void FoundCoin(Transform coin)
    {
        GetComponent<AudioSource>().clip = sounds.alertSounds[Random.Range(0, sounds.alertSounds.Count)];
        GetComponent<AudioSource>().Play();
        m_agent.destination = coin.position;
        coin.GetComponent<CoinGrab>().grabbed = true;
        currentPathing = new coin(m_agent, coin);

        StartCoroutine(StayAtCoin(coinStayTime));
    }
    void Update()
    {
        m_fieldOfView.Find();
        currentPathing.followPath();
        GetComponent<Animator>().SetFloat("Velocity", m_agent.velocity.magnitude);
    }
    public void PlayWalk()
    {
        if (GetComponent<AudioSource>().isPlaying && GetComponent<AudioSource>().clip != sounds.moveSound)
        {

        }
        else
        {
            GetComponent<AudioSource>().clip = sounds.moveSound;
            GetComponent<AudioSource>().Play();
        }
    }
}
public class Pathing
{

    protected NavMeshAgent m_agent;
    public Pathing(NavMeshAgent agent)
    {
        m_agent = agent;

    }
    public virtual void followPath()
    {
        m_agent.GetComponent<MoveToNewIntersection>().followPath();
    }
}
public class follow : Pathing
{

    public follow(NavMeshAgent agent) : base(agent)
    {

    }
    public override void followPath()
    {
        if (m_agent.remainingDistance < 1)
        {
            base.followPath();
        }
    }
}
public class coin : Pathing
{
    public Transform m_coin;
    public coin(NavMeshAgent agent, Transform _coin) : base(agent)
    {
        m_coin = _coin;
    }
    public override void followPath()
    {
        m_agent.destination = m_coin.position;
    }
}