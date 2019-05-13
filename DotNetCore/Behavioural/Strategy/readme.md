# Strategy - Behaviour

Ce pattern permet de choisir un algorithme parmi une famille en fonction d'un point sensible d'un contexte donn&eacute;.
Les algorithmes sont dans des classes concr&egrave;tes distinctes et sont interchangeables. 

## Exemple d'utilisation

On peut faire appel à Strategy avec un code avec plein de specificit&eacute;s (ex: plein de condition if ou des swicths abusifs),
on peut facilement cr&eacute;er un tronc commun et &eacute;crire les sp&eacute;cifier dans des classes concr&egrave;tes.

G&eacute;n&eacute;ralement on l'utilise aussi quand on doit faire un choix en fonction des entr&eacute;es utilisateurs.

## Images / analogie

On applique Strategy dans notre vie de tous les jours: le matin quand on part travailler via diff&eacute;rents 
moyens de transport (&agrave; pied, Long board, Velo, Bus, Metro).
En entrer nous avons notre humeur, le temps qu'il fait dehors et le temps de transport nous allons pouvoir faire un choix.

Sinon cela ressemble beaucoup &agrave; un "switch" sauf qu'en entr&eacute;e au lieu de d'avoir une valeur on aura plut&ocirc;t un contexte plus complexe.

## Liens

https://refactoring.guru/design-patterns/strategy
