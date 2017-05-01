using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour {

	[SerializeField] private GameObject torrePrefab;

	void Update()
	{
		if (ClicouComBotaoPrimario ())
		{
			ConstroiTorre ();
		}
		
	}

	private bool ClicouComBotaoPrimario()
	{
		return Input.GetMouseButtonDown (0);
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
