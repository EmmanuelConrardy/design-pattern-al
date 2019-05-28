# COR

Chain of Responsibility ou "COR" est un design comportemental qui te laisse passer une requ&ecirc;te 
le long d'une chaine de "Handlers" aka "des objets qui g&egrave;rent la requ&ecirc;te".
Chaque "Handlers" decide si il execute ou pas son processus ou de passer la gestion au suivant.

## Exemple d'utilisation

COR porte bien son nom c'est en effet un enchaînement de traitements.
C'est souvent utilisé pour des r&egrave;gles d'éligibilités ou de validation.
C'est encore plus pratique si on doit modifier la chaine à l'execution.

## Images / analogie
Donc tous les "Traitements" sont une bonne analogie, par exemple le traitement d'un appel client à une hotline
(boite vocal, puis hotline niveau 1, puis hotline niveau 2)
ou le processus de recrutement en entreprise (Entretien en ligne, entretien RH, Entretien technique) ou un autre ordre ! 

## Liens

https://refactoring.guru/design-patterns/chain-of-responsibility
