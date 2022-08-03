using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GameIsPaused = false;

    public float speed = 1f;
    public float lerpSpeed = 1f;

    private float _elapsedTime = 2f;
    private float _defaultY;

    public AnimationCurve JumpCurve;
    public float jumpTime = 2f;
    public float jumpMultiplier = 1f;

    [SerializeField] private GameObject[] paths;
    private float _timePassed = 0f;
    private float _limit = 9.95f;

    [SerializeField] private GameObject _arch;
    private float _timePassed2;
    private float _limit2 = 6.55f;

    void Start()
    {
        _defaultY = transform.position.y;
    }

    void Update()
    {
        if(!GameIsPaused)
        {
            handleCommand();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Resume();
        }
    }

    void handleCommand()
    {
        _timePassed += Time.deltaTime;
        _timePassed2 += Time.deltaTime;

        if (_elapsedTime < jumpTime)
        {
            _elapsedTime += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q) && transform.position.z < 1.1)
        {
            var position = transform.position;
            position = Vector3.Lerp(position, position + (Vector3.forward * (Time.deltaTime * speed)), lerpSpeed);
            transform.position = position;
        }

        if (Input.GetKey(KeyCode.D) && transform.position.z > -1.1)
        {
            var position = transform.position;
            position = Vector3.Lerp(position, position + (Vector3.back * (Time.deltaTime * speed)), lerpSpeed);
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _elapsedTime >= jumpTime)
        {
            _elapsedTime = 0f;
        }

        if (_elapsedTime <= jumpTime)
        {
            var tmp = transform.position;
            tmp.y = _defaultY + (JumpCurve.Evaluate(_elapsedTime / jumpTime) * jumpMultiplier);
            transform.position = tmp;
        }

        if (_timePassed > _limit)
        {
            _timePassed = 0f;
            Instantiate(paths[Random.Range(0, paths.Length)], new Vector3(87.8f, 0, 0), Quaternion.identity);
        }

        if (_timePassed2 > _limit2)
        {
            _timePassed2 = 0f;
            GameObject newARch = Instantiate(_arch, new Vector3(74f, -14.9f, 24.6f), Quaternion.identity);
            newARch.transform.Rotate(90f, -90f, 0);
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1;
        GameIsPaused = false;
    }
}
