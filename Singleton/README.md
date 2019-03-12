# Singleton

Pattern qui permet de n'avoir qu'une et une seule instance d'une instance 
pour tout le cycle de vie de l'application. 
C'est souvent utilisé pour les logger ou le cache. 
Cependant on peut l'utiliser aussi pour passer garder un état en mémoire.

## Exemple d'utilisation

Garder un objet en mémoire pour toute la durée de vie de l'application
on se rapproche vraiment du comportement d'une variable globale avec ses avantages et inconvénients
on a tendance à surutiliser les singletons par confort mais cela a pour concéquence
d'augmenter la complexité de votre système

De plus comme le constructeur est privé (sinon on pourrait le recréer) il est difficile
de créer des tests unitaires, et l'execution de l'instance peut être problématique (accès à la base de données, ect.)
dans notre cas on doit souvent ruser en passe par une sous-classe testable.

## Images / analogie

Le monde est un singleton. Sauf si vous souhaitez créer des mondes parallèles. 
Il a une date de début (en mode public) et une date de fin (en mode privé) 
une fois la date de fin atteinte il se "dispose". 

## Liens

https://refactoring.guru/design-patterns/singleton
