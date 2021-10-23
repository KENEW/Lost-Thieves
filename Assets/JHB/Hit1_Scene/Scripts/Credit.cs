using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] RectTransform texts;
    [SerializeField] float speed;
    Vector3 originalPos;
    // Start is called before the first frame update
    private void Awake()
    {
        originalPos = texts.localPosition;
    }
    void OnEnable()
    {
        texts.localPosition = originalPos;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        StartCoroutine(GoUP());
    }
    IEnumerator GoUP()
    {
        while(true)
        {
            var tmp = texts.transform.position;
            tmp.y = tmp.y + speed;
            texts.transform.position = tmp;
            yield return new WaitForSeconds(speed);
        }
    }
    private void OnDisable()
    {
        audioSource.Stop();
    }
}
