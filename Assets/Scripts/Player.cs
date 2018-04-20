using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _weaponAudio;
    // Use this for initialization
    void Start ()
    {
        _controller = GetComponent<CharacterController>();
        // Hide mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If left click
        // Case ray from center point of main camera

        if (Input.GetMouseButton(0))
        {
            _muzzleFlash.SetActive(true);
            // if audio not playing 
            // play audio
            if (_weaponAudio.isPlaying == false)
            {
                _weaponAudio.Play();

            }
            Ray rayOrgions = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrgions, out hitInfo))
            {
                Debug.Log(message: "RayCast Hit: " + hitInfo.transform.name);
                GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
                Destroy(hitMarker, 1f);
            }
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponAudio.Stop();
        }

        // If Escape key pressed
        // Unhide mouse cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
}
