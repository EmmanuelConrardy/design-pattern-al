# Factory method

Ce pattern d&eacute;finie une interface ou une classe abstraite pour cr&eacute;er un objet, mais laisse les sous-classes d&eacute;cider de l'impl&eacute;mentation. Ce qui permet d'harmoniser entre toutes les sous-classe "comment" se fait l'instanciation (via l'interface et sa methode) et laisse la responsabilit&eacute; du "quoi" et "o&ugrave;" sont mise à jour les propri&eacute;t&eacute; dans les classes filles.

## Exemple d'utilisation

Quand on souhaite cr&eacute;er une famille d'objet. Attention on peut introduire beaucoup de sous-classe ce qui peut rendre le notre application plus complexe.


## Images / analogie

Tous les type de famille peuvent être r&eacute;psent&eacute; par une factory method. On pourrait imaginer une famille le "GrandPere", "Pere", "GrandMere", "Maman", "Soeur", "Fils" sans oublier la "Tante". 
Si un jour on souhaite ajouter la "b&eacute;b&eacute;" rien de plus simple il suffira juste de cr&eacute;er une la sous-classe correspondante.
Ce pattern favorise l'extension.

## Liens

https://refactoring.guru/design-patterns/factory-method

