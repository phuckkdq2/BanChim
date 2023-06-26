using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : SingleDarwin
{
    private static BGController instance;
    public static BGController Instance { get => instance;}
    public Sprite[] sprites;
    public SpriteRenderer bgImage;


    public override void Awake() {
        BGController.instance = this;
    }

    public void Start() {
        ChangeSprite();  
    }

    void ChangeSprite(){
        if(bgImage != null && sprites != null && sprites.Length >0){
            int randomIdx = Random.Range(0 , sprites.Length);

            if(sprites[randomIdx] != null){
                bgImage.sprite = sprites[randomIdx];
            }
        }
    }
}
