# Singleton

Pattern qui permet de n'avoir qu'une et une seule instance d'un objet
pour tout le cycle de vie de l'application. 
C'est souvent utilis&eacute; pour les logger ou le cache. 
Cependant on peut l'utiliser aussi pour passer garder un &eacute;tat en m&eacute;moire.

## Exemple d'utilisation

Garder un objet en m&eacute;moire pour toute la dur&eacute;e de vie de l'application
on se rapproche vraiment du comportement d'une variable globale avec ses avantages et inconv&eacute;nients.
On a tendance &agrave; sur-utiliser les singletons par confort mais cela a pour conc&eacute;quence
d'augmenter la complexit&eacute; de votre syst&egrave;me

De plus comme le constructeur est priv&eacute; (sinon on pourrait le recr&eacute;er) il est difficile
de cr&eacute;er des tests unitaires, et l'execution de l'instance peut 	&ecirc;tre probl&eacute;matique (acc&egrave;s &agrave; la base de donn&eacute;es, ect.)
dans notre cas on doit souvent ruser en passant par une sous-classe testable.

## Images / analogie

Le monde est un singleton. Sauf si vous souhaitez cr&eacute;er des mondes parall&egrave;les. 
Il a une date de d&eacute;but (en mode public) et une date de fin (en mode priv&eacute;) 
une fois la date de fin atteinte il se "dispose". 

## Liens

https://refactoring.guru/design-patterns/singleton
