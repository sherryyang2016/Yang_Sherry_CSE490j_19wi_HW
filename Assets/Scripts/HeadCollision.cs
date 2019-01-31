using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HeadCollision : MonoBehaviour
{
    public PostProcessVolume volume;
    public float fadespeed = 0.5f;

    private float exposureMax = 0.0f;
    private float exposureMin = -10.0f;
    private bool hasEntered = false;

    public List<GameObject> fadeOutGameObjects;

    private GameObject enteredGameObject;

    private float timer = 0.0f;


    ColorGrading colorGradingLayer = null;

    void Start()
    {
        volume.profile.TryGetSettings(out colorGradingLayer);
    }

    void OnTriggerEnter(Collider other)
    {
        if (fadeOutGameObjects.Contains(other.gameObject))
        {
            hasEntered = true;
            enteredGameObject = other.gameObject;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (hasEntered && other.gameObject == enteredGameObject)
        {
            hasEntered = false;
            enteredGameObject = null;
        }
    }

    void Update()
    {
        if (hasEntered)
        {
            timer += Time.deltaTime;
            float exposureValue = Mathf.Lerp(exposureMax, exposureMin, timer / fadespeed);
            colorGradingLayer.postExposure.value = exposureValue;
        }
        if (!hasEntered && timer > 0)
        {
            timer -= Time.deltaTime;
            float exposureValue = Mathf.Lerp(exposureMax, exposureMin, timer / fadespeed);
            colorGradingLayer.postExposure.value = exposureValue;
        }
    }

}

