using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float frameDuration = 0.1f;
    private AnimationSprites _spriteAnim;
    public AnimationSprites spriteAnim
    {
        get { return _spriteAnim; }
        set
        {
            StopAllCoroutines();
            _spriteAnim = value;
            if (_spriteAnim.sprites.Length > 1)
            {
                frameDuration = _spriteAnim.frameDuration;
                StartCoroutine(animateSprites());
            }
            else
                spriteRenderer.sprite = _spriteAnim.sprites[0];
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator animateSprites()
    {
        while (true) {
            foreach (Sprite sprite in spriteAnim.sprites)
            {
                spriteRenderer.sprite = sprite;
                yield return new WaitForSeconds(frameDuration);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
