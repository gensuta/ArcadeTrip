using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actor",menuName = "Yarn Spinner/Actor",order = 0)]
public class Actor : ScriptableObject
{
	[SerializeField] string actorName;
	[SerializeField] VNSprite[] actorSprites;
	
	public Sprite GetSprite(string mySprite)
	{
		foreach(VNSprite v in actorSprites)
		{
			if(mySprite.Equals(v.SpriteName().Trim()))
			{
				return v.SpriteImage();
			}
		}

		return null;
	}

}

[System.Serializable]
public class VNSprite
{
	[SerializeField] string spriteName;
	[SerializeField] Sprite spriteImage;

	public string SpriteName()
	{
		return spriteName;
	}

	public Sprite SpriteImage()
	{
		return spriteImage;
	}
}
