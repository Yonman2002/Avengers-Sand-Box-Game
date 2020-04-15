using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float count = 0;
    private float oneHeartSize;

    public Image healthBar;
    public bool isEnemy;
    public float healthAmount;
    public float invincibilityTime;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.rectTransform.sizeDelta = new Vector2((oneHeartSize = healthBar.rectTransform.sizeDelta.x) * healthAmount, healthBar.rectTransform.sizeDelta.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            if (isEnemy)
            {
                Destroy(gameObject);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (count >= 0)
        {
            count -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Damage damage = collision.gameObject.GetComponent<Damage>();
        if (damage != null && count <= 0)
        {
            if (isEnemy != damage.isEnemy)
            {
                healthAmount -= damage.damageAmount;
                count = invincibilityTime;
                healthBar.rectTransform.sizeDelta = new Vector2(oneHeartSize * healthAmount, healthBar.rectTransform.sizeDelta.y);
            }
        }
    }
}
