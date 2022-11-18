/*
Cette fonction s'occupe d'envoyer une requete AJAX vers l'url spécifiée.
Voici les paramètres :
-url: l'URL vers ou la requête AJAX sera envoyée.
-callback: la fonction qui va gérer la réponse du serveur.
-httpMethod: la méthode d'envoi de la requête (GET, si non fournie).
-data: données optionnelles qu'on peut envoyer avec la requête (null, si non fourni).
*/
function ajax(url,fonctionDeCallback,httpMethod,data,contentType) {

	var xhr = new XMLHttpRequest();

	if (!data) data = null;

	if (!httpMethod) httpMethod = 'GET';

	xhr.onreadystatechange = fonctionDeCallback;
	try
	{
		xhr.open(httpMethod,url,true);
	}
	catch (e)
	{
	  alert(e);
	}
	if (contentType) {
		//alert(contentType);
		xhr.setRequestHeader("Content-type", contentType);
	}
	xhr.send(data);
}
