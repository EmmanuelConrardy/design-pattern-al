# Strategy - Structure

Ce pattern permet de choisir un algorithme parmi une famille en fonction d'un point sensible d'un contexte donné.
Les algorithmes sont dans des classes concrètes distinctes et sont interchangeables. 

## Exemple d'utilisation

On peut faire appel à Strategy avec un code avec plein de specificités (ex: plein de condition if ou des swicths abusifs),
on peut facilement créer un tronc commun et écrire les spécifier dans des classes concrètes.

Généralement on l'utilise aussi quand on doit faire un choix en fonction des entrées utilisateurs.

## Images / analogie

On applique Strategy dans notre vie de tous les jours: le matin quand on part travailler via différents 
moyens de transport (à pied, Long board, Velo, Bus, Metro).
En entrer nous avons notre humeur, le temps qu'il fait dehors et le temps de transport nous allons pouvoir faire un choix.

Sinon ça ressemble beaucoup à un "switch" sauf qu'en entrée au lieu de d'avoir une valeur on aura plutôt un contexte plus complexe.

## Liens

https://refactoring.guru/design-patterns/strategy
