# Distributeur Automatique de Tickets – C#

Application console développée en **C# et .NET** permettant de gérer la distribution automatique de tickets dans une banque selon le type d'opération demandé par le client.

## Prérequis

Avant d'exécuter le projet, assurez-vous de disposer des éléments suivants :

- **.NET SDK** : installé sur votre ordinateur.
- **Visual Studio Code** ou Visual Studio : pour consulter et modifier le code source.
- **Git** : facultatif, pour récupérer le projet depuis GitHub.

Vérifier l'installation de .NET :

```bash
dotnet --version
```

Si une version s'affiche, le SDK .NET est installé.

## Installation et exécution

### 1. Cloner le dépôt

```bash
git clone https://github.com/KineynaThioub/DistributeurDeTicket.git
```

### 2. Accéder au dossier du projet

```bash
cd DistributeurDeTicket
```

### 3. Restaurer les dépendances

```bash
dotnet restore
```

### 4. Exécuter l'application

```bash
dotnet run
```

L'application démarre directement dans le terminal.

## Présentation du projet

Le programme simule un distributeur automatique de tickets pour une banque proposant trois types d'opérations :

| Code | Opération |
|:---:|---|
| V | Versement |
| R | Retrait |
| I | Informations |

Lorsqu'un client se présente, l'application lui demande de choisir son opération, puis de renseigner son numéro de compte, son nom et son prénom.

Un numéro de ticket lui est ensuite attribué automatiquement selon le service choisi.

**Exemples de tickets :**
- V-1 : premier client pour un versement.
- R-1 : premier client pour un retrait.
- I-1 : premier client pour les informations.
- V-2 : deuxième client pour un versement.

Chaque service possède son propre compteur indépendant.


<img width="993" height="733" alt="image" src="https://github.com/user-attachments/assets/612195dc-7f97-4c3e-82f0-637d73b46db4" />


## Technologies utilisées

- **Langage :** C#
- **Plateforme :** .NET
- **Type d'application :** Console
- **Gestion des fichiers :** System.IO


## Auteur

**Fatou Kine Thioub**

Projet réalisé dans le cadre des travaux pratiques en C# et .NET.

---

*Projet pédagogique – Gestion des fichiers et programmation C#.*
