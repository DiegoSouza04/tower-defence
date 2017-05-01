using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	public float tempoDeRecarga = 0.5f;
	private float momentoDoUltimoDisparo;

	// Use this for initialization
	void Update () {
		Atira ();
	}

	private void Atira(){

		float tempoAtual = Time.time;


		if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga) {
			momentoDoUltimoDisparo = tempoAtual;
			GameObject pontoDeDisparo = this.transform.Find ("CanhaoDaTorre/PontoDeDisparo").gameObject;
			Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
			Instantiate (projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);
		}
	}
}
