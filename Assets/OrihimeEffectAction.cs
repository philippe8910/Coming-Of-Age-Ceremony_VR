using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrihimeEffectAction : MonoBehaviour
{
    public GameObject startEffect_1, startEffect_2 , orihimeEffect , dialogCanvas , levelSystem;

    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartEffect());

        IEnumerator StartEffect()
        {
            sound.Play();
            startEffect_1.SetActive(true);
            yield return new WaitForSeconds(3);
            startEffect_1.SetActive(false);
            startEffect_2.SetActive(true);
            orihimeEffect.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            startEffect_2.SetActive(false);
            yield return new WaitForSeconds(2f);
            dialogCanvas.SetActive(true);
            levelSystem.SetActive(true);
        }
    }
}
