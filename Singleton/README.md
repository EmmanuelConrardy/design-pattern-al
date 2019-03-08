# Singleton

Pattern qui permet de n'avoir qu'une et une seule instance d'une instance 
pour tout le cycle de vie de l'application. 
C'est souvent utilisé pour les logger ou le cache. 
Cependant on peut l'utiliser aussi pour passer garder un état en mémoire.

## Exemple d'utilisation

Garder un objet en mémoire pour toute la durée de vie de l'application
on se rapproche vraiment du comportement d'une variable globale avec ses avantages et inconvinients
on a tendance à sur-utiliser les singletons par confort mais cela à pour concéquence
d'augmenter la compléxité de votre système

De plus comme le contructeur est privé (sinon on pourrait le recréer) il est difficile
de créer des tests unitaires, et l'execution de l'instance peut être problèmatique (accès à la bases de données, ect...)
dans notre cas on doit souvent ruser en passe par une sous-classe testable.

## links

- https://refactoring.guru/design-patterns/singleton
