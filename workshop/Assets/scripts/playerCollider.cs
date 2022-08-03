using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollider : MonoBehaviour
{
    public GameObject optionsMenu;

    int counter = 0;

    public int lifeRemain = 2;
    public Text LifeRemainText;

    public Text myText;
    private GameObject _player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            counter++;

            myText.text = $"{counter}";
        }

        if (other.gameObject.CompareTag("block"))
        {
            lifeRemain--;

            if (lifeRemain == 0)
            {
                Destroy(_player);
                optionsMenu.gameObject.SetActive(true);
                Pause();
            }

            LifeRemainText.text = $"{lifeRemain}";
        }
    }
    void Pause()
    {
        Time.timeScale = 0;
        player.GameIsPaused = true;
    }
}
