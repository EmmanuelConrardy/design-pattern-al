# Singleton

Pattern qui permet de n'avoir qu'une et une seule instance d'une instance 
pour tout le cycle de vie de l'application. 
C'est souvent utilis� pour les logger ou le cache. 
Cependant on peut l'utiliser aussi pour passer garder un �tat en m�moire.

## Exemple d'utilisation

Garder un objet en m�moire pour toute la dur�e de vie de l'application
on se rapproche vraiment du comportement d'une variable globale avec ses avantages et inconvinients
on a tendance � sur-utiliser les singletons par confort mais cela � pour conc�quence
d'augmenter la compl�xit� de votre syst�me

De plus comme le contructeur est priv� (sinon on pourrait le recr�er) il est difficile
de cr�er des tests unitaires, et l'execution de l'instance peut �tre probl�matique (acc�s � la bases de donn�es, ect...)
dans notre cas on doit souvent ruser en passe par une sous-classe testable.

## links

- https://refactoring.guru/design-patterns/singleton
