# Builder

Ce pattern construit un objet complexe en utilisant des objets simples avec une approche &eacute;tape par &eacute;tape. Il est très utile quand les propri&eacute;t&eacute;s sont "strict" (immutable) ce qui permet de les configurer dans des &eacute;tapes plus souple. 
De plus il &eacute;vite d'avoir &agrave; manipuler/comprendre/retenir les constructeurs avec beaucoup d'arguments (surtout si les arguments sont optionnels). 
Enfin il est possible pour le client de r&eacute;utiliser le builder pour créer des instances similaires.
Il est souvent utilis&eacute; dans les tests unitaires quand il faut créer plusieurs instances d'un objet complexe avec des valeurs différentes.

## Exemple d'utilisation

Quand le constructeur de mon objet comporte trop d'argument ou que la plus part de ses arguments sont optionnels, je peux utiliser le builder.
En revanche sont &eacute;criture est assez volumineuse et augmente la complexit&eacute; du syst&egrave;me

## Images / analogie

Un recette de cuisine est un builder. 
En effet si on devait juste pr&eacute;parer un plat du genre "p&acirc;te au fromage" pas besoin de recette, on peut facilement "instancier" le plat en revanche si on souhaite pr&eacute;parer un "tournedos rossini" il faut "d&eacute;crire" chaque &eacute;tapes dans une recette &agrave; suivre pour concevoir notre plat de mani&egrave;re suffisamment claire et "r&eacute;-utilisable" par n'importe qui. 
De plus il est facile d'ajouter et d'adapter des &eacute;tapes pour modifier ou am&eacute;liorer la recette.
On pourra donc facilement faire un "tournedos rossini aux figues" sans modifier un &eacute;ventuel constructeur.

## Liens

https://refactoring.guru/design-patterns/builder
https://blog.xebia.fr/2016/12/28/design-pattern-builder-et-builder-sont-dans-un-bateau/
