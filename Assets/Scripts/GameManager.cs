using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float playerHealth = 100.0f;
    
    //Cached reference
    private SpawnCoin _spawnCoin;
    [SerializeField] private GameObject _player;
    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWin;
    [SerializeField] private Button _btnReset;
    public Slider _healthBar;

    private int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _spawnCoin = FindObjectOfType<SpawnCoin>();
        _txtWin.gameObject.SetActive(false);
        _btnReset.onClick.AddListener(GameOver);
        _btnReset.gameObject.SetActive(false);
        Time.timeScale = 1.0f;

        CollectCoin.onCollectCoin += IncrementarMonedas;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(0);
    }

    public void IncrementarMonedas()
    {
        if (coinCount <= 3)
        {
            coinCount++;
            //Debug.Log($"You have ${coinCount*10}");
            _txtCoins.text = "POINTS: " + coinCount * 10;
            //CollectCoin.onCollectCoin -= IncrementarMonedas;
            _spawnCoin.SpawnNewCoin();
        }
        else
        {
            EndLevel("You Win!");
            CollectCoin.onCollectCoin -= IncrementarMonedas;
        }
        
    }

    public void TakeDamage(float damageAmount)
    {
        playerHealth = playerHealth - damageAmount;
        _healthBar.value = playerHealth;
        
        //Debug.Log("Player health : " + playerHealth);
        
        if (playerHealth <= 0.0f)
        {
            // die
            Destroy(_player);
            EndLevel("You Die!");
        }
    }

    private void EndLevel(string message)
    {
        _txtWin.gameObject.SetActive(true);
        _txtWin.text = message;
        _btnReset.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
            
        //Pausar el juego
        Time.timeScale = 0;
    }
    
}
