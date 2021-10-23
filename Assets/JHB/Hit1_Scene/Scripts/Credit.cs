using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] GameObject texts;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
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
