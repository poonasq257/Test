using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public GameObject laserPrefab;
    private SteamVR_TrackedObject trackedObj;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    public Transform cameraRigTransform;

    public LayerMask highlightLayerMask;
    private GameObject target = null;

    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    private bool shouldTeleport;
    public LayerMask teleportLayerMask;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
            laserTransform.localScale.y, hit.distance);
    }

    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;

        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
    }

    private void Teleport()
    {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = hitPoint + difference;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, highlightLayerMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);

                target = hit.collider.gameObject;
                target.GetComponent<Highlighting>().isHighlighted = true;

                //reticle.SetActive(true);
                //teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                //shouldTeleport = true;
            }
            else
            {
                laser.SetActive(false);
                if (target)
                {
                    target.GetComponent<Highlighting>().isHighlighted = false;
                    target = null;
                }
            }
        }
        else
        {
            laser.SetActive(false);
            reticle.SetActive(false);
        }

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (target)
            {
                if (GameManager.instance) GameManager.instance.SetCharacter(target.name);
                target.GetComponent<Highlighting>().isHighlighted = false;
                target = null;
                GameManager.instance.NextScene();
            }
            if (shouldTeleport) Teleport();
        }
    }
}