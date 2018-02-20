using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureFill : MonoBehaviour {
	
	public int objCount = 10;
	public int rows;
	public Texture2D[] textures = null;
	public int textureSize = 1024;
	public List<GameObject> _instances; 
	public Material mat;

	// Use this for initialization
	void Start () {

		Texture2DArray textureArray = new Texture2DArray(textureSize, textureSize, textures.Length, TextureFormat.RGBA32, false);

		for (int i = 0; i < textures.Length; i++)
		{
			Graphics.CopyTexture(textures[i], 0, 0, textureArray, i, 0); // i is the index of the texture
		}

		mat.SetTexture("_Textures", textureArray);

		for(int j=0; j < rows; j++) {
		
		for(int i=0; i< objCount; i++){
			GameObject newObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			newObj.transform.position = new Vector3(Random.Range(-20,20),j*2,Random.Range(-20,20));
			newObj.GetComponent<MeshRenderer>().material = mat;
			newObj.transform.parent = gameObject.transform;
			_instances.Add(newObj);
		}
		}

		foreach (var obj in _instances)
		{
			
			MaterialPropertyBlock props = new MaterialPropertyBlock();
			props.SetFloat("_TextureIndex", Random.Range(0, textures.Length));
			float r = Random.Range(0.0f, 1.0f);
   			float g = Random.Range(0.0f, 1.0f);
   			float b = Random.Range(0.0f, 1.0f);
   			props.SetColor("_Color", new Color(r, g, b));
			var renderer = obj.GetComponent<MeshRenderer>();
			//renderer.material.SetTexture("_Textures", textureArray);
			renderer.SetPropertyBlock(props);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
