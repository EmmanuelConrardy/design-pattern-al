# Singleton

Pattern qui permet de n'avoir qu'une et une seule instance d'une instance 
pour tout le cycle de vie de l'application. 
C'est souvent utilis� pour les logger ou le cache. 
Cependant on peut l'utiliser aussi pour passer garder un �tat en m�moire.

## Exemple d'utilisation

Garder un objet en m�moire pour toute la dur�e de vie de l'application
on se rapproche vraiment du comportement d'une variable globale avec ses avantages et inconv�nients
on a tendance � surutiliser les singletons par confort mais cela a pour conc�quence
d'augmenter la complexit� de votre syst�me

De plus comme le constructeur est priv� (sinon on pourrait le recr�er) il est difficile
de cr�er des tests unitaires, et l'execution de l'instance peut �tre probl�matique (acc�s � la base de donn�es, ect.)
dans notre cas on doit souvent ruser en passe par une sous-classe testable.

## Images / analogie

Le monde est un singleton. Sauf si vous souhaitez cr�er des mondes parall�les. 
Il a une date de d�but (en mode public) et une date de fin (en mode priv�) 
une fois la date de fin atteinte il se "dispose". 

## Liens

https://refactoring.guru/design-patterns/singleton
