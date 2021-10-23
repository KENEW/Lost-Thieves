using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] RectTransform texts;
    [SerializeField] float speed;
    [SerializeField] GameObject end;
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
        while(end.GetComponent<RectTransform>().position.y < 0)
        {
            var tmp = texts.transform.position;
            tmp.y = tmp.y + speed;
            texts.transform.position = tmp;
            float size = end.GetComponent<RectTransform>().position.y * -3000 / 10000;
            size = Mathf.Clamp(size, 0f, 1f);
            audioSource.volume = size;
            yield return new WaitForSeconds(speed);
        }
    }
    private void OnDisable()
    {
        audioSource.Stop();
    }
}
