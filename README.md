# API Rest Clinique Rosemont (Projet Scolaire)

Cette API REST fait partie d'un projet scolaire visant à créer une application de gestion de prescriptions médicales. Elle sert de backend pour l'application, stockant et fournissant les informations nécessaires sur les patients et leurs prescriptions.

## Contexte

Ce projet a été développé dans le cadre d'un cours au cegep visant à mettre en pratique les concepts d'API REST. L'API fournit les données nécessaires pour l'application frontend qui permet aux médecins de rechercher des patients et d'accéder à leurs informations et prescriptions.

## Fonctionnalités

- **Enregistrement de nouveaux patients et médecins** : Fournit des endpoints pour enregistrer de nouveaux patients et médecins dans la base de données.
- **Authentification** : Fournit des endpoints pour authentifier les patients et les médecins, leur permettant de se connecter à l'application.
- **Recherche de patients** : Fournit un endpoint pour rechercher des patients par divers critères, tels que le nom, le prénom, la date de naissance, etc.
- **Accès aux informations des patients** : Fournit un endpoint pour accéder à toutes les informations associées à un patient spécifique.
- **Gestion des prescriptions** : Fournit des endpoints pour récupérer, ajouter, modifier et supprimer les prescriptions d'un patient spécifique.

Non, pour un projet .NET, vous auriez besoin de .NET Core ou .NET Framework installé sur votre machine, et vous utiliseriez généralement la commande `dotnet run` pour lancer l'application. Voici comment vous pourriez mettre à jour la section Installation :

## Installation

Suivez les instructions ci-dessous pour configurer et exécuter ce projet sur votre machine locale.

1. Clonez le dépôt sur votre machine locale :

```bash
git clone https://github.com/wwwnic/RestAPICliniqueRosemont.git
```

2. Accédez au répertoire du projet :

```bash
cd RestAPICliniqueRosemont
```

3. Assurez-vous d'avoir .NET Core ou .NET Framework installé sur votre machine. Vous pouvez le télécharger [ici](https://dotnet.microsoft.com/download) si nécessaire.

4. Lancez le serveur :

```bash
dotnet run
```

Votre API devrait être accessible à `http://localhost:5000` ou à l'URL que vous avez configurée (les applications .NET Core s'exécutent généralement sur le port 5000 par défaut).

## Utilisation

Une fois l'API installée et lancée, elle peut être utilisée pour fournir des données à l'application frontend. 

**Note** : Cette API nécessite une connexion à une base de données pour stocker et récupérer les informations sur les patients et leurs prescriptions. Assurez-vous d'avoir correctement configuré la connexion à la base de données.

## Contributions

Les contributions sont les bienvenues ! Pour contribuer, veuillez suivre les étapes suivantes :

1. Forkez le projet
2. Créez votre branche de fonctionnalité (`git checkout -b feature/AmazingFeature`)
3. Commitez vos changements (`git commit -m 'Add some AmazingFeature'`)
4. Poussez vers la branche (`git push origin feature/AmazingFeature`)
5. Ouvrez une Pull Request

## License

Ce projet est sous licence MIT. Pour plus de détails, veuillez vous référer au fichier [LICENSE](LICENSE).

## Contact

Si vous avez des questions, n'hésitez pas à me contacter.

## Auteur

- [Nicolas Brunet](https://github.com/wwwnic)
