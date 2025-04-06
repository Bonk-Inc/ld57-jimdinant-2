using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BackgroundTile))]
public class TileSpriteChange : MonoBehaviour
{
    private BackgroundTile tile;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite grass, dirt, gradientDirt, darkDirt;

    [SerializeField]
    private float darkDirtDepth = -100, surfaceDepth = 0;

    private void Awake()
    {
        tile = GetComponent<BackgroundTile>();
        spriteRenderer = tile.Renderer;
        tile.onPositionChange += UpdateSprite;
    }

    private void UpdateSprite(Vector2 newPosition)
    {
        float y = newPosition.y;
        spriteRenderer.enabled = true;
        
        var flipXChance = Random.Range(0, 10);
        var flipYChance = Random.Range(0, 10);
        
        if (y > surfaceDepth)
        {
            spriteRenderer.enabled = y < surfaceDepth + tile.GetSize().y;
            spriteRenderer.sprite = grass;
            
            flipXChance = 1;
            flipYChance = 1;
        } else if (y < darkDirtDepth)
        {
            spriteRenderer.sprite = y < darkDirtDepth - tile.GetSize().y ? darkDirt : gradientDirt;

            if (y >= darkDirtDepth - tile.GetSize().y)
            {
                flipXChance = 1;
                flipYChance = 1;
            }
        }
        else
        {
            spriteRenderer.sprite = dirt;
        }
        
        spriteRenderer.flipX = flipXChance >= 6;
        spriteRenderer.flipY = flipYChance >= 6;
    }

}
