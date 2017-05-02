using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour 
{

	[SerializeField] private GameObject torrePrefab;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private Jogador jogador;

	void Start()
	{
		gameOver.SetActive (false);
	}

	void Update()
	{

		if (JogoAcabou ()) {
			gameOver.SetActive (true);
		} else {
			if (ClicouComBotaoPrimario ()) {
				ConstroiTorre ();
			}
		}
		
	}

	private bool JogoAcabou()
	{
		return !jogador.EstaVivo ();
	}

	private bool ClicouComBotaoPrimario()
	{
		return Input.GetMouseButtonDown (0);
	}

	public void RecomecaJogo()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	private void ConstroiTorre()
	{
		Vector4 posicaoDoClique = Input.mousePosition;
		RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAteUmPonto (posicaoDoClique);

		if (elementoAtingidoPeloRaio.collider != null) 
		{
			Vector3 posicaoCriacaoDaTorre = elementoAtingidoPeloRaio.point;
			Instantiate (torrePrefab, posicaoCriacaoDaTorre, Quaternion.identity);
		}
	}

	private RaycastHit DisparaRaioDaCameraAteUmPonto(Vector3 pontoInicial)
	{
		Ray raio = Camera.main.ScreenPointToRay (pontoInicial);
		RaycastHit elementoAtingidoPeloRaio;
		float comprimentoMaximoDoRaio = 100.0f;
		Physics.Raycast (raio, out elementoAtingidoPeloRaio , comprimentoMaximoDoRaio);

		return elementoAtingidoPeloRaio;
	}
}
