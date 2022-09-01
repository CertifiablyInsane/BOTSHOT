using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class func_movelinear : MonoBehaviour
{
    [SerializeField] private Vector3 moveDistance;
    [SerializeField] private bool moveOnUse;
    [SerializeField] private float speed = 1;
    [SerializeField] private float autoCloseAfterTime = 0;
    [SerializeField] private AudioClip S_Open;
    [SerializeField] private AudioClip S_Close;

    private AudioSource audioSource;

    private Vector3 startPos;
    private Vector3 endPos;

    private bool open = false;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        startPos = transform.position;
        endPos = transform.position + moveDistance;
        if(moveOnUse)
        {
            gameObject.tag = "Usable";
        }
    }
    public void Open()
    {
        open = true;
        audioSource.clip = S_Open;
        StopAllCoroutines();
        StartCoroutine(Move(endPos));
    }
    public void Close()
    {
        open = false;
        audioSource.clip = S_Close;
        StopAllCoroutines();
        StartCoroutine(Move(startPos));
    }
    public void OnUsed()
    {
        Debug.Log("Used");
        if(moveOnUse)
        {
            if(!open)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }
    private IEnumerator Move(Vector3 goalPos)
    {
        audioSource.Play();
        float step = speed * Time.deltaTime;
        while (Vector3.Distance(transform.position, goalPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, goalPos, step);
            yield return null;
        }
        transform.position = goalPos;
        if(autoCloseAfterTime > 0 && open)
        {
            StartCoroutine(CloseAfterTime());
        }
    }
    private IEnumerator CloseAfterTime()
    {
        yield return new WaitForSeconds(autoCloseAfterTime);
        Close();
    }
}
