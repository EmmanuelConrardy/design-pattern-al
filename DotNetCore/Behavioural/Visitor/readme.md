# Visitor
Ce patron repr&eacute;sente une op&eacute;ration &agrave; effectuer sur un ensemble d'objets. 
Il permet de modifier l'op&eacute;ration sans changer l'objet concern&eacute; ni la structure. 
Selon ce patron, les objets &agrave; modifier sont pass&eacute;s en param&egrave;tre &agrave; une classe tierce qui effectuera des modifications. Une classe abstraite Visitor d&eacute;finit l'interface de la classe tierce. Ce patron est utilis&eacute; notamment pour manipuler un jeu d'objets, où les objets peuvent avoir diff&eacute;rentes interfaces, qui ne peuvent pas être modifi&eacute;s

## Exemple d'utilisation
Travailler sur un code sensible plein de d&eacute;pendances.

On peut facilement ajouter de nouveaux traitements sans toucher &agrave; la hi&eacute;rarchie de nos objets (en POO "classique", on aurait impl&eacute;ment&eacute; de nouvelles m&eacute;thodes pour ajouter de nouvelles fonctionnalit&eacute;s). Grâce aux Visiteurs :

le code est plus clair (des fonctionnalit&eacute;s diff&eacute;rentes se trouvent dans des Visiteurs diff&eacute;rents)
des &eacute;quipes diff&eacute;rentes peuvent travailler sur des fonctionnalit&eacute;s diff&eacute;rentes sans gêner les autres &eacute;quipes
on n'est pas oblig&eacute; de tout recompiler &agrave; chaque ajout d'une fonctionnalit&eacute; (seul le code du Visiteur est recompil&eacute;)

## Images / analogie
Le vendeur porte &agrave; porte qui vend diff&eacute;rent artciles en fonction de sa client&egrave;le. 

## Liens

https://refactoring.guru/design-patterns/visitor
