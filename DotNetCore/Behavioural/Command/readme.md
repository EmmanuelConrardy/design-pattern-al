# Command

The Command design pattern encapsulates a request as an object,
thereby allowing us developers to treat that request differently based 
upon what class receives said command.  Further, it enables much more complex architectures, 
and even enables operations such as undo/redo. 

The Chain of Responsibility pattern fits well with the Command pattern, 
as the former can use objects of the latter to represent its requests.


## Exemple d'utilisation
Le pattern commande des actions ou des requêtes des boutton d'une interface graphique

## Images / analogie

Les buttons plus, moins, diviser, multiplier d'une calculatrice sont des "commandes".
La note du serveur passser en cuisine est une commande pour les cuisinier.
On peut imaginer la "pile" de commande qui arrive et le "traitement" en différé 
quand les cuisinier seront disponible


## Liens

https://refactoring.guru/design-patterns/command
