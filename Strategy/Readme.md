# Strategy - Structure

Ce pattern permet de choisir un algorithme parmi une famille en fonction d'un point sensible d'un contexte donn�.
Les algorithmes sont dans des classes concr�tes distinctes et sont interchangeables. 

## Exemple d'utilisation

On peut faire appel � Strategy avec un code avec plein de specificit�s (ex: plein de condition if ou des swicths abusifs),
on peut facilement cr�er un tronc commun et �crire les sp�cifier dans des classes concr�tes.

G�n�ralement on l'utilise aussi quand on doit faire un choix en fonction des entr�es utilisateurs.

## Images / analogie

On applique Strategy dans notre vie de tous les jours: le matin quand on part travailler via diff�rents 
moyens de transport (� pied, Long board, Velo, Bus, Metro).
En entrer nous avons notre humeur, le temps qu'il fait dehors et le temps de transport nous allons pouvoir faire un choix.

Sinon �a ressemble beaucoup � un "switch" sauf qu'en entr�e au lieu de d'avoir une valeur on aura plut�t un contexte plus complexe.

## Liens

https://refactoring.guru/design-patterns/strategy
